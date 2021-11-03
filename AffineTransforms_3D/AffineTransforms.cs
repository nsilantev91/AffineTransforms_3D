using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;


namespace AffineTransforms_3D
{
    static class AffineTransforms
    {
        static public RotateTransform3D RotateTransform3D(Point3D center, int angle, double x=0, double y=0, double z=0)
        {
            var rotator = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(x, y, z), angle),center);
            return rotator;
        }

        static public TranslateTransform3D TranslateTransform3D(double x=0, double y=0, double z=0)
        {
            var translator = new TranslateTransform3D(x, y, z);
            return translator;
        }

        static public ScaleTransform3D ScaleTransform3D (Point3D center, double x=1, double y=1, double z =1)
        {
            var scaler = new ScaleTransform3D(x, y, z, center.X, center.Y, center.Z);
            return scaler;
        }

        static public Figure Transform(Figure f, Transform3D transform)
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
}
