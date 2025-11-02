// Fayl: AzAgroPOS.Teqdimat/BazaForm.DisposablePattern.cs
namespace AzAgroPOS.Teqdimat;

using System;
using System.Collections.Generic;
using System.Windows.Forms;

/// <summary>
/// BazaForm üçün IDisposable pattern təkmilləşdirmələri.
/// Bu partial class resource-heavy formalar üçün dispose pattern-i təmin edir.
/// </summary>
public partial class BazaForm
{
    /// <summary>
    /// Dispose ediləcək resource-ların siyahısı
    /// </summary>
    private readonly List<IDisposable> _disposables = new();

    /// <summary>
    /// Dispose ediləcək resource qeydiyyatdan keçirir
    /// </summary>
    /// <param name="disposable">Dispose ediləcək obyekt</param>
    protected void RegisterDisposable(IDisposable disposable)
    {
        if (disposable != null)
        {
            _disposables.Add(disposable);
        }
    }

    /// <summary>
    /// Bir neçə disposable-ı qeydiyyatdan keçirir
    /// </summary>
    protected void RegisterDisposables(params IDisposable[] disposables)
    {
        foreach (var disposable in disposables)
        {
            RegisterDisposable(disposable);
        }
    }

    /// <summary>
    /// Form dispose olunduqda bütün qeydiyyatdan keçmiş resource-ları təmizləyir
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            // Qeydiyyatdan keçmiş resource-ları dispose et
            foreach (var disposable in _disposables)
            {
                try
                {
                    disposable?.Dispose();
                }
                catch (Exception ex)
                {
                    // Log error but don't throw during disposal
                    System.Diagnostics.Debug.WriteLine($"Dispose xətası: {ex.Message}");
                }
            }

            _disposables.Clear();

            // Components dispose (Designer tərəfindən yaradılmış)
            components?.Dispose();
        }

        base.Dispose(disposing);
    }
}
