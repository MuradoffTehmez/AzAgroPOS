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
            InitializeComponent();
            _serviceProvider = serviceProvider;
            _tedarukcuRepository = serviceProvider.GetRequiredService<TedarukcuRepository>();
        }

        public TedarukcuAddForm() : this(Program.ServiceProvider)
        {
        }

        private void InitializeComponent()
        {
            this.Text = "Yeni Tədarükçü";
            this.Size = new System.Drawing.Size(400, 300);
            this.StartPosition = FormStartPosition.CenterParent;

            var lblAd = new Label { Text = "Tədarükçü Adı:", Location = new System.Drawing.Point(20, 20), AutoSize = true };
            var txtAd = new TextBox { Name = "txtAd", Location = new System.Drawing.Point(120, 18), Width = 200 };

            var lblKod = new Label { Text = "Kod:", Location = new System.Drawing.Point(20, 60), AutoSize = true };
            var txtKod = new TextBox { Name = "txtKod", Location = new System.Drawing.Point(120, 58), Width = 200 };

            var lblUnvan = new Label { Text = "Ünvan:", Location = new System.Drawing.Point(20, 100), AutoSize = true };
            var txtUnvan = new TextBox { Name = "txtUnvan", Location = new System.Drawing.Point(120, 98), Width = 200 };

            var lblTelefon = new Label { Text = "Telefon:", Location = new System.Drawing.Point(20, 140), AutoSize = true };
            var txtTelefon = new TextBox { Name = "txtTelefon", Location = new System.Drawing.Point(120, 138), Width = 200 };

            var lblEmail = new Label { Text = "Email:", Location = new System.Drawing.Point(20, 180), AutoSize = true };
            var txtEmail = new TextBox { Name = "txtEmail", Location = new System.Drawing.Point(120, 178), Width = 200 };

            var btnSave = new Button { Text = "Yadda Saxla", Location = new System.Drawing.Point(120, 220), Width = 100 };
            var btnCancel = new Button { Text = "Ləğv Et", Location = new System.Drawing.Point(230, 220), Width = 100 };

            btnSave.Click += async (s, e) => await SaveTedarukcu();
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            this.Controls.AddRange(new Control[] { lblAd, txtAd, lblKod, txtKod, lblUnvan, txtUnvan, lblTelefon, txtTelefon, lblEmail, txtEmail, btnSave, btnCancel });
        }

        private async System.Threading.Tasks.Task SaveTedarukcu()
        {
            await ExecuteAsync(async () =>
            {
                var txtAd = this.Controls["txtAd"] as TextBox;
                var txtKod = this.Controls["txtKod"] as TextBox;
                var txtUnvan = this.Controls["txtUnvan"] as TextBox;
                var txtTelefon = this.Controls["txtTelefon"] as TextBox;
                var txtEmail = this.Controls["txtEmail"] as TextBox;

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