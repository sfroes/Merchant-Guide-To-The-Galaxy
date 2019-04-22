using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Util.Conversores;
using Util.Exceptions;

namespace MerchantGalaxy.Controllers
{
    public class RomanosInteirosController : ApiController
    {
        /// <summary>
        /// Converte valor inteiro baseado no numero Romano
        /// </summary>
        /// <returns>Valor Inteiro</returns>
        [HttpGet]
        public IHttpActionResult ConverterRomanoInteiro(string id)
        {
            try
            {
                ConvertRomanosInteiros conversor = new ConvertRomanosInteiros(id);

                return this.Ok($"O numero romano {id} convertido é {conversor.ConverterRomanoInteiro()}");
            }
            catch (NumerosRomanoInvalidoExceptions ex)
            {
                return this.Ok(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}