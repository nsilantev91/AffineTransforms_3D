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

    class Icosahedron : Figure
    {
        const double X = 0.525731112119133606;
        const double Z = 0.850650808352039932;
        const double N = 0.0;

        static Point3D[] vertices = new Point3D [12]
        {
            new Point3D(-X,N,Z), new Point3D(X,N,Z),new Point3D(-X,N,-Z), new Point3D(X,N,-Z),
            new Point3D(N,Z,X), new Point3D(N,Z,-X), new Point3D(N,-Z,X), new Point3D(N,-Z,-X),
            new Point3D (Z,X,N), new Point3D(-Z,X, N), new Point3D(Z,-X,N), new Point3D(-Z,-X, N)
        };

        static int[,] triangles = new int[20,3]
        {
            {0,4,1},{0,9,4},{9,5,4},{4,5,8},{4,8,1},
            {8,10,1},{8,3,10},{5,3,8},{5,2,3},{2,7,3},
            {7,10,3},{7,6,10},{7,11,6},{11,0,6},{0,1,6},
            {6,1,10},{9,0,11},{9,11,2},{9,2,5},{7,2,11}
        };

        public Icosahedron(double c)
        {
            for(int i = 0; i < 20; i++)
            {
                for(int j = 0; j < 3; j++)
                {
                    var p1 = vertices[triangles[i, j]];
                    var p2 = vertices[triangles[i, (j + 1) % 3]];
                    p1.X *= c;
                    p1.Y *= c;
                    p1.Z*= c;
                    p2.X *= c;
                    p2.Y *= c;
                    p2.Z *= c;
                    AddEdge(p1, p2);
                }
            }
        }
    }
}
