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
    enum Transform {Transposition, Rotate, Scale }
    public partial class Form1 : Form
    {
        Graphics g;
        List<(Transform,List<double>)> transforms = new List<(Transform, List<double>)>();
        Projection selectedProjetion;
        Figure currentFigure;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
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
                currentFigure = new Icosahedron(100);

            if (figure == "Додэкаэдр")
                currentFigure = new Dodecahedron(100);

            ReDraw();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentFigure == null)
                return;
            switch ((string)comboBox1.SelectedItem)
            {
                case "Rotate":
                    {
                        //currentFigure = AffineTransforms.Transform(currentFigure, AffineTransforms.RotateTransform3D(currentFigure.FigureCenter(), 30, 0, 0, 1));
                        transforms.Add(((Transform)Enum.Parse(typeof(Transform), comboBox1.SelectedItem.ToString()),new List<double> {int.Parse(textBox1.Text)}));
                        break;
                    }
                default:
                    {
                        transforms.Add(((Transform)Enum.Parse(typeof(Transform), comboBox1.SelectedItem.ToString()), new List<double> { double.Parse(textBox2.Text), double.Parse(textBox3.Text), double.Parse(textBox4.Text) }));
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
            var centerX = Size.Width / 2;
            var centerY = Size.Height / 2 - 150;
            foreach (var i in transforms)
            {
                switch (i.Item1.ToString())
                {
                    case "Rotate":
                        {
                            currentFigure = Transformator.Transform(currentFigure, AffineTransforms.RotateTransform3D(currentFigure.FigureCenter(), (int)i.Item2[0], 0, 0, 1));
                            //transforms.Add(AffineTransforms.RotateTransform3D(currentFigure.FigureCenter(), 30, 0, 0, 1));
                            break;
                        }
                    case "Transposition":
                        {
                            currentFigure= Transformator.Transform(currentFigure, AffineTransforms.TranslateTransform3D(i.Item2[0], i.Item2[1], i.Item2[2]));
                            //transforms.Add(AffineTransforms.TranslateTransform3D(10, 10, 10));
                            break;
                        }
                    case "Scale":
                        {
                            currentFigure= Transformator.Transform(currentFigure, AffineTransforms.ScaleTransform3D(currentFigure.FigureCenter(), i.Item2[0], i.Item2[1], i.Item2[2]));
                            //transforms.Add(AffineTransforms.ScaleTransform3D(currentFigure.FigureCenter(), 2));
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
            if (currentFigure == null)
                return;
            g.Clear(BackColor);
            var centerX = Size.Width / 2;
            var centerY = Size.Height / 2 - 150;
            foreach (var r in currentFigure.edges)
            {
                g.DrawLine(Pens.Black, (int)(r.begin.X + centerX), (int)(r.begin.Y + centerY),
                   (int)(r.end.X + centerX), (int)(r.end.Y + centerY));
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((string)comboBox1.SelectedItem)
            {
                case "Rotate":
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
    }


    
}
