namespace AzAgroPOS.PL
{
    partial class frmDashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.tlpStats = new System.Windows.Forms.TableLayoutPanel();
            this.panelSalesCount = new System.Windows.Forms.Panel();
            this.lblGunlukSatis = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelSalesAmount = new System.Windows.Forms.Panel();
            this.lblGunlukMebleg = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelActiveRepairs = new System.Windows.Forms.Panel();
            this.lblAktivTemir = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panelCriticalStock = new System.Windows.Forms.Panel();
            this.lblKritikStok = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.chartSales = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tlpStats.SuspendLayout();
            this.panelSalesCount.SuspendLayout();
            this.panelSalesAmount.SuspendLayout();
            this.panelActiveRepairs.SuspendLayout();
            this.panelCriticalStock.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpStats
            // 
            this.tlpStats.ColumnCount = 4;
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpStats.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpStats.Controls.Add(this.panelSalesCount, 0, 0);
            this.tlpStats.Controls.Add(this.panelSalesAmount, 1, 0);
            this.tlpStats.Controls.Add(this.panelActiveRepairs, 2, 0);
            this.tlpStats.Controls.Add(this.panelCriticalStock, 3, 0);
            this.tlpStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.tlpStats.Location = new System.Drawing.Point(0, 0);
            this.tlpStats.Name = "tlpStats";
            this.tlpStats.Padding = new System.Windows.Forms.Padding(10);
            this.tlpStats.RowCount = 1;
            this.tlpStats.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpStats.Size = new System.Drawing.Size(1000, 150);
            this.tlpStats.TabIndex = 0;
            // 
            // panelSalesCount
            // 
            this.panelSalesCount.BackColor = System.Drawing.Color.White;
            this.panelSalesCount.Controls.Add(this.lblGunlukSatis);
            this.panelSalesCount.Controls.Add(this.label2);
            this.panelSalesCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSalesCount.Location = new System.Drawing.Point(13, 13);
            this.panelSalesCount.Name = "panelSalesCount";
            this.panelSalesCount.Size = new System.Drawing.Size(239, 124);
            this.panelSalesCount.TabIndex = 0;
            // 
            // lblGunlukSatis
            // 
            this.lblGunlukSatis.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGunlukSatis.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGunlukSatis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblGunlukSatis.Location = new System.Drawing.Point(3, 45);
            this.lblGunlukSatis.Name = "lblGunlukSatis";
            this.lblGunlukSatis.Size = new System.Drawing.Size(233, 50);
            this.lblGunlukSatis.TabIndex = 1;
            this.lblGunlukSatis.Text = "0";
            this.lblGunlukSatis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Bugünkü Satış Sayı";
            // 
            // panelSalesAmount
            // 
            this.panelSalesAmount.BackColor = System.Drawing.Color.White;
            this.panelSalesAmount.Controls.Add(this.lblGunlukMebleg);
            this.panelSalesAmount.Controls.Add(this.label4);
            this.panelSalesAmount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSalesAmount.Location = new System.Drawing.Point(258, 13);
            this.panelSalesAmount.Name = "panelSalesAmount";
            this.panelSalesAmount.Size = new System.Drawing.Size(239, 124);
            this.panelSalesAmount.TabIndex = 1;
            // 
            // lblGunlukMebleg
            // 
            this.lblGunlukMebleg.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblGunlukMebleg.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGunlukMebleg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblGunlukMebleg.Location = new System.Drawing.Point(3, 45);
            this.lblGunlukMebleg.Name = "lblGunlukMebleg";
            this.lblGunlukMebleg.Size = new System.Drawing.Size(233, 50);
            this.lblGunlukMebleg.TabIndex = 1;
            this.lblGunlukMebleg.Text = "0.00 ₼";
            this.lblGunlukMebleg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bugünkü Satış Məbləği";
            // 
            // panelActiveRepairs
            // 
            this.panelActiveRepairs.BackColor = System.Drawing.Color.White;
            this.panelActiveRepairs.Controls.Add(this.lblAktivTemir);
            this.panelActiveRepairs.Controls.Add(this.label6);
            this.panelActiveRepairs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelActiveRepairs.Location = new System.Drawing.Point(503, 13);
            this.panelActiveRepairs.Name = "panelActiveRepairs";
            this.panelActiveRepairs.Size = new System.Drawing.Size(239, 124);
            this.panelActiveRepairs.TabIndex = 2;
            // 
            // lblAktivTemir
            // 
            this.lblAktivTemir.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblAktivTemir.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAktivTemir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(126)))), ((int)(((byte)(49)))));
            this.lblAktivTemir.Location = new System.Drawing.Point(3, 45);
            this.lblAktivTemir.Name = "lblAktivTemir";
            this.lblAktivTemir.Size = new System.Drawing.Size(233, 50);
            this.lblAktivTemir.TabIndex = 1;
            this.lblAktivTemir.Text = "0";
            this.lblAktivTemir.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 11);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(149, 25);
            this.label6.TabIndex = 0;
            this.label6.Text = "Aktiv Təmirlər";
            // 
            // panelCriticalStock
            // 
            this.panelCriticalStock.BackColor = System.Drawing.Color.White;
            this.panelCriticalStock.Controls.Add(this.lblKritikStok);
            this.panelCriticalStock.Controls.Add(this.label8);
            this.panelCriticalStock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCriticalStock.Location = new System.Drawing.Point(748, 13);
            this.panelCriticalStock.Name = "panelCriticalStock";
            this.panelCriticalStock.Size = new System.Drawing.Size(239, 124);
            this.panelCriticalStock.TabIndex = 3;
            // 
            // lblKritikStok
            // 
            this.lblKritikStok.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblKritikStok.Font = new System.Drawing.Font("Segoe UI", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblKritikStok.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.lblKritikStok.Location = new System.Drawing.Point(3, 45);
            this.lblKritikStok.Name = "lblKritikStok";
            this.lblKritikStok.Size = new System.Drawing.Size(233, 50);
            this.lblKritikStok.TabIndex = 1;
            this.lblKritikStok.Text = "0";
            this.lblKritikStok.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 25);
            this.label8.TabIndex = 0;
            this.label8.Text = "Kritik Stok";
            // 
            // chartSales
            // 
            chartArea1.Name = "ChartArea1";
            this.chartSales.ChartAreas.Add(chartArea1);
            this.chartSales.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chartSales.Legends.Add(legend1);
            this.chartSales.Location = new System.Drawing.Point(0, 150);
            this.chartSales.Name = "chartSales";
            this.chartSales.Padding = new System.Windows.Forms.Padding(10);
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartSales.Series.Add(series1);
            this.chartSales.Size = new System.Drawing.Size(1000, 550);
            this.chartSales.TabIndex = 1;
            this.chartSales.Text = "chart1";
            // 
            // frmDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 700);
            this.Controls.Add(this.chartSales);
            this.Controls.Add(this.tlpStats);
            this.Name = "frmDashboard";
            this.Text = "Ana Səhifə";
            this.Load += new System.EventHandler(this.frmDashboard_Load);
            this.tlpStats.ResumeLayout(false);
            this.panelSalesCount.ResumeLayout(false);
            this.panelSalesCount.PerformLayout();
            this.panelSalesAmount.ResumeLayout(false);
            this.panelSalesAmount.PerformLayout();
            this.panelActiveRepairs.ResumeLayout(false);
            this.panelActiveRepairs.PerformLayout();
            this.panelCriticalStock.ResumeLayout(false);
            this.panelCriticalStock.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSales)).EndInit();
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpStats;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSales;
        private System.Windows.Forms.Panel panelSalesCount;
        private System.Windows.Forms.Label lblGunlukSatis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelSalesAmount;
        private System.Windows.Forms.Label lblGunlukMebleg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panelActiveRepairs;
        private System.Windows.Forms.Label lblAktivTemir;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panelCriticalStock;
        private System.Windows.Forms.Label lblKritikStok;
        private System.Windows.Forms.Label label8;
    }
}