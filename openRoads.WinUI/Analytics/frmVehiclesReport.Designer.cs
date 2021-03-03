namespace openRoads.WinUI.Analytics
{
    partial class frmVehiclesReport
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmVehiclesReport));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbYear = new System.Windows.Forms.ComboBox();
            this.cmbVehicleManufacturer = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.dgvDisplay = new System.Windows.Forms.DataGridView();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.ReservationId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VehicleManufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReservationPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReservationYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(609, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(537, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Annual report of profits by vehicles";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 112);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Year:";
            // 
            // cmbYear
            // 
            this.cmbYear.FormattingEnabled = true;
            this.cmbYear.Location = new System.Drawing.Point(183, 112);
            this.cmbYear.Name = "cmbYear";
            this.cmbYear.Size = new System.Drawing.Size(230, 24);
            this.cmbYear.TabIndex = 2;
            // 
            // cmbVehicleManufacturer
            // 
            this.cmbVehicleManufacturer.FormattingEnabled = true;
            this.cmbVehicleManufacturer.Location = new System.Drawing.Point(183, 163);
            this.cmbVehicleManufacturer.Name = "cmbVehicleManufacturer";
            this.cmbVehicleManufacturer.Size = new System.Drawing.Size(230, 24);
            this.cmbVehicleManufacturer.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 163);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Vehicle manufacturer:";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(454, 133);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(199, 27);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "Apply filters";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // dgvDisplay
            // 
            this.dgvDisplay.AllowUserToAddRows = false;
            this.dgvDisplay.AllowUserToDeleteRows = false;
            this.dgvDisplay.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDisplay.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ReservationId,
            this.VehicleId,
            this.TotalPrice,
            this.VehicleManufacturer,
            this.ReservationPrice,
            this.ReservationYear});
            this.dgvDisplay.Location = new System.Drawing.Point(21, 226);
            this.dgvDisplay.Name = "dgvDisplay";
            this.dgvDisplay.ReadOnly = true;
            this.dgvDisplay.RowHeadersWidth = 51;
            this.dgvDisplay.RowTemplate.Height = 24;
            this.dgvDisplay.Size = new System.Drawing.Size(839, 492);
            this.dgvDisplay.TabIndex = 6;
            // 
            // chart1
            // 
            chartArea3.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            this.chart1.Legends.Add(legend3);
            this.chart1.Location = new System.Drawing.Point(953, 226);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Excel;
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "ReservationYear";
            this.chart1.Series.Add(series3);
            this.chart1.Size = new System.Drawing.Size(741, 492);
            this.chart1.TabIndex = 7;
            this.chart1.Text = "Chart";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(242, 751);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 45);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 18;
            this.pictureBox1.TabStop = false;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(21, 751);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(224, 45);
            this.btnExport.TabIndex = 17;
            this.btnExport.Text = "Export to PDF";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // ReservationId
            // 
            this.ReservationId.DataPropertyName = "ReservationId";
            this.ReservationId.HeaderText = "ReservationId";
            this.ReservationId.MinimumWidth = 6;
            this.ReservationId.Name = "ReservationId";
            this.ReservationId.ReadOnly = true;
            this.ReservationId.Visible = false;
            this.ReservationId.Width = 125;
            // 
            // VehicleId
            // 
            this.VehicleId.DataPropertyName = "VehicleId";
            this.VehicleId.HeaderText = "VehicleId";
            this.VehicleId.MinimumWidth = 6;
            this.VehicleId.Name = "VehicleId";
            this.VehicleId.ReadOnly = true;
            this.VehicleId.Visible = false;
            this.VehicleId.Width = 125;
            // 
            // TotalPrice
            // 
            this.TotalPrice.DataPropertyName = "TotalPrice";
            this.TotalPrice.HeaderText = "TotalPrice";
            this.TotalPrice.MinimumWidth = 6;
            this.TotalPrice.Name = "TotalPrice";
            this.TotalPrice.ReadOnly = true;
            this.TotalPrice.Visible = false;
            this.TotalPrice.Width = 125;
            // 
            // VehicleManufacturer
            // 
            this.VehicleManufacturer.DataPropertyName = "VehicleManufacturer";
            this.VehicleManufacturer.HeaderText = "Manufacturer";
            this.VehicleManufacturer.MinimumWidth = 6;
            this.VehicleManufacturer.Name = "VehicleManufacturer";
            this.VehicleManufacturer.ReadOnly = true;
            this.VehicleManufacturer.Width = 125;
            // 
            // ReservationPrice
            // 
            this.ReservationPrice.DataPropertyName = "ReservationPrice";
            this.ReservationPrice.HeaderText = "Price";
            this.ReservationPrice.MinimumWidth = 6;
            this.ReservationPrice.Name = "ReservationPrice";
            this.ReservationPrice.ReadOnly = true;
            this.ReservationPrice.Width = 125;
            // 
            // ReservationYear
            // 
            this.ReservationYear.DataPropertyName = "ReservationYear";
            this.ReservationYear.HeaderText = "Reservation year";
            this.ReservationYear.MinimumWidth = 6;
            this.ReservationYear.Name = "ReservationYear";
            this.ReservationYear.ReadOnly = true;
            this.ReservationYear.Width = 125;
            // 
            // frmVehiclesReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1752, 826);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.dgvDisplay);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.cmbVehicleManufacturer);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cmbYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmVehiclesReport";
            this.Text = "frmVehiclesReport";
            this.Load += new System.EventHandler(this.frmVehiclesReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDisplay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbYear;
        private System.Windows.Forms.ComboBox cmbVehicleManufacturer;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.DataGridView dgvDisplay;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationId;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleId;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn VehicleManufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReservationYear;
    }
}