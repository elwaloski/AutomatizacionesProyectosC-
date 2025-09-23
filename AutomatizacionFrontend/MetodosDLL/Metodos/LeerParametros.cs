using NUnit.Framework;

namespace Metodos
{
    public class LeerParametros
    {

        public static string ArchivoConf = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\ComponentesNecesarios\config\configSE.CFG"));
        public static string RutaAltenativaConf = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\ComponentesNecesarios\config\configSE.CFG"));
        public static string RutaPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\ComponentesNecesarios"));
        public static string RutaAlternativaPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\ComponentesNecesarios"));
        public static string PSPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\ComponentesNecesarios\PSTools\PsExec.exe"));
        public static string RutaAltenativaPSPath = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\..\ComponentesNecesarios\PSTools\PsExec.exe"));

        public static string URLWEBSE62 = "";
        public static string Usuario = "";
        public static string Pass = "";
        public static string URLWSSTOKEN = "";
        public static string URLWSSAPI2020 = "";
        public static string IPCLOUD = "";
        public static string BasedatoCLOUD = "";
        public static string UsuarioCLOUD = "";
        public static string PassCLOUD = "";
        public static string ConexionCLOUD = "";
        public static string CodiEmpr = "";
        public static string RutEmpr = "";
        public static string CargaDesde = "";
        public static string CargaHasta = "";
        public static string RutRece = "";
        public static string DigiRece = "";


        public static string? UsuarioServidor { get; set; }
        public static string? PassServidor { get; set; }
        public static Boolean LeeParamConfig()
        {
            string Ruta = RutaLecturaConfig();

            try
            {
                if (File.Exists(Ruta))
                {
                    try
                    {
                        using (StreamReader file = new StreamReader(Ruta))
                        {
                            String? line;
                            while ((line = file.ReadLine()) != null)
                            {
                                if (line.StartsWith("-URLWEBSE62 "))
                                {
                                    URLWEBSE62 = line.Substring(12).Trim();
                                }
                                else if ((line.StartsWith("-Usuario ")))
                                {
                                    Usuario = line.Substring(9).Trim();
                                }
                                else if ((line.StartsWith("-URLWSSTOKEN ")))
                                {
                                    URLWSSTOKEN = line.Substring(13).Trim();
                                }
                                else if ((line.StartsWith("-URLWSSAPI2020 ")))
                                {
                                    URLWSSAPI2020 = line.Substring(15).Trim();
                                }
                                else if ((line.StartsWith("-Pass ")))
                                {
                                    Pass = line.Substring(6).Trim();
                                }
                                else if (line.StartsWith("-IPCLOUD "))
                                {
                                    IPCLOUD = line.Substring(9).Trim();
                                }
                                else if (line.StartsWith("-BasedatoCLOUD "))
                                {
                                    BasedatoCLOUD = line.Substring(15).Trim();
                                }
                                else if (line.StartsWith("-UsuarioCLOUD "))
                                {
                                    UsuarioCLOUD = line.Substring(14).Trim();
                                }
                                else if (line.StartsWith("-PassCLOUD "))
                                {
                                    PassCLOUD = line.Substring(11).Trim();
                                }
                                else if (line.StartsWith("-CodiEmpr "))
                                {
                                    CodiEmpr = line.Substring(10).Trim();
                                }
                                else if (line.StartsWith("-RutEmpr "))
                                {
                                    RutEmpr = line.Substring(9).Trim();
                                }
                                else if (line.StartsWith("-CargaDesde "))
                                {
                                    CargaDesde = line.Substring(12).Trim();
                                }
                                else if (line.StartsWith("-CargaHasta "))
                                {
                                    CargaHasta = line.Substring(12).Trim();
                                }
                                else if (line.StartsWith("-UsuarioServidor "))
                                {
                                    UsuarioServidor = line.Substring(17).Trim();
                                }
                                else if (line.StartsWith("-PassServidor "))
                                {
                                    PassServidor = line.Substring(14).Trim();
                                }
                                else if (line.StartsWith("-RutRece "))
                                {
                                    RutRece = line.Substring(9).Trim();
                                }
                                else if (line.StartsWith("-DigiRece "))
                                {
                                    DigiRece = line.Substring(10).Trim();
                                }
                            }
                        }
                        //SE
                        ConexionCLOUD = "data source =" + IPCLOUD + "; initial catalog = " + BasedatoCLOUD + "; user id = " + UsuarioCLOUD + "; password = " + PassCLOUD + ";MultipleActiveResultSets=true";
                        
                        if (CargaDesde == "") 
                        {
                            CargaDesde = "15000000";
                        }
                        if (CargaHasta == "")
                        {
                            CargaHasta = "15000100";
                        }
                        if (RutRece == "")
                        {
                            RutRece = "78079790";
                        }
                        if (DigiRece == "")
                        {
                            DigiRece = "8";
                        }

                        return true;
                    }
                    catch (Exception)
                    {
                        Assert.Fail("Archivo config.CFG no esta bien configurado");
                        return false;
                    }
                }
                else
                {
                    Assert.Fail("Directorio de configuracion no existe");
                    return false;
                }

            }
            catch (Exception)
            {
                Assert.Fail("Archivo de configuracion  no existe");
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

        public static string RutaLecturaPath()
        {
            if (Directory.Exists(RutaPath))
            {
                return RutaPath;
            }
            else if (Directory.Exists(RutaAlternativaPath))
            {
                return RutaAlternativaPath;
            }
            else
            {
                return "Directorio no existe ";
            }

        }
    }
}
