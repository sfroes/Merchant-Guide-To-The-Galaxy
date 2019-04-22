using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Util.Conversores
{
    public class ConvertRomanosInteiros
    {
        private Dictionary<char, int> NumerosRomanos = new Dictionary<char, int>()
        {
            {'I', 1 },
            {'V', 5 },
            {'X', 10 },
            {'L', 50 },
            {'C', 100 },
            {'D', 500 },
            {'M', 1000 }
        };

        private string _numeroRomano { get; set; }

        public ConvertRomanosInteiros(string numeroRomano)
        {
            _numeroRomano = numeroRomano.ToUpper().Trim();
        }

        /// <summary>
        /// Retorna o numero inteiro baseado no numero romano
        /// </summary>
        public int ConverterRomanoInteiro()
        {
            if (!this.EhRomano())
            {
                throw new NumerosRomanoInvalidoExceptions();
            }

            List<char> letras = _numeroRomano.Select(s => s).ToList();
            int numeroConvertido = 0;

            for (int i = 0; i < letras.Count; i++)
            {
                int valorAtual = NumerosRomanos[letras[i]];
                int proximoValor = i + 1 < letras.Count ? NumerosRomanos[letras[i + 1]] : 0;
                valorAtual = proximoValor > valorAtual ? -valorAtual : valorAtual;
                numeroConvertido += valorAtual;
            }

            return numeroConvertido;
        }

        /// <summary>
        /// Valida se é um numero romano
        /// </summary>
        /// <returns>Boleano</returns>
        private bool EhRomano()
        {
            bool retorno = true;

            var match = Regex.Match(_numeroRomano, @"^M{0,3}(CM|CD|D?C{0,3})(XC|XL|L?X{0,3})(IX|IV|V?I{0,3})$");

            if (!match.Success)
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
