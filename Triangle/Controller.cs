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
        View view = new View(); // создание экземпляра класса View

        List<Point> points = new List<Point>(); // инициализация списка координат points
        List<Point> newpoints = new List<Point>(); // инициализация списка координат newpoints

        public bool SetupDot(PictureBox map, int x, int y) // инициализация метода подсчета установленных точек
        {
            Point dot = new Point(x, y);
            if (points.Count <= 2)
            {
                points.Add(dot); // добавление в конец списка points значения координат текущей установленной точки
                view.DrawDot(map, x, y); // вызов метода отрисовки точки на холсте
            }
            if (points.Count == 3)
            {
                CalculatedDots(map, points); // вызов метода вычисления сторон треугольника по введенным точкам
                return false;
            }
            return true;
        }

        public void CalculatedDots(PictureBox map, List<Point> points) // инициализация метода вычисления сторон треугольника по введенным точкам
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

            // построение сторон треугольника происходит посредством вычисления вершин.
            // вычисление вершин производится благодаря построению  отрезков:
            // Triangle_P1 = P1 + (P2 - P3)
            // Triangle_P2 = P1 - (P2 - P3)
            // Triangle_P3 = P3 + (P2 - P1)

            newpoints.Add(p1); // добавление в конец списка newpoints значения координат вершин треугольника
            newpoints.Add(p2); // добавление в конец списка newpoints значения координат вершин треугольника
            newpoints.Add(p3); // добавление в конец списка newpoints значения координат вершин треугольника
            newpoints.Add(p1); // добавление в конец списка newpoints значения координат вершин треугольника

            view.DrawTriangle(map, newpoints); // вызов метода отрисовки треугольника
        }

        public void ClearDots() // метод очистки списков с указанными координатами пользователем и вычисленными вершинами треугольника
        {
            points.Clear();
            points.TrimExcess();
            newpoints.Clear();
            newpoints.TrimExcess();
        }
        

        
    }
}
