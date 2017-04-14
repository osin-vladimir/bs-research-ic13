using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace RecallApp
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

        public void Add(PointF point, double time)
        {
            list.Add(point);
            times.Add(time);
        }

        public void Save(string filename)
        {
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
