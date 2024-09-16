using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubientParcAuto
{
    internal class Camion:Vehicul
    {
        private string denumire;
        private float lungime_platforma;
        private float capacitate_max;

        public Camion(int id, float pret, string denumire, float lungime_platforma, float capacitate_max) : base(id, pret)
        {
            this.denumire = denumire;
            this.lungime_platforma = lungime_platforma;
            this.capacitate_max = capacitate_max;
        }

        public string Denumire { get => denumire; set => denumire = value; }
        public float Lungime_platforma { get => lungime_platforma; set => lungime_platforma = value; }
        public float Capacitate_max { get => capacitate_max; set => capacitate_max = value; }
    }
}
