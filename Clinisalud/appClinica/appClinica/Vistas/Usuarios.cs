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
    public partial class Usuarios : Form
    {
        AccesoDatosSQL conexion;
        public Usuarios(AccesoDatosSQL pConexion)
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            UsuariosForm usuarioForm = new UsuariosForm(this.conexion);
            usuarioForm.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            UsuariosForm usuarioForm = new UsuariosForm(this.conexion);
            usuarioForm.ShowDialog();
        }
        
    }
}
