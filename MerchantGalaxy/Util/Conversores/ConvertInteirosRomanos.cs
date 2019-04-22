using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Util.Conversores
{
    public class ConvertInteirosRomanos
    {


        List<int> listaNumeroInteiros = new List<int>() { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };

        List<string> listaNumeroRomanos = new List<string>() { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        private int _numeroInteiros { get; set; }

        public ConvertInteirosRomanos(string numerosInteiros)
        {
            try
            {
                _numeroInteiros = int.Parse(numerosInteiros.Trim());
            }
            catch (Exception)
            {
                throw new NumerosInteiroInvalidoExceptions();
            }

        }

        /// <summary>
        /// Retorna um valor romano
        /// </summary>
        /// <returns>Retorna string</returns>
        public string ConverterInteiroRomano()
        {
            if (!this.EhInteiroValido())
            {
                throw new NumerosInteiroInvalidoExceptions();
            }

            string numeroConvertido = string.Empty;
            int i = 0;
            while (_numeroInteiros > 0)
            {
                if (_numeroInteiros >= listaNumeroInteiros[i])
                {
                    numeroConvertido += listaNumeroRomanos[i];
                    _numeroInteiros -= listaNumeroInteiros[i];
                }
                else
                {
                    i++;
                }
            }

            return numeroConvertido;
        }

        /// <summary>
        /// Valida se o número é um numero inteiro valido
        /// </summary>
        /// <returns>Retorna um boleano</returns>
        public bool EhInteiroValido()
        {
            bool retono = true;

            if (_numeroInteiros <= 0 || _numeroInteiros > 3999)
            {
                retono = false;
            }

            return retono;
        }
    }
}

