using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Util.Conversores;
using Util.Exceptions;

namespace MerchantGalaxy.Controllers
{
    public class InterGalacticalController : ApiController
    {
        /// <summary>
        /// Retorna valor inteiro baseado no numero Romano
        /// </summary>
        /// <returns>Valor Inteiro</returns>
        [HttpGet]
        public IHttpActionResult ConverterTextoGalactical(string id)
        {
            try
            {
                ConvertInterGalactical conversor = new ConvertInterGalactical(id);

                return this.Ok(conversor.ConverterTextoGalactical());
            }
            catch (NumerosGalacticaisInvalidoExceptions ex)
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