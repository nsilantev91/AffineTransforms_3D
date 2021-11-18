using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;


namespace AffineTransforms_3D
{
    public enum CoordinatePlane
    {
        XY, 
        XZ,
        YZ
    }

    

    static public class AffineTransforms
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

        public enum Axis
        {
            X,
            Y,
            Z
        }

        public static double[,] identMatrix()
        {
            return new double[4, 4]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };
        }

        static public  double [,] rotateMatrix(double sin, double cos, Axis axis)
        {
            switch (axis)
            {
                case Axis.X:
                    return new double[4, 4]
                    {
                        {1, 0, 0, 0},
                        {0, cos, sin, 0},
                        {0, -sin, cos, 0},
                        {0, 0, 0, 1}
                    };
                case Axis.Y:
                    return new double[4, 4]
                    {
                        {cos, 0, -sin, 0},
                        {0, 1, 0, 0},
                        {sin, 0, cos, 0},
                        {0, 0, 0, 1}
                    };

                case Axis.Z:
                    return new double[4, 4]
                    {
                        {cos, sin, 0, 0},
                        {-sin, cos, 0, 0},
                        {0, 0, 1, 0},
                        {0, 0, 0, 1}
                    };
                default:
                    throw new ArgumentException("Invalid axis");
            }
        }

        public static double[,] Scale(double xScale, double yScale, double zScale)
        {
            return new double[4, 4]
            {
                {xScale, 0, 0, 0},
                {0, yScale, 0, 0},
                {0, 0, zScale, 0},
                {0, 0, 0, 1}
            };
        }

        public static double [,] translateMatrix(double dx, double dy, double dz)
        {
            return new double[,]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {dx, dy, dz, 1}
            };
        }

        public static double[,] PerspectiveCamera(double zFar, double zNear, double fovX, double fovY)
        {
            return new double[4, 4]
            {
                {1/Math.Tan(fovX/2), 0, 0, 0},
                {0,1/Math.Tan(fovY/2), 0, 0},
                {0, 0, -(zFar+zNear)/(zFar-zNear), -1},
                {0, 0, -(2*zFar*zNear)/(zFar-zNear), 0}
            };

        }

        public static double[,] OrthographicCamera(double zFar, double zNear, double width, double height)
        {
            return new double[4, 4]
            {
                {1/width, 0, 0, 0},
                {0,1/height, 0, 0},
                {0, 0, -2/(zFar - zNear), 0},
                {0, 0, -(zFar + zNear)/(zFar - zNear), 1}
            };

        }

       public static double [,] FullRotationMatrix(Vector3D angles)
        {
            var res = identMatrix();
            int i = 0;
            foreach(var angle in new double[3] { angles.X, angles.Y, angles.Z })
            {
                var rAngle = -angle * Math.PI / 180;
                res = Helpers.MultiplyMatrix(res, rotateMatrix(Math.Sin(rAngle), Math.Cos(rAngle), (Axis)i));
                i++;
            }
            return res;
        }


        static public Transformator CameraTransform3D(Camera camera, bool perspective = true)
        {
            var center = camera.Position;
            var resMatrix = FullRotationMatrix(camera.Direction);
            resMatrix =
                Helpers.MultiplyMatrix(translateMatrix(-center.X, -center.Y, -center.Z), resMatrix);
            if (perspective)
            {
                resMatrix = Helpers.MultiplyMatrix(resMatrix,
                    PerspectiveCamera(camera.zFar, camera.zNear, camera.fovX, camera.fovY));
            }
            else
            {
                resMatrix = Helpers.MultiplyMatrix(resMatrix,
                   OrthographicCamera(camera.zFar, camera.zNear, camera.width / 2, camera.height / 2));
            }
            resMatrix = Helpers.MultiplyMatrix(resMatrix,
                    Scale(camera.width/2, camera.height/2, 1));
           
            return new CustomMatrixTransformator(resMatrix);
        }



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
