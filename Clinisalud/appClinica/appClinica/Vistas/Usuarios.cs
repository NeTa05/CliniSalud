using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace appClinica.Vistas
{
    public partial class Usuarios : Form
    {
        public Usuarios()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {

            this.Visible = false;
            Menu menu = new Menu();
            menu.ShowDialog();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            UsuariosForm usuarioForm = new UsuariosForm();
            usuarioForm.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            UsuariosForm usuarioForm = new UsuariosForm();
            usuarioForm.ShowDialog();
        }
        
    }
}
