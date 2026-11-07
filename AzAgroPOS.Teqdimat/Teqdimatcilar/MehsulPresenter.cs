// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/MehsulPresenter.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat.Teqdimatcilar
{
    public class MehsulPresenter
    {
        private IMehsulIdareetmeView _view = null!;
        private readonly MehsulManager _mehsulManager;
        private readonly KateqoriyaMeneceri _kateqoriyaMeneceri;
        private readonly BrendMeneceri _brendMeneceri;
        private readonly TedarukcuMeneceri _tedarukcuMeneceri;
        private IEnumerable<MehsulDto>? _butunMehsullarCache;
        private bool _isViewAttached;
        private readonly SehifeParametrleri _sehifeParametrleri = new() { SehifeOlcusu = 50 };
        private bool _paginationEnabled = true;

        public MehsulPresenter(MehsulManager mehsulManager,
            KateqoriyaMeneceri kateqoriyaMeneceri, BrendMeneceri brendMeneceri, TedarukcuMeneceri tedarukcuMeneceri)
        {
            _mehsulManager = mehsulManager;
            _kateqoriyaMeneceri = kateqoriyaMeneceri;
            _brendMeneceri = brendMeneceri;
            _tedarukcuMeneceri = tedarukcuMeneceri;
        }

        public void AttachView(IMehsulIdareetmeView view)
        {
            if (view == null)
            {
                throw new ArgumentNullException(nameof(view));
            }

            if (_isViewAttached)
            {
                if (!ReferenceEquals(_view, view))
                {
                    throw new InvalidOperationException("Bu presenter artıq başqa bir görünüşə qoşulub.");
                }

                return;
            }

            _view = view;
            SubscribeToViewEvents();
            _isViewAttached = true;
        }

        private void SubscribeToViewEvents()
        {
            _view.FormYuklendi_Istek += async (s, e) => await FormuYukle();
            _view.MehsulElaveEt_Istek += async (s, e) => await MehsulElaveEt();
            _view.MehsulYenile_Istek += async (s, e) => await MehsulYenile();
            _view.MehsulSil_Istek += async (s, e) => await MehsulSil();
            _view.FormuTemizle_Istek += (s, e) => FormuTemizle();
            _view.CedvelSecimiDeyisdi_Istek += (s, e) => CedvelSeciminiDoldur();
            _view.Axtaris_Istek += async (s, e) => await AxtarisEt();
            _view.StokKoduGeneralasiyaIstek += async (s, e) => await StokKoduGeneralasiyaEt();
            _view.BarkodGeneralasiyaIstek += async (s, e) => await BarkodGeneralasiyaEt();
            _view.Kopyala_Istek += (s, e) => Kopyala();
            _view.NovbetiSehifeIstek += async (s, e) => await NovbetiSehife();
            _view.EvvelkiSehifeIstek += async (s, e) => await EvvelkiSehife();
        }

        private async Task FormuYukle()
        {
            await _view.EmeliyyatIcraEtAsync(async () =>
            {
                _view.OlcuVahidleriniGoster(Enum.GetValues(typeof(OlcuVahidi)));

                // Kateqoriyaları yükləyirik
                EmeliyyatNeticesi<List<KateqoriyaDto>> kateqoriyaNetice = await _kateqoriyaMeneceri.ButunKateqoriyalariGetirAsync();
                if (kateqoriyaNetice.UgurluDur)
                {
                    _view.KateqoriyalariGoster(kateqoriyaNetice.Data);
                }

                // Brendləri yükləyirik
                EmeliyyatNeticesi<List<BrendDto>> brendNetice = await _brendMeneceri.ButunBrendleriGetirAsync();
                if (brendNetice.UgurluDur)
                {
                    _view.BrendleriGoster(brendNetice.Data);
                }

                // Tedarukçuları yükləyirik
                EmeliyyatNeticesi<List<TedarukcuDto>> tedarukcuNetice = await _tedarukcuMeneceri.ButunTedarukculeriGetirAsync();
                if (tedarukcuNetice.UgurluDur)
                {
                    _view.TedarukculeriGoster(tedarukcuNetice.Data);
                }

                // Səhifə 1-dən başlayırıq
                _sehifeParametrleri.SehifeNomresi = 1;
                await MehsullariYukle();
                _view.FormuTemizle();
            }, "Məhsullar yüklənir...");
        }

        private async Task MehsulElaveEt()
        {
            if (string.IsNullOrWhiteSpace(_view.MehsulAdi))
            {
                _view.MesajGoster("Məhsul adı boş ola bilməz.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!MelumatlariYoxla(true)) return;

            await _view.EmeliyyatIcraEtAsync(async () =>
            {
                MehsulDto yeniMehsul = ViewDanMehsulYarat();
                EmeliyyatNeticesi<int> netice = await _mehsulManager.MehsulYaratAsync(yeniMehsul);

                if (netice.UgurluDur)
                {
                    _sehifeParametrleri.SehifeNomresi = 1;
                    await MehsullariYukle();
                    _view.FormuTemizle();
                    _view.MesajGoster("Məhsul uğurla əlavə edildi.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }, "Məhsul əlavə edilir...");
        }

        private async Task MehsulYenile()
        {
            if (string.IsNullOrEmpty(_view.MehsulId) || _view.MehsulId == "0")
            {
                _view.MesajGoster("Yeniləmək üçün cədvəldən məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!MelumatlariYoxla(false)) return;

            await _view.EmeliyyatIcraEtAsync(async () =>
            {
                MehsulDto movcudMehsul = ViewDanMehsulYarat();
                EmeliyyatNeticesi netice = await _mehsulManager.MehsulYenileAsync(movcudMehsul);

                if (netice.UgurluDur)
                {
                    await MehsullariYukle();
                    _view.FormuTemizle();
                    _view.MesajGoster("Məhsul məlumatları uğurla yeniləndi.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }, "Məhsul yenilənir...");
        }

        private async Task MehsulSil()
        {
            if (string.IsNullOrEmpty(_view.MehsulId) || _view.MehsulId == "0")
            {
                _view.MesajGoster("Silmək üçün cədvəldən məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult cavab = _view.MesajGoster("Seçilmiş məhsulu silmək istədiyinizə əminsiniz?", "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cavab == DialogResult.Yes)
            {
                EmeliyyatNeticesi netice = await _mehsulManager.MehsulSilAsync(ParseInt(_view.MehsulId));
                if (netice.UgurluDur)
                {
                    await MehsullariYukle();
                    _view.FormuTemizle();
                }
                else
                {
                    _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Kopyala()
        {
            if (string.IsNullOrEmpty(_view.MehsulId))
            {
                _view.MesajGoster("Kopyalamaq üçün cədvəldən məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            _view.MehsulId = string.Empty;
            _view.StokKodu = string.Empty;
            _view.Barkod = string.Empty;
            _view.MovcudSay = "0";
            _view.MesajGoster("Məhsul kopyalandı. Zəhmət olmasa, yeni Stok Kodu və Barkod daxil edib yadda saxlayın.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void FormuTemizle()
        {
            _view.MehsulId = string.Empty;
            _view.MehsulAdi = string.Empty;
            _view.StokKodu = string.Empty;
            _view.Barkod = string.Empty;
            _view.PerakendeSatisQiymeti = string.Empty;
            _view.TopdanSatisQiymeti = string.Empty;
            _view.TekEdedSatisQiymeti = string.Empty;
            _view.AlisQiymeti = string.Empty;
            _view.MovcudSay = string.Empty;
            _view.MinimumStok = string.Empty;
        }

        private async Task StokKoduGeneralasiyaEt()
        {
            EmeliyyatNeticesi<string> netice = await _mehsulManager.StokKoduGeneralasiyaEtAsync(_view.MehsulAdi);
            if (netice.UgurluDur)
            {
                _view.StokKodu = netice.Data;
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async Task BarkodGeneralasiyaEt()
        {
            EmeliyyatNeticesi<string> netice = await _mehsulManager.BarkodGeneralasiyaEtAsync();
            if (netice.UgurluDur)
            {
                _view.Barkod = netice.Data;
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task AxtarisEt()
        {
            // Axtarış zamanı səhifə 1-ə qayıt
            _sehifeParametrleri.SehifeNomresi = 1;
            await MehsullariYukle();
        }

        private async Task MehsullariYukle()
        {
            if (_paginationEnabled)
            {
                // Səhifələnmiş yükləmə
                string? axtarisMetni = string.IsNullOrWhiteSpace(_view.AxtarisMetni) ? null : _view.AxtarisMetni;
                EmeliyyatNeticesi<SehifelenmisMelumat<MehsulDto>> netice = await _mehsulManager.MehsullariSehifelenmisGetirAsync(_sehifeParametrleri, axtarisMetni);

                if (netice.UgurluDur && netice.Data != null)
                {
                    SehifelenmisMelumat<MehsulDto> sehifelenmis = netice.Data;

                    _butunMehsullarCache = sehifelenmis.Melumatlar.ToList();
                    _view.MehsullariGoster(_butunMehsullarCache);
                    _view.SehifeMelumatlariGoster(
                        sehifelenmis.CariSehife,
                        sehifelenmis.UmumiSehifeSayi,
                        sehifelenmis.UmumiQeydSayi,
                        sehifelenmis.EvvelkiSehifeVar,
                        sehifelenmis.NovbetiSehifeVar
                    );
                }
            }
            else
            {
                // Köhnə yanaşma - hamısını yüklə və cache-lə
                EmeliyyatNeticesi<IEnumerable<MehsulDto>> netice = await _mehsulManager.ButunMehsullariGetirAsync();
                if (netice.UgurluDur)
                {
                    _butunMehsullarCache = netice.Data;
                    string axtarisMetni = _view.AxtarisMetni.ToLower();
                    IEnumerable<MehsulDto>? filterlenmis = string.IsNullOrWhiteSpace(axtarisMetni)
                        ? _butunMehsullarCache
                        : _butunMehsullarCache.Where(m =>
                            m.Ad.ToLower().Contains(axtarisMetni) ||
                            m.StokKodu.ToLower().Contains(axtarisMetni) ||
                            m.Barkod.ToLower().Contains(axtarisMetni));
                    _view.MehsullariGoster(filterlenmis);
                }
            }
        }

        private async Task NovbetiSehife()
        {
            await _view.EmeliyyatIcraEtAsync(async () =>
            {
                _sehifeParametrleri.SehifeNomresi++;
                await MehsullariYukle();
            }, "Səhifə yüklənir...");
        }

        private async Task EvvelkiSehife()
        {
            await _view.EmeliyyatIcraEtAsync(async () =>
            {
                if (_sehifeParametrleri.SehifeNomresi > 1)
                {
                    _sehifeParametrleri.SehifeNomresi--;
                    await MehsullariYukle();
                }
            }, "Səhifə yüklənir...");
        }

        private void CedvelSeciminiDoldur()
        {
            if (!string.IsNullOrEmpty(_view.MehsulId) && _butunMehsullarCache != null)
            {
                MehsulDto? secilmisMehsul = _butunMehsullarCache.FirstOrDefault(m => m.Id == int.Parse(_view.MehsulId));
                if (secilmisMehsul != null)
                {
                    _view.MehsulAdi = secilmisMehsul.Ad;
                    _view.StokKodu = secilmisMehsul.StokKodu;
                    _view.Barkod = secilmisMehsul.Barkod;
                    _view.PerakendeSatisQiymeti = secilmisMehsul.PerakendeSatisQiymeti.ToString("F2");
                    _view.TopdanSatisQiymeti = secilmisMehsul.TopdanSatisQiymeti.ToString("F2");
                    _view.TekEdedSatisQiymeti = secilmisMehsul.TekEdedSatisQiymeti.ToString("F2");
                    _view.AlisQiymeti = secilmisMehsul.AlisQiymeti.ToString("F2");
                    _view.MovcudSay = secilmisMehsul.MovcudSay.ToString();
                    _view.MinimumStok = secilmisMehsul.MinimumStok.ToString();
                }
            }
        }

        private decimal ParseDecimal(string value)
        {
            return decimal.TryParse(value, out decimal result) ? result : 0;
        }

        private int ParseInt(string value)
        {
            return int.TryParse(value, out int result) ? result : 0;
        }

        private bool MelumatlariYoxla(bool yeniMehsuldur)
        {
            if (string.IsNullOrWhiteSpace(_view.StokKodu))
            {
                _view.MesajGoster("Stok kodu daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            foreach (string qiymet in new[] { _view.AlisQiymeti, _view.PerakendeSatisQiymeti,
                         _view.TopdanSatisQiymeti, _view.TekEdedSatisQiymeti })
            {
                if (!decimal.TryParse(qiymet, out decimal mebleg) || mebleg < 0 || decimal.Round(mebleg, 2) != mebleg)
                {
                    _view.MesajGoster("Qiymətləri mənfi olmayan, ən çox iki onluq rəqəmlə daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            if (!decimal.TryParse(_view.MinimumStok, out decimal minimum) || minimum < 0 || minimum != decimal.Round(minimum, 3) ||
                (yeniMehsuldur && (!decimal.TryParse(_view.MovcudSay, out decimal say) || say < 0 || say != decimal.Round(say, 3))))
            {
                _view.MesajGoster("Stok miqdarını mənfi olmayan, ən çox üç onluq rəqəmlə daxil edin.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if ((_view.SecilmisOlcuVahidi == OlcuVahidi.Ədəd || _view.SecilmisOlcuVahidi == OlcuVahidi.Paket) &&
                (minimum != decimal.Truncate(minimum) || (yeniMehsuldur && ParseDecimal(_view.MovcudSay) != decimal.Truncate(ParseDecimal(_view.MovcudSay)))))
            {
                _view.MesajGoster("Ədəd və paket üçün miqdar tam ədəd olmalıdır.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private MehsulDto ViewDanMehsulYarat()
        {
            return new MehsulDto
            {
                Id = string.IsNullOrEmpty(_view.MehsulId) ? 0 : ParseInt(_view.MehsulId),
                Ad = _view.MehsulAdi,
                StokKodu = _view.StokKodu,
                Barkod = _view.Barkod,
                PerakendeSatisQiymeti = ParseDecimal(_view.PerakendeSatisQiymeti),
                TopdanSatisQiymeti = ParseDecimal(_view.TopdanSatisQiymeti),
                TekEdedSatisQiymeti = ParseDecimal(_view.TekEdedSatisQiymeti),
                AlisQiymeti = ParseDecimal(_view.AlisQiymeti),
                MovcudSay = ParseDecimal(_view.MovcudSay),
                MinimumStok = ParseDecimal(_view.MinimumStok),
                OlcuVahidi = _view.SecilmisOlcuVahidi,
                KateqoriyaId = _view.SecilmisKateqoriyaId,
                BrendId = _view.SecilmisBrendId,
                TedarukcuId = _view.SecilmisTedarukcuId
            };
        }
    }
}
