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
    private readonly MehsulManager _mehsulManager;

    public MinimumStokMehsullariPresenter(IMinimumStokMehsullariView view, MehsulManager mehsulManager)
    {
        _view = view;
        _mehsulManager = mehsulManager;

        // Hadisələrə abunə oluruq
        _view.FormYuklendi += async (s, e) => await FormuYukle();
        _view.Yenile_Istek += async (s, e) => await FormuYukle();
    }

    private async Task FormuYukle()
    {
        var netice = await _mehsulManager.MinimumStokMehsullariniGetirAsync();
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