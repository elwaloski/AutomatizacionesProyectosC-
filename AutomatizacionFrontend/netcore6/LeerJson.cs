using Newtonsoft.Json;


namespace netcore6_GX
{
    
    public class LeerJson
    {
        public static string ArchivoConf = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"config.json"));
        public static string RutaAltenativaConf = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\config.json"));
        public static string RutaRaiz = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory));
        public static string URLWEB = "";
        public static string Usuario = "";
        public static string LoginPass = "";

        public static string EI = "";
        public static string CC = "";
        public static string CI = "";
        public static string HB = "";
        public static string HS = "";
        public static string CS = "";
        public static string BS = "";
        public static string FondosFM = "";
        public static string FondosFI = "";
        public static string Circular = "";
        public static string CambioEmpresa = "";
        public static string CrearParametros = "";
        public static string ConsultaConceptos = "";
        public static string NecesitoAyuda = "";
        public static string EditarInstancias = "";
        public static string MantenedorTextos = "";


        public static bool LeeParamConfig()
        {
            string Ruta = RutaLecturaConfig();
            try
            {
                if (File.Exists(Ruta))
                {
                    try
                    {
                        string jsonContent = File.ReadAllText(Ruta);
                        var config = JsonConvert.DeserializeObject<Configuracion>(jsonContent);

                        URLWEB = config.Sitio.URLWEB;
                        Usuario = config.Sitio.Usuario;
                        LoginPass = config.Sitio.LoginPass;

                        EI = config.Activar.EI;
                        CC = config.Activar.CC;
                        CI = config.Activar.CI;
                        HB = config.Activar.HB;
                        HS = config.Activar.HS;
                        CS = config.Activar.CS;
                        BS = config.Activar.BS;
                        FondosFM = config.Activar.FondosFM;
                        FondosFI = config.Activar.FondosFI;
                        Circular = config.Activar.Circular;
                        CambioEmpresa = config.Activar.CambioEmpresa;
                        CrearParametros = config.Activar.CrearParametros;
                        ConsultaConceptos = config.Activar.ConsultaConceptos;
                        NecesitoAyuda = config.Activar.NecesitoAyuda;
                        EditarInstancias = config.Activar.EditarInstancias;
                        MantenedorTextos = config.Activar.MantenedorTextos;

                        // Aquí puedes acceder a otros valores del JSON si es necesario

                        return true;
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail("Error al leer el archivo JSON: " + ex.Message);
                        return false;
                    }
                }
                else
                {
                    Assert.Fail("Directorio de configuración no existe");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Assert.Fail("Error al acceder al archivo de configuración: " + ex.Message);
                return false;
            }
        }

        public static string RutaLecturaConfig()
        {
            if (File.Exists(ArchivoConf))
            {
                return ArchivoConf;
            }
            else if (File.Exists(RutaAltenativaConf))
            {
                return RutaAltenativaConf;
            }
            else
            {
                return "No se encuentra el archivo ";
            }
        }       
    }
    public class Configuracion
    {
        public Sitio Sitio { get; set; }
        public Activar Activar { get; set; }
    }

    public class Sitio
    {
        public string URLWEB { get; set; }
        public string Usuario { get; set; }
        public string LoginPass { get; set; }
    }

    public class Activar
    {
        public string EI { get; set; }
        public string CC { get; set; }
        public string CI { get; set; }
        public string HB { get; set; }
        public string HS { get; set; }
        public string CS { get; set; }
        public string BS { get; set; }
        public string FondosFM { get; set; }
        public string FondosFI { get; set; }
        public string Circular { get; set; }
        public string CambioEmpresa { get; set; }
        public string CrearParametros { get; set; }
        public string ConsultaConceptos { get; set; }
        public string NecesitoAyuda { get; set; }
        public string EditarInstancias { get; set; }
        public string MantenedorTextos { get; set; }
    }
}
