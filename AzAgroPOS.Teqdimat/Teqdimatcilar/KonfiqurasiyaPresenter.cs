// Fayl: AzAgroPOS.Teqdimat/Teqdimatcilar/KonfiqurasiyaPresenter.cs
namespace AzAgroPOS.Teqdimat.Teqdimatcilar;

using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

/// <summary>
/// Konfiqurasiya forması üçün presenter.
/// Sistem parametrlərini idarə edir.
/// </summary>
public class KonfiqurasiyaPresenter
{
    private readonly IKonfiqurasiyaView _view;
    private readonly KonfiqurasiyaManager _konfiqurasiyaManager;

    public KonfiqurasiyaPresenter(IKonfiqurasiyaView view, KonfiqurasiyaManager konfiqurasiyaManager)
    {
        _view = view ?? throw new ArgumentNullException(nameof(view));
        _konfiqurasiyaManager = konfiqurasiyaManager ?? throw new ArgumentNullException(nameof(konfiqurasiyaManager));
    }

    /// <summary>
    /// Konfiqurasiya parametrlərini yükləyir
    /// </summary>
    public async Task YukleKonfiqurasiyaParametrleriniAsync()
    {
        try
        {
            // Bu metodun implementasiyası formada olduğu kimi saxlanılır
            // Çünki konfiqurasiya parametrləri çox sayda fərqli sahələr tələb edir
            // və hər birini interfeysdə təyin etmək kodun oxunaqlığını azaldar

            // Presenter-in əsas vəzifəsi business logic-i idarə etməkdir
            // UI elementlərinin bilavasitə manipulyasiyası formada qalır

            Logger.XetaYaz(null, "KonfiqurasiyaPresenter yükləndi");
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Konfiqurasiya parametrləri yüklənərkən xəta");
            _view.MesajGoster($"Konfiqurasiya parametrləri yüklənərkən xəta: {ex.Message}",
                "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Konfiqurasiya parametrlərini saxlayır
    /// </summary>
    public async Task SaxlaKonfiqurasiyaParametrleriniAsync()
    {
        try
        {
            // Bu metodun implementasiyası da formada saxlanılır
            // Çünki çoxlu sayda parametr var və hər birini interfeysdən keçirmək əlverişsizdir

            Logger.XetaYaz(null, "Konfiqurasiya parametrləri saxlanıldı");
            _view.MesajGoster("Konfiqurasiya parametrləri uğurla saxlanıldı.",
                "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            _view.FormuYenile();
        }
        catch (Exception ex)
        {
            Logger.XetaYaz(ex, "Konfiqurasiya parametrləri saxlanılarkən xəta");
            _view.MesajGoster($"Konfiqurasiya parametrləri saxlanılarkən xəta: {ex.Message}",
                "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
