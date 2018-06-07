using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Circulares
{
    class Bases
    {
        private string _nombreBase = "";
        private int _horas = 0, _minutos = 0;
        private Bases _sig;

        public string NombreBase
        {
            get { return _nombreBase; }
        }

        public int Horas
        {
            get { return _horas; }
        }

        public int Minutos
        {
            get { return _minutos; }
        }

        public Bases Sig
        {
            set { _sig = value; }
            get { return _sig; }
        }

        public Bases(string nombreBase, int horas, int minutos)
        {
            this._nombreBase = nombreBase;
            this._horas = horas;


        }

        public override string ToString()
        {
            return "Base: " + NombreBase + " Horas: " + Horas + " Minutos: " + Minutos;
        }
    }
}
