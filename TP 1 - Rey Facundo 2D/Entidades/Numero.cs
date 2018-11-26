using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;

        public string SetNumero
        {
            set => numero = ValidarNumero(value);
        }

        public Numero()
        {
            this.SetNumero = "0";
        }

        public Numero(double numero)
        {
            this.SetNumero = numero.ToString();
        }

        public Numero(string strNumero)
        {
            this.SetNumero = strNumero;
        }

        /// <summary>
        /// Transforma una cadena de texto en número double
        /// </summary>
        /// <param name="strNumero">El número en string</param>
        /// <returns>El número en double. Si no lo pudo parsear, devuelve 0</returns>
        private double ValidarNumero(string strNumero)
        {
            double numero;
            if (double.TryParse(strNumero, out numero))
                return numero;
            else
                return 0;
        }

        /// <summary>
        /// Pasa un número binario a decimal
        /// </summary>
        /// <param name="binario">Número binario</param>
        /// <returns>Número decimal si era un binario. Si no, mensaje de error</returns>
        public string BinarioDecimal(string binario)
        {
            int i = 0;
            while (i<binario.Length)
            {
                if (binario[i] != '0' && binario[i] != '1')
                    return "Valor inválido";
                i++;
            }
            return Convert.ToInt32(binario, 2).ToString();
        }

        /// <summary>
        /// Pasa un número decimal a binario
        /// </summary>
        /// <param name="binario">Número decimal double</param>
        /// <returns>Número binario si era un decimal sin coma. Si no, mensaje de error</returns>
        public string DecimalBinario (double numero)
        {
            return DecimalBinario(numero.ToString());           
        }

        /// <summary>
        /// Pasa un número decimal a binario
        /// </summary>
        /// <param name="binario">Número decimal string</param>
        /// <returns>Número binario si era un decimal sin coma. Si no, mensaje de error</returns>
        public string DecimalBinario(string numero)
        {
            int binario;
            if (int.TryParse(numero, out binario))
                return Convert.ToString(binario, 2);
            else
                return "Valor inválido";
        }

        public static double operator +(Numero n1, Numero n2)
        {
            return n1.numero + n2.numero;
        }

        public static double operator -(Numero n1, Numero n2)
        {
            return n1.numero - n2.numero;
        }

        public static double operator *(Numero n1, Numero n2)
        {
            return n1.numero * n2.numero;
        }

        public static double operator /(Numero n1, Numero n2)
        {
            if (n2.numero != 0)
                return n1.numero / n2.numero;
            else
                return 0;
        }
    }
}
