using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter.Configuration;
using OpenQA.Selenium;

namespace Metodos
{
    /// <summary>
    /// Funciones de utilidad para el Reporte de QA
    /// </summary>
    public class UtilReporte
    {
        private static string ExtReport { get; set; } = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\"));
        public static string raizReporte { get; set; } = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\"));
        private static string RutaDescargaChrome { get; set; } = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @".\"));
        public static string RutaImaReporte { get; set; } = crearDirectorios();
        public static string? DirectorioFechaUlti { get; set; }
        public static string? directorioCapturas { get; set; }
        private static string? reportePath { get; set; }
        private static string? reportePathFinal { get; set; }
        public static ExtentReports? extent;
        private static ExtentHtmlReporter? htmlReporter;
        private static string? ReportTitulo { get; set; } = "DBNet - Equipo Testing";
        private static string? NombreReporteIndex { get; set; }
        private static string? NombreReporteDashboard { get; set; }
        public static void SetupReporte(string Titulo, string DescClase)
        {
            try
            {
                raizReporte = RutaImaReporte;
                NombreReporteIndex = "ReporteQA_" + Titulo + "_" + string.Concat(DateTime.Now.ToString("yyyy-MM-dd"), ".html");
                htmlReporter = new ExtentHtmlReporter(raizReporte);
                htmlReporter.Config.Theme = Theme.Standard;
                htmlReporter.Config.EnableTimeline = false;
                htmlReporter.Config.DocumentTitle = Titulo;
                htmlReporter.Config.ReportName = "<font size=5>" + ReportTitulo + " </font> ";
                extent = new ExtentReports();
                extent.AttachReporter(htmlReporter);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " error ");
            }
        }
        public static void FinalizaReporte()
        {
            try
            {
                extent.Flush();
                CambiaHTML(raizReporte + "index.html", NombreReporteIndex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " error ");
            }
        }
        public static void CrearTestCase(string titulo, string descripcion)
        {
            ReporteTC.Reporte = extent.CreateTest(titulo);
        }

        private static void CambiaHTML(string p_archivo, string nombre_salida)
        {
            String line, line1;
            try
            {
                reportePath = raizReporte + nombre_salida;
                StreamReader sr = new StreamReader(p_archivo);
                StreamWriter outputFile = new StreamWriter(reportePath);

                line = sr.ReadLine();
                while (line != null)
                {
                    line1 = line.Replace("<a href=\"http://extentreports.relevantcodes.com\" class=\"brand-logo blue darken-3\">Extent</a>", "<a href =\"#\" class=\"brand-logo blue darken-3\">DBNeT</a>");
                    line = line1.Replace("Status</th>", "Estado</th>").Replace("Timestamp</th>", "Hora</th>").Replace("Details</th>", "Detalles</th>");
                    line1 = line.Replace("passed", "pasados").Replace("Status", "Estado").Replace("failed", "fallado").Replace("others", "otros");
                    line = line1.Replace("Fail", "Falla").Replace("Clear Filters", "Limpiar Filtros").Replace("step", "paso").Replace("Search", "Buscar").Replace("Pass", "Pasados");
                    line1 = line.Replace("Steps", "Pasos").Replace("Status", "Estado").Replace("failed", "fallado").Replace("others", "otros");
                    line = line1.Replace("Start", "Inicio").Replace("End", "Termino").Replace("Time Taken", "Duracion").Replace("index.html", NombreReporteIndex).Replace("dashboard.html", NombreReporteDashboard);
                    line1 = line.Replace("https://cdn.rawgit.com/extent-framework/extent-github-cdn/cd00a5e/spark/css/style.css", "../../../../libs/extent/style.css").Replace("https://cdn.rawgit.com/extent-framework/extent-github-cdn/f97b667/spark/js/script.js", "../../../../libs/extent/script.js").Replace("https://cdn.rawgit.com/extent-framework/extent-github-cdn/7cc78ce/spark/js/jsontree.js", "../../../../libs/extent/jsontree.js").Replace("https://cdn.rawgit.com/extent-framework/extent-github-cdn/d74480e/commons/img/logo.png", "../../../../libs/extent/logo.png").Replace("https://stackpath.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css", "../../../../libs/extent/css/font-awesome.min.css");
                    line = line1.Replace("Clear filters", "limpiar filtros").Replace("id='paso-filters'", "id='step-filters'");
                    outputFile.WriteLine(line);
                    line = sr.ReadLine();
                }

                outputFile.Close();
                sr.Close();
                File.Delete(p_archivo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " error ");
            }
            finally
            {

            }
        }

        private static string crearDirectorios()
        {

            try
            {
                string fechaHora = DateTime.Now.ToString("dd-MM-yyyy-HHmm-ss");
                DirectorioFechaUlti = fechaHora;
                string CarpetaSalida = ExtReport + @"Salidas\";
                Directory.CreateDirectory(RutaDescargaChrome + @"descargas");
                Directory.CreateDirectory(CarpetaSalida); //Raiz de reportes
                Directory.CreateDirectory(CarpetaSalida + fechaHora);//Directorio de la ejecución de la prueba
                directorioCapturas = CarpetaSalida + fechaHora + @"\capturas\";
                Directory.CreateDirectory(directorioCapturas);//directorio de capturas
                Directory.CreateDirectory(CarpetaSalida + fechaHora + @"\log");//directorio de log
                return ExtReport + @"Salidas\" + fechaHora + @"\";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " error ");
                return null;
            }
        }
        public static String screenshotretorno(IWebDriver driver, string NombreArchivo)
        {
            try
            {
                string paths = directorioCapturas;
                String fecha = DirectorioFechaUlti;
                if (!Directory.Exists(paths))
                    Directory.CreateDirectory(paths);
                String rutacompleta = (paths + NombreArchivo + fecha + ".png");
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile(rutacompleta);
                String RutaReporte = ".\\capturas\\" + NombreArchivo + fecha + ".png";

                return RutaReporte;
            }
            catch (Exception ex)
            {
                return "Error " + ex;
            }
        }

    }

    public class ReporteTC
    {

        public static ExtentTest Reporte;
        public static void Info(string Mensaje, string RutaScreenshot = "")
        {
            try
            {
                if (String.IsNullOrWhiteSpace(RutaScreenshot))
                {
                    Reporte.Info(Mensaje);
                }
                else
                {
                    Reporte.Info(Mensaje, MediaEntityBuilder.CreateScreenCaptureFromPath(RutaScreenshot, Mensaje).Build());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " error ");
            }
        }

        public static void Warning(string Mensaje, string RutaScreenshot = "")
        {
            try
            {
                if (String.IsNullOrWhiteSpace(RutaScreenshot))
                {
                    Reporte.Warning(Mensaje);
                }
                else
                {
                    Reporte.Warning(Mensaje, MediaEntityBuilder.CreateScreenCaptureFromPath(RutaScreenshot, Mensaje).Build());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " error ");
            }
        }
        public static void Error(string Mensaje, string RutaScreenshot = "")
        {
            try
            {
                if (String.IsNullOrWhiteSpace(RutaScreenshot))
                {
                    Reporte.Error(Mensaje);
                }
                else
                {
                    Reporte.Error(Mensaje, MediaEntityBuilder.CreateScreenCaptureFromPath(RutaScreenshot, Mensaje).Build());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " error ");
            }
        }


        public static void Pass(string Mensaje, string RutaScreenshot = "")
        {
            try
            {
                if (String.IsNullOrWhiteSpace(RutaScreenshot))
                {
                    Reporte.Pass(Mensaje);
                }
                else
                {
                    Reporte.Pass(Mensaje, MediaEntityBuilder.CreateScreenCaptureFromPath(RutaScreenshot, Mensaje).Build());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex + " error ");
            }
        }

    }
}
