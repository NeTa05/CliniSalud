using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using appClinica.Vistas;
using System.Data;
using Datos;

namespace appClinica
{
    static class Program
    {
        static AccesoDatosSQL conexion;
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DataSet parametros = cargarIni().Copy();

            conexion = new AccesoDatosSQL(
                parametros.Tables[0].Rows[0]["Usuario"].ToString(),
                parametros.Tables[0].Rows[0]["Password"].ToString(),
                parametros.Tables[0].Rows[0]["Server"].ToString(),
                parametros.Tables[0].Rows[0]["DataBase"].ToString(),
                parametros.Tables[0].Rows[0]["Schema"].ToString());
            if (conexion.IsError)
            {
                MessageBox.Show("Ha ocurrido un error conectando a la base de datos, " +
                                "detalle técnico: " + conexion.ErrorDescripcion,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            Application.Run(new SesionVista(conexion));

            // Application.Run(new frmMovimientos(conexion,"1"));

        }

        public static DataSet cargarIni()
        {
            DataSet dsetConf = new DataSet();
            string url = "\\INI.xml";//direccion de el INI
            try
            {
                string ArchivoXML = Application.StartupPath + url;
                System.IO.FileStream fsReadXml = new System.IO.FileStream(ArchivoXML, System.IO.FileMode.Open);
                dsetConf.ReadXml(fsReadXml);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ha ocurrido un error cargando el archivo de configuración, " +
                                "detalle técnico: " + e.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
            return dsetConf;
        }
    }
}
