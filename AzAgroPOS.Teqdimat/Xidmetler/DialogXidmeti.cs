// Fayl: AzAgroPOS.Teqdimat/Xidmetler/DialogXidmeti.cs

namespace AzAgroPOS.Teqdimat.Xidmetler;

/// <summary>
/// Dialog və mesaj göstərmək üçün xidmət implementasiyası
/// MessageBox.Show-u mərkəzləşdirir və test edilə bilən edir
/// </summary>
public class DialogXidmeti : IDialogXidmeti
{
    public void MelumatGoster(string mesaj, string basliq = "Məlumat")
    {
        MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void XetaGoster(string mesaj, string basliq = "Xəta")
    {
        MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public void XeberdarligGoster(string mesaj, string basliq = "Xəbərdarlıq")
    {
        MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public void UgurGoster(string mesaj, string basliq = "Uğurlu")
    {
        MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public bool TesdiqSorus(string mesaj, string basliq = "Təsdiq")
    {
        var netice = MessageBox.Show(mesaj, basliq, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        return netice == DialogResult.Yes;
    }

    public DialogResult SecimSorus(string mesaj, string basliq = "Seçim")
    {
        return MessageBox.Show(mesaj, basliq, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
    }
}
