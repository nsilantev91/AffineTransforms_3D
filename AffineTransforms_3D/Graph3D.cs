using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Media3D;

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
                //inside.Reverse();
                //temp.AddRange(inside);
                res.Add(temp);
            }
            return res;
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
    }

}