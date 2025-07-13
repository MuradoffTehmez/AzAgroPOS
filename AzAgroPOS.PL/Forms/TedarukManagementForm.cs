using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.Entities.Domain;

namespace AzAgroPOS.PL.Forms
{
    public partial class TedarukManagementForm : Form
    {
        private readonly TedarukcuService _tedarukcuService;
        private readonly AnbarService _anbarService;
        private readonly MehsulService _mehsulService;
        private List<Tedarukcu> _tedarukciler;
        private List<AlisOrder> _alişOrderleri;
        private List<AlisSeined> _alisSenedleri;
        private List<AnbarTransfer> _transferler;

        public TedarukManagementForm()
        {
            InitializeComponent();
            _tedarukcuService = new TedarukcuService();
            _anbarService = new AnbarService();
            _mehsulService = new MehsulService();
            LoadData();
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _tedarukcuService?.Dispose();
                _anbarService?.Dispose();
                _mehsulService?.Dispose();
                components?.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}