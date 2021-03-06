using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AffineTransforms_3D
{
    enum Projection { Perspective, Isometric, Trimetric, Dimetric };
    public partial class Form1 : Form
    {
        Graphics g;
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

        void ReDraw()
        {
            if (currentFigure == null)
                return;
            g.Clear(BackColor); 
            var centerX = Size.Width / 2;
            var centerY = Size.Height / 2 - 150;
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
    }


    
}
