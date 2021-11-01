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
    public partial class Form1 : Form
    {
        Graphics g;
        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
        }

        private void showFigure_btn_Click(object sender, EventArgs e)
        {
            string figure = (string)figures_box.SelectedItem;
            var selectedFigure = new Figure();
            if (figure == "Тетраэдр")
            {
                PointF3D a = new PointF3D(0, 0, 0);
                PointF3D b = new PointF3D(200, 0, 200);
                PointF3D c = new PointF3D(200, 200, 0);
                PointF3D d = new PointF3D(0, 200, 200);
                Figure tetrahedron = new Figure();
                tetrahedron.AddEdges(a, new List<PointF3D> { b, d, c });
                tetrahedron.AddEdges(b, new List<PointF3D> { d });
                tetrahedron.AddEdges(c, new List<PointF3D> { b, d });
                selectedFigure = tetrahedron;
                
            }
            if (figure == "Гексаэдр")
            {

            }
            if (figure == "Октаэдр")
            {

            }
            var res = Projections.Apply(selectedFigure, true);
            var centerX = Size.Width / 2;
            var centerY = Size.Height / 2;
         
            foreach (var r in res.edges)
            {
                g.DrawLine(Pens.Black, (int)(r.begin.GetPoint().X + centerX), (int)(r.begin.GetPoint().Y + centerY),
                   (int)(r.end.GetPoint().X + centerX), (int)(r.end.GetPoint().Y + centerY));
            }

        }
    }
}
