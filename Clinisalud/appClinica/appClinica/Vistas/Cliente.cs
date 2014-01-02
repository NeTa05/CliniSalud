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
    public partial class Cliente : Form
    {
        private AccesoDatosSQL conexion;

        public Cliente(AccesoDatosSQL pConexion)
        {
            InitializeComponent();
            this.conexion = pConexion;
            this.cargarGrid();
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ClienteForm formulario = new ClienteForm(this.conexion,"agregar");
            formulario.ShowDialog();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            ClienteForm formulario = new ClienteForm(this.conexion,"modificar");
            formulario.ShowDialog();
        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Menu menu = new Menu(this.conexion);
            menu.ShowDialog();
        }

        public void cargarGrid()
        {
            ClienteDatos cliente = new ClienteDatos(this.conexion);
            
            DataSet dset = cliente.obtenerClientes().Copy();
            if (cliente.Error != "")
            {
                MessageBox.Show(cliente.Error);
                return;
            }
            this.gridCliente.DataSource = dset.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

       
    }
}
