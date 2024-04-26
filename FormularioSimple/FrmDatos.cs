using FormularioSimple.DataAccess;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace FormularioSimple
{
    public partial class FrmDatos : Form
    {
        public FrmDatos()
        {
            InitializeComponent();
        }
        private void btnConectar_Click(object sender, EventArgs e)
        {
            Conexion dataAccess = new Conexion();
            string servidor = txtServidor.Text;
            string db = txtDb.Text;
            string usuario = txtUsuario.Text;
            string contrasena = txtContrasena.Text;

            string cadena = $"Server={servidor}; Database={db}; Uid={usuario}; Psw={contrasena};";

            if (dataAccess.intentoDeConexion(cadena))
            {
                dgvDatos.DataSource = dataAccess.obtenerDatos(cadena);
            }
            else
            {
                MessageBox.Show("No se pudo establecer la conexión");
            }
        }
    }
}
