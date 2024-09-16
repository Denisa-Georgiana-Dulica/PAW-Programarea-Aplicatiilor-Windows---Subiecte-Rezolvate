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
    public partial class Form2 : Form
    {
        List<Bilet> lista_bilete = new List<Bilet>();
        List<string> distante=new List<string>();
        public Form2(List<Bilet> lista,List<string> dist)
        {
            InitializeComponent();
            lista_bilete = lista;
            distante = dist;

            foreach(string s  in dist)
            {
                string destinatie = s.Split(',')[1];
                cb_destinatie.Items.Add(destinatie);
            }

            tb_statie_plecare.Text = "Bucuresti";
            tb_id.Text = Bilet.NrBilete.ToString();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(tb_pret.Text, out int pret))
                {
                    throw new Exception("Introduceti un pret valid");
                }
                else
                {
                    if(cb_destinatie.SelectedIndex == -1)
                    {
                        throw new Exception("Alege destinatia");
                    }
                    else
                    {
                        string destinatie=cb_destinatie.SelectedItem.ToString();
                        string plecare = tb_statie_plecare.Text;
                        DateTime date = Convert.ToDateTime(dateTimePicker1.Text);
                        int nr_km = 0;
                        foreach(string s in distante)
                        {
                            if (s.Split(',')[1].Equals(destinatie))
                            {
                                nr_km = Convert.ToInt32(s.Split(',')[2]);
                                tb_km.Text=nr_km.ToString();
                            }
                        }
                        Bilet b = new Bilet(tb_id.Text, date, plecare, destinatie, pret, nr_km);
                        lista_bilete.Add(b);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message,"Eroare",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
