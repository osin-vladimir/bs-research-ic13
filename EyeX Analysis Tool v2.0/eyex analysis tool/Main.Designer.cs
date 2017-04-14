namespace EyeX_Analysis_Tool
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            this.left_pic_box = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.heat_map_btn = new System.Windows.Forms.Button();
            this.ScrollCount = new System.Windows.Forms.Label();
            this.Ticker = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lDataCount = new System.Windows.Forms.Label();
            this.lInfo = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.TickSpeed = new System.Windows.Forms.TrackBar();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.left_pic_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TickSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // left_pic_box
            // 
            this.left_pic_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.left_pic_box.Location = new System.Drawing.Point(4, 3);
            this.left_pic_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.left_pic_box.Name = "left_pic_box";
            this.left_pic_box.Size = new System.Drawing.Size(1920, 1080);
            this.left_pic_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_pic_box.TabIndex = 0;
            this.left_pic_box.TabStop = false;
            this.left_pic_box.Click += new System.EventHandler(this.left_pic_box_Click);
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(4, 1102);
            this.trackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(1920, 90);
            this.trackBar.TabIndex = 2;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // heat_map_btn
            // 
            this.heat_map_btn.Location = new System.Drawing.Point(1950, 3);
            this.heat_map_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.heat_map_btn.Name = "heat_map_btn";
            this.heat_map_btn.Size = new System.Drawing.Size(166, 108);
            this.heat_map_btn.TabIndex = 3;
            this.heat_map_btn.Text = "Heat Map";
            this.heat_map_btn.UseVisualStyleBackColor = true;
            this.heat_map_btn.Click += new System.EventHandler(this.heat_map_btn_Click);
            // 
            // ScrollCount
            // 
            this.ScrollCount.AutoSize = true;
            this.ScrollCount.Location = new System.Drawing.Point(1945, 1102);
            this.ScrollCount.Name = "ScrollCount";
            this.ScrollCount.Size = new System.Drawing.Size(207, 25);
            this.ScrollCount.TabIndex = 4;
            this.ScrollCount.Text = "Scroll Value";
            // 
            // Ticker
            // 
            this.Ticker.Interval = 60;
            this.Ticker.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1950, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 67);
            this.button1.TabIndex = 7;
            this.button1.Text = "Start/Stop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1950, 337);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 179);
            this.button2.TabIndex = 8;
            this.button2.Text = "Add tracking data";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1950, 522);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(166, 83);
            this.button3.TabIndex = 9;
            this.button3.Text = "Clear tracking data";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1945, 773);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Loaded: ";
            // 
            // lDataCount
            // 
            this.lDataCount.AutoSize = true;
            this.lDataCount.Location = new System.Drawing.Point(2078, 773);
            this.lDataCount.Name = "lDataCount";
            this.lDataCount.Size = new System.Drawing.Size(24, 25);
            this.lDataCount.TabIndex = 11;
            this.lDataCount.Text = "0";
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Location = new System.Drawing.Point(1945, 835);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(19, 25);
            this.lInfo.TabIndex = 12;
            this.lInfo.Text = "-";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1950, 630);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(166, 88);
            this.button4.TabIndex = 13;
            this.button4.Text = "Save image";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // TickSpeed
            // 
            this.TickSpeed.LargeChange = 50;
            this.TickSpeed.Location = new System.Drawing.Point(579, 1191);
            this.TickSpeed.Maximum = 400;
            this.TickSpeed.Minimum = 10;
            this.TickSpeed.Name = "TickSpeed";
            this.TickSpeed.Size = new System.Drawing.Size(636, 90);
            this.TickSpeed.SmallChange = 10;
            this.TickSpeed.TabIndex = 14;
            this.TickSpeed.Value = 40;
            this.TickSpeed.Scroll += new System.EventHandler(this.TickSpeed_Scroll);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(1950, 203);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(166, 111);
            this.button5.TabIndex = 15;
            this.button5.Text = "Show/Hide tracks";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2136, 1293);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.TickSpeed);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.lInfo);
            this.Controls.Add(this.lDataCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ScrollCount);
            this.Controls.Add(this.heat_map_btn);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.left_pic_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EyeX Analysis  Tool v 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.left_pic_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TickSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox left_pic_box;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button heat_map_btn;
        private System.Windows.Forms.Label ScrollCount;
        private System.Windows.Forms.Timer Ticker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lDataCount;
        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TrackBar TickSpeed;
        private System.Windows.Forms.Button button5;
    }
}