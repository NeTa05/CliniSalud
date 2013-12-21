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
    public partial class Citas : Form
    {
        public Citas()
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

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            CitasForm citasForm = new CitasForm();
            citasForm.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            CitasForm citasForm = new CitasForm();
            citasForm.ShowDialog();
        }

       
    }
}
