using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Triangle
{
    class View
    {
        Bitmap pic;

        public void DrawDot(PictureBox map, int x, int y)
        {
            pic = new Bitmap(map.Width, map.Height);
            Graphics g = Graphics.FromImage(pic);
            Pen p = new Pen(Color.Red, 3);
            var cursorPosition = map.PointToClient(Cursor.Position);
            g.DrawEllipse(p, cursorPosition.X-7, cursorPosition.Y-7, 15, 15);
            map.Image = pic;
        }

        public void DrawTriangle(PictureBox map, List<Point> newpoints)
        {
            List<Point> points = new List<Point>();
            points = newpoints;
            Point[] pts = points.ToArray();
            Graphics g = Graphics.FromImage(pic);
            Pen p = new Pen(Color.Black, 2);
            g.DrawLines(p, pts);
            map.Image = pic;
            GC.Collect();
        }
        
    }
}
