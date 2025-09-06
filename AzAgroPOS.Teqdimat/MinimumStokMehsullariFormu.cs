// Fayl: AzAgroPOS.Teqdimat/MinimumStokMehsullariFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class MinimumStokMehsullariFormu : BazaForm, IMinimumStokMehsullariView
{
    private readonly MinimumStokMehsullariPresenter _presenter;

    public MinimumStokMehsullariFormu(MehsulMeneceri mehsulMeneceri)
    {
        InitializeComponent();
        _presenter = new MinimumStokMehsullariPresenter(this, mehsulMeneceri);
        StilVerDataGridView(dgvMinimumStokMehsullari);
    }

    #region IMinimumStokMehsullariView Implementasiyası

    public event EventHandler FormYuklendi;
    public event EventHandler Yenile_Istek;

    public void MinimumStokMehsullariniGoster(List<MehsulDto> mehsullar)
    {
        dgvMinimumStokMehsullari.SelectionChanged -= dgvMinimumStokMehsullari_SelectionChanged;
        dgvMinimumStokMehsullari.DataSource = mehsullar;
        dgvMinimumStokMehsullari.SelectionChanged += dgvMinimumStokMehsullari_SelectionChanged;

        if (dgvMinimumStokMehsullari.Columns.Count > 0)
        {
            dgvMinimumStokMehsullari.Columns["Id"].Visible = false;
            dgvMinimumStokMehsullari.Columns["Ad"].HeaderText = "Məhsulun Adı";
            dgvMinimumStokMehsullari.Columns["StokKodu"].HeaderText = "Stok Kodu";
            dgvMinimumStokMehsullari.Columns["Barkod"].HeaderText = "Barkod";
            dgvMinimumStokMehsullari.Columns["MovcudSay"].HeaderText = "Mövcud Say";
            dgvMinimumStokMehsullari.Columns["MinimumStok"].HeaderText = "Minimum Stok";
            dgvMinimumStokMehsullari.Columns["OlcuVahidiStr"].HeaderText = "Ölçü Vahidi";
            dgvMinimumStokMehsullari.Columns["KateqoriyaAdi"].HeaderText = "Kateqoriya";
            dgvMinimumStokMehsullari.Columns["BrendAdi"].HeaderText = "Brend";
            dgvMinimumStokMehsullari.Columns["TedarukcuAdi"].HeaderText = "Tədarükçü";
        }
    }

    public void MesajGoster(string mesaj, bool xetadir = false)
    {
        MessageBox.Show(mesaj, xetadir ? "Xəta" : "Məlumat", MessageBoxButtons.OK, xetadir ? MessageBoxIcon.Error : MessageBoxIcon.Information);
    }

    /// <summary>
    /// Shows a validation error on a control
    /// </summary>
    /// <param name="control">Control to show error on</param>
    /// <param name="message">Error message</param>
    public void XetaGoster(Control control, string message)
    {
        errorProvider1.SetError(control, message);
        errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        errorProvider1.SetIconPadding(control, 2);
    }

    /// <summary>
    /// Clears validation error from a control
    /// </summary>
    /// <param name="control">Control to clear error from</param>
    public void XetaniTemizle(Control control)
    {
        errorProvider1.SetError(control, string.Empty);
    }

    /// <summary>
    /// Clears all validation errors
    /// </summary>
    public void ButunXetalariTemizle()
    {
        // Clear errors from all controls
        foreach (Control control in this.Controls)
        {
            ClearErrorsRecursive(control);
        }
    }

    /// <summary>
    /// Recursively clears errors from all controls
    /// </summary>
    /// <param name="control">Control to clear errors from</param>
    private void ClearErrorsRecursive(Control control)
    {
        errorProvider1.SetError(control, string.Empty);
        foreach (Control child in control.Controls)
        {
            ClearErrorsRecursive(child);
        }
    }

    #endregion

    private void MinimumStokMehsullariFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
    }

    private void btnYenile_Click(object sender, EventArgs e)
    {
        Yenile_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void dgvMinimumStokMehsullari_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvMinimumStokMehsullari.CurrentRow?.DataBoundItem is MehsulDto mehsul)
        {
            // Seçilmiş məhsul haqqında ətraflı məlumat göstərmək üçün burada kod yazmaq olar
            // Hazırda sadə formada buraxırıq
        }
    }
}