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
    public partial class CitasForm : Form
    {
        public CitasForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Citas citas = new Citas();
            citas.ShowDialog();
        }

       
    }
}
