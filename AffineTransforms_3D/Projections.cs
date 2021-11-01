using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AffineTransforms_3D
{
    class Projections
    {
        static double[,] perspective =
        {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 0, 0.001},
            { 0, 0, 0, 1 }
        };

        static double[,] isometric =
        {
              { Math.Sqrt(0.5), 0, -Math.Sqrt(0.5), 0 },
               { 1 / Math.Sqrt(6), 2 /Math.Sqrt(6), 1 / Math.Sqrt(6), 0 },
               { 1 / Math.Sqrt(3), -1 /Math.Sqrt(3), 1 / Math.Sqrt(3), 0 },
               { 0, 0, 0, 1 }

        };

        public static Figure Apply(Figure fig, bool isPerspective)
        {
            var matrProj = isPerspective ? perspective : isometric;
            Figure resFigure = new Figure();
            var adjMatr = fig.adjacencyMatrix;
            foreach (var val in adjMatr)
            {
                var key = val.Key;
                var value = val.Value;
                var matr = new double[,] { { key.X, key.Y, key.Z, 1 } };
                var res = Helpers.MultiplyMatrix(matr, matrProj);
                var beginPoint = new PointF3D(res[0, 0] / res[0, 3], res[0, 1] / res[0, 3]);
                foreach (var ed in value)
                {
                    matr = new double[,] { { ed.X, ed.Y, ed.Z, 1 } };

                    res = Helpers.MultiplyMatrix(matr, matrProj);
                    var endPoint = new PointF3D(res[0, 0] / res[0, 3], res[0, 1] / res[0, 3]);
                    resFigure.AddEdge(beginPoint, endPoint);
                }
            }
            return resFigure;

        }
    }
}
