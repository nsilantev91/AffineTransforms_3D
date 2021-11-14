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
    public class Face
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

        public Face()
        {
            edges = new List<Edge>();
        }

        public Face(IEnumerable<Edge> edges) : this()
        {
            this.edges.AddRange(edges);
        }

        public void addEdge(Edge edge)
        {
            if (edge.begin == edge.end)
                return;
            edges.Add(edge);
        }
    }

    //многогранник
    [Serializable]
    public class Figure
    {
       //можно и нужно переопределять, если использовать другой способ хранения фигуры
        public virtual IEnumerable<Edge> Edges
        {
            get
            {
                foreach(var f in Faces)
                {
                    foreach(var e in f.edges)
                    {
                        yield return e;
                    }
                }
            }
        }

        //можно и нужно переопределять, если использовать другой способ хранения фигуры
        public virtual IEnumerable<Point3D> Vertexes
        {
            get
            {
                foreach (var f in Faces)
                {
                    foreach (var e in f.edges)
                    {
                        yield return e.begin;
                    }
                }
            }
        }

        //в базовой реализации хранятся грани, точки и рёбра вычисляются по граням
        List<Face> faces;

        //можно и нужно переопределять, если использовать другой способ хранения фигуры
        public virtual IEnumerable<Face> Faces => faces;

        public Figure()
        {
            faces = new List<Face>();
        }

       public void Transform(Transformator transformator)
        {
            foreach (var face in Faces)
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
            var x = Vertexes.Average(point => point.X);
            var y = Vertexes.Average(point => point.Y);
            var z = Vertexes.Average(point => point.Z);
            return new Point3D(x, y, z);
        }

        public void AddFace(Point3D[] points)
        {
            var side = new Face();
            for (int i = 0; i < points.Length - 1; i++)
            {
                
                side.addEdge(new Edge(points[i], points[i + 1]));
            }
            side.addEdge(new Edge(points.Last(), points.First()));
            faces.Add(side);
        }

    }


}
