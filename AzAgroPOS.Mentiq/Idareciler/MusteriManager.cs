using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Varliglar;
using AzAgroPOS.Verilenler.Interfeysler;

namespace AzAgroPOS.Mentiq.Idareciler
{
    public class MusteriManager
    {
        private readonly IUnitOfWork _unitOfWork;

        public MusteriManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<EmeliyyatNeticesi<List<MusteriDto>>> ButunMusterileriGetirAsync()
        {
            var musteriler = await _unitOfWork.Musteriler.ButununuGetirAsync();
            var dtolar = musteriler.Select(m => new MusteriDto
            {
                Id = m.Id,
                TamAd = m.TamAd,
                TelefonNomresi = m.TelefonNomresi,
                Unvan = m.Unvan,
                UmumiBorc = m.UmumiBorc,
                KreditLimiti = m.KreditLimiti
            }).OrderBy(m => m.TamAd).ToList();
            return EmeliyyatNeticesi<List<MusteriDto>>.Ugurlu(dtolar);
        }

        public async Task<EmeliyyatNeticesi> MusteriYaratAsync(MusteriDto dto)
        {
            var movcudMusteri = (await _unitOfWork.Musteriler.AxtarAsync(m => m.TelefonNomresi == dto.TelefonNomresi)).FirstOrDefault();
            if (movcudMusteri != null)
                return EmeliyyatNeticesi.Ugursuz("Bu telefon nömrəsi ilə müştəri artıq mövcuddur.");

            var musteri = new Musteri
            {
                TamAd = dto.TamAd,
                TelefonNomresi = dto.TelefonNomresi,
                Unvan = dto.Unvan,
                KreditLimiti = dto.KreditLimiti,
                UmumiBorc = 0
            };
            await _unitOfWork.Musteriler.ElaveEtAsync(musteri);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();
            return EmeliyyatNeticesi.Ugurlu();
        }

        public async Task<EmeliyyatNeticesi> MusteriYenileAsync(MusteriDto dto)
        {
            var musteri = await _unitOfWork.Musteriler.GetirAsync(dto.Id);
            if (musteri == null)
                return EmeliyyatNeticesi.Ugursuz("Müştəri tapılmadı.");

            musteri.TamAd = dto.TamAd;
            musteri.TelefonNomresi = dto.TelefonNomresi;
            musteri.Unvan = dto.Unvan;
            musteri.KreditLimiti = dto.KreditLimiti;

            _unitOfWork.Musteriler.Yenile(musteri);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();
            return EmeliyyatNeticesi.Ugurlu();
        }

        public async Task<EmeliyyatNeticesi> MusteriSilAsync(int id)
        {
            var musteri = await _unitOfWork.Musteriler.GetirAsync(id);
            if (musteri == null)
                return EmeliyyatNeticesi.Ugursuz("Müştəri tapılmadı.");

            if (musteri.UmumiBorc > 0)
                return EmeliyyatNeticesi.Ugursuz("Borcu olan müştərini silmək olmaz.");

            _unitOfWork.Musteriler.Sil(musteri);
            await _unitOfWork.EmeliyyatiTesdiqleAsync();
            return EmeliyyatNeticesi.Ugurlu();
        }

        /// <summary>
        /// Səhifələnmiş müştəri siyahısını əldə edir.
        /// Diqqət: Bu metod böyük müştəri bazaları üçün əlverişlidir.
        /// </summary>
        /// <param name="parametrler">Səhifələmə parametrləri</param>
        /// <returns>Səhifələnmiş müştəri məlumatları</returns>
        public async Task<EmeliyyatNeticesi<SehifelenmisMelumat<MusteriDto>>> MusterileriSehifelenmisGetirAsync(SehifeParametrleri parametrler)
        {
            try
            {
                var (musteriler, umumiSay) = await _unitOfWork.Musteriler.SehifelenmisGetirAsync(
                    parametrler.SehifeNomresi,
                    parametrler.SehifeOlcusu);

                var dtolar = musteriler.Select(m => new MusteriDto
                {
                    Id = m.Id,
                    TamAd = m.TamAd,
                    TelefonNomresi = m.TelefonNomresi,
                    Unvan = m.Unvan,
                    UmumiBorc = m.UmumiBorc,
                    KreditLimiti = m.KreditLimiti
                }).OrderBy(m => m.TamAd).ToList();

                var sehifelenmis = new SehifelenmisMelumat<MusteriDto>(
                    dtolar,
                    umumiSay,
                    parametrler.SehifeNomresi,
                    parametrler.SehifeOlcusu);

                return EmeliyyatNeticesi<SehifelenmisMelumat<MusteriDto>>.Ugurlu(sehifelenmis);
            }
            catch (Exception ex)
            {
                return EmeliyyatNeticesi<SehifelenmisMelumat<MusteriDto>>.Ugursuz($"Səhifələnmiş müştərilər əldə edilərkən xəta: {ex.Message}");
            }
        }

        #region Bonus İdarəetməsi

        /// <summary>
        /// Müştəriyə bal əlavə edir
        /// </summary>
        public async Task<EmeliyyatNeticesi> BalElaveEtAsync(int musteriId, decimal balMiqdari, string aciklama, int? satisId = null)
        {
            try
            {
                if (balMiqdari <= 0)
                    return EmeliyyatNeticesi.Ugursuz("Bal miqdarı 0-dan böyük olmalıdır.");

                var musteri = await _unitOfWork.Musteriler.GetirAsync(musteriId);
                if (musteri == null)
                    return EmeliyyatNeticesi.Ugursuz("Müştəri tapılmadı.");

                // Müştərinin bonus qeydini tap və ya yarat
                var musteriBonus = (await _unitOfWork.MusteriBonuslari.AxtarAsync(mb => mb.MusteriId == musteriId)).FirstOrDefault();
                if (musteriBonus == null)
                {
                    musteriBonus = new MusteriBonus
                    {
                        MusteriId = musteriId,
                        ToplamBal = 0,
                        IstifadeEdilmisBal = 0,
                        Seviyye = MusteriSeviyyesi.Esas
                    };
                    await _unitOfWork.MusteriBonuslari.ElaveEtAsync(musteriBonus);
                    await _unitOfWork.EmeliyyatiTesdiqleAsync(); // ID əldə etmək üçün
                }

                // Balı əlavə et
                musteriBonus.ToplamBal += balMiqdari;
                musteriBonus.SonBalQazanmaTarixi = DateTime.Now;

                // Səviyyəni yenilə
                YenileSeviyye(musteriBonus);

                _unitOfWork.MusteriBonuslari.Yenile(musteriBonus);

                // Bonus qeydini əlavə et
                var bonusQeydi = new BonusQeydi
                {
                    MusteriBonusId = musteriBonus.Id,
                    EmeliyyatNovu = BonusEmeliyyatNovu.Qazanma,
                    BalMiqdari = balMiqdari,
                    EmeliyyatTarixi = DateTime.Now,
                    Aciklama = aciklama,
                    SatisId = satisId
                };

                await _unitOfWork.BonusQeydleri.ElaveEtAsync(bonusQeydi);
                await _unitOfWork.EmeliyyatiTesdiqleAsync();

                return EmeliyyatNeticesi.Ugurlu();
            }
            catch (Exception ex)
            {
                return EmeliyyatNeticesi.Ugursuz($"Bal əlavə edilərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Müştəri balını istifadə edir
        /// </summary>
        public async Task<EmeliyyatNeticesi> BalIstifadeEtAsync(int musteriId, decimal balMiqdari, string aciklama, int? satisId = null)
        {
            try
            {
                if (balMiqdari <= 0)
                    return EmeliyyatNeticesi.Ugursuz("Bal miqdarı 0-dan böyük olmalıdır.");

                var musteriBonus = (await _unitOfWork.MusteriBonuslari.AxtarAsync(mb => mb.MusteriId == musteriId)).FirstOrDefault();
                if (musteriBonus == null)
                    return EmeliyyatNeticesi.Ugursuz("Müştərinin bonus qeydi tapılmadı.");

                if (musteriBonus.MovcudBal < balMiqdari)
                    return EmeliyyatNeticesi.Ugursuz($"Kifayət qədər bal yoxdur. Mövcud bal: {musteriBonus.MovcudBal}");

                // Balı istifadə et
                musteriBonus.IstifadeEdilmisBal += balMiqdari;
                musteriBonus.SonBalIstifadeTarixi = DateTime.Now;

                _unitOfWork.MusteriBonuslari.Yenile(musteriBonus);

                // Bonus qeydini əlavə et
                var bonusQeydi = new BonusQeydi
                {
                    MusteriBonusId = musteriBonus.Id,
                    EmeliyyatNovu = BonusEmeliyyatNovu.Istifade,
                    BalMiqdari = -balMiqdari, // Mənfi dəyər
                    EmeliyyatTarixi = DateTime.Now,
                    Aciklama = aciklama,
                    SatisId = satisId
                };

                await _unitOfWork.BonusQeydleri.ElaveEtAsync(bonusQeydi);
                await _unitOfWork.EmeliyyatiTesdiqleAsync();

                return EmeliyyatNeticesi.Ugurlu();
            }
            catch (Exception ex)
            {
                return EmeliyyatNeticesi.Ugursuz($"Bal istifadə edilərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Müştəri balını ləğv edir (admin)
        /// </summary>
        public async Task<EmeliyyatNeticesi> BalLegvEtAsync(int musteriId, decimal balMiqdari, string aciklama)
        {
            try
            {
                if (balMiqdari <= 0)
                    return EmeliyyatNeticesi.Ugursuz("Bal miqdarı 0-dan böyük olmalıdır.");

                var musteriBonus = (await _unitOfWork.MusteriBonuslari.AxtarAsync(mb => mb.MusteriId == musteriId)).FirstOrDefault();
                if (musteriBonus == null)
                    return EmeliyyatNeticesi.Ugursuz("Müştərinin bonus qeydi tapılmadı.");

                if (musteriBonus.MovcudBal < balMiqdari)
                    return EmeliyyatNeticesi.Ugursuz($"Kifayət qədər bal yoxdur. Mövcud bal: {musteriBonus.MovcudBal}");

                // Balı ləğv et (istifadə edilmiş kimi qeyd et)
                musteriBonus.IstifadeEdilmisBal += balMiqdari;

                // Səviyyəni yenilə
                YenileSeviyye(musteriBonus);

                _unitOfWork.MusteriBonuslari.Yenile(musteriBonus);

                // Bonus qeydini əlavə et
                var bonusQeydi = new BonusQeydi
                {
                    MusteriBonusId = musteriBonus.Id,
                    EmeliyyatNovu = BonusEmeliyyatNovu.Legv,
                    BalMiqdari = -balMiqdari,
                    EmeliyyatTarixi = DateTime.Now,
                    Aciklama = aciklama
                };

                await _unitOfWork.BonusQeydleri.ElaveEtAsync(bonusQeydi);
                await _unitOfWork.EmeliyyatiTesdiqleAsync();

                return EmeliyyatNeticesi.Ugurlu();
            }
            catch (Exception ex)
            {
                return EmeliyyatNeticesi.Ugursuz($"Bal ləğv edilərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Manual bal əlavə edir (admin)
        /// </summary>
        public async Task<EmeliyyatNeticesi> ManualBalElaveEtAsync(int musteriId, decimal balMiqdari, string aciklama)
        {
            try
            {
                if (balMiqdari == 0)
                    return EmeliyyatNeticesi.Ugursuz("Bal miqdarı 0 ola bilməz.");

                var musteri = await _unitOfWork.Musteriler.GetirAsync(musteriId);
                if (musteri == null)
                    return EmeliyyatNeticesi.Ugursuz("Müştəri tapılmadı.");

                var musteriBonus = (await _unitOfWork.MusteriBonuslari.AxtarAsync(mb => mb.MusteriId == musteriId)).FirstOrDefault();
                if (musteriBonus == null)
                {
                    musteriBonus = new MusteriBonus
                    {
                        MusteriId = musteriId,
                        ToplamBal = 0,
                        IstifadeEdilmisBal = 0,
                        Seviyye = MusteriSeviyyesi.Esas
                    };
                    await _unitOfWork.MusteriBonuslari.ElaveEtAsync(musteriBonus);
                    await _unitOfWork.EmeliyyatiTesdiqleAsync();
                }

                // Müsbət və ya mənfi bal əlavə et
                if (balMiqdari > 0)
                {
                    musteriBonus.ToplamBal += balMiqdari;
                    musteriBonus.SonBalQazanmaTarixi = DateTime.Now;
                }
                else
                {
                    musteriBonus.IstifadeEdilmisBal += Math.Abs(balMiqdari);
                }

                YenileSeviyye(musteriBonus);
                _unitOfWork.MusteriBonuslari.Yenile(musteriBonus);

                var bonusQeydi = new BonusQeydi
                {
                    MusteriBonusId = musteriBonus.Id,
                    EmeliyyatNovu = BonusEmeliyyatNovu.ManualElave,
                    BalMiqdari = balMiqdari,
                    EmeliyyatTarixi = DateTime.Now,
                    Aciklama = aciklama
                };

                await _unitOfWork.BonusQeydleri.ElaveEtAsync(bonusQeydi);
                await _unitOfWork.EmeliyyatiTesdiqleAsync();

                return EmeliyyatNeticesi.Ugurlu();
            }
            catch (Exception ex)
            {
                return EmeliyyatNeticesi.Ugursuz($"Manual bal əlavə edilərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Müştərinin bonus məlumatını gətirir
        /// </summary>
        public async Task<EmeliyyatNeticesi<MusteriBonus?>> MusteriBonusunuGetirAsync(int musteriId)
        {
            try
            {
                var musteriBonus = (await _unitOfWork.MusteriBonuslari.AxtarAsync(mb => mb.MusteriId == musteriId)).FirstOrDefault();
                return EmeliyyatNeticesi<MusteriBonus?>.Ugurlu(musteriBonus);
            }
            catch (Exception ex)
            {
                return EmeliyyatNeticesi<MusteriBonus?>.Ugursuz($"Bonus məlumatı əldə edilərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Müştərinin bonus tarixçəsini gətirir
        /// </summary>
        public async Task<EmeliyyatNeticesi<List<BonusQeydi>>> BonusQeydleriniGetirAsync(int musteriId)
        {
            try
            {
                var musteriBonus = (await _unitOfWork.MusteriBonuslari.AxtarAsync(mb => mb.MusteriId == musteriId)).FirstOrDefault();
                if (musteriBonus == null)
                    return EmeliyyatNeticesi<List<BonusQeydi>>.Ugurlu(new List<BonusQeydi>());

                var qeydler = (await _unitOfWork.BonusQeydleri.AxtarAsync(bq => bq.MusteriBonusId == musteriBonus.Id))
                    .OrderByDescending(bq => bq.EmeliyyatTarixi)
                    .ToList();

                return EmeliyyatNeticesi<List<BonusQeydi>>.Ugurlu(qeydler);
            }
            catch (Exception ex)
            {
                return EmeliyyatNeticesi<List<BonusQeydi>>.Ugursuz($"Bonus qeydləri əldə edilərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Bütün müştərilərin bonus məlumatlarını gətirir
        /// </summary>
        public async Task<EmeliyyatNeticesi<List<MusteriBonus>>> ButunBonuslariGetirAsync()
        {
            try
            {
                var bonuslar = (await _unitOfWork.MusteriBonuslari.ButununuGetirAsync())
                    .OrderByDescending(mb => mb.MovcudBal)
                    .ToList();

                return EmeliyyatNeticesi<List<MusteriBonus>>.Ugurlu(bonuslar);
            }
            catch (Exception ex)
            {
                return EmeliyyatNeticesi<List<MusteriBonus>>.Ugursuz($"Bonus məlumatları əldə edilərkən xəta: {ex.Message}");
            }
        }

        /// <summary>
        /// Müştəri səviyyəsini toplam bala görə yeniləyir
        /// </summary>
        private void YenileSeviyye(MusteriBonus musteriBonus)
        {
            var movcudBal = musteriBonus.MovcudBal;

            if (movcudBal >= 10000)
                musteriBonus.Seviyye = MusteriSeviyyesi.Platinum;
            else if (movcudBal >= 5000)
                musteriBonus.Seviyye = MusteriSeviyyesi.Qizil;
            else if (movcudBal >= 1000)
                musteriBonus.Seviyye = MusteriSeviyyesi.Gumus;
            else
                musteriBonus.Seviyye = MusteriSeviyyesi.Esas;
        }

        #endregion
    }
}