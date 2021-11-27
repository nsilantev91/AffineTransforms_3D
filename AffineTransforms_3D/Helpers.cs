using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace AffineTransforms_3D
{
    static public  class Helpers
    {
        static public double[,] MultiplyMatrix(double[,] A, double[,] B)
        {
            int rA = A.GetLength(0);
            int cA = A.GetLength(1);
            int rB = B.GetLength(0);
            int cB = B.GetLength(1);
            double temp = 0;
            double[,] kHasil = new double[rA, cB];
            if (cA != rB)
            {
                Console.WriteLine("matrix can't be multiplied !!");
            }
            else
            {
                for (int i = 0; i < rA; i++)
                {
                    for (int j = 0; j < cB; j++)
                    {
                        temp = 0;
                        for (int k = 0; k < cA; k++)
                        {
                            temp += A[i, k] * B[k, j];
                        }
                        kHasil[i, j] = temp;
                    }
                }
                return kHasil;
            }
            return null;
        }

        static public List<Point3D> BetweenPoint(Point3D first, Point3D second)
        {
            int len;
            if (first.X > second.X)
                len = Convert.ToInt32(Math.Floor(first.X + 1) - Math.Ceiling(second.X - 1));
            else
                len = Convert.ToInt32(Math.Floor(second.X + 1) - Math.Ceiling(first.X - 1));

            var res = new List<Point3D>();
            for (int i=0; i<len;i++)
                res.Add(new Point3D(Convert.ToInt32(Math.Abs(first.X - second.X) / len * i + first.X), Math.Abs(first.Y - second.Y) / len * i + first.Y, Math.Abs(first.Z - second.Z) / len * i + first.Z));
            return res;
        }
    }


}
