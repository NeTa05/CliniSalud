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
    public partial class ClienteForm : Form
    {
        public ClienteForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Cliente cliente = new Cliente();
            cliente.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Cliente cliente = new Cliente();
            cliente.ShowDialog();
        }

       

    }
}
