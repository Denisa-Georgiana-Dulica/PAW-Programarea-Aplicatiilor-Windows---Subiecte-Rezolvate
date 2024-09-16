using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubientParcAuto
{
    public class Vehicul
    {
        private int id;
        private float pret;

        public Vehicul(int id,  float pret)
        {
            this.id = id;
            this.pret = pret;
        }

        public int Id { get => id; set => id = value; }

        public float Pret { get => pret; set => pret = value; }
    
    }
}
