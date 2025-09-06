// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/MinimumStokMehsullariPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

/// <summary>
/// Minimum stok məhsulları idarəetmə forması üçün presenter.
/// </summary>
public class MinimumStokMehsullariPresenter
{
    private readonly IMinimumStokMehsullariView _view;
    private readonly MehsulMeneceri _mehsulMeneceri;

    public MinimumStokMehsullariPresenter(IMinimumStokMehsullariView view, MehsulMeneceri mehsulMeneceri)
    {
        _view = view;
        _mehsulMeneceri = mehsulMeneceri;

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.Yenile_Istek += async (s, e) => await FormuYukle();
    }

    private async Task FormuYukle()
    {
        var netice = await _mehsulMeneceri.MinimumStokMehsullariniGetirAsync();
        if (netice.UgurluDur)
        {
            _view.MinimumStokMehsullariniGoster(netice.Data.OrderBy(m => m.Ad).ToList());
        }
        else
        {
            _view.MinimumStokMehsullariniGoster(new List<MehsulDto>());
            _view.MesajGoster(netice.Mesaj, true);
        }
    }
}