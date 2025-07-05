using AzAgroPOS.BLL;
using AzAgroPOS.Entities;
using AzAgroPOS.PL.Printing;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;
using iTextFont = iTextSharp.text.Font;

namespace AzAgroPOS.PL
{
    /// <summary>
    /// Satış hesabatlarının görüntülənməsi və ixracı üçün form. Tarix aralığına görə satış məlumatlarını göstərir və Excel/PDF formatlarında ixrac edir.
    /// </summary>
    public partial class frmSalesReport : Form
    {
        private readonly SatisBLL _satisBll = new SatisBLL();
        private readonly SatisMehsullariBLL _satisMehsullariBll = new SatisMehsullariBLL();

        /// <summary>
        /// frmSalesReport konstruktoru.
        /// </summary>
        public frmSalesReport()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Form yüklənərkən işə düşən metod. İlkin tarixləri təyin edir və hesabatı yükləyir.
        /// </summary>
        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            btnShowReport_Click(null, null);
        }

        #region Helper Methods

        /// <summary>
        /// Satış cədvəlinin sütunlarını tənzimləyir.
        /// </summary>
        private void SetupSalesGrid()
        {
            if (dgvSales.Columns.Count == 0) return;

            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Sütun başlıqlarını və formatlarını təyin et
            dgvSales.Columns["Id"].HeaderText = "Satış ID";
            dgvSales.Columns["SatisTarixi"].HeaderText = "Tarix və Vaxt";
            dgvSales.Columns["MusteriAdi"].HeaderText = "Müştəri";
            dgvSales.Columns["IstifadeciAdi"].HeaderText = "Kassir";
            dgvSales.Columns["EndirimMeblegi"].HeaderText = "Endirim (₼)";
            dgvSales.Columns["YekunMebleg"].HeaderText = "Yekun Məbləğ (₼)";

            dgvSales.Columns["EndirimMeblegi"].DefaultCellStyle.Format = "F2";
            dgvSales.Columns["YekunMebleg"].DefaultCellStyle.Format = "F2";
            dgvSales.Columns["SatisTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

            // Gizlədiləcək sütunlar
            string[] hiddenColumns = { "MusteriId", "IstifadeciId", "OdenmisMebleg", "SatisMehsullari", "Odenisler" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvSales.Columns[colName] != null) dgvSales.Columns[colName].Visible = false;
            }
        }

        /// <summary>
        /// Satış detalları cədvəlinin sütunlarını tənzimləyir.
        /// </summary>
        private void SetupDetailsGrid()
        {
            if (dgvSaleDetails.Columns.Count == 0) return;

            dgvSaleDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Sütun başlıqlarını təyin et
            if (dgvSaleDetails.Columns["MehsulAdi"] != null) dgvSaleDetails.Columns["MehsulAdi"].HeaderText = "Məhsul Adı";
            if (dgvSaleDetails.Columns["Miqdar"] != null) dgvSaleDetails.Columns["Miqdar"].HeaderText = "Miqdar";
            if (dgvSaleDetails.Columns["QiymetBirEdede"] != null) dgvSaleDetails.Columns["QiymetBirEdede"].HeaderText = "Vahid Qiyməti (₼)";
            if (dgvSaleDetails.Columns["EndirimMeblegi"] != null) dgvSaleDetails.Columns["EndirimMeblegi"].HeaderText = "Endirim (₼)";

            // Format təyin et
            if (dgvSaleDetails.Columns["QiymetBirEdede"] != null) dgvSaleDetails.Columns["QiymetBirEdede"].DefaultCellStyle.Format = "F2";
            if (dgvSaleDetails.Columns["EndirimMeblegi"] != null) dgvSaleDetails.Columns["EndirimMeblegi"].DefaultCellStyle.Format = "F2";

            // Gizlədiləcək sütunlar
            string[] hiddenColumns = { "Id", "SatisId", "MehsulId" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvSaleDetails.Columns[colName] != null) dgvSaleDetails.Columns[colName].Visible = false;
            }
        }

        /// <summary>
        /// Excel faylına ixrac prosesini həyata keçirir.
        /// </summary>
        /// <param name="fileName">Yadda saxlanılacaq faylın yolu</param>
        private void ExportToExcel(string fileName)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Satış Hesabatı");

                // Başlıqları yaz
                int cellIndex = 1;
                foreach (DataGridViewColumn column in dgvSales.Columns)
                {
                    if (column.Visible)
                    {
                        worksheet.Cell(1, cellIndex++).Value = column.HeaderText;
                    }
                }

                // Məlumatları yaz
                int rowIndex = 2;
                foreach (DataGridViewRow row in dgvSales.Rows)
                {
                    cellIndex = 1;
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.OwningColumn.Visible)
                        {
                            worksheet.Cell(rowIndex, cellIndex++).Value = cell.Value?.ToString();
                        }
                    }
                    rowIndex++;
                }

                worksheet.Columns().AdjustToContents();
                workbook.SaveAs(fileName);
            }
        }

        /// <summary>
        /// PDF faylına ixrac prosesini həyata keçirir.
        /// </summary>
        /// <param name="fileName">Yadda saxlanılacaq faylın yolu</param>
        private void ExportToPdf(string fileName)
        {
            string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
            BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

            iTextFont fontHeader = new iTextFont(baseFont, 10, iTextFont.BOLD);
            iTextFont fontBody = new iTextFont(baseFont, 9, iTextFont.NORMAL);

            Document document = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
            PdfWriter.GetInstance(document, new FileStream(fileName, FileMode.Create));

            // Görünən sütunların sayını hesabla
            int visibleColumnCount = 0;
            foreach (DataGridViewColumn column in dgvSales.Columns)
                if (column.Visible) visibleColumnCount++;

            PdfPTable table = new PdfPTable(visibleColumnCount);
            table.WidthPercentage = 100;

            // Başlıqları yaz
            foreach (DataGridViewColumn column in dgvSales.Columns)
            {
                if (column.Visible)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontHeader));
                    cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                    table.AddCell(cell);
                }
            }

            // Məlumatları yaz
            foreach (DataGridViewRow row in dgvSales.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.OwningColumn.Visible)
                    {
                        table.AddCell(new Phrase(cell.Value?.ToString(), fontBody));
                    }
                }
            }

            document.Open();
            document.Add(new Phrase("Satış Hesabatı", new iTextFont(baseFont, 16, iTextFont.BOLD)));
            document.Add(new Paragraph($"Tarix Aralığı: {dtpStartDate.Value:dd.MM.yyyy} - {dtpEndDate.Value:dd.MM.yyyy}\n\n"));
            document.Add(table);
            document.Close();
        }
        #endregion

        #region Event Handlers

        /// <summary>
        /// Hesabatı göstərmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1); // Günün son anı

                dgvSales.DataSource = _satisBll.GetByDateRange(startDate, endDate);
                SetupSalesGrid();
                dgvSaleDetails.DataSource = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesabat yüklənərkən xəta baş verdi: " + ex.Message,
                              "Xəta",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Satış cədvəlində seçim dəyişdikdə işə düşən metod.
        /// </summary>
        private void dgvSales_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null) return;

            try
            {
                int selectedSatisId = (int)dgvSales.CurrentRow.Cells["Id"].Value;
                dgvSaleDetails.DataSource = _satisMehsullariBll.GetBySatisId(selectedSatisId);
                SetupDetailsGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış detalları yüklənərkən xəta baş verdi: " + ex.Message,
                              "Xəta",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Excel-ə ixrac etmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (dgvSales.Rows.Count == 0)
            {
                MessageBox.Show("İxrac etmək üçün məlumat yoxdur.",
                              "Məlumat",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Workbook|*.xlsx",
                Title = "Excel faylı olaraq yadda saxla",
                FileName = $"Satış Hesabatı_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToExcel(saveFileDialog.FileName);
                    MessageBox.Show("Hesabat uğurla Excel faylına ixrac edildi!",
                                  "Uğurlu",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Excel-ə ixrac zamanı xəta baş verdi: " + ex.Message,
                                  "Xəta",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// PDF-ə ixrac etmək üçün düymə klik hadisəsi.
        /// </summary>
        private void btnExportToPdf_Click(object sender, EventArgs e)
        {
            if (dgvSales.Rows.Count == 0)
            {
                MessageBox.Show("İxrac etmək üçün məlumat yoxdur.",
                              "Məlumat",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "PDF Faylı|*.pdf",
                Title = "PDF faylı olaraq yadda saxla",
                FileName = $"Satış Hesabatı_{DateTime.Now:yyyyMMdd_HHmmss}.pdf"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    ExportToPdf(saveFileDialog.FileName);
                    MessageBox.Show("Hesabat uğurla PDF faylına ixrac edildi!",
                                  "Uğurlu",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PDF-ə ixrac zamanı xəta baş verdi: " + ex.Message,
                                  "Xəta",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvSales.CurrentRow == null)
            {
                MessageBox.Show("Zəhmət olmasa, çap etmək üçün cədvəldən bir satış seçin.", "Xəbərdarlıq", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var satisInfo = (Satis)dgvSales.CurrentRow.DataBoundItem;
                // Satışın detallı məlumatlarını (məhsullar və s.) gətiririk
                var fullSatisInfo = new SatisBLL().GetById(satisInfo.Id);

                if (fullSatisInfo != null)
                {
                    var printer = new ChequePrinterService(fullSatisInfo);
                    printer.Print();
                }
                else
                {
                    MessageBox.Show("Satış məlumatları tapılmadı.", "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Çap zamanı xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}