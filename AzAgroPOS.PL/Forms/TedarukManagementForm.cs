using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AzAgroPOS.BLL.Interfaces;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;


namespace AzAgroPOS.PL.Forms
{
    public partial class TedarukManagementForm : BaseForm
    {
        private readonly TedarukcuService _tedarukcuService;
        private readonly AnbarService _anbarService;
        private readonly MehsulService _mehsulService;
        private List<Tedarukcu> _tedarukciler;
        private List<AlisOrder> _alişOrderleri;
        private List<AlisSeined> _alisSenedleri;
        private List<AnbarTransfer> _transferler;

        public TedarukManagementForm() : base()
        {
            InitializeComponent();
            _tedarukcuService = ServiceFactory.CreateTedarukcuService();
            _anbarService = ServiceFactory.CreateAnbarService();
            _mehsulService = ServiceFactory.CreateMehsulService();
            AttachEventHandlers();
            LoadData();
        }

        private void AttachEventHandlers()
        {
            // Tədarükçü tab event handlers
            btnYeniTedarukcu.Click += BtnYeniTedarukcu_Click;
            btnDuzenleTedarukcu.Click += BtnDuzenleTedarukcu_Click;
            btnSilTedarukcu.Click += BtnSilTedarukcu_Click;
            btnOdemeYap.Click += BtnOdemeYap_Click;

            // Alış Order tab event handlers
            btnYeniOrder.Click += BtnYeniOrder_Click;
            btnDuzenleOrder.Click += BtnDuzenleOrder_Click;
            btnTesdiqleOrder.Click += BtnTesdiqleOrder_Click;
            btnIptalOrder.Click += BtnIptalOrder_Click;
            btnOrderDetali.Click += BtnOrderDetali_Click;

            // Alış Sənəd tab event handlers
            btnYeniSened.Click += BtnYeniSened_Click;
            btnQebulEt.Click += BtnQebulEt_Click;
            btnIptalSened.Click += BtnIptalSened_Click;
            btnSenedDetali.Click += BtnSenedDetali_Click;
            btnFaktura.Click += BtnFaktura_Click;

            // Transfer tab event handlers
            btnYeniTransfer.Click += BtnYeniTransfer_Click;
            btnGonderTransfer.Click += BtnGonderTransfer_Click;
            btnQebulTransfer.Click += BtnQebulTransfer_Click;
            btnIptalTransfer.Click += BtnIptalTransfer_Click;
            btnTransferDetali.Click += BtnTransferDetali_Click;

            // Search textbox events
            txtTedarukcuAxtaris.TextChanged += TxtTedarukcuAxtaris_TextChanged;
            txtOrderAxtaris.TextChanged += TxtOrderAxtaris_TextChanged;
            txtSenedAxtaris.TextChanged += TxtSenedAxtaris_TextChanged;
            txtTransferAxtaris.TextChanged += TxtTransferAxtaris_TextChanged;
        }

        private void LoadData()
        {
            LoadTedarukciler();
            LoadAlisOrderleri();
            LoadAlisSenedleri();
            LoadTransferler();
        }

        private void LoadTedarukciler()
        {
            try
            {
                _tedarukciler = _tedarukcuService.GetAllActive();
                dgvTedarukciler.DataSource = _tedarukciler.Select(t => new
                {
                    t.Id,
                    t.Kod,
                    t.Ad,
                    t.VOEN,
                    t.Telefon,
                    t.Email,
                    t.CariBorc,
                    t.KreditLimiti,
                    t.Status
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tədarükçülər yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAlisOrderleri()
        {
            try
            {
                _alişOrderleri = _tedarukcuService.GetAllAlisOrders();
                dgvAlisOrderleri.DataSource = _alişOrderleri.Select(ao => new
                {
                    ao.Id,
                    ao.OrderNomresi,
                    ao.OrderTarixi,
                    TedarukcuAdi = ao.Tedarukcu?.Ad,
                    ao.Status,
                    ao.UmumiMebleg,
                    ao.TeslimTarixi
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Alış orderləri yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAlisSenedleri()
        {
            try
            {
                _alisSenedleri = _tedarukcuService.GetAllAlisSenedleri();
                dgvAlisSenedleri.DataSource = _alisSenedleri.Select(as1 => new
                {
                    as1.Id,
                    as1.SenedNomresi,
                    as1.SenedTarixi,
                    TedarukcuAdi = as1.Tedarukcu?.Ad,
                    as1.Status,
                    as1.UmumiMebleg,
                    as1.OdemeStatus
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Alış sənədləri yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransferler()
        {
            try
            {
                _transferler = _anbarService.GetAllTransfers();
                dgvTransferler.DataSource = _transferler.Select(t => new
                {
                    t.Id,
                    t.TransferNomresi,
                    t.TransferTarixi,
                    MenbAnbar = t.MenbAnbar?.Ad,
                    HedefAnbar = t.HedefAnbar?.Ad,
                    t.Status,
                    t.UmumiMiqdar
                }).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transferlər yüklənərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Event Handlers

        #region Tədarükçü Tab Events

        private void BtnYeniTedarukcu_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = new TedarukcuAddForm();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    LoadTedarukciler(); // Refresh supplier list
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDuzenleTedarukcu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTedarukciler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa tədarükçü seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvTedarukciler.SelectedRows[0].Cells["Id"].Value;
                MessageBox.Show($"Tədarükçü redaktə formu açılacaq (ID: {selectedId})", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSilTedarukcu_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTedarukciler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa tədarükçü seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvTedarukciler.SelectedRows[0].Cells["Id"].Value;
                var selectedName = dgvTedarukciler.SelectedRows[0].Cells["Ad"].Value.ToString();

                var result = MessageBox.Show($"'{selectedName}' tədarükçüsünü silmək istədiyinizdən əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    _tedarukcuService.DeleteTedarukcu(selectedId);
                    LoadTedarukciler();
                    MessageBox.Show("Tədarükçü uğurla silindi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Tədarükçü silinərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOdemeYap_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTedarukciler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa tədarükçü seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvTedarukciler.SelectedRows[0].Cells["Id"].Value;
                MessageBox.Show($"Ödəmə formu açılacaq (Tədarükçü ID: {selectedId})", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtTedarukcuAxtaris_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTedarukcuAxtaris.Text))
                {
                    LoadTedarukciler();
                    return;
                }

                var searchTerm = txtTedarukcuAxtaris.Text.Trim();
                var filteredData = _tedarukciler?.Where(t =>
                    (t.Ad?.ToLower().Contains(searchTerm.ToLower()) ?? false) ||
                    (t.Kod?.ToLower().Contains(searchTerm.ToLower()) ?? false) ||
                    (t.VOEN?.ToLower().Contains(searchTerm.ToLower()) ?? false)
                ).Select(t => new
                {
                    t.Id,
                    t.Kod,
                    t.Ad,
                    t.VOEN,
                    t.Telefon,
                    t.Email,
                    t.CariBorc,
                    t.KreditLimiti,
                    t.Status
                }).ToList();

                dgvTedarukciler.DataSource = filteredData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Axtarışda xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Alış Order Tab Events

        private void BtnYeniOrder_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Yeni alış order formu açılacaq", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDuzenleOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlisOrderleri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa order seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvAlisOrderleri.SelectedRows[0].Cells["Id"].Value;
                MessageBox.Show($"Order redaktə formu açılacaq (ID: {selectedId})", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTesdiqleOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlisOrderleri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa order seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvAlisOrderleri.SelectedRows[0].Cells["Id"].Value;
                var result = MessageBox.Show("Seçilən orderi təsdiqləmək istədiyinizdən əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // TODO: Implement order confirmation logic
                    MessageBox.Show("Order təsdiqləndi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAlisOrderleri();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Order təsdiqləyərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIptalOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlisOrderleri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa order seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvAlisOrderleri.SelectedRows[0].Cells["Id"].Value;
                var result = MessageBox.Show("Seçilən orderi ləğv etmək istədiyinizdən əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // TODO: Implement order cancellation logic
                    MessageBox.Show("Order ləğv edildi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAlisOrderleri();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Order ləğv edərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnOrderDetali_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlisOrderleri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa order seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvAlisOrderleri.SelectedRows[0].Cells["Id"].Value;
                MessageBox.Show($"Order detalları formu açılacaq (ID: {selectedId})", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtOrderAxtaris_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtOrderAxtaris.Text))
                {
                    LoadAlisOrderleri();
                    return;
                }

                var searchTerm = txtOrderAxtaris.Text.Trim().ToLower();
                var filteredData = _alişOrderleri?.Where(ao =>
                    (ao.OrderNomresi?.ToLower().Contains(searchTerm) ?? false) ||
                    (ao.Tedarukcu?.Ad?.ToLower().Contains(searchTerm) ?? false)
                ).Select(ao => new
                {
                    ao.Id,
                    ao.OrderNomresi,
                    ao.OrderTarixi,
                    TedarukcuAdi = ao.Tedarukcu?.Ad,
                    ao.Status,
                    ao.UmumiMebleg,
                    ao.TeslimTarixi
                }).ToList();

                dgvAlisOrderleri.DataSource = filteredData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Axtarışda xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Alış Sənəd Tab Events

        private void BtnYeniSened_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Yeni alış sənədi formu açılacaq", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQebulEt_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlisSenedleri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa sənəd seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvAlisSenedleri.SelectedRows[0].Cells["Id"].Value;
                var result = MessageBox.Show("Seçilən sənədi qəbul etmək istədiyinizdən əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // TODO: Implement document acceptance logic
                    MessageBox.Show("Sənəd qəbul edildi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAlisSenedleri();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sənəd qəbul edərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIptalSened_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlisSenedleri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa sənəd seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvAlisSenedleri.SelectedRows[0].Cells["Id"].Value;
                var result = MessageBox.Show("Seçilən sənədi ləğv etmək istədiyinizdən əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // TODO: Implement document cancellation logic
                    MessageBox.Show("Sənəd ləğv edildi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAlisSenedleri();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sənəd ləğv edərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnSenedDetali_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlisSenedleri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa sənəd seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvAlisSenedleri.SelectedRows[0].Cells["Id"].Value;
                MessageBox.Show($"Sənəd detalları formu açılacaq (ID: {selectedId})", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnFaktura_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvAlisSenedleri.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa sənəd seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvAlisSenedleri.SelectedRows[0].Cells["Id"].Value;
                MessageBox.Show($"Faktura çap ediləcək (ID: {selectedId})", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtSenedAxtaris_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtSenedAxtaris.Text))
                {
                    LoadAlisSenedleri();
                    return;
                }

                var searchTerm = txtSenedAxtaris.Text.Trim().ToLower();
                var filteredData = _alisSenedleri?.Where(as1 =>
                    (as1.SenedNomresi?.ToLower().Contains(searchTerm) ?? false) ||
                    (as1.Tedarukcu?.Ad?.ToLower().Contains(searchTerm) ?? false)
                ).Select(as1 => new
                {
                    as1.Id,
                    as1.SenedNomresi,
                    as1.SenedTarixi,
                    TedarukcuAdi = as1.Tedarukcu?.Ad,
                    as1.Status,
                    as1.UmumiMebleg,
                    as1.OdemeStatus
                }).ToList();

                dgvAlisSenedleri.DataSource = filteredData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Axtarışda xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Transfer Tab Events

        private void BtnYeniTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("Yeni transfer formu açılacaq", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGonderTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa transfer seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvTransferler.SelectedRows[0].Cells["Id"].Value;
                var result = MessageBox.Show("Seçilən transferi göndərmək istədiyinizdən əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // TODO: Implement transfer send logic
                    MessageBox.Show("Transfer göndərildi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransferler();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transfer göndərərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnQebulTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa transfer seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvTransferler.SelectedRows[0].Cells["Id"].Value;
                var result = MessageBox.Show("Seçilən transferi qəbul etmək istədiyinizdən əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // TODO: Implement transfer receive logic
                    MessageBox.Show("Transfer qəbul edildi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransferler();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transfer qəbul edərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnIptalTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa transfer seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvTransferler.SelectedRows[0].Cells["Id"].Value;
                var result = MessageBox.Show("Seçilən transferi ləğv etmək istədiyinizdən əminsiniz?",
                    "Təsdiq", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // TODO: Implement transfer cancellation logic
                    MessageBox.Show("Transfer ləğv edildi", "Uğur", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadTransferler();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Transfer ləğv edərkən xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnTransferDetali_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvTransferler.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Zəhmət olmasa transfer seçin", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var selectedId = (int)dgvTransferler.SelectedRows[0].Cells["Id"].Value;
                MessageBox.Show($"Transfer detalları formu açılacaq (ID: {selectedId})", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TxtTransferAxtaris_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtTransferAxtaris.Text))
                {
                    LoadTransferler();
                    return;
                }

                var searchTerm = txtTransferAxtaris.Text.Trim().ToLower();
                var filteredData = _transferler?.Where(t =>
                    (t.TransferNomresi?.ToLower().Contains(searchTerm) ?? false) ||
                    (t.MenbAnbar?.Ad?.ToLower().Contains(searchTerm) ?? false) ||
                    (t.HedefAnbar?.Ad?.ToLower().Contains(searchTerm) ?? false)
                ).Select(t => new
                {
                    t.Id,
                    t.TransferNomresi,
                    t.TransferTarixi,
                    MenbAnbar = t.MenbAnbar?.Ad,
                    HedefAnbar = t.HedefAnbar?.Ad,
                    t.Status,
                    t.UmumiMiqdar
                }).ToList();

                dgvTransferler.DataSource = filteredData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Axtarışda xəta: {ex.Message}", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #endregion

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        _tedarukcuService?.Dispose();
        //        _anbarService?.Dispose();
        //        _mehsulService?.Dispose();
        //        components?.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}