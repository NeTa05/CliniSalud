﻿using System;
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
    public partial class CitasForm : Form
    {

        AccesoDatosSQL conexion;
        public CitasForm(AccesoDatosSQL pConexion)
        {
            InitializeComponent();
            this.conexion = pConexion;
            this.StartPosition = FormStartPosition.CenterScreen;

        }

        private void btnAtras_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Citas citas = new Citas(this.conexion);
            citas.ShowDialog();
        }

       
    }
}
