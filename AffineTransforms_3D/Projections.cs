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
        public static double [,] GetProjectionForCamera(double width, double height)
        {
            return new double[,] {
                { width, 0, 0, 0 },
                { 0, height, 0, 0 },
                { 0, 0, 1, 0},
                { 0, 0, 0, 1 }
            };
        }

    }
}
