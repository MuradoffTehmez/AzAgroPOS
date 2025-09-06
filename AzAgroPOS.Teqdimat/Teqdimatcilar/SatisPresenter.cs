using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using System.ComponentModel;

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
        // Store individual item discounts and calculate cart discount dynamically
        // For simplicity, we'll keep a simple cart-level discount for now, but prepare for item-level.
        private decimal _cartLevelEndirimMeblegi = 0;

        public SatisPresenter(ISatisView view, SatisManager satisManager, MehsulManager mehsulManager, MusteriManager musteriManager)
        {
            _view = view;
            _satisManager = satisManager;
            _mehsulManager = mehsulManager;
            _musteriManager = musteriManager;
            _aktivSebet = new BindingList<SatisSebetiElementiDto>();
            _gozleyenSebetler = new List<GozleyenSatis>();

            _view.SebeteMehsullariGoster(_aktivSebet);
            AbuneOl();
        }

        private async void AbuneOl()
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
            _view.IndirimIstek += (s, endirimParam) => IndirimEt(endirimParam);
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

            // Müştəri ekranına məhsul əlavə edildiyini bildir
            _view.MusteriEkraniYenile(secilmisMehsul.Ad, secilmisMehsul.PerakendeSatisQiymeti, miqdar);
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

        private void IndirimEt(EndirimParametrləriDto endirimParam)
        {
            if (!_aktivSebet.Any())
            {
                _view.StatusMesajiGoster("Səbət boşdur. Endirim tətbiq etmək mümkün deyil.", StatusMesajiNovu.Xeta);
                return;
            }

            decimal umumiMebleg = _aktivSebet.Sum(e => e.VahidinQiymeti * e.Miqdar); // Calculate total before any discount
            decimal appliedDiscount = 0;

            if (endirimParam.Scope == EndirimScope.Cart)
            {
                if (endirimParam.Type == EndirimType.Percentage)
                {
                    appliedDiscount = umumiMebleg * (endirimParam.Value / 100);
                    _cartLevelEndirimMeblegi = appliedDiscount;
                }
                else if (endirimParam.Type == EndirimType.FixedAmount)
                {
                    appliedDiscount = Math.Min(endirimParam.Value, umumiMebleg); // Cannot discount more than total
                    _cartLevelEndirimMeblegi = appliedDiscount;
                }
                // Reset item-level discounts when applying cart-level discount
                foreach (var item in _aktivSebet)
                {
                    item.EndirimMeblegi = 0;
                }
            }
            else if (endirimParam.Scope == EndirimScope.SelectedItem)
            {
                var secilmisSebetElementi = _view.SecilmisSebetElementi;
                if (secilmisSebetElementi == null)
                {
                    _view.StatusMesajiGoster("Zəhmət olmasa, endirim tətbiq etmək üçün bir məhsul seçin.", StatusMesajiNovu.Xeta);
                    return;
                }

                // Reset cart-level discount when applying item-level discount
                _cartLevelEndirimMeblegi = 0;

                decimal itemTotalBeforeDiscount = secilmisSebetElementi.VahidinQiymeti * secilmisSebetElementi.Miqdar;

                if (endirimParam.Type == EndirimType.Percentage)
                {
                    appliedDiscount = itemTotalBeforeDiscount * (endirimParam.Value / 100);
                }
                else if (endirimParam.Type == EndirimType.FixedAmount)
                {
                    appliedDiscount = Math.Min(endirimParam.Value, itemTotalBeforeDiscount); // Cannot discount more than item total
                }

                secilmisSebetElementi.EndirimMeblegi = appliedDiscount;
            }

            GosterisleriYenile();
            _view.StatusMesajiGoster($"{appliedDiscount:N2} AZN endirim tətbiq edildi.", StatusMesajiNovu.Ugurlu);
        }

        private void SatisiGozlet()
        {
            if (!_aktivSebet.Any())
            {
                _view.StatusMesajiGoster("Gözlətmək üçün səbət boşdur.", StatusMesajiNovu.Xeta);
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
                _view.StatusMesajiGoster("Satış üçün səbət boşdur.", StatusMesajiNovu.Xeta);
                return;
            }

            var musteriId = _view.SecilmisMusteriId;
            if (odenisMetodu == OdenisMetodu.Nisyə && !musteriId.HasValue)
            {
                _view.StatusMesajiGoster("Nisyə satış üçün müştəri seçin.", StatusMesajiNovu.Xeta);
                return;
            }

            decimal umumiMebleg = _aktivSebet.Sum(e => e.VahidinQiymeti * e.Miqdar); // Total before any discount
            decimal totalItemDiscount = _aktivSebet.Sum(e => e.EndirimMeblegi); // Total discount from items
            decimal totalDiscount = totalItemDiscount + _cartLevelEndirimMeblegi;
            decimal yekunMebleg = umumiMebleg - totalDiscount;

            var satisDto = new SatisYaratDto
            {
                SebetElementleri = _aktivSebet.ToList(),
                OdenisMetodu = odenisMetodu,
                NovbeId = AktivSessiya.AktivNovbeId.Value,
                MusteriId = musteriId,
                UmumiMebleg = umumiMebleg,
                Endirim = _cartLevelEndirimMeblegi,
                YekunMebleg = yekunMebleg
            };

            var netice = await _satisManager.SatisYaratAsync(satisDto);

            if (netice.UgurluDur)
            {
                _view.StatusMesajiGoster("Satış uğurla tamamlandı!", StatusMesajiNovu.Ugurlu);
                FormuTamSifirla();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GosterisleriYenile()
        {
            decimal umumiMebleg = _aktivSebet.Sum(e => e.VahidinQiymeti * e.Miqdar); // Total before any discount
            decimal totalItemDiscount = _aktivSebet.Sum(e => e.EndirimMeblegi); // Total discount from items
            decimal yekunMebleg = umumiMebleg - totalItemDiscount - _cartLevelEndirimMeblegi;
            _view.UmumiMebligiGoster(umumiMebleg, totalItemDiscount + _cartLevelEndirimMeblegi, yekunMebleg);
        }

        private void FormuTamSifirla()
        {
            _aktivSebet.Clear();
            _cartLevelEndirimMeblegi = 0;
            _view.FormuTamSifirla();
            GosterisleriYenile();
        }
    }
}