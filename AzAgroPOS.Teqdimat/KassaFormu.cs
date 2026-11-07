// Fayl: AzAgroPOS.Teqdimat/KassaFormu.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Mentiq.Uslublar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using AzAgroPOS.Varliglar;

namespace AzAgroPOS.Teqdimat;
/// <summary>
/// Mərkəzi kassa və maliyyə idarəetmə forması.
/// Diqqət: Bu forma xərcləri, kassa hərəkətlərini və maliyyə hesabatlarını idarə edir.
/// </summary>
public partial class KassaFormu : BazaForm
{
    private readonly MaliyyeManager _maliyyeManager;
    private readonly HesabatManager _hesabatManager;
    private int _seciliXercId = 0;
    private readonly Label _lblKassaCixis = new();
    private readonly Label _lblXulaseIzahi = new();
    private readonly Label _lblSatilanMiqdar = new();
    private readonly Label _lblSatisDeyeri = new();
    private readonly Label _lblAlisDeyeri = new();
    private readonly Label _lblBrutMenfeet = new();
    private readonly Label _lblNagdSatis = new();
    private readonly Label _lblKartSatis = new();
    private readonly Label _lblNisyeSatis = new();
    private readonly Label _lblBorcOdenisi = new();
    private readonly Label _lblTerminalCemi = new();
    private readonly Label _lblQaytarma = new();

    public KassaFormu(MaliyyeManager maliyyeManager, HesabatManager hesabatManager)
    {
        InitializeComponent();
        _maliyyeManager = maliyyeManager ?? throw new ArgumentNullException(nameof(maliyyeManager));
        _hesabatManager = hesabatManager ?? throw new ArgumentNullException(nameof(hesabatManager));

        dgvKassaHareketleri.BackgroundColor = Color.White;
        dgvKassaHareketleri.BorderStyle = BorderStyle.None;
        dgvKassaHareketleri.RowHeadersVisible = false;
        dgvKassaHareketleri.EnableHeadersVisualStyles = false;
        dgvKassaHareketleri.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(42, 64, 81);
        dgvKassaHareketleri.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        dgvKassaHareketleri.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 248, 246);
        groupXulase.BackColor = Color.White;
        tabMaliyyeXulasesi.BackColor = Color.White;
        foreach (Label label in new[] { lblUmumiGelir, lblUmumiXerc, lblMenfeetZerere, lblCariBalans })
        {
            label.BackColor = Color.White;
            label.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
        }
        lblUmumiGelir.Location = new Point(32, 45);
        lblUmumiXerc.Location = new Point(32, 155);
        lblMenfeetZerere.Location = new Point(32, 210);
        lblCariBalans.Location = new Point(32, 265);
        _lblKassaCixis.Location = new Point(32, 100);
        _lblKassaCixis.AutoSize = true;
        _lblKassaCixis.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
        _lblKassaCixis.BackColor = Color.White;
        groupXulase.Controls.Add(_lblKassaCixis);
        _lblXulaseIzahi.Text = "Satışdan qaytarmalar çıxılıb. Nisyə kassaya daxil deyil. Dövr axınına açıq növbə satışı daxildir; jurnal qalığına hələ daxil deyil.";
        _lblXulaseIzahi.Location = new Point(32, 352);
        _lblXulaseIzahi.Size = new Size(620, 55);
        _lblXulaseIzahi.ForeColor = Color.FromArgb(91, 108, 96);
        _lblXulaseIzahi.BackColor = Color.White;
        _lblXulaseIzahi.Font = new Font("Segoe UI", 10F);
        groupXulase.Controls.Add(_lblXulaseIzahi);
        Label[] satisGostericileri = [_lblSatilanMiqdar, _lblSatisDeyeri, _lblAlisDeyeri,
            _lblBrutMenfeet, _lblNagdSatis, _lblKartSatis, _lblNisyeSatis,
            _lblBorcOdenisi, _lblTerminalCemi, _lblQaytarma];
        for (int i = 0; i < satisGostericileri.Length; i++)
        {
            Label label = satisGostericileri[i];
            label.Location = new Point(690, 35 + i * 46);
            label.Size = new Size(600, 38);
            label.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label.BackColor = Color.White;
            label.ForeColor = Color.FromArgb(29, 75, 40);
            groupXulase.Controls.Add(label);
        }
        _lblSatilanMiqdar.Text = "Satılan miqdar: —";
        _lblSatisDeyeri.Text = "Satış dəyəri: —";
        _lblAlisDeyeri.Text = "Satılan malların alış dəyəri: —";
        _lblBrutMenfeet.Text = "Brüt mənfəət: —";
        _lblNagdSatis.Text = "Nağd satış: —";
        _lblKartSatis.Text = "Terminal satışı: —";
        _lblNisyeSatis.Text = "Nisyə satış: —";
        _lblBorcOdenisi.Text = "Borc ödənişi: —";
        _lblTerminalCemi.Text = "Terminal daxilolması: —";
        _lblQaytarma.Text = "Qaytarma: —";
        Button gunlukKassa = new()
        {
            Text = "BU GÜN",
            Location = new Point(735, 18),
            Size = new Size(105, 32),
            BackColor = Color.FromArgb(46, 125, 50),
            ForeColor = Color.White,
            FlatStyle = FlatStyle.Flat
        };
        gunlukKassa.Click += async (_, _) =>
        {
            dtpXesabatBaslangic.Value = DateTime.Today;
            dtpXesabatBitis.Value = DateTime.Today;
            await MaliyyeXulasesiniYukle();
        };
        groupHesabatFiltre.Controls.Add(gunlukKassa);

        // Form yüklənəndə məlumatları yüklə
        Load += KassaFormu_Load;
    }

    private void KassaFormu_Load(object sender, EventArgs e)
    {
        _ = YukleAsync();
    }

    private async Task YukleAsync()
    {
        try
        {
            InitializeEnums();
            // Hesablamalar ekranda göstərilən dövrə əsaslanmalıdır.
            dtpBaslangic.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpBitis.Value = DateTime.Now;
            dtpXesabatBaslangic.Value = dtpBaslangic.Value;
            dtpXesabatBitis.Value = dtpBitis.Value;
            await XercleriYukle();
            await KassaHareketleriniYukle();
            await MaliyyeXulasesiniYukle();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Forma yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    /// <summary>
    /// Enum ComboBox-larını başlatır
    /// </summary>
    private void InitializeEnums()
    {
        cmbXercNovu.DataSource = Enum.GetValues(typeof(XercNovu));
        cmbXercNovu.SelectedIndex = 0;
    }

    #region Xərc İdarəetməsi

    /// <summary>
    /// Xərcləri DataGridView-ə yüklə
    /// </summary>
    private async Task XercleriYukle()
    {
        try
        {
            EmeliyyatNeticesi<List<XercDto>> netice = await _maliyyeManager.ButunXercleriDtoFormatindaGetirAsync();
            if (netice.UgurluDur && netice.Data != null)
            {
                FormatXerclerGrid();
                dgvXercler.DataSource = new System.ComponentModel.BindingList<XercDto>(netice.Data.ToList());
            }
            else
            {
                MessageBox.Show($"Xərclər yüklənərkən xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərclər Siyahısı");
        }
    }

    /// <summary>
    /// Xərclər DataGridView-ni formatla
    /// </summary>
    private void FormatXerclerGrid()
    {
        if (dgvXercler.Columns.Count > 0) return;

        dgvXercler.AutoGenerateColumns = false;

        dgvXercler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
        dgvXercler.Columns.Add(new DataGridViewTextBoxColumn { Name = "IstifadeciId", DataPropertyName = "IstifadeciId", Visible = false });
        
        dgvXercler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Novu", DataPropertyName = "Novu", HeaderText = "Növ" });
        dgvXercler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Ad", DataPropertyName = "Ad", HeaderText = "Ad" });
        
        var sumCol = new DataGridViewTextBoxColumn { Name = "Mebleg", DataPropertyName = "Mebleg", HeaderText = "Məbləğ" };
        sumCol.DefaultCellStyle.Format = "N2";
        dgvXercler.Columns.Add(sumCol);
        
        var dateCol = new DataGridViewTextBoxColumn { Name = "Tarix", DataPropertyName = "Tarix", HeaderText = "Tarix" };
        dateCol.DefaultCellStyle.Format = "dd.MM.yyyy";
        dgvXercler.Columns.Add(dateCol);
        
        dgvXercler.Columns.Add(new DataGridViewTextBoxColumn { Name = "SenedNomresi", DataPropertyName = "SenedNomresi", HeaderText = "Sənəd №" });
        dgvXercler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qeyd", DataPropertyName = "Qeyd", HeaderText = "Qeyd" });
        dgvXercler.Columns.Add(new DataGridViewTextBoxColumn { Name = "IstifadeciAdi", DataPropertyName = "IstifadeciAdi", HeaderText = "İstifadəçi" });

        dgvXercler.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    /// <summary>
    /// Xərc yarat düyməsi
    /// </summary>
    private void btnXercYarat_Click(object sender, EventArgs e)
    {
        if (!ValidateXercForm())
        {
            return;
        }

        _ = XercYaratAsync();
    }

    private async Task XercYaratAsync()
    {
        try
        {
            EmeliyyatNeticesi<int> netice = await _maliyyeManager.XercYaratAsync(
                (XercNovu)cmbXercNovu.SelectedItem,
                txtXercAd.Text,
                numXercMebleg.Value,
                dtpXercTarix.Value,
                txtSenedNomresi.Text,
                txtXercQeyd.Text,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Xərc uğurla yaradıldı!");
                await XercleriYukle();
                await KassaHareketleriniYukle();
                await MaliyyeXulasesiniYukle();
                XercFormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərc Yaratma");
        }
    }

    /// <summary>
    /// Xərc yenilə düyməsi
    /// </summary>
    private void btnXercYenile_Click(object sender, EventArgs e)
    {
        if (_seciliXercId == 0)
        {
            MessageBox.Show("Zəhmət olmasa yeniləmək üçün xərc seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (!ValidateXercForm())
        {
            return;
        }

        _ = XercYenileAsync();
    }

    private async Task XercYenileAsync()
    {
        try
        {
            EmeliyyatNeticesi netice = await _maliyyeManager.XercYenileAsync(
                _seciliXercId,
                (XercNovu)cmbXercNovu.SelectedItem,
                txtXercAd.Text,
                numXercMebleg.Value,
                dtpXercTarix.Value,
                txtSenedNomresi.Text,
                txtXercQeyd.Text,
                AktivSessiya.AktivIstifadeci?.Id);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Xərc uğurla yeniləndi!");
                await XercleriYukle();
                await KassaHareketleriniYukle();
                await MaliyyeXulasesiniYukle();
                XercFormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərc Yeniləmə");
        }
    }

    /// <summary>
    /// Xərc sil düyməsi
    /// </summary>
    private void btnXercSil_Click(object sender, EventArgs e)
    {
        if (_seciliXercId == 0)
        {
            MessageBox.Show("Zəhmət olmasa silmək üçün xərc seçin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        DialogResult tesdiq = MessageBox.Show(
            "Bu xərci silmək istəyirsiniz?",
            "Təsdiq",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (tesdiq != DialogResult.Yes)
        {
            return;
        }

        _ = XercSilAsync();
    }

    private async Task XercSilAsync()
    {
        try
        {
            EmeliyyatNeticesi netice = await _maliyyeManager.XercSilAsync(_seciliXercId);

            if (netice.UgurluDur)
            {
                XetaGostergeci.UgurluMesajGoster("Xərc uğurla silindi!");
                await XercleriYukle();
                await KassaHareketleriniYukle();
                await MaliyyeXulasesiniYukle();
                XercFormuTemizle();
            }
            else
            {
                MessageBox.Show($"Xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərc Silmə");
        }
    }

    /// <summary>
    /// Xərclər cədvəlində sətir seçildikdə
    /// </summary>
    private void dgvXercler_SelectionChanged(object sender, EventArgs e)
    {
        if (dgvXercler.SelectedRows.Count == 0)
        {
            _seciliXercId = 0;
            return;
        }

        try
        {
            DataGridViewRow seciliXerc = dgvXercler.SelectedRows[0];
            _seciliXercId = (int)seciliXerc.Cells["Id"].Value;

            cmbXercNovu.SelectedItem = seciliXerc.Cells["Novu"].Value;
            txtXercAd.Text = seciliXerc.Cells["Ad"].Value?.ToString() ?? string.Empty;
            numXercMebleg.Value = (decimal)seciliXerc.Cells["Mebleg"].Value;
            dtpXercTarix.Value = (DateTime)seciliXerc.Cells["Tarix"].Value;
            txtSenedNomresi.Text = seciliXerc.Cells["SenedNomresi"].Value?.ToString() ?? string.Empty;
            txtXercQeyd.Text = seciliXerc.Cells["Qeyd"].Value?.ToString() ?? string.Empty;
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Xərc Seçimi");
        }
    }

    /// <summary>
    /// Xərc formu təmizlə düyməsi
    /// </summary>
    private void btnXercTemizle_Click(object sender, EventArgs e)
    {
        XercFormuTemizle();
    }

    /// <summary>
    /// Xərc formunu təmizlə
    /// </summary>
    private void XercFormuTemizle()
    {
        _seciliXercId = 0;
        cmbXercNovu.SelectedIndex = 0;
        txtXercAd.Clear();
        numXercMebleg.Value = 0;
        dtpXercTarix.Value = DateTime.Now;
        txtSenedNomresi.Clear();
        txtXercQeyd.Clear();
    }

    /// <summary>
    /// Xərc formu validasiyası
    /// </summary>
    private bool ValidateXercForm()
    {
        if (string.IsNullOrWhiteSpace(txtXercAd.Text))
        {
            MessageBox.Show("Xərc adı daxil edin!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtXercAd.Focus();
            return false;
        }

        if (numXercMebleg.Value <= 0)
        {
            MessageBox.Show("Xərc məbləği 0-dan böyük olmalıdır!", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            numXercMebleg.Focus();
            return false;
        }

        return true;
    }

    #endregion

    #region Kassa Hərəkətləri

    /// <summary>
    /// Kassa hərəkətlərini DataGridView-ə yüklə
    /// </summary>
    private async Task KassaHareketleriniYukle()
    {
        try
        {
            EmeliyyatNeticesi<List<KassaHareketi>> netice = await _maliyyeManager.KassaHareketleriniGetirAsync(
                dtpBaslangic.Value.Date,
                dtpBitis.Value.Date);

            if (netice.UgurluDur && netice.Data != null)
            {
                FormatKassaHareketleriGrid();
                dgvKassaHareketleri.DataSource = new System.ComponentModel.BindingList<KassaHareketi>(netice.Data.ToList());
            }
            else
            {
                MessageBox.Show($"Kassa hərəkətləri yüklənərkən xəta: {netice.Mesaj}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Kassa Hərəkətləri");
        }
    }

    /// <summary>
    /// Kassa hərəkətləri DataGridView-ni formatla
    /// </summary>
    private void FormatKassaHareketleriGrid()
    {
        if (dgvKassaHareketleri.Columns.Count > 0) return;

        dgvKassaHareketleri.AutoGenerateColumns = false;
        
        dgvKassaHareketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
        dgvKassaHareketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmeliyyatId", DataPropertyName = "EmeliyyatId", Visible = false });
        dgvKassaHareketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "IstifadeciId", DataPropertyName = "IstifadeciId", Visible = false });
        
        dgvKassaHareketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "HareketNovu", DataPropertyName = "HareketNovu", HeaderText = "Hərəkət Növü" });
        dgvKassaHareketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "EmeliyyatNovu", DataPropertyName = "EmeliyyatNovu", HeaderText = "Əməliyyat" });
        dgvKassaHareketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "OdenisMetodu", DataPropertyName = "OdenisMetodu", HeaderText = "Ödəniş üsulu" });
        
        var sumCol = new DataGridViewTextBoxColumn { Name = "Mebleg", DataPropertyName = "Mebleg", HeaderText = "Məbləğ" };
        sumCol.DefaultCellStyle.Format = "N2";
        dgvKassaHareketleri.Columns.Add(sumCol);
        
        var dateCol = new DataGridViewTextBoxColumn { Name = "Tarix", DataPropertyName = "Tarix", HeaderText = "Tarix" };
        dateCol.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
        dgvKassaHareketleri.Columns.Add(dateCol);
        
        dgvKassaHareketleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qeyd", DataPropertyName = "Qeyd", HeaderText = "Qeyd" });

        // Hərəkət növünə görə rəng
        foreach (DataGridViewRow row in dgvKassaHareketleri.Rows)
        {
            if (row.Cells["HareketNovu"].Value != null)
            {
                KassaHareketiNovu hareketNovu = (KassaHareketiNovu)row.Cells["HareketNovu"].Value;
                row.DefaultCellStyle.ForeColor = hareketNovu == KassaHareketiNovu.Daxilolma ? Color.Green : Color.Red;
            }
        }

        dgvKassaHareketleri.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
    }

    /// <summary>
    /// Kassa hərəkətlərini filtrələ düyməsi
    /// </summary>
    private void btnFiltrele_Click(object sender, EventArgs e)
    {
        _ = KassaHareketleriniYukle();
    }

    #endregion

    #region Maliyyə Xülasəsi

    /// <summary>
    /// Maliyyə xülasəsini hesabla və göstər
    /// </summary>
    private async Task MaliyyeXulasesiniYukle()
    {
        try
        {
            DateTime baslangic = dtpXesabatBaslangic.Value.Date;
            DateTime bitis = dtpXesabatBitis.Value.Date;
            if (baslangic > bitis)
            {
                MessageBox.Show("Başlanğıc tarixi bitiş tarixindən sonra ola bilməz.", "Tarix aralığı",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            EmeliyyatNeticesi<SatisKassaXulaseDto> satisNetice =
                await _hesabatManager.SatisKassaXulasesiGetirAsync(baslangic, bitis);
            if (!satisNetice.UgurluDur || satisNetice.Data == null)
            {
                MessageBox.Show(satisNetice.Mesaj, "Satış xülasəsi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SatisKassaXulaseDto satis = satisNetice.Data;
            _lblSatilanMiqdar.Text = $"Satılan miqdar: {satis.SatilanMiqdar:N0}";
            _lblSatisDeyeri.Text = $"Satış dəyəri (xalis): {satis.SatisDeyeri:N2} AZN";
            _lblAlisDeyeri.Text = satis.MayaDeyeriTamdir
                ? $"Satılan malların alış dəyəri: {satis.AlisDeyeri:N2} AZN"
                : "Alış dəyəri: bəzi satışlarda məlum deyil";
            _lblBrutMenfeet.Text = satis.MayaDeyeriTamdir
                ? $"Brüt mənfəət: {satis.UmumiQazanc:N2} AZN"
                : "Brüt mənfəət: hesablana bilmir";
            _lblNagdSatis.Text = $"Nağd satış (xalis): {satis.NagdSatis:N2} AZN";
            _lblKartSatis.Text = $"Terminal satışı (xalis): {satis.KartSatis:N2} AZN";
            _lblNisyeSatis.Text = $"Nisyə satış (xalis): {satis.NisyeSatis:N2} AZN";
            _lblQaytarma.Text = $"Qaytarma məbləği: {satis.QaytarmaMeblegi:N2} AZN";

            // Nağd kassa hərəkətlərini hesabla; kart ödənişi fiziki kassaya daxil deyil.
            EmeliyyatNeticesi<List<KassaHareketi>> kassaHareketleriNetice = await _maliyyeManager.KassaHareketleriniGetirAsync(baslangic, bitis);
            if (kassaHareketleriNetice.UgurluDur && kassaHareketleriNetice.Data != null)
            {
                decimal borcOdenisi = kassaHareketleriNetice.Data
                    .Where(k => k.EmeliyyatNovu == EmeliyyatNovu.Odenis && k.HareketNovu == KassaHareketiNovu.Daxilolma)
                    .Sum(k => k.Mebleg);
                _lblBorcOdenisi.Text = $"Borc ödənişi (nağd + kart): {borcOdenisi:N2} AZN";
                decimal kartBorcOdenisi = kassaHareketleriNetice.Data
                    .Where(k => k.EmeliyyatNovu == EmeliyyatNovu.Odenis &&
                                k.HareketNovu == KassaHareketiNovu.Daxilolma &&
                                k.OdenisMetodu == OdenisMetodu.Kart)
                    .Sum(k => k.Mebleg);
                _lblTerminalCemi.Text = $"Terminal daxilolması (xalis): {satis.KartSatis + kartBorcOdenisi:N2} AZN";
                decimal nagdBorcOdenisi = kassaHareketleriNetice.Data
                    .Where(k => k.EmeliyyatNovu == EmeliyyatNovu.Odenis &&
                                k.HareketNovu == KassaHareketiNovu.Daxilolma &&
                                k.OdenisMetodu == OdenisMetodu.Nağd)
                    .Sum(k => k.Mebleg);
                decimal digerNagdGelir = kassaHareketleriNetice.Data
                    .Where(k => k.EmeliyyatNovu == EmeliyyatNovu.Gelir && k.NovbeId == null &&
                                k.HareketNovu == KassaHareketiNovu.Daxilolma &&
                                k.OdenisMetodu != OdenisMetodu.Kart)
                    .Sum(k => k.Mebleg);
                // Növbə bağlanarkən yaranan gəlir qeydi eyni nağd satışın ikinci qeydi sayılmır.
                decimal gelirler = satis.NagdSatis + nagdBorcOdenisi + digerNagdGelir;
                // Qaytarma artıq xalis satışdan çıxılıb; onu ikinci dəfə çıxmırıq.
                decimal cixislar = kassaHareketleriNetice.Data
                    .Where(k => k.HareketNovu == KassaHareketiNovu.Cixis &&
                                k.EmeliyyatNovu != EmeliyyatNovu.Qaytarma &&
                                k.OdenisMetodu != OdenisMetodu.Kart)
                    .Sum(k => k.Mebleg);
                lblUmumiGelir.Text = $"Nağd satış və daxilolma: {gelirler:N2} AZN";
                _lblKassaCixis.Text = $"Digər nağd çıxış: {cixislar:N2} AZN";
                decimal axin = gelirler - cixislar;
                lblMenfeetZerere.Text = axin >= 0
                    ? $"Dövr üzrə kassa axını: +{axin:N2} AZN"
                    : $"Dövr üzrə kassa axını: -{Math.Abs(axin):N2} AZN";
                lblMenfeetZerere.ForeColor = axin >= 0 ? Color.Green : Color.Red;
            }

            // Xərcləri hesabla
            EmeliyyatNeticesi<decimal> xercCemiNetice = await _maliyyeManager.XercCeminiHesablaAsync(baslangic, bitis);
            if (xercCemiNetice.UgurluDur)
            {
                lblUmumiXerc.Text = $"Qeydiyyat xərcləri: {xercCemiNetice.Data:N2} AZN";
            }

            // Cari kassa balansını hesabla (bütün tarixlər üçün)
            EmeliyyatNeticesi<List<KassaHareketi>> butunHareketlerNetice = await _maliyyeManager.KassaHareketleriniGetirAsync();
            if (butunHareketlerNetice.UgurluDur && butunHareketlerNetice.Data != null)
            {
                decimal gelirlerCem = butunHareketlerNetice.Data
                    .Where(k => k.HareketNovu == KassaHareketiNovu.Daxilolma && k.OdenisMetodu != OdenisMetodu.Kart)
                    .Sum(k => k.Mebleg);

                decimal xerclerCem = butunHareketlerNetice.Data
                    .Where(k => k.HareketNovu == KassaHareketiNovu.Cixis && k.OdenisMetodu != OdenisMetodu.Kart)
                    .Sum(k => k.Mebleg);

                decimal balans = gelirlerCem - xerclerCem;
                lblCariBalans.Text = $"Jurnal üzrə nağd qalıq: {balans:N2} AZN";
                lblCariBalans.ForeColor = balans >= 0
                    ? System.Drawing.Color.Green
                    : System.Drawing.Color.Red;
            }
        }
        catch (Exception ex)
        {
            XetaGostergeci.UmumiXetaGoster(ex, "Maliyyə Xülasəsi");
        }
    }

    /// <summary>
    /// Maliyyə hesabatı göstər düyməsi
    /// </summary>
    private void btnHesabatGoster_Click(object sender, EventArgs e)
    {
        _ = MaliyyeXulasesiniYukle();
    }

    #endregion

    /// <summary>
    /// Yenilə düyməsi - bütün məlumatları yenidən yüklə
    /// </summary>
    private void btnYenile_Click(object sender, EventArgs e)
    {
        _ = YenileAsync();
    }

    private async Task YenileAsync()
    {
        try
        {
            await XercleriYukle();
            await KassaHareketleriniYukle();
            await MaliyyeXulasesiniYukle();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Məlumatlar yenilənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
