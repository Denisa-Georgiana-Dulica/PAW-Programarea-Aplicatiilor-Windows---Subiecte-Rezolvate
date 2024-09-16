using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubiectBicicletePublice
{
    public partial class Form2 : Form
    {

        List<Bicicleta> listaBic=new List<Bicicleta>();
        List<Utilizator> listaUt=new List<Utilizator>();
        public Form2(List<Bicicleta> listaB,List<Utilizator> listaU)//nu uita sa faci clasa biblioteca publica
        {
            InitializeComponent();
            listaBic.AddRange(listaB);
            listaUt.AddRange(listaU);

        }

        //desenare grafic (eveniment Paint din componenta panel)
        const int margine = 10;
        Color culoare_bars = Color.Pink;
        Color culoare_text=Color.Red;
        Font font_text=new Font(FontFamily.GenericSerif, 12,FontStyle.Italic);
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            chart1.Visible = false;//optional

            Graphics g = e.Graphics;
            Rectangle dreptunghi = new Rectangle(panel1.ClientRectangle.X + margine,
                                                panel1.ClientRectangle.Y + 4 * margine,
                                                panel1.ClientRectangle.Width - 2 * margine,
                                                panel1.ClientRectangle.Height - 5 * margine);
            Pen creion = new Pen(Color.Red);//deseneaza marginea dreptunghiului
            g.DrawRectangle(creion, dreptunghi);

            Brush bars = new SolidBrush(culoare_bars);
            Brush text = new SolidBrush(culoare_text);

            //pentru bars
            double latime = dreptunghi.Width / listaBic.Count / 3;
            double distanta = (dreptunghi.Width - listaBic.Count * latime) / (listaBic.Count+1);
            double maxim = listaBic.Max(max => max.Km_parcursi);

            Rectangle[] coloane = new Rectangle[listaBic.Count];
            for (int i = 0; i < coloane.Length; i++)
            {
                coloane[i] = new Rectangle((int)(dreptunghi.Location.X + (i + 1) * distanta + i * latime),
                                           (int)(dreptunghi.Location.Y + dreptunghi.Height - (listaBic[i].Km_parcursi / maxim) * dreptunghi.Height),
                                            (int)(latime), (int)((listaBic[i].Km_parcursi / maxim) * dreptunghi.Height));
                g.DrawString(listaBic[i].CodB.ToString(), font_text, text, new Point(coloane[i].Location.X,
                                                                        coloane[i].Location.Y - font_text.Height));


            }
            g.FillRectangles(bars, coloane); //g.FillRectangles cu s

        }

        //BUTON DESENAT (panel1.Invalidate(); ) -> redeseneaza graficul

      private void print(object sender, PrintPageEventArgs e)
        {
            int margine = 10;
            if(listaUt!=null)
            {
                Graphics g = e.Graphics;
                Rectangle dreptunghi = new Rectangle((int)e.PageBounds.X + margine,
                                                    (int)e.PageBounds.Y + 4 * margine,
                                                    (int)e.PageBounds.Width - 2 * margine,
                                                    (int)e.PageBounds.Height - 5 * margine);
                Brush test = new SolidBrush(Color.Black);
                Font font = new Font(FontFamily.GenericSerif, 12, FontStyle.Italic);
                int y = margine;
                for(int i = 0; i < listaUt.Count; i++)
                {
                    g.DrawString(listaUt[i].CodB.ToString() + " - " + listaUt[i].Nume, font, test, new Point(margine, y));
                    y += font.Height + 5;
                }
            }
        }

       
        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(print);
            PrintPreviewDialog pdlg = new PrintPreviewDialog
            {
                Document = pd
            };
            pdlg.ShowDialog();
        }

        private void graficBarsGraphicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series["Numar km"].Points.Clear();   
            chart1.Titles.Clear();
            chart1.Visible = true;
            chart1.Series[0].ChartType=System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            for(int i=0;i<listaBic.Count;i++) 
            {
                chart1.Series["Numar km"].Points.AddXY(listaBic[i].CodB, listaBic[i].Km_parcursi);
            }
            chart1.Titles.Add("Kilometrii parcursi");

        }

        private void graficPieGraphicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Series["Numar km"].Points.Clear();
            chart1.Titles.Clear();
            chart1.Visible = true;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            for(int i=0;i<listaBic.Count;i++)
            {
                chart1.Series["Numar km"].Points.AddXY(listaBic[i].CodB, listaBic[i].Km_parcursi);

            }
            chart1.Titles.Add("Kilometrii parcursi");
        }

        private void barsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd=new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                culoare_bars = cd.Color;
            }
            panel1.Invalidate();
        }

        private void textToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog()== DialogResult.OK)
            {
                culoare_text=cd.Color;
            }
            panel1.Invalidate();
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fd=new FontDialog();
            if(fd.ShowDialog()== DialogResult.OK)
            {
                font_text=fd.Font;

            }
            panel1.Invalidate();
        }
    }
}
