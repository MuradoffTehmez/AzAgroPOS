// Fayl: AzAgroPOS.Teqdimat\Yardimcilar\YuklemeGostergeci.cs
namespace AzAgroPOS.Teqdimat.Yardimcilar;

using System;
using System.Windows.Forms;

/// <summary>
/// Yükləmə göstəricisi - uzun çəkən əməliyyatlar zamanı istifadəçiyə vizual göstərici təmin edir
/// diqqət: Bu sinif formdakı kontrollerlərə yükləmə göstəricisi əlavə edir
/// qeyd: Asinxron əməliyyatlar üçün əlverişlidir
/// </summary>
public class YuklemeGostergeci
{
    private readonly Form _form;
    private Panel _yuklemePaneli;
    private Label _yuklemeEtiketi;
    private ProgressBar _yuklemeCubugu;

    public YuklemeGostergeci(Form form)
    {
        _form = form;
        _yuklemePaneli = new Panel();
        _yuklemeEtiketi = new Label();
        _yuklemeCubugu = new ProgressBar();
    }

    /// <summary>
    /// Yükləmə göstəricisini başlatır
    /// </summary>
    /// <param name="mesaj">İstifadəçiyə göstəriləcək mesaj</param>
    public void Baslat(string mesaj = "Yüklənir...")
    {
        // Yükləmə panelini konfiqurasiya et
        _yuklemePaneli.BackColor = System.Drawing.Color.FromArgb(100, 0, 0, 0); // Yarı şəffaf arxa fon
        _yuklemePaneli.Dock = DockStyle.Fill;
        _yuklemePaneli.BringToFront();
        _yuklemePaneli.Name = "YuklemePaneli";

        // Etiketi konfiqurasiya et
        _yuklemeEtiketi.Text = mesaj;
        _yuklemeEtiketi.ForeColor = System.Drawing.Color.White;
        _yuklemeEtiketi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
        _yuklemeEtiketi.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        _yuklemeEtiketi.AutoSize = false;
        _yuklemeEtiketi.Dock = DockStyle.Top;
        _yuklemeEtiketi.Height = 40;

        // Cərgəyi konfiqurasiya et
        _yuklemeCubugu.Style = ProgressBarStyle.Marquee; // Davamlı hərəkətli cərgə
        _yuklemeCubugu.Dock = DockStyle.Top;
        _yuklemeCubugu.Height = 5;
        _yuklemeCubugu.Name = "YuklemeCubugu";

        // Elementləri əlavə et
        _yuklemePaneli.Controls.Add(_yuklemeEtiketi);
        _yuklemePaneli.Controls.Add(_yuklemeCubugu);

        // Formdakı digər kontrollerləri deaktiv et
        _form.Controls.Add(_yuklemePaneli);
        _yuklemePaneli.BringToFront();

        // Digər kontrollerləri müvəqqəti deaktiv et
        foreach (Control control in _form.Controls)
        {
            if (control != _yuklemePaneli)
            {
                control.Enabled = false;
            }
        }
    }

    /// <summary>
    /// Yükləmə göstəricisini dayandırır
    /// </summary>
    public void Dayandir()
    {
        // Formdakı digər kontrollerləri yenidən aktiv et
        foreach (Control control in _form.Controls)
        {
            if (control != _yuklemePaneli)
            {
                control.Enabled = true;
            }
        }

        // Yükləmə panelini sil
        if (_yuklemePaneli.Parent != null)
        {
            _yuklemePaneli.Parent.Controls.Remove(_yuklemePaneli);
        }

        _yuklemePaneli.Dispose();
        _yuklemeEtiketi.Dispose();
        _yuklemeCubugu.Dispose();
    }

    /// <summary>
    /// Asinxron əməliyyatı icra edən və yükləmə göstəricisini idarə edən metod
    /// </summary>
    /// <typeparam name="T">Əməliyyatın nəticə tipi</typeparam>
    /// <param name="emeliyyat">İcra ediləcək əməliyyat</param>
    /// <param name="mesaj">Yükləmə zamanı göstəriləcək mesaj</param>
    /// <returns>Əməliyyat nəticəsi</returns>
    public async System.Threading.Tasks.Task<T> EmeliyyatIcraEtAsync<T>(Func<System.Threading.Tasks.Task<T>> emeliyyat, string mesaj = "Yüklənir...")
    {
        T netice = default(T);

        try
        {
            Baslat(mesaj);
            netice = await emeliyyat();
        }
        finally
        {
            Dayandir();
        }

        return netice;
    }

    /// <summary>
    /// Void qaytaran asinxron əməliyyatı icra edən və yükləmə göstəricisini idarə edən metod
    /// </summary>
    /// <param name="emeliyyat">İcra ediləcək əməliyyat</param>
    /// <param name="mesaj">Yükləmə zamanı göstəriləcək mesaj</param>
    public async System.Threading.Tasks.Task EmeliyyatIcraEtAsync(Func<System.Threading.Tasks.Task> emeliyyat, string mesaj = "Yüklənir...")
    {
        try
        {
            Baslat(mesaj);
            await emeliyyat();
        }
        finally
        {
            Dayandir();
        }
    }

    /// <summary>
    /// Static helper metod - yükləmə göstəricisi ilə əməliyyat icra edir
    /// </summary>
    /// <param name="form">Ana form</param>
    /// <param name="mesaj">Yükləmə mesajı</param>
    /// <param name="emeliyyat">İcra ediləcək əməliyyat</param>
    public static async System.Threading.Tasks.Task GosterVeIcraEtAsync(Form form, string mesaj, Func<System.Threading.Tasks.Task> emeliyyat)
    {
        var gosterici = new YuklemeGostergeci(form);
        await gosterici.EmeliyyatIcraEtAsync(emeliyyat, mesaj);
    }

    /// <summary>
    /// Static helper metod - yükləmə göstəricisi ilə əməliyyat icra edir (generic version)
    /// </summary>
    /// <typeparam name="T">Nəticə tipi</typeparam>
    /// <param name="form">Ana form</param>
    /// <param name="mesaj">Yükləmə mesajı</param>
    /// <param name="emeliyyat">İcra ediləcək əməliyyat</param>
    public static async System.Threading.Tasks.Task<T> GosterVeIcraEtAsync<T>(Form form, string mesaj, Func<System.Threading.Tasks.Task<T>> emeliyyat)
    {
        var gosterici = new YuklemeGostergeci(form);
        return await gosterici.EmeliyyatIcraEtAsync(emeliyyat, mesaj);
    }
}