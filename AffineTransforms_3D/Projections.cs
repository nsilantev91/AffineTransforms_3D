using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using System.Drawing;

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


        //https://studfile.net/preview/903563/page:5/
        static double[,] isometric =
        {
              { 0.707, -0.408, 0, 0 },
              { 0, 0.816, 0, 0 },
              { -0.707, -0.408, 0, 0 },
              { 0, 0, 0, 1 }


        };

        static double sinB = 1/2;
        static double cosB = Math.Sqrt(3)/2;
        static double sinA = -Math.Sqrt(2) / 2;
        static double cosA = -Math.Sqrt(2)/2;
        static double[,] trimetric =
        {
             { cosA, sinA*sinB, 0, 0 },
             { 0, cosB, 0, 0 },
             { sinA, -sinA*cosB, 0, 0 },
             { 0, 0, 0, 1 }
             

        };

        static double[,] dimetric = 
        {
            { 0.935, -0.118, 0, 0 },
            { 0, 0.943, 0, 0 },
            { -0.354, -0.312, 0, 0 },
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
            if (selectedProjection == Projection.Dimetric)
            {
                matrProj = dimetric;
            }
            Figure resFigure = new Figure();
            var transformator = new CustomMatrixTransformator(matrProj);
            //var transformator = new CustomMatrixTransformator(Camera(-300,300, 1, Math.PI/2));
            foreach (var face in fig.Faces)
            {
                var edges = face.edges;
                List<Point3D> ed = new List<Point3D>();
                foreach(var e in edges)
                {
                    ed.Add(transformator.Transform(e.begin));
                    //ed.Add(transformator.Transform(e.end));
                }
                resFigure.AddFace(ed.ToArray());
            }
           /* foreach (var val in adjMatr)
            {
                var key = val.Key;
                var value = val.Value;
                var beginPoint = transformator.Transform(key);
                foreach (var ed in value)
                {
                    var endPoint = transformator.Transform(ed);
                    resFigure.AddEdge(beginPoint, endPoint);
                }
            }*/
            return resFigure;

        }

        public static Point ApplyForPoint3D(Point3D point, Projection selectedProjection)
        {
            var pointMatrix = new double[,] { { point.X, point.Y, point.Z, 1 } };
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
            if (selectedProjection == Projection.Dimetric)
            {
                matrProj = dimetric;
            }
            var res = Helpers.MultiplyMatrix(pointMatrix, matrProj);
            return new Point((int)(res[0, 0] / res[0, 3]), (int)(res[0, 1] / res[0, 3]));
        }
    }
}
