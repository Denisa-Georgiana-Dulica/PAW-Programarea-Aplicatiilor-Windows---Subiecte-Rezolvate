using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace subiect_bilet_cursa
{
    public partial class Form3 : Form
    {
        List<Bilet> lista_bilete=new List<Bilet>();
        public Form3(List<Bilet> lista)
        {
            InitializeComponent();
            lista_bilete = lista;
        }

        int margine = 10;
        Color culoare_bars= Color.Pink;
        Color culoare_text= Color.Magenta;
        Font font=new Font(FontFamily.GenericSerif, 12,FontStyle.Italic);
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (lista_bilete != null)
            {
                Graphics g = e.Graphics;
                Rectangle dreptunghi = new Rectangle(panel1.ClientRectangle.X + margine,
                                                    panel1.ClientRectangle.Y + 4 * margine,
                                                    panel1.ClientRectangle.Width - 2 * margine,
                                                    panel1.ClientRectangle.Height - 5 * margine);
                Pen pen = new Pen(Color.Red);
                g.DrawRectangle(pen, dreptunghi);


                float[] pret = new float[lista_bilete.Count];
                int nr = 0;
                foreach (Bilet bilet in lista_bilete)
                {
                    pret[nr] = bilet.pretPerkm();
                    nr++;
                }
                double maxim = pret[0];
                for(int i=0;i<pret.Length;i++)
                {
                    if (maxim < pret[i])
                    {
                        maxim = pret[i];
                    }
                }
                double latime = dreptunghi.Width / pret.Length/3;
                double distanta = (dreptunghi.Width - latime * pret.LongLength) / (pret.Length + 1);
                Brush b_bars = new SolidBrush(culoare_bars);
                Brush b_text = new SolidBrush(culoare_text);
                Rectangle[] coloane=new Rectangle[lista_bilete.Count];
                for(int i = 0;i<lista_bilete.Count;i++)
                {
                    coloane[i]=new Rectangle( (int) (dreptunghi.Location.X+(i+1)*distanta+i*latime),
                                                (int)(dreptunghi.Location.Y + dreptunghi.Height - (pret[i]/maxim)*dreptunghi.Height),
                                                (int)latime,
                                                (int)((pret[i] / maxim) * dreptunghi.Height));
                    g.DrawString(lista_bilete[i].ToString().Split(',')[0], font, b_text, new Point(coloane[i].Location.X, coloane[i].Location.Y - font.Height));
                }
                g.FillRectangles(b_bars, coloane);
            }
        }

    }
}
