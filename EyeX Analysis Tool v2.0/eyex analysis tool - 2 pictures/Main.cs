using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeX_Analysis_Tool
{
    public partial class Main : Form
    {
        public string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public Image img_origin;
        public GazePoint points_left;
        public GazePoint points_right;
        public string filename;

        public Main()
        {
            InitializeComponent();

            //trackbar settings
            trackBar.Maximum = 300;
            trackBar.Minimum = 0;
            trackBar.TickFrequency = 10;
            trackBar.LargeChange = 10;
            trackBar.SmallChange = 10;
        }

        //open dialogs for all files
        private void left_pic_box_Click(object sender, EventArgs e)
        {
            //load image
            openFileDialog.Title = "Maain Images";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = openFileDialog.FileName;
                    img_origin = Image.FromFile(openFileDialog.FileName);
                    left_pic_box.Image = img_origin;
                    right_pic_box.Image = img_origin;
                }
                catch (Exception ex)
                {

                }
            }

            //load data left
            openFileDialog.Title = "Data Left";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //load points
                    StreamReader sr = new StreamReader(openFileDialog.FileName);

                    //fill in our gazepoints structure
                    points_left = new GazePoint();
                    string line = "";

                    string bline = "";
                    int PointCountFromFile = 0;
                    int PointCountCopy = 0;
                    int PointCountClear = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        PointCountFromFile++;

                        if (line != bline)
                        {
                            var tmp = line.Split(new string[] { ", " }, StringSplitOptions.None);
                            points_left.list.Add(new PointF(float.Parse(tmp[0]), float.Parse(tmp[1])));
                            points_left.times.Add(double.Parse(tmp[2]));

                            bline = line;
                            PointCountClear++;
                        }
                        else
                        {
                            PointCountCopy++;
                        }

                        
                    }

                    MessageBox.Show("Точек в файле: " + PointCountFromFile.ToString() + "\nУдалено дублей: " + PointCountCopy.ToString() + "\nОсталось чистых: " + PointCountClear.ToString());

                    sr.Close();
                }
                catch (Exception ex)
                {

                }
            }

            //load data right
            openFileDialog.Title = "Data right";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //load points
                    StreamReader sr = new StreamReader(openFileDialog.FileName);

                    //fill in our gazepoints structure
                    points_right = new GazePoint();

                    string line = "";

                    string bline = "";
                    int PointCountFromFile = 0;
                    int PointCountCopy = 0;
                    int PointCountClear = 0;

                    while ((line = sr.ReadLine()) != null)
                    {
                        PointCountFromFile++;

                        if (line != bline)
                        {
                            var tmp = line.Split(new string[] { ", " }, StringSplitOptions.None);
                            points_right.list.Add(new PointF(float.Parse(tmp[0]), float.Parse(tmp[1])));
                            points_right.times.Add(double.Parse(tmp[2]));

                            bline = line;
                            PointCountClear++;
                        }
                        else
                        {
                            PointCountCopy++;
                        }


                    }

                    MessageBox.Show("Точек в файле: " + PointCountFromFile.ToString() + "\nУдалено дублей: " + PointCountCopy.ToString() + "\nОсталось чистых: " + PointCountClear.ToString());

                    sr.Close();
                }
                catch (Exception ex)
                {

                }

            }


        }

        //usual drawing
        public Image Draw_Test(Image img, List<PointF> points)
        {
            Image new_img = (Image)img.Clone();
            Graphics g = Graphics.FromImage(new_img);

            //draw resulting curve
            if (points != null && points.Count > 0)
            {
                if (points.Count > 1)
                {

                    g.DrawCurve(new Pen(new SolidBrush(Color.FromArgb(200, 255, 255, 255)), 2), points.ToArray(), 0.1f);

                    foreach (var item in points)
                    {
                        g.FillEllipse(new SolidBrush(Color.FromArgb(200, Color.FloralWhite)), item.X - 5, item.Y - 5, 10, 10);
                    }

                    //draw points on this set of images
                    double c = 0;
                    double step = 128 / points.Count;

                    /*
                    foreach (var item in points)
                    {
                        Color color = Color.FromArgb(255, (int)c, 0, 0);
                        g.FillEllipse(new SolidBrush(color), item.X, item.Y, 25, 25);
                        c = c + step;
                    }
                    */

                    //begin
                    g.FillEllipse(new SolidBrush(Color.FromArgb(200, Color.FloralWhite)), points[0].X - 35, points[0].Y - 35, 70, 70);
                    //eng
                    g.FillEllipse(new SolidBrush(Color.FromArgb(200, Color.Red)), points[points.Count - 1].X - 35, points[points.Count - 1].Y - 35, 70, 70);

                    return new_img;
                }
            }

            return img;
        }

        // heatmap
        public Image DrawHeatMap(Image img_origin, GazePoint points)
        {
            Image img = (Image)img_origin.Clone();
            Graphics g = Graphics.FromImage(img);

            float step = 30;
            int cell_w = (int)(img.Width / step);
            int cell_h = (int)(img.Height / step);

            int[,] a = new int[cell_h, cell_w];

            foreach (var p in points.list)
            {
                var x = p.X / step;
                var y = p.Y / step;

                if (x > cell_w)
                    x = cell_w - 1;
                if (y > cell_h)
                    y = cell_h - 1;

                a[(int)(y), (int)(x)]++;
            }


            int min = (from int v in a select v).Min();
            int max = (from int v in a select v).Max();
            int mean = (max - min) / 2;

            //draw grid
            for (var i = 0; i < cell_h; i++)
                for (var j = 0; j < cell_w; j++)
                {
                    g.FillRectangle(new SolidBrush(HeatMapColor(a[i, j], min, max)), j * step, i * step, step, step);
                }

            return img;
        }

        public Color HeatMapColor(decimal value, decimal min, decimal max)
        {
            decimal val = (value - min) / (max - min);
            int r = Convert.ToByte(255 * val);
            int g = Convert.ToByte(255 * (1 - val));
            int b = 0;

            return Color.FromArgb(255, r, g, b);
        }

        //controls
        private void heat_map_btn_Click(object sender, EventArgs e)
        {
            if (points_left != null && points_left.list != null)
                left_pic_box.Image = DrawHeatMap(img_origin, points_left);

            if (points_right != null && points_right.list != null)
                right_pic_box.Image = DrawHeatMap(img_origin, points_right);
        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            repaint(sender, e);
        }

        void repaint(object sender, EventArgs e)
        {
            ScrollCount.Text = trackBar.Value.ToString();

            if (points_left != null && points_left.list != null)
                left_pic_box.Image = Draw_Test(img_origin, points_left.list.GetRange(0, points_left.list.Count * trackBar.Value / (trackBar.Maximum - trackBar.Minimum)));

            iLeftPointCount.Text = (points_left.list.Count * trackBar.Value / (trackBar.Maximum - trackBar.Minimum)).ToString();


            if (points_right != null && points_right.list != null)
                right_pic_box.Image = Draw_Test(img_origin, points_right.list.GetRange(0, points_right.list.Count * trackBar.Value / (trackBar.Maximum - trackBar.Minimum)));

            iRightPointCount.Text = (points_right.list.Count * trackBar.Value / (trackBar.Maximum - trackBar.Minimum)).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Ticker.Enabled)
            {
                Ticker.Start();
            }
            else
            {
                Ticker.Stop();
            }
                        
        }

        private void Ticker_Tick(object sender, EventArgs e)
        {
            if (trackBar.Value < trackBar.Maximum)
            {
                repaint(sender, e);
                trackBar.Value++;
            }
            else
            {
                Ticker.Stop();
            }
        }
    }
}
