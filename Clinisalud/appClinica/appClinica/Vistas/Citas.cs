using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Datos;

namespace appClinica.Vistas
{
    public partial class Citas : Form
    {
        AccesoDatosSQL conexion;
        public Citas(AccesoDatosSQL pConexion)
        {
            InitializeComponent();
            this.conexion = pConexion;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu(this.conexion);
            menu.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            CitasForm citasForm = new CitasForm(this.conexion);
            citasForm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            CitasForm citasForm = new CitasForm(this.conexion);
            citasForm.ShowDialog();
        }

       
    }
}
