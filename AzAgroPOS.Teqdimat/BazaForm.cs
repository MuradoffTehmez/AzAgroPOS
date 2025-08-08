// Fayl: AzAgroPOS.Teqdimat/BazaForm.cs
namespace AzAgroPOS.Teqdimat;

using MaterialSkin;
using MaterialSkin.Controls;

public partial class BazaForm : MaterialForm
{
    private readonly MaterialSkinManager _materialSkinManager;

    public BazaForm()
    {
        InitializeComponent();

        // MaterialSkinManager-i başladırıq
        _materialSkinManager = MaterialSkinManager.Instance;
        _materialSkinManager.EnforceBackcolorOnAllComponents = true;
        _materialSkinManager.AddFormToManage(this);
        _materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;

        // Rəng sxemini təyin edirik
        _materialSkinManager.ColorScheme = new ColorScheme(
            Primary.Indigo500,
            Primary.Indigo700,
            Primary.Indigo100,
            Accent.Pink200,
            TextShade.WHITE
        );
    }
}