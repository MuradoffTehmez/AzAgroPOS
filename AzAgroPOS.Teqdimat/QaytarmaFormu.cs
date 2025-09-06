using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class QaytarmaFormu : BazaForm, IQaytarmaView
    {
        public QaytarmaFormu()
        {
            InitializeComponent();
            StilVerDataGridView(dgvSatisMehsullari);

        }

        public string SatisNomresi => txtSatisNomresi.Text;
        
        public string QaytarmaSebebi => txtQaytarmaSebebi.Text;

        public List<SatisSebetiElementiDto> SecilmisMehsullar
        {
            get
            {
                var secilmisler = new List<SatisSebetiElementiDto>();
                foreach (DataGridViewRow row in dgvSatisMehsullari.Rows)
                {
                    if (row.Cells["Secim"].Value != null && (bool)row.Cells["Secim"].Value)
                    {
                        secilmisler.Add((SatisSebetiElementiDto)row.DataBoundItem);
                    }
                }
                return secilmisler;
            }
        }

        public event EventHandler SatisAxtarIstek;
        public event EventHandler QaytarmaEmeliyyatiIstek;

        public void SatisMehsullariniGoster(List<SatisSebetiElementiDto> mehsullar)
        {
            dgvSatisMehsullari.DataSource = mehsullar;
            // Configure columns if needed
            if (dgvSatisMehsullari.Columns.Count > 0)
            {
                // Assuming the Dto has these properties
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.MehsulAdi)].HeaderText = "Məhsul Adı";
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.Miqdar)].HeaderText = "Miqdar";
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.VahidinQiymeti)].HeaderText = "Qiymət";
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.UmumiMebleg)].HeaderText = "Cəmi Məbləğ";

                // Hide unnecessary columns
                dgvSatisMehsullari.Columns[nameof(SatisSebetiElementiDto.MehsulId)].Visible = false;
                // Add a checkbox column for selection if it doesn't exist
                if (dgvSatisMehsullari.Columns["Secim"] == null)
                {
                    DataGridViewCheckBoxColumn secimCol = new DataGridViewCheckBoxColumn();
                    secimCol.Name = "Secim";
                    secimCol.HeaderText = "Seç";
                    dgvSatisMehsullari.Columns.Insert(0, secimCol);
                }
            }
        }

        public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            return MessageBox.Show(this, mesaj, basliq, buttons, icon);
        }

        private void btnAxtar_Click(object sender, EventArgs e)
        {
            SatisAxtarIstek?.Invoke(this, EventArgs.Empty);
        }

        private void btnQaytar_Click(object sender, EventArgs e)
        {
            QaytarmaEmeliyyatiIstek?.Invoke(this, EventArgs.Empty);
        }
    }
}