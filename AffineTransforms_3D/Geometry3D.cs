﻿using System;
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
        public IEnumerable<Point3D> Points()
        {
            yield return begin;
            yield return end;
        }

        public Point3D begin { get; set; }
        public Point3D end { get; set; }
        public Edge(Point3D beg, Point3D end)
        {
            begin = beg;
            this.end = end;
        }

        public bool Contains(Point3D point)
        {
            return begin == point || end == point;
        }
        static public bool operator ==(Edge edge1, Edge edge2)
        {
            return edge1.begin == edge2.begin && edge1.end == edge2.end;
        }

        static public bool operator !=(Edge edge1, Edge edge2)
        {
            return !(edge1 == edge2);
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
        public List<Edge> edges { get; set; }


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

        public bool ContainsPoint(Point3D point)
        {
            foreach (var e in edges)
            {
                if (e.begin == point || e.end == point)
                    return true;
            }
            return false;
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
            var p3 = edges.Last().begin;

            var res = Vector3D.CrossProduct(p2 - p1, p3 - p1);
            res.Normalize();

            return res;
        }
    }

    //многогранник
    [Serializable]
    public class Figure
    {
        public List<List<bool>> VisiblePoints()
        {
            var res = new List<List<bool>>();
            var faces = Faces.ToList();
            var maxY = new SortedDictionary<int, double>();
            var minY = new SortedDictionary<int, double>();
            if (faces[0].edges[0].begin.Z < faces[1].edges[0].begin.Z)
                faces.Reverse();
            foreach (var i in faces)
            {
                res.Add(new List<bool>());
                foreach (var j in i.edges)
                {
                    var x = Convert.ToInt32(j.begin.X);
                    var y = j.begin.Y;
                    if (maxY.ContainsKey(x))
                    {
                        if (maxY[x] <= y)
                        {
                            res.Last().Add(true);
                            //Console.WriteLine(maxY[x] + " max was swapped out for " + y + " at position " + x);
                            maxY[x] = y;
                        }
                        else if (minY[x] >=y )
                        {
                            res.Last().Add(true);
                            //Console.WriteLine(maxY[x] + " min was swapped out for " + y + " at position " + x);
                            minY[x] = y;
                        }
                        else
                            res.Last().Add(false);
                    }
                    else
                    {
                        maxY.Add(x, y);
                        minY.Add(x, y);
                        res.Last().Add(true);
                    }
                }
            }
            return res;
        }


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
        public virtual IEnumerable<Tuple<Point3D, Vector3D>> Vertexes
        {
            get
            {
                foreach (var f in Faces)
                {
                    foreach (var e in f.edges)
                    {
                        var adjacentFaces = Faces.Where(face => face.ContainsPoint(e.begin)).ToList();
                        var sumVect = new Vector3D(0, 0, 0);
                        foreach (var face in adjacentFaces)
                            sumVect += face.NormalVec();
                        yield return  new Tuple<Point3D, Vector3D>(e.begin, sumVect / adjacentFaces.Count);
                    }
                }
            }
        }

        //в базовой реализации хранятся грани, точки и рёбра вычисляются по граням
        public List<Face> faces;

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
            var x = Vertexes.Average(point => point.Item1.X);
            var y = Vertexes.Average(point => point.Item1.Y);
            var z = Vertexes.Average(point => point.Item1.Z);
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


        public List<Face> VisibleFaces(Camera cam)
        {
            var camera = cam.Position;
            var res = new List<Face>();
            var center = FigureCenter();
            var matrix = AffineTransforms.FullRotationMatrix(cam.Direction);
            //matrix =
            //    Helpers.MultiplyMatrix(AffineTransforms.translateMatrix(center.X, center.Y, center.Z), matrix);
            //matrix = Helpers.MultiplyMatrix(matrix,
            //       AffineTransforms.PerspectiveCamera(cam.zFar, cam.zNear, cam.fovX, cam.fovY));
            //matrix = Helpers.MultiplyMatrix(matrix,
            //        AffineTransforms.Scale(cam.width / 2, cam.height / 2, 1));
            var transformator = new CustomMatrixTransformator(matrix);
            var p1 = new Point3D(0,0,-1);
            p1 = transformator.Transform(p1);
            camera = transformator.Transform(camera);
            foreach (var i in faces)
            {

                var t = i.NormalVec();
                var CenToFace = i.SideCenter() - center;
                if (Vector3D.DotProduct(t, CenToFace) < 0)
                    t *= -1;
                //var visVector = i.SideCenter()-camera;
                var visVector = p1 - camera;

                /*
                var angle = Math.Acos(
                (t.X * visVector.X + t.Y * visVector.Y + t.Z * visVector.Z) /
                (Math.Sqrt(t.X * t.X + t.Y * t.Y + t.Z * t.Z) + Math.Sqrt(visVector.X * visVector.X + visVector.Y * visVector.Y + visVector.Z * visVector.Z)));
                if (angle % 180 < 90)
                res.Add(i);
                */
                if (Vector3D.DotProduct(visVector, t) < 0)
                    res.Add(i);
            }
            return res;
        }
    }
}



