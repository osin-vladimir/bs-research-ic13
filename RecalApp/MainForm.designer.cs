namespace RecallApp
{
    partial class EyeX
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
            this.components = new System.ComponentModel.Container();
            this.behaviorMap = new EyeXFramework.Forms.BehaviorMap(this.components);
            this.start_btn = new System.Windows.Forms.Button();
            this.main_panel = new System.Windows.Forms.Panel();
            this.timer_pic = new System.Windows.Forms.Timer(this.components);
            this.timer_black = new System.Windows.Forms.Timer(this.components);
            this.menu_panel = new System.Windows.Forms.Panel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.scene_numb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pause_dur = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.scene_dur = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settings_apply_btn = new System.Windows.Forms.Button();
            this.create_set = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.personal_info_save_btn = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.age = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.female = new System.Windows.Forms.RadioButton();
            this.male = new System.Windows.Forms.RadioButton();
            this.menu_panel.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // start_btn
            // 
            this.start_btn.Location = new System.Drawing.Point(20, 26);
            this.start_btn.Name = "start_btn";
            this.start_btn.Size = new System.Drawing.Size(144, 79);
            this.start_btn.TabIndex = 11;
            this.start_btn.Text = "Начать тест";
            this.start_btn.UseVisualStyleBackColor = true;
            this.start_btn.Click += new System.EventHandler(this.start_btn_Click);
            // 
            // main_panel
            // 
            this.main_panel.BackColor = System.Drawing.Color.Black;
            this.main_panel.Location = new System.Drawing.Point(371, 408);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(418, 298);
            this.main_panel.TabIndex = 12;
            this.main_panel.Visible = false;
            // 
            // timer_pic
            // 
            this.timer_pic.Tick += new System.EventHandler(this.timer_pic_Tick);
            // 
            // timer_black
            // 
            this.timer_black.Tick += new System.EventHandler(this.timer_black_Tick);
            // 
            // menu_panel
            // 
            this.menu_panel.Controls.Add(this.groupBox4);
            this.menu_panel.Controls.Add(this.groupBox1);
            this.menu_panel.Controls.Add(this.start_btn);
            this.menu_panel.Location = new System.Drawing.Point(12, 12);
            this.menu_panel.Name = "menu_panel";
            this.menu_panel.Size = new System.Drawing.Size(946, 338);
            this.menu_panel.TabIndex = 17;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.scene_numb);
            this.groupBox4.Controls.Add(this.create_set);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.pause_dur);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.scene_dur);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.settings_apply_btn);
            this.groupBox4.Location = new System.Drawing.Point(549, 13);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(346, 309);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Настройки";
            // 
            // scene_numb
            // 
            this.scene_numb.Location = new System.Drawing.Point(175, 73);
            this.scene_numb.Name = "scene_numb";
            this.scene_numb.Size = new System.Drawing.Size(100, 22);
            this.scene_numb.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(172, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Количество композиций";
            // 
            // pause_dur
            // 
            this.pause_dur.Location = new System.Drawing.Point(20, 144);
            this.pause_dur.Name = "pause_dur";
            this.pause_dur.Size = new System.Drawing.Size(100, 22);
            this.pause_dur.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Время паузы";
            // 
            // scene_dur
            // 
            this.scene_dur.Location = new System.Drawing.Point(20, 73);
            this.scene_dur.Name = "scene_dur";
            this.scene_dur.Size = new System.Drawing.Size(100, 22);
            this.scene_dur.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Время композиции";
            // 
            // settings_apply_btn
            // 
            this.settings_apply_btn.Location = new System.Drawing.Point(20, 201);
            this.settings_apply_btn.Name = "settings_apply_btn";
            this.settings_apply_btn.Size = new System.Drawing.Size(106, 39);
            this.settings_apply_btn.TabIndex = 2;
            this.settings_apply_btn.Text = "Применить";
            this.settings_apply_btn.UseVisualStyleBackColor = true;
            this.settings_apply_btn.Click += new System.EventHandler(this.settings_apply_btn_Click);
            // 
            // create_set
            // 
            this.create_set.Location = new System.Drawing.Point(20, 246);
            this.create_set.Name = "create_set";
            this.create_set.Size = new System.Drawing.Size(106, 48);
            this.create_set.TabIndex = 21;
            this.create_set.Text = "Создать набор";
            this.create_set.UseVisualStyleBackColor = true;
            this.create_set.Click += new System.EventHandler(this.create_set_btn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.personal_info_save_btn);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(192, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 309);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Информация о тестируемом";
            // 
            // personal_info_save_btn
            // 
            this.personal_info_save_btn.Location = new System.Drawing.Point(6, 217);
            this.personal_info_save_btn.Name = "personal_info_save_btn";
            this.personal_info_save_btn.Size = new System.Drawing.Size(106, 39);
            this.personal_info_save_btn.TabIndex = 2;
            this.personal_info_save_btn.Text = "Сохранить";
            this.personal_info_save_btn.UseVisualStyleBackColor = true;
            this.personal_info_save_btn.Click += new System.EventHandler(this.personal_info_save_btn_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.age);
            this.groupBox3.Location = new System.Drawing.Point(6, 152);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 59);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Возраст";
            // 
            // age
            // 
            this.age.Location = new System.Drawing.Point(6, 24);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(40, 22);
            this.age.TabIndex = 0;
            this.age.TextChanged += new System.EventHandler(this.age_TextChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.female);
            this.groupBox2.Controls.Add(this.male);
            this.groupBox2.Location = new System.Drawing.Point(6, 44);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 100);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Пол";
            // 
            // female
            // 
            this.female.AutoSize = true;
            this.female.Location = new System.Drawing.Point(6, 57);
            this.female.Name = "female";
            this.female.Size = new System.Drawing.Size(42, 21);
            this.female.TabIndex = 1;
            this.female.TabStop = true;
            this.female.Text = "Ж";
            this.female.UseVisualStyleBackColor = true;
            // 
            // male
            // 
            this.male.AutoSize = true;
            this.male.Location = new System.Drawing.Point(6, 30);
            this.male.Name = "male";
            this.male.Size = new System.Drawing.Size(40, 21);
            this.male.TabIndex = 0;
            this.male.TabStop = true;
            this.male.Text = "М";
            this.male.UseVisualStyleBackColor = true;
            // 
            // EyeX
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 373);
            this.Controls.Add(this.menu_panel);
            this.Controls.Add(this.main_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EyeX";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EyeX";
            this.menu_panel.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private EyeXFramework.Forms.BehaviorMap behaviorMap;
        private System.Windows.Forms.Button start_btn;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Timer timer_pic;
        private System.Windows.Forms.Timer timer_black;
        private System.Windows.Forms.Panel menu_panel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton female;
        private System.Windows.Forms.RadioButton male;
        private System.Windows.Forms.Button personal_info_save_btn;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.Button create_set;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox pause_dur;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox scene_dur;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button settings_apply_btn;
        private System.Windows.Forms.TextBox scene_numb;
        private System.Windows.Forms.Label label3;
    }
}

