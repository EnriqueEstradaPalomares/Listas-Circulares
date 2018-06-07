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
        public string Buscar(string nombreBase)
        {
            string texto = "";
            texto = Buscar(nombreBase, inicio).ToString();
            return texto;
        }

        private Bases Buscar(string nombreBase, Bases posicion)
        {
            if (posicion.NombreBase != nombreBase)
                return Buscar(nombreBase, posicion.Sig);
            else
                return posicion;
        }

        //-------------------------------------------------------------------------------------------
        public string EliminarUltimo()
        {
            string texto = "";
            if (inicio != null)
            {
                texto += EliminarUltimo(inicio).ToString();
            }
            return texto;
        }

        private Bases EliminarUltimo(Bases posicion)
        {

            if (posicion.Sig.Sig == inicio)
            {
                Bases temp = posicion.Sig;
                posicion.Sig = inicio;
                return temp;
            }
            else
                return EliminarUltimo(posicion.Sig);
        }
        //------------------------------------------------------------------------
        public string EliminarInicio()
        {
            string texto = inicio.ToString();
            Bases temp = inicio;
            inicio = inicio.Sig;
            nuevoFin(temp, temp);
            return texto;
        }

        private void nuevoFin(Bases posicion, Bases temp)
        {
            if (posicion.Sig == temp)
                posicion.Sig = inicio;
            else
                nuevoFin(posicion.Sig, temp);
        }
        //--------------------------------------------------------------------------
        public string Eliminar(string nombreBase)
        {
            string texto = "";
            if (inicio != null)
            {
                if (inicio.NombreBase == nombreBase)
                    texto += EliminarInicio();
                else
                {
                    Bases temp = Buscar(nombreBase, inicio);
                    Eliminar(temp, inicio);
                    return texto += temp.ToString();
                }
            }
            return texto;
        }

        private void Eliminar(Bases elemento, Bases posicion)
        {
            if (posicion.Sig == elemento)
                posicion.Sig = posicion.Sig.Sig;
            else
                Eliminar(elemento, posicion.Sig);
        }

        //----------------------------------------------------------------
        public string Listar()
        {
            string texto = "";
            if (inicio != null)
            {
                texto += Listar(inicio);
            }
            return texto;
        }

        private string Listar(Bases posicion)
        {
            string texto = "";
            if (posicion.Sig != inicio)
                return texto += posicion.ToString() + Listar(posicion.Sig);
            else
                return texto += posicion.ToString();

        }
        //----------------------------------------------------------------------
        public void Insertar(Bases nuevo, int posicion)
        {
            Bases temp = inicio, temp2;
            if (inicio != null)
            {
                if (posicion == 1)
                {
                    inicio = nuevo;
                    nuevo.Sig = temp;
                    nuevoFin(temp, temp);
                }
                else
                {
                    for (int i = 0; i < posicion - 2; i++)
                        temp = temp.Sig;
                    temp2 = temp.Sig;
                    temp.Sig = nuevo;
                    nuevo.Sig = temp2;
                }
            }
        }
        //----------------------------------------------------------------------
        public string Ruta(string nombreBase, int horaInicio, int horaFin, int minutosInicio, int minutosFin)
        {
            string data = "";
            if (inicio != null)
            {
                TimeSpan hInicio = new TimeSpan(horaInicio, minutosInicio, 0);
                TimeSpan hFin = new TimeSpan(horaFin, minutosFin, 0);
                data += Ruta(inicio, hInicio, hFin);
            }
            return data;
        }

        private string Ruta(Bases posicion, TimeSpan horaInicio, TimeSpan horaFin)
        {
            horaInicio += new TimeSpan(posicion.Horas, posicion.Minutos, 0);
            if (horaInicio <= horaFin)
            {
                return "Nombre base " + posicion.NombreBase + " Hora " + horaInicio + Environment.NewLine +
                        Ruta(posicion.Sig, horaInicio, horaFin);
            }
            return null;
        }
    }
}
