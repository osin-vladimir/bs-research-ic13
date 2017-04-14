using EyeXFramework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Tobii.EyeX.Framework;

namespace RecallApp
{
    public partial class EyeX : Form
    {
        GazePoint points;
        Person person;
        ReportHelper report;

        public bool tracking = false;

        public  string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

        public int screen_w = Screen.PrimaryScreen.Bounds.Width;
        public int screen_h = Screen.PrimaryScreen.Bounds.Height;

        public string root;
        public string[] directories;
        public string[,] files;

        public int set_counter = 0;
        public int h_counter = 0;

        public int img_width = 940;
        public int img_height = 520;

        //settings
        //6000/1500/37
        public int scene_number = 5;
        public int scene_duration = 6000;
        public int pause_duration = 1500;

        public struct Person
        {
            public int id;
            public int age;
            public string sex;
        }

        public EyeX()
        {
            InitializeComponent();
            report = new ReportHelper();
            start_btn.Enabled = false;

            //list of gazed points
            points = new GazePoint();
            points.list = new List<PointF>();
            points.times = new List<double>();
            person = new Person();

            //add eye-gaze interaction behaviors to the panels on the form.
            Program.EyeXHost.Connect(behaviorMap);
            behaviorMap.Add(main_panel, new GazeAwareBehavior(OnGaze));

            //timer setings
            timer_pic = new Timer();
            timer_pic.Interval = pause_duration;
            timer_pic.Tick += new EventHandler(this.timer_pic_Tick);

            timer_black = new Timer();
            timer_black.Interval = scene_duration;
            timer_black.Tick += new EventHandler(this.timer_black_Tick);

            scene_numb.Text = scene_number.ToString();
            scene_dur.Text = pause_duration.ToString();
            pause_dur.Text = scene_duration.ToString();
        }

        public void SetImages(int h)
        {
            main_panel.Size = new Size(EyeX.ActiveForm.Width, EyeX.ActiveForm.Height);
            main_panel.Location = new Point(0, 0);
            main_panel.BackgroundImage = Image.FromFile(desktop + "\\results\\current_set\\" + h.ToString() + ".jpeg");
            main_panel.Visible = true;
        }

        public void Draw(List<PointF> list)
        {
            var image = Image.FromFile(desktop + "\\results\\current_set\\" + h_counter.ToString() + ".jpeg");

            Graphics g = Graphics.FromImage(image);
            if (list != null && list.Count > 0)
            {
                g.DrawCurve(new Pen(new SolidBrush(Color.FromArgb(255, 0, 0, 255)), 5), list.ToArray());

                //draw points on this set of images
                double c = 0;
                double step = 255 / (double)list.Count;

                foreach (var item in list)
                {
                    Color color = Color.FromArgb(255, (int)c, 0, 0);
                    g.FillEllipse(new SolidBrush(color), item.X, item.Y, 10, 10);
                    c = c + step;
                }

                g.FillRectangle(new SolidBrush(Color.FloralWhite), list[0].X, list[0].Y, 30, 30);
                g.FillRectangle(new SolidBrush(Color.Green), list[list.Count - 1].X, list[list.Count - 1].Y, 30, 30);
            }

            //save this set
            image.Save(desktop + "\\results\\" + Properties.Settings.Default.id.ToString() + "\\img\\" + h_counter.ToString() + ".jpeg");
            points.Save(desktop + "\\results\\" + Properties.Settings.Default.id.ToString() + "\\data\\data-" + h_counter.ToString() + ".txt");

            points.Clear();
            list.Clear();
            h_counter++;
        }

        public void menu(string status)
        {
            if (status == "show")
            {
                menu_panel.Visible = true;
                main_panel.Visible = false;
                ActiveForm.FormBorderStyle = FormBorderStyle.FixedSingle;
                ActiveForm.WindowState = FormWindowState.Normal;
                ActiveForm.BackColor = SystemColors.Control;
            }
            else if (status == "hide")
            {
                menu_panel.Visible = false;

                ActiveForm.FormBorderStyle = FormBorderStyle.None;
                ActiveForm.WindowState = FormWindowState.Maximized;
                ActiveForm.BackColor = Color.Black;
            }

        }

        private void timer_pic_Tick(object sender, System.EventArgs e)
        {
            if (h_counter == scene_number)
            {
                menu("show");
                Cursor.Show();
                timer_black.Stop();
                timer_pic.Stop();

                // saving report
                report.CreateReport(desktop + "\\results\\" + person.id.ToString(), scene_number, person);
                Properties.Settings.Default.id++;
                Properties.Settings.Default.Save();

                start_btn.Enabled = false;
                age.Text = "";
                h_counter = 0;
                set_counter = 0;

                return;
            }

            points = new GazePoint();
            SetImages(h_counter);

            tracking = true;
            timer_black.Start();
            timer_pic.Stop();
        }

        private void timer_black_Tick(object sender, System.EventArgs e)
        {
            tracking = false;
            main_panel.Visible = false;

            Draw(points.list);

            timer_pic.Start();
            timer_black.Stop();

        }

        public void load_img()
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Выберите папку содержащую наборы изображений по гипотезам";
                dialog.ShowNewFolderButton = false;
                dialog.RootFolder = Environment.SpecialFolder.Desktop;

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    root = dialog.SelectedPath;
                    directories = Directory.GetDirectories(root);
                    if (directories.Count() > 0)
                    {
                        int set_size = 0;
                        for (int i = 0; i < directories.Count(); i++)
                            set_size = set_size + Directory.GetDirectories(directories[i]).Count();
                    
                        files = new string[set_size, 4];
                        var c = 0;
                        for (var i = 0; i < directories.Count(); i++)
                        {
                            var d = Directory.GetDirectories(directories[i]);

                            for (var j = 0; j < d.Count(); j++)
                            {
                                var f = Directory.GetFiles(d[j]);

                                for (var k = 0; k < f.Count(); k++)
                                    files[c, k] = f[k];
                                c++;
                            }
                        }
                    }
                }
            }
        }

        /// <summary> 
        /// Create new set from img set(combine 4 pictures into 1)
        /// </summary>
        public void CreateCurrentSet()
        {
            if (Directory.Exists(desktop + "\\results\\current_set"))
            {
                if (Directory.GetFiles(desktop + "\\results\\current_set").Count() > 0)
                {
                    MessageBox.Show("Очистите директорию: " + desktop + "\\results\\current_set");
                    return;
                }
             
            }

            Directory.CreateDirectory(desktop + "\\results\\current_set");
            for (int i = 0; i < files.GetLength(0); i++)
            {
                int s = 0;
                Bitmap bmp = new Bitmap(screen_w, screen_h);
                Graphics g = Graphics.FromImage(bmp);

                g.DrawImage(Image.FromFile(files[i, s]), 0, 0, img_width, img_height);
                s++;
                g.DrawImage(Image.FromFile(files[i, s]), screen_w - img_width, 0, img_width, img_height);
                s++;
                g.DrawImage(Image.FromFile(files[i, s]), screen_w - img_width, screen_h - img_height, img_width, img_height);
                s++;
                g.DrawImage(Image.FromFile(files[i, s]), 0, screen_h - img_height, img_width, img_height);
                g.Dispose();
                bmp.Save(desktop + "\\results\\current_set\\" + i.ToString() + ".jpeg", ImageFormat.Jpeg);
                bmp.Dispose();
            }
        }

        private void age_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(age.Text, "[^0-9]"))
            {
                MessageBox.Show("Вводите только цифры");
                age.Text = "";
            }
        }

        /// <summary>
        /// menu buttons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void start_btn_Click(object sender, System.EventArgs e)
        {
            menu("hide");
            Cursor.Hide();
            timer_pic.Start();

            //result dir 
            Directory.CreateDirectory(desktop + "\\results\\" + Properties.Settings.Default.id.ToString());
            Directory.CreateDirectory(desktop + "\\results\\" + Properties.Settings.Default.id.ToString() + "\\img");
            Directory.CreateDirectory(desktop + "\\results\\" + Properties.Settings.Default.id.ToString() + "\\data");
        }

        private void create_set_btn_Click(object sender, EventArgs e)
        {
            load_img();
            CreateCurrentSet();
        }

        private void personal_info_save_btn_Click(object sender, EventArgs e)
        {
            if (male.Checked)
                person.sex = male.Text;
            else if (female.Checked)
                person.sex = female.Text;
            else
                MessageBox.Show("Для продолжения, укажите свой пол");

            if (age.TextLength > 2 || age.TextLength == 0 || int.Parse(age.Text) == 0)
                MessageBox.Show("Укажите свой возраст");
            else
                person.age = int.Parse(age.Text);

            person.id = Properties.Settings.Default.id;
            start_btn.Enabled = true;
        }

        private void settings_apply_btn_Click(object sender, EventArgs e)
        {
            timer_pic.Interval = int.Parse(pause_dur.Text);
            timer_black.Interval = int.Parse(scene_dur.Text);
            scene_number = int.Parse(scene_numb.Text);
        }

        /// <summary>
        /// Get points from eye-tracker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnGaze(object sender, GazeAwareEventArgs e)
        {
            var panel = sender as Panel;

            if (panel != null && tracking)
            {
                if (e.HasGaze)
                {
                    var lightlyFilteredGazeDataStream = Program.EyeXHost.CreateGazePointDataStream(GazePointDataMode.LightlyFiltered);

                    // Write the data to the GazePoints list
                    lightlyFilteredGazeDataStream.Next += (s, r) => points.Add(new PointF((float)r.X, (float)r.Y), r.Timestamp);
                }
            }
        }

       
    }
}


