namespace AzAgroPOS.Teqdimat.Yardimcilar
{
    public static class DataGridViewHelper
    {
        public static void StilVerDataGridView(DataGridView grid, Color? headerBack = null, Color? selectionBack = null, Color? altRow = null)
        {
            if (!headerBack.HasValue) headerBack = Color.FromArgb(33, 150, 243);
            if (!selectionBack.HasValue) selectionBack = Color.FromArgb(187, 222, 251);
            if (!altRow.HasValue) altRow = Color.FromArgb(245, 245, 245);

            grid.BackgroundColor = Color.White;
            grid.BorderStyle = BorderStyle.None;
            grid.RowHeadersVisible = false;
            grid.AllowUserToResizeRows = false;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.GridColor = Color.FromArgb(230, 230, 230);

            grid.ColumnHeadersDefaultCellStyle.BackColor = headerBack.Value;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersHeight = 40;

            grid.DefaultCellStyle.BackColor = Color.White;
            grid.DefaultCellStyle.ForeColor = Color.Black;
            grid.DefaultCellStyle.SelectionBackColor = selectionBack.Value;
            grid.DefaultCellStyle.SelectionForeColor = Color.Black;
            grid.DefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            grid.DefaultCellStyle.Padding = new Padding(5, 3, 5, 3);

            grid.AlternatingRowsDefaultCellStyle.BackColor = altRow.Value;

            grid.RowTemplate.Height = 35;
        }
    }
}