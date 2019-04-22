using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Conversores;
using Util.Exceptions;

namespace MerchantGalaxy.Tests
{
    [TestClass]
    public class InterGalacticalTest
    {
        [TestMethod]
        public void InterpretarSimboloGalacticalBasicoParaInteiro()
        {
            Assert.AreEqual("glob is 1", new ConvertInterGalactical("glob").ConverterTextoGalactical());
            Assert.AreEqual("prok is 5", new ConvertInterGalactical("prok").ConverterTextoGalactical());
            Assert.AreEqual("pish is 10", new ConvertInterGalactical("pish").ConverterTextoGalactical());
            Assert.AreEqual("tegj is 50", new ConvertInterGalactical("tegj").ConverterTextoGalactical());

        }

        [TestMethod]
        [ExpectedException(typeof(NumerosGalacticaisInvalidoExceptions))]
        public void InterpetrarTextoInvalidoCausaException()
        {
            new ConvertInterGalactical("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?").ConverterTextoGalactical();
        }

        #region Levando em consideração as regras dos numeros romanos

        [TestMethod]
        [ExpectedException(typeof(NumerosGalacticaisInvalidoExceptions))]
        public void InterpetrarSequenciaSimboloInvalidoEmbasadoNumerosRomanosCausaException()
        {
            new ConvertInterGalactical("prok pish").ConverterTextoGalactical();
        }

        [TestMethod]
        [ExpectedException(typeof(NumerosGalacticaisInvalidoExceptions))]
        public void InterpetrarSequenciaSimboloInvalidoEmbasadoNumerosRomanosRepetidosCausaException()
        {
            new ConvertInterGalactical("prok prok").ConverterTextoGalactical();
        }

        [TestMethod]
        [ExpectedException(typeof(NumerosGalacticaisInvalidoExceptions))]
        public void InterpetrarSequenciaSimboloInvalidoEmbasadoNumerosRomanosRepetidosMaisTresVezesCausaException()
        {
            new ConvertInterGalactical("glob glob glob glob").ConverterTextoGalactical();
        }

        #endregion

        [TestMethod]
        public void InterpetrarTextoComMetais()
        {
            var resultadoSilver = new ConvertInterGalactical("how many Credits is glob prok Silver ?").ConverterTextoGalactical();
            var resultadoGold = new ConvertInterGalactical("how many Credits is glob prok Gold ?").ConverterTextoGalactical();
            var resultadoIron = new ConvertInterGalactical("how many Credits is glob prok Iron ?").ConverterTextoGalactical();

            Assert.AreEqual("glob prok Silver is 68 Credits", resultadoSilver);
            Assert.AreEqual("glob prok Gold is 57800 Credits", resultadoGold);
            Assert.AreEqual("glob prok Iron is 782 Credits", resultadoIron);
        }

        [TestMethod]
        public void InterpetrarTextoSemMetais()
        {
            var resultado = new ConvertInterGalactical("how much is pish tegj glob glob ?").ConverterTextoGalactical();

            Assert.AreEqual("pish tegj glob glob is 42", resultado);

        }
    }
}
