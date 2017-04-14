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
            this.right_pic_box = new System.Windows.Forms.PictureBox();
            this.trackBar = new System.Windows.Forms.TrackBar();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.heat_map_btn = new System.Windows.Forms.Button();
            this.ScrollCount = new System.Windows.Forms.Label();
            this.iRightPointCount = new System.Windows.Forms.Label();
            this.iLeftPointCount = new System.Windows.Forms.Label();
            this.Ticker = new System.Windows.Forms.Timer(this.components);
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.left_pic_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_pic_box)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // left_pic_box
            // 
            this.left_pic_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.left_pic_box.Location = new System.Drawing.Point(4, 3);
            this.left_pic_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.left_pic_box.Name = "left_pic_box";
            this.left_pic_box.Size = new System.Drawing.Size(1349, 936);
            this.left_pic_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.left_pic_box.TabIndex = 0;
            this.left_pic_box.TabStop = false;
            this.left_pic_box.Click += new System.EventHandler(this.left_pic_box_Click);
            // 
            // right_pic_box
            // 
            this.right_pic_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.right_pic_box.Location = new System.Drawing.Point(1364, 3);
            this.right_pic_box.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.right_pic_box.Name = "right_pic_box";
            this.right_pic_box.Size = new System.Drawing.Size(1349, 936);
            this.right_pic_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.right_pic_box.TabIndex = 1;
            this.right_pic_box.TabStop = false;
            // 
            // trackBar
            // 
            this.trackBar.Location = new System.Drawing.Point(475, 950);
            this.trackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar.Name = "trackBar";
            this.trackBar.Size = new System.Drawing.Size(1859, 90);
            this.trackBar.TabIndex = 2;
            this.trackBar.Scroll += new System.EventHandler(this.trackBar_Scroll);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // heat_map_btn
            // 
            this.heat_map_btn.Location = new System.Drawing.Point(4, 950);
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
            this.ScrollCount.Location = new System.Drawing.Point(1255, 1014);
            this.ScrollCount.Name = "ScrollCount";
            this.ScrollCount.Size = new System.Drawing.Size(207, 25);
            this.ScrollCount.TabIndex = 4;
            this.ScrollCount.Text = "Значение ползунка";
            // 
            // iRightPointCount
            // 
            this.iRightPointCount.AutoSize = true;
            this.iRightPointCount.Location = new System.Drawing.Point(1791, 1014);
            this.iRightPointCount.Name = "iRightPointCount";
            this.iRightPointCount.Size = new System.Drawing.Size(70, 25);
            this.iRightPointCount.TabIndex = 5;
            this.iRightPointCount.Text = "label2";
            // 
            // iLeftPointCount
            // 
            this.iLeftPointCount.AutoSize = true;
            this.iLeftPointCount.Location = new System.Drawing.Point(867, 1015);
            this.iLeftPointCount.Name = "iLeftPointCount";
            this.iLeftPointCount.Size = new System.Drawing.Size(70, 25);
            this.iLeftPointCount.TabIndex = 6;
            this.iLeftPointCount.Text = "label3";
            // 
            // Ticker
            // 
            this.Ticker.Interval = 4;
            this.Ticker.Tick += new System.EventHandler(this.Ticker_Tick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2465, 994);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(119, 45);
            this.button1.TabIndex = 7;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(2788, 1077);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.iLeftPointCount);
            this.Controls.Add(this.iRightPointCount);
            this.Controls.Add(this.ScrollCount);
            this.Controls.Add(this.heat_map_btn);
            this.Controls.Add(this.trackBar);
            this.Controls.Add(this.right_pic_box);
            this.Controls.Add(this.left_pic_box);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EyeX Analysis  Tool v 1.0";
            ((System.ComponentModel.ISupportInitialize)(this.left_pic_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.right_pic_box)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox left_pic_box;
        private System.Windows.Forms.PictureBox right_pic_box;
        private System.Windows.Forms.TrackBar trackBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button heat_map_btn;
        private System.Windows.Forms.Label ScrollCount;
        private System.Windows.Forms.Label iRightPointCount;
        private System.Windows.Forms.Label iLeftPointCount;
        private System.Windows.Forms.Timer Ticker;
        private System.Windows.Forms.Button button1;
    }
}