using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.Threading;


namespace AffineTransforms_3D
{
    enum Projection { Perspective, Orthogonal};
    enum Transform {Transposition, Rotate, Scale, Reflect }

    public  enum Function { Plus, Minus, Prod, SinCos, Sin, Plus3D, Prod3D }

    public struct GraphData
    {
        public int X0;
        public int X1;
        public int Y0;
        public int Y1;
        public int StepCount;
        public Function Fun;
    }

    public struct Camera
    {
        public Vector3D Direction;
        public Point3D Position;
        public double zNear;
        public double zFar;
        public double fovX;
        public double fovY;
        public double width;
        public double height;
    }

   
    public partial class Form1 : Form
    {
        Graphics g;
        List<(Transform,List<double>)> transforms = new List<(Transform, List<double>)>();
        Projection selectedProjetion;
        List<Figure> currentFigures;
        bool figureCenter;
        bool usingLine = false;
        bool usingZBuffer = false;
        bool rotatingCamera = false;
        CoordinatePlane plane;
        Point3D point1 = new Point3D(0,0,0);
        Point3D point2 = new Point3D(1,1,1);
        List<Point3D> forming;
        List<Point3D> showForming;
        Camera camera = new Camera();
        Axes axes = new Axes();
        int curDeg = 0;
      
       private void syncCamera()
        {
            if (rotatingCamera) return;
            camera.Position.X = double.Parse(cameraXTextBox.Text);
            camera.Position.Y = double.Parse(cameraYTextBox.Text);
            camera.Position.Z= double.Parse(cameraZTextBox.Text);
            //camera.Direction.X = double.Parse(cameraXTextBox.Text);
            //camera.Direction.Y = double.Parse(cameraYTextBox.Text);
            //camera.Direction.Z = double.Parse(cameraZTextBox.Text);
            camera.Direction.X = double.Parse(vectorXtextBox.Text);
            camera.Direction.Y = double.Parse(vectorYtextBox.Text);
            camera.Direction.Z = double.Parse(vectorZtextBox.Text);
            camera.zFar = double.Parse(zFarTextBox.Text);
            camera.zNear = double.Parse(zNearTextBox.Text);
            camera.fovX = double.Parse(fovXtextBox.Text) * Math.PI / 180;
            camera.fovY = double.Parse(fovYtextBox.Text) * Math.PI / 180;
            camera.width = pictureBox1.Width;
            camera.height = pictureBox1.Height;
        }

        private void syncGraph()
        {  
             graphData.Y1 = int.Parse(y1FunTextBox.Text); 
             graphData.X1 = int.Parse(x1FunTextBox.Text);
             graphData.X0 = int.Parse(x0FunTextBox.Text);
             graphData.Y0 = int.Parse(y0FunTextBox.Text);
             graphData.StepCount = int.Parse(stepCountTextBox.Text);
        }

        private void syncLine()
        {
            point1.X = double.Parse(textBoxX1.Text);
            point1.Y = double.Parse(textBoxY1.Text);
            point1.Z = double.Parse(textBoxZ1.Text);

            point2.X = double.Parse(textBoxX1.Text);
            point2.Y = double.Parse(textBoxY1.Text);
            point2.Z = double.Parse(textBoxZ1.Text);
        }


        GraphData graphData = new GraphData();
        public Form1()
        {
            /*
            var test = new Side();
            test.addEdge(new Edge(new Point3D(1, -2, 0), new Point3D(2, 0, -1)));
            test.addEdge(new Edge(new Point3D(2, 0, -1), new Point3D(0, -1, 2)));
            test.addEdge(new Edge(new Point3D(0, -1, 2), new Point3D(1,-2,0)));
            test.SideEquation();
            */

            InitializeComponent();
            syncCamera();
            planeComboBox.SelectedIndex = 0;
            transformComboBox.SelectedIndex = 0;
            AutoSize = true;
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Trebuchet MS",
                10.0f,
                FontStyle.Regular,
                GraphicsUnit.Point,
                ((byte)(204))
            );
            g = pictureBox1.CreateGraphics();
            proj_box.SelectedIndex = 0;
            figures_box.SelectedIndex = 0;
            funComboBox.SelectedIndex = 0;
            selectedProjetion = Projection.Perspective;
            currentFigures = new List<Figure>();
            forming = new List<Point3D>();
            axis_box.SelectedIndex = 0;
            showForming = new List<Point3D>();
            syncCamera();
            syncGraph();

        }

        private void showFigure_btn_Click(object sender, EventArgs e)
        {
            string figure = (string)figures_box.SelectedItem;
                if (figure == "Тетраэдр")
                    currentFigures.Add(Figures.Tetrahedron);

                if (figure == "Гексаэдр")
                    currentFigures.Add(Figures.Hexahedron);

                if (figure == "Октаэдр")
                    currentFigures.Add(Figures.Octahedron);

                if (figure == "Икосаэдр")
                    currentFigures.Add(new Icosahedron(150));

                if (figure == "Додэкаэдр")
                    currentFigures.Add(new Dodecahedron(150));
                if (figure == "График")
                    currentFigures.Add(new Graph(graphData));
                if (figure == "Плавающий горизонт")
                {
                    if ((string)funComboBox.SelectedItem == "y = x + z (3D)")
                        currentFigures.Add(new Graph3D(100, 100, 3, 1, Function3D.Sum));
                    else if ((string)funComboBox.SelectedItem == "y = 100*Sin(x/100)*Cos(z/100)(3D)")
                        currentFigures.Add(new Graph3D(100, 100, 10, 1, Function3D.Sin));
                    else if ((string)funComboBox.SelectedItem == "y = 10*(x/100)*(z/100)(3D)")
                        currentFigures.Add(new Graph3D(100, 100, 5, 5, Function3D.complex));
            }



            for (int i = 0; i < currentFigures.Count; i++)
            {
                var center = currentFigures[i].FigureCenter();
                currentFigures[i].Transform(AffineTransforms.TranslateTransform3D(-center.X, -center.Y, -center.Z));
            }
            ReDraw();
        }

       

        Transform parseTransform()
        {
           return (Transform)Enum.Parse(typeof(Transform), transformComboBox.SelectedItem.ToString());
        } 

       /// <summary>
       /// применение афинного преобразования к currentFigure 
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void transformButton_Click(object sender, EventArgs e)
        {
            if (currentFigures.Count == 0)
                return;
            var transform = parseTransform();
                switch (transform)
                {
                    case Transform.Rotate:
                        {
                            var degree = int.Parse(textBox1.Text);
                            (double, double, double) axis = (0, 0, 0);
                            switch (plane)
                            {
                                case CoordinatePlane.XY:
                                    axis = (0, 0, 1);
                                    break;
                                case CoordinatePlane.XZ:
                                    axis = (0, 1, 0);
                                    break;
                                case CoordinatePlane.YZ:
                                    axis = (1, 0, 0);
                                    break;

                            }
                            if (usingLine)
                            {
                                syncLine();
                                var v1 = new Vector3D(point1.X, point1.Y, point1.Z);
                                var v2 = new Vector3D(point2.X, point2.Y, point2.Z);
                                var v = v2 - v1;
                                currentFigures[0].Transform(
                                  AffineTransforms.RotateTransform3D(point1,
                                  degree, v.X, v.Y, v.Z));
                             } 
                            else
                            {
                                var point = figureCenter ? currentFigures[0].FigureCenter() : new Point3D(0, 0, 0);
                                currentFigures[0].Transform(
                                    AffineTransforms.RotateTransform3D(point,
                                    degree, axis.Item1, axis.Item2, axis.Item3));
                               
                                    
                        }                      
                            break;
                        }
                    case Transform.Transposition:
                        {
                            var x = double.Parse(textBox2.Text);
                            var y = double.Parse(textBox3.Text);
                            var z = double.Parse(textBox4.Text);
                            currentFigures[0].Transform(
                                AffineTransforms.TranslateTransform3D(x, y, z));
                          
                        break;
                        }
                    case Transform.Scale:
                        {
                            var x = double.Parse(textBox2.Text);
                            var y = double.Parse(textBox3.Text);
                            var z = double.Parse(textBox4.Text);
                            var point = figureCenter ? currentFigures[0].FigureCenter() : new Point3D(0, 0, 0);
                            if (!figureCenter)  currentFigures[0].Transform(
                                AffineTransforms.ScaleTransform3D(point,
                                x, y, z));
                            break;
                        }
                    case Transform.Reflect:
                        {
                            currentFigures[0].Transform(
                                AffineTransforms.ReflectionTransform(plane));
                        break;
                        }             
            }
            ReDraw();
        }

        private void applyCameraButton_Click(object sender, EventArgs e)
        {
            ReDraw();
        }


        /// <summary>
        /// Получение проекции currentFigure и её отрисовка
        /// </summary>
        void ReDraw()
        {
            syncCamera();
            g.Clear(BackColor);
            g.DrawPie(new Pen(Color.Red), new RectangleF(10, 10, 50, 50), 0, curDeg);
            var centerX = pictureBox1.Size.Width / 2;
            var centerY = pictureBox1.Size.Height / 2;
            List<Figure> figures = new List<Figure>();
            foreach (var currentFigure in currentFigures)
            {
                var cameraFig = Transformator.Transform(currentFigure,
                              AffineTransforms.CameraTransform3D(camera, selectedProjetion == Projection.Perspective));
                figures.Add(cameraFig);
            }
        
            if (usingZBuffer)
            {
                pictureBox1.Invalidate();
                pictureBox1.Image = ZBuffer.zBuffer(pictureBox1.Width, pictureBox1.Height, figures);
            }
            else
                foreach (var cameraFig in figures)
                    if ((string)figures_box.SelectedItem=="Плавающий горизонт")
                    {
                        for(var i=0; i<cameraFig.faces.Count; i++)
                            for (var j=0; j<cameraFig.faces[i].edges.Count;j++)
                            {
                                cameraFig.faces[i].edges[j].begin = new Point3D(Convert.ToInt32(cameraFig.faces[i].edges[j].begin.X), cameraFig.faces[i].edges[j].begin.Y, cameraFig.faces[i].edges[j].begin.Z);
                                cameraFig.faces[i].edges[j].end = new Point3D(Convert.ToInt32(cameraFig.faces[i].edges[j].end.X), cameraFig.faces[i].edges[j].end.Y, cameraFig.faces[i].edges[j].end.Z);
                            }
                        var visibles = cameraFig.VisiblePoints();
                        var t = new List<Face>(cameraFig.Faces);
                        if (t[0].edges[0].begin.Z < t[1].edges[0].begin.Z)
                            t.Reverse();
                        for (var i=0;i<t.Count;i++)
                        {
                            for(var j =0;j<t[i].edges.Count-1;j++)
                            {
                                if (visibles[i][j] && visibles[i][j+1])
                                    g.DrawLine(Pens.Black,
                                                (int)(t[i].edges[j].begin.X + centerX), (int)(t[i].edges[j].begin.Y + centerY),
                                                (int)(t[i].edges[j].end.X + centerX), (int)(t[i].edges[j].end.Y + centerY));
                            }
                        }
                    }
                    else if (RemoveEdges.Checked)
                        foreach (var side in cameraFig.VisibleFaces(camera))
                            foreach (var edge in side.edges)
                            {
                                g.DrawLine(Pens.Black,
                                    (int)(edge.begin.X + centerX), (int)(edge.begin.Y + centerY),
                                    (int)(edge.end.X + centerX), (int)(edge.end.Y + centerY));
                            }
                    else
                        foreach (var r in cameraFig.Edges)
                        {
                            g.DrawLine(Pens.Black, (int)(r.begin.X + centerX), (int)(r.begin.Y + centerY),
                               (int)(r.end.X + centerX), (int)(r.end.Y + centerY));
                        }
        }



        private void proj_box_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedProjetion = (Projection)proj_box.SelectedIndex;
        }

        private void clear_btn_Click(object sender, EventArgs e)
        {
            g.Clear(BackColor);
            currentFigures = new List<Figure>();
            transforms.Clear();
            forming.Clear();
            showForming.Clear();
            forming_x_box.Text = "0";
            forming_y_box.Text = "0";
            forming_z_box.Text = "0";
            num_parts_box.Text = "0";
            create_fig_btn.Enabled = false;
            num_parts_box.Enabled = false;


        }



        private void Form1_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (parseTransform())
            {
                case Transform.Rotate:
                    {
                        textBox1.Enabled = true;
                        textBox2.Enabled = false;
                        textBox3.Enabled = false;
                        textBox4.Enabled = false;
                        break;
                    }
                default:
                    {
                        textBox1.Enabled = false;
                        textBox2.Enabled = true;
                        textBox3.Enabled = true;
                        textBox4.Enabled = true;
                        break;
                    }
            }
        }
        public Vector3D ActualFuckingVector(Point3D camera, Figure figure)
        {
            var res = camera - figure.FigureCenter();
            res.Normalize();
            return res;
        }

        CoordinatePlane parsePlane()
        {
            return (CoordinatePlane)Enum.Parse(typeof(CoordinatePlane), planeComboBox.SelectedItem.ToString());
        }
        private void planeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            plane = parsePlane();
        }

        private void centerFigureCheckBox_CheckedChanged(object sender, EventArgs e)
        {
           figureCenter=centerFigureCheckBox.Checked;
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /*if (currentFigure.faces.Count == 0)
                return;*/
            //g.Clear(BackColor);
            //var centerX = Size.Width / 2 - 200;
            //var centerY = Size.Height / 2 - 150;
            //if (usingZBuffer)
            //{
            //    pictureBox1.Image = ZBuffer.zBuffer(pictureBox1.Width, pictureBox1.Height, currentFigure);
            //}
            
            //{
                /*foreach (var r in currentFigure.edges)
                {
                    g.DrawLine(Pens.Black, (int)(r.begin.X + centerX), (int)(r.begin.Y + centerY),
                       (int)(r.end.X + centerX), (int)(r.end.Y + centerY));
                }*/
            //}
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            point1.X=double.Parse(((TextBox)sender).Text);
        }

        private void textBoxY1_TextChanged(object sender, EventArgs e)
        {
            point1.Y = double.Parse(((TextBox)sender).Text);
            //if (currentFigure == null)
            //    return;
            //g.Clear(BackColor);
            //var centerX = Size.Width / 2 - 200;
            //var centerY = Size.Height / 2 - 150;
            //foreach (var r in currentFigure.Edges)
            //{
            //    g.DrawLine(Pens.Black, (int)(r.begin.X + centerX), (int)(r.begin.Y + centerY),
            //       (int)(r.end.X + centerX), (int)(r.end.Y + centerY));
            //}
        }

        

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            usingLine = ((CheckBox)sender).Checked;
        }
        private void PictureBox1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            forming_x_box.Text = e.X.ToString();
            forming_y_box.Text = e.Y.ToString();
        }
        private void create_fig_btn_Click(object sender, EventArgs e)
        {
            figures_box.SelectedIndex = 5;
            (int, int, int) xyz = (0, 0, 0);
            if (axis_box.SelectedIndex == 0)
                xyz.Item1 = 1;
            if (axis_box.SelectedIndex == 1)
                xyz.Item2 = 1;
            if (axis_box.SelectedIndex == 2)
                xyz.Item3 = 1;
            var res = Figures.createRotateFigure(forming.ToArray(), int.Parse(num_parts_box.Text),xyz);
            currentFigures.Add(res);
            ReDraw();
        }

        

        private void add_point_btn_Click(object sender, EventArgs e)
        {
            var x = int.Parse(forming_x_box.Text);
            var y = int.Parse(forming_y_box.Text);
            var z = int.Parse(forming_z_box.Text);
            showForming.Add(new Point3D(x, y, z));
            forming.Add(new Point3D(x - 200, y - 200, z));
            var transformator = AffineTransforms.CameraTransform3D(camera, selectedProjetion == Projection.Perspective);
            if (forming.Count >=2)
            {
                num_parts_box.Enabled = true;
                Point[] points = new Point[forming.Count];
                for(int i = 0; i< showForming.Count; i++)
                {
                    var p = showForming[i];
                    transformator.Transform(p);
                    points[i] = new Point((int)p.X,(int) p.Y);
                }
                g.DrawLines(Pens.Black, points);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            int res = 0;
            if (int.TryParse(num_parts_box.Text, out res) && forming.Count >= 2)
            {
                create_fig_btn.Enabled = true;
            }

        }

        private void Saver_Click(object sender, EventArgs e)
        {
            if (currentFigures.Count != 0)
            { 
                SaveFileDialog saveFile = saveFileDialog1;
                saveFile.InitialDirectory = "c:\\";
                saveFile.Filter = "Figure (*.fig)|*.fig|All files (*.*)|*.*";
            
                if (saveFile.ShowDialog()==DialogResult.OK)
                {
                    var path = Path.GetFullPath(saveFile.FileName);
                    var t = new FileWorker(currentFigures, selectedProjetion,(string)figures_box.SelectedItem);
                    FileHelper.WriteToBinaryFile(path, t);
                }
            }

        }

        private void Opener_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = openFileDialog1;
            openFile.InitialDirectory = "c:\\";
            openFile.Filter = "Figure (*.fig)|*.fig|All files (*.*)|*.*";
            if (openFile.ShowDialog()==DialogResult.OK)
            {
                clear_btn_Click(sender, e);

                var path = Path.GetFullPath(openFile.FileName);
                var t = FileHelper.ReadFromBinaryFile<FileWorker>(path);
                currentFigures = t.fig;
                selectedProjetion = t.proj;
                proj_box.SelectedIndex = (int)t.proj;
                figures_box.SelectedIndex = figures_box.Items.IndexOf(t.fname);
                ReDraw();
                //showFigure_btn_Click(sender, e);
            }

        }

        private void funComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphData.Fun = (sender as ComboBox).SelectedItem.ToString().ParseFun();
        }

        private void stepCountTextBox_TextChanged(object sender, EventArgs e)
        {
            graphData.StepCount = int.Parse(stepCountTextBox.Text);
        }

        private void rotateCameraButton_Click(object sender, EventArgs e)
        {
            rotatingCamera = true;
            var degree = 1;
            (double, double, double) axis = (0, 0, 0);
            switch (plane)
            {
                case CoordinatePlane.XY:
                    axis = (0, 0, 1);
                    break;
                case CoordinatePlane.XZ:
                    axis = (0, 1, 0);
                    break;
                case CoordinatePlane.YZ:
                    axis = (1, 0, 0);
                    break;

            }
            var p = camera.Position;
            var cVec = camera.Direction;
            var transformator = AffineTransforms.RotateTransform3D(new Point3D(0,0,0),
                                    degree, axis.Item1, axis.Item2, axis.Item3);
           

            for (int i = 0; i < 360/degree; i+=degree)
            {
                curDeg += degree;
                Thread.Sleep(10);
                camera.Position = transformator.Transform(camera.Position);
                switch (plane)
                {
                    case CoordinatePlane.XY:
                        camera.Direction.Z += degree;
                        break;
                    case CoordinatePlane.XZ:
                        camera.Direction.Y += degree;
                        break;
                    case CoordinatePlane.YZ:
                        camera.Direction.X += degree;
                        break;

                }
                ReDraw();
            }

            curDeg = 0;
            rotatingCamera = false;
            camera.Direction = cVec;
        }

        private void zBuf_check_btn_CheckedChanged(object sender, EventArgs e)
        {
            usingZBuffer = !usingZBuffer;
        }

        private void forming_y_box_TextChanged(object sender, EventArgs e)
        {

        }
    }


    public static class EnumExtension
    {


      public  static Func<int, int, double> Fun(this Function function)
        {
            switch (function)
            {
                case Function.Plus:
                    return (x, y) => (x + y);
                case Function.Minus:
                    return (x, y) => x - y;
                case Function.Prod:
                    return (x, y) => 10*(x/100.0)*(y/100.0);
                case Function.SinCos:
                    return (x, y) =>100* Math.Sin(x/100.0)*Math.Cos(y/100.0);
                case Function.Sin:
                    return (x, y) => 100 * Math.Sin(x / 100.0);
                default:
                    throw new ArgumentException("Задана некорректная функция");
            }
        }

     public static Function ParseFun(this string s)
        {
            switch (s)
            {
                case "x + y":
                    return Function.Plus;
                case "x - y":
                    return Function.Minus;
                case "10*(x/100)*(y/100)":
                    return Function.Prod;
                case "100*Sin(x/100)*Cos(y/100)":
                    return Function.SinCos;
                case "100*Sin(x/100)":
                    return Function.Sin;
                default:
                    return Function.Plus;
                    //throw new ArgumentException("Задана некорректная функция");
            }
        }
     }    
}
