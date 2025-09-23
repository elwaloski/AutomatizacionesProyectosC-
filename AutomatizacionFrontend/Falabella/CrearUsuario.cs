using EFTEC;
using Metodos;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using OpenQA.Selenium.Firefox;
using SeleniumUndetectedChromeDriver;
using System.IO;

namespace Tests
{
    public class Tests
    {
         IWebDriver driver;        
         String Correo ="";

        [OneTimeSetUp]
        public void EjecutaAlInicio()
        {            
            if (Clases.LeeParamConfig())
            {
                driver = Clases.NavegadorFirefox();
                String URLWEBSE62 = Clases.URLWEBSE62;
                driver.Navigate().GoToUrl(URLWEBSE62);
                UtilReporte.SetupReporte("Reporte Falabella", TestContext.CurrentContext.Test.ClassName);

            }
            else Assert.Fail("No funciono");
            try
            {
                UtilReporte.SetupReporte("Comprar y Comprarar", TestContext.CurrentContext.Test.ClassName);
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
                driver.Close();
                driver.Quit();
                driver.Dispose();
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " Finaliza Reporte error ");
            }
        }

        [Test, Order(1), Retry(10)]
        public void Registro()
        {
            Random rdn = new Random();
            int Random = rdn.Next(10000, 100000);
            String Mail="";
            Boolean Existe=false;
            Actions action = new Actions(driver);
            UtilReporte.CrearTestCase("Registro de Usuario", "Falabella");
            try
            {
                driver.FindElement(By.ClassName("dy-lb-close")).Click();
                //driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[1]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("//div[@id='testId-UserAction-userinfo']/div/div[2]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("testId-loggedout-item-1")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("testId-Input-firstName")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("testId-Input-firstName")).SendKeys("Marco");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("testId-Input-lastName")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("testId-Input-lastName")).SendKeys("Ominamiu");
                Thread.Sleep(3000);
                driver.FindElement(By.Id("testId-Input-document")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//div[@id='__next']/div/div/div")).Click();                
                Thread.Sleep(3000);
                string rut = RutChile.GeneraRut(1, 99999999);
                driver.FindElement(By.Id("testId-Input-document")).SendKeys(rut);
                Thread.Sleep(3000);
                driver.FindElement(By.Id("testId-Input-phoneNumber")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("testId-Input-phoneNumber")).SendKeys("77889944");
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//div[@id='__next']/div/div/div/div/div[2]/div[5]/div")).Click();
                Thread.Sleep(3000);

                Mail = "a.b.c.d@gmail.com";
                driver.FindElement(By.Id("testId-Input-email")).SendKeys(Mail);
                Thread.Sleep(3000);
                driver.FindElement(By.Id("__next")).Click();
                Thread.Sleep(3000);

                try
                {
                    Existe = driver.FindElement(By.CssSelector(".jsx-2017513839:nth-child(3)")).Displayed;
                    Thread.Sleep(1000);
                    Correo = driver.FindElement(By.CssSelector(".jsx-2017513839:nth-child(3)")).Text;
                    Thread.Sleep(1000);
                }
                catch
                {
                    Correo = "No existe";
                }
                
                Thread.Sleep(3000);

                while (Correo == "Este correo electrónico ya se encuentra registrado")
                {
                    driver.FindElement(By.Id("testId-Input-email")).Click();
                    Thread.Sleep(2000);
                    Teclas.Borrar(30, action);
                    Thread.Sleep(2000);
                    Mail = "a.b.c.d" + Random + "@gmail.com";
                    driver.FindElement(By.Id("testId-Input-email")).SendKeys(Mail);
                    Thread.Sleep(3000);
                    driver.FindElement(By.Id("__next")).Click();
                    Thread.Sleep(3000);                 

                    try
                    {
                        Existe =  driver.FindElement(By.CssSelector(".jsx-2017513839:nth-child(3)")).Displayed;
                        Correo = "Este correo electrónico ya se encuentra registrado";
                    }
                    catch
                    {
                        Correo = "No existe";
                    }

                }                                               

                driver.FindElement(By.Id("__next")).Click();
                Thread.Sleep(3000);
                string Passw = "Abel123*";
                driver.FindElement(By.Id("testId-Input-password")).SendKeys(Passw);
                Thread.Sleep(3000);

                Clases.EscribirUserPass(Mail, Passw);
                Thread.Sleep(3000);

                driver.FindElement(By.XPath("//div[@id='__next']/div/div/div")).Click();
                Thread.Sleep(3000);
                Teclas.Bajar(10, action);
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[1]/div[2]/div[8]/div/div[1]/label/span/p/span[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("/html/body/div[1]/div/div/div/div[1]/div[2]/div[8]/div/div[2]/label/span/p/span[1]")).Click();
                Thread.Sleep(3000);
                driver.FindElement(By.Id("testId-Button-submit")).Click();
                Thread.Sleep(3000);
                Teclas.Subir(15, action);
                String foto = UtilReporte.screenshotretorno(driver, "Usuario Creado Exitosamente");
                ReporteTC.Pass("Usuario Creado Exitosamente OK", foto);
                Thread.Sleep(10000);
            }
            catch(Exception ex)
            {
                String URLWEBSE62 = Clases.URLWEBSE62;
                driver.Navigate().GoToUrl(URLWEBSE62);
                Thread.Sleep(3000);
                ReporteTC.Error("Error en Crear Usuario");
                Assert.Fail("Error  en Crear Usuario" + ex);
            }

        }

        [Test, Order(2), Retry(10)]
        public void CerrarCesion()
        {
            try 
            { 
                Thread.Sleep(3000);
                driver.FindElement(By.XPath("//div[@id='testId-UserAction-userinfo']/div/div[2]")).Click();
                Thread.Sleep(2000);
                driver.FindElement(By.Id("testId-loggedin-action-item-0")).Click();
                Thread.Sleep(3000);
                String foto = UtilReporte.screenshotretorno(driver, "Cerrar Sesion");
                ReporteTC.Pass("Cerrar Sesion OK", foto);
            }
            catch
            {
                String URLWEBSE62 = Clases.URLWEBSE62;
                driver.Navigate().GoToUrl(URLWEBSE62);
                Thread.Sleep(2000);
                driver.FindElement(By.XPath("/html/body/div[4]/div[2]/div/div[1]")).Click();
                Thread.Sleep(3000);
                ReporteTC.Error("Error en Cerrar Sesion");
                Assert.Fail("Error en Cerrar Sesion");
            }
        }    

        public string ExisteComponente(Boolean IdComponente)
        {
            Boolean Existe = false;
            try
            {
                Existe = IdComponente;
                return "existe";
            }
            catch
            {
               return "No existe";
            }
        }
       
    }
}