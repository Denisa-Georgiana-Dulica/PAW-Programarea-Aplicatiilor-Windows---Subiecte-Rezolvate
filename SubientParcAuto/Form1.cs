using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SubientParcAuto
{
    public partial class Form1 : Form
    {

        List<Autoturism> autoturismList=new List<Autoturism>();
        SqlConnection conexiune = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ParcAuto;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form1()
        {
            InitializeComponent();
            this.ContextMenuStrip = contextMenuStrip1;
        }

       

        private void preluareDateToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            conexiune.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT Id,Pret,Denumire,Km1,Km2,NumarLocuri FROM Auto", conexiune);
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    int id = Convert.ToInt32(dr["Id"].ToString());
                    float pret = float.Parse(dr["Pret"].ToString());
                    string denumire = dr["Denumire"].ToString();
                    float[] vector = new float[2];
                    vector[0] = float.Parse(dr["Km1"].ToString());
                    vector[1] = float.Parse(dr["Km2"].ToString());
                    int nrLocuri = Convert.ToInt32(dr["NumarLocuri"].ToString());
                    Autoturism a = new Autoturism(id, pret, denumire, vector, nrLocuri);
                    
                    autoturismList.Add(a);
                }

                conexiune.Close();
                listView_parc_auto.Items.Clear();
                foreach (Autoturism a in autoturismList)
                {
                    ListViewItem list = new ListViewItem(a.Id.ToString());
                    list.SubItems.Add(a.Pret.ToString());
                    list.SubItems.Add(a.Denumire);
                    string v = null;
                    for (int i = 0; i < a.Km_parcursi.Count(); i++)
                    {
                        v += a.Km_parcursi[i].ToString() + ",";

                    }
                    list.SubItems.Add(v);
                    list.SubItems.Add(a.Numar_locuri.ToString());
                    double medie = (double)a;
                    list.SubItems.Add(a.Km_medie.ToString());
                    listView_parc_auto.Items.Add(list);
                }


            }
            else
            {
                MessageBox.Show("nuu");
            }
        }

        private void btn_stergere_Click(object sender, EventArgs e)
        {
            foreach(ListViewItem lv in listView_parc_auto.Items)
            {
                if(lv.Checked)
                {
                    int index=lv.Index; 
                    int id = autoturismList[index].Id;
                    conexiune.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Auto where Id=@id",conexiune);
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    conexiune.Close();
                }
                listView_parc_auto.Items.Clear();
                autoturismList.Clear();
            }
        }

        private void graficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(autoturismList);
            form2.ShowDialog();
        }
    }
}
