using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubientParcAuto
{
   public class Autoturism : Vehicul, ICloneable, IComparable
    {
        private string denumire;
        private float[] km_parcursi;
        private int numar_locuri;
        private float km_medie;

        public Autoturism(int id, float pret, string denumire, float[] km_parcursi, int numar_locuri) : base(id, pret)
        {
            this.Denumire = denumire;
            this.km_parcursi = km_parcursi;
            this.numar_locuri = numar_locuri;
        }

      
        public float[] Km_parcursi { get => km_parcursi; set => km_parcursi = value; }
        public int Numar_locuri { get => numar_locuri; set => numar_locuri = value; }
        public string Denumire { get => denumire; set => denumire = value; }
        public float Km_medie { get => km_medie; set => km_medie = value; }

        public object Clone()
        {
            Autoturism a = new Autoturism(this.Id, this.Pret, this.Denumire, this.km_parcursi, this.numar_locuri);
            return a;
        }

        public int CompareTo(object obj)
        {
            if (obj is Autoturism)
            {
                Autoturism a = (Autoturism)obj;
                if (this.Pret > a.Pret)
                {
                    return 1;
                }
                else if (this.Pret < a.Pret)
                    return -1;
                else
                    return 0;
            }
            else
                return -2;
        }

        public static Autoturism operator +(Autoturism a, float km)
        {
            if (km > 0)
            {

                float[] vector = new float[a.km_parcursi.Length + 1];
                Array.Copy(a.km_parcursi, vector, a.km_parcursi.Length);
                vector[vector.Length - 1] = km;
                a.km_parcursi = vector;
                return a;


            }
            else
                return a;

        }

        public static explicit operator double(Autoturism a)
        {
            if (a.km_parcursi != null)
            {
                for (int i = 0; i < a.km_parcursi.Length; i++)
                {
                    a.km_medie += a.Km_parcursi[i];
                }
                a.km_medie /= a.km_parcursi.Length;
                return a.km_medie;
            }
            else
                return 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.Denumire);
            sb.Append(" Numar locuri:");
            sb.Append(this.numar_locuri);
            sb.Append(" Km:");
            for (int i = 0; i < this.Km_parcursi.Length; i++)
            {
                sb.Append(this.km_parcursi[i]);
                sb.Append(" ");
            }
            return sb.ToString();

        }
    }
}

