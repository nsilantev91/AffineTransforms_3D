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

        static public void Transform(Figure f, Transform3D transform)
        {
            for (var i=0;i<f.vertexes.Count; i++)
            {
                f.vertexes[i] = transform.Transform(f.vertexes[i]);
            }
        }
    }
}
