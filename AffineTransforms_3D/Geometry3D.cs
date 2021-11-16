using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace AffineTransforms_3D
{

    //ребро
    [Serializable]
    public class Edge
    {
        public Point3D begin { get; set; }
        public Point3D end { get; set; }
        public Edge(Point3D beg, Point3D end)
        {
            begin = beg;
            this.end = end;
        }
    }

    //грань фигуры 
    [Serializable]
    public class Side
    {
        public Point3D SideCenter()
        {
            double x = 0;
            double y = 0;
            double z = 0;
            foreach (var e in edges)
            {
                x += e.begin.X;
                y += e.begin.Y;
                z += e.begin.Z;
            }
            return new Point3D(x / edges.Count, y / edges.Count, z / edges.Count);
        }
        public List<Edge> edges { get; }
        public Side()
        {
            edges = new List<Edge>();
        }
        public Side(IEnumerable<Edge> edges) : this()
        {
            this.edges.AddRange(edges);
        }
        public void addEdge(Edge edge)
        {
            if (edge.begin == edge.end)
                return;
            edges.Add(edge);
        }
        /*
        public List<double> SideEquation()
        {
            var p1 = edges[0].begin;
            var p2 = edges[0].end;
            var p3 = edges[1].end;

            var p3p1 = p2 - p1;
            var p3p2 = p3 - p1;

            var x = p3p1.Y * p3p2.Z - p3p1.Z * p3p2.Y;
            var y = -(p3p1.X * p3p2.Z - p3p1.Z * p3p2.X);
            var z = p3p1.X * p3p2.Y - p3p1.Y * p3p2.X;
            var d = -x * p1.X + -y * p1.Y + -z * p1.Z;
            return new List<double>{ x, y, z, d };
        }
        */
        public Vector3D NormalVec()
        {
            var p1 = edges[0].begin;
            var p2 = edges[0].end;
            var p3 = edges[1].end;

            return Vector3D.CrossProduct(p2 - p1, p3 - p2);
        }
    }

    //многогранник
    [Serializable]
    public class Figure
    {    
        public IEnumerable<Edge> edges
        {
            get
            {
                foreach(var f in faces)
                {
                    foreach(var e in f.edges)
                    {
                        yield return e;
                    }
                }
            }
        }

        public IEnumerable<Point3D> vertexes
        {
            get
            {
                foreach (var f in faces)
                {
                    foreach (var e in f.edges)
                    {
                        yield return e.begin;
                    }
                }
            }
        }

        ////список вершин
        //public List<Point3D> vertexes { get; set; }


        //матрица смежности
        // public Dictionary<Point3D, List<Point3D>> adjacencyMatrix { get; }

        public List<Side> faces { get; }

        public Figure()
        {
          //  adjacencyMatrix = new Dictionary<Point3D, List<Point3D>>();
            faces = new List<Side>();
        }

       public void Transform(Transformator transformator)
        {
            foreach (var face in faces)
            {
                var edges = face.edges;
                foreach (var edge in face.edges)
                {
                    edge.begin = transformator.Transform(edge.begin);
                    edge.end = transformator.Transform(edge.end);
                }          
            }
        }

        public Point3D FigureCenter()
        {
            var x = vertexes.Average(point => point.X);
            var y = vertexes.Average(point => point.Y);
            var z = vertexes.Average(point => point.Z);
            return new Point3D(x, y, z);
        }

        public void AddFace(Point3D[] points)
        {
            var side = new Side();
            for (int i = 0; i < points.Length - 1; i++)
            {
                
                side.addEdge(new Edge(points[i], points[i + 1]));
            }
            side.addEdge(new Edge(points.Last(), points.First()));
            faces.Add(side);
        }


        public List<Side> VisibleFaces(Vector3D visVector)
        {
            var res = new List<Side>();
            foreach (var i in faces)
            {
                var t = i.NormalVec();
                var angle = Math.Acos(
                    (t.X * visVector.X + t.Y * visVector.Y + t.Z * visVector.Z) /
                    (Math.Sqrt(t.X * t.X + t.Y * t.Y + t.Z * t.Z) + Math.Sqrt(visVector.X * visVector.X + visVector.Y * visVector.Y + visVector.Z * visVector.Z)));
                if (angle % 180 < 90)
                    res.Add(i);
            }
            return res;
        }
    }


}
