using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;

namespace AffineTransforms_3D
{
    static public class Figures
    {
        static public Figure Tetrahedron = new Tetrahedron();
        static public Figure Hexahedron  = new Hexahedron();
        static public Figure Octahedron = new Octahedron();
    }

    //Тетраэдр
    class Tetrahedron : Figure
    {
        Point3D a = new Point3D(0, 0, 0);
        Point3D b = new Point3D(200, 0, 200);
        Point3D c = new Point3D(200, 200, 0);
        Point3D d = new Point3D(0, 200, 200);
        public Tetrahedron() : base()
        {
            AddEdges(a, new List<Point3D> { b, d, c });
            AddEdges(b, new List<Point3D> { d });
            AddEdges(c, new List<Point3D> { b, d });
        }
    }

    //Гексаэдр
    class Hexahedron : Figure
    {
        Point3D a = new Point3D(0, 0, 0);
        Point3D b = new Point3D(200, 0, 0);
        Point3D c = new Point3D(200, 0, 200);
        Point3D d = new Point3D(0, 0, 200);
        Point3D a1 = new Point3D(0, 200, 0);
        Point3D b1 = new Point3D(200, 200, 0);
        Point3D c1 = new Point3D(200, 200, 200);
        Point3D d1 = new Point3D(0, 200, 200);
        
        public Hexahedron() : base()
        {
            AddEdges(a, new List<Point3D> { a1, b });
            AddEdges(b, new List<Point3D> { b1, c });
            AddEdges(c, new List<Point3D> { c1, d });
            AddEdges(d, new List<Point3D> { a, d1 });
            AddEdges(a1, new List<Point3D> { b1 });
            AddEdges(b1, new List<Point3D> { c1 });
            AddEdges(c1, new List<Point3D> { d1 });
            AddEdges(d1, new List<Point3D> { a1 });
        }
    }

    //Октаэдр
    class Octahedron : Figure
    {
        Point3D a = new Point3D(0, 0, 0);
        Point3D b = new Point3D(200, 200, 0);
        Point3D c = new Point3D(-200, 200, 0);
        Point3D d = new Point3D(0, 200, -200);
        Point3D e = new Point3D(0, 200, 200);
        Point3D f = new Point3D(0, 400, 0);

        public Octahedron() : base()
        {
            AddEdges(a, new List<Point3D> { b, d, c, e });
            AddEdges(b, new List<Point3D> { d });
            AddEdges(c, new List<Point3D> { e });
            AddEdges(d, new List<Point3D> { c });
            AddEdges(e, new List<Point3D> { b });
            AddEdges(f, new List<Point3D> { b, d, c, e });
        }

    }
}
