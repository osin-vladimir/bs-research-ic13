//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace EyeX_Analysis_Tool
//{
//    public partial class Analysis : Form
//    {
//        public string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
//        public Image img_left;
//        public Image img_right;
//        public GazePoint points_left;
//        public GazePoint points_right;
//        public string filename;
//        public bool mergeTrackBar = false;

//        public Analysis()
//        {
//            InitializeComponent();
//        }

//        public Image Draw_Test(Image img, List<PointF> points)
//        {
//            Image new_img = (Image)img.Clone();
//            Graphics g = Graphics.FromImage(new_img);
            
//            //draw resulting curve
//            if (points != null && points.Count > 0)
//            {
//                g.DrawCurve(new Pen(new SolidBrush(Color.FromArgb(255, 0, 0, 255)), 5), points.ToArray());

//                //draw points on this set of images
//                double c = 0;
//                double step = 255 / points.Count;

//                foreach (var item in points)
//                {
//                    Color color = Color.FromArgb(255, (int)c, 0, 0);
//                    g.FillEllipse(new SolidBrush(color), item.X, item.Y, 25, 25);
//                    c = c + step;
//                }

//                g.FillRectangle(new SolidBrush(Color.FloralWhite), points[0].X, points[0].Y, 30, 30);
//                g.FillRectangle(new SolidBrush(Color.Green), points[points.Count - 1].X, points[points.Count - 1].Y, 30, 30);

//                return new_img;
//            }

//            return img;
//        }

//        private void pictureBox1_Click(object sender, EventArgs e)
//        {
//            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                try
//                {
//                    filename = openFileDialog.FileName;
//                    img_left = Image.FromFile(openFileDialog.FileName);
//                    pictureBox1.Image = img_left;
//                }
//                catch (Exception ex)
//                {

//                }

//            }


//            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                try
//                {
//                    //load points
//                    StreamReader sr = new StreamReader(openFileDialog.FileName);

//                    //fill in our gazepoints structure
//                    points_left = new GazePoint();
//                    string line = "";
//                    while ((line = sr.ReadLine()) != null)
//                    {
//                        var tmp = line.Split(new string[] { ", " }, StringSplitOptions.None);
//                        points_left.list.Add(new PointF(float.Parse(tmp[0]), float.Parse(tmp[1])));
//                        points_left.times.Add(double.Parse(tmp[2]));
//                    }

//                    trackBar1.Maximum = (int) (points_left.times.Max() - points_left.times.Min());
//                    trackBar1.Minimum = 0;
//                    trackBar1.Value = trackBar1.Minimum;
//                    trackBar1.TickFrequency = trackBar1.Maximum / 4;
//                    sr.Close();
//                }
//                catch (Exception ex)
//                {

//                }

//            }
//        }

//        private void pictureBox2_Click(object sender, EventArgs e)
//        {
//            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                try
//                {
//                    filename = openFileDialog.FileName;
//                    img_right = Image.FromFile(openFileDialog.FileName);
//                    pictureBox2.Image = img_right;
//                }
//                catch (Exception ex)
//                {

//                }

//            }


//            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                try
//                {
//                    //load points
//                    StreamReader sr = new StreamReader(openFileDialog.FileName);

//                    //fill in our gazepoints structure
//                    points_right = new GazePoint();
//                    string line = "";
//                    while ((line = sr.ReadLine()) != null)
//                    {
//                        var tmp = line.Split(new string[] { ", " }, StringSplitOptions.None);
//                        points_right.list.Add(new PointF(float.Parse(tmp[0]), float.Parse(tmp[1])));
//                        points_right.times.Add(double.Parse(tmp[2]));
//                    }
//                    sr.Close();

//                    trackBar2.Maximum = (int)(points_right.times.Max() - points_right.times.Min());
//                    trackBar2.Minimum = 0;
//                    trackBar2.Value = trackBar2.Minimum;
//                    trackBar2.TickFrequency = trackBar2.Maximum / 4;
//                    sr.Close();
//                }
//                catch (Exception ex)
//                {

//                }

//            }
//        }

//        private void button1_Click(object sender, EventArgs e)
//        {
//            var i = 0;
//            List<PointF> t_list = new List<PointF>();
//            while (points_left.times[i] - points_left.times[0] < trackBar1.Value)
//            {
//                t_list.Add(points_left.list[i]);
//                i++;
//            }

//            pictureBox1.Image = Draw_Test(img_left, t_list);

//            if (mergeTrackBar)
//            {
//                var j = 0;
//                List<PointF> tmp_list = new List<PointF>();
//                while (points_right.times[j] - points_right.times[0] < trackBar2.Value)
//                {
//                    tmp_list.Add(points_right.list[j]);
//                    j++;
//                }

//                pictureBox2.Image = Draw_Test(img_right, tmp_list);
//            }
//        }

//        private void button2_Click(object sender, EventArgs e)
//        {
//            var i = 0;
//            List<PointF> t_list = new List<PointF>();
//            while (points_right.times[i] - points_right.times[0] < trackBar2.Value)
//            {
//                t_list.Add(points_right.list[i]);
//                i++;
//            }

//            pictureBox2.Image = Draw_Test(img_right, t_list);

//            if (mergeTrackBar)
//            {
//                var j = 0;
//                List<PointF> tmp_list = new List<PointF>();
//                while (points_left.times[j] - points_left.times[0] < trackBar1.Value)
//                {
//                    tmp_list.Add(points_left.list[j]);
//                    j++;
//                }

//                pictureBox1.Image = Draw_Test(img_left, tmp_list);
//            }

//        }

//        private void checkBox1_CheckedChanged(object sender, EventArgs e)
//        {
//            if (checkBox1.Checked == true)
//                mergeTrackBar = true;
//            else
//                mergeTrackBar = false;

//        }

//        private void trackBar1_Scroll(object sender, EventArgs e)
//        {
//            if (mergeTrackBar)
//                trackBar2.Value = trackBar1.Value;
//        }

//        private void trackBar2_Scroll(object sender, EventArgs e)
//        {
//            if (mergeTrackBar)
//                trackBar1.Value = trackBar2.Value;
//        }


//        public Image DrawHeatMap()
//        {
//            Image img = (Image)img_left.Clone();
//            Graphics g = Graphics.FromImage(img);

//            float step = 30;
//            int cell_w = (int)(img_left.Width / step);
//            int cell_h = (int)(img_left.Height / step);

//            int[,] a = new int[cell_h, cell_w];

//            foreach (var p in points_left.list)
//            {
//                var x = p.X / step;
//                var y = p.Y / step;

//                if (x > cell_w)
//                    x = cell_w - 1;
//                if (y > cell_h)
//                    y = cell_h - 1;

//                a[(int)(y), (int)(x)]++;
//            }


//            int min = (from int v in a select v).Min();
//            int max = (from int v in a select v).Max();
//            int mean = (max - min) / 2;


//            //draw grid
//            for (var i = 0; i < cell_h; i++)
//                for (var j = 0; j < cell_w; j++)
//                {
//                    g.FillRectangle(new SolidBrush(HeatMapColor(a[i, j], min, max)), j * step, i * step, step, step);
//                }


//            //g.FillRectangle(new SolidBrush(Color.Red), p.X, p.Y, 10, 10);
//            return img;
//        }


//        private void button3_Click(object sender, EventArgs e)
//        {
//            pictureBox1.Image = DrawHeatMap();
//        }

//        public Color HeatMapColor(decimal value, decimal min, decimal max)
//        {
//            decimal val = (value - min) / (max - min);
//            int r = Convert.ToByte(255 * val);
//            int g = Convert.ToByte(255 * (1 - val));
//            int b = 0;

//            return Color.FromArgb(255, r, g, b);
//        }

//        private void button4_Click(object sender, EventArgs e)
//        {
//            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
//            {
//                var data = Directory.GetFiles(Path.GetDirectoryName(openFileDialog.FileName));
//                points_left = new GazePoint();

//                foreach (var item in data)
//                {
//                    //load points
//                    StreamReader sr = new StreamReader(item);

//                    //fill in our gazepoints structure
//                    string line = "";
//                    while ((line = sr.ReadLine()) != null)
//                    {
//                        var tmp = line.Split(new string[] { ", " }, StringSplitOptions.None);
//                        points_left.list.Add(new PointF(float.Parse(tmp[0]), float.Parse(tmp[1])));
//                        points_left.times.Add(double.Parse(tmp[2]));
//                    }
//                    sr.Close();
//                }

//            }

//            pictureBox1.Image = DrawHeatMap();
//        }

//        private void InitializeComponent()
//        {
//            this.SuspendLayout();
//            // 
//            // Analysis
//            // 
//            this.ClientSize = new System.Drawing.Size(991, 557);
//            this.Name = "Analysis";
//            this.ResumeLayout(false);

//        }

//        //private Color HeatMapColor(double value, double min, double max)
//        //{
//        //    Color firstColour = Color.RoyalBlue;
//        //    Color secondColour = Color.LightSkyBlue;

//        //    // Example: Take the RGB
//        //    //135-206-250 // Light Sky Blue
//        //    // 65-105-225 // Royal Blue
//        //    // 70-101-25 // Delta

//        //    int rOffset = Math.Max(firstColour.R, secondColour.R);
//        //    int gOffset = Math.Max(firstColour.G, secondColour.G);
//        //    int bOffset = Math.Max(firstColour.B, secondColour.B);

//        //    int deltaR = Math.Abs(firstColour.R - secondColour.R);
//        //    int deltaG = Math.Abs(firstColour.G - secondColour.G);
//        //    int deltaB = Math.Abs(firstColour.B - secondColour.B);

//        //    double val = (value - min) / (max - min);
//        //    int r = rOffset - Convert.ToByte(deltaR * (1 - val));
//        //    int g = gOffset - Convert.ToByte(deltaG * (1 - val));
//        //    int b = bOffset - Convert.ToByte(deltaB * (1 - val));

//        //    if(value == 0 )
//        //        return Color.FromArgb(150, r, g, b);
//        //    else
//        //        return Color.FromArgb(255, r, g, b);
//        //}   
//    }
//}
