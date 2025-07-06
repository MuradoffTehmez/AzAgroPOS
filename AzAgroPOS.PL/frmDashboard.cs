using AzAgroPOS.BLL;
using AzAgroPOS.PL.Themes;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AzAgroPOS.PL
{
    public partial class frmDashboard : BaseForm
    {
        private readonly DashboardBLL _dashboardBll = new DashboardBLL();

        public frmDashboard()
        {
            InitializeComponent();
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            // BaseForm-dan gələn standart stillər tətbiq olunduqdan sonra,
            // bu formaya məxsus xüsusi stilləri və məlumatları yükləyirik.
            LoadStats();
            LoadSalesChart();
            ApplyThemeToDashboard();
        }

        /// <summary>
        /// Statistik göstəriciləri bazadan yükləyir və müvafiq Labellərə yazır.
        /// </summary>
        private void LoadStats()
        {
            try
            {
                var stats = _dashboardBll.GetDashboardStats();

                lblGunlukSatis.Text = stats.BugunkuSatisSayi.ToString();
                lblGunlukMebleg.Text = stats.BugunkuSatisMeblegi.ToString("F2") + " ₼";
                lblAktivTemir.Text = stats.AktivTemirSayi.ToString();
                lblKritikStok.Text = stats.KritikStokdaMehsulSayi.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Statistik məlumatlar yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Son 7 günün satış məlumatlarını bazadan alaraq qrafiki yaradır və doldurur.
        /// </summary>
        private void LoadSalesChart()
        {
            try
            {
                var salesData = _dashboardBll.GetSalesForLast7Days();

                // Qrafiki hər dəfə yenidən qururuq
                chartSales.Series.Clear();
                chartSales.ChartAreas.Clear();
                chartSales.Titles.Clear();

                // Qrafik sahəsini (ChartArea) yaradırıq
                ChartArea chartArea = new ChartArea("MainArea");
                chartArea.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
                chartArea.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gainsboro;
                chartArea.AxisX.LabelStyle.Font = new Font("Segoe UI", 8F);
                chartArea.AxisY.LabelStyle.Font = new Font("Segoe UI", 8F);
                chartArea.AxisY.LabelStyle.Format = "F0' ₼'";
                chartSales.ChartAreas.Add(chartArea);

                // Başlıq əlavə edirik
                chartSales.Titles.Add(new Title(
                    "Son 7 Günün Satışları",
                    Docking.Top,
                    new Font("Segoe UI", 12F, FontStyle.Bold),
                    Color.Black
                ));

                // Məlumat seriyasını (Series) yaradırıq
                Series series = new Series("Satışlar")
                {
                    ChartType = SeriesChartType.Column, // Sütunlu qrafik
                    IsValueShownAsLabel = true,
                    LabelFormat = "F0"
                };

                // Məlumatları qrafikə nöqtə olaraq əlavə edirik
                foreach (var day in salesData)
                {
                    series.Points.AddXY(day.Key.ToString("dd MMM"), day.Value);
                }

                chartSales.Series.Add(series);
                chartSales.Legends.Clear(); // Tək seriya olduğu üçün legend-i gizlədirik
            }
            catch (Exception ex)
            {
                MessageBox.Show("Satış qrafiki yüklənərkən xəta baş verdi: " + ex.Message, "Xəta", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bu formaya məxsus xüsusi elementlərin rənglərini mövcud temaya uyğunlaşdırır.
        /// </summary>
        private void ApplyThemeToDashboard()
        {
            // Panellərin arxa fonu
            panelSalesCount.BackColor = ThemeManager.BackgroundSecondary;
            panelSalesAmount.BackColor = ThemeManager.BackgroundSecondary;
            panelActiveRepairs.BackColor = ThemeManager.BackgroundSecondary;
            panelCriticalStock.BackColor = ThemeManager.BackgroundSecondary;

            // Başlıq Labellərinin rəngi
            label2.ForeColor = ThemeManager.TextColor;
            label4.ForeColor = ThemeManager.TextColor;
            label6.ForeColor = ThemeManager.TextColor;
            label8.ForeColor = ThemeManager.TextColor;

            // Qrafikin rəngləri
            chartSales.BackColor = ThemeManager.Background;
            chartSales.ChartAreas[0].BackColor = ThemeManager.Background;
            chartSales.Titles[0].ForeColor = ThemeManager.TextColor;
            chartSales.ChartAreas[0].AxisX.LabelStyle.ForeColor = ThemeManager.TextColor;
            chartSales.ChartAreas[0].AxisY.LabelStyle.ForeColor = ThemeManager.TextColor;
            chartSales.ChartAreas[0].AxisX.LineColor = ThemeManager.Secondary;
            chartSales.ChartAreas[0].AxisY.LineColor = ThemeManager.Secondary;

            // Qrafikdəki sütunların rəngi
            if (chartSales.Series.Count > 0)
            {
                chartSales.Series[0].Color = ThemeManager.Success;
                chartSales.Series[0].LabelForeColor = ThemeManager.TextColor;
            }
        }

    }
}