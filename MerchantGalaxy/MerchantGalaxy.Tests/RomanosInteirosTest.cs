using System;
using MerchantGalaxy.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Util.Conversores;
using Util.Exceptions;

namespace MerchantGalaxy.Tests
{
    [TestClass]
    public class RomanosInteirosTest
    {
        [TestMethod]
        public void ConverterNumerosBasicosRomanosInteiro()
        {
            Assert.AreEqual(1, new ConvertRomanosInteiros("I").ConverterRomanoInteiro());
            Assert.AreEqual(5, new ConvertRomanosInteiros("V").ConverterRomanoInteiro());
            Assert.AreEqual(10, new ConvertRomanosInteiros("X").ConverterRomanoInteiro());
            Assert.AreEqual(50, new ConvertRomanosInteiros("L").ConverterRomanoInteiro());
            Assert.AreEqual(100, new ConvertRomanosInteiros("C").ConverterRomanoInteiro());
            Assert.AreEqual(500, new ConvertRomanosInteiros("D").ConverterRomanoInteiro());
            Assert.AreEqual(1000, new ConvertRomanosInteiros("M").ConverterRomanoInteiro());
        }

        [TestMethod]
        public void ConverterNumerosRepetidosRomanosInteiro()
        {
            Assert.AreEqual(3, new ConvertRomanosInteiros("III").ConverterRomanoInteiro());
            Assert.AreEqual(30, new ConvertRomanosInteiros("XXX").ConverterRomanoInteiro());
            Assert.AreEqual(300, new ConvertRomanosInteiros("CCC").ConverterRomanoInteiro());
            Assert.AreEqual(3000, new ConvertRomanosInteiros("MMM").ConverterRomanoInteiro()); ;
        }

        [TestMethod]
        public void ConverterSubtracaoNumeroRomanoInteiro()
        {

            Assert.AreEqual(4, new ConvertRomanosInteiros("IV").ConverterRomanoInteiro());
            Assert.AreEqual(9, new ConvertRomanosInteiros("IX").ConverterRomanoInteiro());
            Assert.AreEqual(40, new ConvertRomanosInteiros("XL").ConverterRomanoInteiro());
            Assert.AreEqual(90, new ConvertRomanosInteiros("XC").ConverterRomanoInteiro());
            Assert.AreEqual(400, new ConvertRomanosInteiros("CD").ConverterRomanoInteiro());
            Assert.AreEqual(900, new ConvertRomanosInteiros("CM").ConverterRomanoInteiro());
        }

        [TestMethod]
        public void ConverterAdicaoNumeroRomanoInteiro()
        {
            Assert.AreEqual(8, new ConvertRomanosInteiros("VIII").ConverterRomanoInteiro());
            Assert.AreEqual(13, new ConvertRomanosInteiros("XIII").ConverterRomanoInteiro());
            Assert.AreEqual(15, new ConvertRomanosInteiros("XV").ConverterRomanoInteiro());
            Assert.AreEqual(18, new ConvertRomanosInteiros("XVIII").ConverterRomanoInteiro());
        }

        #region "I" somente pode subtrair de "V" e "X".
        [TestMethod]
        public void SubtrairNumeroRomanoISomentePermitdos()
        {
            Assert.AreEqual(4, new ConvertRomanosInteiros("IV").ConverterRomanoInteiro());
            Assert.AreEqual(9, new ConvertRomanosInteiros("IX").ConverterRomanoInteiro());
        }
        #endregion

        #region "X" somente pode subtrair de "L" and "C".
        [TestMethod]
        public void SubtrairNumeroRomanoXSomentePermitdos()
        {
            Assert.AreEqual(40, new ConvertRomanosInteiros("XL").ConverterRomanoInteiro());
            Assert.AreEqual(90, new ConvertRomanosInteiros("XC").ConverterRomanoInteiro());

        }
        #endregion

        #region "C" somente pode subtrair de "D" and "M".
        [TestMethod]
        public void CorrectSubstractionsForC()
        {
            Assert.AreEqual(400, new ConvertRomanosInteiros("CD").ConverterRomanoInteiro());
            Assert.AreEqual(900, new ConvertRomanosInteiros("CM").ConverterRomanoInteiro());
        }
        #endregion

        #region "V", "L", e "D" numeros romanos que nunca podem subtrair.
        [TestMethod]
        public void NumerosRomanosVLDNaoPodemSubtrair()
        {

            bool subtrairComV = false;
            bool subtrairComL = false;
            bool subtrairComD = false;

            try
            {
                new ConvertRomanosInteiros("VX").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                subtrairComV = true;
            }
            try
            {
                new ConvertRomanosInteiros("LC").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                subtrairComL = true;
            }
            try
            {
                new ConvertRomanosInteiros("DM").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                subtrairComD = true;
            }

            Assert.IsTrue(subtrairComV);
            Assert.IsTrue(subtrairComL);
            Assert.IsTrue(subtrairComD);
        }
        #endregion

        #region "V", "L", e "D" não podem repetir.
        [TestMethod]
        public void NumerosRomanosVLDNaoPodemRepetir()
        {
            bool repetirComV = false;
            bool repetirComL = false;
            bool repetirComD = false;

            try
            {
                new ConvertRomanosInteiros("VV").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                repetirComV = true;
            }
            try
            {
                new ConvertRomanosInteiros("LL").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                repetirComL = true;
            }
            try
            {
                new ConvertRomanosInteiros("DD").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                repetirComD = true;
            }

            Assert.IsTrue(repetirComV);
            Assert.IsTrue(repetirComL);
            Assert.IsTrue(repetirComD);
        }
        #endregion

        #region "I", "X", "C", and "M" não poder repetir mais que três vezes.
        [TestMethod]
        public void NumerosRomanosIXCMNaoPodemRepetirMaisTresVezes()
        {
            bool repetirComIMais = false;
            bool repetirComXMais = false;
            bool repetirComCMais = false;
            bool repetirComMMais = false;

            try
            {
                new ConvertRomanosInteiros("IIII").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                repetirComIMais = true;
            }
            try
            {
                new ConvertRomanosInteiros("XXXX").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                repetirComXMais = true;
            }
            try
            {
                new ConvertRomanosInteiros("CCCC").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                repetirComCMais = true;
            }
            try
            {
                new ConvertRomanosInteiros("MMMM").ConverterRomanoInteiro();
            }
            catch (NumerosRomanoInvalidoExceptions)
            {
                repetirComMMais = true;
            }

            Assert.IsTrue(repetirComIMais);
            Assert.IsTrue(repetirComXMais);
            Assert.IsTrue(repetirComCMais);
            Assert.IsTrue(repetirComMMais);
        } 
        #endregion
    }
}
