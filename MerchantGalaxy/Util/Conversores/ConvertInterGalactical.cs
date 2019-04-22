using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Util.Exceptions;

namespace Util.Conversores
{
    public class ConvertInterGalactical
    {
        /// <summary>
        /// Numerais galaticais com sua determinada correspondencia em romanos
        /// </summary>
        private Dictionary<string, char> NumeroGalactical = new Dictionary<string, char>()
        {
           {"glob", 'I' },
           {"prok", 'V' },
           {"pish", 'X' },
           {"tegj", 'L' }
        };

        /// <summary>
        /// O dicionário será para cada elemento com o seu determinado valor unitário. E assim podendo converter qualquer valor.
        /// </summary>
        private Dictionary<string, double> MetaisGalactical = new Dictionary<string, double>()
        {
            {"Silver", 17 },
            {"Gold", 14450 },
            {"Iron", 195.5 },
        };

        private string _textGalactical { get; set; }

        public ConvertInterGalactical(string textGalactical)
        {
            this._textGalactical = textGalactical.ToLower();
        }

        /// <summary>
        /// Converter e calcular o texto galactical
        /// </summary>
        /// <returns></returns>
        public string ConverterTextoGalactical()
        {
            try
            {
                string retorno = string.Empty;

                if (!ValidacaoTextoGalactical())
                {
                    throw new NumerosGalacticaisInvalidoExceptions();
                }

                retorno = this.InterpretarTexto();

                return retorno;
            }
            catch (Exception)
            {
                throw new NumerosGalacticaisInvalidoExceptions();
            }

        }

        private string InterpretarTexto()
        {
            string retorno = string.Empty;

            Dictionary<int, string> numerosGalacticais = this.OcorrenciasNumeroGalactical();

            Dictionary<string, int> metaisGalacticais = this.ContarMetaisGalactical();

            //Gerar numero romano baseado nos numeros galacticais
            string conversaoNumerosGalacticaisRomanos = string.Empty;

            int conversaoNumeroRomanoInteiros = 0;

            double valorMetais = 1;

            foreach (var item in numerosGalacticais)
            {
                retorno += $"{item.Value} ";

                conversaoNumerosGalacticaisRomanos += NumeroGalactical[item.Value];
            }

            //Recupera os numeros inteiros do numero romano
            conversaoNumeroRomanoInteiros = new ConvertRomanosInteiros(conversaoNumerosGalacticaisRomanos).ConverterRomanoInteiro();

            //Caso exista metais recupera o valor de cada metal
            foreach (var item in metaisGalacticais)
            {
                retorno += $"{item.Key} ";

                valorMetais = MetaisGalactical[item.Key];
            }

            //Efetua os calculos e arrendondamentos necessarios 
            retorno += $"is {valorMetais * conversaoNumeroRomanoInteiros}{(valorMetais > 1 ? " Credits" : "")}";

            return retorno;
        }

        /// <summary>
        /// Contar quantas vezer o numeros galacticais ocorrem na frase
        /// </summary>
        /// <returns>Dicionário de numeros com o numero de reptições</returns>
        private Dictionary<int, string> OcorrenciasNumeroGalactical()
        {
            Dictionary<int, string> retorno = new Dictionary<int, string>();

            foreach (var item in NumeroGalactical)
            {
                MatchCollection ocorrecias = Regex.Matches(_textGalactical, item.Key);

                foreach (Match ocorrecia in ocorrecias)
                {
                    retorno.Add(ocorrecia.Index, item.Key);
                }
            }

            //Retorna as ocorrecias dos numeros galacticais em posição de entrada no texto
            return retorno.OrderBy(o => o.Key).ToDictionary(d => d.Key, d => d.Value);
        }

        /// <summary>
        /// Contar quantas vezes o metais galacticais ocorrem na frase
        /// </summary>
        /// <returns>Dicionário de metais com o numero de reptições</returns>
        private Dictionary<string, int> ContarMetaisGalactical()
        {
            Dictionary<string, int> retorno = new Dictionary<string, int>();

            foreach (var item in MetaisGalactical)
            {
                MatchCollection ocorrecias = Regex.Matches(_textGalactical, item.Key.ToLower());

                if (ocorrecias.Count > 0)
                {
                    retorno.Add(item.Key, ocorrecias.Count);
                }
            }

            return retorno;
        }

        /// <summary>
        /// Validar se texto galactical é coerente
        /// </summary>
        /// <returns>Retorna boleano validando texto galactical</returns>
        private bool ValidacaoTextoGalactical()
        {
            bool retorno = true;

            Dictionary<int, string> numerosGalacticais = this.OcorrenciasNumeroGalactical();

            Dictionary<string, int> metaisGalacticais = this.ContarMetaisGalactical();

            //Cenario caso tenha mais de um metal o frase é errada
            if (metaisGalacticais.Count > 1)
            {
                retorno = false;
            }

            //Cenario caso não tenha nenhum metal ou nenhum numero galactical
            if (metaisGalacticais.Count == 0 && numerosGalacticais.Count == 0)
            {
                retorno = false;
            }

            return retorno;
        }
    }
}
