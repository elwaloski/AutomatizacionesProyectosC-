using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace Metodos
{
    public class NecesarioAutomatizacion
    {
        //static string Directorio = LeerParametros.RutaLecturaPath();
        //private static string serverPath = Directorio + @"\libs";
        //private static string RutaPortableChrome = Directorio + "\\ChromePortable\\App\\Chrome-bin\\chrome.exe";
        //private static string RutaDescargaChrome { get; set; } = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\descargas"));
        public static IWebDriver NavegadorChrome(string opciones = "")
        {
            try
            {
                ChromeOptions options = new ChromeOptions();
                //ChromeDriverService ServicioChrome = ChromeDriverService.CreateDefaultService(serverPath);
                ChromeOptions OpcionesChrome = new ChromeOptions();
                //OpcionesChrome.BinaryLocation = RutaPortableChrome;
                OpcionesChrome.AddArgument("--disable-extensions --disable-gpu --window-size=1920,1080 --start-maximized --enable-automation --disable-dev-shm-usage ");
                OpcionesChrome.AddUserProfilePreference("download.prompt_for_download", false);
                OpcionesChrome.AddUserProfilePreference("download.directory_upgrade", true);
                //OpcionesChrome.AddUserProfilePreference("download.default_directory", RutaDescargaChrome);
                OpcionesChrome.AddUserProfilePreference("profile.default_content_settings.popups", 0);
                OpcionesChrome.AddArguments("--safebrowsing-disable-download-protection");
                OpcionesChrome.AddArguments("safebrowsing-disable-extension-blacklist");

                if (!opciones.Equals(""))
                {
                    OpcionesChrome.AddArgument(opciones);
                }
                var dm = new DriverManager().SetUpDriver(new ChromeConfig());
                IWebDriver driver = new ChromeDriver(dm, OpcionesChrome);
                driver.Manage().Window.Maximize();
                return driver;
            }
            catch (WebDriverException ex)
            {
                Console.WriteLine(ex.Message + "Primera exception");
                return null;
            }
            catch (Exception ex2)
            {
                Console.WriteLine(ex2.Message + "Segunda exception");
                return null;
            }
        }
    }
}
