using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class MusteriDetailsForm : Form
    {
        private readonly MusteriService _musteriService;
        private readonly Musteri _musteri;

        public MusteriDetailsForm(int musteriId)
        {
            InitializeComponent();
            _musteriService = new MusteriService();
            
            _musteri = _musteriService.GetCustomerById(musteriId);
            if (_musteri == null)
                throw new ArgumentException("Müştəri tapılmadı", nameof(musteriId));
            
            SetupForm();
            LoadCustomerDetails();
        }

        private void SetupForm()
        {
            Text = "Müştəri Detalları";
        }

        private void LoadCustomerDetails()
        {
            try
            {
                // Personal Information
                lblMusteriKodu.Text = "Müştəri Kodu: " + _musteri.MusteriKodu;
                lblAd.Text = "Ad: " + _musteri.Ad;
                lblSoyad.Text = "Soyad: " + _musteri.Soyad;
                lblTelefon.Text = "Telefon: " + _musteri.TelefonBilgisi;
                lblEmail.Text = "Email: " + (_musteri.Email ?? "Məlumat yoxdur");
                
                // Financial Information
                lblCariBorc.Text = "Cari Borc: " + _musteri.CariBorc.ToString("C");
                lblKreditLimiti.Text = "Kredit Limiti: " + _musteri.KreditLimitiFormatli;
                lblUmumiAlis.Text = "Ümumi Alış: " + _musteri.UmumiAlis.ToString("C");
                lblSonZiyaret.Text = "Son Ziyarət: " + (_musteri.SonZiyaretTarixi?.ToString("dd.MM.yyyy") ?? "Heç vaxt");
                
                // Set color for debt status
                if (_musteri.KreditLimitiAsildi)
                {
                    lblCariBorc.ForeColor = System.Drawing.Color.Red;
                }
                else
                {
                    lblCariBorc.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Müştəri detalları yüklənərkən xəta baş verdi.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}