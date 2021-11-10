using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace AffineTransforms_3D
{
    public  abstract class Transformator
    {
        public abstract Point3D Transform(Point3D point);

        static public Figure Transform(Figure f, Transformator transformator)
        {
            var figure = new Figure();
            foreach (var face in f.faces)
            {
                var edges = face.edges;
                List<Point3D> ed = new List<Point3D>();
                foreach (var e in edges)
                {
                    ed.Add(transformator.Transform(e.begin));
                    ed.Add(transformator.Transform(e.end));
                }
                figure.AddFace(ed.ToArray());
            }
            return figure;
        }

       
    }

    class StandardMatrixTransformator : Transformator
    {
        Transform3D transform3D;

        public StandardMatrixTransformator(Transform3D transform3D)
        {
            this.transform3D = transform3D;
        }
        public override Point3D Transform(Point3D point)
        {
            return transform3D.Transform(point);
        }
    }

    class CustomMatrixTransformator : Transformator
    {
        double[,] matrix;
        public CustomMatrixTransformator(double[,] m)
        {
            matrix = m;
        }
        public override Point3D Transform(Point3D point)
        {
            var pointMatrix = new double[,] { { point.X, point.Y, point.Z, 1 } };
            var res = Helpers.MultiplyMatrix(pointMatrix, matrix);
            return new Point3D(res[0,0]/res[0,3], res[0,1]/res[0,3], res[0,2]/res[0,3]);
        }
    }


}
