// Fayl: AzAgroPOS.Teqdimat/IsciIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

public partial class IsciIdareetmeFormu : BazaForm, IIsciView
{
    private readonly IsciPresenter _presenter;

    public IsciIdareetmeFormu(IsciManager isciManager)
    {
        InitializeComponent();
        _presenter = new IsciPresenter(this, isciManager);
        StilVerDataGridView(dgvIsciler);
    }

    #region IIsciView Implementasiyası

    public int IsciId
    {
        get => string.IsNullOrEmpty(txtId.Text) ? 0 : int.Parse(txtId.Text);
        set => txtId.Text = value.ToString();
    }

    public string TamAd
    {
        get => txtTamAd.Text;
        set => txtTamAd.Text = value;
    }

    public DateTime DogumTarixi
    {
        get => dtpDogumTarixi.Value;
        set => dtpDogumTarixi.Value = value;
    }

    public string TelefonNomresi
    {
        get => txtTelefonNomresi.Text;
        set => txtTelefonNomresi.Text = value;
    }

    public string Unvan
    {
        get => txtUnvan.Text;
        set => txtUnvan.Text = value;
    }

    public string Email
    {
        get => txtEmail.Text;
        set => txtEmail.Text = value;
    }

    public DateTime IseBaslamaTarixi
    {
        get => dtpIseBaslamaTarixi.Value;
        set => dtpIseBaslamaTarixi.Value = value;
    }

    public decimal Maas
    {
        get => decimal.TryParse(txtMaas.Text, out var maas) ? maas : 0;
        set => txtMaas.Text = value.ToString("N2");
    }

    public string Vezife
    {
        get => txtVezife.Text;
        set => txtVezife.Text = value;
    }

    public string Departament
    {
        get => txtDepartament.Text;
        set => txtDepartament.Text = value;
    }

    public IsciStatusu Status
    {
        get => (IsciStatusu)Enum.Parse(typeof(IsciStatusu), cmbStatus.SelectedItem?.ToString() ?? "Aktiv");
        set => cmbStatus.SelectedItem = value.ToString();
    }

    public string SvsNo
    {
        get => txtSvsNo.Text;
        set => txtSvsNo.Text = value;
    }

    public string QeydiyyatUnvani
    {
        get => txtQeydiyyatUnvani.Text;
        set => txtQeydiyyatUnvani.Text = value;
    }

    public string BankMəlumatları
    {
        get => txtBankMelumatlari.Text;
        set => txtBankMelumatlari.Text = value;
    }

    public string SistemIstifadeciAdi
    {
        get => txtSistemIstifadeciAdi.Text;
        set => txtSistemIstifadeciAdi.Text = value;
    }

    public event EventHandler FormYuklendi;
    public event EventHandler IsciYarat_Istek;
    public event EventHandler IsciYenile_Istek;
    public event EventHandler IsciSil_Istek;
    public event EventHandler FormuTemizle_Istek;

    public void IscileriGoster(List<IsciDto> isciler)
    {
        dgvIsciler.SelectionChanged -= dgvIsciler_SelectionChanged;
        dgvIsciler.DataSource = isciler;
        dgvIsciler.SelectionChanged += dgvIsciler_SelectionChanged;

        if (dgvIsciler.Columns.Count > 0)
        {
            dgvIsciler.Columns["Id"].Visible = false;
            dgvIsciler.Columns["TamAd"].HeaderText = "Tam Ad";
            dgvIsciler.Columns["DogumTarixi"].HeaderText = "Doğum Tarixi";
            dgvIsciler.Columns["TelefonNomresi"].HeaderText = "Telefon";
            dgvIsciler.Columns["Unvan"].HeaderText = "Ünvan";
            dgvIsciler.Columns["Email"].HeaderText = "Email";
            dgvIsciler.Columns["IseBaslamaTarixi"].HeaderText = "İşə Başlama Tarixi";
            dgvIsciler.Columns["Maas"].HeaderText = "Maaş";
            dgvIsciler.Columns["Vezife"].HeaderText = "Vəzifə";
            dgvIsciler.Columns["Departament"].HeaderText = "Departament";
            dgvIsciler.Columns["Status"].HeaderText = "Status";
            dgvIsciler.Columns["SvsNo"].HeaderText = "SVS No";
            dgvIsciler.Columns["QeydiyyatUnvani"].HeaderText = "Qeydiyyat Ünvanı";
            dgvIsciler.Columns["BankMəlumatları"].HeaderText = "Bank Məlumatları";
            dgvIsciler.Columns["SistemIstifadeciAdi"].HeaderText = "Sistem İstifadəçisi";
        }
    }

    public void MesajGoster(string mesaj, bool xetadir = false)
    {
        MessageBox.Show(mesaj, xetadir ? "Xəta" : "Məlumat", MessageBoxButtons.OK, xetadir ? MessageBoxIcon.Error : MessageBoxIcon.Information);
    }

    public void FormuTemizle()
    {
        txtId.Clear();
        txtTamAd.Clear();
        dtpDogumTarixi.Value = DateTime.Now.AddYears(-25);
        txtTelefonNomresi.Clear();
        txtUnvan.Clear();
        txtEmail.Clear();
        dtpIseBaslamaTarixi.Value = DateTime.Now;
        txtMaas.Clear();
        txtVezife.Clear();
        txtDepartament.Clear();
        cmbStatus.SelectedIndex = 0;
        txtSvsNo.Clear();
        txtQeydiyyatUnvani.Clear();
        txtBankMelumatlari.Clear();
        txtSistemIstifadeciAdi.Clear();
        dgvIsciler.ClearSelection();
        txtTamAd.Focus();
    }

    public void PerformansQeydleriniGoster(List<IsciPerformansDto> performansQeydleri)
    {
        // TODO: Performans qeydlərini göstərmək üçün uyğun forma elementləri əlavə edilməlidir
        MesajGoster($"İşçinin {performansQeydleri.Count} performans qeydi tapıldı.", false);
    }

    public void IzinQeydleriniGoster(List<IsciIzniDto> izinQeydleri)
    {
        // TODO: İzn qeydlərini göstərmək üçün uyğun forma elementləri əlavə edilməlidir
        MesajGoster($"İşçinin {izinQeydleri.Count} məzuniyyət/icazə qeydi tapıldı.", false);
    }

    #endregion

    private void IsciIdareetmeFormu_Load(object sender, EventArgs e)
    {
        // Status combo boxunu dolduruq
        cmbStatus.Items.Clear();
        foreach (IsciStatusu status in Enum.GetValues(typeof(IsciStatusu)))
        {
            cmbStatus.Items.Add(status.ToString());
        }
        cmbStatus.SelectedIndex = 0;

        FormYuklendi?.Invoke(this, EventArgs.Empty);
        FormuTemizle();
    }

    private void btnYarat_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtId.Text) || txtId.Text == "0")
        {
            IsciYarat_Istek?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            IsciYenile_Istek?.Invoke(this, EventArgs.Empty);
        }
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
        IsciSil_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnYenile_Click(object sender, EventArgs e)
    {
        IsciYenile_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void dgvIsciler_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvIsciler.CurrentRow?.DataBoundItem is IsciDto isci)
        {
            txtId.Text = isci.Id.ToString();
            txtTamAd.Text = isci.TamAd;
            dtpDogumTarixi.Value = isci.DogumTarixi;
            txtTelefonNomresi.Text = isci.TelefonNomresi;
            txtUnvan.Text = isci.Unvan;
            txtEmail.Text = isci.Email;
            dtpIseBaslamaTarixi.Value = isci.IseBaslamaTarixi;
            txtMaas.Text = isci.Maas.ToString("N2");
            txtVezife.Text = isci.Vezife;
            txtDepartament.Text = isci.Departament;
            cmbStatus.SelectedItem = isci.Status.ToString();
            txtSvsNo.Text = isci.SvsNo;
            txtQeydiyyatUnvani.Text = isci.QeydiyyatUnvani;
            txtBankMelumatlari.Text = isci.BankMəlumatları;
            txtSistemIstifadeciAdi.Text = isci.SistemIstifadeciAdi;
        }
    }
}