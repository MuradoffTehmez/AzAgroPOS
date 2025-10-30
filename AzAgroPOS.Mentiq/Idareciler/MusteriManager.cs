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
    }
}