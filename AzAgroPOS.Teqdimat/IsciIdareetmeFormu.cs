// Fayl: AzAgroPOS.Teqdimat/IsciIdareetmeFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public partial class IsciIdareetmeFormu : BazaForm, IIsciView
{
    private readonly IsciPresenter _presenter;
    private Panel? _paginationPanel;
    private Button? _btnEvvelki;
    private Button? _btnNovbeti;
    private Label? _lblSehifeMelumati;

    public IsciIdareetmeFormu(IsciManager isciManager)
    {
        InitializeComponent();
        _presenter = new IsciPresenter(this, isciManager);
        StilVerDataGridView(dgvIsciler);
        SetupPaginationUI();
    }

    private void SetupPaginationUI()
    {
        // Pagination panel yaradırıq
        _paginationPanel = new Panel
        {
            Height = 35,
            Dock = DockStyle.Bottom,
            BackColor = Color.WhiteSmoke,
            Padding = new Padding(5)
        };

        // Əvvəlki səhifə düyməsi
        _btnEvvelki = new Button
        {
            Text = "← Əvvəlki",
            Width = 100,
            Height = 28,
            Location = new Point(10, 3),
            Enabled = false
        };
        _btnEvvelki.Click += (s, e) => EvvelkiSehifeIstek?.Invoke(this, EventArgs.Empty);

        // Növbəti səhifə düyməsi
        _btnNovbeti = new Button
        {
            Text = "Növbəti →",
            Width = 100,
            Height = 28,
            Location = new Point(120, 3),
            Enabled = false
        };
        _btnNovbeti.Click += (s, e) => NovbetiSehifeIstek?.Invoke(this, EventArgs.Empty);

        // Səhifə məlumatı label
        _lblSehifeMelumati = new Label
        {
            AutoSize = true,
            Location = new Point(230, 8),
            Text = "Səhifə 1/1 - Cəmi: 0 qeyd"
        };

        _paginationPanel.Controls.AddRange(new Control[] { _btnEvvelki, _btnNovbeti, _lblSehifeMelumati });
        this.Controls.Add(_paginationPanel);
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

    public string AxtarisMetni => string.Empty; // Axtarış textbox-u hələ əlavə edilməyib

    public event EventHandler FormYuklendi;
    public event EventHandler IsciYarat_Istek;
    public event EventHandler IsciYenile_Istek;
    public event EventHandler IsciSil_Istek;
    public event EventHandler FormuTemizle_Istek;
    public event EventHandler AxtarIstek;
    public event EventHandler NovbetiSehifeIstek;
    public event EventHandler EvvelkiSehifeIstek;

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
        if (performansQeydleri == null || !performansQeydleri.Any())
        {
            MesajGoster("İşçinin heç bir performans qeydi tapılmadı.", false);
            return;
        }

        // Performans qeydlərini mətn formatında göstəririk
        var mesaj = $"İşçinin {performansQeydleri.Count} performans qeydi:\n\n";
        foreach (var qeyd in performansQeydleri.Take(5)) // İlk 5 qeydi göstəririk
        {
            mesaj += $"• Tarix: {qeyd.Tarix:dd.MM.yyyy} | Dövr: {qeyd.QeydDovru}\n";
            mesaj += $"  Qiymət: {qeyd.Qiymet}/10 | Qeydlər: {qeyd.Qeydler}\n\n";
        }

        if (performansQeydleri.Count > 5)
        {
            mesaj += $"... və daha {performansQeydleri.Count - 5} qeyd.\n";
        }

        MesajGoster(mesaj, "Performans Qeydləri", MessageBoxIcon.Information);
    }

    public void IzinQeydleriniGoster(List<IsciIzniDto> izinQeydleri)
    {
        if (izinQeydleri == null || !izinQeydleri.Any())
        {
            MesajGoster("İşçinin heç bir məzuniyyət/icazə qeydi tapılmadı.", false);
            return;
        }

        // İzin qeydlərini mətn formatında göstəririk
        var mesaj = $"İşçinin {izinQeydleri.Count} məzuniyyət/icazə qeydi:\n\n";
        foreach (var izin in izinQeydleri.Take(5)) // İlk 5 qeydi göstəririk
        {
            mesaj += $"• {izin.IzinNovu}: {izin.BaslamaTarixi:dd.MM.yyyy} - {izin.BitmeTarixi:dd.MM.yyyy}\n";
            mesaj += $"  Günlər: {izin.IzinGunu} | Status: {izin.Status}\n";
            mesaj += $"  Səbəb: {izin.Sebeb}\n\n";
        }

        if (izinQeydleri.Count > 5)
        {
            mesaj += $"... və daha {izinQeydleri.Count - 5} qeyd.\n";
        }

        MesajGoster(mesaj, "Məzuniyyət Qeydləri", MessageBoxIcon.Information);
    }

    public void SehifeMelumatlariGoster(int cariSehife, int umumiSehife, int umumiQeyd, bool evvelkiVar, bool novbetiVar)
    {
        if (_lblSehifeMelumati != null)
        {
            _lblSehifeMelumati.Text = $"Səhifə {cariSehife}/{umumiSehife} - Cəmi: {umumiQeyd} qeyd";
        }

        if (_btnEvvelki != null)
        {
            _btnEvvelki.Enabled = evvelkiVar;
        }

        if (_btnNovbeti != null)
        {
            _btnNovbeti.Enabled = novbetiVar;
        }
    }

    public async Task EmeliyyatIcraEtAsync(Func<Task> emeliyyat, string mesaj)
    {
        var gosterici = new Yardimcilar.YuklemeGostergeci(this);
        await gosterici.EmeliyyatIcraEtAsync(emeliyyat, mesaj);
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

    public void MesajGoster(string mesaj, string basliq, MessageBoxIcon ikon)
    {
        MessageBox.Show(mesaj, basliq, MessageBoxButtons.OK, ikon);
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
}