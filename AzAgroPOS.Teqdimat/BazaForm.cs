// Fayl: AzAgroPOS.Teqdimat/BazaForm.cs
using MaterialSkin;
using MaterialSkin.Controls;
using AzAgroPOS.Mentiq.Yardimcilar;
using AzAgroPOS.Teqdimat.Yardimcilar;

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
            InitializeStatusMesaji();
        }

        private void InitializeStatusMesaji()
        {
            if (toolStripStatusLabel1 != null)
            {
                StatusMesajiGostericisi.Initialize(toolStripStatusLabel1);
            }
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

        #region İcazə Yoxlama Metodları

        /// <summary>
        /// İstifadəçinin icazəsi olub-olmadığını yoxlayır
        /// diqqət: Bu metod IcazeYoxlayici singleton istifadə edir
        /// qeyd: İcazə yoxdursa false qaytarır
        /// </summary>
        /// <param name="icazeAdi">Yoxlanılacaq icazənin adı</param>
        /// <returns>İcazə varsa true, yoxsa false</returns>
        protected bool IcazeVarmi(string icazeAdi)
        {
            return AzAgroPOS.Mentiq.Yardimcilar.IcazeYoxlayici.Instance.IcazeVarmi(icazeAdi);
        }

        /// <summary>
        /// İstifadəçinin icazəsi olub-olmadığını yoxlayır və mesaj göstərir
        /// diqqət: İcazə yoxdursa istifadəçiyə xəbərdarlıq mesajı göstərilir
        /// qeyd: MessageBox.Show ilə mesaj göstərilir
        /// </summary>
        /// <param name="icazeAdi">Yoxlanılacaq icazənin adı</param>
        /// <returns>İcazə varsa true, yoxsa false</returns>
        protected bool IcazeVarmiMesajla(string icazeAdi)
        {
            bool icazeVar = AzAgroPOS.Mentiq.Yardimcilar.IcazeYoxlayici.Instance.IcazeVarmiMesajla(icazeAdi, out string mesaj);

            if (!icazeVar)
            {
                MessageBox.Show(mesaj, "İcazə Yoxdur", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return icazeVar;
        }

        /// <summary>
        /// İcazəyə əsasən button-u gizlədir və ya göstərir
        /// diqqət: İcazə yoxdursa button Visible = false olur
        /// qeyd: Formun Load event-də çağırılmalıdır
        /// </summary>
        /// <param name="button">İcazəyə görə gizlədilə biləcək button</param>
        /// <param name="icazeAdi">Tələb olunan icazənin adı</param>
        protected void ButtonIcazeIleGoster(Control button, string icazeAdi)
        {
            if (button == null)
                return;

            button.Visible = IcazeVarmi(icazeAdi);
        }

        /// <summary>
        /// İcazəyə əsasən button-u aktivləşdirir və ya deaktivləşdirir
        /// diqqət: İcazə yoxdursa button Enabled = false olur
        /// qeyd: Formun Load event-də çağırılmalıdır
        /// </summary>
        /// <param name="button">İcazəyə görə deaktivləşdirilə biləcək button</param>
        /// <param name="icazeAdi">Tələb olunan icazənin adı</param>
        protected void ButtonIcazeIleAktivleshdir(Control button, string icazeAdi)
        {
            if (button == null)
                return;

            button.Enabled = IcazeVarmi(icazeAdi);
        }

        /// <summary>
        /// Çoxsaylı buttonları icazələrə görə konfiqurasiya edir
        /// diqqət: Dictionary formatında button və icazə cütləri verilir
        /// qeyd: Formun Load event-də çağırılmalıdır
        /// </summary>
        /// <param name="buttonIcazeler">Button-İcazə cütləri</param>
        /// <param name="gizlet">true olarsa buttonlar gizlədilir, false olarsa deaktivləşdirilir</param>
        protected void ButtonlariIcazeIleKonfiqureEt(Dictionary<Control, string> buttonIcazeler, bool gizlet = false)
        {
            if (buttonIcazeler == null)
                return;

            foreach (var pair in buttonIcazeler)
            {
                if (pair.Key == null)
                    continue;

                bool icazeVar = IcazeVarmi(pair.Value);

                if (gizlet)
                {
                    pair.Key.Visible = icazeVar;
                }
                else
                {
                    pair.Key.Enabled = icazeVar;
                }
            }
        }

        /// <summary>
        /// İstifadəçinin admin olub-olmadığını yoxlayır
        /// </summary>
        protected bool AdminDirmi()
        {
            return AzAgroPOS.Mentiq.Yardimcilar.IcazeYoxlayici.Instance.AdminDirmi();
        }

        /// <summary>
        /// İstifadəçinin manager olub-olmadığını yoxlayır
        /// </summary>
        protected bool ManagerDirmi()
        {
            return AzAgroPOS.Mentiq.Yardimcilar.IcazeYoxlayici.Instance.ManagerDirmi();
        }

        /// <summary>
        /// İstifadəçinin kassir olub-olmadığını yoxlayır
        /// </summary>
        protected bool KassirDirmi()
        {
            return AzAgroPOS.Mentiq.Yardimcilar.IcazeYoxlayici.Instance.KassirDirmi();
        }

        #endregion

        #region Status Mesajı Metodları

        /// <summary>
        /// Status stripda uğurlu mesaj göstərir
        /// diqqət: Mesaj avtomatik olaraq 3 saniyə sonra təmizlənir
        /// qeyd: Yaşıl rənglə göstərilir
        /// </summary>
        /// <param name="mesaj">Göstəriləcək mesaj</param>
        protected void UgurluMesajGoster(string mesaj)
        {
            StatusMesajiGostericisi.UgurluMesajGoster(mesaj);
        }

        /// <summary>
        /// Status stripda xəta mesajı göstərir
        /// diqqət: Mesaj avtomatik olaraq 3 saniyə sonra təmizlənir
        /// qeyd: Qırmızı rənglə göstərilir
        /// </summary>
        /// <param name="mesaj">Göstəriləcək mesaj</param>
        protected void XetaMesajiGoster(string mesaj)
        {
            StatusMesajiGostericisi.XetaMesajiGoster(mesaj);
        }

        /// <summary>
        /// Status stripda məlumat mesajı göstərir
        /// diqqət: Mesaj avtomatik olaraq 3 saniyə sonra təmizlənir
        /// qeyd: Mavi rənglə göstərilir
        /// </summary>
        /// <param name="mesaj">Göstəriləcək mesaj</param>
        protected void MelumatMesajiGoster(string mesaj)
        {
            StatusMesajiGostericisi.MelumatMesajiGoster(mesaj);
        }

        #endregion
    }
}