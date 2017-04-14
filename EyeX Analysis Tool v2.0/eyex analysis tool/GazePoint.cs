using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace EyeX_Analysis_Tool
{
    public class GazePoint
    {
        public List<PointF> list;
        public List<double> times;

        public GazePoint()
        {
            list = new List<PointF>();
            times = new List<double>();
        }

        public GazePoint(GazePoint inp)
        {
            list = new List<PointF>(inp.list);
            times = new List<double>(inp.times);
        }

        public void Add(PointF point, double time)
        {
            list.Add(point);
            times.Add(time);
        }

        public void Save(string filename)
        {
            var a = File.Create(filename);
            a.Close();
            StreamWriter file = new StreamWriter(filename);
            for (var i = 0; i < list.Count; i++)
                file.WriteLine(list[i].X + ", " + list[i].Y + ", " + times[i]);
            file.Close();
        }

        public void Clear()
        {
            list.Clear();
            times.Clear();
        }
    }
}
