// AzAgroPOS.Teqdimat/KonfiqurasiyaFormu.cs
using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;

namespace AzAgroPOS.Teqdimat
{
    public partial class KonfiqurasiyaFormu : BazaForm, IKonfiqurasiyaView
    {
        private readonly KonfiqurasiyaManager _konfiqurasiyaManager;

        public KonfiqurasiyaFormu(KonfiqurasiyaManager konfiqurasiyaManager)
        {
            InitializeComponent();
            _konfiqurasiyaManager = konfiqurasiyaManager;
        }

        private async void KonfiqurasiyaFormu_Load(object sender, EventArgs e)
        {
            await YukleKonfiqurasiyaParametrləri();
        }

        private async Task YukleKonfiqurasiyaParametrləri()
        {
            try
            {
                // Şirkət məlumatlarını yükləyirik
                var sirketMəlumatları = await _konfiqurasiyaManager.QruplaGetirAsync("Şirkət Məlumatları");
                if (sirketMəlumatları.UgurluDur)
                {
                    foreach (var parametr in sirketMəlumatları.Data)
                    {
                        switch (parametr.Acar)
                        {
                            case "Şirkət.Adı":
                                txtSirketAdi.Text = parametr.Deyer;
                                break;
                            case "Şirkət.Ünvanı":
                                txtSirketUnvani.Text = parametr.Deyer;
                                break;
                            case "Şirkət.VÖEN":
                                txtSirketVoen.Text = parametr.Deyer;
                                break;
                        }
                    }
                }

                // Vergi parametrlərini yükləyirik
                var vergiParametrləri = await _konfiqurasiyaManager.QruplaGetirAsync("Vergi Parametrləri");
                if (vergiParametrləri.UgurluDur)
                {
                    foreach (var parametr in vergiParametrləri.Data)
                    {
                        if (parametr.Acar == "Vergi.ƏDV.Dərəcəsi")
                        {
                            if (decimal.TryParse(parametr.Deyer, out decimal edvDerəcəsi))
                            {
                                nudEdvDerəcəsi.Value = edvDerəcəsi;
                            }
                        }
                    }
                }

                // Printer tənzimləmələrini yükləyirik
                var printerTənzimləmələri = await _konfiqurasiyaManager.QruplaGetirAsync("Printer Tənzimləmələri");
                if (printerTənzimləmələri.UgurluDur)
                {
                    foreach (var parametr in printerTənzimləmələri.Data)
                    {
                        switch (parametr.Acar)
                        {
                            case "Printer.Qəbz":
                                txtQəbzPrinteri.Text = parametr.Deyer;
                                break;
                            case "Printer.Barkod":
                                txtBarkodPrinteri.Text = parametr.Deyer;
                                break;
                        }
                    }
                }

                // Proqram davranış parametrlərini yükləyirik
                var davranisParametrləri = await _konfiqurasiyaManager.QruplaGetirAsync("Proqram Davranışı");
                if (davranisParametrləri.UgurluDur)
                {
                    foreach (var parametr in davranisParametrləri.Data)
                    {
                        if (parametr.Acar == "Davranış.SatışdanSonraQəbziÇapEt")
                        {
                            chkSatisdanSonraQəbziÇapEt.Checked = parametr.Deyer.ToLower() == "true";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konfiqurasiya parametrləri yüklənərkən xəta baş verdi: {ex.Message}",
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSaxla_Click(object sender, EventArgs e)
        {
            try
            {
                // Şirkət məlumatlarını saxlayırıq
                var sirketAdiParametr = new KonfiqurasiyaDto
                {
                    Acar = "Şirkət.Adı",
                    Deyer = txtSirketAdi.Text,
                    Tesvir = "Şirkətin rəsmi adı",
                    Qrup = "Şirkət Məlumatları"
                };
                await _konfiqurasiyaManager.KonfiqurasiyaElaveEtVəYaYenileAsync(sirketAdiParametr);

                var sirketUnvaniParametr = new KonfiqurasiyaDto
                {
                    Acar = "Şirkət.Ünvanı",
                    Deyer = txtSirketUnvani.Text,
                    Tesvir = "Şirkətin ünvanı",
                    Qrup = "Şirkət Məlumatları"
                };
                await _konfiqurasiyaManager.KonfiqurasiyaElaveEtVəYaYenileAsync(sirketUnvaniParametr);

                var sirketVoenParametr = new KonfiqurasiyaDto
                {
                    Acar = "Şirkət.VÖEN",
                    Deyer = txtSirketVoen.Text,
                    Tesvir = "Şirkətin vergi ödəyiciyinin elektron nömrəsi",
                    Qrup = "Şirkət Məlumatları"
                };
                await _konfiqurasiyaManager.KonfiqurasiyaElaveEtVəYaYenileAsync(sirketVoenParametr);

                // Vergi parametrlərini saxlayırıq
                var edvDerəcəsiParametr = new KonfiqurasiyaDto
                {
                    Acar = "Vergi.ƏDV.Dərəcəsi",
                    Deyer = nudEdvDerəcəsi.Value.ToString(),
                    Tesvir = "ƏDV dərəcəsi (%)",
                    Qrup = "Vergi Parametrləri"
                };
                await _konfiqurasiyaManager.KonfiqurasiyaElaveEtVəYaYenileAsync(edvDerəcəsiParametr);

                // Printer tənzimləmələrini saxlayırıq
                var qəbzPrinteriParametr = new KonfiqurasiyaDto
                {
                    Acar = "Printer.Qəbz",
                    Deyer = txtQəbzPrinteri.Text,
                    Tesvir = "Qəbz çapı üçün printer",
                    Qrup = "Printer Tənzimləmələri"
                };
                await _konfiqurasiyaManager.KonfiqurasiyaElaveEtVəYaYenileAsync(qəbzPrinteriParametr);

                var barkodPrinteriParametr = new KonfiqurasiyaDto
                {
                    Acar = "Printer.Barkod",
                    Deyer = txtBarkodPrinteri.Text,
                    Tesvir = "Barkod çapı üçün printer",
                    Qrup = "Printer Tənzimləmələri"
                };
                await _konfiqurasiyaManager.KonfiqurasiyaElaveEtVəYaYenileAsync(barkodPrinteriParametr);

                // Proqram davranış parametrlərini saxlayırıq
                var davranisParametr = new KonfiqurasiyaDto
                {
                    Acar = "Davranış.SatışdanSonraQəbziÇapEt",
                    Deyer = chkSatisdanSonraQəbziÇapEt.Checked.ToString(),
                    Tesvir = "Satışdan sonra qəbzi avtomatik çap et",
                    Qrup = "Proqram Davranışı"
                };
                await _konfiqurasiyaManager.KonfiqurasiyaElaveEtVəYaYenileAsync(davranisParametr);

                MessageBox.Show("Konfiqurasiya parametrləri uğurla saxlanıldı.",
                    "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Konfiqurasiya parametrləri saxlanılarkən xəta baş verdi: {ex.Message}",
                    "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // IKonfiqurasiyaView interface implementasiyası
        public void MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            MessageBox.Show(mesaj, basliq, düymələr, ikon);
        }

        public void FormuYenile()
        {
            // Formu yeniləmək üçün tələb olunan əməliyyatlar
            // Hazırda bu metod sadələşdirilmişdir
        }
    }
}