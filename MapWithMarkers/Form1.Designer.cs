namespace MapWithMarkers
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gMapCtrl = new GMap.NET.WindowsForms.GMapControl();
            this.b_saveInDB = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gMapCtrl
            // 
            this.gMapCtrl.Bearing = 0F;
            this.gMapCtrl.CanDragMap = true;
            this.gMapCtrl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapCtrl.GrayScaleMode = false;
            this.gMapCtrl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapCtrl.LevelsKeepInMemory = 5;
            this.gMapCtrl.Location = new System.Drawing.Point(13, 13);
            this.gMapCtrl.MarkersEnabled = true;
            this.gMapCtrl.MaxZoom = 2;
            this.gMapCtrl.MinZoom = 2;
            this.gMapCtrl.MouseWheelZoomEnabled = true;
            this.gMapCtrl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapCtrl.Name = "gMapCtrl";
            this.gMapCtrl.NegativeMode = false;
            this.gMapCtrl.PolygonsEnabled = true;
            this.gMapCtrl.RetryLoadTile = 0;
            this.gMapCtrl.RoutesEnabled = true;
            this.gMapCtrl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapCtrl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapCtrl.ShowTileGridLines = false;
            this.gMapCtrl.Size = new System.Drawing.Size(672, 437);
            this.gMapCtrl.TabIndex = 0;
            this.gMapCtrl.Zoom = 0D;
            this.gMapCtrl.Load += new System.EventHandler(this.gMapCtrl_Load);
            this.gMapCtrl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapCtrl_MouseDown);
            this.gMapCtrl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMapCtrl_MouseUp);
            // 
            // b_saveInDB
            // 
            this.b_saveInDB.Location = new System.Drawing.Point(692, 13);
            this.b_saveInDB.Name = "b_saveInDB";
            this.b_saveInDB.Size = new System.Drawing.Size(96, 23);
            this.b_saveInDB.TabIndex = 1;
            this.b_saveInDB.Text = "Запись в базу";
            this.b_saveInDB.UseVisualStyleBackColor = true;
            this.b_saveInDB.Click += new System.EventHandler(this.b_saveInDB_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(800, 471);
            this.Controls.Add(this.b_saveInDB);
            this.Controls.Add(this.gMapCtrl);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private GMap.NET.WindowsForms.GMapControl gMapCtrl;
        private System.Windows.Forms.Button b_saveInDB;
    }
}

