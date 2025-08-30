// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/MehsulPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Verilenler.Kontekst;
using AzAgroPOS.Verilenler.Realizasialar;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

public class MehsulPresenter
{
    private readonly IMehsulIdareetmeView _view;
    private readonly MehsulManager _mehsulManager;
    private IEnumerable<MehsulDto>? _butunMehsullarCache;

    public MehsulPresenter(IMehsulIdareetmeView view)
    {
        _view = view;
        var unitOfWork = new UnitOfWork(new AzAgroPOSDbContext());
        _mehsulManager = new MehsulManager(unitOfWork);

        _view.FormYuklendi_Istek += async (s, e) => await FormuYukle();
        _view.MehsulElaveEt_Istek += async (s, e) => await MehsulElaveEt();
        _view.MehsulYenile_Istek += async (s, e) => await MehsulYenile();
        _view.MehsulSil_Istek += async (s, e) => await MehsulSil();
        _view.FormuTemizle_Istek += (s, e) => FormuTemizle();
        _view.CedvelSecimiDeyisdi_Istek += (s, e) => CedvelSeciminiDoldur();
        _view.Axtaris_Istek += (s, e) => AxtarisEt();
        _view.StokKoduGeneralasiyaIstek += async (s, e) => await StokKoduGeneralasiyaEt();
        _view.BarkodGeneralasiyaIstek += async (s, e) => await BarkodGeneralasiyaEt();
    }

    private async Task FormuYukle()
    {
        _view.OlcuVahidleriniGoster(Enum.GetValues(typeof(OlcuVahidi)));
        var netice = await _mehsulManager.ButunMehsullariGetirAsync();
        if (netice.UgurluDur && netice.Data != null)
        {
            _butunMehsullarCache = netice.Data;
            _view.MehsullariGoster(_butunMehsullarCache);
        }
    }

    private void AxtarisEt()
    {
        if (_butunMehsullarCache == null) return;
        var axtarisMetni = _view.AxtarisMetni.ToLower();
        var filterlenmis = string.IsNullOrWhiteSpace(axtarisMetni)
            ? _butunMehsullarCache
            : _butunMehsullarCache.Where(m =>
                m.Ad.ToLower().Contains(axtarisMetni) ||
                m.StokKodu.ToLower().Contains(axtarisMetni) ||
                m.Barkod.ToLower().Contains(axtarisMetni));
        _view.MehsullariGoster(filterlenmis);
    }

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
                _view.PerakendeSatisQiymeti = secilmisMehsul.PerakendeSatisQiymeti.ToString("F2");
                _view.TopdanSatisQiymeti = secilmisMehsul.TopdanSatisQiymeti.ToString("F2");
                _view.TekEdedSatisQiymeti = secilmisMehsul.TekEdedSatisQiymeti.ToString("F2");
                _view.AlisQiymeti = secilmisMehsul.AlisQiymeti.ToString("F2");
                _view.MovcudSay = secilmisMehsul.MovcudSay.ToString();
            }
        }
    }

    private decimal ParseDecimal(string value) => decimal.TryParse(value, out var result) ? result : 0;
    private int ParseInt(string value) => int.TryParse(value, out var result) ? result : 0;

    private async Task MehsulElaveEt()
    {
        var yeniMehsul = new MehsulDto
        {
            Ad = _view.MehsulAdi,
            StokKodu = _view.StokKodu,
            Barkod = _view.Barkod,
            PerakendeSatisQiymeti = ParseDecimal(_view.PerakendeSatisQiymeti),
            TopdanSatisQiymeti = ParseDecimal(_view.TopdanSatisQiymeti),
            TekEdedSatisQiymeti = ParseDecimal(_view.TekEdedSatisQiymeti),
            AlisQiymeti = ParseDecimal(_view.AlisQiymeti),
            MovcudSay = ParseInt(_view.MovcudSay),
            OlcuVahidi = _view.SecilmisOlcuVahidi
        };
        var netice = await _mehsulManager.MehsulYaratAsync(yeniMehsul);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Məhsul uğurla əlavə edildi.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await FormuYukle();
            FormuTemizle();
        }
        else _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private async Task MehsulYenile()
    {
        if (string.IsNullOrEmpty(_view.MehsulId))
        {
            _view.MesajGoster("Yeniləmək üçün cədvəldən məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var yenilenmisMehsul = new MehsulDto
        {
            Id = ParseInt(_view.MehsulId),
            Ad = _view.MehsulAdi,
            StokKodu = _view.StokKodu,
            Barkod = _view.Barkod,
            PerakendeSatisQiymeti = ParseDecimal(_view.PerakendeSatisQiymeti),
            TopdanSatisQiymeti = ParseDecimal(_view.TopdanSatisQiymeti),
            TekEdedSatisQiymeti = ParseDecimal(_view.TekEdedSatisQiymeti),
            AlisQiymeti = ParseDecimal(_view.AlisQiymeti),
            MovcudSay = ParseInt(_view.MovcudSay),
            OlcuVahidi = _view.SecilmisOlcuVahidi
        };
        var netice = await _mehsulManager.MehsulYenileAsync(yenilenmisMehsul);
        if (netice.UgurluDur)
        {
            _view.MesajGoster("Məhsul uğurla yeniləndi.", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await FormuYukle();
            FormuTemizle();
        }
        else _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private async Task MehsulSil()
    {
        if (string.IsNullOrEmpty(_view.MehsulId))
        {
            _view.MesajGoster("Silmək üçün cədvəldən məhsul seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var sual = _view.MesajGoster($"'{_view.MehsulAdi}' adlı məhsulu silməyə əminsinizmi?", "Silməni Təsdiqlə", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (sual == DialogResult.Yes)
        {
            var netice = await _mehsulManager.MehsulSilAsync(ParseInt(_view.MehsulId));
            if (netice.UgurluDur)
            {
                await FormuYukle();
                FormuTemizle();
            }
            else _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
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
    }

    private async Task StokKoduGeneralasiyaEt()
    {
        var netice = await _mehsulManager.StokKoduGeneralasiyaEtAsync(_view.MehsulAdi);
        if (netice.UgurluDur)
            _view.StokKodu = netice.Data;
        else
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    private async Task BarkodGeneralasiyaEt()
    {
        var netice = await _mehsulManager.BarkodGeneralasiyaEtAsync();
        if (netice.UgurluDur)
            _view.Barkod = netice.Data;
        else
            _view.MesajGoster(netice.Mesaj, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}