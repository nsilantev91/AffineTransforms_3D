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

namespace AffineTransforms_3D
{
    enum Projection { Perspective, Isometric, Trimetric, Dimetric };
    enum Transform {Transposition, Rotate, Scale, Reflect }
    public partial class Form1 : Form
    {
        Graphics g;
        List<(Transform,List<double>)> transforms = new List<(Transform, List<double>)>();
        Projection selectedProjetion;
        Figure currentFigure;
        bool figureCenter;
        bool usingLine = false;
        CoordinatePlane plane;
        Point3D point1 = new Point3D(0,0,0);
        Point3D point2 = new Point3D(1,1,1);
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
            selectedProjetion = Projection.Perspective;
            currentFigure = new Figure();
        }

        private void showFigure_btn_Click(object sender, EventArgs e)
        {
            string figure = (string)figures_box.SelectedItem;
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
                
            this.showFigure_btn_Click(sender, e);

        }

        void ReDraw()
        {
            if (currentFigure == null)
                return;
            g.Clear(BackColor); 
            var centerX = Size.Width / 2 - 400;
            var centerY = Size.Height / 2 - 150;
            foreach (var i in transforms)
            {
                switch (i.Item1)
                {
                    case Transform.Rotate:
                        {
                            (double, double, double) axis = (0, 0, 0);
                            var plane =(CoordinatePlane)i.Item2[1];
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
                                currentFigure = Transformator.Transform(currentFigure,
                                  AffineTransforms.RotateTransform3D(point1,
                                  (int)i.Item2[0], v.X, v.Y, v.Z));
                            }
                            else
                            {
                                var figureCenter = ((int)i.Item2[2]) == 1;
                                var point = figureCenter ? currentFigure.FigureCenter() : new Point3D(0, 0, 0);
                                currentFigure = Transformator.Transform(currentFigure,
                                    AffineTransforms.RotateTransform3D(point,
                                    (int)i.Item2[0], axis.Item1, axis.Item2, axis.Item3));
                            }
                          
                            //transforms.Add(AffineTransforms.RotateTransform3D(currentFigure.FigureCenter(), 30, 0, 0, 1));
                            break;
                        }
                    case Transform.Transposition:
                        {
                            currentFigure= Transformator.Transform(currentFigure, 
                                AffineTransforms.TranslateTransform3D(i.Item2[0], i.Item2[1], i.Item2[2]));
                            //transforms.Add(AffineTransforms.TranslateTransform3D(10, 10, 10));
                            break;
                        }
                    case Transform.Scale:
                        {
                            var figureCenter = (int)i.Item2[3] == 1;
                            var point = figureCenter ? currentFigure.FigureCenter() :new Point3D(0, 0, 0);
                            currentFigure = Transformator.Transform(currentFigure,
                                AffineTransforms.ScaleTransform3D(point,
                                i.Item2[0], i.Item2[1], i.Item2[2]));
                            //transforms.Add(AffineTransforms.ScaleTransform3D(currentFigure.FigureCenter(), 2));
                            break;
                        }
                    case Transform.Reflect:
                        {
                            currentFigure = Transformator.Transform(currentFigure, 
                                AffineTransforms.ReflectionTransform((CoordinatePlane)(int)(i.Item2[0])));
                            break;
                        }
                }
            }
            currentFigure = Projections.Apply(currentFigure, selectedProjetion);
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
            transforms.Clear();
            currentFigure = new Figure();
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

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
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

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
    }


    
}
