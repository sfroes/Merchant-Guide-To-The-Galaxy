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
    public class InteirosRomanosController : ApiController
    {
        /// <summary>
        /// Retorna valor Romano baseado no numero inteiro
        /// </summary>
        /// <returns>Valor romano string</returns>
        [HttpGet]
        public IHttpActionResult ConverterInteiroRomano(string id)
        {
            try
            {
                ConvertInteirosRomanos conversor = new ConvertInteirosRomanos(id);

                return this.Ok($"O numero inteiro {id} em romanos é {conversor.ConverterInteiroRomano()}");
            }
            catch (NumerosInteiroInvalidoExceptions ex)
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