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
            camera.Direction.X = -1;
            camera.Direction.Y = -1;
            camera.Direction.Z = -1;
            camera.Position.X = 300;
            camera.Position.Y = 300;
            camera.Position.Z = 300;
            camera.width = 800;
            camera.height = 600;
            camera.fovX = camera.fovY = Math.PI / 2;
            camera.zFar = 1000;
            camera.zNear = 200;
            Axes axes = new Axes();
            var transformator = AffineTransforms.CameraTransform3D(camera);
            var p = new Point3D(-1, -1, -1);
            var p1 = transformator.Transform(p);
            var newAxes = Transformator.Transform(axes, transformator);
            Console.WriteLine("s");
        }
    }
}
