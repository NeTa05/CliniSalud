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
    public partial class ClienteForm : Form
    {
        AccesoDatosSQL conexion;
        string tipo = "";
        public ClienteForm(AccesoDatosSQL pConexion, string pTipo)
        {
            InitializeComponent();
            this.tipo = pTipo;
            this.conexion = pConexion;
            this.StartPosition = FormStartPosition.CenterScreen;

            

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Cliente cliente = new Cliente(this.conexion);
            cliente.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClienteDatos clientes = new ClienteDatos(this.conexion);

            // caso de agregar
            if (this.tipo.Equals("agregar"))
            {
                string cedula = txtCedula.Text.ToString().Trim();
                DateTime valoracion = DateTime.Today;
                string nombre = txtNombre.Text.ToString().Trim();
                string apellidos = txtApellidos.Text.ToString().Trim();
                int edad = (int)numEdad.Value;
                string estatura = txtEstatura.Text.ToString().Trim();
                string peso = txtPeso.Text.ToString().Trim();
                DateTime nacimiento = dtNacimiento.Value;
                string email = txtEmail.Text.ToString().Trim();
                int hijos = (int) numHijos.Value;
                string telefono = txtTelefono.Text.ToString().Trim();
                string celular = txtCelular.Text.ToString().Trim();
                string ocupacion = txtOcupacion.Text.ToString().Trim();
                string motivo = txtMotivo.Text.ToString().Trim();
                string presion = txtPresion.Text.ToString().Trim();
                string linfedema = txtLinfedema.Text.ToString().Trim();
                string rh = txtRh.Text.ToString().Trim();
                string factor = txtFactor.Text.ToString().Trim();
                string glucosa = txtGlucosa.Text.ToString().Trim();
                string estrenimiento = txtEstreñimiento.Text.ToString().Trim();
                string trigliceridos = txtTrigliceridos.Text.ToString().Trim();
                string colesterol = txtColesterol.Text.ToString().Trim();
                string rm = txtRm.Text.ToString().Trim();
                string medicamentos = txtMedicamentos.Text.ToString().Trim();
                string enfermedades = txtEnfermedades.Text.ToString().Trim();
                string tabaco = txtTabaco.Text.ToString().Trim();
                string alcohol = txtAlcohol.Text.ToString().Trim();
                string lesiones = txtLesiones.Text.ToString().Trim();
                string ejercicio = txtEjercicio.Text.ToString().Trim();
                string exposicion = txtExposicion.Text.ToString().Trim();
                string proteccion = txtProteccion.Text.ToString().Trim();
                string lunares_manchas = txtLunares.Text.ToString().Trim();
                string implante = txtImplantes.Text.ToString().Trim();
                string anticonceptivos = txtAnticonceptivos.Text.ToString().Trim();
                string embarazo = txtEmbarazo.Text.ToString().Trim();
                string tipo = txtTipo.Text.ToString().Trim();
                string desayuno = txtDesayuno.Text.ToString().Trim();
                string almuerzo = txtAlmuerzo.Text.ToString().Trim();
                string cena = txtCena.Text.ToString().Trim();
                string infusiones = txtInfusiones.Text.ToString().Trim();

                if (cedula.Trim() != "" && email.Trim() != "" && telefono.Trim() != "" && celular.Trim() != "")
                {

                    //cuerpo                , titulo
                    if (MessageBox.Show("Cédula : " + cedula + "\nEmail : " + email + "\nTeléfono : " + telefono +
                        "\nCelular: " + celular, "Datos del nuevo cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        string estado = clientes.insertarClientes(cedula, valoracion, nombre, apellidos, edad, estatura,
                            peso, nacimiento, email, hijos, telefono, celular, ocupacion, motivo, presion, linfedema,
                            rh, factor, glucosa, estrenimiento, trigliceridos, colesterol, rm, medicamentos, enfermedades,
                            tabaco, alcohol, lesiones, ejercicio, exposicion, proteccion, lunares_manchas, implante,
                            anticonceptivos, embarazo, tipo, desayuno, almuerzo, cena, infusiones);
                        //agregado
                        if (estado.Equals(""))
                        {
                            MessageBox.Show("Cliente agregado");
                        }
                         //doble PK
                        else
                        {
                            MessageBox.Show(this, "Cédula ya existente", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                }
                //faltan datos necesarios p la busqueda
                else
                {
                    MessageBox.Show(this, "Debe ingresar cédula, email, télefono, celular.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                
            }

            // caso de modificar
            if (this.tipo.Equals("modificar"))
            { 
            
            }


        }

       

    }
}
