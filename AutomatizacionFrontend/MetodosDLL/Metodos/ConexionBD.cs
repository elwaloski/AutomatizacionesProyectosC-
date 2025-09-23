using System.Data;
using System.Data.SqlClient;

namespace Metodos
{
    public class ConexionBD
    {
        public SqlConnection ConectarBD = new SqlConnection();

        public ConexionBD()
        {
            LeerParametros.LeeParamConfig();
            ConectarBD.ConnectionString = LeerParametros.ConexionCLOUD;
        }

        public void abrirBD()
        {
            try
            {
                ConectarBD.Open();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Conexion ", ex.Message);
            }
        }

        public void CerraBD()
        {
            ConectarBD.Close();
        }

        public void EjecutarSql(string Query)
        {
            try
            {
                SqlCommand MiComando = new SqlCommand(Query, ConectarBD);
                MiComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error SQL de EjecutarSql: " + ex.Message);
            }
        }

        public string ConsultaDocumentos(string tipo_docu)
        {
            try
            {
                string Cantidad = "";
                string[] Datos = RecuperaDatosHolding();
                string Holding = Datos[0];
                int CodiEmpr = Int32.Parse(Datos[1]);
                LeerParametros.LeeParamConfig();
                int CargaDesde = Int32.Parse(LeerParametros.CargaDesde);
                int CargaHasta = Int32.Parse(LeerParametros.CargaHasta);
                string storedProcedure = "QA_COUNT_SELECT_DTE_ENCA_DOCU_HOLD";
                abrirBD();
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CODI_EMEX", Holding);
                command.Parameters.AddWithValue("@TIPO_DOCU", decimal.Parse(tipo_docu));
                command.Parameters.AddWithValue("@DOCU_DESD", CargaDesde);
                command.Parameters.AddWithValue("@DOCU_HASTA ", CargaHasta);
                command.Parameters.AddWithValue("@CODI_EMPR ", CodiEmpr);
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Cantidad = reader.GetInt32(0).ToString();
                }
                return Cantidad;
            }
            catch (Exception ex)
            {
                return "Error al consultar cantiadad de datos "+ex;
            }
        }

        public  string[] RecuperaDatosHolding()
        {
            string? Holding = "";
            string? codi_empr = "";
            string?  rutt_empr = "";
            string? digi_empr = "";
            string? nomb_empr = "";

            try
            {
                LeerParametros.LeeParamConfig();
                string Usuario = LeerParametros.Usuario;
                abrirBD();
                string storedProcedure = "QA_Recupera_Holding_CodiEmpr";
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CODI_USUA ", Usuario);
                SqlDataReader reader = command.ExecuteReader();
                
                if (reader.Read())
                {
                    Holding= reader.GetString(0);
                    codi_empr = reader.GetDecimal(1).ToString();
                }

                string storedProcedure2 = "QA_Recupera_Rut_Digi_nombre_EMPR";
                SqlCommand command2 = new SqlCommand(storedProcedure2, ConectarBD);
                command2.CommandType = CommandType.StoredProcedure;
                command2.Parameters.AddWithValue("@CODI_EMEX ", Holding);
                command2.Parameters.AddWithValue("@CODI_EMPR ", Int32.Parse(codi_empr));
                SqlDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read())
                {
                    rutt_empr = reader2.GetDecimal(0).ToString();
                    digi_empr = reader2.GetString(1);
                    nomb_empr = reader2.GetString(2);

                    string[] Datos = new string[] { Holding, codi_empr,rutt_empr, digi_empr, nomb_empr };
                    CerraBD();
                    return Datos;
                }
                CerraBD();
                throw new Exception("Este es un error generado a propósito");
            }
            catch (SqlException ex)
            {
                string[] Error = new string[] { "Error en recuperar Holding : " + ex.Message };
                return Error;
            }
        }

        public string[] RecuperaDatosToken()
        {
            string[] Datos = RecuperaDatosHolding();
            string holding = Datos[0];
            string Codi_empr = Datos[1];
            string rutt_empr = Datos[2];
            string iden_empr = "";
            string iden_auth = "";
            string pass_secu = "";
            try
            {
                LeerParametros.LeeParamConfig();
                string Usuario = LeerParametros.Usuario;
                abrirBD();
                string storedProcedure = "QA_Recupera_Datos_Token";
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@CODI_EMEX ", holding);
                command.Parameters.AddWithValue("@RUTT_EMPR ", rutt_empr);
                command.Parameters.AddWithValue("@CODI_EMPR ", Int32.Parse(Codi_empr));
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    iden_empr = reader.GetString(0);
                    iden_auth = reader.GetString(1);
                    pass_secu = reader.GetString(2);            
                    string[] DatosToken = new string[] { iden_empr, iden_auth, pass_secu };
                    CerraBD();
                    return DatosToken;
                }
                CerraBD();
                throw new Exception("Este es un error generado a propósito");
            }
            catch (SqlException ex)
            {
                string[] Error = new string[] { "Error en recuperar Holding : " + ex.Message };
                return Error;
            }
        }

        public string recupera_dato(string queryBDSQL)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(queryBDSQL, ConectarBD);
                var reader = cmd.ExecuteReader();
                string Dato = "";
                while (reader.Read())
                {
                    Dato = reader[0].ToString();
                }
                if (Dato == "")
                {
                    Dato = "0";
                    return Dato;
                }
                else
                {
                    return Dato;
                }

            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
                return "0";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error SQL: " + ex.Message);
                return "0";
            }
            finally
            {

            }
        }

        public string EliminaDTOControSE( string Tipo_docu)
        {
            try
            {
                LeerParametros.LeeParamConfig();
                int CargaDesde = Int32.Parse(LeerParametros.CargaDesde);
                int CargaHasta = Int32.Parse(LeerParametros.CargaHasta);
                string[] Datos = RecuperaDatosHolding();
                string rutt_empr = Datos[2];
                abrirBD();
                string storedProcedure = "QA_Eliminar_DTO_DTECONTROL";
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Iden_emis", rutt_empr);
                command.Parameters.AddWithValue("@Tipo_docu", Tipo_docu);
                command.Parameters.AddWithValue("@Desde", CargaDesde);
                command.Parameters.AddWithValue("@Hasta", CargaHasta);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.CommandTimeout = 120;
                return "Eliminacion de datos Correcta";
            }
            catch (SqlException ex)
            {
                return "Error en Eliminacion de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error en Eliminacion de datos: " + ex.Message;
            }
        }
        public string RecuperaSucursal()
        {
            try
            {                              
                string[] Datos = RecuperaDatosHolding();
                string CODI_EMEX = Datos[0];
                string rutt_pers = Datos[2];
                abrirBD();
                string storedProcedure = "QA_Recupera_Sucursal";
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@rutt_pers", rutt_pers);
                command.Parameters.AddWithValue("@CODI_EMEX", CODI_EMEX);                
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();

                var reader = command.ExecuteReader();
                string Dato = "";
                while (reader.Read())
                {
                    Dato = reader[0].ToString();
                }
                if (Dato == "")
                {
                    Dato = "0";
                    return Dato;
                }
                else
                {
                    return Dato;
                }            

            }
            catch (SqlException ex)
            {
                return "Error en Eliminacion de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error en Eliminacion de datos: " + ex.Message;
            }
        }
        public string TRAS_ACCI_S50()
        {
            try
            {
                abrirBD();
                string storedProcedure = "TRAS_ACCI_S50";
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.CommandTimeout = 120;
                return "TRAS_ACCI_S50 Ejecutado Correctamente";
            }
            catch (SqlException ex)
            {
                return "Error en ejecutar PRC TRAS_ACCI_S50: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error en ejecutar PRC TRAS_ACCI_S50: " + ex.Message;
            }
        }

        public string TRAS_EVNT_ACCI() //traspaso de SE62 a 52
        {
            try
            {
                abrirBD();
                string storedProcedure = "TRAS_EVNT_ACCI";
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.CommandTimeout = 120;
                return "TRAS_EVNT_ACCI Ejecutado Correctamente";
            }
            catch (SqlException ex)
            {
                return "Error en ejecutar PRC TRAS_EVNT_ACCI: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error en ejecutar PRC TRAS_EVNT_ACCI: " + ex.Message;
            }
        }

        public string CargaDocumentoEmision(string Tipo_docu)
        {
            try
            {
                LeerParametros.LeeParamConfig();
                int CargaDesde = Int32.Parse(LeerParametros.CargaDesde);
                int CargaHasta = Int32.Parse(LeerParametros.CargaHasta);
                int cantidad = CargaHasta - CargaDesde;
                string[] Datos = RecuperaDatosHolding();
                string holding = Datos[0];
                string Codi_empr = Datos[1];
                string rutt_empr = Datos[2];
                string Digi_empr = Datos[3];
                abrirBD();
                string storedProcedure = "QA_Carga_DocumentosDesde";
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Desde", CargaDesde);
                command.Parameters.AddWithValue("@CantidadCargar", cantidad);
                command.Parameters.AddWithValue("@Tipo_docu", Tipo_docu);
                command.Parameters.AddWithValue("@Holding", holding);
                command.Parameters.AddWithValue("@RutEmisor", rutt_empr);
                command.Parameters.AddWithValue("@digi", Digi_empr);
                command.Parameters.AddWithValue("@codi_empr", Codi_empr);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.CommandTimeout = 120;
                return "Carga de Documentos de Emision Correcta";
            }
            catch (SqlException ex)
            {
                return "Error en la Carga de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error en la Carga de datos: " + ex.Message;
            }
        }

        public string EliminaRangoDTE(string Tipo_docu)
        {
            try
            {
                LeerParametros.LeeParamConfig();
                int CargaDesde = Int32.Parse(LeerParametros.CargaDesde);
                int CargaHasta = Int32.Parse(LeerParametros.CargaHasta);
                string[] Datos = RecuperaDatosHolding();
                string holding = Datos[0];
                abrirBD();
                string storedProcedure = "QA_Eliminar_Rango_DTE";
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Holding", holding);
                command.Parameters.AddWithValue("@Tipo_docu", Tipo_docu);                
                command.Parameters.AddWithValue("@Desde", CargaDesde);
                command.Parameters.AddWithValue("@Hasta", CargaHasta);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.CommandTimeout = 120;
                return "Eliminacion  e Documentos de Emision Correcta";
            }
            catch (SqlException ex)
            {
                return "Error en la Eliminacion de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error en la Eliminacion de datos: " + ex.Message;
            }
        }
        public string EliminaRangoBEL(string Tipo_docu)
        {
            try
            {
                LeerParametros.LeeParamConfig();
                int CargaDesde = Int32.Parse(LeerParametros.CargaDesde);
                int CargaHasta = Int32.Parse(LeerParametros.CargaHasta);
                string[] Datos = RecuperaDatosHolding();
                string holding = Datos[0];
                abrirBD();
                string storedProcedure = "QA_Eliminar_Rango_BEL";
                SqlCommand command = new SqlCommand(storedProcedure, ConectarBD);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Holding", holding);
                command.Parameters.AddWithValue("@Tipo_docu", Tipo_docu);
                command.Parameters.AddWithValue("@Desde", CargaDesde);
                command.Parameters.AddWithValue("@Hasta", CargaHasta);
                command.CommandType = CommandType.StoredProcedure;
                command.ExecuteNonQuery();
                command.CommandTimeout = 120;
                return "Eliminacion  e Documentos de Emision Correcta";
            }
            catch (SqlException ex)
            {
                return "Error en la Eliminacion de datos: " + ex.Message;
            }
            catch (Exception ex)
            {
                return "Error en la Eliminacion de datos: " + ex.Message;
            }
        }
    }
}
