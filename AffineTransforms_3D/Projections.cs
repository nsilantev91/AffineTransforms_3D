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
              { 0.707, -0.408, 0, 0 },
               { 0, 0.816, 0, 0 },
               { -0.707, -0.408, 0, 0 },
               { 0, 0, 0, 1 }


        };

        static double[,] trimetric =
        {
             { Math.Sqrt(3)/2, Math.Sqrt(2)/4, 0, 0 },
               { 0, Math.Sqrt(2)/2, 0, 0 },
               { 1/2, -Math.Sqrt(6)/4, 0, 0 },
               { 0, 0, 0, 1 }

        };

        public static Figure Apply(Figure fig, Projection selectedProjection)
        {
            double[,] matrProj = { { 0 } };
            if (selectedProjection == Projection.Perspective)
            {
                matrProj = perspective;
            }
            if (selectedProjection == Projection.Isometric)
            {
                matrProj = isometric;
            }
            if (selectedProjection == Projection.Trimetric)
            {
                matrProj = trimetric;
            }
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
