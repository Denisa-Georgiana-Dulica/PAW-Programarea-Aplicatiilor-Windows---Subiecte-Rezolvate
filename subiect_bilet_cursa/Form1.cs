using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Configuration;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
/*Sa se realizeze o aplicatie Windows C# NET pentru a gestiona vanzarile de bilete dintr-o autogara.

 (2p) Se defineste clasa Bilet cu atributele: id (string), dataCursei (DateTime), statiePlecare  (string), destinatie (string), pret (int). Pentru aceasta clasa se defineste un constructor cu parametri cu valori implicite si proprietati pentru atributele private (destinatie si pret).

 (1p) Se defineste interfata ICalculEficienta ce defineste metoda (abstracta) float pretPerKm() ce returneaza pretul ce revine in medie pe un km.

 (1p) Clasa Bilet mosteneste interfata ICalculEficienta, implementand metoda pretPerKm() prin impartirea pretului la numarul de km, preluat din fisierul distante.dat, creat cu un editor de text si continand inregistrari de forma Origine Destinatie Km (ex. Bucuresti Ploiesti 60 ).

 (1p) Se construieste un formular (altul decat cel principal) ce permite inserarea unui Bilet folosind controale:

·         TextBox precompletate: pentru id (prin autoincrementare) si pentru statiePlecare (Bucuresti),

·         DateTimePicker (sau alt control de tip calendar) pentru dataCursei,

·         ComboBox pentru destinatie,

·         TextBox cu validare de numeric, pentru pret.

La nivelul aplicatiei, formularul se activeaza din meniul principal si se inchide prin intermediul a doua butoane de tipul Save si Cancel (retine sau nu obiectul de tip Bilet).                                    

 (2p)     Obiectele create prin intermediul formularului secundar se salveaza in aplicatie intr-o colectie standard (List<>, ArrayList, Stack,Queue, etc.) numita lstBilete.

            La nivelul formularului principal, elementele colectiei Bilete) sunt afisate prin intermediul unui control de tip ListView (ce afiseaza toate campurile). De asemenea, din ora in ora (eveniment de ceas), biletele utilizate sau expirate sunt colorate in rosu.                                                                          

(1p) Aplicatia permite prin intermediul meniului principal, activarea optiunii de serializare a datelor (lista de bilete emise) intr-un fisier binar. Numele fisierului se cere utilizatorului (SaveFileDialog). O alta optiune a meniului principal permite restaurarea datelor, prin deserializare.                                                

(1p) Aplicatia permite vizualizarea grafica prin bare a pretului pe km, pentru fiecare dintre biletele emise. Desenul are persistenta pe refresh (redimensionare, redesenare la Minimize/Maximize).     

(1p) Pe un meniu contextual asociat ListView-ului, se implementeaza preluarea datelor din Clipboard pentru a permite inserarea automata a unui  bilet (cand nu exista selectie in ListView) sau pentru a modifica un bilet selectat in ListView. Continutul din Clipboard trebuie sa fie de tip text (ex: 123 ;15.06.2013;Bucuresti;Ploiesti;110) si se preia dintr-un editor de text (ex. Notepad) prin Copy.    

*/
namespace subiect_bilet_cursa
{
    public partial class Form1 : Form
    {
        List<string> distante=new List<string>();
        List<Bilet> lista_bilete=new List<Bilet>();
        
        public Form1()
        {
            InitializeComponent();
            citeste_din_binar();
            listView_bilete.ContextMenuStrip = contextMenuStrip1;
            ToolStripMenuItem clipboard = new ToolStripMenuItem("Modificare Bilet selectat din Clipboard", null, clipboardToolStripMenuItem_Click);
            //creez fisierul binar
            // string dist1 = "Bucuresti,Ploiesti,60";
            // string dist2 = "Bucuresti,Pitesti,100";
            // distante.Add(dist1);
            // distante.Add(dist2);
            // scrie_in_binar();
        }

        /*private void scrie_in_binar()
        {
            FileStream fs = new FileStream("distanta.dat", FileMode.Create, FileAccess.Write);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, distante);
        }*/
        
        private void citeste_din_binar()
        {
            FileStream fs = new FileStream("distanta.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            distante=(List<string>)bf.Deserialize(fs);
            fs.Close();
        }

        private void initializareBiletToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(lista_bilete,distante);
            form2.ShowDialog();
        }

        private void btn_lv_Click(object sender, EventArgs e)
        {
            listView_bilete.Items.Clear();
            foreach(Bilet bilet in lista_bilete)
            {
                string[] date=bilet.ToString().Split(',');
                ListViewItem lv = new ListViewItem(date[0]);
                lv.SubItems.Add(date[1]);
                lv.SubItems.Add(date[2]);
                lv.SubItems.Add(date[3]);
                lv.SubItems.Add(date[4]);
                listView_bilete.Items.Add(lv);
            }
           
        }

        private void salvareBinarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "(*.dat)|*.dat";
            if(saveFileDialog1.ShowDialog() == DialogResult.OK) {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Create, FileAccess.Write);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, lista_bilete);
                fs.Close();
            }
            
        }

        private void citireBinarToolStripMenuItem_Click(object sender, EventArgs e)
        {
          openFileDialog1.Filter = "(*.dat)|*.dat";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog1.FileName, FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                List<Bilet> lista= (List<Bilet>)bf.Deserialize(fs);
                fs.Close();
            }
        }

        private void graficToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(lista_bilete);
            form3.ShowDialog();
        }

        private void clipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(listView_bilete.SelectedItems == null)
            {
                MessageBox.Show("Alege un element din list view");
                return;
            }
            string clipboard = Clipboard.GetText();
            if (string.IsNullOrEmpty(clipboard))
            {
                return;
            }
            string[] date = clipboard.Split(';');
            string id = date[0];
            string plecare = date[1];
            DateTime data = Convert.ToDateTime(date[2]);
            string destinatie = date[3];
            int pret = int.Parse(date[4]);
            string id_lv = listView_bilete.SelectedItems[0].Text;
            int nr_km = 0;
            Bilet bilet = lista_bilete.FirstOrDefault(b => b.ToString().Split(',')[0] == id_lv);
            if (bilet != null)
            {

              bilet = new Bilet(id, data, plecare, destinatie, pret, nr_km);
                
            }
            
        }
    }
}
