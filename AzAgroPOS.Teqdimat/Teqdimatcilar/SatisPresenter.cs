using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Servisler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using System.ComponentModel;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    public class SatisPresenter : ISatisPresenter
    {
        private readonly ISatisView _view;
        private readonly SatisManager _satisManager;
        private readonly MehsulManager _mehsulManager;
        private readonly MusteriManager _musteriManager;
        private readonly CapServisi _capServisi;

        private BindingList<SatisSebetiElementiDto> _aktivSebet;
        private readonly List<GozleyenSatis> _gozleyenSebetler;
        //Store individual item discounts and calculate cart discount dynamically
        //For simplicity, we'll keep a simple cart-level discount for now, but prepare for item-level.
        private decimal _cartLevelEndirimMeblegi = 0;

        public SatisPresenter(ISatisView view, SatisManager satisManager, MehsulManager mehsulManager, MusteriManager musteriManager)
        {
            _view = view;
            _satisManager = satisManager;
            _mehsulManager = mehsulManager;
            _musteriManager = musteriManager;
            _capServisi = new CapServisi();
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
            await _view.EmeliyyatIcraEtAsync(async () =>
            {
                await MusterileriYukle();
                await MehsulAxtar();
                await SuretliSatisMehsullariniGetir();
            }, "Satış formu yüklənir...");
        }

        public async Task MusterileriYukle()
        {
            // Lazy loading: Yalnız ilk 50 müştərini yükləyirik
            // İstifadəçi ComboBox-da axtarış etdikdə daha çox məlumat yüklənəcək
            var musteriNetice = await _musteriManager.MusterileriAxtarisIleGetirAsync("", 50);
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
            System.Diagnostics.Debug.WriteLine($"[DEBUG] SebeteElaveEt çağırıldı. mehsul parametri: {mehsul?.Ad ?? "null"}");
            System.Windows.Forms.MessageBox.Show($"SebeteElaveEt çağırıldı!\nMəhsul: {mehsul?.Ad ?? "null"}", "DEBUG Presenter");

            var secilmisMehsul = mehsul ?? _view.SecilmisAxtarisMehsulu;
            if (secilmisMehsul == null)
            {
                System.Windows.Forms.MessageBox.Show("secilmisMehsul NULL-dur!", "DEBUG Presenter");
                return;
            }

            System.Windows.Forms.MessageBox.Show($"Seçilmiş məhsul: {secilmisMehsul.Ad}\nStok: {secilmisMehsul.MovcudSay}", "DEBUG Presenter");

            if (!decimal.TryParse(_view.SecilmisMehsulMiqdari, out decimal miqdar) || miqdar <= 0)
            {
                miqdar = 1;
            }

            // Stok yoxlaması
            var movcudElement = _aktivSebet.FirstOrDefault(e => e.MehsulId == secilmisMehsul.Id);
            decimal sebetdekiMiqdar = movcudElement?.Miqdar ?? 0;
            decimal istenilenToplamMiqdar = sebetdekiMiqdar + miqdar;

            if (istenilenToplamMiqdar > secilmisMehsul.MovcudSay)
            {
                System.Windows.Forms.MessageBox.Show($"Stok kifayət deyil!\nMövcud: {secilmisMehsul.MovcudSay}\nTələb: {istenilenToplamMiqdar}", "DEBUG Presenter");
                _view.StatusMesajiGoster(
                    $"Stokda kifayət qədər məhsul yoxdur! Mövcud: {secilmisMehsul.MovcudSay}, Tələb olunan: {istenilenToplamMiqdar}",
                    StatusMesajiNovu.Xeta);
                return;
            }

            // Minimum stok xəbərdarlığı
            if (secilmisMehsul.MovcudSay <= secilmisMehsul.MinimumStok)
            {
                _view.StatusMesajiGoster(
                    $"Diqqət: {secilmisMehsul.Ad} minimum stok səviyyəsinə çatıb! (Mövcud: {secilmisMehsul.MovcudSay})",
                    StatusMesajiNovu.Melumat);
            }

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

        // Maksimum endirim faizi (konfiqurasiya edilə bilər)
        private const decimal MAX_ENDIRIM_FAIZI = 50m; // Maksimum 50% endirim

        private void IndirimEt(EndirimParametrləriDto endirimParam)
        {
            if (!_aktivSebet.Any())
            {
                _view.StatusMesajiGoster("Səbət boşdur. Endirim tətbiq etmək mümkün deyil.", StatusMesajiNovu.Xeta);
                return;
            }

            decimal umumiMebleg = _aktivSebet.Sum(e => e.VahidinQiymeti * e.Miqdar);
            decimal appliedDiscount = 0;

            // Faiz limitini yoxla
            if (endirimParam.Type == EndirimType.Percentage && endirimParam.Value > MAX_ENDIRIM_FAIZI)
            {
                _view.StatusMesajiGoster($"Maksimum endirim faizi {MAX_ENDIRIM_FAIZI}%-dir.", StatusMesajiNovu.Xeta);
                return;
            }

            if (endirimParam.Scope == EndirimScope.Cart)
            {
                // Cart level endirim - mövcud item endirimlərinə əlavə olunur
                if (endirimParam.Type == EndirimType.Percentage)
                {
                    appliedDiscount = umumiMebleg * (endirimParam.Value / 100);
                }
                else if (endirimParam.Type == EndirimType.FixedAmount)
                {
                    appliedDiscount = Math.Min(endirimParam.Value, umumiMebleg);
                }

                // Mövcud item endirimləri saxlanılır, cart level endirim əlavə olunur
                _cartLevelEndirimMeblegi = appliedDiscount;
            }
            else if (endirimParam.Scope == EndirimScope.SelectedItem)
            {
                var secilmisSebetElementi = _view.SecilmisSebetElementi;
                if (secilmisSebetElementi == null)
                {
                    _view.StatusMesajiGoster("Zəhmət olmasa, endirim tətbiq etmək üçün bir məhsul seçin.", StatusMesajiNovu.Xeta);
                    return;
                }

                decimal itemTotalBeforeDiscount = secilmisSebetElementi.VahidinQiymeti * secilmisSebetElementi.Miqdar;

                if (endirimParam.Type == EndirimType.Percentage)
                {
                    appliedDiscount = itemTotalBeforeDiscount * (endirimParam.Value / 100);
                }
                else if (endirimParam.Type == EndirimType.FixedAmount)
                {
                    appliedDiscount = Math.Min(endirimParam.Value, itemTotalBeforeDiscount);
                }

                // Item level endirim - cart level endirimlə birləşir
                secilmisSebetElementi.EndirimMeblegi = appliedDiscount;
            }

            // Yekun məbləğin mənfi olmamasını təmin et
            decimal totalDiscount = _aktivSebet.Sum(e => e.EndirimMeblegi) + _cartLevelEndirimMeblegi;
            if (totalDiscount > umumiMebleg)
            {
                _view.StatusMesajiGoster("Endirim məbləği ümumi məbləği keçə bilməz.", StatusMesajiNovu.Xeta);
                // Endirimi geri al
                if (endirimParam.Scope == EndirimScope.Cart)
                    _cartLevelEndirimMeblegi = 0;
                return;
            }

            _aktivSebet.ResetBindings();
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

        // Müştəri borc limiti (konfiqurasiya edilə bilər)
        private const decimal MUSTERI_BORC_LIMITI = 10000m; // Maksimum 10000 AZN borc

        private async Task SatisiTesdiqle(OdenisMetodu odenisMetodu)
        {
            System.Diagnostics.Debug.WriteLine($"[SatisPresenter] Satış təsdiqi başladı. AktivNovbeId: {AktivSessiya.AktivNovbeId}");

            if (!AktivSessiya.AktivNovbeId.HasValue)
            {
                System.Diagnostics.Debug.WriteLine("[SatisPresenter] AktivNovbeId null-dur!");
                _view.MesajGoster("Aktiv növbə yoxdur. Satış etmək mümkün deyil.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            System.Diagnostics.Debug.WriteLine($"[SatisPresenter] Növbə mövcuddur: ID={AktivSessiya.AktivNovbeId.Value}");

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

            // Nisyə satış üçün müştəri borc limitini yoxla
            if (odenisMetodu == OdenisMetodu.Nisyə && musteriId.HasValue)
            {
                var musteriSiyahisi = await _musteriManager.ButunMusterileriGetirAsync();
                if (musteriSiyahisi.UgurluDur && musteriSiyahisi.Data != null)
                {
                    var musteri = musteriSiyahisi.Data.FirstOrDefault(m => m.Id == musteriId.Value);
                    if (musteri != null)
                    {
                        decimal yekunMebleg = _aktivSebet.Sum(e => e.VahidinQiymeti * e.Miqdar)
                                             - _aktivSebet.Sum(e => e.EndirimMeblegi) - _cartLevelEndirimMeblegi;
                        decimal yeniBorc = musteri.UmumiBorc + yekunMebleg;

                        if (yeniBorc > MUSTERI_BORC_LIMITI)
                        {
                            var cavab = _view.MesajGoster(
                                $"Müştərinin cari borcu: {musteri.UmumiBorc:N2} AZN\n" +
                                $"Bu satış ilə yeni borc: {yeniBorc:N2} AZN\n" +
                                $"Borc limiti: {MUSTERI_BORC_LIMITI:N2} AZN\n\n" +
                                "Limit aşılır. Davam etmək istəyirsiniz?",
                                "Borc Limiti Xəbərdarlığı",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (cavab == DialogResult.No)
                            {
                                return;
                            }
                        }
                    }
                }
            }

            await _view.EmeliyyatIcraEtAsync(async () =>
            {
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
                    // Qebz cap et
                    try
                    {
                        var qebz = new SatisQebzDto
                        {
                            SatisId = netice.Data!.Id,
                            Tarix = netice.Data.Tarix,
                            KassirAdi = AktivSessiya.AktivIstifadeci?.TamAd ?? "Kassir",
                            SatilanMehsullar = _aktivSebet.Select(e => new SatisSebetiElementiDto
                            {
                                MehsulId = e.MehsulId,
                                MehsulAdi = e.MehsulAdi,
                                Miqdar = e.Miqdar,
                                VahidinQiymeti = e.VahidinQiymeti,
                                EndirimMeblegi = e.EndirimMeblegi
                            }).ToList()
                        };

                        _capServisi.EndirimTeyinEt(_cartLevelEndirimMeblegi);
                        _capServisi.CekiCapEt(qebz);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"[SatisPresenter] Çek cap xətası: {ex.Message}");
                        // Cap xetasi satisi dayandirmamali
                    }

                    _view.StatusMesajiGoster("Satış uğurla tamamlandı!", StatusMesajiNovu.Ugurlu);
                    FormuTamSifirla();
                }
                else
                {
                    _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }, "Satış təsdiq edilir...");
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

        public async Task<bool> MehsulSilAsync(int mehsulId)
        {
            try
            {
                var netice = await _mehsulManager.MehsulSilAsync(mehsulId);
                return netice.UgurluDur;
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Müştəri borcuna görə uyğun rəng adını qaytarır
        /// </summary>
        /// <param name="borc">Müştəri borcu</param>
        /// <returns>Rəng adı ("Red", "Orange" və ya "Black")</returns>
        public string GetMusteriBorcRengi(decimal borc)
        {
            if (borc > 5000)
                return "Red";
            else if (borc > 1000)
                return "Orange";
            else
                return "Black";
        }
    }
}