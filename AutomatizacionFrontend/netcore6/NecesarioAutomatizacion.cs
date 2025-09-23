using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace netcore6_GX
{
    public class NecesarioAutomatizacion
    {

        static string Directorio = LeerJson.RutaLecturaPath();
        private static string RutaDescargaChrome { get; set; } = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\Descargas"));

        public static IWebDriver NavegadorChrome(string opcionesAdicionales = "")
        {
            try
            {
                ValidarRutas();
                // Configurar opciones de Chrome
                ChromeOptions opcionesChrome = ConfigurarOpciones(opcionesAdicionales);

                // Crear el navegador y devolverlo
                IWebDriver driver = new ChromeDriver( opcionesChrome);
                driver.Manage().Window.Maximize();
                return driver;
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine($"Error al inicializar el navegador Chrome: {ex.Message}");
                throw;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error inesperado: {ex.Message}");
                throw;
            }
        }

        private static ChromeOptions ConfigurarOpciones(string opcionesAdicionales)
        {
            var opcionesChrome = new ChromeOptions();

            // Configuración básica
            opcionesChrome.AddArguments(
                "--disable-extensions",
                "--disable-gpu",
                "--window-size=1920,1080",
                "--start-maximized",
                "--enable-automation",
                "--disable-dev-shm-usage",
                "--safebrowsing-disable-download-protection",
                "safebrowsing-disable-extension-blacklist"
            );

            // Configuración para descargas
            opcionesChrome.AddUserProfilePreference("download.directory_upgrade", true);
            opcionesChrome.AddUserProfilePreference("download.default_directory", RutaDescargaChrome);
            opcionesChrome.AddUserProfilePreference("profile.default_content_settings.popups", 0);

            // Agregar argumentos adicionales si se proporcionan
            if (!string.IsNullOrEmpty(opcionesAdicionales))
            {
                opcionesChrome.AddArgument(opcionesAdicionales);
            }

            return opcionesChrome;
        }

        private static void ValidarRutas()
        {
            if (!Directory.Exists(RutaDescargaChrome))
            {
                Directory.CreateDirectory(RutaDescargaChrome);
            }
        }
    }
}
