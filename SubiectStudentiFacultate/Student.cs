﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace SubiectStudentiFacultate
{
    public class Student
    {
        private int matricol;
        private string nume;
        private float medie;

        public Student(int matricol, string nume, float medie)
        {
            this.matricol = matricol;
            this.nume = nume;
            this.medie = medie;
        }

        public int Matricol { get => matricol; set => matricol = value; }
        public string Nume { get => nume; set => nume = value; }
        public float Medie { get => medie; set => medie = value; }
    }
}
