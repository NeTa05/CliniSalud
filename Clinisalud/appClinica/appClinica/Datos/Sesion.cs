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
    class Sesion
    {

         //atributos
        AccesoDatosSQL cnx;//conexion bd
        string error;//posible error

        //metodo constructor cn conexion y error vacio
        public Sesion(AccesoDatosSQL pCnx)
        {
            this.cnx = pCnx;
            this.error = "";
        }

        //get error
        public string Error
        {
            get { return error; }
        }

        #region Consultas seguridad


        //verificar q el usuario exista y la contraseña sea correcta
        public string verificaUsuario(string pUsuario, string pContraseña)
        {

            string mensaje = "";//dato a retornar
            this.error = "";// posible error
            string sql = "select * from Usuarios  where usuario=@usuario ";

            SqlParameter[] Parametros = new SqlParameter[2];//arreglo de parametros p consulta

            Parametros[0] = new SqlParameter();             //posicion 0 es varchar y hace referencia a la columna usuario
            Parametros[0].SqlDbType = SqlDbType.VarChar;
            Parametros[0].ParameterName = "@usuario";
            Parametros[0].Value = pUsuario;

            Parametros[1] = new SqlParameter();             //posicion 1 es varchar y hace referencia a la columna contraseña
            Parametros[1].SqlDbType = SqlDbType.VarChar;
            Parametros[1].ParameterName = "@contrasena";
            Parametros[1].Value = pContraseña;

            DataSet retorno;//almacenar datos de las tablas
            try
            {
                retorno = this.cnx.ejecutarConsultaSQL(sql, "table", Parametros);//consulta, nomb tabla, parametros p consulta
            }
            catch//si ocurre error pone dataset retorno en null
            {
                retorno = null;
            }

            if (retorno.Tables[0].Rows.Count > 0)//si trae mas de una fila
            {
                string usuario = retorno.Tables[0].Rows[0]["usuario"].ToString();//obtener una tabla primero ref tabla desp       
                string contrasena = retorno.Tables[0].Rows[0]["contrasena"].ToString();//obtener una tabla primero ref tabla 
                if (usuario.Equals(pUsuario))//si las contraseña de la bd es igual a la digitada
                {
                    mensaje = "";//pone mensaje en blanco p indicar q si puede iniciar sesion
                    if (pContraseña.Equals(pContraseña))
                    {
                        mensaje = "Ingreso";
                    }
                    else
                    { 
                        mensaje="Contraseña incorrecta";
                    }

                }
                else//si las contraseña no coincide cn la bd
                {
                    mensaje = "Usuario incorrecto";//pone mensaje como contraseña incorrecta
                }

            }
            else//si no trae fila el usuario no esta en la bd
            {
                mensaje = "Usuario incorrecto";//pone mensaje como contraseña incorrecta
            }
            if (this.cnx.IsError)
            {
                this.error = this.cnx.ErrorDescripcion;
            }

            return mensaje;
        }

        

        #endregion
    }
}
