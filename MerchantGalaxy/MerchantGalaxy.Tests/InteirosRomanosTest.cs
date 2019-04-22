using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util.Conversores;
using Util.Exceptions;

namespace MerchantGalaxy.Tests
{
    [TestClass]
    public class InteirosRomanosTest
    {
        [TestMethod]
        public void ConverterNumeroInteiroBasicosEmNumeroRomano()
        {
            Assert.AreEqual("I", new ConvertInteirosRomanos("1").ConverterInteiroRomano());
            Assert.AreEqual("V", new ConvertInteirosRomanos("5").ConverterInteiroRomano());
            Assert.AreEqual("X", new ConvertInteirosRomanos("10").ConverterInteiroRomano());
            Assert.AreEqual("L", new ConvertInteirosRomanos("50").ConverterInteiroRomano());
            Assert.AreEqual("C", new ConvertInteirosRomanos("100").ConverterInteiroRomano());
            Assert.AreEqual("D", new ConvertInteirosRomanos("500").ConverterInteiroRomano());
            Assert.AreEqual("M", new ConvertInteirosRomanos("1000").ConverterInteiroRomano());
        }

        [TestMethod]
        public void ConverterNumeroInteiroComplexosEmNumeroRomano()
        {
            Assert.AreEqual("MCMIV", new ConvertInteirosRomanos("1904").ConverterInteiroRomano());
            Assert.AreEqual("MMDLXVIII", new ConvertInteirosRomanos("2568").ConverterInteiroRomano());
            Assert.AreEqual("CXXIII", new ConvertInteirosRomanos("123").ConverterInteiroRomano());
            Assert.AreEqual("MMMCMXCIX", new ConvertInteirosRomanos("3999").ConverterInteiroRomano());
        }

        [TestMethod]
        [ExpectedException(typeof(NumerosInteiroInvalidoExceptions))]
        public void ConverterNumeroInteiroNegativoCausaException()
        {
           new ConvertInteirosRomanos("-1").ConverterInteiroRomano();
        }

        #region O numero maximo permitido é 3999

        [TestMethod]
        [ExpectedException(typeof(NumerosInteiroInvalidoExceptions))]
        public void ConverterNumeroInteiroAcimaPermitidoCausaException()
        {
            new ConvertInteirosRomanos("4000").ConverterInteiroRomano();
        }
        
        #endregion


    }
}
