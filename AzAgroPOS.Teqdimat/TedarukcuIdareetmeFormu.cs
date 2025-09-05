// Fayl: AzAgroPOS.Teqdimat/TedarukcuIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class TedarukcuIdareetmeFormu : BazaForm, ITedarukcuView
{
    private readonly TedarukcuPresenter _presenter;

    public TedarukcuIdareetmeFormu(AlisManager alisManager)
    {
        InitializeComponent();
        _presenter = new TedarukcuPresenter(this, alisManager);
        StilVerDataGridView(dgvTedarukculer);
    }

    #region ITedarukcuView Implementasiyası

    public int TedarukcuId
    {
        get => string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text);
        set => txtId.Text = value.ToString();
    }

    public string Ad
    {
        get => txtAd.Text;
        set => txtAd.Text = value;
    }

    public string? Voen
    {
        get => txtVoen.Text;
        set => txtVoen.Text = value;
    }

    public string? Unvan
    {
        get => txtUnvan.Text;
        set => txtUnvan.Text = value;
    }

    public string? Telefon
    {
        get => txtTelefon.Text;
        set => txtTelefon.Text = value;
    }

    public string? Email
    {
        get => txtEmail.Text;
        set => txtEmail.Text = value;
    }

    public string? BankHesabi
    {
        get => txtBankHesabi.Text;
        set => txtBankHesabi.Text = value;
    }

    public bool Aktivdir
    {
        get => chkAktivdir.Checked;
        set => chkAktivdir.Checked = value;
    }

    public event EventHandler FormYuklendi;
    public event EventHandler TedarukcuYarat_Istek;
    public event EventHandler TedarukcuYenile_Istek;
    public event EventHandler TedarukcuSil_Istek;
    public event EventHandler FormuTemizle_Istek;

    public void TedarukculeriGoster(List<TedarukcuDto> tedarukculer)
    {
        dgvTedarukculer.SelectionChanged -= dgvTedarukculer_SelectionChanged;
        dgvTedarukculer.DataSource = tedarukculer;
        dgvTedarukculer.SelectionChanged += dgvTedarukculer_SelectionChanged;

        if (dgvTedarukculer.Columns.Count > 0)
        {
            dgvTedarukculer.Columns["Id"].Visible = false;
            dgvTedarukculer.Columns["Ad"].HeaderText = "Ad";
            dgvTedarukculer.Columns["Voen"].HeaderText = "VÖEN";
            dgvTedarukculer.Columns["Unvan"].HeaderText = "Ünvan";
            dgvTedarukculer.Columns["Telefon"].HeaderText = "Telefon";
            dgvTedarukculer.Columns["Email"].HeaderText = "Email";
            dgvTedarukculer.Columns["BankHesabi"].HeaderText = "Bank Hesabı";
            dgvTedarukculer.Columns["Aktivdir"].HeaderText = "Aktiv";
        }
    }

    public void MesajGoster(string mesaj, bool xetadir = false)
    {
        MessageBox.Show(mesaj, xetadir ? "Xəta" : "Məlumat", MessageBoxButtons.OK, xetadir ? MessageBoxIcon.Error : MessageBoxIcon.Information);
    }

    public void FormuTemizle()
    {
        txtId.Clear();
        txtAd.Clear();
        txtVoen.Clear();
        txtUnvan.Clear();
        txtTelefon.Clear();
        txtEmail.Clear();
        txtBankHesabi.Clear();
        chkAktivdir.Checked = true;
        dgvTedarukculer.ClearSelection();
        txtAd.Focus();
    }

    #endregion

    private void TedarukcuIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
        FormuTemizle();
    }

    private void btnYarat_Click(object sender, EventArgs e)
    {
        TedarukcuYarat_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnYenile_Click(object sender, EventArgs e)
    {
        TedarukcuYenile_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
        TedarukcuSil_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void dgvTedarukculer_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvTedarukculer.CurrentRow?.DataBoundItem is TedarukcuDto tedarukcu)
        {
            txtId.Text = tedarukcu.Id.ToString();
            txtAd.Text = tedarukcu.Ad;
            txtVoen.Text = tedarukcu.Voen;
            txtUnvan.Text = tedarukcu.Unvan;
            txtTelefon.Text = tedarukcu.Telefon;
            txtEmail.Text = tedarukcu.Email;
            txtBankHesabi.Text = tedarukcu.BankHesabi;
            chkAktivdir.Checked = tedarukcu.Aktivdir;
        }
    }
}