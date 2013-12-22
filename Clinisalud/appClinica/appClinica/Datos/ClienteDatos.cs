using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    class ClienteDatos
    {

        //atributos
        AccesoDatosSQL cnx;//conexion bd
        string error;//posible error

        //metodo constructor cn conexion y error vacio
        public ClienteDatos(AccesoDatosSQL pCnx)
        {
            this.cnx = pCnx;
            this.error = "";
        }

        //get error
        public string Error
        {
            get { return error; }
        }

        #region Consultas


        //select de carretas
        public DataSet obtenerClientes()
        {
            this.error = "";
            string sql = "select * from Clientes";
            DataSet retorno = this.cnx.ejecutarConsultaSQL(sql);
            if (this.cnx.IsError)
            {
                this.error = this.cnx.ErrorDescripcion;
            }
            return retorno;
        }
        #endregion 
    }
}
