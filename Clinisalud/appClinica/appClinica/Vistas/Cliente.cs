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
    public partial class Cliente : Form
    {
        public Cliente()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ClienteForm formulario = new ClienteForm();
            formulario.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ClienteForm formulario = new ClienteForm();
            formulario.ShowDialog();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu();
            menu.ShowDialog();
        }

       
    }
}
