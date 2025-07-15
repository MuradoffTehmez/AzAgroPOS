using AzAgroPOS.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
// using System.Windows.Forms; // BLL layer-də UI components istifadə edilmir

namespace AzAgroPOS.BLL.Services
{
    public class ExportService : IDisposable
    {
        private bool _disposed = false;

        public ExportService()
        {
        }

        #region Excel Export

        /// <summary>
        /// Export sales report to Excel
        /// </summary>
        public bool ExportSalesReportToExcel(SalesReportDto report, string filePath)
        {
            try
            {
                var dataTable = CreateSalesReportDataTable(report);
                return ExportDataTableToExcel(dataTable, filePath, "Satış Hesabatı");
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Excel ixracı zamanı xəta baş verdi.");
                return false;
            }
        }

        /// <summary>
        /// Export debt report to Excel
        /// </summary>
        public bool ExportDebtReportToExcel(DebtReportDto report, string filePath)
        {
            try
            {
                var dataTable = CreateDebtReportDataTable(report);
                return ExportDataTableToExcel(dataTable, filePath, "Borc Hesabatı");
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Excel ixracı zamanı xəta baş verdi.");
                return false;
            }
        }

        /// <summary>
        /// Export repair analytics to Excel
        /// </summary>
        public bool ExportRepairAnalyticsToExcel(RepairAnalyticsDto report, string filePath)
        {
            try
            {
                var dataTable = CreateRepairAnalyticsDataTable(report);
                return ExportDataTableToExcel(dataTable, filePath, "Təmir Analitikası");
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Excel ixracı zamanı xəta baş verdi.");
                return false;
            }
        }

        #endregion

        #region CSV Export

        /// <summary>
        /// Export any DataTable to CSV
        /// </summary>
        public bool ExportDataTableToCSV(DataTable dataTable, string filePath)
        {
            try
            {
                using (var writer = new StreamWriter(filePath, false, Encoding.UTF8))
                {
                    // Write headers
                    var headers = dataTable.Columns.Cast<DataColumn>()
                        .Select(column => EscapeCsvField(column.ColumnName));
                    writer.WriteLine(string.Join(",", headers));

                    // Write data
                    foreach (DataRow row in dataTable.Rows)
                    {
                        var fields = row.ItemArray.Select(field => 
                            EscapeCsvField(field?.ToString() ?? string.Empty));
                        writer.WriteLine(string.Join(",", fields));
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "CSV ixracı zamanı xəta baş verdi.");
                return false;
            }
        }

        #endregion

        #region HTML/PDF Export

        /// <summary>
        /// Export sales report to HTML (for PDF conversion)
        /// </summary>
        public bool ExportSalesReportToHTML(SalesReportDto report, string filePath)
        {
            try
            {
                var html = GenerateSalesReportHTML(report);
                File.WriteAllText(filePath, html, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "HTML ixracı zamanı xəta baş verdi.");
                return false;
            }
        }

        /// <summary>
        /// Export debt report to HTML
        /// </summary>
        public bool ExportDebtReportToHTML(DebtReportDto report, string filePath)
        {
            try
            {
                var html = GenerateDebtReportHTML(report);
                File.WriteAllText(filePath, html, Encoding.UTF8);
                return true;
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "HTML ixracı zamanı xəta baş verdi.");
                return false;
            }
        }

        #endregion

        #region Helper Methods - DataTable Creation

        private DataTable CreateSalesReportDataTable(SalesReportDto report)
        {
            var table = new DataTable("Satış Hesabatı");
            
            // Summary section
            table.Columns.Add("Göstərici", typeof(string));
            table.Columns.Add("Dəyər", typeof(string));

            table.Rows.Add("Hesabat Növü", report.ReportType);
            table.Rows.Add("Başlanğıc Tarixi", report.StartDate.ToString("dd.MM.yyyy"));
            table.Rows.Add("Bitmə Tarixi", report.EndDate.ToString("dd.MM.yyyy"));
            table.Rows.Add("Ümumi Satış Sayı", report.TotalSales.ToString("N0"));
            table.Rows.Add("Ümumi Məbləğ", report.TotalAmount.ToString("C"));
            table.Rows.Add("Ümumi Endirim", report.TotalDiscount.ToString("C"));
            table.Rows.Add("Net Məbləğ", report.NetAmount.ToString("C"));
            table.Rows.Add("Orta Sifariş Dəyəri", report.AverageOrderValue.ToString("C"));
            table.Rows.Add("Endirim Faizi", $"{report.DiscountPercentage:F2}%");

            return table;
        }

        private DataTable CreateDebtReportDataTable(DebtReportDto report)
        {
            var table = new DataTable("Borc Hesabatı");
            
            table.Columns.Add("Müştəri Adı", typeof(string));
            table.Columns.Add("Ümumi Borc", typeof(decimal));
            table.Columns.Add("Ödənilən", typeof(decimal));
            table.Columns.Add("Qalan Borc", typeof(decimal));
            table.Columns.Add("Son Ödəniş", typeof(string));
            table.Columns.Add("Borc Sayı", typeof(int));

            foreach (var debt in report.CustomerDebts)
            {
                table.Rows.Add(
                    debt.CustomerName,
                    debt.TotalDebt,
                    debt.TotalPaid,
                    debt.RemainingDebt,
                    debt.LastPaymentDate?.ToString("dd.MM.yyyy") ?? "Yoxdur",
                    debt.DebtCount
                );
            }

            return table;
        }

        private DataTable CreateRepairAnalyticsDataTable(RepairAnalyticsDto report)
        {
            var table = new DataTable("Təmir Analitikası");
            
            table.Columns.Add("Təmir Növü", typeof(string));
            table.Columns.Add("Sayı", typeof(int));
            table.Columns.Add("Ümumi Məbləğ", typeof(decimal));
            table.Columns.Add("Orta Məbləğ", typeof(decimal));

            foreach (var repairType in report.RepairsByType)
            {
                table.Rows.Add(
                    repairType.RepairType,
                    repairType.Count,
                    repairType.TotalCost,
                    repairType.AverageCost
                );
            }

            return table;
        }

        #endregion

        #region Helper Methods - HTML Generation

        private string GenerateSalesReportHTML(SalesReportDto report)
        {
            var html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html><head>");
            html.AppendLine("<meta charset='utf-8'>");
            html.AppendLine("<title>Satış Hesabatı</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: Arial, sans-serif; margin: 20px; }");
            html.AppendLine("table { border-collapse: collapse; width: 100%; margin-top: 20px; }");
            html.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
            html.AppendLine("th { background-color: #f2f2f2; }");
            html.AppendLine(".header { text-align: center; margin-bottom: 30px; }");
            html.AppendLine(".summary { background-color: #f9f9f9; padding: 15px; margin-bottom: 20px; }");
            html.AppendLine("</style>");
            html.AppendLine("</head><body>");
            
            html.AppendLine("<div class='header'>");
            html.AppendLine("<h1>AzAgroPOS - Satış Hesabatı</h1>");
            html.AppendLine($"<p>{report.ReportType} Hesabatı</p>");
            html.AppendLine($"<p>{report.StartDate:dd.MM.yyyy} - {report.EndDate:dd.MM.yyyy}</p>");
            html.AppendLine("</div>");
            
            html.AppendLine("<div class='summary'>");
            html.AppendLine("<h3>Ümumi Məlumatlar</h3>");
            html.AppendLine($"<p><strong>Satış Sayı:</strong> {report.TotalSales:N0}</p>");
            html.AppendLine($"<p><strong>Ümumi Məbləğ:</strong> {report.TotalAmount:C}</p>");
            html.AppendLine($"<p><strong>Endirim:</strong> {report.TotalDiscount:C}</p>");
            html.AppendLine($"<p><strong>Net Məbləğ:</strong> {report.NetAmount:C}</p>");
            html.AppendLine($"<p><strong>Orta Sifariş:</strong> {report.AverageOrderValue:C}</p>");
            html.AppendLine("</div>");

            if (report.TopProducts?.Any() == true)
            {
                html.AppendLine("<h3>Ən Çox Satılan Məhsullar</h3>");
                html.AppendLine("<table>");
                html.AppendLine("<tr><th>Məhsul</th><th>Miqdar</th><th>Məbləğ</th><th>Satış Sayı</th></tr>");
                
                foreach (var product in report.TopProducts.Take(10))
                {
                    html.AppendLine($"<tr>");
                    html.AppendLine($"<td>{product.ProductName}</td>");
                    html.AppendLine($"<td>{product.TotalQuantity:N2}</td>");
                    html.AppendLine($"<td>{product.TotalAmount:C}</td>");
                    html.AppendLine($"<td>{product.SalesCount}</td>");
                    html.AppendLine($"</tr>");
                }
                html.AppendLine("</table>");
            }

            html.AppendLine($"<p style='margin-top: 30px; text-align: center; color: #666;'>");
            html.AppendLine($"Hesabat tarixi: {report.GeneratedDate:dd.MM.yyyy HH:mm}</p>");
            html.AppendLine("</body></html>");

            return html.ToString();
        }

        private string GenerateDebtReportHTML(DebtReportDto report)
        {
            var html = new StringBuilder();
            html.AppendLine("<!DOCTYPE html>");
            html.AppendLine("<html><head>");
            html.AppendLine("<meta charset='utf-8'>");
            html.AppendLine("<title>Borc Hesabatı</title>");
            html.AppendLine("<style>");
            html.AppendLine("body { font-family: Arial, sans-serif; margin: 20px; }");
            html.AppendLine("table { border-collapse: collapse; width: 100%; margin-top: 20px; }");
            html.AppendLine("th, td { border: 1px solid #ddd; padding: 8px; text-align: left; }");
            html.AppendLine("th { background-color: #f2f2f2; }");
            html.AppendLine(".header { text-align: center; margin-bottom: 30px; }");
            html.AppendLine(".summary { background-color: #f9f9f9; padding: 15px; margin-bottom: 20px; }");
            html.AppendLine("</style>");
            html.AppendLine("</head><body>");
            
            html.AppendLine("<div class='header'>");
            html.AppendLine("<h1>AzAgroPOS - Borc Hesabatı</h1>");
            html.AppendLine("</div>");
            
            html.AppendLine("<div class='summary'>");
            html.AppendLine("<h3>Ümumi Borc Statistikası</h3>");
            html.AppendLine($"<p><strong>Ümumi Borc:</strong> {report.TotalDebt:C}</p>");
            html.AppendLine($"<p><strong>Ödənilən:</strong> {report.TotalPaid:C}</p>");
            html.AppendLine($"<p><strong>Qalan Borc:</strong> {report.RemainingDebt:C}</p>");
            html.AppendLine($"<p><strong>Borclu Müştəri Sayı:</strong> {report.CustomersWithDebt}</p>");
            html.AppendLine($"<p><strong>Yığım Dərəcəsi:</strong> {report.CollectionRate:F1}%</p>");
            html.AppendLine("</div>");

            if (report.CustomerDebts?.Any() == true)
            {
                html.AppendLine("<h3>Müştəri Borcları</h3>");
                html.AppendLine("<table>");
                html.AppendLine("<tr><th>Müştəri</th><th>Ümumi Borc</th><th>Ödənilən</th><th>Qalan</th><th>Son Ödəniş</th></tr>");
                
                foreach (var debt in report.CustomerDebts)
                {
                    html.AppendLine($"<tr>");
                    html.AppendLine($"<td>{debt.CustomerName}</td>");
                    html.AppendLine($"<td>{debt.TotalDebt:C}</td>");
                    html.AppendLine($"<td>{debt.TotalPaid:C}</td>");
                    html.AppendLine($"<td>{debt.RemainingDebt:C}</td>");
                    html.AppendLine($"<td>{debt.LastPaymentDate?.ToString("dd.MM.yyyy") ?? "Yoxdur"}</td>");
                    html.AppendLine($"</tr>");
                }
                html.AppendLine("</table>");
            }

            html.AppendLine($"<p style='margin-top: 30px; text-align: center; color: #666;'>");
            html.AppendLine($"Hesabat tarixi: {report.GeneratedDate:dd.MM.yyyy HH:mm}</p>");
            html.AppendLine("</body></html>");

            return html.ToString();
        }

        #endregion

        #region Helper Methods - General

        private bool ExportDataTableToExcel(DataTable dataTable, string filePath, string sheetName)
        {
            try
            {
                // Simple CSV export (Excel can open CSV files)
                // For full Excel functionality, you would need a library like EPPlus or ClosedXML
                var csvPath = Path.ChangeExtension(filePath, ".csv");
                return ExportDataTableToCSV(dataTable, csvPath);
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "Excel ixracı zamanı xəta baş verdi.");
                return false;
            }
        }

        private string EscapeCsvField(string field)
        {
            if (string.IsNullOrEmpty(field))
                return string.Empty;

            // Escape quotes and wrap in quotes if necessary
            if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
            {
                field = field.Replace("\"", "\"\"");
                return $"\"{field}\"";
            }

            return field;
        }

        #endregion

        #region Export Dialog Helpers

        /// <summary>
        /// Show save file dialog and export debt report
        /// </summary>
        public void ShowExportDebtReportDialog(DebtReportDto report)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Title = "Borc Hesabatını İxrac Et";
                    saveDialog.Filter = "CSV Files (*.csv)|*.csv|HTML Files (*.html)|*.html";
                    saveDialog.FileName = $"Borc_Hesabati_{DateTime.Now:yyyyMMdd_HHmm}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        bool success = false;
                        
                        if (Path.GetExtension(saveDialog.FileName).ToLower() == ".csv")
                        {
                            success = ExportDebtReportToExcel(report, saveDialog.FileName);
                        }
                        else if (Path.GetExtension(saveDialog.FileName).ToLower() == ".html")
                        {
                            success = ExportDebtReportToHTML(report, saveDialog.FileName);
                        }

                        if (success)
                        {
                            ErrorHandlingService.ShowSuccess("Hesabat uğurla ixrac edildi!");
                            
                            // Ask if user wants to open the file
                            if (ErrorHandlingService.ShowConfirmation("Faylı açmaq istəyirsiniz?"))
                            {
                                System.Diagnostics.Process.Start(saveDialog.FileName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "İxrac zamanı xəta baş verdi.");
            }
        }

        /// <summary>
        /// Show save file dialog and export sales report
        /// </summary>
        public void ShowExportSalesReportDialog(SalesReportDto report)
        {
            try
            {
                using (var saveDialog = new SaveFileDialog())
                {
                    saveDialog.Title = "Satış Hesabatını İxrac Et";
                    saveDialog.Filter = "CSV Files (*.csv)|*.csv|HTML Files (*.html)|*.html";
                    saveDialog.FileName = $"Satis_Hesabati_{DateTime.Now:yyyyMMdd_HHmm}";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        bool success = false;
                        
                        if (Path.GetExtension(saveDialog.FileName).ToLower() == ".csv")
                        {
                            success = ExportSalesReportToExcel(report, saveDialog.FileName);
                        }
                        else if (Path.GetExtension(saveDialog.FileName).ToLower() == ".html")
                        {
                            success = ExportSalesReportToHTML(report, saveDialog.FileName);
                        }

                        if (success)
                        {
                            ErrorHandlingService.ShowSuccess("Hesabat uğurla ixrac edildi!");
                            
                            // Ask if user wants to open the file
                            if (ErrorHandlingService.ShowConfirmation("Faylı açmaq istəyirsiniz?"))
                            {
                                System.Diagnostics.Process.Start(saveDialog.FileName);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorHandlingService.HandleErrorStatic(ex, "İxrac zamanı xəta baş verdi.");
            }
        }

        #endregion

        #region IDisposable

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Clean up managed resources
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}