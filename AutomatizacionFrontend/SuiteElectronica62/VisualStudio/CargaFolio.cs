using Metodos;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SuiteElectronica62;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdminConfig
{
    public class CargaFolio
    {
        IWebDriver driver;
        string foto;

        [OneTimeSetUp]
        public void EjecutaAlInicio()
        {
            if (LeerParametros.LeeParamConfig())
            {
                driver = NecesarioAutomatizacion.NavegadorChrome();
                String URLWEBSE62 = LeerParametros.URLWEBSE62;
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

                    #region Mantenedor CAF
                    driver.FindElement(By.LinkText("Admin. Y Config.")).Click();
                    Thread.Sleep(3000);
                    driver.FindElement(By.LinkText("Administración")).Click();
                    Thread.Sleep(3000);
                    driver.FindElement(By.LinkText("Carga Folios (CAF)")).Click();
                    Thread.Sleep(3000);
                    string titManCaf = driver.FindElement(By.XPath("//h2[normalize-space()='Mantenedor CAF']")).Text;
                    if (titManCaf != "Mantenedor CAF")
                    {
                        Assert.Fail("Error EjecutaAlInicio(): El texto de la pantalla es diferente de Mantenedor CAF, Texto obtenido: " + titManCaf);
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
        [TestCase("REC-T1130", "SEM")]
        [TestCase("REC-T1131", "VAL")]
        [TestCase("REC-T1132", "DIG")]
        public void TC(string tc, string estadoCaf)
        {
            UtilReporte.CrearTestCase("CargaCAF: " + tc, "SE6.2");
            try
            {
                //Seleccionar estado CAF
                driver.FindElement(By.XPath("//button[@id='cargar-caf']")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//span[@aria-label='select']")).Click();
                Thread.Sleep(3000);
                var estados = driver.FindElements(By.XPath("//ul[@id='estadoCaf_listbox']//li"));
                foreach (var estado in estados)
                {
                    if(estado.Text == estadoCaf)
                    {
                        estado.Click();
                        break;
                    }
                }

                //Subir archivo xml
                string pathCaf = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"..\\..\\..\\data\\{estadoCaf}.xml"));
                driver.FindElement(By.XPath("//input[@id='uploadCAF']")).SendKeys(pathCaf);
                Thread.Sleep(300);
                driver.FindElement(By.XPath("//button[normalize-space()='Subir Archivo']")).Click();
                Thread.Sleep(3000);
                foto = UtilReporte.screenshotretorno(driver, $"res_car_caf_{tc}_");
                string respuesta = driver.FindElement(By.XPath("//div[@data-role='alert']")).Text;
                driver.FindElement(By.XPath("//div[@role='toolbar']//button")).Click();
                if (respuesta != "CAF Cargado exitosamente")
                {
                    ReporteTC.Error("Error al cargar CAF. Respuesta obtenida: " + respuesta, foto);
                    Assert.Fail("Error al cargar CAF. Respuesta obtenida: " + respuesta);
                }

                //Validar registro en la grilla
                var columnas = driver.FindElements(By.XPath("//div[@class='k-grid-content']//table[@role='grid']//tbody//tr[1]//td"));
                string colEstado = columnas[2].Text;
                if (colEstado != estadoCaf)
                {
                    ReporteTC.Error($"Error al cargar CAF. campo Estado no coincide, estado esperado: {estadoCaf}, estado obtenido: {colEstado}");
                    Assert.Fail($"Error al cargar CAF. campo Estado no coincide, estado esperado: {estadoCaf}, estado obtenido: {colEstado}");
                }
                ReporteTC.Pass("OK", foto);
            }
            catch(NoSuchElementException)
            {
                ReporteTC.Error("Error al cargar CAF");
                Assert.Fail("Error al cargar CAF");
            }
        }

    }
}