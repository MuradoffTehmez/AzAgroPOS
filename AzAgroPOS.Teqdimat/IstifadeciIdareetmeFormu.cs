// Fayl: AzAgroPOS.Teqdimat/IstifadeciIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class IstifadeciIdareetmeFormu : BazaForm, IIstifadeciView
{
    private readonly IstifadeciPresenter _presenter;

    public IstifadeciIdareetmeFormu()
    {
        InitializeComponent();
        _presenter = new IstifadeciPresenter(this);
        dgvIstifadeciler.SelectionChanged += (s, e) =>
        {
            if (dgvIstifadeciler.CurrentRow != null && dgvIstifadeciler.CurrentRow.DataBoundItem is IstifadeciDto dto)
            {
                txtId.Text = dto.Id.ToString();
            }
        };
    }

    public string IstifadeciId { get => txtId.Text; set => txtId.Text = value; }
    public string IstifadeciAdi { get => txtIstifadeciAdi.Text; set => txtIstifadeciAdi.Text = value; }
    public string TamAd { get => txtTamAd.Text; set => txtTamAd.Text = value; }
    public string Parol { get => txtParol.Text; set => txtParol.Text = value; }
    public int SecilmisRolId => (int)(cmbRollar.SelectedValue ?? 0);

    public event EventHandler FormYuklendi;
    public event EventHandler IstifadeciYarat_Istek;
    public event EventHandler IstifadeciSil_Istek;

    public void IstifadecileriGoster(List<IstifadeciDto> istifadeciler)
    {
        dgvIstifadeciler.DataSource = istifadeciler;
    }

    
    public void RollariGoster(List<Rol> rollar)
    {
        cmbRollar.DataSource = rollar;
        cmbRollar.DisplayMember = "Ad";
        cmbRollar.ValueMember = "Id";
    }

    public void MesajGoster(string mesaj, bool xetadir = false)
    {
        MessageBox.Show(mesaj, xetadir ? "Xəta" : "Məlumat", MessageBoxButtons.OK, xetadir ? MessageBoxIcon.Error : MessageBoxIcon.Information);
    }

    public void FormuTemizle()
    {
        txtIstifadeciAdi.Clear();
        txtTamAd.Clear();
        txtParol.Clear();
        if (cmbRollar.Items.Count > 0)
        {
            cmbRollar.SelectedIndex = 0;
        }
    }

    private void IstifadeciIdareetmeFormu_Load(object sender, EventArgs e) => FormYuklendi?.Invoke(this, EventArgs.Empty);
    private void btnYarat_Click(object sender, EventArgs e) => IstifadeciYarat_Istek?.Invoke(this, EventArgs.Empty);
    private void btnSil_Click(object sender, EventArgs e) => IstifadeciSil_Istek?.Invoke(this, EventArgs.Empty);
}