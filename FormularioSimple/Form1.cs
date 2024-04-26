using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace FormularioSimple
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void btnValidar_Click(object sender, EventArgs e)
        {
            // Paso 1: Validar que ambas contraseñas sean iguales
            // Paso 2: Validar que la contraseña cuente con 
            //      12 caracteres, mayusculas, minusculas, 3 simbolos especiales y al menos 1 numero
            //      @"^(?=(?:[^A-Z]*[A-Z]){1})(?=(?:[^a-z]*[a-z]){1})(?=(?:\D*\d){1})(?=(?:[^\W_]*[\W_]){3}[^\W_]*$)[A-Za-z\d\W_]{12}$"

            string primeraContrasena = txtPrimeraContrasena.Text;
            string segundaContrasena = txtSegundaContrasena.Text;
            string regexPattern = @"^(?=(?:[^A-Z]*[A-Z]){1})(?=(?:[^a-z]*[a-z]){1})(?=(?:\D*\d){1})(?=(?:[^\W_]*[\W_]){3}[^\W_]*$)[A-Za-z\d\W_]{12}$";

            if (!primeraContrasena.Equals(segundaContrasena))
            {
                MessageBox.Show("Las contraseñas NO son iguales", "V E R I F I Q U E", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!Regex.IsMatch(primeraContrasena, regexPattern))
            {
                MessageBox.Show("La contraseña no es válida", "V E R I F I Q U E", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            MessageBox.Show("La contraseña fue validada", "E X I T O", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
    }
}
