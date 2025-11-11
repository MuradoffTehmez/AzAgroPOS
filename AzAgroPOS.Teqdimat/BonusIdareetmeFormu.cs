using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Xidmetler;
using AzAgroPOS.Varliglar;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class BonusIdareetmeFormu : BazaForm
    {
        private readonly MusteriManager _musteriManager;
        private readonly IDialogXidmeti _dialogXidmeti;
        private int _seciliMusteriId = 0;
        private MusteriBonus? _seciliMusteriBonus = null;

        public BonusIdareetmeFormu(MusteriManager musteriManager)
        {
            InitializeComponent();
            _musteriManager = musteriManager ?? throw new ArgumentNullException(nameof(musteriManager));
            _dialogXidmeti = new DialogXidmeti();
            this.Load += BonusIdareetmeFormu_Load;
        }

        private void BonusIdareetmeFormu_Load(object? sender, EventArgs e)
        {
            _ = YukleAsync();
        }

        private async Task YukleAsync()
        {
            try
            {
                await MusterileriYukle();
                await ButunBonuslariYukle();
                TablolariDuzenle();
            }
            catch (Exception ex)
            {
                _dialogXidmeti.XetaGoster($"Forma yükləmə xətası: {ex.Message}", "Xəta");
            }
        }

        #region Müştəri Yükləmə

        private async Task MusterileriYukle()
        {
            var netice = await _musteriManager.ButunMusterileriGetirAsync();
            if (!netice.UgurluDur || netice.Data == null)
            {
                _dialogXidmeti.XetaGoster(netice.Mesaj ?? "Müştərilər yüklənə bilmədi", "Xəta");
                return;
            }

            cmbMusteri.DataSource = null;
            cmbMusteri.Items.Clear();

            var musteriler = netice.Data
                .OrderBy(m => m.TamAd)
                .ToList();

            cmbMusteri.DataSource = musteriler;
            cmbMusteri.DisplayMember = "TamAd";
            cmbMusteri.ValueMember = "Id";

            if (cmbMusteri.Items.Count > 0)
            {
                cmbMusteri.SelectedIndex = -1;
            }
        }

        #endregion

        #region Bütün Bonuslar

        private async Task ButunBonuslariYukle()
        {
            var netice = await _musteriManager.ButunBonuslariGetirAsync();
            if (!netice.UgurluDur || netice.Data == null)
            {
                _dialogXidmeti.XetaGoster(netice.Mesaj ?? "Bonuslar yüklənə bilmədi", "Xəta");
                return;
            }

            dgvButunBonuslar.DataSource = null;
            dgvButunBonuslar.DataSource = netice.Data;
        }

        private void TablolariDuzenle()
        {
            // Bütün bonuslar grid
            if (dgvButunBonuslar.Columns.Count > 0)
            {
                dgvButunBonuslar.Columns["Id"]!.Visible = false;
                dgvButunBonuslar.Columns["MusteriId"]!.HeaderText = "Müştəri ID";
                dgvButunBonuslar.Columns["MusteriId"]!.Width = 100;

                if (dgvButunBonuslar.Columns["Musteri"] != null)
                {
                    dgvButunBonuslar.Columns["Musteri"]!.HeaderText = "Müştəri";
                    dgvButunBonuslar.Columns["Musteri"]!.Width = 200;
                }

                dgvButunBonuslar.Columns["ToplamBal"]!.HeaderText = "Toplam Bal";
                dgvButunBonuslar.Columns["ToplamBal"]!.DefaultCellStyle.Format = "N2";
                dgvButunBonuslar.Columns["ToplamBal"]!.Width = 120;

                dgvButunBonuslar.Columns["IstifadeEdilmisBal"]!.HeaderText = "İstifadə Edilmiş";
                dgvButunBonuslar.Columns["IstifadeEdilmisBal"]!.DefaultCellStyle.Format = "N2";
                dgvButunBonuslar.Columns["IstifadeEdilmisBal"]!.Width = 140;

                dgvButunBonuslar.Columns["MovcudBal"]!.HeaderText = "Mövcud Bal";
                dgvButunBonuslar.Columns["MovcudBal"]!.DefaultCellStyle.Format = "N2";
                dgvButunBonuslar.Columns["MovcudBal"]!.DefaultCellStyle.Font = new Font(dgvButunBonuslar.Font, FontStyle.Bold);
                dgvButunBonuslar.Columns["MovcudBal"]!.Width = 130;

                dgvButunBonuslar.Columns["Seviyye"]!.HeaderText = "Səviyyə";
                dgvButunBonuslar.Columns["Seviyye"]!.Width = 100;

                if (dgvButunBonuslar.Columns["SonBalQazanmaTarixi"] != null)
                {
                    dgvButunBonuslar.Columns["SonBalQazanmaTarixi"]!.HeaderText = "Son Qazanma";
                    dgvButunBonuslar.Columns["SonBalQazanmaTarixi"]!.DefaultCellStyle.Format = "dd.MM.yyyy";
                    dgvButunBonuslar.Columns["SonBalQazanmaTarixi"]!.Width = 120;
                }

                if (dgvButunBonuslar.Columns["BonusQeydleri"] != null)
                    dgvButunBonuslar.Columns["BonusQeydleri"]!.Visible = false;
            }

            // Bonus tarixçəsi grid
            if (dgvBonusTarixcesi.Columns.Count > 0)
            {
                dgvBonusTarixcesi.Columns["Id"]!.Visible = false;
                dgvBonusTarixcesi.Columns["MusteriBonusId"]!.Visible = false;

                dgvBonusTarixcesi.Columns["EmeliyyatNovu"]!.HeaderText = "Əməliyyat Növü";
                dgvBonusTarixcesi.Columns["EmeliyyatNovu"]!.Width = 130;

                dgvBonusTarixcesi.Columns["BalMiqdari"]!.HeaderText = "Bal Miqdarı";
                dgvBonusTarixcesi.Columns["BalMiqdari"]!.DefaultCellStyle.Format = "N2";
                dgvBonusTarixcesi.Columns["BalMiqdari"]!.DefaultCellStyle.Font = new Font(dgvBonusTarixcesi.Font, FontStyle.Bold);
                dgvBonusTarixcesi.Columns["BalMiqdari"]!.Width = 120;

                dgvBonusTarixcesi.Columns["EmeliyyatTarixi"]!.HeaderText = "Tarix";
                dgvBonusTarixcesi.Columns["EmeliyyatTarixi"]!.DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";
                dgvBonusTarixcesi.Columns["EmeliyyatTarixi"]!.Width = 140;

                dgvBonusTarixcesi.Columns["Aciklama"]!.HeaderText = "Açıqlama";
                dgvBonusTarixcesi.Columns["Aciklama"]!.Width = 250;

                if (dgvBonusTarixcesi.Columns["SatisId"] != null)
                {
                    dgvBonusTarixcesi.Columns["SatisId"]!.HeaderText = "Satış ID";
                    dgvBonusTarixcesi.Columns["SatisId"]!.Width = 100;
                }

                if (dgvBonusTarixcesi.Columns["MusteriBonus"] != null)
                    dgvBonusTarixcesi.Columns["MusteriBonus"]!.Visible = false;

                if (dgvBonusTarixcesi.Columns["Satis"] != null)
                    dgvBonusTarixcesi.Columns["Satis"]!.Visible = false;
            }
        }

        #endregion

        #region Müştəri Seçimi

        private void cmbMusteri_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbMusteri.SelectedValue is int musteriId && musteriId > 0)
            {
                _seciliMusteriId = musteriId;
                _ = MusteriBonusMelumatlariniYukleAsync();
            }
            else
            {
                _seciliMusteriId = 0;
                _seciliMusteriBonus = null;
                BonusMelumatlariniTemizle();
            }

            DuymeleriBloklama();
        }

        private async Task MusteriBonusMelumatlariniYukleAsync()
        {
            try
            {
                await MusteriBonusMelumatlariniYukle();
                await BonusTarixcesiniYukle();
            }
            catch (Exception ex)
            {
                _dialogXidmeti.XetaGoster($"Müştəri bonus məlumatı yüklənərkən xəta: {ex.Message}", "Xəta");
            }
        }

        private async Task MusteriBonusMelumatlariniYukle()
        {
            var netice = await _musteriManager.MusteriBonusunuGetirAsync(_seciliMusteriId);
            if (!netice.UgurluDur)
            {
                _dialogXidmeti.XetaGoster(netice.Mesaj ?? "Bonus məlumatı yüklənə bilmədi", "Xəta");
                BonusMelumatlariniTemizle();
                return;
            }

            _seciliMusteriBonus = netice.Data;

            if (_seciliMusteriBonus != null)
            {
                lblToplamBalDeyer.Text = _seciliMusteriBonus.ToplamBal.ToString("N2");
                lblIstifadeBalDeyer.Text = _seciliMusteriBonus.IstifadeEdilmisBal.ToString("N2");
                lblMovcudBalDeyer.Text = _seciliMusteriBonus.MovcudBal.ToString("N2");
                lblSeviyye.Text = _seciliMusteriBonus.Seviyye.ToString();

                // Səviyyəyə görə rəng
                switch (_seciliMusteriBonus.Seviyye)
                {
                    case MusteriSeviyyesi.Esas:
                        lblSeviyye.ForeColor = Color.Gray;
                        break;
                    case MusteriSeviyyesi.Gumus:
                        lblSeviyye.ForeColor = Color.Silver;
                        break;
                    case MusteriSeviyyesi.Qizil:
                        lblSeviyye.ForeColor = Color.Gold;
                        break;
                    case MusteriSeviyyesi.Platinum:
                        lblSeviyye.ForeColor = Color.DeepSkyBlue;
                        break;
                }
            }
            else
            {
                lblToplamBalDeyer.Text = "0.00";
                lblIstifadeBalDeyer.Text = "0.00";
                lblMovcudBalDeyer.Text = "0.00";
                lblSeviyye.Text = "Esas";
                lblSeviyye.ForeColor = Color.Gray;
            }
        }

        private void BonusMelumatlariniTemizle()
        {
            lblToplamBalDeyer.Text = "0.00";
            lblIstifadeBalDeyer.Text = "0.00";
            lblMovcudBalDeyer.Text = "0.00";
            lblSeviyye.Text = "-";
            lblSeviyye.ForeColor = Color.Black;
            dgvBonusTarixcesi.DataSource = null;
        }

        private async Task BonusTarixcesiniYukle()
        {
            var netice = await _musteriManager.BonusQeydleriniGetirAsync(_seciliMusteriId);
            if (!netice.UgurluDur || netice.Data == null)
            {
                dgvBonusTarixcesi.DataSource = null;
                return;
            }

            dgvBonusTarixcesi.DataSource = netice.Data.OrderByDescending(bq => bq.EmeliyyatTarixi).ToList();

            // Rəngli görüntü
            foreach (DataGridViewRow row in dgvBonusTarixcesi.Rows)
            {
                if (row.Cells["EmeliyyatNovu"].Value is BonusEmeliyyatNovu emeliyyatNovu)
                {
                    switch (emeliyyatNovu)
                    {
                        case BonusEmeliyyatNovu.Qazanma:
                            row.DefaultCellStyle.BackColor = Color.LightGreen;
                            break;
                        case BonusEmeliyyatNovu.Istifade:
                            row.DefaultCellStyle.BackColor = Color.LightBlue;
                            break;
                        case BonusEmeliyyatNovu.Legv:
                            row.DefaultCellStyle.BackColor = Color.LightCoral;
                            break;
                        case BonusEmeliyyatNovu.ManualElave:
                            row.DefaultCellStyle.BackColor = Color.LightYellow;
                            break;
                    }
                }
            }
        }

        #endregion

        #region Əməliyyatlar

        private void btnBalElaveEt_Click(object? sender, EventArgs e)
        {
            if (_seciliMusteriId == 0)
            {
                _dialogXidmeti.XeberdarligGoster("Zəhmət olmasa müştəri seçin", "Xəbərdarlıq");
                return;
            }

            if (numBalMiqdari.Value <= 0)
            {
                _dialogXidmeti.XeberdarligGoster("Bal miqdarı 0-dan böyük olmalıdır", "Xəbərdarlıq");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                _dialogXidmeti.XeberdarligGoster("Zəhmət olmasa açıqlama daxil edin", "Xəbərdarlıq");
                return;
            }

            _ = BalElaveEtAsync();
        }

        private async Task BalElaveEtAsync()
        {
            try
            {
                var netice = await _musteriManager.BalElaveEtAsync(
                    _seciliMusteriId,
                    numBalMiqdari.Value,
                    txtAciklama.Text);

                if (netice.UgurluDur)
                {
                    _dialogXidmeti.UgurGoster("Bal uğurla əlavə edildi", "Uğur");

                    await MusteriBonusMelumatlariniYukle();
                    await BonusTarixcesiniYukle();
                    await ButunBonuslariYukle();
                    EmeliyyatSaheleriniTemizle();
                }
                else
                {
                    _dialogXidmeti.XetaGoster(netice.Mesaj ?? "Bal əlavə edilə bilmədi", "Xəta");
                }
            }
            catch (Exception ex)
            {
                _dialogXidmeti.XetaGoster($"Bal əlavə edilərkən xəta: {ex.Message}", "Xəta");
            }
        }

        private void btnBalIstifadeEt_Click(object? sender, EventArgs e)
        {
            if (_seciliMusteriId == 0)
            {
                _dialogXidmeti.XeberdarligGoster("Zəhmət olmasa müştəri seçin", "Xəbərdarlıq");
                return;
            }

            if (numBalMiqdari.Value <= 0)
            {
                _dialogXidmeti.XeberdarligGoster("Bal miqdarı 0-dan böyük olmalıdır", "Xəbərdarlıq");
                return;
            }

            if (_seciliMusteriBonus == null || _seciliMusteriBonus.MovcudBal < numBalMiqdari.Value)
            {
                _dialogXidmeti.XeberdarligGoster($"Kifayət qədər bal yoxdur. Mövcud bal: {_seciliMusteriBonus?.MovcudBal ?? 0:N2}", "Xəbərdarlıq");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                _dialogXidmeti.XeberdarligGoster("Zəhmət olmasa açıqlama daxil edin", "Xəbərdarlıq");
                return;
            }

            _ = BalIstifadeEtAsync();
        }

        private async Task BalIstifadeEtAsync()
        {
            try
            {
                var netice = await _musteriManager.BalIstifadeEtAsync(
                    _seciliMusteriId,
                    numBalMiqdari.Value,
                    txtAciklama.Text);

                if (netice.UgurluDur)
                {
                    _dialogXidmeti.UgurGoster("Bal uğurla istifadə edildi", "Uğur");

                    await MusteriBonusMelumatlariniYukle();
                    await BonusTarixcesiniYukle();
                    await ButunBonuslariYukle();
                    EmeliyyatSaheleriniTemizle();
                }
                else
                {
                    _dialogXidmeti.XetaGoster(netice.Mesaj ?? "Bal istifadə edilə bilmədi", "Xəta");
                }
            }
            catch (Exception ex)
            {
                _dialogXidmeti.XetaGoster($"Bal istifadə edilərkən xəta: {ex.Message}", "Xəta");
            }
        }

        private void btnBalLegvEt_Click(object? sender, EventArgs e)
        {
            if (_seciliMusteriId == 0)
            {
                _dialogXidmeti.XeberdarligGoster("Zəhmət olmasa müştəri seçin", "Xəbərdarlıq");
                return;
            }

            if (numBalMiqdari.Value <= 0)
            {
                _dialogXidmeti.XeberdarligGoster("Bal miqdarı 0-dan böyük olmalıdır", "Xəbərdarlıq");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                _dialogXidmeti.XeberdarligGoster("Zəhmət olmasa açıqlama daxil edin", "Xəbərdarlıq");
                return;
            }

            var tesdiq = _dialogXidmeti.TesdiqSorus($"Müştərinin {numBalMiqdari.Value:N2} balı ləğv ediləcək. Davam etmək istəyirsiniz?", "Təsdiq");

            if (!tesdiq)
                return;

            _ = BalLegvEtAsync();
        }

        private async Task BalLegvEtAsync()
        {
            try
            {
                var netice = await _musteriManager.BalLegvEtAsync(
                    _seciliMusteriId,
                    numBalMiqdari.Value,
                    txtAciklama.Text);

                if (netice.UgurluDur)
                {
                    _dialogXidmeti.UgurGoster("Bal uğurla ləğv edildi", "Uğur");

                    await MusteriBonusMelumatlariniYukle();
                    await BonusTarixcesiniYukle();
                    await ButunBonuslariYukle();
                    EmeliyyatSaheleriniTemizle();
                }
                else
                {
                    _dialogXidmeti.XetaGoster(netice.Mesaj ?? "Bal ləğv edilə bilmədi", "Xəta");
                }
            }
            catch (Exception ex)
            {
                _dialogXidmeti.XetaGoster($"Bal ləğv edilərkən xəta: {ex.Message}", "Xəta");
            }
        }

        private void btnManualElaveEt_Click(object? sender, EventArgs e)
        {
            if (_seciliMusteriId == 0)
            {
                _dialogXidmeti.XeberdarligGoster("Zəhmət olmasa müştəri seçin", "Xəbərdarlıq");
                return;
            }

            if (numBalMiqdari.Value == 0)
            {
                _dialogXidmeti.XeberdarligGoster("Bal miqdarı 0 ola bilməz", "Xəbərdarlıq");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAciklama.Text))
            {
                _dialogXidmeti.XeberdarligGoster("Zəhmət olmasa açıqlama daxil edin", "Xəbərdarlıq");
                return;
            }

            var tesdiq = _dialogXidmeti.TesdiqSorus($"Müştərinin balına {numBalMiqdari.Value:N2} manual əlavə ediləcək. Davam etmək istəyirsiniz?", "Təsdiq");

            if (!tesdiq)
                return;

            _ = ManualBalElaveEtAsync();
        }

        private async Task ManualBalElaveEtAsync()
        {
            try
            {
                var netice = await _musteriManager.ManualBalElaveEtAsync(
                    _seciliMusteriId,
                    numBalMiqdari.Value,
                    txtAciklama.Text);

                if (netice.UgurluDur)
                {
                    _dialogXidmeti.UgurGoster("Bal uğurla manual əlavə edildi", "Uğur");

                    await MusteriBonusMelumatlariniYukle();
                    await BonusTarixcesiniYukle();
                    await ButunBonuslariYukle();
                    EmeliyyatSaheleriniTemizle();
                }
                else
                {
                    _dialogXidmeti.XetaGoster(netice.Mesaj ?? "Bal manual əlavə edilə bilmədi", "Xəta");
                }
            }
            catch (Exception ex)
            {
                _dialogXidmeti.XetaGoster($"Bal manual əlavə edilərkən xəta: {ex.Message}", "Xəta");
            }
        }

        private void EmeliyyatSaheleriniTemizle()
        {
            numBalMiqdari.Value = 0;
            txtAciklama.Clear();
        }

        #endregion

        #region Yeniləmə

        private void btnYenile_Click(object? sender, EventArgs e)
        {
            _ = YenileAsync();
        }

        private async Task YenileAsync()
        {
            try
            {
                await MusterileriYukle();
                await ButunBonuslariYukle();

                if (_seciliMusteriId > 0)
                {
                    await MusteriBonusMelumatlariniYukle();
                    await BonusTarixcesiniYukle();
                }

                _dialogXidmeti.UgurGoster("Məlumatlar yeniləndi", "Uğur");
            }
            catch (Exception ex)
            {
                _dialogXidmeti.XetaGoster($"Məlumatlar yenilənərkən xəta: {ex.Message}", "Xəta");
            }
        }

        #endregion

        #region Yardımçı metodlar

        private void DuymeleriBloklama()
        {
            bool musteriSecilmisdir = _seciliMusteriId > 0;
            btnBalElaveEt.Enabled = musteriSecilmisdir;
            btnBalIstifadeEt.Enabled = musteriSecilmisdir;
            btnBalLegvEt.Enabled = musteriSecilmisdir;
            btnManualElaveEt.Enabled = musteriSecilmisdir;
        }

        #endregion
    }
}
