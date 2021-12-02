using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Media3D;
using FastBitmapLib;

namespace AffineTransforms_3D
{
    class Function3D
    {
        public static List<List<Point3D>> EvaluateFunction(int z, int x, int step, Func<int,int,int> func)
        {
            var res = new List<List<Point3D>>();
            for (int i = -z+1; i<z; i+=step)
            {
                var temp = new List<Point3D>();
                temp.Add(new Point3D(-x,0,i));
                for (int j = -x+1; j<x; j+=step)
                    temp.Add(new Point3D(j, func(j, i), i));
                temp.Add(new Point3D(x, 0, i));
                res.Add(temp);
            }
            return res;
        }

        public static List<List<Point3D>> EvaluateFunction(int z, int x, int stepZ,int stepX, Func<double, double, double> func)
        {
            var res = new List<List<Point3D>>();
            for (double i = -z + 1; i < z; i += stepZ)
            {
                var temp = new List<Point3D>();
                var inside = new List<Point3D>();
                //temp.Add(new Point3D(-x, 0, i));
                for (double j = -x + 1; j < x; j += stepX)
                    inside.Add(new Point3D(j, -func(j, i), i));
                temp.AddRange(inside);
                //temp.Add(new Point3D(x, 0, i));
                inside.Reverse();
                temp.AddRange(inside);
                res.Add(temp);
            }
            return res;
        }

        static public Bitmap DrawFloatingHorizon(int width, int height, List<Face> faces)
        {
            var highest = Enumerable.Repeat(int.MinValue, width).ToList();
            var lowest = Enumerable.Repeat(int.MaxValue, width).ToList();

            Bitmap image = new Bitmap(width, height);
            FastBitmap fastBtm = new FastBitmap(image);
            fastBtm.Lock();
            fastBtm.Clear(Color.White);
            var centerX = width / 2;
            var centerY = height / 2;



            foreach (var side in faces)
                foreach (var edge in side.edges)
                {
                    lineBresenham(
                        (int)(edge.begin.X + centerX), (int)(edge.begin.Y + centerY),
                        (int)(edge.end.X + centerX), (int)(edge.end.Y + centerY),Color.Black,fastBtm, lowest,highest);
                }

            for (var i = 0; i < faces.Count() - 1; i++)
            {
                lineBresenham((int)(faces[i].edges[0].begin.X + centerX), (int)(faces[i].edges[0].begin.Y + centerY),
                    (int)(faces[i + 1].edges[0].begin.X + centerX), (int)(faces[i + 1].edges[0].begin.Y + centerY), Color.Black, fastBtm, lowest, highest);
            }

            for (var i = 0; i < faces.Count() - 1; i++)
            {
                lineBresenham((int)(faces[i].edges[faces[i].edges.Count()/2].begin.X + centerX), (int)(faces[i].edges[faces[i].edges.Count() / 2].begin.Y + centerY),
                    (int)(faces[i + 1].edges[faces[i].edges.Count() / 2].begin.X + centerX), (int)(faces[i + 1].edges[faces[i].edges.Count() / 2].begin.Y + centerY), Color.Black, fastBtm, lowest, highest);
            }

            fastBtm.Unlock();
            return image;
        }

        public static void lineBresenham(int x, int y, int x2, int y2, Color color,FastBitmap btm, List<int> low, List<int> high)
        {
            var temp_low = low.ToList();
            var temp_high = high.ToList();
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }

            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (x>=0 && x<btm.Width && y>=0 && y< btm.Height)
                {
                    /*
                    btm.SetPixel(x, y, color);
                    */
                    if (y>=temp_high[x])
                    { 
                        btm.SetPixel(x, y, color);
                        high[x] = y;
                    }
                    if (y<=temp_low[x])
                    {
                        btm.SetPixel(x, y, color);
                        low[x] = y;
                    }
                    
                }
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        public static void lineBresenham(int x, int y, int x2, int y2, Color color, FastBitmap btm)
        {
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            int longest = Math.Abs(w);
            int shortest = Math.Abs(h);
            if (!(longest > shortest))
            {
                longest = Math.Abs(h);
                shortest = Math.Abs(w);
                if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                dx2 = 0;
            }

            int numerator = longest >> 1;
            for (int i = 0; i <= longest; i++)
            {
                if (x >= 0 && x < btm.Width && y >= 0 && y < btm.Height)
                {
                    btm.SetPixel(x, y, color);
                }
                numerator += shortest;
                if (!(numerator < longest))
                {
                    numerator -= longest;
                    x += dx1;
                    y += dy1;
                }
                else
                {
                    x += dx2;
                    y += dy2;
                }
            }
        }

        public static double Sum(double a, double b)
        {
            return a + b;
        }

        public static double Mult(double a, double b)
        {
            return a*b;
        }

        public static double Sin(double a, double b)
        {
            return 100 * Math.Sin(a/100)*Math.Cos(b/100);
        }
        public static double complex(double a, double b)
        {
            return 10 * (a / 100) * (b / 100);
        }
        
        public static double veryComplex(double a, double b)
        {
            return Math.Sin(Math.Sqrt(a * a + b * b))*3;
        }
    }

}