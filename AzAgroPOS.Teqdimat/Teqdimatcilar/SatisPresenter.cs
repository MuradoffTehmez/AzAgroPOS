// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/SatisPresenter.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Servisler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;
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
        private readonly NisyeManager _nisyeManager;

        private BindingList<SatisSebetiElementiDto> _aktivSebet;
        private readonly List<GozleyenSatis> _gozleyenSebetler;

        public SatisPresenter(ISatisView view)
        {
            _view = view;
            var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
            _satisManager = new SatisManager(unitOfWork);
            _mehsulManager = new MehsulManager(unitOfWork);
            _nisyeManager = new NisyeManager(unitOfWork);

            _aktivSebet = new BindingList<SatisSebetiElementiDto>();
            _gozleyenSebetler = new List<GozleyenSatis>();

            _view.SebeteMehsullariGoster(_aktivSebet);

            // Hadisələrə abunə oluruq
            _view.FormYuklendiIstek += async (s, e) => await FormuYukle();
            _view.MehsulAxtarIstek += async (s, e) => await MehsulAxtar();
            _view.SebeteElaveEtIstek += (s, e) => SebeteElaveEt();
            _view.SebetdenSilIstek += (s, e) => SebetdenSil();
            _view.SebetiTemizleIstek += (s, e) => SebetiTemizle(); // YENİ
            _view.MiqdariDeyisIstek += (s, e) => MiqdariDeyis();
            _view.SatisiGozletIstek += (s, e) => SatisiGozlet();
            _view.GozleyenSatisiAcIstek += (s, e) => _view.GozleyenSatislarMenyusunuGoster(_gozleyenSebetler);
            _view.SatisiTesdiqleIstek += async (s, odenisMetodu) => await SatisiTesdiqle(odenisMetodu);
        }

        // Form ilk dəfə yüklənəndə həm müştəriləri, həm də bütün məhsulları gətirir
        private async Task FormuYukle()
        {
            var musteriNetice = await _nisyeManager.MusterileriGetirAsync();
            if (musteriNetice.UgurluDur)
            {
                _view.MusteriSiyahisiniGoster(musteriNetice.Data);
            }
            // Axtarış qutusunu boş saxlayaraq bütün məhsulları gətiririk
            await MehsulAxtar();
        }

        private async Task MehsulAxtar()
        {
            var netice = await _mehsulManager.ButunMehsullariGetirAsync();
            if (netice.UgurluDur)
            {
                var axtarisMetni = _view.AxtarisMetni.ToLower();
                if (string.IsNullOrWhiteSpace(axtarisMetni))
                {
                    _view.AxtarisNeticeleriniGoster(netice.Data.ToList());
                    return;
                }

                var filterlenmis = netice.Data.Where(m =>
                    m.Ad.ToLower().Contains(axtarisMetni) ||
                    m.StokKodu.ToLower().Contains(axtarisMetni) ||
                    m.Barkod.ToLower().Contains(axtarisMetni)
                ).ToList();
                _view.AxtarisNeticeleriniGoster(filterlenmis);
            }
        }

        private void SebetiTemizle()
        {
            if (_aktivSebet.Any())
            {
                var cavab = _view.MesajGoster("Səbəti tamamilə təmizləmək istədiyinizə əminsinizmi?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cavab == DialogResult.Yes)
                {
                    _aktivSebet.Clear();
                    GosterisleriYenile();
                }
            }
        }

        private void SebeteElaveEt()
        {
            var secilmisMehsul = _view.SecilmisAxtarisMehsulu;
            if (secilmisMehsul == null) return;

            if (!int.TryParse(_view.SecilmisMehsulMiqdari, out int miqdar) || miqdar <= 0)
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
                    VahidinQiymeti = secilmisMehsul.PerakendeSatisQiymeti,
                    QiymetNövü = "Pərakəndə"
                });
            }
            _aktivSebet.ResetBindings();
            GosterisleriYenile();
            _view.AxtarisPaneliniSifirla();
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

        private void MiqdariDeyis()
        {
            _aktivSebet.ResetBindings();
            GosterisleriYenile();
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
            _view.FormuTamSifirla();
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

            if (odenisMetodu == OdenisMetodu.Nisyə && !_view.SecilmisMusteriId.HasValue)
            {
                _view.MesajGoster("Nisyə satış üçün müştəri seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var satisDto = new SatisYaratDto
            {
                SebetElementleri = _aktivSebet.ToList(),
                OdenisMetodu = odenisMetodu,
                NovbeId = AktivSessiya.AktivNovbeId.Value,
                MusteriId = _view.SecilmisMusteriId
            };

            var netice = await _satisManager.SatisYaratAsync(satisDto);

            if (netice.UgurluDur)
            {
                _view.MesajGoster("Satış uğurla tamamlandı!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var qebzDto = new SatisQebzDto
                {
                    SatisId = netice.Data.Id,
                    Tarix = netice.Data.Tarix,
                    KassirAdi = AktivSessiya.AktivIstifadeci?.TamAd ?? "Naməlum",
                    SatilanMehsullar = new List<SatisSebetiElementiDto>(_aktivSebet)
                };
                CapServisi capServisi = new CapServisi();
                capServisi.AftomatikCapaGonder(qebzDto);

                _view.FormuTamSifirla();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GosterisleriYenile()
        {
            _view.UmumiMebligiGoster(_aktivSebet.Sum(e => e.UmumiMebleg));
        }
    }
}