using OfficeOpenXml;
using System.Data;
using System.Reflection;

namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    public static class ExportHelper
    {
        static ExportHelper()
        {
            try
            {
                // EPPlus lisensiyasını qur - EPPlus 5.0+ tələb edir
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            }
            catch
            {
                // Əgər lisensiya quruluşunda xəta olarsa, davam et
                // Lisensiya ilk istifadə zamanı yenidən qurulacaq
            }
        }

        /// <summary>
        /// DataGridView məzmununu Excel faylına ixrac edir
        /// </summary>
        /// <param name="dataGridView">İxrac ediləcək DataGridView</param>
        /// <param name="fileName">Fayl adı (defolt: "export.xlsx")</param>
        public static void ExportToExcel(DataGridView dataGridView, string fileName = "export.xlsx")
        {
            try
            {
                // Lisensiya kontekstini qur (əgər static constructor işləməyibsə)
                if (ExcelPackage.LicenseContext == LicenseContext.Commercial)
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                }

                // Yeni Excel paketi yarat
                using ExcelPackage package = new();
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                // Başlıqları yaz
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    if (dataGridView.Columns[i].Visible)
                    {
                        worksheet.Cells[1, i + 1].Value = dataGridView.Columns[i].HeaderText;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                    }
                }

                // Məlumatları yaz
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    int excelColumn = 1;
                    for (int j = 0; j < dataGridView.Columns.Count; j++)
                    {
                        if (dataGridView.Columns[j].Visible)
                        {
                            object cellValue = dataGridView.Rows[i].Cells[j].Value;
                            worksheet.Cells[i + 2, excelColumn].Value = cellValue?.ToString() ?? string.Empty;
                            excelColumn++;
                        }
                    }
                }

                // Avtomatik sütun genişliyi
                worksheet.Cells.AutoFitColumns();

                // Faylı saxla
                byte[] fileBytes = package.GetAsByteArray();
                File.WriteAllBytes(fileName, fileBytes);

                MessageBox.Show($"Məlumatlar uğurla {fileName} faylına ixrac edildi.",
                    "İxrac Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İxrac edərkən xəta baş verdi: {ex.Message}",
                    "İxrac Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// İstənilən obyektlər siyahısını Excel faylına ixrac edir
        /// </summary>
        /// <typeparam name="T">Obyekt tipi</typeparam>
        /// <param name="data">İxrac ediləcək məlumatlar</param>
        /// <param name="fileName">Fayl adı</param>
        /// <param name="sheetName">Worksheet adı</param>
        public static void ExportToExcel<T>(IEnumerable<T> data, string fileName, string sheetName = "Data") where T : class
        {
            try
            {
                using ExcelPackage package = new();
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add(sheetName);

                // T tipinin xüsusiyyətlərini əldə et
                List<PropertyInfo> properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.CanRead)
                    .ToList();

                // Başlıqları yaz
                for (int i = 0; i < properties.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i].Name;
                    worksheet.Cells[1, i + 1].Style.Font.Bold = true;
                }

                // Məlumatları yaz
                List<T> dataList = data.ToList();
                for (int i = 0; i < dataList.Count; i++)
                {
                    for (int j = 0; j < properties.Count; j++)
                    {
                        object? value = properties[j].GetValue(dataList[i]);
                        worksheet.Cells[i + 2, j + 1].Value = value?.ToString() ?? string.Empty;
                    }
                }

                // Avtomatik sütun genişliyi
                worksheet.Cells.AutoFitColumns();

                // Faylı saxla
                byte[] fileBytes = package.GetAsByteArray();
                File.WriteAllBytes(fileName, fileBytes);

                MessageBox.Show($"Məlumatlar uğurla {fileName} faylına ixrac edildi.",
                    "İxrac Uğurlu", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"İxrac edərkən xəta baş verdi: {ex.Message}",
                    "İxrac Xətası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// DataGridView məzmununu PDF faylına ixrac etmək üçün dialoq göstərir
        /// </summary>
        /// <param name="dataGridView">İxrac ediləcək DataGridView</param>
        /// <param name="defaultFileName">Defolt fayl adı</param>
        public static void ShowExportDialog(DataGridView dataGridView, string defaultFileName = "export")
        {
            using SaveFileDialog saveFileDialog = new();
            saveFileDialog.Filter = "Excel Kitabları|*.xlsx|Bütün Fayllar|*.*";
            saveFileDialog.DefaultExt = "xlsx";
            saveFileDialog.FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                ExportToExcel(dataGridView, saveFileDialog.FileName);
            }
        }
    }
}