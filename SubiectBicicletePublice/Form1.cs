using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubiectBicicletePublice
{
    public partial class Form1 : Form
    {
        List<Bicicleta> IstBiciclete=new List<Bicicleta>();
        List<Utilizator> IstUtilizatori=new List<Utilizator>();

        public Form1()
        {
            InitializeComponent();
            IstBiciclete.Add(new Bicicleta("Parcare 1", 20, 1));
            IstBiciclete.Add(new Bicicleta("Parcare 2", 30, 2));
            IstBiciclete.Add(new Bicicleta("Parcare 3", 40, 3));
            IstBiciclete.Add(new Bicicleta("Parcare 4", 50, 4));

            IstUtilizatori.Add(new Utilizator("Utilizator1", 1, 30));
            IstUtilizatori.Add(new Utilizator("Utilizator2", 1, 100));
            IstUtilizatori.Add(new Utilizator("Utilizator3", 2, 120));
            IstUtilizatori.Add(new Utilizator("Utilizator4", 3, 60));
            IstUtilizatori.Add(new Utilizator("Utilizator5", 2, 100));
            this.ContextMenuStrip = contextMenuStrip1; //this este form1

            foreach(Bicicleta b in IstBiciclete)
            {
                ListViewItem it = new ListViewItem(b.CodB.ToString());
                it.SubItems.Add(b.Denumire_parcare);
                it.SubItems.Add(b.Km_parcursi.ToString());
                listView_biciclete.Items.Add(it);
            }

           
        }

        //list view - checked boxes- true + item checked
        private void listView_biciclete_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.Checked)
            {
                float suma = 0;
                listView_utilizatori.Items.Clear();
                int index = e.Item.Index;
                int cod = IstBiciclete[index].CodB;
                foreach (Utilizator u in IstUtilizatori)
                {
                    if (u.CodB == cod)
                    {
                        ListViewItem lv = new ListViewItem(u.Nume);
                        lv.SubItems.Add(u.CodB.ToString());
                        lv.SubItems.Add(u.Durata_utilizare.ToString());
                        listView_utilizatori.Items.Add(lv);

                        if(u.Durata_utilizare>30)
                        {
                            suma += ((u.Durata_utilizare - 30) / 10)*2;
                        }
                    }
                }
                tb_valoare_totala.Text = suma.ToString();
            }

        }

        private void graficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(IstBiciclete,IstUtilizatori);
            form2.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileStream fs=new FileStream("biciclete.dat",FileMode.Create,FileAccess.Write);
            BinaryFormatter bf=new BinaryFormatter();
            bf.Serialize(fs, IstBiciclete);
            fs.Close();
            MessageBox.Show("Fisier biciclete.dat salvat");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("utilizatori.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, IstUtilizatori);
            fs.Close();
            MessageBox.Show("Fisier utilzatori.dat salvat");
        }
    }
}
