using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using AzAgroPOS.Entities.Constants;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcDetailsForm : Form
    {
        private readonly int _debtId;
        private readonly Istifadeci _currentUser;
        private readonly BorcService _borcService;
        private MusteriBorc _debt;

        public BorcDetailsForm(int debtId, Istifadeci currentUser)
        {
            try
            {
                InitializeComponent();
                
                if (debtId <= 0)
                    throw new ArgumentException("Yanlış borc ID-si");
                if (currentUser == null)
                    throw new ArgumentNullException(nameof(currentUser), "İstifadəçi məlumatı tələb olunur");
                
                _debtId = debtId;
                _currentUser = currentUser;
                _borcService = new BorcService();
                
                SetupForm();
                LoadDebtDetails();
                
                // Load payment history asynchronously to improve form loading speed
                this.Load += (s, e) => LoadPaymentHistory();
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleError(ex, "Form açılarkən xəta baş verdi.");
                this.Close();
            }
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            dgvPayments.EnableHeadersVisualStyles = false;
            dgvPayments.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(52, 73, 94);
            dgvPayments.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPayments.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            
            dgvPayments.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgvPayments.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvPayments.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 249, 250);
            
            dgvPayments.BorderStyle = BorderStyle.None;
            dgvPayments.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPayments.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayments.MultiSelect = false;
            dgvPayments.AllowUserToAddRows = false;
            dgvPayments.AllowUserToDeleteRows = false;
            dgvPayments.ReadOnly = true;
        }

        private void LoadDebtDetails()
        {
            try
            {
                _debt = _borcService.GetDebtById(_debtId);
                if (_debt == null)
                {
                    ErrorHandlingService.ShowValidationError("Borc məlumatı tapılmadı.");
                    this.Close();
                    return;
                }

                // Load basic debt information with null checks
                lblBorcNomresi.Text = _debt.BorcNomresiFormatli ?? $"BORC-{_debt.Id:000000}";
                lblMusteriAdi.Text = _debt.Musteri?.Ad ?? "Naməlum";
                lblBorcTipi.Text = _debt.BorcTipi ?? "Naməlum";
                lblBorcMeblegi.Text = _debt.BorcMeblegi.ToString("C");
                lblOdenilmisMebleg.Text = _debt.OdenilmisMebleg.ToString("C");
                lblQalanBorc.Text = _debt.QalanBorc.ToString("C");
                lblFaizMeblegi.Text = _debt.FaizMeblegi.ToString("C");
                lblUmumiBorc.Text = _debt.UmumiBorc.ToString("C");
                lblBorcTarixi.Text = _debt.BorcTarixi.ToString("dd.MM.yyyy");
                lblSonOdemeTarixi.Text = _debt.SonOdemeTarixi.ToString("dd.MM.yyyy");
                lblFaizDerecesi.Text = _debt.FaizDerecesi.ToString("F2") + "%";
                lblAciklama.Text = string.IsNullOrEmpty(_debt.Aciklama) ? "Açıqlama yoxdur" : _debt.Aciklama;
                lblYaradan.Text = _debt.YaradanIstifadeci?.Ad ?? "Naməlum";
                lblYaradilmaTarixi.Text = _debt.YaradilmaTarixi.ToString("dd.MM.yyyy HH:mm");
                
                // Calculate days overdue
                var daysOverdue = (DateTime.Now - _debt.SonOdemeTarixi).Days;
                if (daysOverdue > 0 && _debt.QalanBorc > 0)
                {
                    lblGecikmeGunleri.Text = daysOverdue.ToString() + " gün";
                    lblGecikmeGunleri.ForeColor = Color.FromArgb(231, 76, 60);
                }
                else
                {
                    lblGecikmeGunleri.Text = "Gecikməyib";
                    lblGecikmeGunleri.ForeColor = Color.FromArgb(46, 204, 113);
                }

                // Set status color
                if (_debt.QalanBorc <= 0)
                {
                    lblStatus.Text = "Tamamlanıb";
                    lblStatus.ForeColor = Color.FromArgb(46, 204, 113);
                }
                else if (daysOverdue > 0)
                {
                    lblStatus.Text = "Gecikib";
                    lblStatus.ForeColor = Color.FromArgb(231, 76, 60);
                }
                else
                {
                    lblStatus.Text = "Aktiv";
                    lblStatus.ForeColor = Color.FromArgb(241, 196, 15);
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleError(ex, "Borc məlumatları yüklənərkən xəta baş verdi.");
            }
        }

        private void LoadPaymentHistory()
        {
            try
            {
                var paymentHistory = _borcService.GetPaymentHistory(_debtId);
                if (paymentHistory == null)
                {
                    dgvPayments.DataSource = null;
                    lblTotalPayments.Text = "0";
                    return;
                }

                var payments = paymentHistory.Select(p => new
                {
                    p.Id,
                    OdenisTarixi = p.OdenisTarixi.ToString("dd.MM.yyyy"),
                    OdenisMeblegi = p.OdenisMeblegi.ToString("C"),
                    OdenisTipi = p.OdenisTipi ?? "Naməlum",
                    FaizOdenisi = p.FaizOdenisi.ToString("C"),
                    EsasBorcOdenisi = p.EsasBorcOdenisi.ToString("C"),
                    KomissiyaMeblegi = p.KomissiyaMeblegi.ToString("C"),
                    Aciklama = string.IsNullOrEmpty(p.Aciklama) ? "Açıqlama yoxdur" : p.Aciklama,
                    QebulEden = p.QebulEdenIstifadeci?.Ad ?? "Naməlum"
                }).ToList();

                dgvPayments.DataSource = payments;
                
                if (dgvPayments.Columns.Count > 0)
                {
                    dgvPayments.Columns["Id"].Visible = false;
                    dgvPayments.Columns["OdenisTarixi"].HeaderText = "Ödəniş Tarixi";
                    dgvPayments.Columns["OdenisMeblegi"].HeaderText = "Məbləğ";
                    dgvPayments.Columns["OdenisTipi"].HeaderText = "Tip";
                    dgvPayments.Columns["FaizOdenisi"].HeaderText = "Faiz";
                    dgvPayments.Columns["EsasBorcOdenisi"].HeaderText = "Əsas Borc";
                    dgvPayments.Columns["KomissiyaMeblegi"].HeaderText = "Komissiya";
                    dgvPayments.Columns["Aciklama"].HeaderText = "Açıqlama";
                    dgvPayments.Columns["QebulEden"].HeaderText = "Qəbul Edən";
                }

                lblTotalPayments.Text = payments.Count.ToString();
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleError(ex, "Ödəniş tarixçəsi yüklənərkən xəta baş verdi.");
            }
        }

        private void btnAddPayment_Click(object sender, EventArgs e)
        {
            try
            {
                if (_debt == null)
                {
                    ErrorHandlingService.ShowValidationError("Borc məlumatı yüklənməyib.");
                    return;
                }

                if (_debt.QalanBorc <= 0)
                {
                    ErrorHandlingService.ShowValidationError("Bu borc artıq tam ödənilib.");
                    return;
                }

                var paymentForm = new BorcPaymentForm(_debtId, _currentUser);
                if (paymentForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDebtDetails();
                    LoadPaymentHistory();
                    ErrorHandlingService.ShowSuccess("Ödəniş uğurla əlavə edildi.");
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleError(ex, "Ödəniş əlavə edilərkən xəta baş verdi.");
            }
        }

        private void btnEditDebt_Click(object sender, EventArgs e)
        {
            try
            {
                if (_currentUser.Role != SystemConstants.Roles.Administrator && _currentUser.Role != SystemConstants.Roles.Manager)
                {
                    ErrorHandlingService.ShowValidationError("Bu əməliyyat üçün icazəniz yoxdur.");
                    return;
                }

                if (_debt == null)
                {
                    ErrorHandlingService.ShowValidationError("Borc məlumatı yüklənməyib.");
                    return;
                }

                var editForm = new BorcEditForm(_debtId, _currentUser);
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    LoadDebtDetails();
                    ErrorHandlingService.ShowSuccess("Borc məlumatları uğurla yeniləndi.");
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleError(ex, "Borc düzəldilməsi zamanı xəta baş verdi.");
            }
        }

        private void btnPrintReport_Click(object sender, EventArgs e)
        {
            try
            {
                // Generate and print debt report
                MessageBox.Show("Hesabat çap funksiyası tezliklə əlavə ediləcək.", "Məlumat", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleError(ex, "Hesabat yaradılarkən xəta baş verdi.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _borcService?.Dispose();
        //        components?.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}