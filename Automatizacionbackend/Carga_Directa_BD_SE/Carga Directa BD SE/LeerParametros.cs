using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace Carga_Directa_BD_SE
{
    public class LeerParametros
    {
        public static string path_config = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @""));
        public static string IPORACLE = "";
        public static string PuertoORACLE = "";
        public static string ServicenameORACLE = "";
        public static string UsuarioORACLE = "";
        public static string PassORACLE = "";
        public static string IPSQL = "";
        public static string BasedatoSQL = "";
        public static string UsuarioSQL = "";
        public static string PassSQL = "";
        public static string IPCLOUD = "";
        public static string BasedatoCLOUD = "";
        public static string UsuarioCLOUD = "";
        public static string PassCLOUD = "";
        public static string IPCLOUDCF = "";
        public static string BasedatoCLOUDCF = "";
        public static string UsuarioCLOUDCF = "";
        public static string PassCLOUDCF = "";
        public static string IPORACLECF = "";
        public static string PuertoORACLECF = "";
        public static string ServicenameORACLECF = "";
        public static string UsuarioORACLECF = "";
        public static string PassORACLECF = "";
        public static string IPSQLCF = "";
        public static string BasedatoSQLCF = "";
        public static string UsuarioSQLCF = "";
        public static string PassSQLCF = "";
        public static string ConexionSQL = "";
        public static string ConexionCLOUD = "";
        public static string ConexionORACLE = "";
        public static string ConexionSQLCF = "";
        public static string ConexionCLOUDCF = "";
        public static string ConexionORACLECF = "";

        public static Boolean LeeParamConfig()
        {
            string ArchivoConf = path_config + @"\config\config.CFG";  //  ConfigLocal;

            try
            {
                if (File.Exists(ArchivoConf))
                {
                    try
                    {
                        using (StreamReader file = new StreamReader(ArchivoConf))
                        {
                            String line;
                            while ((line = file.ReadLine()) != null)
                            {
                                if (line.StartsWith("-IPORACLE "))
                                {
                                    IPORACLE = line.Substring(10).Trim();
                                }
                                else if (line.StartsWith("-PuertoORACLE "))
                                {
                                    PuertoORACLE = line.Substring(14).Trim();
                                }
                                else if (line.StartsWith("-ServicenameORACLE "))
                                {
                                    ServicenameORACLE = line.Substring(19).Trim();
                                }

                                else if (line.StartsWith("-UsuarioORACLE "))
                                {
                                    UsuarioORACLE = line.Substring(15).Trim();
                                }
                                else if (line.StartsWith("-PassORACLE "))
                                {
                                    PassORACLE = line.Substring(12).Trim();
                                }
                                else if (line.StartsWith("-IPSQL "))
                                {
                                    IPSQL = line.Substring(7).Trim();
                                }
                                else if (line.StartsWith("-BasedatoSQL "))
                                {
                                    BasedatoSQL = line.Substring(13).Trim();
                                }
                                else if (line.StartsWith("-UsuarioSQL "))
                                {
                                    UsuarioSQL = line.Substring(12).Trim();
                                }
                                else if (line.StartsWith("-PassSQL "))
                                {
                                    PassSQL = line.Substring(9).Trim();
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
                                else if (line.StartsWith("-IPCLOUDCF "))
                                {
                                    IPCLOUDCF = line.Substring(11).Trim();
                                }
                                else if (line.StartsWith("-BasedatoCLOUDCF "))
                                {
                                    BasedatoCLOUDCF = line.Substring(17).Trim();
                                }
                                else if (line.StartsWith("-UsuarioCLOUDCF "))
                                {
                                    UsuarioCLOUDCF = line.Substring(16).Trim();
                                }
                                else if (line.StartsWith("-PassCLOUDCF "))
                                {
                                    PassCLOUDCF = line.Substring(13).Trim();
                                }

                                else if (line.StartsWith("-IPORACLECF "))
                                {
                                    IPORACLECF = line.Substring(12).Trim();
                                }
                                else if (line.StartsWith("-PuertoORACLECF "))
                                {
                                    PuertoORACLECF = line.Substring(16).Trim();
                                }
                                else if (line.StartsWith("-ServicenameORACLECF "))
                                {
                                    ServicenameORACLECF = line.Substring(21).Trim();
                                }
                                else if (line.StartsWith("-UsuarioORACLECF "))
                                {
                                    UsuarioORACLECF = line.Substring(17).Trim();
                                }
                                else if (line.StartsWith("-PassORACLECF "))
                                {
                                    PassORACLECF = line.Substring(14).Trim();
                                }


                                else if (line.StartsWith("-IPSQLCF "))
                                {
                                    IPSQLCF = line.Substring(9).Trim();
                                }
                                else if (line.StartsWith("-BasedatoSQLCF "))
                                {
                                    BasedatoSQLCF = line.Substring(15).Trim();
                                }
                                else if (line.StartsWith("-UsuarioSQLCF "))
                                {
                                    UsuarioSQLCF = line.Substring(14).Trim();
                                }
                                else if (line.StartsWith("-PassSQLCF "))
                                {
                                    PassSQLCF = line.Substring(11).Trim();
                                }
                            }

                        }
                        //SE
                        ConexionSQL = "data source =" + IPSQL + "; initial catalog = " + BasedatoSQL + "; user id =" + UsuarioSQL + "; password =" + PassSQL + ";MultipleActiveResultSets=true";
                        ConexionCLOUD = "data source =" + IPCLOUD + "; initial catalog = " + BasedatoCLOUD + "; user id = " + UsuarioCLOUD + "; password = " + PassCLOUD + ";MultipleActiveResultSets=true";
                        ConexionORACLE = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=" +
                        IPORACLE + ")(Port=" + PuertoORACLE + ")))(CONNECT_DATA=(SERVICE_NAME=" +
                        ServicenameORACLE + "))); User Id=" + UsuarioORACLE + ";Password=" + PassORACLE + ";";

                        //CF
                        ConexionSQLCF = "data source =" + IPSQLCF + "; initial catalog = " + BasedatoSQLCF + "; user id =" + UsuarioSQLCF + "; password =" + PassSQLCF + ";MultipleActiveResultSets=true";
                        ConexionCLOUDCF = "data source =" + IPCLOUDCF + "; initial catalog = " + BasedatoCLOUDCF + "; user id = " + UsuarioCLOUDCF + "; password = " + PassCLOUDCF + ";MultipleActiveResultSets=true";
                        ConexionORACLECF = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(Host=" +
                        IPORACLECF + ")(Port=" + PuertoORACLECF + ")))(CONNECT_DATA=(SERVICE_NAME=" +
                        ServicenameORACLECF + "))); User Id=" + UsuarioORACLECF + ";Password=" + PassORACLECF + ";";
                        return true;
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Archivo esta vacio");
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Directorio de configuracion no existe");
                    return false;
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Archivo de configuracion  no existe");
                return false;
            }
        }
    }
}
