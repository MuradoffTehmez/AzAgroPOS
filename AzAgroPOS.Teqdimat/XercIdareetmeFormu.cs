// Fayl: AzAgroPOS.Teqdimat/XercIdareetmeFormu.cs

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using AzAgroPOS.Varliglar;
using MaterialSkin.Controls;
using System.ComponentModel;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class XercIdareetmeFormu : BazaForm, IXercView
    {
        private XercPresenter _presenter;
        private BindingList<XercDto> _xercBindingList;

        public XercIdareetmeFormu()
        {
            InitializeComponent();
            StilVerDataGridView(dgvXercler);
            _xercBindingList = new BindingList<XercDto>();
            dgvXercler.DataSource = _xercBindingList;
            ConfigureDataGridViewStyles();
        }

        public XercNovu SecilmisXercNovu => (XercNovu)(cmbXercNovu.SelectedItem ?? XercNovu.Diger);
        public string XercAdi => txtXercAdi.Text;
        public decimal XercMeblegi => nudXercMeblegi.Value;
        public DateTime XercTarixi => dtpXercTarixi.Value;
        public string? XercSenedNomresi => txtSenedNomresi.Text;
        public string? XercQeydi => txtQeyd.Text;
        public int? SecilmisXercId => _secilmisXercId;
        private int? _secilmisXercId;

        public event EventHandler XercElaveEtIstek;
        public event EventHandler XercYenileIstek;
        public event EventHandler XercSilIstek;
        public event EventHandler XercAxtarIstek;
        public event EventHandler FormYuklendiIstek;

        public void XercleriGoster(List<XercDto> xercler)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => XercleriGoster(xercler)));
                return;
            }

            _xercBindingList.Clear();
            foreach (var xerc in xercler)
            {
                _xercBindingList.Add(xerc);
            }

            // DataGridView sütun başlıqlarını tərcümə edin
            if (dgvXercler.Columns.Contains("Novu"))
                dgvXercler.Columns["Novu"].HeaderText = "Növ";
            if (dgvXercler.Columns.Contains("Ad"))
                dgvXercler.Columns["Ad"].HeaderText = "Ad";
            if (dgvXercler.Columns.Contains("Mebleg"))
                dgvXercler.Columns["Mebleg"].HeaderText = "Məbləğ";
            if (dgvXercler.Columns.Contains("Tarix"))
                dgvXercler.Columns["Tarix"].HeaderText = "Tarix";
            if (dgvXercler.Columns.Contains("SenedNomresi"))
                dgvXercler.Columns["SenedNomresi"].HeaderText = "Sənəd №";
            if (dgvXercler.Columns.Contains("Qeyd"))
                dgvXercler.Columns["Qeyd"].HeaderText = "Qeyd";
            if (dgvXercler.Columns.Contains("IstifadeciAdi"))
                dgvXercler.Columns["IstifadeciAdi"].HeaderText = "İstifadəçi";
        }

        public void XercFormunuSifirla()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(XercFormunuSifirla));
                return;
            }

            cmbXercNovu.SelectedIndex = -1;
            txtXercAdi.Clear();
            nudXercMeblegi.Value = 0;
            dtpXercTarixi.Value = DateTime.Now;
            txtSenedNomresi.Clear();
            txtQeyd.Clear();
            _secilmisXercId = null;
            btnXercElaveEt.Text = "Əlavə Et";
            btnXercYenile.Enabled = false;
            btnXercSil.Enabled = false;
        }

        public void SecilmisXerciFormaYukle(XercDto xerc)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SecilmisXerciFormaYukle(xerc)));
                return;
            }

            cmbXercNovu.SelectedItem = xerc.Novu;
            txtXercAdi.Text = xerc.Ad ?? string.Empty;
            nudXercMeblegi.Value = xerc.Mebleg;
            dtpXercTarixi.Value = xerc.Tarix;
            txtSenedNomresi.Text = xerc.SenedNomresi ?? string.Empty;
            txtQeyd.Text = xerc.Qeyd ?? string.Empty;
            _secilmisXercId = xerc.Id;
            btnXercElaveEt.Text = "Yenilə";
            btnXercYenile.Enabled = true;
            btnXercSil.Enabled = true;
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            return MessageBox.Show(this, mesaj, basliq, düymələr, ikon);
        }

        public void InitializePresenter(XercPresenter presenter)
        {
            _presenter = presenter;
        }

        private void ConfigureDataGridViewStyles()
        {
            // DataGridView sütun genişliklərini tənzimləyin
            if (dgvXercler.Columns.Contains("Novu"))
                dgvXercler.Columns["Novu"].Width = 120;
            if (dgvXercler.Columns.Contains("Ad"))
                dgvXercler.Columns["Ad"].Width = 150;
            if (dgvXercler.Columns.Contains("Mebleg"))
                dgvXercler.Columns["Mebleg"].Width = 100;
            if (dgvXercler.Columns.Contains("Tarix"))
                dgvXercler.Columns["Tarix"].Width = 120;
            if (dgvXercler.Columns.Contains("SenedNomresi"))
                dgvXercler.Columns["SenedNomresi"].Width = 100;
            if (dgvXercler.Columns.Contains("Qeyd"))
                dgvXercler.Columns["Qeyd"].Width = 150;
            if (dgvXercler.Columns.Contains("IstifadeciAdi"))
                dgvXercler.Columns["IstifadeciAdi"].Width = 120;

            // Məbləğ sütunu üçün para formatı
            if (dgvXercler.Columns.Contains("Mebleg"))
            {
                dgvXercler.Columns["Mebleg"].DefaultCellStyle.Format = "N2";
            }
        }

        private void XercIdareetmeFormu_Load(object sender, EventArgs e)
        {
            // Xərc növlərini combo box-a əlavə edin
            cmbXercNovu.DataSource = Enum.GetValues(typeof(XercNovu));
            cmbXercNovu.SelectedIndex = -1;

            // Təsdiqləyici metodu çağırın
            FormYuklendiIstek?.Invoke(this, EventArgs.Empty);
        }

        private void dgvXercler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvXercler.CurrentRow?.DataBoundItem is XercDto secilmisXerc)
            {
                SecilmisXerciFormaYukle(secilmisXerc);
            }
        }

        private void btnXercElaveEt_Click(object sender, EventArgs e)
        {
            if (_secilmisXercId.HasValue)
            {
                XercYenileIstek?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                XercElaveEtIstek?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnXercYenile_Click(object sender, EventArgs e)
        {
            XercYenileIstek?.Invoke(this, EventArgs.Empty);
        }

        private void btnXercSil_Click(object sender, EventArgs e)
        {
            XercSilIstek?.Invoke(this, EventArgs.Empty);
        }

        private void btnYenidenYukle_Click(object sender, EventArgs e)
        {
            XercAxtarIstek?.Invoke(this, EventArgs.Empty);
        }

        private void btnFormuSifirla_Click(object sender, EventArgs e)
        {
            XercFormunuSifirla();
        }
    }
}
            _xercBindingList.Clear();
            foreach (var xerc in xercler)
            {
                _xercBindingList.Add(xerc);
            }

            // DataGridView sütun başlıqlarını tərcümə edin
            if (dgvXercler.Columns.Contains("Novu"))
                dgvXercler.Columns["Novu"].HeaderText = "Növ";
            if (dgvXercler.Columns.Contains("Ad"))
                dgvXercler.Columns["Ad"].HeaderText = "Ad";
            if (dgvXercler.Columns.Contains("Mebleg"))
                dgvXercler.Columns["Mebleg"].HeaderText = "Məbləğ";
            if (dgvXercler.Columns.Contains("Tarix"))
                dgvXercler.Columns["Tarix"].HeaderText = "Tarix";
            if (dgvXercler.Columns.Contains("SenedNomresi"))
                dgvXercler.Columns["SenedNomresi"].HeaderText = "Sənəd №";
            if (dgvXercler.Columns.Contains("Qeyd"))
                dgvXercler.Columns["Qeyd"].HeaderText = "Qeyd";
            if (dgvXercler.Columns.Contains("IstifadeciAdi"))
                dgvXercler.Columns["IstifadeciAdi"].HeaderText = "İstifadəçi";
        }

        public void XercFormunuSifirla()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(XercFormunuSifirla));
                return;
            }

            cmbXercNovu.SelectedIndex = -1;
            txtXercAdi.Clear();
            nudXercMeblegi.Value = 0;
            dtpXercTarixi.Value = DateTime.Now;
            txtSenedNomresi.Clear();
            txtQeyd.Clear();
            _secilmisXercId = null;
            btnXercElaveEt.Text = "Əlavə Et";
            btnXercYenile.Enabled = false;
            btnXercSil.Enabled = false;
        }

        public void SecilmisXerciFormaYukle(XercDto xerc)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => SecilmisXerciFormaYukle(xerc)));
                return;
            }

            cmbXercNovu.SelectedItem = xerc.Novu;
            txtXercAdi.Text = xerc.Ad ?? string.Empty;
            nudXercMeblegi.Value = xerc.Mebleg;
            dtpXercTarixi.Value = xerc.Tarix;
            txtSenedNomresi.Text = xerc.SenedNomresi ?? string.Empty;
            txtQeyd.Text = xerc.Qeyd ?? string.Empty;
            _secilmisXercId = xerc.Id;
            btnXercElaveEt.Text = "Yenilə";
            btnXercYenile.Enabled = true;
            btnXercSil.Enabled = true;
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
        {
            return MessageBox.Show(this, mesaj, basliq, düymələr, ikon);
        }

        public void InitializePresenter(XercPresenter presenter)
        {
            _presenter = presenter;
        }

        private void ConfigureDataGridViewStyles()
        {
            // DataGridView sütun genişliklərini tənzimləyin
            if (dgvXercler.Columns.Contains("Novu"))
                dgvXercler.Columns["Novu"].Width = 120;
            if (dgvXercler.Columns.Contains("Ad"))
                dgvXercler.Columns["Ad"].Width = 150;
            if (dgvXercler.Columns.Contains("Mebleg"))
                dgvXercler.Columns["Mebleg"].Width = 100;
            if (dgvXercler.Columns.Contains("Tarix"))
                dgvXercler.Columns["Tarix"].Width = 120;
            if (dgvXercler.Columns.Contains("SenedNomresi"))
                dgvXercler.Columns["SenedNomresi"].Width = 100;
            if (dgvXercler.Columns.Contains("Qeyd"))
                dgvXercler.Columns["Qeyd"].Width = 150;
            if (dgvXercler.Columns.Contains("IstifadeciAdi"))
                dgvXercler.Columns["IstifadeciAdi"].Width = 120;

            // Məbləğ sütunu üçün para formatı
            if (dgvXercler.Columns.Contains("Mebleg"))
            {
                dgvXercler.Columns["Mebleg"].DefaultCellStyle.Format = "N2";
            }
        }

        private void XercIdareetmeFormu_Load(object sender, EventArgs e)
        {
            // Xərc növlərini combo box-a əlavə edin
            cmbXercNovu.DataSource = Enum.GetValues(typeof(XercNovu));
            cmbXercNovu.SelectedIndex = -1;

            // Təsdiqləyici metodu çağırın
            FormYuklendiIstek?.Invoke(this, EventArgs.Empty);
        }

        private void dgvXercler_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvXercler.CurrentRow?.DataBoundItem is XercDto secilmisXerc)
            {
                SecilmisXerciFormaYukle(secilmisXerc);
            }
        }

        private void btnXercElaveEt_Click(object sender, EventArgs e)
        {
            if (_secilmisXercId.HasValue)
            {
                XercYenileIstek?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                XercElaveEtIstek?.Invoke(this, EventArgs.Empty);
            }
        }

        private void btnXercYenile_Click(object sender, EventArgs e)
        {
            XercYenileIstek?.Invoke(this, EventArgs.Empty);
        }

        private void btnXercSil_Click(object sender, EventArgs e)
        {
            XercSilIstek?.Invoke(this, EventArgs.Empty);
        }

        private void btnYenidenYukle_Click(object sender, EventArgs e)
        {
            XercAxtarIstek?.Invoke(this, EventArgs.Empty);
        }

        private void btnFormuSifirla_Click(object sender, EventArgs e)
        {
            XercFormunuSifirla();
        }
    }
}