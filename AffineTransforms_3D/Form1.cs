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
    public partial class Form1 : Form
    {
        Graphics g;
        List<AffineTransform3D> transforms = new List<AffineTransform3D>();
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

            ReDraw();
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
                AffineTransforms.Transform(currentFigure, i);
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
            currentFigure = new Figure();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var t = AffineTransforms.RotateTransform3D(currentFigure.FigureCenter(), 40, 0,1,0);
            transforms.Add(t);
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
    }


    
}
