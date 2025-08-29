// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/MehsulPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

/// <summary>
/// bu presenter, məhsul idarəetmə əməliyyatlarını idarə etmək üçün istifadə olunur.
/// </summary>
public class MehsulPresenter
{
    /// <summary>
    /// istifadəçi interfeysini təmsil edən view obyektidir.
    /// </summary>
    private readonly IMehsulIdareetmeView _view;
    /// <summary>
    /// məhsul idarəetmə əməliyyatlarını həyata keçirmək üçün istifadə olunan MehsulManager obyektidir.
    /// </summary>
    private readonly MehsulManager _mehsulManager;
    /// <summary>
    /// bütün məhsulları saxlamaq üçün istifadə olunan cache.
    /// </summary>
    private IEnumerable<MehsulDto>? _butunMehsullarCache;

    /// <summary>
    /// bu presenter, məhsul idarəetmə əməliyyatlarını idarə etmək üçün istifadə olunur.
    /// məhsul əlavə etmək, yeniləmək, silmək və axtarış etmək kimi əməliyyatları həyata keçirir.
    /// </summary>
    /// <param name="view"></param>
    public MehsulPresenter(IMehsulIdareetmeView view)
    {
        _view = view;
        var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _mehsulManager = new MehsulManager(unitOfWork);

        // View-dan gələn hadisələrə abunə oluruq
        _view.FormYuklendi_Istek += async (s, e) => await FormuYukle();
        _view.MehsulElaveEt_Istek += async (s, e) => await MehsulElaveEt();
        _view.MehsulYenile_Istek += async (s, e) => await MehsulYenile();
        _view.MehsulSil_Istek += async (s, e) => await MehsulSil();
        _view.FormuTemizle_Istek += (s, e) => FormuTemizle();
        _view.CedvelSecimiDeyisdi_Istek += (s, e) => CedvelSeciminiDoldur();
        _view.Axtaris_Istek += (s, e) => AxtarisEt();
        _view.KodGeneralasiyaIstek += async (s, e) => await KodlariGeneralasiyaEt();
    }

    /// <summary>
    /// bu metod, form yükləndikdə bütün məhsulları yükləyir və göstərir.
    /// </summary>
    /// <returns> async asixron bir şəkildə bütün məhsulları yükləyir və göstərir.
    /// </returns>
    private async Task FormuYukle()
    {
        var netice = await _mehsulManager.ButunMehsullariGetirAsync();
        if (netice.UgurluDur && netice.Data != null)
        {
            _butunMehsullarCache = netice.Data;
            _view.MehsullariGoster(_butunMehsullarCache);
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// AxtarisEt metodu, istifadəçinin axtarış mətninə əsasən məhsulları süzür.
    /// axtarış mətnini kiçik hərflərə çevirir və məhsul adını, stok kodunu və barkodu yoxlayır.
    /// agər axtarış mətninə uyğun məhsul tapılarsa, onları göstərir.
    /// filterlenmiş məhsulları göstərmək üçün _view.MehsullariGoster metodunu çağırır.
    /// məhsulgostermek üçün _butunMehsullarCache dəyişənini istifadə edir.
    /// </summary>
    private void AxtarisEt()
    {
        if (_butunMehsullarCache == null) return;

        var axtarisMetni = _view.AxtarisMetni.ToLower();
        if (string.IsNullOrWhiteSpace(axtarisMetni))
        {
            _view.MehsullariGoster(_butunMehsullarCache);
            return;
        }

        var filterlenmis = _butunMehsullarCache.Where(m =>
            m.Ad.ToLower().Contains(axtarisMetni) ||
            m.StokKodu.ToLower().Contains(axtarisMetni) ||
            m.Barkod.ToLower().Contains(axtarisMetni)
        );
        _view.MehsullariGoster(filterlenmis);
    }

    /// <summary>
    /// cedvelSeciminiDoldur metodu, istifadəçi cədvəldəki bir məhsulu seçdiyində çağırılır.
    /// bu metod dəqiq məhsulun məlumatlarını form sahələrinə doldurur.
    /// </summary>
    private void CedvelSeciminiDoldur()
    {
        if (!string.IsNullOrEmpty(_view.MehsulId) && _butunMehsullarCache != null)
        {
            var secilmisMehsul = _butunMehsullarCache.FirstOrDefault(m => m.Id == int.Parse(_view.MehsulId));
            if (secilmisMehsul != null)
            {
                _view.MehsulAdi = secilmisMehsul.Ad;
                _view.StokKodu = secilmisMehsul.StokKodu;
                _view.Barkod = secilmisMehsul.Barkod;
                _view.SatisQiymeti = secilmisMehsul.SatisQiymeti.ToString("F2");
                _view.AlisQiymeti = secilmisMehsul.AlisQiymeti.ToString("F2");
                _view.MovcudSay = secilmisMehsul.MovcudSay.ToString();
            }
        }
    }

    /// <summary>
    /// Məhsul əlavə etmək üçün istifadə olunur.
    /// əgər məhsul uğurla əlavə edilərsə, cədvəli yeniləyir və formu təmizləyir. əgər məhsul əlavə edilə bilməzsə, istifadəçiyə xəta mesajı göstərir.
    /// </summary>
    /// <returns></returns>
    private async Task MehsulElaveEt()
    {
        var yeniMehsul = new MehsulDto
        {
            Ad = _view.MehsulAdi,
            StokKodu = _view.StokKodu,
            Barkod = _view.Barkod,
            SatisQiymeti = decimal.TryParse(_view.SatisQiymeti, out var qiymet) ? qiymet : 0,
            AlisQiymeti = decimal.TryParse(_view.AlisQiymeti, out var alisQiymeti) ? alisQiymeti : 0,
            MovcudSay = int.TryParse(_view.MovcudSay, out var say) ? say : 0
        };

        var netice = await _mehsulManager.MehsulYaratAsync(yeniMehsul);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Məhsul uğurla əlavə edildi.", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await FormuYukle();
            FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

    /// <summary>
    ///  məhsulu yeniləmək üçün istifadə olunur.
    ///  adətən, məhsulun ID-sini alır və istifadəçidən yeni məlumatları alır.
    ///  agər məhsul uğurla yenilənərsə, cədvəli yeniləyir və formu təmizləyir.
    ///  agər məhsul yenilənməzsə, istifadəçiyə xəta mesajı göstərir.
    ///  əgər məhsul ID-si boşdursa, istifadəçiyə xəbərdarlıq mesajı göstərir ki, əvvəlcə məhsul seçməlidir.
    ///  əgər məhsul ID-si boş deyilsə, məhsulun yeni məlumatlarını alır və yeniləmə əməliyyatını həyata keçirir.
    /// </summary>
    /// <returns>Async bir şəkildə məhsulu yeniləyir və cədvəli yeniləyir.
    /// </returns>
    private async Task MehsulYenile()
    {
        if (string.IsNullOrEmpty(_view.MehsulId))
        {
            _view.MesajGoster("Zəhmət olmasa, yeniləmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var yenilenmisMehsul = new MehsulDto
        {
            Id = int.Parse(_view.MehsulId),
            Ad = _view.MehsulAdi,
            StokKodu = _view.StokKodu,
            Barkod = _view.Barkod,
            SatisQiymeti = decimal.TryParse(_view.SatisQiymeti, out var qiymet) ? qiymet : 0,
            AlisQiymeti = decimal.TryParse(_view.AlisQiymeti, out var alisQiymeti) ? alisQiymeti : 0,
            MovcudSay = int.TryParse(_view.MovcudSay, out var say) ? say : 0
        };

        var netice = await _mehsulManager.MehsulYenileAsync(yenilenmisMehsul);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Məhsul uğurla yeniləndi.", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await FormuYukle();
            FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// məhsulu silmək üçün istifadə olunur.
    /// adətən, məhsulun ID-sini alır və istifadəçidən təsdiq soruşur.
    /// əgər istifadəçi təsdiq edərsə, məhsulu silir və cədvəli yeniləyir.
    /// 
    /// </summary>
    /// <returns> Async bir şəkildə məhsulu silir və cədvəli yeniləyir.
    /// </returns>
    private async Task MehsulSil()
    {
        if (string.IsNullOrEmpty(_view.MehsulId))
        {
            _view.MesajGoster("Zəhmət olmasa, silmək üçün bir məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var sual = _view.MesajGoster($"'{_view.MehsulAdi}' adlı məhsulu silməyə əminsinizmi?", "Silməni Təsdiqlə", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

        if (sual == DialogResult.Yes)
        {
            var netice = await _mehsulManager.MehsulSilAsync(int.Parse(_view.MehsulId));
            if (netice.UgurluDur)
            {
                _view.MesajGoster("Məhsul uğurla silindi.", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await FormuYukle();
                FormuTemizle();
            }
            else
            {
                _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    /// <summary>
    /// formu təmizləyir, yəni bütün sahələri boşaldır.
    /// </summary>
    private void FormuTemizle()
    {
        _view.MehsulId = string.Empty;
        _view.MehsulAdi = string.Empty;
        _view.StokKodu = string.Empty;
        _view.Barkod = string.Empty;
        _view.SatisQiymeti = string.Empty;
        _view.AlisQiymeti = string.Empty;
        _view.MovcudSay = string.Empty;
    }
    /// <summary>
    /// KodlarıGenerasiyaEt metodu, məhsul üçün unikal stok kodu və barkod generasiya edir.
    /// </summary>
    /// <returns></returns>
    private async Task KodlariGeneralasiyaEt()
    {
        var netice = await _mehsulManager.KodlariGeneralasiyaEtAsync();
        if (netice.UgurluDur)
        {
            _view.StokKodu = netice.Data.StokKodu;
            _view.Barkod = netice.Data.Barkod;
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}