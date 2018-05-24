using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Circulares
{
    class Rutas
    {
        Bases inicio;

        public void agregarFinal(Bases nuevo)
        {
            if (inicio == null)
            {
                inicio = nuevo;
                inicio.Sig = inicio;
            }
            else
                AgregarFinal(inicio, nuevo);
        }

        private void AgregarFinal(Bases posicion, Bases nuevo)
        {
            if (posicion.Sig == inicio)
            {
                posicion.Sig = nuevo;
                nuevo.Sig = inicio;
            }
            else
                AgregarFinal(posicion.Sig, nuevo);
        }
        //-----------------------------------------------------------------------------------------

    }
}
