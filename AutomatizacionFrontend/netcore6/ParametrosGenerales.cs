using OpenQA.Selenium;


namespace netcore6_GX
{
    public class ParametrosGenerales
    {
        IWebDriver driver;
        int CorrInst;


        [OneTimeSetUp]
        public void EjecutaAlInicio()
        {
            try
            {
                if (LeerJson.LeeParamConfig())
                {
                    driver = NecesarioAutomatizacion.NavegadorChrome();
                    string urlWebGx = LeerJson.URLWEB;
                    driver.Navigate().GoToUrl(urlWebGx);
                    // Configuración del reporte
                    //UtilReporte.SetupReporte("Reporte QA", TestContext.CurrentContext.Test.ClassName);
                }
                else
                {
                    Assert.Fail("No se pudo leer la configuración de parámetros.");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error al inicializar el WebDriver: {ex.Message}");
            }
        }

        [OneTimeTearDown]
        public void EjecutaAlFinal()
        {
            try
            {
                // Finaliza el reporte
                //UtilReporte.FinalizaReporte();

                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                }
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error al cerrar el WebDriver: {ex.Message}");
            }
        }

        [Test, Order(1), Retry(10)]
        public void IngresarLogin()
        {
            //UtilReporte.CrearTestCase("Ingresar Login", "GX");
            try
            {
                CorrInst = FuncionesWebs.IniciarSesion(driver);

            }
            catch (Exception ex)
            {
                Assert.Fail($"Error al iniciar sesión: {ex.Message}");
            }
        }

        [Test, Order(2), Retry(10)]
        public void ParametroGeneral()
        {
            string NombrePrueba = "Parametros Generales";

            try
            {
                //FuncionesWebs.BuscarinstanciaAccion(driver, "Comercio Industria 147", "VerInstancia");
                FuncionesWebs.ParametrosGenerales(driver, NombrePrueba);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error al resolver Parametros Generales: {ex.Message}");
            }
        }
        [Test, Order(100), Retry(10)]
        public void CerrarSesion()
        {
            //UtilReporte.CrearTestCase("Cerrar Sesion", "GX");
            try
            {
                FuncionesWebs.CerrarSesion(driver);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Error al iniciar sesión: {ex.Message}");
            }
        }
       // [SetUp]

    }
}