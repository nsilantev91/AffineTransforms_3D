using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;


namespace AffineTransforms_3D
{
    enum CoordinatePlane
    {
        XY, 
        XZ,
        YZ
    }

    

    static class AffineTransforms
    {
        static double[,] reflectXY = new double[4, 4]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, -1, 0},
                {0, 0, 0, 1 }
            };

        static double[,] reflectXZ = new double[4, 4]
           {
                {1, 0, 0, 0},
                {0, -1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1 }
           };

        static double[,] reflectYZ = new double[4, 4]
           {
                {-1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1 }
           };

      


        static public Transformator RotateTransform3D(Point3D center, double angle, double x=0, double y=0, double z=0)
        {
            var rotator = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(x, y, z), angle),center);
            return new StandardMatrixTransformator(rotator);
        }

        static public Transformator TranslateTransform3D(double x=0, double y=0, double z=0)
        {
            var translator = new TranslateTransform3D(x, y, z);
            return new StandardMatrixTransformator(translator);
        }

        static public Transformator ScaleTransform3D (Point3D center, double x=1, double y=1, double z =1)
        {
            var scaler = new ScaleTransform3D(x, y, z, center.X, center.Y, center.Z);
            return new StandardMatrixTransformator(scaler);
        }

        static public Transformator ReflectionTransform(CoordinatePlane plane)
        {
            switch (plane)
            {
                case CoordinatePlane.XY: return new CustomMatrixTransformator(reflectXY);
                case CoordinatePlane.XZ: return new CustomMatrixTransformator(reflectXZ);
                case CoordinatePlane.YZ: return new CustomMatrixTransformator(reflectYZ);
                default: throw new ArgumentException("Incorreect plane!");
            }
        }

      
    }
}
