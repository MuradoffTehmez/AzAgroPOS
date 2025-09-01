using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Servisler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    public class SatisPresenter
    {
        private readonly ISatisView _view;
        private readonly SatisManager _satisManager;
        private readonly MehsulManager _mehsulManager;
        private readonly MusteriManager _musteriManager;

        private BindingList<SatisSebetiElementiDto> _aktivSebet;
        private readonly List<GozleyenSatis> _gozleyenSebetler;
        private decimal _endirimMeblegi = 0;

        public SatisPresenter(ISatisView view)
        {
            _view = view;
            var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
            _satisManager = new SatisManager(unitOfWork);
            _mehsulManager = new MehsulManager(unitOfWork);
            _musteriManager = new MusteriManager(unitOfWork);

            _aktivSebet = new BindingList<SatisSebetiElementiDto>();
            _gozleyenSebetler = new List<GozleyenSatis>();

            _view.SebeteMehsullariGoster(_aktivSebet);
            AbuneOl();
        }

        private void AbuneOl()
        {
            _view.FormYuklendiIstek += async (s, e) => await FormuYukle();
            _view.MehsulAxtarIstek += async (s, e) => await MehsulAxtar();
            _view.SebeteElaveEtIstek += (s, e) => SebeteElaveEt();
            _view.SuretliSatisIstek += (s, mehsul) => SebeteElaveEt(mehsul);
            _view.SebetdenSilIstek += (s, e) => SebetdenSil();
            _view.SebetiTemizleIstek += (s, e) => SebetiTemizle();
            _view.SatisiGozletIstek += (s, e) => SatisiGozlet();
            _view.GozleyenSatisiAcIstek += (s, e) => _view.GozleyenSatislarMenyusunuGoster(_gozleyenSebetler);
            _view.SatisiTesdiqleIstek += async (s, odenisMetodu) => await SatisiTesdiqle(odenisMetodu);
            _view.IndirimIstek += (s, faiz) => IndirimEt(faiz);
            _view.SebetMiqdarArtirIstek += (s, mehsulId) => SebetMiqdarDeyisdir(mehsulId, 1);
            _view.SebetMiqdarAzaltIstek += (s, mehsulId) => SebetMiqdarDeyisdir(mehsulId, -1);
            _view.MusteriSiyahisiniYenileIstek += async (s, e) => await MusterileriYukle();
        }

        private async Task FormuYukle()
        {
            await MusterileriYukle();
            await MehsulAxtar();
            await SuretliSatisMehsullariniGetir();
        }

        public async Task MusterileriYukle()
        {
            var musteriNetice = await _musteriManager.ButunMusterileriGetirAsync();
            if (musteriNetice.UgurluDur)
            {
                _view.MusteriSiyahisiniGoster(musteriNetice.Data);
            }
        }

        private async Task SuretliSatisMehsullariniGetir()
        {
            var netice = await _mehsulManager.AxtarAsync("", 30);
            if (netice.UgurluDur)
            {
                _view.SuretliSatisMehsullariniGoster(netice.Data);
            }
        }

        private async Task MehsulAxtar()
        {
            var netice = await _mehsulManager.AxtarAsync(_view.AxtarisMetni, 100);
            if (netice.UgurluDur)
            {
                _view.AxtarisNeticeleriniGoster(netice.Data);
            }
        }

        private void SebeteElaveEt(MehsulDto? mehsul = null)
        {
            var secilmisMehsul = mehsul ?? _view.SecilmisAxtarisMehsulu;
            if (secilmisMehsul == null) return;

            if (!decimal.TryParse(_view.SecilmisMehsulMiqdari, out decimal miqdar) || miqdar <= 0)
            {
                miqdar = 1;
            }

            var movcudElement = _aktivSebet.FirstOrDefault(e => e.MehsulId == secilmisMehsul.Id);
            if (movcudElement != null)
            {
                movcudElement.Miqdar += miqdar;
            }
            else
            {
                _aktivSebet.Add(new SatisSebetiElementiDto
                {
                    MehsulId = secilmisMehsul.Id,
                    MehsulAdi = secilmisMehsul.Ad,
                    Miqdar = miqdar,
                    VahidinQiymeti = secilmisMehsul.PerakendeSatisQiymeti
                });
            }
            _aktivSebet.ResetBindings();
            GosterisleriYenile();
            if (mehsul == null) _view.AxtarisPaneliniSifirla();
        }

        private void SebetMiqdarDeyisdir(int mehsulId, decimal deyisiklik)
        {
            var element = _aktivSebet.FirstOrDefault(e => e.MehsulId == mehsulId);
            if (element != null)
            {
                element.Miqdar += deyisiklik;
                if (element.Miqdar <= 0)
                {
                    _aktivSebet.Remove(element);
                }
                _aktivSebet.ResetBindings();
                GosterisleriYenile();
            }
        }

        private void SebetdenSil()
        {
            var secilmisSebetElementi = _view.SecilmisSebetElementi;
            if (secilmisSebetElementi != null)
            {
                _aktivSebet.Remove(secilmisSebetElementi);
                GosterisleriYenile();
            }
        }

        private void SebetiTemizle()
        {
            if (_aktivSebet.Any())
            {
                var cavab = _view.MesajGoster("Səbəti tamamilə təmizləmək istədiyinizə əminsinizmi?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cavab == DialogResult.Yes)
                {
                    FormuTamSifirla();
                }
            }
        }

        private void IndirimEt(decimal faiz)
        {
            decimal umumiMebleg = _aktivSebet.Sum(e => e.UmumiMebleg);
            if (umumiMebleg > 0)
            {
                _endirimMeblegi = umumiMebleg * (faiz / 100);
                GosterisleriYenile();
                _view.MesajGoster($"{_endirimMeblegi:N2} AZN endirim tətbiq edildi.", "Endirim", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SatisiGozlet()
        {
            if (!_aktivSebet.Any())
            {
                _view.MesajGoster("Gözlətmək üçün səbət boşdur.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string ad = $"Satış {DateTime.Now:HH:mm:ss}";
            _gozleyenSebetler.Add(new GozleyenSatis(ad, _aktivSebet.ToList()));
            _view.GozleyenSatislarSayiniGuncelle(_gozleyenSebetler.Count);
            FormuTamSifirla();
        }

        public void GozleyenSatisiSec(GozleyenSatis satis)
        {
            if (_aktivSebet.Any())
            {
                var cavab = _view.MesajGoster("Aktiv səbət mövcuddur. Dəyişikliklər itəcək. Davam etmək istəyirsiniz?", "Xəbərdarlıq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cavab == DialogResult.No) return;
            }
            _aktivSebet = new BindingList<SatisSebetiElementiDto>(satis.Sebet);
            _gozleyenSebetler.Remove(satis);
            _view.GozleyenSatislarSayiniGuncelle(_gozleyenSebetler.Count);
            _view.SebeteMehsullariGoster(_aktivSebet);
            GosterisleriYenile();
        }

        private async Task SatisiTesdiqle(OdenisMetodu odenisMetodu)
        {
            if (!AktivSessiya.AktivNovbeId.HasValue)
            {
                _view.MesajGoster("Aktiv növbə yoxdur. Satış etmək mümkün deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_aktivSebet.Any())
            {
                _view.MesajGoster("Satış üçün səbət boşdur.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var musteriId = _view.SecilmisMusteriId;
            if (odenisMetodu == OdenisMetodu.Nisyə && !musteriId.HasValue)
            {
                _view.MesajGoster("Nisyə satış üçün müştəri seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal umumiMebleg = _aktivSebet.Sum(e => e.UmumiMebleg);
            decimal yekunMebleg = umumiMebleg - _endirimMeblegi;

            var satisDto = new SatisYaratDto
            {
                SebetElementleri = _aktivSebet.ToList(),
                OdenisMetodu = odenisMetodu,
                NovbeId = AktivSessiya.AktivNovbeId.Value,
                MusteriId = musteriId,
                UmumiMebleg = umumiMebleg,
                Endirim = _endirimMeblegi,
                YekunMebleg = yekunMebleg
            };

            var netice = await _satisManager.SatisYaratAsync(satisDto);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Satış uğurla tamamlandı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FormuTamSifirla();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GosterisleriYenile()
        {
            decimal umumiMebleg = _aktivSebet.Sum(e => e.UmumiMebleg);
            decimal yekunMebleg = umumiMebleg - _endirimMeblegi;
            _view.UmumiMebligiGoster(umumiMebleg, _endirimMeblegi, yekunMebleg);
        }

        private void FormuTamSifirla()
        {
            _aktivSebet.Clear();
            _endirimMeblegi = 0;
            _view.FormuTamSifirla();
            GosterisleriYenile();
        }
    }
}