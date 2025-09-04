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
        // MaterialSkinManager-i statik olaraq saxlayırıq ki, bütün tətbiq boyu yalnız bir dəfə yaradılsın.
        private static MaterialSkinManager _materialSkinManager;

        public BazaForm()
        {
            InitializeComponent();

            // Formun öz şriftini təyin edirik. Bu, içindəki bir çox kontrol tərəfindən miras alınacaq.
            // Bu, 'FontRoboto' xətasını aradan qaldırmaq üçün daha etibarlı bir yoldur.
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            InitializeMaterialSkin();
        }

        private void InitializeMaterialSkin()
        {
            // Yalnız ilk dəfə BazaForm yaradılanda SkinManager-i konfiqurasiya edirik.
            if (_materialSkinManager == null)
            {
                _materialSkinManager = MaterialSkinManager.Instance;

                // Bu xüsusiyyət bəzi kontrollərin arxa fon rənginin düzgün tətbiq olunmasını təmin edir.
                _materialSkinManager.EnforceBackcolorOnAllComponents = true;

                // Tətbiqin temasını təyin edirik (Açıq və ya Tünd).
                _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

                // Tətbiqin peşəkar və gözə xoş görünən YAŞIL rəng sxemini təyin edirik.
                _materialSkinManager.ColorScheme = new ColorScheme(
                    Primary.Green800,      // Əsas tünd yaşıl (Header, əsas düymələr)
                    Primary.Green900,      // Daha tünd variant (Status bar)
                    Primary.Green500,      // Açıq variant
                    Accent.LightGreen700,  // Vurğu rəngi (Seçilmiş elementlər, bəzi düymələr)
                    TextShade.WHITE        // Mətn rəngi
                );
            }

            // Hər yeni yaradılan formu SkinManager-in idarəetməsinə əlavə edirik.
            _materialSkinManager.AddFormToManage(this);
        }
        /// <summary>
        /// DataGridView-lər üçün vahid stil təyin edən metod.
        /// Bu metod miras alan bütün formalardan çağırıla bilər.
        /// </summary>
        /// <param name="dgv">Stil veriləcək DataGridView obyekti.</param>
        protected void StilVerDataGridView(DataGridView dgv)
        {
            // --- Ümumi Davranış Tənzimləmələri ---
            dgv.AllowUserToAddRows = false;       // İstifadəçinin sətir əlavə etməsini qadağan et
            dgv.AllowUserToDeleteRows = false;     // İstifadəçinin sətir silməsini qadağan et
            dgv.ReadOnly = true;                   // Cədvəli yalnız oxunaqlı et
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Klikləyəndə bütün sətri seç
            dgv.MultiSelect = false;               // Çoxsaylı sətir seçimini qadağan et
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill; // Sütunları avtomatik doldur

            // --- Görünüş və Stil Tənzimləmələri ---
            dgv.BackgroundColor = Color.Gainsboro; // Arxa fon rəngi
            dgv.BorderStyle = BorderStyle.None;      // Kənar xətləri ləğv et
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal; // Hüceyrələr arası üfüqi xətt

            // --- Başlıq (Header) Stili ---
            dgv.EnableHeadersVisualStyles = false; // Xüsusi başlıq stilini aktivləşdirmək üçün vacibdir!
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None; // Başlıq kənar xətti
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 49, 63); // Başlıq arxa fon rəngi (tünd göy)
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White; // Başlıq mətni rəngi (ağ)
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold); // Başlıq şrifti
            dgv.ColumnHeadersHeight = 40; // Başlıq hündürlüyü

            // --- Sətir (Row) Stili ---
            dgv.RowHeadersVisible = false; // Ən soldakı boş sütunu gizlət
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9); // Sətir şrifti
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(52, 152, 219); // Seçilmiş sətir arxa fonu
            dgv.DefaultCellStyle.SelectionForeColor = Color.White; // Seçilmiş sətir mətni
            dgv.RowTemplate.Height = 35; // Sətirlərin hündürlüyü

            // Alternativ sətirlərə fərqli rəng vermək (zebr effekti)
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.WhiteSmoke;
        }
    }
}