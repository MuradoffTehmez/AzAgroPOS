using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System.ComponentModel;

namespace AzAgroPOS.Teqdimat
{
    public partial class AlisSenedFormu : BazaForm, IAlisSenedView
    {
        private readonly AlisSenedPresenter _presenter;
        private readonly IServiceProvider _serviceProvider;
        private BindingList<AlisSenedSetiriDto> _senedSetirleri = new();

        public AlisSenedFormu(AlisManager alisManager, MehsulManager mehsulManager, IServiceProvider serviceProvider)
        {
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _presenter = new AlisSenedPresenter(this, alisManager, mehsulManager);

            // Form yüklənəndə Presenter-ə xəbər veririk
            Load += (s, e) =>
            {
                FormYuklendi?.Invoke(this, EventArgs.Empty);
                SetupTooltips();
            };

            StilVerDataGridView(dgvSenetler);
            StilVerDataGridView(dgvSenedSetirleri);
        }

        private void SetupTooltips()
        {
            toolTip1.SetToolTip(txtSenedNomresi, "Sənədin nömrəsini daxil edin");
            toolTip1.SetToolTip(cmbTedarukcu, "Tədarükçü seçin");
            toolTip1.SetToolTip(dtpYaradilmaTarixi, "Sənədin yaradılma tarixini seçin");
            toolTip1.SetToolTip(dtpTehvilTarixi, "Malın təhvil alınma tarixini seçin");
            toolTip1.SetToolTip(txtQeydler, "Əlavə qeydlər və şərhlər daxil edin");
            toolTip1.SetToolTip(btnYeni, "Yeni sənəd yaratmaq üçün formanı təmizləyin");
            toolTip1.SetToolTip(btnYaddaSaxla, "Sənədi yadda saxlayın");
            toolTip1.SetToolTip(btnSil, "Seçilmiş sənədi silin");
        }

        #region IAlisSenedView Implementasiyası

        public int SenedId { get; set; }
        public string SenedNomresi
        {
            get => txtSenedNomresi.Text;
            set => txtSenedNomresi.Text = value;
        }

        public DateTime YaradilmaTarixi
        {
            get => dtpYaradilmaTarixi.Value;
            set => dtpYaradilmaTarixi.Value = value;
        }

        public int TedarukcuId
        {
            get => cmbTedarukcu.SelectedValue is int id ? id : 0;
            set => cmbTedarukcu.SelectedValue = value;
        }

        public DateTime TehvilTarixi
        {
            get => dtpTehvilTarixi.Value;
            set => dtpTehvilTarixi.Value = value;
        }

        public decimal UmumiMebleg
        {
            get => _senedSetirleri.Sum(s => s.CemiMebleg);
            set { } // Hesablanır
        }

        public string? Qeydler
        {
            get => txtQeydler.Text;
            set => txtQeydler.Text = value ?? string.Empty;
        }

        public event EventHandler FormYuklendi;
        public event EventHandler SenedYarat_Istek;
        public event EventHandler SenedYenile_Istek;
        public event EventHandler SenedSil_Istek;
        public event EventHandler FormuTemizle_Istek;

        public void TedarukculeriGoster(List<TedarukcuDto> tedarukculer)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => TedarukculeriGoster(tedarukculer)));
                return;
            }

            cmbTedarukcu.DataSource = tedarukculer;
            cmbTedarukcu.DisplayMember = "Ad";
            cmbTedarukcu.ValueMember = "Id";
        }

        public void SenetleriGoster(List<AlisSenedDto> senetler)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SenetleriGoster(senetler)));
                return;
            }

            dgvSenetler.SelectionChanged -= dgvSenetler_SelectionChanged;

            if (dgvSenetler.Columns.Count == 0)
            {
                dgvSenetler.AutoGenerateColumns = false;
                dgvSenetler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
                dgvSenetler.Columns.Add(new DataGridViewTextBoxColumn { Name = "SenedNomresi", DataPropertyName = "SenedNomresi", HeaderText = "Sənəd №" });
                
                var dateCol = new DataGridViewTextBoxColumn { Name = "YaradilmaTarixi", DataPropertyName = "YaradilmaTarixi", HeaderText = "Yaradılma Tarixi" };
                dateCol.DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvSenetler.Columns.Add(dateCol);
                
                dgvSenetler.Columns.Add(new DataGridViewTextBoxColumn { Name = "TedarukcuAdi", DataPropertyName = "TedarukcuAdi", HeaderText = "Tədarükçü" });
                
                var dateCol2 = new DataGridViewTextBoxColumn { Name = "TehvilTarixi", DataPropertyName = "TehvilTarixi", HeaderText = "Təhvil Tarixi" };
                dateCol2.DefaultCellStyle.Format = "dd.MM.yyyy";
                dgvSenetler.Columns.Add(dateCol2);
                
                var sumCol = new DataGridViewTextBoxColumn { Name = "UmumiMebleg", DataPropertyName = "UmumiMebleg", HeaderText = "Ümumi Məbləğ" };
                sumCol.DefaultCellStyle.Format = "N2";
                sumCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSenetler.Columns.Add(sumCol);
                
                dgvSenetler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Status", DataPropertyName = "Status", HeaderText = "Status" });
                dgvSenetler.Columns.Add(new DataGridViewTextBoxColumn { Name = "Qeydler", DataPropertyName = "Qeydler", HeaderText = "Qeydlər" });
            }

            dgvSenetler.DataSource = new BindingList<AlisSenedDto>(senetler);
            dgvSenetler.SelectionChanged += dgvSenetler_SelectionChanged;
        }

        public void SenedSetirleriniGoster(List<AlisSenedSetiriDto> setirler)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SenedSetirleriniGoster(setirler)));
                return;
            }

            _senedSetirleri = new BindingList<AlisSenedSetiriDto>(setirler);

            if (dgvSenedSetirleri.Columns.Count == 0)
            {
                dgvSenedSetirleri.AutoGenerateColumns = false;
                dgvSenedSetirleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", DataPropertyName = "Id", Visible = false });
                dgvSenedSetirleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "AlisSenedId", DataPropertyName = "AlisSenedId", Visible = false });
                dgvSenedSetirleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulId", DataPropertyName = "MehsulId", Visible = false });
                dgvSenedSetirleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "AlisSifarisSetiriId", DataPropertyName = "AlisSifarisSetiriId", Visible = false });
                dgvSenedSetirleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "AlisSifarisSetiriNomresi", DataPropertyName = "AlisSifarisSetiriNomresi", Visible = false });
                dgvSenedSetirleri.Columns.Add(new DataGridViewTextBoxColumn { Name = "MehsulAdi", DataPropertyName = "MehsulAdi", HeaderText = "Məhsul" });
                
                var qtyCol = new DataGridViewTextBoxColumn { Name = "Miqdar", DataPropertyName = "Miqdar", HeaderText = "Miqdar" };
                qtyCol.DefaultCellStyle.Format = "N2";
                qtyCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSenedSetirleri.Columns.Add(qtyCol);
                
                var priceCol = new DataGridViewTextBoxColumn { Name = "BirVahidQiymet", DataPropertyName = "BirVahidQiymet", HeaderText = "Vahid Qiyməti" };
                priceCol.DefaultCellStyle.Format = "N2";
                priceCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSenedSetirleri.Columns.Add(priceCol);
                
                var sumCol = new DataGridViewTextBoxColumn { Name = "CemiMebleg", DataPropertyName = "CemiMebleg", HeaderText = "Cəmi Məbləğ" };
                sumCol.DefaultCellStyle.Format = "N2";
                sumCol.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvSenedSetirleri.Columns.Add(sumCol);
            }

            dgvSenedSetirleri.DataSource = _senedSetirleri;

            // Ümumi məbləği göstər
            lblUmumiMebleg.Text = $"Ümumi: {UmumiMebleg:N2} AZN";
        }

        public void MehsullariGoster(List<MehsulDto> mehsullar)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => MehsullariGoster(mehsullar)));
                return;
            }

            cmbMehsul.DataSource = mehsullar;
            cmbMehsul.DisplayMember = "Ad";
            cmbMehsul.ValueMember = "Id";
        }

        public void MesajGoster(string mesaj, bool xetadir = false)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => MesajGoster(mesaj, xetadir)));
                return;
            }

            MessageBox.Show(mesaj,
                xetadir ? "Xəta" : "Məlumat",
                MessageBoxButtons.OK,
                xetadir ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public void FormuTemizle()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(FormuTemizle));
                return;
            }

            SenedId = 0;
            txtSenedNomresi.Clear();
            dtpYaradilmaTarixi.Value = DateTime.Now;
            dtpTehvilTarixi.Value = DateTime.Now;
            txtQeydler.Clear();
            if (cmbTedarukcu.Items.Count > 0)
            {
                cmbTedarukcu.SelectedIndex = 0;
            }

            _senedSetirleri.Clear();

            txtSenedNomresi.Focus();
        }

        #endregion

        #region Event Handlers

        private void dgvSenetler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSenetler.CurrentRow?.DataBoundItem is AlisSenedDto sened)
            {
                SenedId = sened.Id;
                SenedNomresi = sened.SenedNomresi;
                YaradilmaTarixi = sened.YaradilmaTarixi;
                TedarukcuId = sened.TedarukcuId;
                TehvilTarixi = sened.TehvilTarixi;
                Qeydler = sened.Qeydler;
                SenedSetirleriniGoster(sened.SenedSetirleri);
            }
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            FormuTemizle_Istek?.Invoke(this, EventArgs.Empty);
        }

        private void btnYaddaSaxla_Click(object sender, EventArgs e)
        {
            // Validasiya
            if (string.IsNullOrWhiteSpace(SenedNomresi))
            {
                MesajGoster("Sənəd nömrəsini daxil edin!", true);
                txtSenedNomresi.Focus();
                return;
            }

            if (TedarukcuId <= 0)
            {
                MesajGoster("Tədarükçü seçin!", true);
                cmbTedarukcu.Focus();
                return;
            }

            if (_senedSetirleri.Count == 0)
            {
                MesajGoster("Ən azı bir məhsul əlavə edin!", true);
                return;
            }

            // Sənəd yarat və ya yenilə
            if (SenedId > 0)
            {
                SenedYenile_Istek?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                SenedYarat_Istek?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (SenedId <= 0)
            {
                MesajGoster("Silmək üçün sənəd seçin!", true);
                return;
            }

            DialogResult result = MessageBox.Show(
                "Seçilmiş sənədi silmək istədiyinizdən əminsiniz?",
                "Təsdiq",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                SenedSil_Istek?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnMehsulElaveEt_Click(object sender, EventArgs e)
        {
            if (cmbMehsul.SelectedValue is not int mehsulId || mehsulId <= 0)
            {
                MesajGoster("Məhsul seçin!", true);
                return;
            }

            if (!decimal.TryParse(txtMiqdar.Text, out decimal miqdar) || miqdar <= 0)
            {
                MesajGoster("Düzgün miqdar daxil edin!", true);
                txtMiqdar.Focus();
                return;
            }

            if (!decimal.TryParse(txtQiymet.Text, out decimal qiymet) || qiymet <= 0)
            {
                MesajGoster("Düzgün qiymət daxil edin!", true);
                txtQiymet.Focus();
                return;
            }

            MehsulDto? mehsulDto = cmbMehsul.SelectedItem as MehsulDto;
            AlisSenedSetiriDto setir = new()
            {
                MehsulId = mehsulId,
                MehsulAdi = mehsulDto?.Ad ?? "",
                Miqdar = miqdar,
                BirVahidQiymet = qiymet,
                CemiMebleg = miqdar * qiymet
            };

            _senedSetirleri.Add(setir);

            // Təmizlə
            txtMiqdar.Clear();
            txtQiymet.Clear();
            cmbMehsul.Focus();
        }

        private void btnSetirSil_Click(object sender, EventArgs e)
        {
            if (dgvSenedSetirleri.CurrentRow?.DataBoundItem is AlisSenedSetiriDto setir)
            {
                _senedSetirleri.Remove(setir);
            }
        }

        private void txtAxtaris_TextChanged(object sender, EventArgs e)
        {
            // Axtarış funksionallığı əlavə edilə bilər
        }

        #endregion
    }
}
