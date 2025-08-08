// Fayl: AzAgroPOS.Teqdimat/SatisFormu.cs
namespace AzAgroPOS.Teqdimat;

using AzAgroPOS.Mentiq.DTOs;
using AzAgroPOS.Teqdimat.Interfeysler;
using AzAgroPOS.Teqdimat.Teqdimatcilar;

public partial class SatisFormu : BazaForm, ISatisView
{
    private readonly SatisPresenter _presenter;

    public SatisFormu()
    {
        InitializeComponent();
        _presenter = new SatisPresenter(this);
    }

    // Interfeys Implementasiyası
    public string BarkodAxtaris => txtBarkodAxtaris.Text;

    public event EventHandler BarkodDaxilEdildi_Istek;
    public event EventHandler SatisiTesdiqle_Istek;

    public void SebeteMehsulGoster(IEnumerable<SatisSebetiElementiDto> sebet)
    {
        dgvSebet.DataSource = sebet.ToList();
        if (dgvSebet.Columns.Count > 0)
        {
            dgvSebet.Columns["MehsulId"].Visible = false;
            dgvSebet.Columns["MehsulAdi"].HeaderText = "Məhsulun Adı";
            dgvSebet.Columns["Miqdar"].HeaderText = "Miqdar";
            dgvSebet.Columns["VahidinQiymeti"].HeaderText = "Qiymət";
            dgvSebet.Columns["UmumiMebleg"].HeaderText = "Məbləğ";
        }
    }

    public void UmumiMebligiGoster(decimal mebleg)
    {
        lblUmumiMebleg.Text = $"ÜMUMİ MƏBLƏĞ: {mebleg:N2} AZN";
    }

    public void FormuSifirla()
    {
        txtBarkodAxtaris.Clear();
        txtBarkodAxtaris.Focus();
    }

    public DialogResult MesajGoster(string mesaj, string basliq, MessageBoxButtons düymələr, MessageBoxIcon ikon)
    {
        return MessageBox.Show(this, mesaj, basliq, düymələr, ikon);
    }

    // Hadisələrin Presenter-ə ötürülməsi
    private void txtBarkodAxtaris_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            BarkodDaxilEdildi_Istek?.Invoke(this, EventArgs.Empty);
            // Enter-ə basdıqdan sonra mətn qutusunu təmizləyək ki, yeni barkod daxil etmək rahat olsun
            txtBarkodAxtaris.SelectAll();
        }
    }

    private void btnSatisiTesdiqle_Click(object sender, EventArgs e)
    {
        SatisiTesdiqle_Istek?.Invoke(this, EventArgs.Empty);
    }
}