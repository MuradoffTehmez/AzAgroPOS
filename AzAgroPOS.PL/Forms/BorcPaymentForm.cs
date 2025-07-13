using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL;
using AzAgroPOS.Entities.Domain;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class BorcPaymentForm : Form
    {
        private readonly int _debtId;
        private readonly Istifadeci _currentUser;
        private readonly AzAgroDbContext _context;
        private readonly BorcService _borcService;
        private MusteriBorc _debt;

        public BorcPaymentForm(int debtId, Istifadeci currentUser)
        {
            InitializeComponent();
            _debtId = debtId;
            _currentUser = currentUser;
            _context = new AzAgroDbContext();
            _borcService = new BorcService(_context, new AuditLogService());
            SetupForm();
            LoadDebtInfo();
        }

        private void SetupForm()
        {
            this.BackColor = Color.FromArgb(236, 240, 241);
            dtpOdenisTarixi.Value = DateTime.Now;
            
            // Setup payment types
            cmbOdenisTipi.Items.AddRange(new object[] { "Nəğd", "Kart", "Bank Köçürməsi", "Çek" });
            cmbOdenisTipi.SelectedIndex = 0;
        }

        private void LoadDebtInfo()
        {
            try
            {
                _debt = _borcService.GetDebtById(_debtId);
                if (_debt == null)
                {
                    MessageBox.Show("Borc məlumatı tapılmadı.", "Xəta", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Display debt information
                lblBorcNomresi.Text = _debt.BorcNomresiFormatli;
                lblMusteriAdi.Text = _debt.Musteri?.Ad ?? "Naməlum";
                lblBorcMeblegi.Text = _debt.BorcMeblegi.ToString("C");
                lblOdenilmisMebleg.Text = _debt.OdenilmisMebleg.ToString("C");
                lblQalanBorc.Text = _debt.QalanBorc.ToString("C");
                lblFaizMeblegi.Text = _debt.FaizMeblegi.ToString("C");
                lblUmumiBorc.Text = _debt.UmumiBorc.ToString("C");

                // Set maximum payment amount
                numOdenisMeblegi.Maximum = _debt.UmumiBorc;
                numOdenisMeblegi.Value = Math.Min(1000, _debt.QalanBorc);

                // Calculate interest and principal payment
                CalculatePaymentBreakdown();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Borc məlumatları yüklənərkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CalculatePaymentBreakdown()
        {
            var paymentAmount = numOdenisMeblegi.Value;
            var interestAmount = Math.Min(paymentAmount, _debt.FaizMeblegi);
            var principalAmount = paymentAmount - interestAmount;

            lblFaizOdenisi.Text = interestAmount.ToString("C");
            lblEsasBorcOdenisi.Text = principalAmount.ToString("C");
        }

        private void numOdenisMeblegi_ValueChanged(object sender, EventArgs e)
        {
            CalculatePaymentBreakdown();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                var borcOdenis = new BorcOdenis
                {
                    MusteriBorcId = _debtId,
                    OdenisTarixi = dtpOdenisTarixi.Value,
                    OdenisMeblegi = numOdenisMeblegi.Value,
                    OdenisTipi = cmbOdenisTipi.SelectedItem.ToString(),
                    OdenisDetali = txtOdenisDetali.Text,
                    KomissiyaMeblegi = numKomissiya.Value,
                    FaizOdenisi = decimal.Parse(lblFaizOdenisi.Text.Replace("₼", "").Replace(",", "")),
                    EsasBorcOdenisi = decimal.Parse(lblEsasBorcOdenisi.Text.Replace("₼", "").Replace(",", "")),
                    Aciklama = txtAciklama.Text,
                    QebulEdenIstifadeciId = _currentUser.Id
                };

                _borcService.AddPayment(borcOdenis);
                
                MessageBox.Show("Ödəniş uğurla qeydə alındı.", "Uğur", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ödəniş qeydə alınarkən xəta: {ex.Message}", "Xəta", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (numOdenisMeblegi.Value <= 0)
            {
                MessageBox.Show("Ödəniş məbləği sıfırdan böyük olmalıdır.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (numOdenisMeblegi.Value > _debt.UmumiBorc)
            {
                MessageBox.Show("Ödəniş məbləği ümumi borcu aşa bilməz.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (cmbOdenisTipi.SelectedIndex == -1)
            {
                MessageBox.Show("Zəhmət olmasa ödəniş tipi seçin.", "Xəbərdarlıq", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}