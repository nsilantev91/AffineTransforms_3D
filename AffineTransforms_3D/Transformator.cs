using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace AffineTransforms_3D
{

    abstract class Transformator
    {
        public abstract Point3D Transform(Point3D point);

        static public Figure Transform(Figure f, Transformator transform)
        {
            var figure = new Figure();
            var adjMatr = f.adjacencyMatrix;
            foreach (var val in adjMatr)
            {
                var key = val.Key;
                var value = val.Value;
                var beginPoint = transform.Transform(key);
                foreach (var ed in value)
                {
                    var endPoint = transform.Transform(ed);
                    figure.AddEdge(beginPoint, endPoint);
                }
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
