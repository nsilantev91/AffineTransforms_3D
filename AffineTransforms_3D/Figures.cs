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
        static public Figure createRotateFigure(Point3D[] forming, int partsNumber, (int, int, int) xyz)
        {
            var resFigure = new Figure();
            List<Point3D> transformedPoints = new List<Point3D>();
            transformedPoints.AddRange(forming);
            float angle = 360.0f / partsNumber;
            var centerPoint = new Point3D(0, 0, 0);
            for (int i = 0; i < forming.Length * partsNumber; i++)
            {
                var transformator = AffineTransforms.RotateTransform3D(centerPoint, angle, xyz.Item1, xyz.Item2, xyz.Item3);
                var point = transformator.Transform(transformedPoints[i]);
                transformedPoints.Add(point);
            }
            var formingPNumber = forming.Length;
            var countPoints = transformedPoints.Count;
            for (int l = 0; l < partsNumber; l++)
            {
                for (int p = 0; p < formingPNumber; p++)
                {
                    int currentPoint = l * formingPNumber + p;
                    int rightPoint = (currentPoint + formingPNumber) % countPoints;
                    if ((currentPoint + 1) % formingPNumber == 0)
                        resFigure.AddEdge(transformedPoints[currentPoint], transformedPoints[rightPoint]);
                    else
                    {
                        resFigure.AddFace(new[]{ transformedPoints[currentPoint],  transformedPoints[currentPoint+1],
                            transformedPoints[(currentPoint + 1 + formingPNumber) % countPoints],
                             transformedPoints[(currentPoint + formingPNumber) % countPoints]  });
                    }

                }
            }
            var center = resFigure.FigureCenter();
            return Transformator.Transform(resFigure,
                AffineTransforms.ScaleTransform3D(center, 0.7, 0.7, 0.7));
        }
    }

    //Тетраэдр
    [Serializable]
    class Tetrahedron : Figure
    {
        Point3D a = new Point3D(0, 0, 0);
        Point3D b = new Point3D(220, 0, 220);
        Point3D c = new Point3D(220, 220, 0);
        Point3D d = new Point3D(0, 220, 220);
        public Tetrahedron() : base()
        {
            AddEdges(a, new List<Point3D> { b, d, c });
            AddEdges(b, new List<Point3D> { d });
            AddEdges(c, new List<Point3D> { b, d });
        }
    }

    //Гексаэдр
    [Serializable]
    class Hexahedron : Figure
    {
        Point3D a = new Point3D(0, 0, 0);
        Point3D b = new Point3D(220, 0, 0);
        Point3D c = new Point3D(220, 0, 220);
        Point3D d = new Point3D(0, 0, 220);
        Point3D a1 = new Point3D(0, 220, 0);
        Point3D b1 = new Point3D(220, 220, 0);
        Point3D c1 = new Point3D(220, 220, 220);
        Point3D d1 = new Point3D(0, 220, 220);
        
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
    [Serializable]
    class Octahedron : Figure
    {
        Point3D a = new Point3D(0, 0, 0);
        Point3D b = new Point3D(220, 220, 0);
        Point3D c = new Point3D(-220, 220, 0);
        Point3D d = new Point3D(0, 220, -220);
        Point3D e = new Point3D(0, 220, 220);
        Point3D f = new Point3D(0, 440, 0);

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

    [Serializable]
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

    [Serializable]
    class Dodecahedron:Figure
    {
        private void MakeVertices(double sLen)
        {
            double s = sLen;
            //double t1 = 2.0 * Math.PI / 5.0;
            double t2 = Math.PI / 10.0;
            double t3 = 3.0 * Math.PI / 10.0;
            double t4 = Math.PI / 5.0;
            double d1 = s / 2.0 / Math.Sin(t4);
            double d2 = d1 * Math.Cos(t4);
            double d3 = d1 * Math.Cos(t2);
            double d4 = d1 * Math.Sin(t2);
            double Fx =
                (s * s - (2.0 * d3) * (2.0 * d3) -
                    (d1 * d1 - d3 * d3 - d4 * d4)) /
                        (2.0 * (d4 - d1));
            double d5 = Math.Sqrt(0.5 *
                (s * s + (2.0 * d3) * (2.0 * d3) -
                    (d1 - Fx) * (d1 - Fx) -
                        (d4 - Fx) * (d4 - Fx) - d3 * d3));
            double Fy = (Fx * Fx - d1 * d1 - d5 * d5) / (2.0 * d5);
            double Ay = d5 + Fy;

            Point3D A = new Point3D(d1, Ay, 0);
            Point3D B = new Point3D(d4, Ay, d3);
            Point3D C = new Point3D(-d2, Ay, s / 2);
            Point3D D = new Point3D(-d2, Ay, -s / 2);
            Point3D E = new Point3D(d4, Ay, -d3);
            Point3D F = new Point3D(Fx, Fy, 0);
            Point3D G = new Point3D(Fx * Math.Sin(t2), Fy,
                Fx * Math.Cos(t2));
            Point3D H = new Point3D(-Fx * Math.Sin(t3), Fy,
                Fx * Math.Cos(t3));
            Point3D I = new Point3D(-Fx * Math.Sin(t3), Fy,
                -Fx * Math.Cos(t3));
            Point3D J = new Point3D(Fx * Math.Sin(t2), Fy,
                -Fx * Math.Cos(t2));
            Point3D K = new Point3D(Fx * Math.Sin(t3), -Fy,
                Fx * Math.Cos(t3));
            Point3D L = new Point3D(-Fx * Math.Sin(t2), -Fy,
                Fx * Math.Cos(t2));
            Point3D M = new Point3D(-Fx, -Fy, 0);
            Point3D N = new Point3D(-Fx * Math.Sin(t2), -Fy,
                -Fx * Math.Cos(t2));
            Point3D O = new Point3D(Fx * Math.Sin(t3), -Fy,
                -Fx * Math.Cos(t3));
            Point3D P = new Point3D(d2, -Ay, s / 2);
            Point3D Q = new Point3D(-d4, -Ay, d3);
            Point3D R = new Point3D(-d1, -Ay, 0);
            Point3D S = new Point3D(-d4, -Ay, -d3);
            Point3D T = new Point3D(d2, -Ay, -s / 2);


            Point3D[][] faces = new Point3D[12][];
            faces[0] = new Point3D[5] {A, B, C, D, E };
            faces[1] = new Point3D[5] { A, F, K, G, B };
            faces[2] = new Point3D[5] { B, G, L, H, C };
            faces[3] = new Point3D[5] { C, H, M, I, D };
            faces[4] = new Point3D[5] { D, I, N, J, E };
            faces[5] = new Point3D[5] { E, J, O, F, A };

            faces[6] = new Point3D[5] { T, P, Q, R, S };
            faces[7] = new Point3D[5] { T, O, F, K, P };
            faces[8] = new Point3D[5] { P, K, G, L, Q};
            faces[9] = new Point3D[5] { Q, L, H, M, R };
            faces[10] = new Point3D[5] { R, M, I, N, S};
            faces[11] = new Point3D[5] { S, N, J, O, T };
            foreach(var f in faces)
            {
                AddFace(f);
            }


        }

       
        private void AddFace(Point3D[] points)
        {
            for(int i = 0; i < points.Length - 1; i++)
            {
                AddEdge(points[i], points[i+1]);
            }
            AddEdge(points.Last(), points.First());
        }

       public Dodecahedron(double sideLen)
       {
            MakeVertices(sideLen);
       }
    }

    
}
