using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
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

        public bool DrawTrack;

        public List<GazePoint> spoints;

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

            DrawTrack = true;

            spoints = new List<GazePoint>();
        }

        //open dialogs for all files
        private void left_pic_box_Click(object sender, EventArgs e)
        {
            //load image
            openFileDialog.Title = "Main Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    filename = openFileDialog.FileName;
                    img_origin = Image.FromFile(openFileDialog.FileName);
                    left_pic_box.Image = img_origin;
                    //right_pic_box.Image = img_origin;
                }
                catch (Exception ex)
                {

                }
            }
        }



        GazePoint loadData()
        {
            //load data left
            openFileDialog.Title = "Data" + spoints.Count.ToString() + 1;

            GazePoint points_tmp = new GazePoint();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //load points
                    StreamReader sr = new StreamReader(openFileDialog.FileName);

                    CultureInfo ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
                    ci.NumberFormat.CurrencyDecimalSeparator = ",";
                    //fill in our gazepoints structure

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
                            points_tmp.list.Add(new PointF(float.Parse(tmp[0], NumberStyles.Any, ci), float.Parse(tmp[1], NumberStyles.Any, ci)));
                            points_tmp.times.Add(double.Parse(tmp[2], NumberStyles.Any, ci));

                            bline = line;
                            PointCountClear++;
                        }
                        else
                        {
                            PointCountCopy++;
                        }


                    }

                    lInfo.Text = ("Total dots: " + PointCountFromFile.ToString() + "\nDeleted duplicates: " + PointCountCopy.ToString() + "\nClean dots: " + PointCountClear.ToString());

                    sr.Close();

                    
                }
                catch (Exception ex)
                {

                }                              
            }

            return points_tmp;
        }

        //usual drawing
        public Image Draw_Test(Image img, List<List<PointF>> points)
        {
            if (img != null)
            {
                Image new_img = (Image)img.Clone();
                Graphics g = Graphics.FromImage(new_img);


                bool t = true;

                for (int i = 0; i < points.Count; i++)
                {
                    if (points[i] != null && points[i].Count > 1)
                        drawall(i + 1, points[i], g);
                }

                return new_img;
            }

            return null;
        }

        public Image DrawHeatmap(Image img, List<List<PointF>> points)
        {

            if (img != null)
            {
                
            }


            return null;
        }
        

            void drawall(int number, List<PointF> points, Graphics g)
        {
            Color LineColor = Color.Black;
            Color AccentColor = Color.White;
            int LineWidth = 3;
            int EllRadius = 40;
            int AverEllRadius = 15;
            int AccEllRadius = 46;

            switch (number)
                {
                case 1:
                    {
                        LineColor = Color.FromArgb(200, 255, 100, 100);
                        break;
                    }
                case 2:
                    {
                        LineColor = Color.FromArgb(200, 100, 100, 255);
                        break;
                    }
                case 3:
                    {
                        LineColor = Color.FromArgb(200, 255, 100, 255);
                        break;
                    }
                case 4:
                    {
                        LineColor = Color.FromArgb(200, 150, 150, 150);
                        break;
                    }
                case 5:
                    {
                        LineColor = Color.FromArgb(200, 220, 220, 220);
                        break;
                    }
                case 6:
                    {
                        LineColor = Color.FromArgb(200, 20, 20, 255);
                        break;
                    }
            }

            PointF[] p2 = points.ToArray();

            for (int i = 0; i < p2.Length; i++)
            {
                p2[i].X = p2[i].X + 1;
                p2[i].Y = p2[i].Y + 1;
            }


            if (DrawTrack)
            {
                g.DrawCurve(new Pen(new SolidBrush(AccentColor), LineWidth), p2, 0);
                g.DrawCurve(new Pen(new SolidBrush(LineColor), LineWidth), points.ToArray(), 0);

                //begin
                g.FillEllipse(new SolidBrush(AccentColor), points[0].X - AccEllRadius / 4, points[0].Y - AccEllRadius / 4, AccEllRadius / 2, AccEllRadius / 2);
                g.FillEllipse(new SolidBrush(LineColor), points[0].X - EllRadius / 4, points[0].Y - EllRadius / 4, EllRadius / 2, EllRadius / 2);
                g.DrawString(number.ToString(), new Font("Arial", 16), new SolidBrush(AccentColor), points[points.Count - 1].X - 8, points[points.Count - 1].Y - 8);
            }

            for (int i = 0; i < points.Count; i++)
            {
                g.FillEllipse(new SolidBrush(Color.FromArgb(255 * i / points.Count, LineColor)), points[i].X - AverEllRadius / 2, points[i].Y - AverEllRadius / 2, AverEllRadius, AverEllRadius);
            }


            

            //end
            g.FillEllipse(new SolidBrush(AccentColor), points[points.Count - 1].X - AccEllRadius / 2, points[points.Count - 1].Y - AccEllRadius / 2, AccEllRadius, AccEllRadius);
            g.FillEllipse(new SolidBrush(LineColor), points[points.Count - 1].X - EllRadius/2, points[points.Count - 1].Y - EllRadius/2, EllRadius, EllRadius);
            g.DrawString(number.ToString(), new Font("Arial", 16), new SolidBrush(AccentColor), points[points.Count - 1].X - 8, points[points.Count - 1].Y - 8);
        }


       
        //controls
        private void heat_map_btn_Click(object sender, EventArgs e)
        {
            Ticker.Stop();

            if (img_origin == null)
                return;

        
            int[,] Heatmap = new int[1920, 1080];
                                 
            for (int i = 0; i < Heatmap.GetLength(0); i++)
            {
                for (int j = 0; j < Heatmap.GetLength(1); j++)
                {
                    Heatmap[i, j] = 0;
                }
            }

           

            for (int i = 0; i < spoints.Count; i++)
            {
                for (int j = 0; j < spoints[i].list.Count; j++)
                {
                    int x = Convert.ToInt32(spoints[i].list[j].X);
                    int y = Convert.ToInt32(spoints[i].list[j].Y);

                    if (x < Heatmap.GetLength(0) && y < Heatmap.GetLength(1) && x >= 0 && y >= 0)
                    {
                        Heatmap[x, y] += 5;

                        if (x - 1 >= 0 && x + 1 < Heatmap.GetLength(0) && y - 1 >= 0 && y + 1 < Heatmap.GetLength(1))
                        {
                            Heatmap[x, y - 1] += 4;
                            Heatmap[x, y + 1] += 4;
                            Heatmap[x - 1, y] += 4;
                            Heatmap[x + 1, y] += 4;

                            Heatmap[x - 1, y + 1] += 2;
                            Heatmap[x - 1, y - 1] += 2;
                            Heatmap[x + 1, y + 1] += 2;
                            Heatmap[x + 1, y - 1] += 2;
                        }

                    }

                    
                }
            }


            for (int i = 0; i < Heatmap.GetLength(0) - 3; i += 3)
            {
                for (int j = 0; j < Heatmap.GetLength(1) - 3; j += 3)
                {                    
                    Heatmap[i + 1, j + 1] = Heatmap[i + 1, j + 1] + Heatmap[i, j] + Heatmap[i + 1, j] + Heatmap[i + 2, j] + Heatmap[i, j + 1] + Heatmap[i + 2, j + 1] + Heatmap[i, j + 2] + Heatmap[i + 1, j + 2] + Heatmap[i + 2, j + 2];
                }
            }


            int MaxHeat = 1;
            int MinHeat = 100000;

            for (int i = 0; i < Heatmap.GetLength(0); i++)
            {
                for (int j = 0; j < Heatmap.GetLength(1); j++)
                {
                    if (Heatmap[i, j] > MaxHeat)
                        MaxHeat = Heatmap[i, j];

                    if (Heatmap[i, j] > 0 && Heatmap[i, j] < MinHeat)
                        MinHeat = Heatmap[i, j];
                }
            }



            Image new_img = (Image)img_origin.Clone();
            Graphics g = Graphics.FromImage(new_img);

            float HeatSie = 2;
            float YellowHeatSize;

            float RadMin = 0;
            float RadMax = 80;

            float DeltaHeat = MaxHeat - MinHeat;

            

           //float k = (RadMax - RadMin) / DeltaHeat;


            for (int i = 0; i < Heatmap.GetLength(0); i++)
            {
                for (int j = 0; j < Heatmap.GetLength(1); j++)
                {                    
                    if (Heatmap[i, j] != 0)
                    {
                        HeatSie = RadMax / MaxHeat * Heatmap[i, j];
                        YellowHeatSize = (float)(HeatSie * 1.2);

                        g.FillEllipse(new SolidBrush(Color.FromArgb(Convert.ToInt32(255.0 / MaxHeat / 1.7 * Heatmap[i, j]), Color.Yellow)), i - YellowHeatSize / 2, j - YellowHeatSize / 2, YellowHeatSize, YellowHeatSize);

                        g.FillEllipse(new SolidBrush(Color.FromArgb(Convert.ToInt32(255.0 / MaxHeat * Heatmap[i, j]), Color.Red)), i - HeatSie / 2, j - HeatSie / 2, HeatSie, HeatSie);
                        if (255.0 / MaxHeat * Heatmap[i, j] > 150)
                            Console.WriteLine((255.0 / MaxHeat * Heatmap[i, j]).ToString());

                    }
                }
            }
            
            

            left_pic_box.Image = new_img;



            

        }

        private void trackBar_Scroll(object sender, EventArgs e)
        {
            repaint(sender, e);
        }

        void repaint(object sender, EventArgs e)
        {
            ScrollCount.Text = trackBar.Value.ToString();

           

            List<List<PointF>> p = new List<List<PointF>>();

            bool t = true;

            for (int i = 0; i < spoints.Count; i++)
            {
                p.Add(spoints[i].list.GetRange(0, spoints[i].list.Count * trackBar.Value / (trackBar.Maximum - trackBar.Minimum)));
                if (spoints[i] == null || spoints[i].list == null)
                    t = false;
            }

            if (t)
                left_pic_box.Image = Draw_Test(img_origin, p);            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Ticker.Enabled)
            {
                if (trackBar.Value == trackBar.Maximum)
                    trackBar.Value = trackBar.Minimum;
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

        private void button2_Click(object sender, EventArgs e)
        {
            spoints.Add(loadData());
            lDataCount.Text = spoints.Count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            spoints.Clear();
            lDataCount.Text = spoints.Count.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap bmpSave = (Bitmap)left_pic_box.Image;
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = "png";
            sfd.Filter = "Image files (*.png)|*.png|All files (*.*)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)

                bmpSave.Save(sfd.FileName, ImageFormat.Png);
        }

        private void TickSpeed_Scroll(object sender, EventArgs e)
        {
            Ticker.Interval = TickSpeed.Value;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DrawTrack = !DrawTrack;
        }
    }
}
