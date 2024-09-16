using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subiect_bilet_cursa
{
    [Serializable]
    public class Bilet:ICalculEficienta
    {
        private static int nrBilete = 0;
        private string id;
        private DateTime dataCursa;
        private string statie_plecare;
        private string destinatie;
        private int pret;

        private int nr_km;
        //CONSTRUCTOR CU VALORI IMPLICITE
        public Bilet(string id="0", DateTime dataCursa=new DateTime(), string statie_plecare="Bucuresti", string destinatie="Ploiesti", int pret=0, int nr_km=0)
        {
            this.id = id;
            this.dataCursa = dataCursa;
            this.statie_plecare = statie_plecare;
            this.destinatie = destinatie;
            this.pret = pret;
            this.nr_km = nr_km;    
            nrBilete++;
        }

        public string Destinatie { get => destinatie; set => destinatie = value; }
        public int Pret { get => pret; set => pret = value; }
        public static int NrBilete { get => nrBilete; set => nrBilete = value; }

        public float pretPerkm()
        {
            return (float)this.pret/this.nr_km;
        }

        ~Bilet()
            {
            nrBilete--;
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(this.id);
            stringBuilder.Append(",");
            stringBuilder.Append(this.statie_plecare); stringBuilder.Append(",");
            stringBuilder.Append(this.dataCursa);
            stringBuilder.Append(",");
            stringBuilder.Append(this.destinatie);
            stringBuilder.Append(",");
            stringBuilder.Append(this.Pret); 
            return stringBuilder.ToString();
        }
    }
}
