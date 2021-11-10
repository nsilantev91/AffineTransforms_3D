using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Media3D;
using System.IO;


namespace AffineTransforms_3D
{
    enum Projection { Perspective, Isometric, Trimetric, Dimetric };
    enum Transform {Transposition, Rotate, Scale, Reflect }

    public  enum Function { Plus, Minus, Prod, SinCos, Sin }

    public struct GraphData
    {
        public int X0;
        public int X1;
        public int Y0;
        public int Y1;
        public int StepCount;
        public Function Fun;
    }

   
    public partial class Form1 : Form
    {
        String lastfig = "";
        Graphics g;
        List<(Transform,List<double>)> transforms = new List<(Transform, List<double>)>();
        Projection selectedProjetion;
        Figure currentFigure;
        bool figureCenter;
        bool usingLine = false;
        CoordinatePlane plane;
        Point3D point1 = new Point3D(0,0,0);
        Point3D point2 = new Point3D(1,1,1);
        List<Point3D> forming;
        List<Point3D> showForming;
        bool openedFigure = false;
    
       
        GraphData graphData = new GraphData();
        public Form1()
        {
            InitializeComponent();
            planeComboBox.SelectedIndex = 0;
            transformComboBox.SelectedIndex = 0;
            AutoSize = false;
            AutoScaleMode = AutoScaleMode.Font;
            Font = new Font("Trebuchet MS",
                12.0f,
                FontStyle.Regular,
                GraphicsUnit.Point,
                ((byte)(204))
            );
            g = pictureBox1.CreateGraphics();
            proj_box.SelectedIndex = 0;
            figures_box.SelectedIndex = 0;
            funComboBox.SelectedIndex = 0;
            selectedProjetion = Projection.Perspective;
            currentFigure = new Figure();
            forming = new List<Point3D>();
            axis_box.SelectedIndex = 0;
            showForming = new List<Point3D>();
            graphData.X0 = int.Parse(x0FunTextBox.Text);
            graphData.Y0 = int.Parse(y0FunTextBox.Text);
            graphData.X1 = int.Parse(x1FunTextBox.Text);
            graphData.Y1 = int.Parse(y1FunTextBox.Text);
            graphData.StepCount= int.Parse(stepCountTextBox.Text);

        }

        private void showFigure_btn_Click(object sender, EventArgs e)
        {
            string figure = (string)figures_box.SelectedItem;
            if (lastfig != figure)
            {
                if (figure == "Тетраэдр")
                    currentFigure = Figures.Tetrahedron;

                if (figure == "Гексаэдр")

                    currentFigure = Figures.Hexahedron;

                if (figure == "Октаэдр")
                    currentFigure = Figures.Octahedron;

                if (figure == "Икосаэдр")
                    currentFigure = new Icosahedron(150);

                if (figure == "Додэкаэдр")
                    currentFigure = new Dodecahedron(150);
                if (figure == "График")
                    currentFigure = new Graph(graphData);
                lastfig = figure;
                if (figure == "Пользовательская")
                    lastfig = "Сustom figure";
            }
            ReDraw();
        }

       

        Transform parseTransform()
        {
           return (Transform)Enum.Parse(typeof(Transform), transformComboBox.SelectedItem.ToString());
        } 

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentFigure == null)
                return;
            var transform = parseTransform();
            switch (transform)
            {
                case Transform.Rotate:
                    {
                        //currentFigure = AffineTransforms.Transform(currentFigure, AffineTransforms.RotateTransform3D(currentFigure.FigureCenter(), 30, 0, 0, 1));
                        transforms.Add((transform, new List<double> {int.Parse(textBox1.Text), (int) plane, figureCenter?1:0}));
                        break;
                    }
                case Transform.Reflect:
                    {
                        transforms.Add((transform, new List<double> {(int)plane}));
                        break;
                    }
                default:
                    {
                        transforms.Add((transform, new List<double> 
                            { double.Parse(textBox2.Text), 
                              double.Parse(textBox3.Text),
                              double.Parse(textBox4.Text),
                              figureCenter?1:0}));
                        break;
                    }
            }
            var centerX = Size.Width / 2 - 200;
            var centerY = Size.Height / 2 - 150;
            //foreach (var i in transforms)
            //{
            if (transforms.Count != 0)
            {
                var i = transforms.Last();
                switch (i.Item1)
                {
                    case Transform.Rotate:
                        {
                            (double, double, double) axis = (0, 0, 0);
                            var plane = (CoordinatePlane)i.Item2[1];
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
                                var v1 = new Vector3D(point1.X, point1.Y, point1.Z);
                                var v2 = new Vector3D(point2.X, point2.Y, point2.Z);
                                var v = v2 - v1;
                                currentFigure.Transform(
                                  AffineTransforms.RotateTransform3D(point1,
                                  (int)i.Item2[0], v.X, v.Y, v.Z));
                            }
                            else
                            {
                                var figureCenter = ((int)i.Item2[2]) == 1;
                                var point = figureCenter ? currentFigure.FigureCenter() : new Point3D(0, 0, 0);
                                currentFigure.Transform(
                                    AffineTransforms.RotateTransform3D(point,
                                    (int)i.Item2[0], axis.Item1, axis.Item2, axis.Item3));
                            }

                            //transforms.Add(AffineTransforms.RotateTransform3D(currentFigure.FigureCenter(), 30, 0, 0, 1));
                            break;
                        }
                    case Transform.Transposition:
                        {
                            currentFigure.Transform(
                                AffineTransforms.TranslateTransform3D(i.Item2[0], i.Item2[1], i.Item2[2]));
                            //transforms.Add(AffineTransforms.TranslateTransform3D(10, 10, 10));
                            break;
                        }
                    case Transform.Scale:
                        {
                            var figureCenter = (int)i.Item2[3] == 1;
                            var point = figureCenter ? currentFigure.FigureCenter() : new Point3D(0, 0, 0);
                            currentFigure.Transform(
                                AffineTransforms.ScaleTransform3D(point,
                                i.Item2[0], i.Item2[1], i.Item2[2]));
                            //transforms.Add(AffineTransforms.ScaleTransform3D(currentFigure.FigureCenter(), 2));
                            break;
                        }
                    case Transform.Reflect:
                        {
                            currentFigure.Transform(
                                AffineTransforms.ReflectionTransform((CoordinatePlane)(int)(i.Item2[0])));
                            break;
                        }
                        // }
                }
            }
            ReDraw();
        }

        void ReDraw()
        {
            if (currentFigure == null)
                return;
            g.Clear(BackColor);
            var centerX = Size.Width / 2 - 200;
            var centerY = Size.Height / 2 - 150;
           
            if (!openedFigure)
            {
                currentFigure = Projections.Apply(currentFigure, selectedProjetion);
            }
            else
            {
                openedFigure = false;
            }
            
            foreach (var r in currentFigure.edges)
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
            currentFigure = new Figure();
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
            
            if (currentFigure == null)
                return;
            g.Clear(BackColor);
            var centerX = Size.Width / 2 - 200;
            var centerY = Size.Height / 2 - 150;
            foreach (var r in currentFigure.edges)
            {
                g.DrawLine(Pens.Black, (int)(r.begin.X + centerX), (int)(r.begin.Y + centerY),
                   (int)(r.end.X + centerX), (int)(r.end.Y + centerY));
            }
            
            //ReDraw();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            point1.X=double.Parse(((TextBox)sender).Text);
        }

        private void textBoxY1_TextChanged(object sender, EventArgs e)
        {
            point1.Y = double.Parse(((TextBox)sender).Text);
        }

        private void textBoxZ1_TextChanged(object sender, EventArgs e)
        {
            point1.Z = double.Parse(((TextBox)sender).Text);
        }

        private void textBoxX2_TextChanged(object sender, EventArgs e)
        {
            point2.X = double.Parse(((TextBox)sender).Text);
        }

        private void textBoxY2_TextChanged(object sender, EventArgs e)
        {
            point2.Y = double.Parse(((TextBox)sender).Text);
        }

        private void textBoxZ2_TextChanged(object sender, EventArgs e)
        {
            point2.Z = double.Parse(((TextBox)sender).Text);
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
            currentFigure = res;
            ReDraw();
        }

        

        private void add_point_btn_Click(object sender, EventArgs e)
        {
            var x = int.Parse(forming_x_box.Text);
            var y = int.Parse(forming_y_box.Text);
            var z = int.Parse(forming_z_box.Text);
            showForming.Add(new Point3D(x, y, z));
            forming.Add(new Point3D(x - 200, y - 200, z));
            if(forming.Count >=2)
            {
                num_parts_box.Enabled = true;
                Point[] points = new Point[forming.Count];
                for(int i = 0; i< showForming.Count; i++)
                {
                    points[i] = Projections.ApplyForPoint3D(showForming[i], selectedProjetion);
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
            if (currentFigure!=null)
            { 
                SaveFileDialog saveFile = saveFileDialog1;
                saveFile.InitialDirectory = "c:\\";
                saveFile.Filter = "Figure (*.fig)|*.fig|All files (*.*)|*.*";
            
                if (saveFile.ShowDialog()==DialogResult.OK)
                {
                    var path = Path.GetFullPath(saveFile.FileName);
                    var t = new FileWorker(currentFigure, selectedProjetion,(string)figures_box.SelectedItem);
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
                currentFigure = t.fig;
                selectedProjetion = t.proj;
                lastfig = t.fname;
                proj_box.SelectedIndex = (int)t.proj;
                figures_box.SelectedIndex = figures_box.Items.IndexOf(t.fname);
                openedFigure = true;
                ReDraw();
                //showFigure_btn_Click(sender, e);
            }

        }

        private void funComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            graphData.Fun = (sender as ComboBox).SelectedItem.ToString().ParseFun();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            graphData.Y1 = int.Parse(y1FunTextBox.Text);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            graphData.X1 = int.Parse(x1FunTextBox.Text);
        }

        private void textBox9_TextChanged_1(object sender, EventArgs e)
        {
            graphData.X0 = int.Parse(x0FunTextBox.Text);
        }

        private void textBox8_TextChanged_1(object sender, EventArgs e)
        {
            graphData.Y0 = int.Parse(y0FunTextBox.Text);
        }

        private void stepCountTextBox_TextChanged(object sender, EventArgs e)
        {
            graphData.StepCount = int.Parse(stepCountTextBox.Text);
        }
    }


    public static class EnumExtension
    {
      public  static Func<int, int, double> Fun(this Function function)
        {
            switch (function)
            {
                case Function.Plus:
                    return (x, y) => x + y;
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
                    throw new ArgumentException("Задана некорректная функция");
            }
        }
     }    
}
