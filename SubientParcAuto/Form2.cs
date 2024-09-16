using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubientParcAuto
{
    public partial class Form2 : Form
    {
        List<Autoturism> lista=new List<Autoturism>();  
        public Form2(List<Autoturism> lista1)
        {
            InitializeComponent();
            lista.AddRange(lista1);
           
        }

        int margine = 10;
        Color culoare_bars = Color.Pink;
        Color culoare_text = Color.Red;
        Font font_text=new Font(FontFamily.GenericSerif, 12,FontStyle.Italic);
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            chart1.Visible = false;
            if (lista != null)
            {
                Graphics g = e.Graphics;
                Rectangle dreptunghi=new Rectangle(panel1.ClientRectangle.X+margine,
                                                    panel1.ClientRectangle.Y+4*margine,
                                                    panel1.ClientRectangle.Width-2*margine,
                                                    panel1.ClientRectangle.Height-5*margine);
                Pen p = new Pen(Color.Red);
                g.DrawRectangle(p, dreptunghi );

                Rectangle[] coloane=new Rectangle[lista.Count];
                double maxim = lista.Max(max => max.Pret);
                double latime=dreptunghi.Width/lista.Count/3;
                double distanta = (dreptunghi.Width-lista.Count*latime)/(lista.Count+1);

                Brush b_bars=new SolidBrush(culoare_bars);
                Brush text=new SolidBrush(culoare_text);
                for(int i=0;i<coloane.Length;i++)
                {
                    coloane[i] = new Rectangle( (int) (dreptunghi.Location.X + (i+1)*distanta+ i*latime ),
                                                (int)(dreptunghi.Location.Y + dreptunghi.Height - (lista[i].Pret/maxim)*dreptunghi.Height),
                                                (int)latime, 
                                                (int) ( (lista[i].Pret / maxim) * dreptunghi.Height )   );

                    g.DrawString(lista[i].Id.ToString(), font_text, text, new Point(coloane[i].Location.X, coloane[i].Location.Y - font_text.Height));
                }
                g.FillRectangles(b_bars, coloane);
            }
        }

        private void graficBarsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series["Pret"].Points.Clear();
            chart1.Titles.Clear();
            chart1.Visible = true;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bar;
            foreach(Autoturism a in lista)
            {
                chart1.Series["Pret"].Points.AddXY(a.Id, a.Pret);

            }
            chart1.Titles.Add("Pret");
        }

        private void barsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            ColorDialog cd= new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK )
            {
                culoare_bars = cd.Color;
            }
            panel1.Invalidate();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                culoare_text = cd.Color;
            }
            panel1.Invalidate();
        }

        private void pp(object sender, PrintPageEventArgs e)
        {
            if(lista!=null)
            {
                int margine = 10;
                int y = margine;
                Graphics g = e.Graphics;
                Brush b_text=new SolidBrush(Color.BlueViolet);
                Font font=new Font(FontFamily.GenericSerif, 12,FontStyle.Italic);
                Rectangle dreptunghi=new Rectangle(e.PageBounds.X+margine,
                                                    e.PageBounds.Y+4*margine,
                                                    e.PageBounds.Width-2*margine,
                                                    e.PageBounds.Height-5*margine);
                foreach(Autoturism a in  lista)
                {
                    g.DrawString(a.Denumire + " " + a.Pret, font, b_text, new Point(margine, y));
                    y += font.Height + 5;
                }
               
            }
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd=new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pp);
            PrintPreviewDialog pdlg=new PrintPreviewDialog()
            {
                Document = pd
            };
            pdlg.ShowDialog();
        }
    }
}
