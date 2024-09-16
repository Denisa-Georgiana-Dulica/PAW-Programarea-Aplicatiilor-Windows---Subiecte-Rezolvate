using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubiectBicicletePublice
{
    [Serializable]
    public class Bicicleta
    {
        private readonly int codB;//constant
        private string denumire_parcare;
        private int km_parcursi;

        public Bicicleta(string denumire_parcare, int km_parcursi,int codB)
        {
            this.codB = codB;
            this.denumire_parcare = denumire_parcare;
            this.km_parcursi = km_parcursi;
        }

        
        public string Denumire_parcare { get => denumire_parcare; set => denumire_parcare = value; }
        public int Km_parcursi { get => km_parcursi; set => km_parcursi = value; }

        public int CodB => codB;
    }
}
