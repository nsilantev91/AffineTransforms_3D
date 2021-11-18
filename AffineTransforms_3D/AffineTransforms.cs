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

        enum Axis
        {
            X,
            Y,
            Z
        }

        static double[,] identMatrix()
        {
            return new double[4, 4]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {0, 0, 0, 1}
            };
        }

        static double [,] rotateMatrix(double sin, double cos, Axis axis)
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

        static double[,] Scale(double xScale, double yScale, double zScale)
        {
            return new double[4, 4]
            {
                {xScale, 0, 0, 0},
                {0, yScale, 0, 0},
                {0, 0, zScale, 0},
                {0, 0, 0, 1}
            };
        }

        static double [,] translateMatrix(double dx, double dy, double dz)
        {
            return new double[,]
            {
                {1, 0, 0, 0},
                {0, 1, 0, 0},
                {0, 0, 1, 0},
                {dx, dy, dz, 1}
            };
        }

        static double[,] PerspectiveCamera(double zFar, double zNear, double fovX, double fovY)
        {
            return new double[4, 4]
            {
                {1/Math.Tan(fovX/2), 0, 0, 0},
                {0,1/Math.Tan(fovY/2), 0, 0},
                {0, 0, (zFar+zNear)/(zFar-zNear), 1},
                {0, 0, -(2*zFar*zNear)/(zFar-zNear), 0}
            };

        }

        static double[,] OrthographicCamera(double zFar, double zNear, double width, double height)
        {
            return new double[4, 4]
            {
                {1/width, 0, 0, 0},
                {0,1/height, 0, 0},
                {0, 0, 2/(zFar - zNear), 0},
                {0, 0, (zFar + zNear)/(zFar - zNear), 1}
            };

        }

        static (double, double) SinCosWithQuater(double sin, double cos)
        {
            if (cos == 0)
            {
                return sin > 0 ? (sin, cos) : (-sin, cos);
            }
            if (sin == 0)
            {
                return cos > 0 ? (sin, cos) :(sin, -cos);
            }
            //if (sin > 0 && cos > 0)
            //{
            //    return (sin, cos);
            //} else if (sin > 0 && cos < 0)
            //{
            //    return (sin, cos);
            //}
            //else if(sin<0 && cos<0)
            //{
            //    return (sin, cos);
            //}
            //else
            //{
            //    return (sin, cos);
            //}
            return (sin, cos);
        }

      
        static public Transformator CameraTransform3D(Camera camera, bool perspective = true)
        {
            var center = camera.Position;
            var cameraVector = camera.Direction;
            var resMatrix = translateMatrix(-center.X, -center.Y, -center.Z);
            var r = Math.Sqrt(cameraVector.X * cameraVector.X + cameraVector.Z * cameraVector.Z);
            var cosY = 0.0;
            var sinY = 1.0;
            if (r != 0)
            {
                sinY = cameraVector.X / r;
                cosY = cameraVector.Z / r;
                (sinY, cosY) = SinCosWithQuater(sinY, cosY);
                resMatrix = Helpers.MultiplyMatrix(resMatrix,
               rotateMatrix(-sinY, cosY, Axis.Y));
            }
            var cosX = 0.0;
            var sinX = 1.0;
            r = Math.Sqrt(cameraVector.Y * cameraVector.Y + cameraVector.Z * cameraVector.Z);
            if (r != 0)
            {
                sinX = cameraVector.Y / r;
                cosX = cameraVector.Z / r;
                (sinX, cosX) = SinCosWithQuater(sinX, cosX);
                resMatrix = Helpers.MultiplyMatrix(resMatrix,
               rotateMatrix(sinX, cosX, Axis.X));
            }

            //var transformator = new CustomMatrixTransformator(resMatrix);
            //var p = new Point3D(center.X, center.Y + 1, center.Z);
            //var p1 = transformator.Transform(p);
            //r = Math.Sqrt(p1.X * p1.X + p1.Y * p1.Y);
            //var cosZ = 0.0;
            //var sinZ = 1.0;
            //if (r != 0)
            //{
            //    sinZ = -p1.X / r;
            //    cosZ = p1.Y / r;
            //    resMatrix = Helpers.MultiplyMatrix(resMatrix,
            //    rotateMatrix(sinZ, cosZ, Axis.Z));
            //}
            //    //var sinZ = sinX * cosY + sinY * cosX;
                //var cosZ = cosX * cosY - sinX * sinY;
                //transformator = new CustomMatrixTransformator(resMatrix);
                // var p2 = transformator.Transform(p);
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
