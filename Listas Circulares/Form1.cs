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
        Rutas ruta = new Rutas();
        int posicion = 0, horas = 0, minutos = 0, horasInicio = 0, horasFin = 0, minutosInicio = 0, minutosFin = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregarFinal_Click(object sender, EventArgs e)
        {
            Bases bases = new Bases(txtBase.Text, Convert.ToInt32(txtHora.Text), Convert.ToInt32(txtMinutos.Text));
            ruta.agregarFinal(bases);
            txtBase.Clear();
            txtHora.Clear();
            txtMinutos.Clear();
            txtBase.Focus();
            inicializar();
        }



        public void inicializar()
        {
            txtMinutos.Text = "00";
            txtHora.Text = "00";
            txtMinutosInicio.Text = "00";
            txtMinutosFin.Text = "00";
            txtHoraInicio.Text = "00";
            txtHoraFin.Text = "00";
        }
    }
}
