// Fayl: AzAgroPOS.Teqdimat/BazaForm.cs
using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace AzAgroPOS.Teqdimat
{
    public partial class BazaForm : MaterialForm
    {
        private static MaterialSkinManager _materialSkinManager;
        private Color originalRowColor;
        private Cursor _originalCursor;

        public BazaForm()
        {
            InitializeComponent();
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            InitializeMaterialSkin();
        }

        private void InitializeMaterialSkin()
        {
            if (_materialSkinManager == null)
            {
                _materialSkinManager = MaterialSkinManager.Instance;
                _materialSkinManager.EnforceBackcolorOnAllComponents = true;
                _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
                _materialSkinManager.ColorScheme = new ColorScheme(
                    Primary.Green800,     
                    Primary.Green900,     
                    Primary.Green500,      
                    Accent.LightGreen700,  
                    TextShade.WHITE        
                );
            }

            _materialSkinManager.AddFormToManage(this);
        }
        
        /// <summary>
        /// DataGridView-lər üçün vahid stil təyin edən metod.
        /// Bu metod miras alan bütün formalardan çağırıla bilər.
        /// </summary>
        /// <param name="dgv">Stil veriləcək DataGridView obyekti.</param>
        protected void StilVerDataGridView(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;  
            dgv.AllowUserToResizeRows = false;   
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.ScrollBars = ScrollBars.Both;

            dgv.BackgroundColor = Color.FromArgb(245, 247, 249);
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = Color.FromArgb(224, 224, 224);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(44, 62, 80);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 10.5F);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgv.ColumnHeadersHeight = 45;

            foreach (DataGridViewColumn column in dgv.Columns)
                column.SortMode = DataGridViewColumnSortMode.NotSortable;

            dgv.RowHeadersVisible = false;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.DefaultCellStyle.Padding = new Padding(5, 0, 0, 0);
            dgv.RowTemplate.Height = 40;

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgv.RowsDefaultCellStyle.BackColor = Color.FromArgb(249, 249, 249);

            dgv.CellMouseEnter -= dgv_CellMouseEnter;
            dgv.CellMouseLeave -= dgv_CellMouseLeave;
            dgv.CellMouseEnter += dgv_CellMouseEnter;
            dgv.CellMouseLeave += dgv_CellMouseLeave;
        }

        /// <summary>
        /// Hover zamanı sətrin arxa fonunu dəyişir.
        /// </summary>
        private void dgv_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dgv = (DataGridView)sender;
                var row = dgv.Rows[e.RowIndex];

                if (!row.Selected) 
                {
                    originalRowColor = row.DefaultCellStyle.BackColor;
                    row.DefaultCellStyle.BackColor = Color.FromArgb(236, 240, 241);
                }
            }
        }

        /// <summary>
        /// Hover bitdikdə rəngi bərpa edir.
        /// </summary>
        private void dgv_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var dgv = (DataGridView)sender;
                var row = dgv.Rows[e.RowIndex];

                if (!row.Selected) 
                    row.DefaultCellStyle.BackColor = originalRowColor;
            }
        }

        /// <summary>
        /// Sets the form cursor to wait cursor and disables all controls
        /// </summary>
        public void YuklemeBasladi()
        {
            _originalCursor = this.Cursor;
            this.Cursor = Cursors.WaitCursor;
            DisableControls(this);
        }

        /// <summary>
        /// Restores the form cursor and enables all controls
        /// </summary>
        public void YuklemeBitdi()
        {
            this.Cursor = _originalCursor ?? Cursors.Default;
            EnableControls(this);
        }

        /// <summary>
        /// Disables all controls on the form
        /// </summary>
        /// <param name="control">Control to disable</param>
        private void DisableControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is DataGridView || c is TextBox || c is ComboBox || c is Button || c is CheckBox)
                {
                    c.Enabled = false;
                }
                DisableControls(c);
            }
        }

        /// <summary>
        /// Enables all controls on the form
        /// </summary>
        /// <param name="control">Control to enable</param>
        private void EnableControls(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is DataGridView || c is TextBox || c is ComboBox || c is Button || c is CheckBox)
                {
                    c.Enabled = true;
                }
                EnableControls(c);
            }
        }
    }
}