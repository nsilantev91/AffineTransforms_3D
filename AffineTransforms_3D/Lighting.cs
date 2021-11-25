using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastBitmapLib;
using System.Windows.Media.Media3D;
using System.Drawing;

namespace AffineTransforms_3D
{
    class Lighting
    {
        private static IEnumerable<Tuple<Point3D, Vector3D>> vertexes;
        public static Bitmap lighting(int width, int height, Figure figure,Vector3D normal)
        {
            Bitmap bmp = new Bitmap(width, height);
            FastBitmap fastBmp = new FastBitmap(bmp);
            fastBmp.Lock();
            fastBmp.Clear(Color.White);
            fastBmp.Unlock();
            double[,] zbuff = new double[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    zbuff[i, j] = float.MinValue;
            vertexes = figure.Vertexes;
            var triags = ZBuffer.Triangulate(figure);
            var rastFigure = new Dictionary<int, List<Tuple<double,Point3D>>>();
            foreach (var triag in triags)
            {
                rastFigure.Add(triag.Key, Rasterize(triag.Value[0], normal));
                for (int i = 1; i < triag.Value.Count; i++)
                {
                    rastFigure[triag.Key].AddRange(Rasterize(triag.Value[i], normal));
                }
            }        
            var centerX = width / 2;
            var centerY = height / 2;
            var color = Color.AliceBlue;
            fastBmp.Lock();
            for (int i = 0; i < rastFigure.Count; i++)
            {
                var points = rastFigure[i + 1];
                for (int j = 0; j < points.Count; j++)
                {
                    int x = (int)(points[j].Item2.X + centerX);
                    int y = (int)(points[j].Item2.Y + centerY);
                    if (x < width && y < height && x > 0 && y > 0)
                    {
                        if (points[j].Item2.Z > zbuff[x, y])
                        {
                            //color = pictureBmp.GetPixel(x, y);
                            zbuff[x, y] = points[j].Item2.Z;
                            var light = points[j].Item1;
                            var col = Color.FromArgb((int)(color.R * light) % 256, (int)(color.G * light) % 256, (int)(color.B * light) % 256);
                            fastBmp.SetPixel(x, y, col);
                        }
                    }
                }
            }
            fastBmp.Unlock();
            return bmp;
        }

        public static (int,int,int,int) MinMaxValues(List<List<Edge>> triags)
        {
            var xMin = double.MaxValue;
            var yMin = double.MaxValue;
            var xMax = double.MinValue;
            var yMax = double.MinValue;
            foreach(var triag in triags)
            {
                foreach(var edge in triag)
                {
                    foreach(var p in edge.Points())
                    {
                        if (p.X > xMax)
                        {
                            xMax = p.X;
                        }
                        else if(p.X < xMin)
                        {
                            xMin = p.X;
                        }
                        if (p.Y > yMax)
                        {
                            yMax = p.Y;
                        }
                        else if (p.Y< yMin)
                        {
                            yMin = p.Y;
                        }
                    }
                }
            }
            return ((int)xMin, (int)yMin, (int)xMax,(int) yMax);
        }

        public static Bitmap texturing(int width, int height, Figure figure, Vector3D normal, bool withLight=false)
        {
            Bitmap bmp = new Bitmap(width, height);
            FastBitmap fastBmp = new FastBitmap(bmp);
            fastBmp.Lock();
            fastBmp.Clear(Color.White);
            fastBmp.Unlock();
            double[,] zbuff = new double[width, height];
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    zbuff[i, j] = float.MinValue;
            vertexes = figure.Vertexes;
            var triags = ZBuffer.Triangulate(figure);
            var rastFigure = new Dictionary<int, List<Tuple<double, double,double, Point3D>>>();
            foreach (var triag in triags)
            {
                (int xMin, int yMin,int  xMax,int yMax) = MinMaxValues(triag.Value);
                rastFigure.Add(triag.Key, RasterizeWithUV(triag.Value[0], normal, xMin, yMin, xMax, yMax));
                for (int i = 1; i < triag.Value.Count; i++)
                {
                    rastFigure[triag.Key].AddRange(RasterizeWithUV(triag.Value[i], normal, xMin, yMin, xMax, yMax));
                }
            }
            var centerX = width / 2;
            var centerY = height / 2;
            var color = Color.AliceBlue;
            fastBmp.Lock();
            var pictureBmp = new Bitmap("cat.jpg");
            //FastBitmap pictureFastBmp = new FastBitmap(pictureBmp);
            // pictureFastBmp.Lock();
            for (int i = 0; i < rastFigure.Count; i++)
            {
                var points = rastFigure[i + 1];
                for (int j = 0; j < points.Count; j++)
                {
                    int x = (int)(points[j].Item4.X + centerX);
                    int y = (int)(points[j].Item4.Y + centerY);
                    if (x < width && y < height && x > 0 && y > 0)
                    {
                        if (points[j].Item4.Z > zbuff[x, y])
                        {
                            var u = points[j].Item1;
                            var v = points[j].Item2;
                            var xPic =(int) (pictureBmp.Width * u);
                            var yPic =(int) (pictureBmp.Height * v);
                            color = pictureBmp.GetPixel(xPic, yPic);
                            zbuff[x, y] = points[j].Item4.Z;
                            var light =withLight? points[j].Item3:1;
                            var col = Color.FromArgb((int)(color.R * light) % 256, (int)(color.G * light) % 256, (int)(color.B * light) % 256);
                            fastBmp.SetPixel(x, y, col);
                        }
                    }
                }
            }
            fastBmp.Unlock();
            return bmp;
        }

        static double lambertModel(Point3D vertex, Vector3D normal, Vector3D lightPoint)
        {
            Vector3D reflLight = new Vector3D(vertex.X - lightPoint.X, vertex.Y - lightPoint.Y, vertex.Z - lightPoint.Z);
            double cos = Math.Cos(Vector3D.AngleBetween(reflLight, normal));
            return (cos + 1) / 2;
        }

        static public List<Tuple<double,Point3D>> Rasterize(List<Edge> triangle, Vector3D lightPoint)
        {
            List<Point3D> points = new List<Point3D>();
            foreach (var edge in triangle)
            {
                if (!points.Contains(edge.begin))
                    points.Add(edge.begin);
            }
            points.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
            var x1 = (int)points[0].X;
            var y1 = (int)points[0].Y;
            var z1 = (int)points[0].Z;

            var x2 = (int)points[1].X;
            var y2 = (int)points[1].Y;
            var z2 = (int)points[1].Z;

            var x3 = (int)points[2].X;
            var y3 = (int)points[2].Y;
            var z3 = (int)points[2].Z;

            var h1 = lambertModel(points[0], vertexes.First(p => p.Item1 == points[0]).Item2, lightPoint);
            var h2 = lambertModel(points[1], vertexes.First(p => p.Item1 == points[1]).Item2, lightPoint);
            var h3 = lambertModel(points[2], vertexes.First(p => p.Item1 == points[2]).Item2, lightPoint);

            var xLeft = interpolate(x1, y1, x2, y2).Select(x => (int)x).ToList();
            var xRight = interpolate(x2, y2, x3, y3).Select(x => (int)x).ToList();
            var xBase = interpolate(x1, y1, x3, y3).Select(x => (int)x).ToList();

            var zLeft = interpolate(z1, y1, z2, y2).Select(x => (int)x).ToList();
            var zRight = interpolate(z2, y2, z3, y3).Select(x => (int)x).ToList();
            var zBase = interpolate(z1, y1, z3, y3).Select(x => (int)x).ToList();

            var hLeft = interpolate(h1, y1, h2, y2);
            var hRight = interpolate(h2, y2, h3, y3);
            var hBase = interpolate(h1, y1, h3, y3);

            xLeft.RemoveAt(xLeft.Count - 1);
            xLeft.AddRange(xRight);
            zLeft.RemoveAt(zLeft.Count - 1);
            zLeft.AddRange(zRight);
            hLeft.RemoveAt(hLeft.Count - 1);
            hLeft.AddRange(hRight);

            int centerPointIndex = xLeft.Count / 2;
            if (xBase[centerPointIndex] < xLeft[centerPointIndex])
            {
                return helpFunc(xBase, xLeft, zBase, zLeft,hBase, hLeft, y1, y3);
            }
            else
            {
                return helpFunc(xLeft, xBase, zLeft, zBase,hLeft, hBase, y1, y3);
            }
        }

        static public List<Tuple<double, double, double, Point3D>> RasterizeWithUV(List<Edge> triangle, Vector3D lightPoint, int xMin, int yMin, int xMax, int yMax)
        {
            List<Point3D> points = new List<Point3D>();
            foreach (var edge in triangle)
            {
                if (!points.Contains(edge.begin))
                    points.Add(edge.begin);
            }
            points.Sort((p1, p2) => p1.Y.CompareTo(p2.Y));
            var x1 = (int)points[0].X;
            var y1 = (int)points[0].Y;
            var z1 = (int)points[0].Z;

            var x2 = (int)points[1].X;
            var y2 = (int)points[1].Y;
            var z2 = (int)points[1].Z;

            var x3 = (int)points[2].X;
            var y3 = (int)points[2].Y;
            var z3 = (int)points[2].Z;

            var h1 = lambertModel(points[0], vertexes.First(p => p.Item1 == points[0]).Item2, lightPoint);
            var h2 = lambertModel(points[1], vertexes.First(p => p.Item1 == points[1]).Item2, lightPoint);
            var h3 = lambertModel(points[2], vertexes.First(p => p.Item1 == points[2]).Item2, lightPoint);

            var xLeft = interpolate(x1, y1, x2, y2).Select(x => (int)x).ToList();
            var xRight = interpolate(x2, y2, x3, y3).Select(x => (int)x).ToList();
            var xBase = interpolate(x1, y1, x3, y3).Select(x => (int)x).ToList();

            var zLeft = interpolate(z1, y1, z2, y2).Select(x => (int)x).ToList();
            var zRight = interpolate(z2, y2, z3, y3).Select(x => (int)x).ToList();
            var zBase = interpolate(z1, y1, z3, y3).Select(x => (int)x).ToList();

            var hLeft = interpolate(h1, y1, h2, y2);
            var hRight = interpolate(h2, y2, h3, y3);
            var hBase = interpolate(h1, y1, h3, y3);

            xLeft.RemoveAt(xLeft.Count - 1);
            xLeft.AddRange(xRight);
            zLeft.RemoveAt(zLeft.Count - 1);
            zLeft.AddRange(zRight);
            hLeft.RemoveAt(hLeft.Count - 1);
            hLeft.AddRange(hRight);

            int centerPointIndex = xLeft.Count / 2;
            if (xBase[centerPointIndex] < xLeft[centerPointIndex])
            {
                return helpUVFunc(xBase, xLeft, zBase, zLeft, hBase, hLeft, y1, y3, xMin, yMin, xMax, yMax);
            }
            else
            {
                return helpUVFunc(xLeft, xBase, zLeft, zBase, hLeft, hBase, y1, y3, xMin, yMin, xMax, yMax);
            }
        }

        static List<Tuple<double,Point3D>> helpFunc(List<int> x_left, List<int> x_right, List<int> z_left, List<int> z_right, List<double> h_left, List<double> h_right, int y1, int y2)
        {
            List<Tuple<double,Point3D>> res = new List<Tuple<double,Point3D>>();
            for (int y = y1; y < y2; y++)
            {
                var currZ = interpolate(z_left[y - y1], x_left[y - y1], z_right[y - y1], x_right[y - y1]);
                var currH = interpolate(h_left[y - y1], x_left[y - y1], h_right[y - y1], x_right[y - y1]);
                for (int x = x_left[y - y1]; x < x_right[y - y1]; x++)
                {
                    res.Add(new Tuple<double, Point3D>(currH[x - x_left[y - y1]],new Point3D(x, y, currZ[x - x_left[y - y1]])));
                }
            }
            return res;
        }

        static List<Tuple<double, double, double, Point3D>> helpUVFunc(List<int> x_left, List<int> x_right, List<int> z_left, List<int> z_right,
            List<double> h_left, List<double> h_right, int y1, int y2, int xMin, int yMin, int xMax, int yMax)
        {
            List<Tuple<double, double, double, Point3D>> res = new List<Tuple<double, double,double, Point3D>>();
            var dx = (double) xMax - xMin;
            var dy = (double)yMax - yMin;
            for (int y = y1; y < y2; y++)
            {
                var currZ = interpolate(z_left[y - y1], x_left[y - y1], z_right[y - y1], x_right[y - y1]);
                var currH = interpolate(h_left[y - y1], x_left[y - y1], h_right[y - y1], x_right[y - y1]);
                var v = (y - yMin) * 1.0 / dy; 
                for (int x = x_left[y - y1]; x < x_right[y - y1]; x++)
                {
                    var u = (x - xMin) * 1.0 / dx;
                    res.Add(new Tuple<double, double, double, Point3D>(u, v, currH[x - x_left[y - y1]], new Point3D(x, y, currZ[x - x_left[y - y1]])));
                }
            }
            return res;
        }

        static List<double> interpolate(double x1, int y1, double x2, int y2)
        {
            if (y1 == y2)
            {
                return new List<double> { x1 };
            }
            List<double> values = new List<double>();

            double a = (double)(x2 - x1) * 1.0 / (y2 - y1);

            for (int i = 0; i <= Math.Abs(y2 - y1); i++)
            {
                values.Add((a * i) + x1);
            }

            return values;
        }
    }
}
