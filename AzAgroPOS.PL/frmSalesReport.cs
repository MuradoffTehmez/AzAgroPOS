using AzAgroPOS.BLL;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;
using iTextFont = iTextSharp.text.Font; // Ad konfliktini həll etmək üçün alias

namespace AzAgroPOS.PL
{
    public partial class frmSalesReport : Form
    {
        private readonly SatisBLL _satisBll = new SatisBLL();
        private readonly SatisMehsullariBLL _satisMehsullariBll = new SatisMehsullariBLL();

        public frmSalesReport()
        {
            InitializeComponent();
        }

        private void frmSalesReport_Load(object sender, EventArgs e)
        {
            dtpStartDate.Value = DateTime.Today;
            dtpEndDate.Value = DateTime.Today;
            btnShowReport_Click(null, null); 
        }

        private void btnShowReport_Click(object sender, EventArgs e)
        {
            try
            {
                var startDate = dtpStartDate.Value.Date;
                var endDate = dtpEndDate.Value.Date.AddDays(1).AddTicks(-1); // Günün son anı

                dgvSales.DataSource = _satisBll.GetByDateRange(startDate, endDate);
                SetupSalesGrid();
                dgvSaleDetails.DataSource = null; // Üst cədvəl yenilənəndə alt cədvəli təmizləyirik
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hesabat yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupSalesGrid()
        {
            if (dgvSales.Columns.Count == 0) return;

            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Görünən sütunların başlıqlarını və formatlarını dəyişirik
            dgvSales.Columns["Id"].HeaderText = "Satış ID";
            dgvSales.Columns["SatisTarixi"].HeaderText = "Tarix və Vaxt";
            dgvSales.Columns["MusteriAdi"].HeaderText = "Müştəri";
            dgvSales.Columns["IstifadeciAdi"].HeaderText = "Kassir";
            dgvSales.Columns["EndirimMeblegi"].HeaderText = "Endirim (₼)";
            dgvSales.Columns["YekunMebleg"].HeaderText = "Yekun Məbləğ (₼)";

            dgvSales.Columns["EndirimMeblegi"].DefaultCellStyle.Format = "F2";
            dgvSales.Columns["YekunMebleg"].DefaultCellStyle.Format = "F2";
            dgvSales.Columns["SatisTarixi"].DefaultCellStyle.Format = "dd.MM.yyyy HH:mm";

            // Lazımsız sütunları gizlədirik
            string[] hiddenColumns = { "MusteriId", "IstifadeciId", "OdenmisMebleg", "SatisMehsullari", "Odenisler" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvSales.Columns[colName] != null) dgvSales.Columns[colName].Visible = false;
            }
        }

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
                MessageBox.Show("Satış detalları yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupDetailsGrid()
        {
            if (dgvSaleDetails.Columns.Count == 0) return;

            dgvSaleDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvSaleDetails.Columns["MehsulAdi"] != null) dgvSaleDetails.Columns["MehsulAdi"].HeaderText = "Məhsul Adı";
            if (dgvSaleDetails.Columns["Miqdar"] != null) dgvSaleDetails.Columns["Miqdar"].HeaderText = "Miqdar";
            if (dgvSaleDetails.Columns["QiymetBirEdede"] != null) dgvSaleDetails.Columns["QiymetBirEdede"].HeaderText = "Vahid Qiyməti (₼)";
            if (dgvSaleDetails.Columns["EndirimMeblegi"] != null) dgvSaleDetails.Columns["EndirimMeblegi"].HeaderText = "Endirim (₼)";

            if (dgvSaleDetails.Columns["QiymetBirEdede"] != null) dgvSaleDetails.Columns["QiymetBirEdede"].DefaultCellStyle.Format = "F2";
            if (dgvSaleDetails.Columns["EndirimMeblegi"] != null) dgvSaleDetails.Columns["EndirimMeblegi"].DefaultCellStyle.Format = "F2";

            string[] hiddenColumns = { "Id", "SatisId", "MehsulId" };
            foreach (var colName in hiddenColumns)
            {
                if (dgvSaleDetails.Columns[colName] != null) dgvSaleDetails.Columns[colName].Visible = false;
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            if (dgvSales.Rows.Count == 0)
            {
                MessageBox.Show("İxrac etmək üçün məlumat yoxdur.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            try
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel Workbook|*.xlsx";
                saveFileDialog.Title = "Excel faylı olaraq yadda saxla";
                saveFileDialog.FileName = $"Satış Hesabatı_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("Satış Hesabatı");
                        int cellIndex = 1;
                        foreach (DataGridViewColumn column in dgvSales.Columns)
                        {
                            if (column.Visible)
                            {
                                worksheet.Cell(1, cellIndex++).Value = column.HeaderText;
                            }
                        }
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
                        workbook.SaveAs(saveFileDialog.FileName);
                        MessageBox.Show("Hesabat uğurla Excel faylına ixrac edildi!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Excel-ə ixrac zamanı xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportToPdf_Click(object sender, EventArgs e)
        {
            if (dgvSales.Rows.Count == 0)
            {
                MessageBox.Show("İxrac etmək üçün məlumat yoxdur.", "Məlumat", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Faylı|*.pdf";
            saveFileDialog.Title = "PDF faylı olaraq yadda saxla";
            saveFileDialog.FileName = $"Satış Hesabatı_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "ARIAL.TTF");
                    BaseFont baseFont = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                    iTextFont fontHeader = new iTextFont(baseFont, 10, iTextFont.BOLD);
                    iTextFont fontBody = new iTextFont(baseFont, 9, iTextFont.NORMAL);

                    Document document = new Document(PageSize.A4.Rotate(), 20, 20, 20, 20);
                    PdfWriter.GetInstance(document, new FileStream(saveFileDialog.FileName, FileMode.Create));

                    int visibleColumnCount = 0;
                    foreach (DataGridViewColumn column in dgvSales.Columns)
                        if (column.Visible) visibleColumnCount++;

                    PdfPTable table = new PdfPTable(visibleColumnCount);
                    table.WidthPercentage = 100;

                    foreach (DataGridViewColumn column in dgvSales.Columns)
                    {
                        if (column.Visible)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.HeaderText, fontHeader));
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            table.AddCell(cell);
                        }
                    }

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

                    MessageBox.Show("Hesabat uğurla PDF faylına ixrac edildi!", "Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("PDF-ə ixrac zamanı xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}