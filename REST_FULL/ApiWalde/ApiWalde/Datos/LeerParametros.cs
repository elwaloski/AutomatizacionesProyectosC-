using System.Data.SqlClient;
using System.IO;
using System;
using System.Data;

namespace ApiWalde.Datos
{
    public class LeerParametros
    {
        public static string ArchivoConfAPI = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Config\config.CFG"));

        public static string URLWEBSE62 = "";
        public static string Usuario = "";
        public static string Pass = "";
        public static string URLWSSTOKEN = "";
        public static string URLWSSAPI2020 = "";
        public static string IPCLOUD = "";
        public static string BasedatoCLOUD = "";
        public static string UsuarioCLOUD = "";
        public static string PassCLOUD = "";
        public static string Conexion = "";
        public static string CodiEmpr = "";
        public static string? UsuarioServidor { get; set; }
        public static string? PassServidor { get; set; }

        public static SqlConnection ConectarBD = new();

    public static void AbrirBD()
        {
            LeerParametros.LeeParamConfig();
            ConectarBD.ConnectionString = LeerParametros.Conexion;
            try
            {
                ConectarBD.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Conexion con BD", ex.Message);
            }
        }

        public static void CerraBD()
        {
            ConectarBD.Close();
        }

        public static string ConsultaExisteHolding(string codi_emex)
        {
            string sql = "QA_01_SELECT_1_EXISTE_PARA_EMPR_HOLD";
            try
            {
                AbrirBD();
                SqlCommand cmd = new(sql,ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codi_emex", codi_emex);
                cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();
                string Dato = "";
                while (reader.Read())
                {
                    Dato = reader.GetString(0);
                }
                if (Dato == "")
                {
                    return "NoExiste";
                }
                CerraBD();
                return "Existe";
            }
            catch (Exception )
            {
                CerraBD();
                return "Error";
            }
        }
        public static string ConsultaExisteEMPRHolding(string codi_emex,int codi_empr)
        {
            string sql = "QA_01_EXISTE_EMPR_HOLD";
            try
            {
                AbrirBD();
                SqlCommand cmd = new(sql, ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codi_emex", codi_emex);
                cmd.Parameters.AddWithValue("@codi_empr", codi_empr);
                cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();
                string Dato = "";
                while (reader.Read())
                {
                    Dato = reader.GetString(0);
                }
                if (Dato == "-1")
                {
                    return "NoExiste";
                }
                CerraBD();
                return "Existe";
            }
            catch (Exception)
            {
                CerraBD();
                return "Error";
            }
        }
        public static string ConsultarDatospara_empr_hold(string codi_emex, string codi_paem, int codi_empr)
        {
            string sql = "QA_01_SELECT_EXISTE_PARA_EMPR_HOLD";
            try
            {
                AbrirBD();
                SqlCommand cmd = new(sql, ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codi_emex", codi_emex);
                cmd.Parameters.AddWithValue("@codi_paem", codi_paem);
                cmd.Parameters.AddWithValue("@codi_empr", codi_empr);
                cmd.ExecuteNonQuery();
                var reader = cmd.ExecuteReader();
                string Dato = "";
                while (reader.Read())
                {
                    Dato = reader.GetString(0);
                }
                if (Dato == "-1")
                {
                    return "NoExiste";
                }
                CerraBD();
                return "Existe";
            }
            catch (Exception)
            {
                CerraBD();
                return "Error";
            }
        }
        public static void CarpetaRutaRelativa(string ruta) 
        {
            string carpetaRelativa = @ruta;
            string carpetaCompleta = Path.Combine(Environment.CurrentDirectory, carpetaRelativa);

            if (!Directory.Exists(carpetaCompleta))
            {
                Directory.CreateDirectory(carpetaCompleta);
            }
        }
        public static Boolean LeeParamConfig()
        {
            string Ruta = ArchivoConfAPI;
            CarpetaRutaRelativa("logs");
            CarpetaRutaRelativa("Config");
            try
            {
                if (File.Exists(Ruta))
                {
                    try
                    {
                        using (StreamReader file = new(Ruta))
                        {
                            String line;
                            while ((line = file.ReadLine()) != null)
                            {
                                if (line.StartsWith("-URLWEBSE62 "))
                                {
                                    URLWEBSE62 = line[12..].Trim();
                                }
                                else if ((line.StartsWith("-Usuario ")))
                                {
                                    Usuario = line[9..].Trim();
                                }
                                else if ((line.StartsWith("-URLWSSTOKEN ")))
                                {
                                    URLWSSTOKEN = line[13..].Trim();
                                }
                                else if ((line.StartsWith("-URLWSSAPI2020 ")))
                                {
                                    URLWSSAPI2020 = line[15..].Trim();
                                }
                                else if ((line.StartsWith("-Pass ")))
                                {
                                    Pass = line[6..].Trim();
                                }
                                else if (line.StartsWith("-IPCLOUD "))
                                {
                                    IPCLOUD = line[9..].Trim();
                                }
                                else if (line.StartsWith("-BasedatoCLOUD "))
                                {
                                    BasedatoCLOUD = line[15..].Trim();
                                }
                                else if (line.StartsWith("-UsuarioCLOUD "))
                                {
                                    UsuarioCLOUD = line[14..].Trim();
                                }
                                else if (line.StartsWith("-PassCLOUD "))
                                {
                                    PassCLOUD = line[11..].Trim();
                                }
                                else if (line.StartsWith("-CodiEmpr "))
                                {
                                    CodiEmpr = line[10..].Trim();
                                }
                                else if (line.StartsWith("-UsuarioServidor "))
                                {
                                    UsuarioServidor = line[17..].Trim();
                                }
                                else if (line.StartsWith("-PassServidor "))
                                {
                                    PassServidor = line[14..].Trim();
                                }
                            }
                        }
                        //SE
                        Conexion = "data source =" + IPCLOUD + "; initial catalog = " + BasedatoCLOUD + "; user id = " + UsuarioCLOUD + "; password = " + PassCLOUD + ";MultipleActiveResultSets=true";



                        return true;
                    }
                    catch (Exception)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}
