using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Listas_Circulares
{
    public partial class Form1 : Form
    {
        Bases bases;
        Rutas ruta = new Rutas();
        public Form1()
        {
            InitializeComponent();
            start();
        }

        private void btnAgregarFinal_Click(object sender, EventArgs e)
        {
            bases = new Bases(txtBase.Text, Convert.ToInt32(txtHora.Text), Convert.ToInt32(txtMinutos.Text));
            ruta.agregarFinal(bases);
            txtBase.Clear();
            txtHora.Clear();
            txtMinutos.Clear();
            txtBase.Focus();
            start();
        }

        public void start()
        {
            txtMinutos.Text = "00";
            txtHora.Text = "00";
            txtMinutosInicio.Text = "00";
            txtMinutosFin.Text = "00";
            txtHoraInicio.Text = "00";
            txtHoraFin.Text = "00";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nombreBase = txtBase.Text;
            txtTexto.Text += ruta.Buscar(nombreBase);
        }

        private void btnEliminarUltimo_Click(object sender, EventArgs e)
        {
            txtTexto.Clear();
            txtTexto.Text += ruta.EliminarUltimo();
        }

        private void btnEliminarInicio_Click(object sender, EventArgs e)
        {
            txtTexto.Clear();
            txtTexto.Text += ruta.EliminarInicio();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            string nombre = txtBase.Text;
            txtTexto.Clear();
            txtTexto.Text = ruta.Eliminar(nombre);
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            txtTexto.Clear();
            txtTexto.Text = ruta.Listar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            string nombre = txtBase.Text;
            int horas = int.Parse(txtHora.Text);
            int minutos = int.Parse(txtMinutos.Text);
            int posicion = int.Parse(txtPosicion.Text);
            bases = new Bases(nombre, horas, minutos);
            ruta.Insertar(bases, posicion);
        }

        private void btnRuta_Click(object sender, EventArgs e)
        {
            txtTexto.Clear();
            txtTexto.Text = ruta.Ruta(txtBaseInicio.Text, int.Parse(txtHoraInicio.Text), int.Parse(txtHoraFin.Text),
                int.Parse(txtMinutosInicio.Text), int.Parse(txtMinutosFin.Text));
        }
    }
}
