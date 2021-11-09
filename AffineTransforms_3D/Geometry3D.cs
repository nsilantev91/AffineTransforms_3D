using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Media.Media3D;

namespace AffineTransforms_3D
{
    /*public class Point3D
    {
        Point3D point;

        public double X { get; set; } = 0;
        public double Y { get; set; } = 0;
        public double Z { get; set; } = 0;

        public Point3D(double X, double Y, double Z = 0)
        {
            this.X = X;
            this.Y = Y;
            this.Z = Z;
        }

        public Point GetPoint()
        {
            return new Point((int)X, (int)Y);
        }
    }
    */
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
            edges.Add(edge);
        }
    }

    //многогранник
    [Serializable]
    public class Figure
    {
        //cписок ребер
        public List<Edge> edges { get; }

        //список вершин
        public List<Point3D> vertexes { get; set; }

       
        //матрица смежности
        public Dictionary<Point3D, List<Point3D>> adjacencyMatrix { get; }

        public List<Side> faces { get; }

        public Figure()
        {
            edges = new List<Edge>();
            vertexes = new List<Point3D>();
            adjacencyMatrix = new Dictionary<Point3D, List<Point3D>>();
            faces = new List<Side>();
        }

        public Figure(List<Point3D> points) : this()
        {
            vertexes = points;
            foreach (var p in points)
                adjacencyMatrix.Add(p, new List<Point3D>());
        }

        public void AddEdge(Point3D p1, Point3D p2)
        {
            if (!vertexes.Contains(p1))
                vertexes.Add(p1);
            if (!vertexes.Contains(p2))
                vertexes.Add(p2);
            if (!edges.Contains(new Edge(p1, p2)))
                edges.Add(new Edge(p1, p2));
            if (!adjacencyMatrix.ContainsKey(p1))
                adjacencyMatrix.Add(p1, new List<Point3D> { p2 });
            else
                adjacencyMatrix[p1].Add(p2);
        }
       
        public void AddEdges(Point3D startPoint, List<Point3D> pointsList)
        {
            foreach (var point in pointsList)
                AddEdge(startPoint, point);
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
                AddEdge(points[i], points[i + 1]);
                side.addEdge(new Edge(points[i], points[i + 1]));
            }
            AddEdge(points.Last(), points.First());
            side.addEdge(new Edge(points.Last(), points.First()));
            faces.Add(side);
        }

    }


}
