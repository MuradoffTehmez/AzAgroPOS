// Fayl: AzAgroPOS.Teqdimat/IstifadeciIdareetmeFormu.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat;

public partial class IstifadeciIdareetmeFormu : BazaForm, IIstifadeciView
{
    private readonly IstifadeciPresenter _presenter;
    private readonly IcazeManager _icazeManager;

    public IstifadeciIdareetmeFormu(IstifadeciManager istifadeciManager, IcazeManager icazeManager)
    {
        InitializeComponent();
        _icazeManager = icazeManager;
        _presenter = new IstifadeciPresenter(this, istifadeciManager);
        StilVerDataGridView(dgvIstifadeciler);
        dgvIstifadeciler.CellClick += (_, e) =>
        {
            if (e.RowIndex >= 0)
                dgvIstifadeciler_SelectionChanged(dgvIstifadeciler, EventArgs.Empty);
        };
        Button icazeButton = new()
        {
            Text = "ROLLAR VƏ İCAZƏLƏR",
            Location = new Point(18, 338),
            Size = new Size(380, 40),
            Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
        };
        icazeButton.Visible = IcazeYoxlayici.Instance.AdminDirmi();
        icazeButton.Click += async (_, _) => await RolIcazeleriniGosterAsync();
        materialCard1.Controls.Add(icazeButton);
    }

    private async Task RolIcazeleriniGosterAsync()
    {
        if (!IcazeYoxlayici.Instance.AdminDirmi()) return;
        EmeliyyatNeticesi<IEnumerable<IcazeDto>> netice = await _icazeManager.ButunIcazeleriGetirAsync();
        if (!netice.UgurluDur)
        {
            MesajGoster(netice.Mesaj, true);
            return;
        }
        List<IcazeDto> icazeler = netice.Data.OrderBy(i => i.Ad).ToList();
        List<Rol> rollar = cmbRollar.Items.Cast<Rol>().Where(r => r.Id != 1).ToList();
        if (rollar.Count == 0)
        {
            MesajGoster("Redaktə ediləcək rol tapılmadı.", true);
            return;
        }

        using Form dialoq = new()
        {
            Text = "Rollar və icazələr",
            ClientSize = new Size(540, 590),
            MinimumSize = new Size(440, 450),
            StartPosition = FormStartPosition.CenterParent
        };
        ComboBox rolSecimi = new() { Dock = DockStyle.Top, DropDownStyle = ComboBoxStyle.DropDownList, Height = 36 };
        rolSecimi.DataSource = rollar;
        rolSecimi.DisplayMember = nameof(Rol.Ad);
        CheckedListBox siyahi = new() { Dock = DockStyle.Fill, CheckOnClick = true };
        Button yaddaSaxla = new() { Text = "İCAZƏLƏRİ YADDA SAXLA", Dock = DockStyle.Bottom, Height = 44, Enabled = false };
        dialoq.Controls.Add(siyahi);
        dialoq.Controls.Add(yaddaSaxla);
        dialoq.Controls.Add(rolSecimi);

        async Task SecilmisRoluYukleAsync()
        {
            if (rolSecimi.SelectedItem is not Rol rol) return;
            yaddaSaxla.Enabled = false;
            EmeliyyatNeticesi<IEnumerable<IcazeDto>> rolNeticesi = await _icazeManager.RolIcazeleriniGetirAsync(rol.Id);
            if (!rolNeticesi.UgurluDur)
            {
                MesajGoster(rolNeticesi.Mesaj, true);
                return;
            }
            HashSet<int> secilmis = rolNeticesi.Data.Select(i => i.Id).ToHashSet();
            siyahi.Items.Clear();
            foreach (IcazeDto icaze in icazeler)
                siyahi.Items.Add(icaze, secilmis.Contains(icaze.Id));
            siyahi.DisplayMember = nameof(IcazeDto.Ad);
            yaddaSaxla.Enabled = icazeler.Count > 0;
        }

        rolSecimi.SelectedIndexChanged += async (_, _) => await SecilmisRoluYukleAsync();
        // DataSource seçim bağlaması dialoq görünənədək tamamlanmaya bilər.
        dialoq.Shown += async (_, _) => await SecilmisRoluYukleAsync();
        yaddaSaxla.Click += async (_, _) =>
        {
            if (rolSecimi.SelectedItem is not Rol rol) return;
            yaddaSaxla.Enabled = false;
            try
            {
                int[] idler = siyahi.CheckedItems.Cast<IcazeDto>().Select(i => i.Id).ToArray();
                EmeliyyatNeticesi cavab = await _icazeManager.RolIcazeleriniTeyinEtAsync(rol.Id, idler);
                if (!cavab.UgurluDur)
                    MesajGoster(cavab.Mesaj, true);
                else
                {
                    MesajGoster("Rol icazələri yadda saxlanıldı. Təsir üçün həmin istifadəçi yenidən daxil olmalıdır.");
                    dialoq.Close();
                }
            }
            finally { yaddaSaxla.Enabled = true; }
        };
        dialoq.ShowDialog(this);
    }

    public string IstifadeciId { get => txtId.Text; set => txtId.Text = value; }
    public string IstifadeciAdi { get => txtIstifadeciAdi.Text; set => txtIstifadeciAdi.Text = value; }
    public string TamAd { get => txtTamAd.Text; set => txtTamAd.Text = value; }
    public string Parol { get => txtParol.Text; set => txtParol.Text = value; }
    public int SecilmisRolId => (int)(cmbRollar.SelectedValue ?? 0);

    public event EventHandler FormYuklendi;
    public event EventHandler IstifadeciYarat_Istek;
    public event EventHandler IstifadeciYenile_Istek;
    public event EventHandler IstifadeciSil_Istek;
    public event EventHandler FormuTemizle_Istek;


    public void IstifadecileriGoster(List<IstifadeciDto> istifadeciler)
    {
        dgvIstifadeciler.SelectionChanged -= dgvIstifadeciler_SelectionChanged;
        // Cədvəli yeniləmədən əvvəl seçimi qorumaq üçün
        int secilmisId = string.IsNullOrEmpty(txtId.Text) ? -1 : int.Parse(txtId.Text);

        if (dgvIstifadeciler.Columns.Count == 0)
        {
            dgvIstifadeciler.AutoGenerateColumns = false;
            
            dgvIstifadeciler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
            dgvIstifadeciler.Columns.Add(new DataGridViewTextBoxColumn { Name = "RolId", DataPropertyName = "RolId", Visible = false });
            dgvIstifadeciler.Columns.Add(new DataGridViewTextBoxColumn { Name = "IstifadeciAdi", DataPropertyName = "IstifadeciAdi", HeaderText = "İstifadəçi Adı" });
            dgvIstifadeciler.Columns.Add(new DataGridViewTextBoxColumn { Name = "TamAd", DataPropertyName = "TamAd", HeaderText = "Tam Ad" });
            dgvIstifadeciler.Columns.Add(new DataGridViewTextBoxColumn { Name = "RolAdi", DataPropertyName = "RolAdi", HeaderText = "Rol" });
        }

        dgvIstifadeciler.DataSource = new System.ComponentModel.BindingList<IstifadeciDto>(istifadeciler);

        // Seçimi bərpa etməyə çalışırıq
        if (secilmisId != -1)
        {
            foreach (DataGridViewRow row in dgvIstifadeciler.Rows)
            {
                if (row.DataBoundItem is IstifadeciDto dto && dto.Id == secilmisId)
                {
                    row.Selected = true;
                    break;
                }
            }
        }

        dgvIstifadeciler.SelectionChanged += dgvIstifadeciler_SelectionChanged;
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
        txtId.Clear();
        txtIstifadeciAdi.Clear();
        txtIstifadeciAdi.ReadOnly = false;
        txtTamAd.Clear();
        txtParol.Clear();
        if (cmbRollar.Items.Count > 0)
        {
            cmbRollar.SelectedIndex = 0;
        }
        dgvIstifadeciler.ClearSelection();
        txtIstifadeciAdi.Focus();
        btnSil.Enabled = false; // "Yeni" rejimində "Sil" düyməsi deaktiv olsun
    }

    private void IstifadeciIdareetmeFormu_Load(object sender, EventArgs e)
    {
        FormYuklendi?.Invoke(this, EventArgs.Empty);
        FormuTemizle();
    }

    private void btnYarat_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtId.Text))
        {
            IstifadeciYarat_Istek?.Invoke(this, EventArgs.Empty);
        }
        else
        {
            IstifadeciYenile_Istek?.Invoke(this, EventArgs.Empty);
        }
    }

    private void btnSil_Click(object sender, EventArgs e)
    {
        IstifadeciSil_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void btnTemizle_Click(object sender, EventArgs e)
    {
        FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
    }

    private void dgvIstifadeciler_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvIstifadeciler.CurrentRow?.DataBoundItem is IstifadeciDto istifadeci)
        {
            txtId.Text = istifadeci.Id.ToString();
            txtIstifadeciAdi.Text = istifadeci.IstifadeciAdi;
        txtIstifadeciAdi.ReadOnly = false;
            txtTamAd.Text = istifadeci.TamAd;
            cmbRollar.SelectedValue = istifadeci.RolId;
            txtParol.Clear();
            btnSil.Enabled = true; // "Redakt\u0131" rejimind\u0131 "Sil" d\u00FCym\u0131si aktiv olsun
        }
        else
        {
            btnSil.Enabled = false;
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
        foreach (Control control in Controls)
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
