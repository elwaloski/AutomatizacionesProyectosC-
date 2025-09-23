using Metodos;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuiteElectronica62;

namespace EmisionDTE.Digitador
{
    internal class DigitadorDTE
    {
        IWebDriver driver;
        string foto;

        [OneTimeSetUp]
        public void EjecutaAlInicio()
        {
            if (LeerParametros.LeeParamConfig())
            {
                driver = NecesarioAutomatizacion.NavegadorChrome();
                string URLWEBSE62 = LeerParametros.URLWEBSE62;
                driver.Navigate().GoToUrl(URLWEBSE62);

                UtilReporte.SetupReporte("Reporte QA", TestContext.CurrentContext.Test.ClassName);

                try
                {
                    #region login
                    string usuario = LeerParametros.Usuario;
                    string pass = LeerParametros.Pass;

                    if (!Login.RealizarLogin(driver, usuario, pass))
                        throw new Exception("Error al realizar el login");

                    #endregion

                    #region Ir al digitador
                    driver.FindElement(By.LinkText("Emisión DTE")).Click();
                    Thread.Sleep(1500);
                    driver.FindElement(By.LinkText("Digitador")).Click();
                    Thread.Sleep(1500);
                    driver.FindElement(By.LinkText("Digitador DTE")).Click();
                    Thread.Sleep(1500);

                    //cambiar al frame del web52 (si, tiene dos)
                    driver.SwitchTo().Frame("targetframe");
                    driver.SwitchTo().Frame("monitor_frame");
                    string titManCaf = driver.FindElement(By.XPath("//span[@id='lbTitulo']")).Text;
                    if (titManCaf != "Ingreso Factura Manual Electrónica")
                    {
                        Assert.Fail("Error EjecutaAlInicio(): El texto de la pantalla es diferente de 'Ingreso Factura Manual Electrónica', Texto obtenido: " + titManCaf);
                    }
                    #endregion

                }
                catch (NoSuchElementException e)
                {
                    Assert.Fail("Error EjecutaAlInicio(): " + e.Message);
                }
                catch (WebDriverTimeoutException e)
                {
                    Assert.Fail("Error EjecutaAlInicio(): " + e.Message);
                }
            }
            else Assert.Fail("No funciono");
            try
            {
                UtilReporte.SetupReporte("Monitor_Acep_o_con_acuse", TestContext.CurrentContext.Test.ClassName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " Error inicializar WebDriver");
            }
        }

        [OneTimeTearDown]
        public void EjecutaAlFinal()
        {
            try
            {
                UtilReporte.FinalizaReporte();
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " Finaliza Reporte error ");
            }
        }


        [Test]
        [TestCase("REC-21321")]
        public void CargaIndividualExce_OKl(string tc)
        {
            driver.FindElement(By.XPath("//input[@id='btnMostrarPopup']")).Click();
            driver.FindElement(By.XPath("//input[@id='fileInput']")).SendKeys("C:\\Users\\daniel.cornejo\\Downloads\\CargaDigitadorGuíaClienteFinal.xlsx");
            driver.FindElement(By.XPath("//input[@id='btnCargar']")).Click();
        }
    }
}
