using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using AffineTransforms_3D;
using Camera = AffineTransforms_3D.Camera;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Camera camera = new Camera();
            camera.Direction.X = 0;
            camera.Direction.Y = -1;
            camera.Direction.Z = -1;
            camera.Position.X = 0;
            camera.Position.Y = 300;
            camera.Position.Z = 300;
            camera.width = 800;
            camera.height = 600;
            camera.fovX = camera.fovY = Math.PI / 2;
            camera.zFar = 1000;
            camera.zNear = 200;
            Axes axes = new Axes();
            var center = camera.Position;
            var cameraVector = camera.Direction;
            var resMatrix = AffineTransforms.translateMatrix(-center.X, -center.Y, -center.Z);
            double r;
            r = Math.Sqrt(cameraVector.X * cameraVector.X + cameraVector.Z * cameraVector.Z);
            var cosY = 0.0;
            var sinY = 1.0;
            if (r != 0)
            {
                sinY = cameraVector.X / r;
                cosY = cameraVector.Z / r;
                //(sinY, cosY) = AffineTransforms.SinCosWithQuater(sinY, cosY);
                resMatrix = Helpers.MultiplyMatrix(resMatrix,
                AffineTransforms.rotateMatrix(-sinY, cosY, AffineTransforms.Axis.Y));
            }
            var cosX = 0.0;
            var sinX = 1.0;
            r = Math.Sqrt(cameraVector.Y * cameraVector.Y + cameraVector.Z * cameraVector.Z);
            if (r != 0)
            {
                sinX = cameraVector.Y / r;
                cosX = cameraVector.Z / r;
               // (sinX, cosX) = AffineTransforms.SinCosWithQuater(sinX, cosX);
                resMatrix = Helpers.MultiplyMatrix(resMatrix,
                AffineTransforms.rotateMatrix(sinX, cosX, AffineTransforms.Axis.X));
            }

            var transformator = new CustomMatrixTransformator(resMatrix);
            var p = new Point3D(0, 0, 0);
            var p1 = transformator.Transform(p);
            var newAxes = Transformator.Transform(axes, transformator);
            Console.WriteLine("s");
        }
    }
}
