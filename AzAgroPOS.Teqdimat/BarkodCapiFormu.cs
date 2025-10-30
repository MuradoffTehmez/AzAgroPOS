// Fayl: AzAgroPOS.Teqdimat/BarkodCapiFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Mentiq.Idareciler;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;
using System.ComponentModel;

public partial class BarkodCapiFormu : BazaForm, IBarkodCapiView
{
    private readonly BarkodCapiPresenter _presenter;
    private BindingList<BarkodEtiketDto> _capSiyahisiBindingList;

    public BarkodCapiFormu(BarkodCapiManager barkodCapiManager, MehsulManager mehsulManager)
    {
        InitializeComponent();
        _presenter = new BarkodCapiPresenter(this, barkodCapiManager, mehsulManager);
        StilVerDataGridView(dgvAxtarisNeticeleri);
        StilVerDataGridView(dgvCapSiyahisi);
        _capSiyahisiBindingList = new BindingList<BarkodEtiketDto>();
        dgvCapSiyahisi.DataSource = _capSiyahisiBindingList;
    }

    public string AxtarisMetni => txtAxtar.Text;
    public List<BarkodEtiketDto> CapSiyahisi => _capSiyahisiBindingList.ToList();

    public event EventHandler AxtarisIstek;
    public event EventHandler SiyahiniCapaGonderIstek;

    public void AxtarisNeticeleriniGoster(List<MehsulDto> mehsullar)
    {
        dgvAxtarisNeticeleri.DataSource = mehsullar;
        dgvAxtarisNeticeleri.Visible = true;
        lblAxtarisXeta.Visible = false;
    }

    public void AxtarisXetasiGoster(string mesaj)
    {
        dgvAxtarisNeticeleri.DataSource = null;
        dgvAxtarisNeticeleri.Visible = false;
        lblAxtarisXeta.Text = mesaj;
        lblAxtarisXeta.Visible = true;
    }

    public void CapSiyahisiniYenile(List<BarkodEtiketDto> siyahı)
    {
        _capSiyahisiBindingList.Clear();
        foreach (var item in siyahı)
        {
            _capSiyahisiBindingList.Add(item);
        }
    }

    public void MesajGoster(string mesaj, string basliq)
    {
        MessageBox.Show(mesaj, basliq);
    }

    /// <summary>
    /// Shows a validation error on a control
    /// </summary>
    /// <param name="control">Control to show error on</param>
    /// <param name="message">Error message</param>
    public void XetaGoster(Control control, string message)
    {
        errorProvider1.SetError(control, message);
        errorProvider1.SetIconAlignment(control, ErrorIconAlignment.MiddleRight);
        errorProvider1.SetIconPadding(control, 2);
    }

    /// <summary>
    /// Clears validation error from a control
    /// </summary>
    /// <param name="control">Control to clear error from</param>
    public void XetaniTemizle(Control control)
    {
        errorProvider1.SetError(control, string.Empty);
    }

    /// <summary>
    /// Clears all validation errors
    /// </summary>
    public void ButunXetalariTemizle()
    {
        // Clear errors from all controls
        foreach (Control control in this.Controls)
        {
            ClearErrorsRecursive(control);
        }
    }

    /// <summary>
    /// Recursively clears errors from all controls
    /// </summary>
    /// <param name="control">Control to clear errors from</param>
    private void ClearErrorsRecursive(Control control)
    {
        errorProvider1.SetError(control, string.Empty);
        foreach (Control child in control.Controls)
        {
            ClearErrorsRecursive(child);
        }
    }

    private void btnAxtar_Click(object sender, EventArgs e)
    {
        AxtarisIstek?.Invoke(this, EventArgs.Empty);
    }

    private void btnSiyahiyaElaveEt_Click(object sender, EventArgs e)
    {
        if (dgvAxtarisNeticeleri.CurrentRow?.DataBoundItem is MehsulDto secilmisMehsul)
        {
            // Eyni məhsul siyahıda varsa, sayını artır
            var movcud = _capSiyahisiBindingList.FirstOrDefault(x => x.MehsulId == secilmisMehsul.Id);
            if (movcud != null)
            {
                movcud.CapEdilecekSay++;
            }
            else // Yoxdursa, yeni əlavə et
            {
                var yeniEtiket = new BarkodEtiketDto
                {
                    MehsulId = secilmisMehsul.Id,
                    MehsulAdi = secilmisMehsul.Ad,
                    Barkod = secilmisMehsul.Barkod,
                    Qiymet = secilmisMehsul.PerakendeSatisQiymeti,
                    CapEdilecekSay = 1
                };
                _capSiyahisiBindingList.Add(yeniEtiket);
            }
            _capSiyahisiBindingList.ResetBindings();
        }
    }

    private void btnSiyahidanSil_Click(object sender, EventArgs e)
    {
        if (dgvCapSiyahisi.CurrentRow?.DataBoundItem is BarkodEtiketDto secilmisEtiket)
        {
            _capSiyahisiBindingList.Remove(secilmisEtiket);
        }
    }

    private void btnCapiBaslat_Click(object sender, EventArgs e)
    {
        SiyahiniCapaGonderIstek?.Invoke(this, EventArgs.Empty);
    }

}
