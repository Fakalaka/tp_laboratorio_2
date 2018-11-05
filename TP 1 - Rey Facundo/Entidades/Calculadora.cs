using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Calculadora
    {
        /// <summary>
        /// Verifica que el operador pasado sea correcto
        /// </summary>
        /// <param name="operador">Operador a validar</param>
        /// <returns>El mismo operador si era -, * ó /. Caso contrario +</returns>
        private static string ValidarOperador(string operador)
        {
            if (operador == "-" || operador == "*" || operador == "/")
                return operador;
            else
                return "+";
        }

        /// <summary>
        /// Realiza las operaciones con los valores de los números
        /// </summary>
        /// <param name="num1">Número 1</param>
        /// <param name="num2">Número 2</param>
        /// <param name="operador">Operación a realizar</param>
        /// <returns>Resultado de la operación</returns>
        public double Operar(Numero num1, Numero num2, string operador)
        {         
            switch (ValidarOperador(operador))
            {
                case "+":
                    return num1 + num2;
                case "-":
                    return num1 - num2;
                case "*":
                    return num1 * num2;
                default:
                    return num1 / num2;
            }
        }
    }
}
