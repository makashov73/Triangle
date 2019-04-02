using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Triangle
{
    class Controller
    {
        View view = new View();

        List<Point> points = new List<Point>();
        List<Point> newpoints = new List<Point>();

        public bool SetupDot(PictureBox map, int x, int y)
        {
            Point dot = new Point(x, y);
            if (points.Count <= 2)
            {
                points.Add(dot);
                view.DrawDot(map, x, y);
            }
            if (points.Count == 3)
            {
                CalculatedDots(map, points);
                return false;
            }
            return true;
        }

        public void CalculatedDots(PictureBox map, List<Point> points)
        {
            Point temp = new Point(0, 0);
            Point p1 = new Point(0, 0);
            Point p2 = new Point(0, 0);
            Point p3 = new Point(0, 0);

            temp.X = points[1].X - points[2].X;
            temp.Y = points[1].Y - points[2].Y;

            p1.X = points[0].X + temp.X;
            p1.Y = points[0].Y + temp.Y;

            p2.X = points[0].X - temp.X;
            p2.Y = points[0].Y - temp.Y;

            temp.X = points[1].X - points[0].X;
            temp.Y = points[1].Y - points[0].Y;

            p3.X = points[2].X + temp.X;
            p3.Y = points[2].Y + temp.Y;

            newpoints.Add(p1);
            newpoints.Add(p2);
            newpoints.Add(p3);
            newpoints.Add(p1);

            view.DrawTriangle(map, newpoints);
        }

        public void ClearDots()
        {
            points.Clear();
            points.TrimExcess();
            newpoints.Clear();
            newpoints.TrimExcess();
        }
        

        
    }
}
