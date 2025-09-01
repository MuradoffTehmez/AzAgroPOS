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
    }
}