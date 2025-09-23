using NUnit.Framework;

namespace Metodos
{
    public  class Probar
    {
        [OneTimeSetUp]
        public void EjecutaAlInicio()
        {
            ConexionBD co = new ConexionBD();
            if (LeerParametros.LeeParamConfig())
            {
                co.RecuperaSucursal();
                CargaMTA.CargaMTADocumento("34");
                co.ConsultaDocumentos("33");
                co.TRAS_EVNT_ACCI();
                co.EliminaDTOControSE("52");
                co.TRAS_ACCI_S50();
                co.TRAS_EVNT_ACCI();

                string[] d = co.RecuperaDatosHolding();
                string holding =d[0];
                string codi_empr = d[1];
                string rutt_empr = d[2];
                string digi_empr = d[3];
                string nomb_empr = d[4];
            }
            else Assert.Fail("No funciono");
            try
            {
                UtilReporte.SetupReporte("Grilla_Rechazados", TestContext.CurrentContext.Test.ClassName);
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
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " Finaliza Reporte error ");
            }
        }

        [Test, Order(1), Retry(10)]
        public void IngresarLogin()
        {
            UtilReporte.CrearTestCase("Ingresar Login", "SE6.2");
            int contador = 1;
            try
            {
                String Usuario = LeerParametros.Usuario;

            }
            catch
            {
                if (contador == 1)
                {
                    contador = contador + 1;
                    ReporteTC.Error("Error en Inicio Sesion");
                    Assert.Fail("Error en Inicio Sesion");
                }
                else
                {
                    Assert.Fail("Error en Inicio Sesion");
                }
            }
        }
    }
}
