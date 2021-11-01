using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        PointF3D a = new PointF3D(0, 0, 0);
        PointF3D b = new PointF3D(200, 0, 200);
        PointF3D c = new PointF3D(200, 200, 0);
        PointF3D d = new PointF3D(0, 200, 200);
        public Tetrahedron() : base()
        {
            AddEdges(a, new List<PointF3D> { b, d, c });
            AddEdges(b, new List<PointF3D> { d });
            AddEdges(c, new List<PointF3D> { b, d });
        }
    }

    //Гексаэдр
    class Hexahedron : Figure
    {
        PointF3D a = new PointF3D(0, 0, 0);
        PointF3D b = new PointF3D(200, 0, 0);
        PointF3D c = new PointF3D(200, 0, 200);
        PointF3D d = new PointF3D(0, 0, 200);
        PointF3D a1 = new PointF3D(0, 200, 0);
        PointF3D b1 = new PointF3D(200, 200, 0);
        PointF3D c1 = new PointF3D(200, 200, 200);
        PointF3D d1 = new PointF3D(0, 200, 200);
        
        public Hexahedron() : base()
        {
            AddEdges(a, new List<PointF3D> { a1, b });
            AddEdges(b, new List<PointF3D> { b1, c });
            AddEdges(c, new List<PointF3D> { c1, d });
            AddEdges(d, new List<PointF3D> { a, d1 });
            AddEdges(a1, new List<PointF3D> { b1 });
            AddEdges(b1, new List<PointF3D> { c1 });
            AddEdges(c1, new List<PointF3D> { d1 });
            AddEdges(d1, new List<PointF3D> { a1 });
        }
    }

    //Октаэдр
    class Octahedron : Figure
    {
        PointF3D a = new PointF3D(0, 0, 0);
        PointF3D b = new PointF3D(200, 200, 0);
        PointF3D c = new PointF3D(-200, 200, 0);
        PointF3D d = new PointF3D(0, 200, -200);
        PointF3D e = new PointF3D(0, 200, 200);
        PointF3D f = new PointF3D(0, 400, 0);

        public Octahedron() : base()
        {
            AddEdges(a, new List<PointF3D> { b, d, c, e });
            AddEdges(b, new List<PointF3D> { d });
            AddEdges(c, new List<PointF3D> { e });
            AddEdges(d, new List<PointF3D> { c });
            AddEdges(e, new List<PointF3D> { b });
            AddEdges(f, new List<PointF3D> { b, d, c, e });
        }

    }
}
