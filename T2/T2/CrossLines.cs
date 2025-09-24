using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace T2
{
    public class CrossLines
    {
        private double x1,y1,x2,y2;
        public CrossLines(double x1, double y1, double x2, double y2)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
        }
        public CrossLines(CrossLines a)
        {
            this.x1 = a.x1;
            this.y1 = a.y1;
            this.x2 = a.x2;
            this.y2 = a.y2;
        }
        public double getX1() { return x1; }
        public double getY1() { return y1; }
        public double getX2() { return x2; }
        public double getY2() { return y2; }
        public void setX1(double x) { this.x1 = x; }
        public void setY1(double y) { this.y1 = y; }
        public void setX2(double x) { this.x2 = x; }
        public void setY2(double y) { this.y2 = y; }

        public double len()
        {
            double dx = x2 - x1;
            double dy = y2 - y1;
            return dx * dx + dy * dy;
        }
        public bool Intersection(CrossLines a, CrossLines b, out (double,double) point, ref string label)
        {       
            // Координаты направления вектора первого отрезка
            double v = a.x2 - a.x1;
            double w = a.y2 - a.y1;
            // Координаты направления вектора второго отрезка
            double v2 = b.x2 - b.x1;
            double w2 = b.y2 - b.y1;

            if (v == 0 && w == 0 && v2 == 0 && w2 == 0)
            {
                //Отрезки неопредёленны
                label = "Оба отрезка неопределённы";
                point = (0,1);
                return false;
            }
            else if (v == 0 && w == 0)
            {
                // Первый отрезок неопределён
                label = "Первый отрезок неопределён";
                point = (0, 2);
                return false;
            }
            else if (v2 == 0 && w2 == 0)
            {
                // Втопой отрезок неопределён
                label = "Второй отрезок неопределён";
                point = (0, 2);
                return false;
            }
            double len1 = a.len();
            double len2 = b.len();
            double XF = v / len1;
            double YF = w / len1;
            double XS = v2 / len2;
            double YS = w2 / len2;
            double epsilon = 0.000001;

            if (a.x1 == b.x1 && a.y1 == b.y1 && a.x2 == b.x2 && a.y2 == b.y2)
            {
                label = "Отрезки совпадают";
                point = (0, 3);
                return false;
            }
            if (Math.Abs(XF - XS) < epsilon && Math.Abs(YF - YS) < epsilon)
            {
                label = "Отрезки параллельны";
                point = (0, 4);
                return false;
            }
            double t2 = (-w * b.x1 + w * a.x1 + v * b.y1 - v * a.y1) / (w * v2 - v * w2);
            double t = (b.x1 - a.x1 + v2 * t2) / v;

            if (t < 0 || t > 1 || t2 < 0 || t2 > 1)
            {
                label = $"Пересечения нет, {t}, {t2}";
                point = (0, 5);
                return false;
            }
            point = (b.x1 + v2 * t2, b.y1 + w2 * t2);
            label = $"Пересечение есть: X={point.Item1}; Y={point.Item2}";
            return true;
        }
        public bool Angle(CrossLines a, CrossLines b, out double angle)
        {
            double up = (a.x2 - a.x1)*(b.x2 - b.x1) + (a.y2 - a.y1)*(b.y2 - b.y1);
            double down = Math.Sqrt(Math.Pow((a.x2 - a.x1),2) + Math.Pow((a.y2 - a.y1),2)) * Math.Sqrt(Math.Pow((b.x2 - b.x1), 2) + Math.Pow((b.y2 - b.y1), 2));
            angle = Math.Acos(up/down);
            return true; 
        }
    }
}
