using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        public LaCalculadora()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cierra el form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Borra el contenido de todos los campos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
            lblResultado.Text = "";
        }

        /// <summary>
        /// Muestra el resultado de la operación indicada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.Text)).ToString();
        }

        /// <summary>
        /// Transforma el resultado de binario a decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBinarioADecimal_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                Numero binario = new Numero();
                lblResultado.Text = binario.BinarioDecimal(lblResultado.Text);
            }          
        }

        /// <summary>
        /// Transforma el resultado de decimal a binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDecimalABinario_Click(object sender, EventArgs e)
        {
            if (lblResultado.Text != "")
            {
                Numero binario = new Numero();
                lblResultado.Text = binario.DecimalBinario(lblResultado.Text);
            }          
        }


        /// <summary>
        /// Realiza la operación usando el método Operar de Calculadora
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        static double Operar(string numero1, string numero2, string operador)
        {
            Numero n1 = new Numero(numero1);
            Numero n2 = new Numero(numero2);
            Calculadora calcular = new Calculadora();
            return calcular.Operar(n1, n2, operador);
        }
    }
}
