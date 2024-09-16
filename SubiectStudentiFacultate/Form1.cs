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

namespace SubiectStudentiFacultate
{
    public partial class Form1 : Form
    {
        List<Student> listStudenti=new List<Student>();
        SqlConnection conexiune = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Studenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_afisare_Click(object sender, EventArgs e)
        {
            conexiune.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter adaptor= new SqlDataAdapter("Select Matricol,Nume,Medie from tblStudenti",conexiune);
            adaptor.Fill(dt);
            dgv_studenti.DataSource = dt;
            conexiune.Close();

            foreach(DataRow r in dt.Rows )
            {
                int matricol =Convert.ToInt32( r["Matricol"].ToString());
                string nume = r["Nume"].ToString();
                float medie = float.Parse(r["Medie"].ToString());
                Student s=new Student(matricol, nume, medie);
                listStudenti.Add(s);
            }
        }

        //data grid view -> row mouse click
        Student stud;
        private void dgv_studenti_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           int matricol = Convert.ToInt32(dgv_studenti.Rows[e.RowIndex].Cells[0].Value.ToString());
            foreach(Student s in listStudenti)
            {
                if(s.Matricol == matricol)
                {
                    stud = s;
                }
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(stud);
            form2.ShowDialog();
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(listStudenti);
            form2.ShowDialog();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            conexiune.Open();
            int matricol=stud.Matricol;
            SqlCommand sqlCommand = new SqlCommand("DELETE FROM tblStudenti WHERE Matricol=@matricol",conexiune);
            sqlCommand.Parameters.AddWithValue("@matricol", matricol);
            sqlCommand.ExecuteNonQuery();
            conexiune.Close();
        }
    }
}
