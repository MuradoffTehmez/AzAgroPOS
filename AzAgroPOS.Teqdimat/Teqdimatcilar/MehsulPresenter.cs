// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/MehsulPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;

public class MehsulPresenter
{
    private readonly IMehsulIdareetmeView _view;
    private readonly MehsulManager _mehsulManager;
    private IEnumerable<MehsulDto>? _butunMehsullarCache;

    public MehsulPresenter(IMehsulIdareetmeView view)
    {
        _view = view;
        // İdealda, bu obyektlər Dependency Injection ilə ötürülməlidir.
        // Hələlik sadəlik üçün birbaşa yaradırıq.
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
    }

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

    private void CedvelSeciminiDoldur()
    {
        // View-dan gələn Id boş deyilsə, formadakı sahələri doldur.
        if (!string.IsNullOrEmpty(_view.MehsulId) && _butunMehsullarCache != null)
        {
            var secilmisMehsul = _butunMehsullarCache.FirstOrDefault(m => m.Id == int.Parse(_view.MehsulId));
            if (secilmisMehsul != null)
            {
                _view.MehsulAdi = secilmisMehsul.Ad;
                _view.StokKodu = secilmisMehsul.StokKodu;
                _view.Barkod = secilmisMehsul.Barkod;
                _view.SatisQiymeti = secilmisMehsul.SatisQiymeti.ToString("F2");
                _view.MovcudSay = secilmisMehsul.MovcudSay.ToString();
            }
        }
    }

    private async Task MehsulElaveEt()
    {
        var yeniMehsul = new MehsulDto
        {
            Ad = _view.MehsulAdi,
            StokKodu = _view.StokKodu,
            Barkod = _view.Barkod,
            SatisQiymeti = decimal.TryParse(_view.SatisQiymeti, out var qiymet) ? qiymet : 0,
            MovcudSay = int.TryParse(_view.MovcudSay, out var say) ? say : 0
        };

        var netice = await _mehsulManager.MehsulYaratAsync(yeniMehsul);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Məhsul uğurla əlavə edildi.", "Uğurlu Əməliyyat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await FormuYukle(); // Cədvəli yenilə
            FormuTemizle();
        }
        else
        {
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }

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

    private void FormuTemizle()
    {
        _view.MehsulId = string.Empty;
        _view.MehsulAdi = string.Empty;
        _view.StokKodu = string.Empty;
        _view.Barkod = string.Empty;
        _view.SatisQiymeti = string.Empty;
        _view.MovcudSay = string.Empty;
    }
}