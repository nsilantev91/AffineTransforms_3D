using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Drawing;

namespace AffineTransforms_3D
{
    class ZBuffer
    {
        static public Bitmap zBuffer(int width, int height, List<Figure> figures)
        {
            Bitmap image = new Bitmap(width, height);
            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    image.SetPixel(i, j, Color.White);
            double[,] zbuff = new double[width, height];

            for (int i = 0; i < width; i++)
                for (int j = 0; j < height; j++)
                    zbuff[i, j] = float.MinValue;

            foreach (var figure in figures)
            {
                var triags = Triangulate(figure);
                var rastFigure = new Dictionary<int, List<Point3D>>();
                foreach (var triag in triags)
                {
                    rastFigure.Add(triag.Key, Rasterize(triag.Value[0]));
                    for (int i = 1; i < triag.Value.Count; i++)
                    {
                        rastFigure[triag.Key].AddRange(Rasterize(triag.Value[i]));
                    }
                }
                var figLeftX = rastFigure.Values.Where(lst => lst.Count != 0).Min(p => p.Min(pp => pp.X));
                var figRightX = rastFigure.Values.Where(lst => lst.Count != 0).Max(p => p.Max(pp => pp.X));
                var figLeftY = rastFigure.Values.Where(lst => lst.Count != 0).Min(p => p.Min(pp => pp.Y));
                var figRightY = rastFigure.Values.Where(lst => lst.Count != 0).Max(p => p.Max(pp => pp.Y));

                var figureCenterX = (figRightX - figLeftX) / 2;
                var figureCenterY = (figRightY - figLeftY) / 2;
                var centerX = width / 2;
                var centerY = height / 2;
                Random r = new Random();
                for (int i = 0; i < rastFigure.Count; i++)
                {
                    var points = rastFigure[i + 1];
                    var BackColor = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
                    var colors = new List<Color> { Color.Black, Color.BlueViolet, Color.Coral, Color.DarkSeaGreen, Color.DimGray, Color.DeepPink };
                    for (int j = 0; j < points.Count; j++)
                    {
                        int x = (int)(points[j].X + centerX - figureCenterX) + 200;
                        int y = (int)(points[j].Y + centerY - figureCenterY) + 200;
                        if (x < width && y < height && x > 0 && y > 0)
                        {
                            if (points[j].Z > zbuff[x, y])
                            {
                                zbuff[x, y] = points[j].Z;
                                image.SetPixel(x, y, BackColor/*colors[i % colors.Count]*/ );
                            }
                        }
                    }
                }
            }
            return image;
        }
        static public Dictionary<int, List<List<Edge>>> Triangulate(Figure figure)
        {
            Dictionary<int, List<List<Edge>>> res = new Dictionary<int, List<List<Edge>>>();
            int count = 1;
            foreach (var face in figure.Faces)
            {
                if (face.edges.Count == 3)
                    res.Add(count, new List<List<Edge>> { face.edges });
                if (face.edges.Count == 4)
                {
                    res.Add(count, new List<List<Edge>> { new List<Edge> { face.edges[0], face.edges[1], face.edges[2] } });
                    res[count].Add(new List<Edge> { face.edges[0], face.edges[2], face.edges[3] });
                }
                if (face.edges.Count == 5)
                {
                    res.Add(count, new List<List<Edge>> { new List<Edge> { face.edges[0], face.edges[1], face.edges[4] } });
                    res[count].Add(new List<Edge> { face.edges[1], face.edges[2], face.edges[4] });
                    res[count].Add(new List<Edge> { face.edges[2], face.edges[3], face.edges[4] });
                }
                count++;
            }
            return res;
        }

        static public List<Point3D> Rasterize(List<Edge> triangle)
        {
            List<Point3D> res = new List<Point3D>();
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

            var xLeft = interpolate(x1, y1, x2, y2);
            var xRight = interpolate(x2, y2, x3, y3);
            var xBase = interpolate(x1, y1, x3, y3);

            var zLeft = interpolate(z1, y1, z2, y2);
            var zRight = interpolate(z2, y2, z3, y3);
            var zBase = interpolate(z1, y1, z3, y3);
            xLeft.AddRange(xRight);
            zLeft.AddRange(zRight);
            int centerPointIndex = xLeft.Count / 2;
            if (xBase[centerPointIndex] < xLeft[centerPointIndex])
            {
                return helpFunc(xBase, xLeft, zBase, zLeft, y1, y3);
            }
            else
            {
                return helpFunc(xLeft, xBase, zLeft, zBase, y1, y3);
            }
        }
        static List<Point3D> helpFunc(List<int> x_left, List<int> x_right, List<int> z_left, List<int> z_right, int y1, int y2)
        {
            List<Point3D> res = new List<Point3D>();
            for (int y = y1; y < y2; y++)
            {
                var intCurrZ = interpolate(z_left[y - y1], x_left[y - y1], z_right[y - y1], x_right[y - y1]);
                for (int x = x_left[y - y1]; x < x_right[y - y1]; x++)
                {
                    res.Add(new Point3D(x, y, intCurrZ[x - x_left[y - y1]]));
                }
            }
            return res;
        }
        static List<int> interpolate(int x1, int y1, int x2, int y2)
        {
            if (y1 == y2)
            {
                return new List<int> { x1 };
            }
            List<int> values = new List<int>();

            double a = (double)(x2 - x1) * 1.0 / (y2 - y1);

            for (int i = 0; i <= Math.Abs(y2 - y1); i++)
            {
                values.Add((int)(a * i) + x1);
            }

            return values;
        }

    }
}
