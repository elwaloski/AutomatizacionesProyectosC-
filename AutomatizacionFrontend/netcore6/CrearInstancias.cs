using OpenQA.Selenium;


namespace netcore6_GX
{
    public class CrearInstancias
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
        public void Crear_Instancias()
        {

            try
            {
                //(Comercio Industria,Seguro,Holding Bancario,Holding Seguro,Cajas Compensación,Entidades informantes,Bancos y Seguros)
                //Pantalla Docs Financieros
                /*FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "Comercio Industria", "Docs Financieros", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "Seguro", "Docs Financieros", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "Holding Bancario", "Docs Financieros", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "Holding Seguro", "Docs Financieros", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "Cajas Compensación", "Docs Financieros", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "Entidades informantes", "paDocs Financierosntalla", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "Bancos y Seguros", "Docs Financieros", CorrInst);*/

                //Taxonomia Circular 2275  nombreTaxo -->(cs-im-2024-08-27,cs-im-2020-03-15)
                //Pantalla Circular 2275
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "cs-im-2024-08-27", "Circular 2275", CorrInst);
                //FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "cs-im-2020-03-15", "Circular 2275", CorrInst);

                //pantalla --> Docs Fondos 
                //Taxonomia fondos nombreTaxo -->(cl-iv_20110430 , cl-fm_20110430 , cl-fi_20110430 , cl-fc_20110606 , cl-cp_20110822)
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "cl-iv_20110430", "Docs Fondos", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "cl-fm_20110430", "Docs Fondos", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "cl-fi_20110430", "Docs Fondos", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "cl-fc_20110606", "Docs Fondos", CorrInst);
                FuncionesWebs.CrearInstancia(driver, "Crear instancia ", "cl-cp_20110822", "Docs Fondos", CorrInst);

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