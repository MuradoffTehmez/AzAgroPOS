// Fayl: AzAgroPOS.Teqdimat/EmekHaqqiFormu.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat;
/// <summary>
/// Əmək haqqı hesablama və idarəetmə forması.
/// Diqqət: Bu forma işçilərin əmək haqqını hesablamaq, ödəmək və tarixçəyə baxmaq üçündür.
/// </summary>
public partial class EmekHaqqiFormu : BazaForm
{
    private readonly EmekHaqqiManager _emekHaqqiManager;
    private readonly IsciManager _isciManager;
    private bool _yuklenmeDevamEdir = false; // Eyni vaxtda əməliyyatların qarşısını al
    private bool _formaYuklenir = false; // Form yüklənmə prosesini izlə

    public EmekHaqqiFormu(EmekHaqqiManager emekHaqqiManager, IsciManager isciManager)
    {
        InitializeComponent();
        _emekHaqqiManager = emekHaqqiManager ?? throw new ArgumentNullException(nameof(emekHaqqiManager));
        _isciManager = isciManager ?? throw new ArgumentNullException(nameof(isciManager));

        // Form yüklənəndə işçi siyahısını və tarixçəni yüklə
        Load += EmekHaqqiFormu_Load;

        // DataGridView xətalarını idarə et
        dgvEmekHaqqlari.DataError += DgvEmekHaqqlari_DataError;
    }

    /// <summary>
    /// DataGridView xətalarını idarə edir (enum conversion xətaları və s.)
    /// </summary>
    private void DgvEmekHaqqlari_DataError(object? sender, DataGridViewDataErrorEventArgs e)
    {
        // Xətanı səssizcə keç - enum dəyərləri üçün "Naməlum" göstəriləcək
        e.ThrowException = false;
    }

    private void EmekHaqqiFormu_Load(object sender, EventArgs e)
    {
        _ = YukleAsync();
    }

    private async Task YukleAsync()
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        _yuklenmeDevamEdir = true;
        _formaYuklenir = true;

        try
        {
            await IscileriYukle();
            await EmekHaqqiTarixcesiniYukle();

            // Dövr üçün hazırkı ayı təyin et
            dtpDovr.Value = DateTime.Now;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Forma yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        finally
        {
            _formaYuklenir = false;
            _yuklenmeDevamEdir = false;
        }
    }

    /// <summary>
    /// Aktiv işçiləri ComboBox-a yüklə
    /// </summary>
    private async Task IscileriYukle()
    {
        try
        {
            EmeliyyatNeticesi<List<IsciDto>> netice = await _isciManager.ButunIscileriGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                List<IsciDto> aktivIsciler = netice.Data.Where(i => i.Status == IsciStatusu.Aktiv).ToList();
                cmbIsci.DataSource = aktivIsciler;
                cmbIsci.DisplayMember = "TamAd";
                cmbIsci.ValueMember = "Id";
                cmbIsci.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show($"İşçi siyahısı yüklənərkən xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "İşçi Siyahısı");
        }
    }

    /// <summary>
    /// Əmək haqqı tarixçəsini DataGridView-ə yüklə
    /// </summary>
    private async Task EmekHaqqiTarixcesiniYukle()
    {
        try
        {
            EmeliyyatNeticesi<List<EmekHaqqiDto>> netice = await _emekHaqqiManager.EmekHaqqilariGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                FormatGrid();
                dgvEmekHaqqlari.DataSource = new System.ComponentModel.BindingList<EmekHaqqiDto>(netice.Data.ToList());
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Əmək Haqqı Tarixçəsi");
        }
    }

    /// <summary>
    /// DataGridView sütunlarını formatla
    /// </summary>
    private void FormatGrid()
    {
        if (dgvEmekHaqqlari.Columns.Count > 0) return;

        dgvEmekHaqqlari.AutoGenerateColumns = false;
        
        dgvEmekHaqqlari.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
        dgvEmekHaqqlari.Columns.Add(new DataGridViewTextBoxColumn { Name = "IsciId", DataPropertyName = "IsciId", Visible = false });
        dgvEmekHaqqlari.Columns.Add(new DataGridViewTextBoxColumn { Name = "IsciAdi", DataPropertyName = "IsciAdi", HeaderText = "İşçi" });
        dgvEmekHaqqlari.Columns.Add(new DataGridViewTextBoxColumn { Name = "Dovr", DataPropertyName = "Dovr", HeaderText = "Dövr" });
        
        var baseSalaryCol = new DataGridViewTextBoxColumn { Name = "EsasMaas", DataPropertyName = "EsasMaas", HeaderText = "Əsas Maaş" };
        baseSalaryCol.DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns.Add(baseSalaryCol);
        
        var bonusCol = new DataGridViewTextBoxColumn { Name = "Bonuslar", DataPropertyName = "Bonuslar", HeaderText = "Bonuslar" };
        bonusCol.DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns.Add(bonusCol);
        
        var extraPayCol = new DataGridViewTextBoxColumn { Name = "ElaveOdenisler", DataPropertyName = "ElaveOdenisler", HeaderText = "Əlavə Ödənişlər" };
        extraPayCol.DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns.Add(extraPayCol);
        
        var leaveDedCol = new DataGridViewTextBoxColumn { Name = "IcazeTutulmasi", DataPropertyName = "IcazeTutulmasi", HeaderText = "İcazə Tutulması" };
        leaveDedCol.DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns.Add(leaveDedCol);
        
        var otherDedCol = new DataGridViewTextBoxColumn { Name = "DigerTutulmalar", DataPropertyName = "DigerTutulmalar", HeaderText = "Digər Tutulmalar" };
        otherDedCol.DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns.Add(otherDedCol);
        
        var finalCol = new DataGridViewTextBoxColumn { Name = "YekunEmekHaqqi", DataPropertyName = "YekunEmekHaqqi", HeaderText = "Yekun" };
        finalCol.DefaultCellStyle.Format = "N2";
        dgvEmekHaqqlari.Columns.Add(finalCol);
        
        dgvEmekHaqqlari.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "StatusStr", HeaderText = "Status" });
        
        var dateCol = new DataGridViewTextBoxColumn { Name = "HesablanmaTarixi", DataPropertyName = "HesablanmaTarixi", HeaderText = "Hesablama Tarixi" };
        dateCol.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        dgvEmekHaqqlari.Columns.Add(dateCol);
        
        dgvEmekHaqqlari.Columns.Add(new DataGridViewTextBoxColumn { Name = "OdenisTarixi", DataPropertyName = "OdenisTarixi", HeaderText = "Ödəniş Tarixi" });
        dgvEmekHaqqlari.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qeyd", DataPropertyName = "Qeyd", HeaderText = "Qeyd" });

        dgvEmekHaqqlari.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    /// <summary>
    /// Əmək haqqını hesabla düyməsi
    /// </summary>
    private void btnHesabla_Click(object sender, EventArgs e)
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        if (cmbIsci.SelectedValue == null)
        {
            MessageBox.Show("Zəhmət olmasa işçi seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _ = HesablaAsync();
    }

    private async Task HesablaAsync()
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        _yuklenmeDevamEdir = true;

        try
        {
            int isciId = (int)cmbIsci.SelectedValue;
            string dovr = dtpDovr.Value.ToString("yyyy MMMM");
            decimal elaveOdenisler = numElaveOdenisler.Value;
            decimal digerTutulmalar = numDigerTutulmalar.Value;
            string qeyd = txtQeyd.Text;

            EmeliyyatNeticesi<int> netice = await _emekHaqqiManager.EmekHaqqiHesablaAsync(
                isciId,
                dovr,
                elaveOdenisler,
                digerTutulmalar,
                qeyd,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Əmək haqqı uğurla hesablandı!");
                await EmekHaqqiTarixcesiniYukle();
                FormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Əmək Haqqı Hesablama");
        }
        finally
        {
            _yuklenmeDevamEdir = false;
        }
    }

    /// <summary>
    /// Ödə düyməsi - seçilmiş əmək haqqını ödə
    /// </summary>
    private void btnOde_Click(object sender, EventArgs e)
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        if (dgvEmekHaqqlari.SelectedRows.Count == 0)
        {
            MessageBox.Show("Zəhmət olmasa ödəniləcək əmək haqqını seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int emekHaqqiId = (int)dgvEmekHaqqlari.SelectedRows[0].Cells["Id"].Value;
        string? status = dgvEmekHaqqlari.SelectedRows[0].Cells["Status"].Value.ToString();

        if (status == EmekHaqqiStatusu.Odenilmis.ToString())
        {
            MessageBox.Show("Bu əmək haqqı artıq ödənilib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult tesdiq = MessageBox.Show(
            "Bu əmək haqqını ödəmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tesdiq != DialogResult.Yes)
        {
            return;
        }

        _ = OdeAsync(emekHaqqiId);
    }

    private async Task OdeAsync(int emekHaqqiId)
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        _yuklenmeDevamEdir = true;

        try
        {
            EmeliyyatNeticesi netice = await _emekHaqqiManager.EmekHaqqiOdeAsync(emekHaqqiId, AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Əmək haqqı uğurla ödənildi!");
                await EmekHaqqiTarixcesiniYukle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Əmək Haqqı Ödənişi");
        }
        finally
        {
            _yuklenmeDevamEdir = false;
        }
    }

    /// <summary>
    /// Ləğv et düyməsi
    /// </summary>
    private void btnLegvEt_Click(object sender, EventArgs e)
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        if (dgvEmekHaqqlari.SelectedRows.Count == 0)
        {
            MessageBox.Show("Zəhmət olmasa ləğv ediləcək əmək haqqını seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        int emekHaqqiId = (int)dgvEmekHaqqlari.SelectedRows[0].Cells["Id"].Value;
        string? status = dgvEmekHaqqlari.SelectedRows[0].Cells["Status"].Value.ToString();

        if (status == EmekHaqqiStatusu.Legv.ToString())
        {
            MessageBox.Show("Bu əmək haqqı artıq ləğv edilib!", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        DialogResult tesdiq = MessageBox.Show(
            "Bu əmək haqqını ləğv etmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Warning);

        if (tesdiq != DialogResult.Yes)
        {
            return;
        }

        _ = LegvEtAsync(emekHaqqiId);
    }

    private async Task LegvEtAsync(int emekHaqqiId)
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        _yuklenmeDevamEdir = true;

        try
        {
            EmeliyyatNeticesi netice = await _emekHaqqiManager.EmekHaqqiLegvEtAsync(emekHaqqiId);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Əmək haqqı ləğv edildi!");
                await EmekHaqqiTarixcesiniYukle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Əmək Haqqı Ləğvi");
        }
        finally
        {
            _yuklenmeDevamEdir = false;
        }
    }

    /// <summary>
    /// Formu təmizlə
    /// </summary>
    private void FormuTemizle()
    {
        cmbIsci.SelectedIndex = -1;
        numElaveOdenisler.Value = 0;
        numDigerTutulmalar.Value = 0;
        txtQeyd.Clear();
    }

    /// <summary>
    /// Yenilə düyməsi
    /// </summary>
    private void btnYenile_Click(object sender, EventArgs e)
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        _ = YenileAsync();
    }

    private async Task YenileAsync()
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        _yuklenmeDevamEdir = true;

        try
        {
            await EmekHaqqiTarixcesiniYukle();
        }
        finally
        {
            _yuklenmeDevamEdir = false;
        }
    }

    /// <summary>
    /// İşçi seçildikdə onun son əmək haqqı məlumatlarını göstər
    /// </summary>
    private void cmbIsci_SelectedIndexChanged(object sender, EventArgs e)
    {
        // Forma yüklənərkən və ya başqa əməliyyat davam edərkən işləmə
        if (_formaYuklenir || _yuklenmeDevamEdir)
        {
            return;
        }

        if (cmbIsci.SelectedValue == null)
        {
            return;
        }

        _ = IsciSecildiAsync();
    }

    private async Task IsciSecildiAsync()
    {
        if (_yuklenmeDevamEdir)
        {
            return;
        }

        _yuklenmeDevamEdir = true;

        try
        {
            int isciId = (int)cmbIsci.SelectedValue;
            EmeliyyatNeticesi<List<EmekHaqqiDto>> netice = await _emekHaqqiManager.EmekHaqqilariGetirAsync();

            if (netice.UgurluDur && netice.Data != null)
            {
                List<EmekHaqqiDto> isciEmekHaqqlari = netice.Data.Where(eh => eh.IsciId == isciId).ToList();
                if (isciEmekHaqqlari.Any())
                {
                    EmekHaqqiDto sonEmekHaqqi = isciEmekHaqqlari.OrderByDescending(eh => eh.HesablanmaTarixi).First();
                    lblSonMaas.Text = $"Son Maaş: {sonEmekHaqqi.YekunEmekHaqqi:N2} AZN ({sonEmekHaqqi.Dovr})";
                }
                else
                {
                    lblSonMaas.Text = "Son Maaş: ---";
                }
            }
            else
            {
                lblSonMaas.Text = "Son Maaş: ---";
            }
        }
        catch
        {
            lblSonMaas.Text = "Son Maaş: ---";
        }
        finally
        {
            _yuklenmeDevamEdir = false;
        }
    }
}
