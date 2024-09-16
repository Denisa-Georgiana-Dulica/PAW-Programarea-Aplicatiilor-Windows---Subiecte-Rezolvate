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
    public partial class Form2 : Form
    {
        Student student;
        List<Student> student_lista;
        SqlConnection conexiune = new SqlConnection("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Studenti;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public Form2(Student s)
        {
            InitializeComponent();
            student = s;
            tb_matricol.Text=s.Matricol.ToString();
            tb_nume.Text=s.Nume.ToString();
            tb_matricol.ReadOnly=true;
            tb_nume.ReadOnly=true;
            tb_medie.Text = s.Medie.ToString();
            btn_inserare.Hide();
        }
        public Form2(List<Student> s)
        {
            InitializeComponent();
            student_lista = s;
            button1.Hide();

        }

            private void button1_Click(object sender, EventArgs e)
        {
            conexiune.Open();
            SqlCommand cmd = new SqlCommand("UPDATE tblStudenti SET Medie=@medie where Matricol=@matricol",conexiune);//nu uita de conexiune
            cmd.Parameters.AddWithValue("@medie", float.Parse(tb_medie.Text));//trebuie sa fie de aceleasi tipuri ca in tabela
            cmd.Parameters.AddWithValue("@matricol", tb_matricol.Text);
            cmd.ExecuteNonQuery();//nu uita
            conexiune.Close();
            this.Close();
        }

        private void btn_inserare_Click(object sender, EventArgs e)
        {
           
            try
            {
                foreach (Student student in student_lista)
                {
                    if (Convert.ToInt32(tb_matricol.Text) == student.Matricol)
                    {
                        throw new Exception("matriol existent");
                    }
                }
                    
                    
                        conexiune.Open();
                        SqlCommand comm = new SqlCommand("INSERT INTO tblStudenti (Matricol,Nume,Medie) Values (@matricol,@nume,@medie)", conexiune);
                        comm.Parameters.AddWithValue("@matricol", Convert.ToInt32(tb_matricol.Text));
                        comm.Parameters.AddWithValue("@nume", tb_nume.Text);
                        comm.Parameters.AddWithValue("@medie", float.Parse(tb_medie.Text));
                        comm.ExecuteNonQuery();
                        conexiune.Close();
                        this.Close();
                       
                    
                
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message,"Eroare",MessageBoxButtons.OK,MessageBoxIcon.Error);
                tb_matricol.Clear();
            }

        }
    }
}
