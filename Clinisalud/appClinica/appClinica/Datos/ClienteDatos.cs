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

        //insert into clientes
        public string insertarClientes
            (string pCedula,DateTime pValoracion,string pNombre, string pApellidos, string pEdad, string pEstatura,
            string pPeso,DateTime pNacimiento,string pEmail,int pHijos,string pTelefono, string pCelular, string pOcupacion, 
            string pMotivo,string pPresion, string pLinfedema,string pRh, string pFactor, string pGlucosa, string pEstrenimiento,
            string pTrigliceridos, string pColesterol, string pRm, string pMedicamentos, string pEnfermedades, string pTabaco,
            string pAlcohol,string pLesiones, string pEjercicio, string pExposicion,string pProteccion,string pLunares, 
            string pImplantes, string pAnticonceptivos, string pEmbarazo, string pTipo, string pDesayuno,string pAlmuerzo, 
            string pCena,string pInfusiones)
        {
            this.error = "";
            string sql = "insert into Clientes values(@cedula,@valoracion,@nombre,@apellidos,@edad,@estatura,"+
                "@peso,@nacimiento,@email,@hijos,@telefono,@celular,@ocupacion,@motivo,@presion,@linfedema,@rh,@factor,"+
                "@glucosa, @estrenimiento,@trigliceridos,@colesterol,@rm,@medicamentos,@enfermedades,@tabaco,@alcohol,"+
                "@lesiones,@ejercicio,@exposicion,@proteccion,@lunares,@implantes,@anticonceptivos,@embarazo,@tipo,"+
                "@desayuno,@almuerzo,@cena,@infusiones)";

            SqlParameter[] Parametros = new SqlParameter[40];

            Parametros[0] = new SqlParameter();
            Parametros[0].SqlDbType = SqlDbType.VarChar;
            Parametros[0].ParameterName = "@cedula";
            Parametros[0].Value = pCedula;

            Parametros[1] = new SqlParameter();
            Parametros[1].SqlDbType = SqlDbType.DateTime;
            Parametros[1].ParameterName = "@valoracion";
            Parametros[1].Value = pValoracion;

            Parametros[2] = new SqlParameter();
            Parametros[2].SqlDbType = SqlDbType.VarChar;
            Parametros[2].ParameterName = "@nombre";
            Parametros[2].Value = pNombre;

            Parametros[3] = new SqlParameter();
            Parametros[3].SqlDbType = SqlDbType.VarChar;
            Parametros[3].ParameterName = "@apellidos";
            Parametros[3].Value = pApellidos;

            Parametros[4] = new SqlParameter();
            Parametros[4].SqlDbType = SqlDbType.VarChar;
            Parametros[4].ParameterName = "@edad";
            Parametros[4].Value = pEdad;

            Parametros[5] = new SqlParameter();
            Parametros[5].SqlDbType = SqlDbType.VarChar;
            Parametros[5].ParameterName = "@estatura";
            Parametros[5].Value = pEstatura;

            Parametros[6] = new SqlParameter();
            Parametros[6].SqlDbType = SqlDbType.VarChar;
            Parametros[6].ParameterName = "@peso";
            Parametros[6].Value = pPeso;

            Parametros[7] = new SqlParameter();
            Parametros[7].SqlDbType = SqlDbType.DateTime;
            Parametros[7].ParameterName = "@nacimiento";
            Parametros[7].Value = pNacimiento;

            Parametros[8] = new SqlParameter();
            Parametros[8].SqlDbType = SqlDbType.VarChar;
            Parametros[8].ParameterName = "@email";
            Parametros[8].Value = pEmail;

            Parametros[9] = new SqlParameter();
            Parametros[9].SqlDbType = SqlDbType.Int;
            Parametros[9].ParameterName = "@hijos";
            Parametros[9].Value = pHijos;

            Parametros[10] = new SqlParameter();
            Parametros[10].SqlDbType = SqlDbType.VarChar;
            Parametros[10].ParameterName = "@telefono";
            Parametros[10].Value = pTelefono;

            Parametros[11] = new SqlParameter();
            Parametros[11].SqlDbType = SqlDbType.VarChar;
            Parametros[11].ParameterName = "@celular";
            Parametros[11].Value = pCelular;

            Parametros[12] = new SqlParameter();
            Parametros[12].SqlDbType = SqlDbType.VarChar;
            Parametros[12].ParameterName = "@ocupacion";
            Parametros[12].Value = pOcupacion;

            Parametros[13] = new SqlParameter();
            Parametros[13].SqlDbType = SqlDbType.VarChar;
            Parametros[13].ParameterName = "@motivo";
            Parametros[13].Value = pMotivo;

            Parametros[14] = new SqlParameter();
            Parametros[14].SqlDbType = SqlDbType.VarChar;
            Parametros[14].ParameterName = "@presion";
            Parametros[14].Value = pPresion;

            Parametros[15] = new SqlParameter();
            Parametros[15].SqlDbType = SqlDbType.VarChar;
            Parametros[15].ParameterName = "@linfedema";
            Parametros[15].Value = pLinfedema;

            Parametros[16] = new SqlParameter();
            Parametros[16].SqlDbType = SqlDbType.VarChar;
            Parametros[16].ParameterName = "@rh";
            Parametros[16].Value = pRh;

            Parametros[17] = new SqlParameter();
            Parametros[17].SqlDbType = SqlDbType.VarChar;
            Parametros[17].ParameterName = "@factor";
            Parametros[17].Value = pFactor;

            Parametros[18] = new SqlParameter();
            Parametros[18].SqlDbType = SqlDbType.VarChar;
            Parametros[18].ParameterName = "@glucosa";
            Parametros[18].Value = pGlucosa;

            Parametros[19] = new SqlParameter();
            Parametros[19].SqlDbType = SqlDbType.VarChar;
            Parametros[19].ParameterName = "@estrenimiento";
            Parametros[19].Value = pEstrenimiento;

            Parametros[20] = new SqlParameter();
            Parametros[20].SqlDbType = SqlDbType.VarChar;
            Parametros[20].ParameterName = "@trigliceridos";
            Parametros[20].Value = pTrigliceridos;

            Parametros[21] = new SqlParameter();
            Parametros[21].SqlDbType = SqlDbType.VarChar;
            Parametros[21].ParameterName = "@colesterol";
            Parametros[21].Value = pColesterol;

            Parametros[22] = new SqlParameter();
            Parametros[22].SqlDbType = SqlDbType.VarChar;
            Parametros[22].ParameterName = "@rm";
            Parametros[22].Value = pRm;

            Parametros[23] = new SqlParameter();
            Parametros[23].SqlDbType = SqlDbType.VarChar;
            Parametros[23].ParameterName = "@medicamentos";
            Parametros[23].Value = pMedicamentos;

            Parametros[24] = new SqlParameter();
            Parametros[24].SqlDbType = SqlDbType.VarChar;
            Parametros[24].ParameterName = "@enfermedades";
            Parametros[24].Value = pEnfermedades;

            Parametros[25] = new SqlParameter();
            Parametros[25].SqlDbType = SqlDbType.VarChar;
            Parametros[25].ParameterName = "@tabaco";
            Parametros[25].Value = pTabaco;

            Parametros[26] = new SqlParameter();
            Parametros[26].SqlDbType = SqlDbType.VarChar;
            Parametros[26].ParameterName = "@alcohol";
            Parametros[26].Value = pAlcohol;

            Parametros[27] = new SqlParameter();
            Parametros[27].SqlDbType = SqlDbType.VarChar;
            Parametros[27].ParameterName = "@lesiones";
            Parametros[27].Value = pLesiones;

            Parametros[28] = new SqlParameter();
            Parametros[28].SqlDbType = SqlDbType.VarChar;
            Parametros[28].ParameterName = "@ejercicio";
            Parametros[28].Value = pEjercicio;

            Parametros[29] = new SqlParameter();
            Parametros[29].SqlDbType = SqlDbType.VarChar;
            Parametros[29].ParameterName = "@exposicion";
            Parametros[29].Value = pExposicion;

            Parametros[30] = new SqlParameter();
            Parametros[30].SqlDbType = SqlDbType.VarChar;
            Parametros[30].ParameterName = "@proteccion";
            Parametros[30].Value = pProteccion;

            Parametros[31] = new SqlParameter();
            Parametros[31].SqlDbType = SqlDbType.VarChar;
            Parametros[31].ParameterName = "@lunares";
            Parametros[31].Value = pLunares;

            Parametros[32] = new SqlParameter();
            Parametros[32].SqlDbType = SqlDbType.VarChar;
            Parametros[32].ParameterName = "@implantes";
            Parametros[32].Value = pImplantes;

            Parametros[33] = new SqlParameter();
            Parametros[33].SqlDbType = SqlDbType.VarChar;
            Parametros[33].ParameterName = "@anticonceptivos";
            Parametros[33].Value = pAnticonceptivos;

            Parametros[34] = new SqlParameter();
            Parametros[34].SqlDbType = SqlDbType.VarChar;
            Parametros[34].ParameterName = "@embarazo";
            Parametros[34].Value = pEmbarazo;

            Parametros[35] = new SqlParameter();
            Parametros[35].SqlDbType = SqlDbType.VarChar;
            Parametros[35].ParameterName = "@tipo";
            Parametros[35].Value = pTipo;

            Parametros[36] = new SqlParameter();
            Parametros[36].SqlDbType = SqlDbType.VarChar;
            Parametros[36].ParameterName = "@desayuno";
            Parametros[36].Value = pDesayuno;

            Parametros[37] = new SqlParameter();
            Parametros[37].SqlDbType = SqlDbType.VarChar;
            Parametros[37].ParameterName = "@almuerzo";
            Parametros[37].Value = pAlmuerzo;

            Parametros[38] = new SqlParameter();
            Parametros[38].SqlDbType = SqlDbType.VarChar;
            Parametros[38].ParameterName = "@cena";
            Parametros[38].Value = pCena;

            Parametros[39] = new SqlParameter();
            Parametros[39].SqlDbType = SqlDbType.VarChar;
            Parametros[39].ParameterName = "@infusiones";
            Parametros[39].Value = pInfusiones;

            this.cnx.ejecutarSQL(sql, Parametros);
            if (this.cnx.IsError)
            {
                this.error = this.cnx.ErrorDescripcion;
            }
            return error;
        }


        #endregion 
    }
}
