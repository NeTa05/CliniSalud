using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class AccesoDatosSQL
    {
        static int instancias = 0;              //Contador de cuanta veces se ha instanciado la clase, para evitar que se instancie mas de una vez
        public SqlConnection conexion;          //Objeto de tipo conexion, para establecer comunicacion con la BD
        private Boolean isError = false;        //Una bandera, para determinar si existe o no algun error
        private String errorDescripcion;        //Almacena la descripcion del error        
        private String errorCode;               //Almacena códigos de error                
        private SqlTransaction transaccion;     //Objeto de tipo transaccion de base de datos, para iniciar, procesar y cerrar transacciones
        private bool hayTransaccion;            //Bandera que determina si hay una transaccion activa
        private string schema;                  //Almacena el esquema con el cual se trabaja en la base de datos, para devolverlo mediante un metodo get                
        //El Schema, debera incluir el punto en caso de amerite. Ejemplo : “Admin.”

        // Constructor
        public AccesoDatosSQL(String pUsuario, String pContrasena, String pServidor, String pBD, String pschema)
        {
            limpiarEstado();// pone is error en false

            conexion = new SqlConnection("Data Source=" + pServidor + ";Initial Catalog=" + pBD + ";User Id=" + pUsuario + ";Password=" + pContrasena + ";");
            instancias += 1;//se aumenta contador p crear bd

            // no puede haber + de una instancia de la clase
            if (instancias > 1) return;

            try
            {
                conexion.Open();
                this.schema = pschema;
            }
            catch (SqlException error)
            {
                instancias = 0;// pone instancias en 0 no hay bd
                ProcesarExcepcion(error);
            }
            desconectar();
        }

        // Indica el estado de la conexión
        public string estado()
        {
            limpiarEstado();
            String mensaje = "";

            // estado dela conexión
            switch (conexion.State)
            {
                case System.Data.ConnectionState.Broken:
                    mensaje = "La conexión con la base de datos fue interrumpida.";
                    break;
                case System.Data.ConnectionState.Closed:
                    mensaje = "La conexión con la base de datos fue cerrada o no pudo ser establecida.";
                    break;
                case System.Data.ConnectionState.Connecting:
                    mensaje = "Conectandose.";
                    break;
                case System.Data.ConnectionState.Executing:
                    mensaje = "Ejecutando.";
                    break;
                case System.Data.ConnectionState.Fetching:
                    mensaje = "Extrayendo.";
                    break;
                case System.Data.ConnectionState.Open:
                    mensaje = "Abierta.";
                    break;
            }

            return mensaje;
        }

        public void conectar()
        {
            try
            {
                if (!(conexion.State == ConnectionState.Open))
                {
                    conexion.Open();
                    instancias = 1;
                }
            }
            catch (SqlException error)
            {
                ProcesarExcepcion(error);
            }
        }

        public void desconectar()
        {
            try
            {
                conexion.Close();
                instancias = 0;
            }
            catch (SqlException error)
            {
                ProcesarExcepcion(error);
            }
        }

        //Manipulacion de select sin parámetros
        public DataSet ejecutarConsultaSQL(String pSql)
        {
            limpiarEstado();

            SqlDataAdapter oDataAdapter = new SqlDataAdapter(pSql, conexion);
            DataSet oDataSet = new DataSet();

            // capturar la excepción
            try
            {
                oDataAdapter.Fill(oDataSet);
            }
            catch (SqlException error)
            {
                ProcesarExcepcion(error);

            }

            return oDataSet;
        }

        //Manipulacion de select con parámetros
        public DataSet ejecutarConsultaSQL(String pSql, String pnTabla, Object[] myParamArray)
        {
            limpiarEstado();

            SqlCommand cmd = new SqlCommand(pSql, conexion);

            cmd.CommandType = CommandType.Text;

            for (int j = 0; j < myParamArray.Length; j++)
            {
                cmd.Parameters.Add(((SqlParameter)myParamArray[j]));
            }

            SqlDataAdapter oDataAdapter = new SqlDataAdapter(cmd);
            DataSet oDataSet = new DataSet();

            // capturar la excepción
            try
            {
                oDataAdapter.Fill(oDataSet, pnTabla);
            }
            catch (SqlException error)
            {
                ProcesarExcepcion(error);
            }

            return oDataSet;
        }

        // Método para manipular Insert, Update, Delete sin parámetros
        public void ejecutarSQL(String pSql)
        {
            limpiarEstado();

            // Definicion de Command
            SqlCommand cmd = null;

            try
            {
                cmd = new SqlCommand(pSql, conexion);

                if (this.hayTransaccion)
                {
                    cmd.Transaction = this.transaccion;
                }

                cmd.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                ProcesarExcepcion(error);
            }

        }

        //Método para manipular Insert, Update con parametros
        public void ejecutarSQL(string sql, Object[] myParamArray)
        {
            limpiarEstado();

            try
            {

                SqlCommand cmd = new SqlCommand(sql, conexion);
                cmd.CommandType = CommandType.Text;
                conexion.Open();
                for (int j = 0; j < myParamArray.Length; j++)
                {
                    cmd.Parameters.Add((SqlParameter)myParamArray[j]);//agrega cada dato del array
                }

                if (this.hayTransaccion)
                {
                    cmd.Transaction = this.transaccion;
                }

                cmd.ExecuteNonQuery();
            }
            catch (SqlException error)
            {
                ProcesarExcepcion(error);
            }
            conexion.Close();
        }

        //Metodos de transaccion
        public void iniciarTransaccion()
        {
            if (this.hayTransaccion == false)
            {
                this.transaccion = this.conexion.BeginTransaction();
                this.hayTransaccion = true;
            }
        }

        public void commitTransaccion()
        {
            if (this.hayTransaccion)
            {
                this.transaccion.Commit();
                this.hayTransaccion = false;
            }
        }

        public void rollbackTransaccion()
        {
            if (this.hayTransaccion)
            {
                this.transaccion.Rollback();
                this.hayTransaccion = false;
            }
        }

        public DateTime ObtieneFecha()
        {
            string sql = "select getdate()";//fecha server
            DateTime retorno = DateTime.Today;
            try
            {
                DataSet dsetDatos = new DataSet();
                dsetDatos = ejecutarConsultaSQL(sql);
                retorno = Convert.ToDateTime(dsetDatos.Tables[0].Rows[0][0].ToString());
            }
            catch (SqlException error)
            {
                ProcesarExcepcion(error);
            }
            return retorno;
        }

        // Metodos de Set & Get
        public Boolean IsError
        {
            set { isError = value; }
            get { return isError; }
        }

        public String ErrorDescripcion
        {
            set { errorDescripcion = value; }
            get { return errorDescripcion; }
        }

        public string Schema
        {
            get { return this.schema; }
        }

        public string ErrorCode
        {
            get { return this.errorCode; }
        }

        //Elimina el estado de error de la clase.
        public void limpiarEstado()
        {
            this.errorDescripcion = "";
            this.isError = false;
            this.errorCode = "";
        }

        //da tratamiento a las excepciones
        private void ProcesarExcepcion(SqlException pExcepcion)
        {
            IsError = true;
            ErrorDescripcion += pExcepcion.ErrorCode + "||";
            ErrorDescripcion += pExcepcion.StackTrace + "||";
            ErrorDescripcion += pExcepcion.Message;
            this.errorCode = pExcepcion.ErrorCode.ToString();
        }
        public void actualizarBloque(string pSql, DataTable pTabla)
        {
            try
            {
                SqlDataAdapter adapter = new SqlDataAdapter(pSql, this.conexion);
                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);
                adapter.Update(pTabla);
            }
            catch (SqlException error)
            {
                ProcesarExcepcion(error);
            }
        }

        public SqlDataReader getReader(String consulta)
        {

            SqlCommand command = new SqlCommand(
                 consulta, conexion);
            conexion.Open();

            SqlDataReader reader = command.ExecuteReader();

            return reader;
        }
    }
}

