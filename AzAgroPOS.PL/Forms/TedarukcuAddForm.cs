using AzAgroPOS.Entities.Domain;
using AzAgroPOS.BLL.Services;
using AzAgroPOS.DAL.Repositories;
using AzAgroPOS.PL.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows.Forms;

namespace AzAgroPOS.PL.Forms
{
    public partial class TedarukcuAddForm : BaseForm
    {
        private readonly TedarukcuRepository _tedarukcuRepository;
        private readonly IServiceProvider _serviceProvider;

        public TedarukcuAddForm(IServiceProvider serviceProvider) : base()
        {
            _serviceProvider = serviceProvider;
            _tedarukcuRepository = serviceProvider.GetRequiredService<TedarukcuRepository>();
            InitializeComponent();
        }

        public TedarukcuAddForm() : this(Program.ServiceProvider)
        {
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveTedarukcu();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private async System.Threading.Tasks.Task SaveTedarukcu()
        {
            await ExecuteAsync(async () =>
            {
                if (string.IsNullOrWhiteSpace(txtAd.Text))
                {
                    ShowError("Tədarükçü adı mütləqdir!");
                    return;
                }

                var tedarukcu = new Tedarukcu
                {
                    Ad = txtAd.Text.Trim(),
                    Kod = txtKod.Text.Trim(),
                    Unvan = txtUnvan.Text.Trim(),
                    Telefon = txtTelefon.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Status = "Aktiv",
                    YaradilmaTarixi = DateTime.Now
                };

                await _tedarukcuRepository.AddAsync(tedarukcu);
                ShowSuccess("Tədarükçü uğurla əlavə edildi!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }, "Tədarükçü əlavə edilərkən xəta baş verdi");
        }
    }
}