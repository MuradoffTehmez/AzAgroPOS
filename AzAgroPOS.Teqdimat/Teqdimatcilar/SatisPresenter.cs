using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Servisler;
using AzAgroPOS.Teqdimat.Sabitler;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;
using System.ComponentModel;
using System.Globalization;
using System.Text.Json;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    public class SatisPresenter : ISatisPresenter
    {
        private readonly ISatisView _view;
        private readonly SatisManager _satisManager;
        private readonly MehsulManager _mehsulManager;
        private readonly MusteriManager _musteriManager;
        private readonly KonfiqurasiyaManager _konfiqurasiyaManager;

        private BindingList<SatisSebetiElementiDto> _aktivSebet;
        private readonly List<GozleyenSatis> _gozleyenSebetler;
        //Store individual item discounts and calculate cart discount dynamically
        //For simplicity, we'll keep a simple cart-level discount for now, but prepare for item-level.
        private decimal _cartLevelEndirimMeblegi = 0;
        private int _satisDavamEdir;

        public SatisPresenter(ISatisView view, SatisManager satisManager, MehsulManager mehsulManager, MusteriManager musteriManager, KonfiqurasiyaManager konfiqurasiyaManager)
        {
            _view = view;
            _satisManager = satisManager;
            _mehsulManager = mehsulManager;
            _musteriManager = musteriManager;
            _konfiqurasiyaManager = konfiqurasiyaManager;
            _aktivSebet = new BindingList<SatisSebetiElementiDto>();
            _gozleyenSebetler = GozleyenSebetleriOxu();

            _view.SebeteMehsullariGoster(_aktivSebet);
            _view.GozleyenSatislarSayiniGuncelle(_gozleyenSebetler.Count);
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
            EmeliyyatNeticesi<List<MusteriDto>> musteriNetice = await _musteriManager.MusterileriAxtarisIleGetirAsync("", 50);
            if (musteriNetice.UgurluDur)
            {
                _view.MusteriSiyahisiniGoster(musteriNetice.Data);
            }
        }

        private async Task SuretliSatisMehsullariniGetir()
        {
            EmeliyyatNeticesi<List<MehsulDto>> netice = await _mehsulManager.AxtarAsync("", 30);
            if (netice.UgurluDur)
            {
                _view.SuretliSatisMehsullariniGoster(netice.Data);
            }
        }

        private async Task MehsulAxtar()
        {
            EmeliyyatNeticesi<List<MehsulDto>> netice = await _mehsulManager.AxtarAsync(_view.AxtarisMetni, 100);
            if (netice.UgurluDur)
            {
                _view.AxtarisNeticeleriniGoster(netice.Data);
            }
        }

        private void SebeteElaveEt(MehsulDto? mehsul = null)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Səbətə əlavə et: {mehsul?.Ad ?? "seçilmiş məhsul"}");

                // Məhsul seçimi yoxlaması
                MehsulDto? secilmisMehsul = mehsul ?? _view.SecilmisAxtarisMehsulu;
                if (secilmisMehsul == null)
                {
                    System.Diagnostics.Debug.WriteLine("Məhsul seçilməyib");
                    _view.StatusMesajiGoster("Zəhmət olmasa əvvəlcə məhsul seçin", StatusMesajiNovu.Melumat);
                    return;
                }

                // Məhsul məlumatlarının tamlığını yoxla
                if (string.IsNullOrWhiteSpace(secilmisMehsul.Ad))
                {
                    System.Diagnostics.Debug.WriteLine("Məhsul adı yoxdur");
                    _view.StatusMesajiGoster("Məhsul məlumatları natamamdır", StatusMesajiNovu.Xeta);
                    return;
                }

                // Miqdar yoxlaması və təyin edilməsi
                if (!decimal.TryParse(_view.SecilmisMehsulMiqdari, out decimal miqdar) || miqdar <= 0 ||
                    miqdar != decimal.Round(miqdar, 3))
                {
                    _view.StatusMesajiGoster("Miqdarı müsbət və ən çox üç onluq dəqiqlikdə daxil edin.", StatusMesajiNovu.Xeta);
                    return;
                }
                if ((secilmisMehsul.OlcuVahidi == OlcuVahidi.Ədəd || secilmisMehsul.OlcuVahidi == OlcuVahidi.Paket) &&
                    miqdar != decimal.Truncate(miqdar))
                {
                    _view.StatusMesajiGoster("Ədəd və paket məhsulu üçün tam ədəd miqdar daxil edin.", StatusMesajiNovu.Xeta);
                    return;
                }

                // Miqdar məntiq yoxlaması
                if (miqdar > 10000)
                {
                    _view.StatusMesajiGoster("Miqdar çox böyükdür. Zəhmət olmasa düzgün miqdar daxil edin", StatusMesajiNovu.Xeta);
                    return;
                }

                SatisSebetiElementiDto? movcudElement = _aktivSebet.FirstOrDefault(e => e.MehsulId == secilmisMehsul.Id);
                decimal istenilenToplamMiqdar = (movcudElement?.Miqdar ?? 0) + miqdar;
                // Səbətə əlavə et və ya mövcud miqdarı artır
                if (movcudElement != null)
                {
                    movcudElement.Miqdar += miqdar;
                    System.Diagnostics.Debug.WriteLine($"Mövcud məhsulun miqdarı artırıldı: {secilmisMehsul.Ad}, Yeni miqdar: {movcudElement.Miqdar}");
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
                    System.Diagnostics.Debug.WriteLine($"Yeni məhsul səbətə əlavə edildi: {secilmisMehsul.Ad}, Miqdar: {miqdar}");
                }

                // UI-ni yenilə
                _aktivSebet.ResetBindings();
                GosterisleriYenile();
                if (mehsul == null)
                {
                    _view.AxtarisPaneliniSifirla();
                }

                // Müştəri ekranını yenilə
                _view.MusteriEkraniYenile(secilmisMehsul.Ad, secilmisMehsul.PerakendeSatisQiymeti, miqdar);

                // Uğurlu əməliyyat mesajı
                _view.StatusMesajiGoster(
                    $"✓ {secilmisMehsul.Ad} səbətə əlavə edildi ({miqdar} ədəd)",
                    StatusMesajiNovu.Ugurlu);

                // Minimum stok xəbərdarlığı
                if (secilmisMehsul.MovcudSay - istenilenToplamMiqdar <= secilmisMehsul.MinimumStok)
                {
                    System.Diagnostics.Debug.WriteLine($"Minimum stok xəbərdarlığı: {secilmisMehsul.Ad}");
                    _view.StatusMesajiGoster(
                        $"⚠ Diqqət: {secilmisMehsul.Ad} minimum stok səviyyəsinə yaxınlaşır! (Qalıq: {secilmisMehsul.MovcudSay - istenilenToplamMiqdar})",
                        StatusMesajiNovu.Melumat);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Səbətə əlavə etmə xətası: {ex.Message}\n{ex.StackTrace}");
                _view.StatusMesajiGoster(
                    $"Məhsul səbətə əlavə edilərkən xəta baş verdi: {ex.Message}",
                    StatusMesajiNovu.Xeta);
            }
        }

        private void SebetMiqdarDeyisdir(int mehsulId, decimal deyisiklik)
        {
            try
            {
                SatisSebetiElementiDto? element = _aktivSebet.FirstOrDefault(e => e.MehsulId == mehsulId);
                if (element == null)
                {
                    _view.StatusMesajiGoster("Məhsul səbətdə tapılmadı", StatusMesajiNovu.Xeta);
                    return;
                }

                element.Miqdar += deyisiklik;

                if (element.Miqdar <= 0)
                {
                    _aktivSebet.Remove(element);
                    _view.StatusMesajiGoster($"{element.MehsulAdi} səbətdən silindi", StatusMesajiNovu.Melumat);
                }
                else
                {
                    _view.StatusMesajiGoster($"{element.MehsulAdi} miqdarı dəyişdirildi: {element.Miqdar}", StatusMesajiNovu.Melumat);
                }

                _aktivSebet.ResetBindings();
                GosterisleriYenile();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Səbət miqdar dəyişikliyi xətası: {ex.Message}");
                _view.StatusMesajiGoster($"Miqdar dəyişdirilərkən xəta: {ex.Message}", StatusMesajiNovu.Xeta);
            }
        }

        private void SebetdenSil()
        {
            try
            {
                SatisSebetiElementiDto? secilmisSebetElementi = _view.SecilmisSebetElementi;
                if (secilmisSebetElementi == null)
                {
                    _view.StatusMesajiGoster("Zəhmət olmasa silinəcək məhsulu seçin", StatusMesajiNovu.Melumat);
                    return;
                }

                string mehsulAdi = secilmisSebetElementi.MehsulAdi;
                _aktivSebet.Remove(secilmisSebetElementi);
                GosterisleriYenile();
                _view.StatusMesajiGoster($"{mehsulAdi} səbətdən silindi", StatusMesajiNovu.Ugurlu);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Səbətdən silmə xətası: {ex.Message}");
                _view.StatusMesajiGoster($"Məhsul silinərkən xəta: {ex.Message}", StatusMesajiNovu.Xeta);
            }
        }

        private void SebetiTemizle()
        {
            try
            {
                if (!_aktivSebet.Any())
                {
                    _view.StatusMesajiGoster("Səbət artıq boşdur", StatusMesajiNovu.Melumat);
                    return;
                }

                DialogResult cavab = _view.MesajGoster("Səbəti tamamilə təmizləmək istədiyinizə əminsinizmi?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (cavab == DialogResult.Yes)
                {
                    FormuTamSifirla();
                    _view.StatusMesajiGoster("Səbət təmizləndi", StatusMesajiNovu.Ugurlu);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Səbəti təmizləmə xətası: {ex.Message}");
                _view.StatusMesajiGoster($"Səbət təmizlənərkən xəta: {ex.Message}", StatusMesajiNovu.Xeta);
            }
        }

        // Maksimum endirim faizi (konfiqurasiya edilə bilər)
        private const decimal MAX_ENDIRIM_FAIZI = 50m; // Maksimum 50% endirim

        private void IndirimEt(EndirimParametrləriDto endirimParam)
        {
            if (!AzAgroPOS.Mentiq.Yardimcilar.IcazeYoxlayici.Instance
                .IcazeVarmi(AzAgroPOS.Mentiq.Yardimcilar.SistemIcazeleri.SatisaEndirimVer))
            {
                _view.StatusMesajiGoster("Endirim verməyə icazəniz yoxdur.", StatusMesajiNovu.Xeta);
                return;
            }
            if (!_aktivSebet.Any())
            {
                _view.StatusMesajiGoster("Səbət boşdur. Endirim tətbiq etmək mümkün deyil.", StatusMesajiNovu.Xeta);
                return;
            }

            decimal umumiMebleg = _aktivSebet.Sum(e => decimal.Round(e.VahidinQiymeti * e.Miqdar, 2, MidpointRounding.AwayFromZero));
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
                appliedDiscount = decimal.Round(appliedDiscount, 2, MidpointRounding.AwayFromZero);
                _cartLevelEndirimMeblegi = appliedDiscount;
            }
            else if (endirimParam.Scope == EndirimScope.SelectedItem)
            {
                SatisSebetiElementiDto? secilmisSebetElementi = _view.SecilmisSebetElementi;
                if (secilmisSebetElementi == null)
                {
                    _view.StatusMesajiGoster("Zəhmət olmasa, endirim tətbiq etmək üçün bir məhsul seçin.", StatusMesajiNovu.Xeta);
                    return;
                }

                decimal itemTotalBeforeDiscount = decimal.Round(secilmisSebetElementi.VahidinQiymeti * secilmisSebetElementi.Miqdar, 2, MidpointRounding.AwayFromZero);

                if (endirimParam.Type == EndirimType.Percentage)
                {
                    appliedDiscount = itemTotalBeforeDiscount * (endirimParam.Value / 100);
                }
                else if (endirimParam.Type == EndirimType.FixedAmount)
                {
                    appliedDiscount = Math.Min(endirimParam.Value, itemTotalBeforeDiscount);
                }

                // Item level endirim - cart level endirimlə birləşir
                appliedDiscount = decimal.Round(appliedDiscount, 2, MidpointRounding.AwayFromZero);
                secilmisSebetElementi.EndirimMeblegi = appliedDiscount;
            }

            // Yekun məbləğin mənfi olmamasını təmin et
            decimal totalDiscount = _aktivSebet.Sum(e => e.EndirimMeblegi) + _cartLevelEndirimMeblegi;
            if (totalDiscount > umumiMebleg)
            {
                _view.StatusMesajiGoster("Endirim məbləği ümumi məbləği keçə bilməz.", StatusMesajiNovu.Xeta);
                // Endirimi geri al
                if (endirimParam.Scope == EndirimScope.Cart)
                {
                    _cartLevelEndirimMeblegi = 0;
                }

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

            string ad = $"Satış {DateTime.Now:dd.MM HH:mm:ss}";
            GozleyenSatis gozleyen = new(ad, _aktivSebet.ToList())
            {
                MusteriId = _view.SecilmisMusteriId,
                SebetEndirimi = _cartLevelEndirimMeblegi
            };
            _gozleyenSebetler.Add(gozleyen);
            if (!GozleyenSebetleriYaz())
            {
                _gozleyenSebetler.Remove(gozleyen);
                _view.StatusMesajiGoster("Gözlədilən satış saxlanmadı; səbət açıq qaldı.", StatusMesajiNovu.Xeta);
                return;
            }
            _view.GozleyenSatislarSayiniGuncelle(_gozleyenSebetler.Count);
            FormuTamSifirla();
        }

        public async Task GozleyenSatisiSec(GozleyenSatis satis)
        {
            if (_aktivSebet.Any())
            {
                DialogResult cavab = _view.MesajGoster("Aktiv səbət mövcuddur. Dəyişikliklər itəcək. Davam etmək istəyirsiniz?", "Xəbərdarlıq", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cavab == DialogResult.No)
                {
                    return;
                }
            }
            MusteriDto? musteri = null;
            if (satis.MusteriId.HasValue)
            {
                EmeliyyatNeticesi<MusteriDto> netice = await _musteriManager.MusteriGetirAsync(satis.MusteriId.Value);
                if (!netice.UgurluDur || netice.Data == null)
                {
                    _view.StatusMesajiGoster("Gözlədilən satışın müştərisi tapılmadı.", StatusMesajiNovu.Xeta);
                    return;
                }
                musteri = netice.Data;
            }
            _gozleyenSebetler.Remove(satis);
            if (!GozleyenSebetleriYaz())
            {
                _gozleyenSebetler.Add(satis);
                _view.StatusMesajiGoster("Gözlədilən satışın saxlanması alınmadı.", StatusMesajiNovu.Xeta);
                return;
            }
            _aktivSebet = new BindingList<SatisSebetiElementiDto>(satis.Sebet);
            _cartLevelEndirimMeblegi = satis.SebetEndirimi;
            _view.GozleyenSatislarSayiniGuncelle(_gozleyenSebetler.Count);
            _view.SebeteMehsullariGoster(_aktivSebet);
            // Seçilmiş müştərini bərpa edərkən siyahıdakı digər müştəriləri itirmə.
            await MusterileriYukle();
            _view.MusteriSec(satis.MusteriId);
            GosterisleriYenile();
        }

        private static string GozleyenSebetYolu()
        {
            string qovluq = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "AzAgroPOS");
            Directory.CreateDirectory(qovluq);
            return Path.Combine(qovluq, $"GozleyenSatislar-{AktivSessiya.AktivIstifadeci?.Id ?? 0}.json");
        }

        private static List<GozleyenSatis> GozleyenSebetleriOxu()
        {
            try
            {
                string yol = GozleyenSebetYolu();
                return File.Exists(yol)
                    ? JsonSerializer.Deserialize<List<GozleyenSatis>>(File.ReadAllText(yol)) ?? new()
                    : new();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Gözlədilən satışlar oxunmadı: {ex}");
                return new();
            }
        }

        private bool GozleyenSebetleriYaz()
        {
            try
            {
                string yol = GozleyenSebetYolu();
                string muveqqetiYol = yol + ".tmp";
                File.WriteAllText(muveqqetiYol, JsonSerializer.Serialize(_gozleyenSebetler));
                File.Move(muveqqetiYol, yol, true);
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Gözlədilən satışlar saxlanmadı: {ex}");
                return false;
            }
        }

        private async Task SatisiTesdiqle(OdenisMetodu odenisMetodu)
        {
            if (Interlocked.Exchange(ref _satisDavamEdir, 1) != 0) return;
            try { await SatisiTesdiqleDaxili(odenisMetodu); }
            finally { Interlocked.Exchange(ref _satisDavamEdir, 0); }
        }

        private async Task SatisiTesdiqleDaxili(OdenisMetodu odenisMetodu)
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

            int? musteriId = _view.SecilmisMusteriId;
            if (odenisMetodu == OdenisMetodu.Nisyə && !musteriId.HasValue)
            {
                _view.StatusMesajiGoster("Nisyə satış üçün müştəri seçin.", StatusMesajiNovu.Xeta);
                return;
            }

            // Nisyə satış üçün müştəri borc limitini yoxla
            if (odenisMetodu == OdenisMetodu.Nisyə && musteriId.HasValue)
            {
                EmeliyyatNeticesi<MusteriDto> musteriNeticesi = await _musteriManager.MusteriGetirAsync(musteriId.Value);
                if (musteriNeticesi.UgurluDur && musteriNeticesi.Data != null)
                {
                    MusteriDto? musteri = musteriNeticesi.Data;
                    if (musteri != null)
                    {
                        decimal yekunMebleg = _aktivSebet.Sum(e => e.UmumiMebleg) - _cartLevelEndirimMeblegi;
                        decimal yeniBorc = musteri.UmumiBorc + yekunMebleg;

                        if (musteri.KreditLimiti > 0 && yeniBorc > musteri.KreditLimiti)
                        {
                            _view.MesajGoster(
                                $"Müştərinin cari borcu: {musteri.UmumiBorc:N2} AZN\n" +
                                $"Bu satış ilə yeni borc: {yeniBorc:N2} AZN\n" +
                                $"Borc limiti: {musteri.KreditLimiti:N2} AZN\n\n" +
                                "Müştərinin kredit limitini Müştəri idarəetmə bölməsində yeniləyin.",
                                "Borc limiti aşıldı",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                            return;
                        }
                    }
                }
            }

            Action? capIsi = null;
            SynchronizationContext? uiContext = SynchronizationContext.Current;
            await _view.EmeliyyatIcraEtAsync(async () =>
            {
                decimal umumiMebleg = _aktivSebet.Sum(e => decimal.Round(e.VahidinQiymeti * e.Miqdar, 2, MidpointRounding.AwayFromZero)); // Total before any discount
                decimal totalItemDiscount = _aktivSebet.Sum(e => e.EndirimMeblegi); // Total discount from items
                decimal totalDiscount = totalItemDiscount + _cartLevelEndirimMeblegi;
                decimal yekunMebleg = umumiMebleg - totalDiscount;

                SatisYaratDto satisDto = new()
                {
                    SebetElementleri = _aktivSebet.ToList(),
                    OdenisMetodu = odenisMetodu,
                    NovbeId = AktivSessiya.AktivNovbeId.Value,
                    MusteriId = musteriId,
                    UmumiMebleg = umumiMebleg,
                    Endirim = _cartLevelEndirimMeblegi,
                    YekunMebleg = yekunMebleg
                };

                EmeliyyatNeticesi<Satis> netice = await _satisManager.SatisYaratAsync(satisDto);

                if (netice.UgurluDur)
                {
                    // Qebz cap et
                    try
                    {
                        SatisQebzDto qebz = new()
                        {
                            SatisId = netice.Data!.Id,
                            Tarix = netice.Data.Tarix,
                            KassirAdi = AktivSessiya.AktivIstifadeci?.TamAd ?? "Kassir",
                            OdenisMetodu = odenisMetodu,
                            YekunMebleg = netice.Data.UmumiMebleg,
                            MusteriAdi = netice.Data.MusteriAdiQebz,
                            BuSatisBorcu = odenisMetodu == OdenisMetodu.Nisyə ? netice.Data.UmumiMebleg : null,
                            UmumiBorc = netice.Data.BorcSonra,
                            SatilanMehsullar = _aktivSebet.Select(e => new SatisSebetiElementiDto
                            {
                                MehsulId = e.MehsulId,
                                MehsulAdi = e.MehsulAdi,
                                Miqdar = e.Miqdar,
                                VahidinQiymeti = e.VahidinQiymeti,
                                EndirimMeblegi = e.EndirimMeblegi
                            }).ToList()
                        };

                        string sirketAdi = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.SirketAdi, KonfiqurasiyaSabitleri.VarsayilanDeyerler.SirketAdi);
                        string unvan = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.SirketUnvani);
                        string voen = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.SirketVoen);
                        string edv = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.VergiEdvDerecesi, KonfiqurasiyaSabitleri.VarsayilanDeyerler.VergiEdvDerecesi);
                        string avtoCap = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.DavranisQebzCap, KonfiqurasiyaSabitleri.VarsayilanDeyerler.DavranisQebzCap);
                        string printer = await _konfiqurasiyaManager.GetirAsync(KonfiqurasiyaSabitleri.Acarlar.PrinterQebz);
                        CapServisi capServisi = new();
                        capServisi.MagazaMelumatlariTeyinEt(sirketAdi, unvan, voen);
                        if (decimal.TryParse(edv, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal edvDerecesi))
                            capServisi.EdvDerecesiTeyinEt(edvDerecesi);
                        capServisi.EndirimTeyinEt(_cartLevelEndirimMeblegi);
                        if (!bool.TryParse(avtoCap, out bool capAktivdir) || capAktivdir)
                            capIsi = () => capServisi.CekiCapEt(qebz, printer, xetaMesajiGoster: false);
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

            // Printer sürücüsü uzun çəkə bilər; satışı artıq saxlamış UI axınını bloklamırıq.
            if (capIsi != null)
            {
                Action capEmeliyyati = capIsi;
                Thread capThread = new(() =>
                {
                    try { capEmeliyyati(); }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine($"Qəbz çapı: {ex}");
                        uiContext?.Post(_ => _view.StatusMesajiGoster(
                            $"Satış saxlandı, lakin qəbz çap olunmadı: {ex.Message}", StatusMesajiNovu.Xeta), null);
                    }
                }) { IsBackground = true, Name = "AzAgroPOS-QebzCap" };
                capThread.SetApartmentState(ApartmentState.STA);
                capThread.Start();
            }
        }

        private void GosterisleriYenile()
        {
            decimal umumiMebleg = _aktivSebet.Sum(e => decimal.Round(e.VahidinQiymeti * e.Miqdar, 2, MidpointRounding.AwayFromZero)); // Total before any discount
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
                EmeliyyatNeticesi netice = await _mehsulManager.MehsulSilAsync(mehsulId);
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
            return borc > 5000 ? "Red" : borc > 1000 ? "Orange" : "Black";
        }
    }
}
