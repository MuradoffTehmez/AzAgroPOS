using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class MusteriIdareetmeFormu : BazaForm, IMusteriView
    {
        private readonly MusteriPresenter _presenter;
        public int SecilenMusteriId { get; private set; } = 0;

        public MusteriIdareetmeFormu(MusteriManager musteriManager)
        {
            InitializeComponent();
            _presenter = new MusteriPresenter(this, musteriManager);
            // Form yüklənəndə Presenter-ə xəbər veririk
            this.Load += (s, e) => FormYuklendi?.Invoke(this, EventArgs.Empty);
            StilVerDataGridView(dgvMusteriler);
        }

        #region IMusteriView Implementasiyası

        public int SecilmisMusteriId => dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri ? musteri.Id : 0;

        public string TamAd { get => txtTamAd.Text; set => txtTamAd.Text = value; }
        public string Telefon { get => txtTelefon.Text; set => txtTelefon.Text = value; }
        public string Unvan { get => txtUnvan.Text; set => txtUnvan.Text = value; }
        public string KreditLimiti { get => txtKreditLimiti.Text; set => txtKreditLimiti.Text = value; }
        public string AxtarisMetni => txtAxtaris.Text;

        public event EventHandler FormYuklendi;
        public event EventHandler MusteriSecildi;
        public event EventHandler YeniMusteriIstek;
        public event EventHandler YaddaSaxlaIstek;
        public event EventHandler SilIstek;
        public event EventHandler AxtarIstek;

        public void MusterileriGoster(List<MusteriDto> musteriler)
        {
            // SelectionChanged hadisəsini müvəqqəti dayandırırıq ki, datanı yükləyəndə təkrar-təkrar işə düşməsin
            dgvMusteriler.SelectionChanged -= dgvMusteriler_SelectionChanged;
            dgvMusteriler.DataSource = musteriler;
            if (dgvMusteriler.Columns.Count > 0)
            {
                dgvMusteriler.Columns["Id"].Visible = false;
                dgvMusteriler.Columns["Unvan"].Visible = false;
                dgvMusteriler.Columns["TamAd"].HeaderText = "Tam Ad";
                dgvMusteriler.Columns["TelefonNomresi"].HeaderText = "Telefon";
                dgvMusteriler.Columns["UmumiBorc"].HeaderText = "Cari Borc";
                dgvMusteriler.Columns["KreditLimiti"].HeaderText = "Kredit Limiti";

                // Format currency columns
                dgvMusteriler.Columns["UmumiBorc"].DefaultCellStyle.Format = "N2";
                dgvMusteriler.Columns["KreditLimiti"].DefaultCellStyle.Format = "N2";
                
                // Align numeric columns to the right
                dgvMusteriler.Columns["UmumiBorc"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvMusteriler.Columns["KreditLimiti"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                
                // Allow sorting
                dgvMusteriler.Columns["TamAd"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvMusteriler.Columns["TelefonNomresi"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvMusteriler.Columns["UmumiBorc"].SortMode = DataGridViewColumnSortMode.Automatic;
                dgvMusteriler.Columns["KreditLimiti"].SortMode = DataGridViewColumnSortMode.Automatic;
            }
            dgvMusteriler.SelectionChanged += dgvMusteriler_SelectionChanged;
        }

        public void FormuTemizle()
        {
            txtTamAd.Clear();
            txtTelefon.Clear();
            txtUnvan.Clear();
            txtKreditLimiti.Text = "0";
            dgvMusteriler.ClearSelection();
            txtTamAd.Focus();
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

        #endregion

        #region Hadisə Ötürücüləri

        private void dgvMusteriler_SelectionChanged(object sender, EventArgs e)
        {
            MusteriSecildi?.Invoke(sender, e);
            
            // Update selected customer ID when selection changes
            if (dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri)
            {
                SecilenMusteriId = musteri.Id;
            }
            else
            {
                SecilenMusteriId = 0;
            }
        }
        
        private void btnYeni_Click(object sender, EventArgs e) => YeniMusteriIstek?.Invoke(sender, e);
        private void btnYaddaSaxla_Click(object sender, EventArgs e) => YaddaSaxlaIstek?.Invoke(sender, e);
        private void btnSil_Click(object sender, EventArgs e) => SilIstek?.Invoke(sender, e);
        private void txtAxtaris_TextChanged(object sender, EventArgs e) => AxtarIstek?.Invoke(sender, e);

        // Handle double-click to select customer and close form
        private void dgvMusteriler_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvMusteriler.CurrentRow?.DataBoundItem is MusteriDto musteri)
            {
                SecilenMusteriId = musteri.Id;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        #endregion
    }
}