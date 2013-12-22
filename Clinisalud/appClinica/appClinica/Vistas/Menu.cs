using Datos;
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
    public partial class Menu : Form
    {
        AccesoDatosSQL conexion;

        public Menu(AccesoDatosSQL pConexion)
        {
            InitializeComponent();
            this.conexion = pConexion;
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Cliente cliente = new Cliente(this.conexion);
            cliente.ShowDialog();
        }

        private void citasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Citas citas = new Citas(this.conexion);
            citas.ShowDialog();
        }

        private void usuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Usuarios usarios = new Usuarios(this.conexion);
            usarios.ShowDialog();
        }
    }
}
