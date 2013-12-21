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
    public partial class SesionVista : Form
    {
        AccesoDatosSQL conexion;
        public string usuario;

        public SesionVista(AccesoDatosSQL pConexion)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.conexion = pConexion;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           


            this.usuario = this.txtUsuario.Text;
            string contrasena = this.txtContraseña.Text;
            Sesion sesion = new Sesion(conexion);//instancia la clase de las conculsta

            string resultado = sesion.verificaUsuario(this.usuario, contrasena);// se iguala el return del metodo

            

            if (resultado.Equals(""))//si viene vacio no retorno error en contraseña o id
            {

                this.Visible = false;
                Menu menu = new Menu();
                menu.ShowDialog();
            }
            else// si viene diferente a vacio se concatena el error
            {
                MessageBox.Show("Ha ocurrido el siguiente error: " + resultado);
            }

        }
    }
}
