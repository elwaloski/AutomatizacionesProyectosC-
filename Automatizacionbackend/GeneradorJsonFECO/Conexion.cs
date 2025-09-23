using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeneradorJsonFECO
{
    class Conexion
    {
        private SqlConnection conectarBd = new SqlConnection();
        private string[] holding;

        #region Metodos de Conexion a BD
        public Conexion()
        {
            try
            {
                string[] parametros = LeerArchivoConfig();
                string cadenaConexion = "Data Source = " + parametros[0] + "; Initial Catalog = " + parametros[1] + "; User ID = " + parametros[2] + "; Password=" + parametros[3];
                conectarBd.ConnectionString = cadenaConexion;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error Conexion: " + e.Message);
            }
        }
        
        public string[] LeerArchivoConfig()
        {
            try
            {
                string path = System.IO.Directory.GetCurrentDirectory();
                if (!System.IO.Directory.Exists(path + "\\config"))
                {
                    System.IO.Directory.CreateDirectory(path + "\\config");
                    Console.WriteLine("Se crea directorio de configuración");
                }
                string config = System.IO.File.ReadAllText(path + "\\config\\config.cfg");
                string[] parametros = config.Split('\n');
                parametros[0] = parametros[0].Substring(7).Trim();
                parametros[1] = parametros[1].Substring(7).Trim();
                parametros[2] = parametros[2].Substring(10).Trim();
                parametros[3] = parametros[3].Substring(10).Trim();
                holding = parametros[4].Substring(9).Split(';');

                return parametros;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error LeerArchivoConfig: " +e.Message);
                return null;
            }
        }

        private SqlConnection AbrirConexion()
        {
            try
            {
                conectarBd.Open();
                Console.WriteLine("Conexion BD abierta");
                return conectarBd;

            }
            catch (Exception e)
            {
                Console.WriteLine("Error al abrir conexion: " + e.Message);
                return null;
            }
        }

        private void CerrarConexion()
        {
            try
            {
                conectarBd.Close();
                Console.WriteLine("Conexion a BD Cerrada");
            }
            catch(Exception e)
            {
                Console.WriteLine("Error Cerrar Conexion: " + e.Message);
            }
        }

        #endregion

        public ArrayList RescatarEmpresasEmisoras()
        {
            try
            {
                string condicion = "";

                for(int i=0; i < holding.Count(); i++)
                {
                    condicion += "'" + holding[i] + "',";
                }


                ArrayList empresas = new ArrayList();

                string sql = "Select DISTINCT empr.rutt_empr,empr.nomb_empr , empr.corr_empr FROM SIST_UREH_ACCE ureh, SIST_EMPR_ACCE empr WHERE ureh.RUTT_EMPR = empr.RUTT_EMPR AND ureh.rutt_usua = 22222222 AND ureh.codi_hold in (" + condicion.TrimEnd(',') + ") order by empr.corr_empr";

                SqlCommand cmd = new SqlCommand(sql, AbrirConexion());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            Console.WriteLine("NO HAY EMPRESA CONFIGURADA");
                        }
                        else
                        {
                            empresas.Add(reader.GetValue(0) + " - " + reader.GetString(1));
                        }
                    }
                }

                CerrarConexion();

                return empresas;
            }
            catch(Exception e)
            {
                Console.WriteLine("Error RescatarEmpresasEmisoras: " + e.Message );
                return null;
            }

        }

        public ArrayList RescatarAreaFactura(string rutEmpresa)
        {
            try
            {
                ArrayList areas = new ArrayList();

                string sql = "select codi_area from dte_area_factura where iden_empr = '" + rutEmpresa + "'";

                SqlCommand cmd = new SqlCommand(sql, AbrirConexion());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            Console.WriteLine("NO HAY EMPRESA CONFIGURADA");
                        }
                        else
                        {
                            areas.Add(reader.GetValue(0));
                        }
                    }
                }

                CerrarConexion();

                return areas;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error RescatarAreasFactura: " + e.Message);
                return null;
            }

        }

        public ArrayList RescatarPrefijo(string rutEmpresa, string tipoDocu)
        {
            try
            {
                ArrayList prefijos = new ArrayList();

                string sql = "select distinct pref_docu from dte_rango_area where iden_empr = " + rutEmpresa +  "and tipo_docu = '" + tipoDocu + "'";

                SqlCommand cmd = new SqlCommand(sql, AbrirConexion());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            Console.WriteLine("NO HAY EMPRESA CONFIGURADA");
                        }
                        else
                        {
                            prefijos.Add(reader.GetValue(0));
                        }
                    }
                }

                CerrarConexion();

                return prefijos;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error RescatarPrefijo: " + e.Message);
                return null;
            }

        }

        public int RescatarCorrCont(string tipoDocu, int numeDocu)
        {
            try
            {
                int corrCont = 0;
                string sql = "select corr_cont from dte_control where nume_docu = '" + numeDocu + "' and tipo_docu = '" + tipoDocu + "'";

                SqlCommand cmd = new SqlCommand(sql, AbrirConexion());
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader.IsDBNull(0))
                        {
                            Console.WriteLine("NO SE RECUPERA CORR_CONT");
                        }
                        else
                        {
                            corrCont = reader.GetInt16(0);
                            //Console.WriteLine("IEQUI DEL EQUIPO: " + iequi);
                        }
                    }
                }

                CerrarConexion();
                return corrCont;
            }
            catch(Exception e)
            {
                Console.WriteLine("ERROR RescatarCorrCont: " + e.Message);
                CerrarConexion();
                return 0;
            }

        }

        public int CargaDocBD(EstructuraJson.InfoDoc infoDoc)
        {
            try
            {
                
                int corrCont = 0;
                int val = 0;
                
                string insertDteControl = "INSERT INTO DTE_CONTROL (TIPO_OPER, TIPO_DOCU, PREF_DOCU, NUME_DOCU, FECH_EMIS, HORA_EMIS, TIPO_FACT, MONE_DOCU," +
                            "TIPO_EMIS, IDEN_EMIS, DIGI_EMIS, RAZO_EMIS,TIPO_RECE, IDEN_RECE, DIGI_RECE, RAZO_RECE, TOTA_BRUT, TOTA_DESC, TOTA_CARG," +
                            "TOTA_IMPO, TOTA_ANTI, MONT_TOTA, NCOM_EMIS, ESTA_DOCU,TIPO_UBL,TIPO_CARG)" +
                            "VALUES('EMI', '" + infoDoc.TipoDocumento + "', 'SETP'," + infoDoc.Correlativo + ", '2020-11-04', '09:07:10', '01', 'COP', '31', '900918004', '5', 'DBNeT SAS', '12', " +
                            "'900918004', '0', 'V Q INGENIERIA SOCIEDAD POR ACCIONES SIMPLIFICADA S.A.S.', '1500000.00', '0.00', '0.00', '1500000.00', null," +
                            "'1785000.00', 'DBNeT SAS', 'Registrado', '21', 'N')";

                SqlCommand cmd = new SqlCommand(insertDteControl, AbrirConexion());
                val = cmd.ExecuteNonQuery();
                CerrarConexion();

                if (val > 0)
                {
                    Console.WriteLine("DTE_CONTROL insertada");
                    corrCont = RescatarCorrCont(infoDoc.TipoDocumento, int.Parse(infoDoc.Correlativo));

                    if (corrCont > 0)
                    {
                        string insertDteDocuImpu = "INSERT INTO DTE_DOCU_IMPU(CORR_CONT, NUME_LINE, MONE_IMPU, TOTA_IMPU, INDI_IMPU, BASE_IMPU, PORC_IMPU, NUME_IMPU)" +
                                            "VALUES(" + corrCont + ", '1', 'COP', '285000.00', 'false', '1500000.00', '19.00', '01')" +

                                            "INSERT INTO DTE_DOCU_IMPU (CORR_CONT, NUME_LINE, MONE_IMPU, TOTA_IMPU, INDI_IMPU, BASE_IMPU, PORC_IMPU, NUME_IMPU)" +
                                            "VALUES(" + corrCont + ", '2', 'COP', '42750.00', 'true', '285000.00', '15.00', '05')";

                        cmd = new SqlCommand(insertDteDocuImpu, AbrirConexion());
                        cmd.ExecuteNonQuery();
                        CerrarConexion();

                        string insertDteDocuPago = "INSERT INTO DTE_DOCU_PAGO (CORR_CONT, NUME_LINE, CODI_PAGO, MEDI_PAGO) VALUES (" + corrCont + ", '1', '1', '10')";

                        cmd = new SqlCommand(insertDteDocuPago, AbrirConexion());
                        cmd.ExecuteNonQuery();
                        CerrarConexion();

                        string insertDteCntt = "INSERT INTO DTE_DOCU_CNTT (CORR_CONT, MAIL_TO, MAIL_CC, MAIL_BCC, MAIL_TIPO) " +
                                                "VALUES (" + corrCont + ", 'waldogonzalez@mt5.dbnetcorp.com', null, null, 'SEND_FACT_EMIT')";

                        cmd = new SqlCommand(insertDteCntt, AbrirConexion());
                        cmd.ExecuteNonQuery();
                        CerrarConexion();

                        string insertDteDocuXlobXml = "INSERT INTO DTE_DOCU_XLOB(CORR_CONT, TIPO_ARCH, CLOB_ARCH) VALUES(" + corrCont + ", 'XML', 'PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+PElu dm9pY2UgeG1sbnM9InVybjpvYXNpczpuYW1lczpzcGVjaWZpY2F0aW9uOnVibDpzY2hlbWE6eHNk Okludm9pY2UtMiIgeG1sbnM6Y2FjPSJ1cm46b2FzaXM6bmFtZXM6c3BlY2lmaWNhdGlvbjp1Ymw6 c2NoZW1hOnhzZDpDb21tb25BZ2dyZWdhdGVDb21wb25lbnRzLTIiIHhtbG5zOmNiYz0idXJuOm9h c2lzOm5hbWVzOnNwZWNpZmljYXRpb246dWJsOnNjaGVtYTp4c2Q6Q29tbW9uQmFzaWNDb21wb25l bnRzLTIiIHhtbG5zOmRzPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwLzA5L3htbGRzaWcjIiB4bWxu czpleHQ9InVybjpvYXNpczpuYW1lczpzcGVjaWZpY2F0aW9uOnVibDpzY2hlbWE6eHNkOkNvbW1v bkV4dGVuc2lvbkNvbXBvbmVudHMtMiIgeG1sbnM6b3RoPSJodHRwOi8vZXhhbXBsZS5vcmcvb3Ro IiB4bWxuczpzdHM9ImRpYW46Z292OmNvOmZhY3R1cmFlbGVjdHJvbmljYTpTdHJ1Y3R1cmVzLTIt MSIgeG1sbnM6eGFkZXM9Imh0dHA6Ly91cmkuZXRzaS5vcmcvMDE5MDMvdjEuMy4yIyIgeG1sbnM6 eGFkZXMxNDE9Imh0dHA6Ly91cmkuZXRzaS5vcmcvMDE5MDMvdjEuNC4xIyIgeG1sbnM6eHNpPSJo dHRwOi8vd3d3LnczLm9yZy8yMDAxL1hNTFNjaGVtYS1pbnN0YW5jZSIgeHNpOnNjaGVtYUxvY2F0 aW9uPSJ1cm46b2FzaXM6bmFtZXM6c3BlY2lmaWNhdGlvbjp1Ymw6c2NoZW1hOnhzZDpJbnZvaWNl LTIgaHR0cDovL2RvY3Mub2FzaXMtb3Blbi5vcmcvdWJsL29zLVVCTC0yLjEveHNkL21haW5kb2Mv VUJMLUludm9pY2UtMi4xLnhzZCI+DQo8ZXh0OlVCTEV4dGVuc2lvbnM+DQo8ZXh0OlVCTEV4dGVu c2lvbj4NCjxleHQ6RXh0ZW5zaW9uQ29udGVudD4NCjxzdHM6RGlhbkV4dGVuc2lvbnM+DQo8c3Rz Okludm9pY2VDb250cm9sPjxzdHM6SW52b2ljZUF1dGhvcml6YXRpb24+MTg3NjAwMDAwMDE8L3N0 czpJbnZvaWNlQXV0aG9yaXphdGlvbj4gIDxzdHM6QXV0aG9yaXphdGlvblBlcmlvZD4gIDxjYmM6 U3RhcnREYXRlPjIwMTktMDEtMTk8L2NiYzpTdGFydERhdGU+ICA8Y2JjOkVuZERhdGU+MjAzMC0w MS0xOTwvY2JjOkVuZERhdGU+ICA8L3N0czpBdXRob3JpemF0aW9uUGVyaW9kPiAgPHN0czpBdXRo b3JpemVkSW52b2ljZXM+ICA8c3RzOlByZWZpeD5TRVRQPC9zdHM6UHJlZml4PiAgPHN0czpGcm9t Pjk5MDAwMDAwMDwvc3RzOkZyb20+ICA8c3RzOlRvPjk5NTAwMDAwMDwvc3RzOlRvPiAgPC9zdHM6 QXV0aG9yaXplZEludm9pY2VzPiAgPC9zdHM6SW52b2ljZUNvbnRyb2w+ICA8c3RzOkludm9pY2VT b3VyY2U+ICA8Y2JjOklkZW50aWZpY2F0aW9uQ29kZSBsaXN0QWdlbmN5SUQ9IjYiIGxpc3RBZ2Vu Y3lOYW1lPSJVbml0ZWQgTmF0aW9ucyBFY29ub21pYyBDb21taXNzaW9uIGZvciBFdXJvcGUiIGxp c3RTY2hlbWVVUkk9InVybjpvYXNpczpuYW1lczpzcGVjaWZpY2F0aW9uOnVibDpjb2RlbGlzdDpn YzpDb3VudHJ5SWRlbnRpZmljYXRpb25Db2RlLTIuMSI+Q088L2NiYzpJZGVudGlmaWNhdGlvbkNv ZGU+PC9zdHM6SW52b2ljZVNvdXJjZT48c3RzOlNvZnR3YXJlUHJvdmlkZXI+DQo8c3RzOlByb3Zp ZGVySUQgc2NoZW1lQWdlbmN5SUQ9IjE5NSIgc2NoZW1lQWdlbmN5TmFtZT0iQ08sIERJQU4gKERp cmVjY2nDg8KzbiBkZSBJbXB1ZXN0b3MgeSBBZHVhbmFzIE5hY2lvbmFsZXMpIiBzY2hlbWVJRD0i NSIgc2NoZW1lTmFtZT0iMzEiPjkwMDkxODAwNDwvc3RzOlByb3ZpZGVySUQ+DQo8c3RzOlNvZnR3 YXJlSUQgc2NoZW1lQWdlbmN5SUQ9IjE5NSIgc2NoZW1lQWdlbmN5TmFtZT0iQ08sIERJQU4gKERp cmVjY2nDg8KzbiBkZSBJbXB1ZXN0b3MgeSBBZHVhbmFzIE5hY2lvbmFsZXMpIj41NTVlNzUwZS1k OWMwLTQ5ODAtYWE0Mi05NDhhMjI3YmVmZjU8L3N0czpTb2Z0d2FyZUlEPg0KPC9zdHM6U29mdHdh cmVQcm92aWRlcj4NCjxzdHM6U29mdHdhcmVTZWN1cml0eUNvZGUgc2NoZW1lQWdlbmN5SUQ9IjE5 NSIgc2NoZW1lQWdlbmN5TmFtZT0iQ08sIERJQU4gKERpcmVjY2nDg8KzbiBkZSBJbXB1ZXN0b3Mg eSBBZHVhbmFzIE5hY2lvbmFsZXMpIj5kY2ZlNDMxZTZlYmQ0YjBkNTZiYzNlYzUxYjk1OGIyYzZk OGZjNWYwODQ4OTk0NjkzNzA4YTFiZWU0MzQ3ZmU4NDkzMDk4MWMyMTI3ZjE1Y2E5Y2I1MzI4NDA4 NjUyMTY8L3N0czpTb2Z0d2FyZVNlY3VyaXR5Q29kZT4NCjxzdHM6QXV0aG9yaXphdGlvblByb3Zp ZGVyPg0KPHN0czpBdXRob3JpemF0aW9uUHJvdmlkZXJJRCBzY2hlbWVBZ2VuY3lJRD0iMTk1IiBz Y2hlbWVBZ2VuY3lOYW1lPSJDTywgRElBTiAoRGlyZWNjacODwrNuIGRlIEltcHVlc3RvcyB5IEFk dWFuYXMgTmFjaW9uYWxlcykiIHNjaGVtZUlEPSI0IiBzY2hlbWVOYW1lPSIzMSI+ODAwMTk3MjY4 PC9zdHM6QXV0aG9yaXphdGlvblByb3ZpZGVySUQ+IA0KPC9zdHM6QXV0aG9yaXphdGlvblByb3Zp ZGVyPjxzdHM6UVJDb2RlPmh0dHBzOi8vY2F0YWxvZ28tdnBmZS1oYWIuZGlhbi5nb3YuY28vZG9j dW1lbnQvc2VhcmNocXI/ZG9jdW1lbnRrZXk9MWYxZjM5ZGYxODM5MzM1YTY5NGI3YmE0YWE0NmIw NTA0ZmM3MDRiODQyYjE2Yjk2NTAyNzlkZjQ1ZWM5ZTYyMjM2ZjY5MjA3ZmVmNjEzNWE4ZjVlOGIy MjViOTUyZTBlPC9zdHM6UVJDb2RlPjwvc3RzOkRpYW5FeHRlbnNpb25zPg0KPC9leHQ6RXh0ZW5z aW9uQ29udGVudD4NCjwvZXh0OlVCTEV4dGVuc2lvbj4NCjxleHQ6VUJMRXh0ZW5zaW9uPg0KPGV4 dDpFeHRlbnNpb25Db250ZW50Pg0KPGRzOlNpZ25hdHVyZSBJZD0ieG1sZHNpZy0xZDI2MDYxMC1l M2M4LTRmOTYtODFlMC1hOTM3YmYyMjE2YzciPjxkczpTaWduZWRJbmZvPjxkczpDYW5vbmljYWxp emF0aW9uTWV0aG9kIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvVFIvMjAwMS9SRUMteG1s LWMxNG4tMjAwMTAzMTUiLz48ZHM6U2lnbmF0dXJlTWV0aG9kIEFsZ29yaXRobT0iaHR0cDovL3d3 dy53My5vcmcvMjAwMS8wNC94bWxkc2lnLW1vcmUjcnNhLXNoYTI1NiIvPjxkczpSZWZlcmVuY2Ug SWQ9InhtbGRzaWctMWQyNjA2MTAtZTNjOC00Zjk2LTgxZTAtYTkzN2JmMjIxNmM3LXJlZjAiIFVS ST0iIj48ZHM6VHJhbnNmb3Jtcz48ZHM6VHJhbnNmb3JtIEFsZ29yaXRobT0iaHR0cDovL3d3dy53 My5vcmcvMjAwMC8wOS94bWxkc2lnI2VudmVsb3BlZC1zaWduYXR1cmUiLz48L2RzOlRyYW5zZm9y bXM+PGRzOkRpZ2VzdE1ldGhvZCBBbGdvcml0aG09Imh0dHA6Ly93d3cudzMub3JnLzIwMDEvMDQv eG1sZW5jI3NoYTI1NiIvPjxkczpEaWdlc3RWYWx1ZT5ScDlnTm5YUTJKKyt1NlVjdDZYankrZGpC ZWpNbkVFNk9NZWJnY2RlZUxjPTwvZHM6RGlnZXN0VmFsdWU+PC9kczpSZWZlcmVuY2U+PGRzOlJl ZmVyZW5jZSBVUkk9IiN4bWxkc2lnLTFkMjYwNjEwLWUzYzgtNGY5Ni04MWUwLWE5MzdiZjIyMTZj Ny1rZXlpbmZvIj48ZHM6RGlnZXN0TWV0aG9kIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcv MjAwMS8wNC94bWxlbmMjc2hhMjU2Ii8+PGRzOkRpZ2VzdFZhbHVlPkdSWVlGR1I1dEh2bDlYeTl1 R0V6TytqUzdRVE16cDd6R0t4b1dhakg5eDg9PC9kczpEaWdlc3RWYWx1ZT48L2RzOlJlZmVyZW5j ZT48ZHM6UmVmZXJlbmNlIFR5cGU9Imh0dHA6Ly91cmkuZXRzaS5vcmcvMDE5MDMjU2lnbmVkUHJv cGVydGllcyIgVVJJPSIjeG1sZHNpZy0xZDI2MDYxMC1lM2M4LTRmOTYtODFlMC1hOTM3YmYyMjE2 Yzctc2lnbmVkcHJvcHMiPjxkczpEaWdlc3RNZXRob2QgQWxnb3JpdGhtPSJodHRwOi8vd3d3Lncz Lm9yZy8yMDAxLzA0L3htbGVuYyNzaGEyNTYiLz48ZHM6RGlnZXN0VmFsdWU+ckpTL1Vyb3Zadjhn UENsU0JTdHY0Qk5XMklUc25WZ25XSnoxc3pIWHhZZz08L2RzOkRpZ2VzdFZhbHVlPjwvZHM6UmVm ZXJlbmNlPjwvZHM6U2lnbmVkSW5mbz48ZHM6U2lnbmF0dXJlVmFsdWUgSWQ9InhtbGRzaWctMWQy NjA2MTAtZTNjOC00Zjk2LTgxZTAtYTkzN2JmMjIxNmM3LXNpZ3ZhbHVlIj5lYkhtMUZqdFExSERl RWtBMXpLZURoNjE5SzhCWTlFc1M0QVRBL0puMXFtbXFRMXJaS0F1TFR1enRsRXQ5V3NKZGk1YkJa L3BtN1h4cnNDY205ZXdDZGV5WUJ0aU0vQUhUZGw2QmtOSXNQTE5pTjcwanVOUUxpZWlkM0pQa01z WmZyWFZzZE90YUJvWGhVNjBycmVid1hHQ2dUMnpVOHFKRWErTUk5MjdIVERFTm1TeFFxbGwrOXpI azhNcEdUSmNMK1NTd3pNc3JPaEFaT3N1SkxkUmdqbHBHUkZidDZYVFQ0NnpjTWRJWk00YzdGakg1 b1pKWmZxV3pCLzJrakI2VjBsTm1memJOTnJGTzZCOFBGM084NEt6ZnIrRnJUTmwxc2tyYlZaQkZE WmFnSUEvNmV4OVVmOUxmY0k1NC9mMGExam4rL2F5VUdqb2hwMmNCWG1VY3c9PTwvZHM6U2lnbmF0 dXJlVmFsdWU+PGRzOktleUluZm8gSWQ9InhtbGRzaWctMWQyNjA2MTAtZTNjOC00Zjk2LTgxZTAt YTkzN2JmMjIxNmM3LWtleWluZm8iPjxkczpYNTA5RGF0YT48ZHM6WDUwOUNlcnRpZmljYXRlPk1J SUlmakNDQm1hZ0F3SUJBZ0lJT2hGL0lrOHZEOHN3RFFZSktvWklodmNOQVFFTEJRQXdnYlF4SXpB aEJna3Foa2lHOXcwQkNRRVdGR2x1Wm05QVlXNWtaWE56WTJRdVkyOXRMbU52TVNNd0lRWURWUVFE RXhwRFFTQkJUa1JGVXlCVFEwUWdVeTVCTGlCRGJHRnpaU0JKU1RFd01DNEdBMVVFQ3hNblJHbDJh WE5wYjI0Z1pHVWdZMlZ5ZEdsbWFXTmhZMmx2YmlCbGJuUnBaR0ZrSUdacGJtRnNNUk13RVFZRFZR UUtFd3BCYm1SbGN5QlRRMFF1TVJRd0VnWURWUVFIRXd0Q2IyZHZkR0VnUkM1RExqRUxNQWtHQTFV RUJoTUNRMDh3SGhjTk1Ua3dNakU0TVRrME16QXdXaGNOTWpFd01qRTNNVGswTWpBd1dqQ0NBVEV4 SkRBaUJnTlZCQWtURzBOU0lERXpJRGsySURZM0lFOUdJRFV4TXlCRlJDQkJTMDlTU1RFc01Db0dD U3FHU0liM0RRRUpBUllkWTJGeWJHOXpMbUZrWVhKeVlXZGhRR1JpYm1WMFkyOXljQzVqYjIweEd6 QVpCZ05WQkFNVEVrUkNUa1ZVSUVOUFRFOU5Ra2xCSUZOQlV6RVRNQkVHQTFVRUJSTUtPVEF3T1RF NE1EQTBOVEUyTURRR0ExVUVEQk10UlcxcGMyOXlJRVpoWTNSMWNtRWdSV3hsWTNSeWIyNXBZMkVn TFNCUVpYSnpiMjVoSUVwMWNtbGthV05oTVNzd0tRWURWUVFMRXlKRmJXbDBhV1J2SUhCdmNpQkJi bVJsY3lCVFEwUWdRM0poSURJM0lEZzJJRFF6TVE4d0RRWURWUVFLRXdaQ1QwZFBWRUV4RHpBTkJn TlZCQWNUQmtKUFIwOVVRVEVWTUJNR0ExVUVDQk1NUTFWT1JFbE9RVTFCVWtOQk1Rc3dDUVlEVlFR R0V3SkRUekNDQVNJd0RRWUpLb1pJaHZjTkFRRUJCUUFEZ2dFUEFEQ0NBUW9DZ2dFQkFMTmpTREZw eTNFVUhvbmRZaTJxaVRpNUtYVUYwY0x4ZThwcWNoL01CU2FyK0RnNzBtRWRrSHpCVS9RTy96dUFW QythMnBuOEtDcVVTdWZOQytTREZHSGc3SnpkcGhKR2I3aFhmT2VDM3BmcU9XUU02WnJCbEZUZUdB UUlmZFVxZG50YzZqV2orSGJPekxNRHZJT2NkS0Qrcm1NdFJoRFBlVEQxcVNTMFJRUVJhWVYwUnAw YUQ0OWVIeWlZYS8wTlIwNWZyREZkeHFnaktTTWhYQVhOazYvVG5Hb3hueHlVNjZLdHFkVEJRbENh TWxZUmQ1MUgrc3hsVTlKQkxuRkVmVWZPT0JqQ2hDWTFHaDVURjZEOVo2Z3RKalFrWFhjUW8zRm5k clo5b0VxbEZpR0lyWnJPUTNUZStpVmNGMXhMN0oydzRWbUtodnZxQlk1bjlBY3g0bTBDQXdFQUFh T0NBeEl3Z2dNT01Bd0dBMVVkRXdFQi93UUNNQUF3SHdZRFZSMGpCQmd3Rm9BVXFFdTA5QXVudGx2 VW9DaUZFSjBFRXpQRXAvY3dOd1lJS3dZQkJRVUhBUUVFS3pBcE1DY0dDQ3NHQVFVRkJ6QUJoaHRv ZEhSd09pOHZiMk56Y0M1aGJtUmxjM05qWkM1amIyMHVZMjh3S0FZRFZSMFJCQ0V3SDRFZFkyRnli Rzl6TG1Ga1lYSnlZV2RoUUdSaWJtVjBZMjl5Y0M1amIyMHdnZ0h4QmdOVkhTQUVnZ0hvTUlJQjVE Q0NBZUFHRFNzR0FRUUJnZlJJQVFJR0FRSXdnZ0hOTUVFR0NDc0dBUVVGQndJQkZqVm9kSFJ3T2k4 dmQzZDNMbUZ1WkdWemMyTmtMbU52YlM1amJ5OWtiMk56TDBSUVExOUJibVJsYzFORFJGOVdNeTR3 TG5Ca1pqQ0NBWVlHQ0NzR0FRVUZCd0lDTUlJQmVCNkNBWFFBVEFCaEFDQUFkUUIwQUdrQWJBQnBB SG9BWVFCakFHa0E4d0J1QUNBQVpBQmxBQ0FBWlFCekFIUUFaUUFnQUdNQVpRQnlBSFFBYVFCbUFH a0FZd0JoQUdRQWJ3QWdBR1VBY3dCMEFPRUFJQUJ6QUhVQWFnQmxBSFFBWVFBZ0FHRUFJQUJzQUdF QWN3QWdBRkFBYndCc0FPMEFkQUJwQUdNQVlRQnpBQ0FBWkFCbEFDQUFRd0JsQUhJQWRBQnBBR1lB YVFCakFHRUFaQUJ2QUNBQVpBQmxBQ0FBUmdCaEFHTUFkQUIxQUhJQVlRQmpBR2tBOHdCdUFDQUFS UUJzQUdVQVl3QjBBSElBOHdCdUFHa0FZd0JoQUNBQUtBQlFBRU1BS1FBZ0FIa0FJQUJFQUdVQVl3 QnNBR0VBY2dCaEFHTUFhUUR6QUc0QUlBQmtBR1VBSUFCUUFISUE0UUJqQUhRQWFRQmpBR0VBY3dB Z0FHUUFaUUFnQUVNQVpRQnlBSFFBYVFCbUFHa0FZd0JoQUdNQWFRRHpBRzRBSUFBb0FFUUFVQUJE QUNrQUlBQmxBSE1BZEFCaEFHSUFiQUJsQUdNQWFRQmtBR0VBY3dBZ0FIQUFid0J5QUNBQVFRQnVB R1FBWlFCekFDQUFVd0JEQUVRd0hRWURWUjBsQkJZd0ZBWUlLd1lCQlFVSEF3SUdDQ3NHQVFVRkJ3 TUVNRGNHQTFVZEh3UXdNQzR3TEtBcW9DaUdKbWgwZEhBNkx5OWpjbXd1WVc1a1pYTnpZMlF1WTI5 dExtTnZMME5zWVhObFNVa3VZM0pzTUIwR0ExVWREZ1FXQkJSYTF2cU1tSE9maFF4ektpMmIyNXls em5SS0hUQU9CZ05WSFE4QkFmOEVCQU1DQmVBd0RRWUpLb1pJaHZjTkFRRUxCUUFEZ2dJQkFJS3Ry dGNVWEE3SGNmbUR3OFdZdWFwTzBQTEI0Q1VsQy8xeHBHT3Rac1V6TWZVUUYzUGd2VlZVZGpFb01Z SWlrbHhRa0tlblJuMVAzWXMwQzNZM2V3aFRqMUtKVDNaaEZGZEFGT052anpnbjU0QWY3OTRzT3Fm UVd4dUF2ZHR3N25MRUh5b0h6QTRPSG9OMlNqem1PS295WDFwb2NPQkhjSWdXeHlKenJKL2w2MVh1 TDNWSmdMZFBGdW9GMVBlQkhsSk0vQTdFaGNNNXoxUzlDd25OR2M3QzJoZnhRSnI1aG56anFiSWl1 WWdXM2huUEVPZzRBeE83bVlTOGJrVzJiSDEreHpVNXJYUk9vTktCVWVxaTU4TkovQ3FhY0l3UFlz cTk4TTNPY2VRbEtsUGV2VGY3TWZnTEkrWFpnRW9EYVNmaGxnSWgranlGcER4bTN5Wk5GMERleWF6 TFJSN0pTU080emhRYVdXTjMyUnU2NXRETU5nemdxUllNMWEwMHNTSEpHVEVSdW1oWUlFamEzSVEx aFduUXBCOUs0N0hsUkhOYTFUNWdITDdTUTZ1WXRNcitMWEdmU0tCL3E4Y1hNTDUwa3A4YVVQMFY3 WGlpT2kvSzF0ZjdSTXpBQ0VoNjJpSzlEeU5DaGF1OEIvbTFuQzFQa2k3WXJ0SXJyRzZKS09lVUdk TUJJUjJySVZCdE04WVE2c1pTVjBIdXJvM3VXSENlWFN5eFVmSUdwaENtWW0zdzBiY0NqdnNPcXF2 RjdrbDRIanNHTVpLQlVnSGlIaG12RWxvcy9LR01Yc0R3RCsyK2hqTmI5ZkxHYnJmZWVITS9Id0U0 bE81cVVwZFdTQTlzcVF2Tkxyc0NPdDNLK09JOGhZV3VoWGg4Z1llZVFtUjA0bEF5U1RJKzwvZHM6 WDUwOUNlcnRpZmljYXRlPjwvZHM6WDUwOURhdGE+PC9kczpLZXlJbmZvPjxkczpPYmplY3Q+PHhh ZGVzOlF1YWxpZnlpbmdQcm9wZXJ0aWVzIFRhcmdldD0iI3htbGRzaWctMWQyNjA2MTAtZTNjOC00 Zjk2LTgxZTAtYTkzN2JmMjIxNmM3Ij48eGFkZXM6U2lnbmVkUHJvcGVydGllcyBJZD0ieG1sZHNp Zy0xZDI2MDYxMC1lM2M4LTRmOTYtODFlMC1hOTM3YmYyMjE2Yzctc2lnbmVkcHJvcHMiPjx4YWRl czpTaWduZWRTaWduYXR1cmVQcm9wZXJ0aWVzPjx4YWRlczpTaWduaW5nVGltZT4yMDIwLTExLTA0 VDA3OjA5OjEzLjE5Mi0wNTowMDwveGFkZXM6U2lnbmluZ1RpbWU+PHhhZGVzOlNpZ25pbmdDZXJ0 aWZpY2F0ZT48eGFkZXM6Q2VydD48eGFkZXM6Q2VydERpZ2VzdD48ZHM6RGlnZXN0TWV0aG9kIEFs Z29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvMjAwMS8wNC94bWxlbmMjc2hhMjU2Ii8+PGRzOkRp Z2VzdFZhbHVlPkxwYnBXNVpjc25TdTR1V1U3RHpJQmZFQWxZWHVKN3RiaC9CejlVaTNtWE09PC9k czpEaWdlc3RWYWx1ZT48L3hhZGVzOkNlcnREaWdlc3Q+PHhhZGVzOklzc3VlclNlcmlhbD48ZHM6 WDUwOUlzc3Vlck5hbWU+Qz1DTyxMPUJvZ290YSBELkMuLE89QW5kZXMgU0NELixPVT1EaXZpc2lv biBkZSBjZXJ0aWZpY2FjaW9uIGVudGlkYWQgZmluYWwsQ049Q0EgQU5ERVMgU0NEIFMuQS4gQ2xh c2UgSUksMS4yLjg0MC4xMTM1NDkuMS45LjE9IzE2MTQ2OTZlNjY2ZjQwNjE2ZTY0NjU3MzczNjM2 NDJlNjM2ZjZkMmU2MzZmPC9kczpYNTA5SXNzdWVyTmFtZT48ZHM6WDUwOVNlcmlhbE51bWJlcj40 MTg0MjY1MzE0MTM4MDAxMzU1PC9kczpYNTA5U2VyaWFsTnVtYmVyPjwveGFkZXM6SXNzdWVyU2Vy aWFsPjwveGFkZXM6Q2VydD48L3hhZGVzOlNpZ25pbmdDZXJ0aWZpY2F0ZT48eGFkZXM6U2lnbmF0 dXJlUG9saWN5SWRlbnRpZmllcj48eGFkZXM6U2lnbmF0dXJlUG9saWN5SWQ+PHhhZGVzOlNpZ1Bv bGljeUlkPjx4YWRlczpJZGVudGlmaWVyPmh0dHBzOi8vZmFjdHVyYWVsZWN0cm9uaWNhLmRpYW4u Z292LmNvL3BvbGl0aWNhZGVmaXJtYS92Mi9wb2xpdGljYWRlZmlybWF2Mi5wZGY8L3hhZGVzOklk ZW50aWZpZXI+PHhhZGVzOkRlc2NyaXB0aW9uPlBvbMOtdGljYSBkZSBmaXJtYSBwYXJhIGZhY3R1 cmFzIGVsZWN0csOzbmljYXMgZGUgbGEgUmVww7pibGljYSBkZSBDb2xvbWJpYTwveGFkZXM6RGVz Y3JpcHRpb24+PC94YWRlczpTaWdQb2xpY3lJZD48eGFkZXM6U2lnUG9saWN5SGFzaD48ZHM6RGln ZXN0TWV0aG9kIEFsZ29yaXRobT0iaHR0cDovL3d3dy53My5vcmcvMjAwMS8wNC94bWxlbmMjc2hh MjU2Ii8+PGRzOkRpZ2VzdFZhbHVlPmRNb012dGNHNWFJemdZbzB0SXNTUWVWSkJEblVuZlNPZkJw eFhybW9yMFk9PC9kczpEaWdlc3RWYWx1ZT48L3hhZGVzOlNpZ1BvbGljeUhhc2g+PC94YWRlczpT aWduYXR1cmVQb2xpY3lJZD48L3hhZGVzOlNpZ25hdHVyZVBvbGljeUlkZW50aWZpZXI+PHhhZGVz OlNpZ25lclJvbGU+PHhhZGVzOkNsYWltZWRSb2xlcz48eGFkZXM6Q2xhaW1lZFJvbGU+c3VwcGxp ZXI8L3hhZGVzOkNsYWltZWRSb2xlPjwveGFkZXM6Q2xhaW1lZFJvbGVzPjwveGFkZXM6U2lnbmVy Um9sZT48L3hhZGVzOlNpZ25lZFNpZ25hdHVyZVByb3BlcnRpZXM+PC94YWRlczpTaWduZWRQcm9w ZXJ0aWVzPjwveGFkZXM6UXVhbGlmeWluZ1Byb3BlcnRpZXM+PC9kczpPYmplY3Q+PC9kczpTaWdu YXR1cmU+PC9leHQ6RXh0ZW5zaW9uQ29udGVudD4NCjwvZXh0OlVCTEV4dGVuc2lvbj4NCjwvZXh0 OlVCTEV4dGVuc2lvbnM+DQo8Y2JjOlVCTFZlcnNpb25JRD5VQkwgMi4xPC9jYmM6VUJMVmVyc2lv bklEPg0KPGNiYzpDdXN0b21pemF0aW9uSUQ+MTA8L2NiYzpDdXN0b21pemF0aW9uSUQ+DQo8Y2Jj OlByb2ZpbGVJRD5ESUFOIDIuMTwvY2JjOlByb2ZpbGVJRD4NCjxjYmM6UHJvZmlsZUV4ZWN1dGlv bklEPjI8L2NiYzpQcm9maWxlRXhlY3V0aW9uSUQ+DQo8Y2JjOklEPlNFVFA5OTA1MjU4NTY8L2Ni YzpJRD4NCjxjYmM6VVVJRCBzY2hlbWVJRD0iMiIgc2NoZW1lTmFtZT0iQ1VGRS1TSEEzODQiPjFm MWYzOWRmMTgzOTMzNWE2OTRiN2JhNGFhNDZiMDUwNGZjNzA0Yjg0MmIxNmI5NjUwMjc5ZGY0NWVj OWU2MjIzNmY2OTIwN2ZlZjYxMzVhOGY1ZThiMjI1Yjk1MmUwZTwvY2JjOlVVSUQ+DQo8Y2JjOklz c3VlRGF0ZT4yMDIwLTExLTA0PC9jYmM6SXNzdWVEYXRlPg0KPGNiYzpJc3N1ZVRpbWU+MDk6MDc6 MTAtMDU6MDA8L2NiYzpJc3N1ZVRpbWU+DQo8Y2JjOkludm9pY2VUeXBlQ29kZT4wMTwvY2JjOklu dm9pY2VUeXBlQ29kZT4NCjxjYmM6Tm90ZT5QcnVlYmEgZGUgZW1zaW9uIGRlIGRvY3VtZW50b3Mg RkVDTzwvY2JjOk5vdGU+DQo8Y2JjOkRvY3VtZW50Q3VycmVuY3lDb2RlPkNPUDwvY2JjOkRvY3Vt ZW50Q3VycmVuY3lDb2RlPg0KPGNiYzpMaW5lQ291bnROdW1lcmljPjE8L2NiYzpMaW5lQ291bnRO dW1lcmljPg0KPGNhYzpBY2NvdW50aW5nU3VwcGxpZXJQYXJ0eT4NCjxjYmM6QWRkaXRpb25hbEFj Y291bnRJRD4xPC9jYmM6QWRkaXRpb25hbEFjY291bnRJRD4NCjxjYWM6UGFydHk+DQo8Y2FjOlBh cnR5SWRlbnRpZmljYXRpb24+DQo8Y2JjOklEIHNjaGVtZUFnZW5jeUlEPSIxOTUiIHNjaGVtZUFn ZW5jeU5hbWU9IkNPLCBESUFOKERpcmVjY2lvbiBkZSBJbXB1ZXN0b3MgeSBBZHVhbmFzIE5hY2lv bmFsZXMpIiBzY2hlbWVJRD0iNSIgc2NoZW1lTmFtZT0iMzEiPjkwMDkxODAwNDwvY2JjOklEPjwv Y2FjOlBhcnR5SWRlbnRpZmljYXRpb24+DQo8Y2FjOlBhcnR5TmFtZT4NCjxjYmM6TmFtZT5EQk5l VCBTQVM8L2NiYzpOYW1lPg0KPC9jYWM6UGFydHlOYW1lPg0KPGNhYzpQaHlzaWNhbExvY2F0aW9u Pg0KPGNhYzpBZGRyZXNzPg0KPGNiYzpJRD4xMTAwMTwvY2JjOklEPg0KPGNiYzpDaXR5TmFtZT5C b2dvdGE8L2NiYzpDaXR5TmFtZT4NCjxjYmM6UG9zdGFsWm9uZS8+DQo8Y2JjOkNvdW50cnlTdWJl bnRpdHk+Qm9nb3RhLCBELkMuPC9jYmM6Q291bnRyeVN1YmVudGl0eT4NCjxjYmM6Q291bnRyeVN1 YmVudGl0eUNvZGU+MTE8L2NiYzpDb3VudHJ5U3ViZW50aXR5Q29kZT4NCjxjYWM6QWRkcmVzc0xp bmU+DQo8Y2JjOkxpbmU+Q29sb21iaWE8L2NiYzpMaW5lPg0KPC9jYWM6QWRkcmVzc0xpbmU+DQo8 Y2FjOkNvdW50cnk+DQo8Y2JjOklkZW50aWZpY2F0aW9uQ29kZT5DTzwvY2JjOklkZW50aWZpY2F0 aW9uQ29kZT4NCjxjYmM6TmFtZSBsYW5ndWFnZUlEPSJlcyI+Q29sb21iaWE8L2NiYzpOYW1lPg0K PC9jYWM6Q291bnRyeT4NCjwvY2FjOkFkZHJlc3M+DQo8L2NhYzpQaHlzaWNhbExvY2F0aW9uPg0K PGNhYzpQYXJ0eVRheFNjaGVtZT4NCjxjYmM6UmVnaXN0cmF0aW9uTmFtZT5EQk5lVCBTQVM8L2Ni YzpSZWdpc3RyYXRpb25OYW1lPg0KPGNiYzpDb21wYW55SUQgc2NoZW1lQWdlbmN5SUQ9IjE5NSIg c2NoZW1lQWdlbmN5TmFtZT0iQ08sIERJQU4gKERpcmVjY2nDg8KzbiBkZSBJbXB1ZXN0b3MgeSBB ZHVhbmFzIE5hY2lvbmFsZXMpIiBzY2hlbWVJRD0iNSIgc2NoZW1lTmFtZT0iMzEiPjkwMDkxODAw NDwvY2JjOkNvbXBhbnlJRD4NCjxjYmM6VGF4TGV2ZWxDb2RlIGxpc3ROYW1lPSI0OSI+Ty0yMzwv Y2JjOlRheExldmVsQ29kZT4NCjxjYWM6UmVnaXN0cmF0aW9uQWRkcmVzcz4NCjxjYmM6SUQ+MTEw MDE8L2NiYzpJRD4NCjxjYmM6Q2l0eU5hbWU+Qm9nb3RhPC9jYmM6Q2l0eU5hbWU+DQo8Y2JjOlBv c3RhbFpvbmUvPg0KPGNiYzpDb3VudHJ5U3ViZW50aXR5PkJvZ290YSwgRC5DLjwvY2JjOkNvdW50 cnlTdWJlbnRpdHk+DQo8Y2JjOkNvdW50cnlTdWJlbnRpdHlDb2RlPjExPC9jYmM6Q291bnRyeVN1 YmVudGl0eUNvZGU+DQo8Y2FjOkFkZHJlc3NMaW5lPg0KPGNiYzpMaW5lPkNvbG9tYmlhPC9jYmM6 TGluZT4NCjwvY2FjOkFkZHJlc3NMaW5lPg0KPGNhYzpDb3VudHJ5Pg0KPGNiYzpJZGVudGlmaWNh dGlvbkNvZGU+Q088L2NiYzpJZGVudGlmaWNhdGlvbkNvZGU+DQo8Y2JjOk5hbWUgbGFuZ3VhZ2VJ RD0iZXMiPkNvbG9tYmlhPC9jYmM6TmFtZT4NCjwvY2FjOkNvdW50cnk+DQo8L2NhYzpSZWdpc3Ry YXRpb25BZGRyZXNzPg0KPGNhYzpUYXhTY2hlbWU+DQo8Y2JjOklEPjAyPC9jYmM6SUQ+DQo8Y2Jj Ok5hbWU+SUM8L2NiYzpOYW1lPg0KPC9jYWM6VGF4U2NoZW1lPg0KPC9jYWM6UGFydHlUYXhTY2hl bWU+DQo8Y2FjOlBhcnR5TGVnYWxFbnRpdHk+DQo8Y2JjOlJlZ2lzdHJhdGlvbk5hbWU+REJOZVQg U0FTPC9jYmM6UmVnaXN0cmF0aW9uTmFtZT4NCjxjYmM6Q29tcGFueUlEIHNjaGVtZUFnZW5jeUlE PSIxOTUiIHNjaGVtZUFnZW5jeU5hbWU9IkNPLCBESUFOIChEaXJlY2Npw4PCs24gZGUgSW1wdWVz dG9zIHkgQWR1YW5hcyBOYWNpb25hbGVzKSIgc2NoZW1lSUQ9IjUiIHNjaGVtZU5hbWU9IjMxIj45 MDA5MTgwMDQ8L2NiYzpDb21wYW55SUQ+DQo8Y2FjOkNvcnBvcmF0ZVJlZ2lzdHJhdGlvblNjaGVt ZT4NCjxjYmM6SUQ+U0VUUDwvY2JjOklEPg0KPC9jYWM6Q29ycG9yYXRlUmVnaXN0cmF0aW9uU2No ZW1lPg0KPC9jYWM6UGFydHlMZWdhbEVudGl0eT4NCjxjYWM6Q29udGFjdD4NCjxjYmM6TmFtZT5K dWFuIFBlcmV6PC9jYmM6TmFtZT4NCjxjYmM6VGVsZXBob25lPjMyNTgwMzA8L2NiYzpUZWxlcGhv bmU+DQo8Y2JjOkVsZWN0cm9uaWNNYWlsPmNvcnJlb0Bjb250YWN0bzEuY29tPC9jYmM6RWxlY3Ry b25pY01haWw+DQo8Y2JjOk5vdGU+RGVzIENvbnRhY3RvIDE8L2NiYzpOb3RlPg0KPC9jYWM6Q29u dGFjdD4NCjwvY2FjOlBhcnR5Pg0KPC9jYWM6QWNjb3VudGluZ1N1cHBsaWVyUGFydHk+DQo8Y2Fj OkFjY291bnRpbmdDdXN0b21lclBhcnR5Pg0KPGNiYzpBZGRpdGlvbmFsQWNjb3VudElEPjE8L2Ni YzpBZGRpdGlvbmFsQWNjb3VudElEPg0KPGNhYzpQYXJ0eT4NCjxjYWM6UGFydHlJZGVudGlmaWNh dGlvbj4NCjxjYmM6SUQgc2NoZW1lQWdlbmN5SUQ9IjE5NSIgc2NoZW1lQWdlbmN5TmFtZT0iQ08s IERJQU4oRGlyZWNjaW9uIGRlIEltcHVlc3RvcyB5IEFkdWFuYXMgTmFjaW9uYWxlcykiIHNjaGVt ZUlEPSIwIiBzY2hlbWVOYW1lPSIxMiI+OTAwOTE4MDA0PC9jYmM6SUQ+PC9jYWM6UGFydHlJZGVu dGlmaWNhdGlvbj4NCjxjYWM6UGFydHlOYW1lPg0KPGNiYzpOYW1lPlYgUSBJTkdFTklFUklBIFNP Q0lFREFEIFBPUiBBQ0NJT05FUyBTSU1QTElGSUNBREEgUy5BLlMuPC9jYmM6TmFtZT4NCjwvY2Fj OlBhcnR5TmFtZT4NCjxjYWM6UGh5c2ljYWxMb2NhdGlvbj4NCjxjYWM6QWRkcmVzcz4NCjxjYmM6 SUQ+MTEwMDE8L2NiYzpJRD4NCjxjYmM6Q2l0eU5hbWU+Qm9nb3RhLCBELkMuPC9jYmM6Q2l0eU5h bWU+DQo8Y2JjOlBvc3RhbFpvbmUvPg0KPGNiYzpDb3VudHJ5U3ViZW50aXR5PkJvZ290YSwgRC5D LjwvY2JjOkNvdW50cnlTdWJlbnRpdHk+DQo8Y2JjOkNvdW50cnlTdWJlbnRpdHlDb2RlPjExPC9j YmM6Q291bnRyeVN1YmVudGl0eUNvZGU+DQo8Y2FjOkFkZHJlc3NMaW5lPg0KPGNiYzpMaW5lPkNy YSA3MEMgIyA1NCAtIDY5PC9jYmM6TGluZT4NCjwvY2FjOkFkZHJlc3NMaW5lPg0KPGNhYzpDb3Vu dHJ5Pg0KPGNiYzpJZGVudGlmaWNhdGlvbkNvZGU+Q088L2NiYzpJZGVudGlmaWNhdGlvbkNvZGU+ DQo8Y2JjOk5hbWUgbGFuZ3VhZ2VJRD0iZXMiPkNvbG9tYmlhPC9jYmM6TmFtZT4NCjwvY2FjOkNv dW50cnk+DQo8L2NhYzpBZGRyZXNzPg0KPC9jYWM6UGh5c2ljYWxMb2NhdGlvbj4NCjxjYWM6UGFy dHlUYXhTY2hlbWU+DQo8Y2JjOlJlZ2lzdHJhdGlvbk5hbWU+ViBRIElOR0VOSUVSSUEgU09DSUVE QUQgUE9SIEFDQ0lPTkVTIFNJTVBMSUZJQ0FEQSBTLkEuUy48L2NiYzpSZWdpc3RyYXRpb25OYW1l Pg0KPGNiYzpDb21wYW55SUQgc2NoZW1lQWdlbmN5SUQ9IjE5NSIgc2NoZW1lQWdlbmN5TmFtZT0i Q08sIERJQU4gKERpcmVjY2nDg8KzbiBkZSBJbXB1ZXN0b3MgeSBBZHVhbmFzIE5hY2lvbmFsZXMp IiBzY2hlbWVJRD0iMCIgc2NoZW1lTmFtZT0iMTIiPjkwMDkxODAwNDwvY2JjOkNvbXBhbnlJRD4N CjxjYmM6VGF4TGV2ZWxDb2RlIGxpc3ROYW1lPSI0OCI+Ty0yMzwvY2JjOlRheExldmVsQ29kZT4N CjxjYWM6VGF4U2NoZW1lPg0KPGNiYzpJRD4wMTwvY2JjOklEPg0KPGNiYzpOYW1lPklWQTwvY2Jj Ok5hbWU+DQo8L2NhYzpUYXhTY2hlbWU+DQo8L2NhYzpQYXJ0eVRheFNjaGVtZT4NCjxjYWM6UGFy dHlMZWdhbEVudGl0eT4NCjxjYmM6UmVnaXN0cmF0aW9uTmFtZT5WIFEgSU5HRU5JRVJJQSBTT0NJ RURBRCBQT1IgQUNDSU9ORVMgU0lNUExJRklDQURBIFMuQS5TLjwvY2JjOlJlZ2lzdHJhdGlvbk5h bWU+DQo8Y2JjOkNvbXBhbnlJRCBzY2hlbWVBZ2VuY3lJRD0iMTk1IiBzY2hlbWVBZ2VuY3lOYW1l PSJDTywgRElBTiAoRGlyZWNjacODwrNuIGRlIEltcHVlc3RvcyB5IEFkdWFuYXMgTmFjaW9uYWxl cykiIHNjaGVtZUlEPSIwIiBzY2hlbWVOYW1lPSIxMiI+OTAwOTE4MDA0PC9jYmM6Q29tcGFueUlE Pg0KPC9jYWM6UGFydHlMZWdhbEVudGl0eT4NCjxjYWM6Q29udGFjdD4NCjxjYmM6TmFtZT5BcXVp bGVzIEJhZXphPC9jYmM6TmFtZT4NCjxjYmM6VGVsZXBob25lPjMyNTgwMzA8L2NiYzpUZWxlcGhv bmU+DQo8Y2JjOkVsZWN0cm9uaWNNYWlsPmFxdWlsZXNAY29udGFjdG8yLmNvbTwvY2JjOkVsZWN0 cm9uaWNNYWlsPg0KPGNiYzpOb3RlPkRlcyBDb250YWN0byAyPC9jYmM6Tm90ZT4NCjwvY2FjOkNv bnRhY3Q+DQo8L2NhYzpQYXJ0eT4NCjwvY2FjOkFjY291bnRpbmdDdXN0b21lclBhcnR5Pg0KPGNh YzpQYXltZW50TWVhbnM+DQo8Y2JjOklEPjE8L2NiYzpJRD4NCjxjYmM6UGF5bWVudE1lYW5zQ29k ZT4xMDwvY2JjOlBheW1lbnRNZWFuc0NvZGU+DQo8Y2JjOlBheW1lbnRJRD5JRCBNUEFHTzwvY2Jj OlBheW1lbnRJRD4NCjwvY2FjOlBheW1lbnRNZWFucz4NCjxjYWM6VGF4VG90YWw+DQo8Y2JjOlRh eEFtb3VudCBjdXJyZW5jeUlEPSJDT1AiPjI4NTAwMC4wMDwvY2JjOlRheEFtb3VudD4NCjxjYWM6 VGF4U3VidG90YWw+DQo8Y2JjOlRheGFibGVBbW91bnQgY3VycmVuY3lJRD0iQ09QIj4xNTAwMDAw LjAwPC9jYmM6VGF4YWJsZUFtb3VudD4NCjxjYmM6VGF4QW1vdW50IGN1cnJlbmN5SUQ9IkNPUCI+ Mjg1MDAwLjAwPC9jYmM6VGF4QW1vdW50Pg0KPGNhYzpUYXhDYXRlZ29yeT4NCjxjYmM6UGVyY2Vu dD4xOS4wMDwvY2JjOlBlcmNlbnQ+DQo8Y2FjOlRheFNjaGVtZT4NCjxjYmM6SUQ+MDE8L2NiYzpJ RD4NCjxjYmM6TmFtZT5JVkE8L2NiYzpOYW1lPg0KPC9jYWM6VGF4U2NoZW1lPg0KPC9jYWM6VGF4 Q2F0ZWdvcnk+DQo8L2NhYzpUYXhTdWJ0b3RhbD4NCjwvY2FjOlRheFRvdGFsPg0KPGNhYzpXaXRo aG9sZGluZ1RheFRvdGFsPg0KPGNiYzpUYXhBbW91bnQgY3VycmVuY3lJRD0iQ09QIj40Mjc1MC4w MDwvY2JjOlRheEFtb3VudD4NCjxjYWM6VGF4U3VidG90YWw+DQo8Y2JjOlRheGFibGVBbW91bnQg Y3VycmVuY3lJRD0iQ09QIj4yODUwMDAuMDA8L2NiYzpUYXhhYmxlQW1vdW50Pg0KPGNiYzpUYXhB bW91bnQgY3VycmVuY3lJRD0iQ09QIj40Mjc1MC4wMDwvY2JjOlRheEFtb3VudD4NCjxjYWM6VGF4 Q2F0ZWdvcnk+DQo8Y2JjOlBlcmNlbnQ+MTUuMDA8L2NiYzpQZXJjZW50Pg0KPGNhYzpUYXhTY2hl bWU+DQo8Y2JjOklEPjA1PC9jYmM6SUQ+DQo8Y2JjOk5hbWU+UmV0ZUlWQTwvY2JjOk5hbWU+DQo8 L2NhYzpUYXhTY2hlbWU+DQo8L2NhYzpUYXhDYXRlZ29yeT4NCjwvY2FjOlRheFN1YnRvdGFsPg0K PC9jYWM6V2l0aGhvbGRpbmdUYXhUb3RhbD4NCjxjYWM6TGVnYWxNb25ldGFyeVRvdGFsPg0KPGNi YzpMaW5lRXh0ZW5zaW9uQW1vdW50IGN1cnJlbmN5SUQ9IkNPUCI+MTUwMDAwMC4wMDwvY2JjOkxp bmVFeHRlbnNpb25BbW91bnQ+DQo8Y2JjOlRheEV4Y2x1c2l2ZUFtb3VudCBjdXJyZW5jeUlEPSJD T1AiPjE1MDAwMDAuMDA8L2NiYzpUYXhFeGNsdXNpdmVBbW91bnQ+DQo8Y2JjOlRheEluY2x1c2l2 ZUFtb3VudCBjdXJyZW5jeUlEPSJDT1AiPjE3ODUwMDAuMDA8L2NiYzpUYXhJbmNsdXNpdmVBbW91 bnQ+DQo8Y2JjOkFsbG93YW5jZVRvdGFsQW1vdW50IGN1cnJlbmN5SUQ9IkNPUCI+MC4wMDwvY2Jj OkFsbG93YW5jZVRvdGFsQW1vdW50Pg0KPGNiYzpDaGFyZ2VUb3RhbEFtb3VudCBjdXJyZW5jeUlE PSJDT1AiPjAuMDA8L2NiYzpDaGFyZ2VUb3RhbEFtb3VudD4NCjxjYmM6UGF5YWJsZUFtb3VudCBj dXJyZW5jeUlEPSJDT1AiPjE3ODUwMDAuMDA8L2NiYzpQYXlhYmxlQW1vdW50Pg0KPC9jYWM6TGVn YWxNb25ldGFyeVRvdGFsPg0KPGNhYzpJbnZvaWNlTGluZT4NCjxjYmM6SUQ+MTwvY2JjOklEPg0K PGNiYzpOb3RlPk5vdGFzIGRlbCBJdGVtIDE8L2NiYzpOb3RlPg0KPGNiYzpJbnZvaWNlZFF1YW50 aXR5IHVuaXRDb2RlPSJFQSI+MTwvY2JjOkludm9pY2VkUXVhbnRpdHk+DQo8Y2JjOkxpbmVFeHRl bnNpb25BbW91bnQgY3VycmVuY3lJRD0iQ09QIj4xNTAwMDAwLjAwPC9jYmM6TGluZUV4dGVuc2lv bkFtb3VudD4NCg0KDQo8Y2FjOkRlc3BhdGNoTGluZVJlZmVyZW5jZT4NCjxjYmM6TGluZUlEPjE8 L2NiYzpMaW5lSUQ+DQo8Y2FjOkRvY3VtZW50UmVmZXJlbmNlPg0KPGNiYzpJRD5FUDBDTE5UNTAw IDUwMjYyMzMzNDQtMjAxOTwvY2JjOklEPg0KPGNiYzpEb2N1bWVudFR5cGVDb2RlPk1JR088L2Ni YzpEb2N1bWVudFR5cGVDb2RlPg0KPC9jYWM6RG9jdW1lbnRSZWZlcmVuY2U+DQo8L2NhYzpEZXNw YXRjaExpbmVSZWZlcmVuY2U+DQoNCg0KPGNhYzpUYXhUb3RhbD4NCjxjYmM6VGF4QW1vdW50IGN1 cnJlbmN5SUQ9IkNPUCI+Mjg1MDAwLjAwPC9jYmM6VGF4QW1vdW50Pg0KPGNhYzpUYXhTdWJ0b3Rh bD4NCjxjYmM6VGF4YWJsZUFtb3VudCBjdXJyZW5jeUlEPSJDT1AiPjE1MDAwMDAuMDA8L2NiYzpU YXhhYmxlQW1vdW50Pg0KPGNiYzpUYXhBbW91bnQgY3VycmVuY3lJRD0iQ09QIj4yODUwMDAuMDA8 L2NiYzpUYXhBbW91bnQ+DQo8Y2FjOlRheENhdGVnb3J5Pg0KPGNiYzpQZXJjZW50PjE5LjAwPC9j YmM6UGVyY2VudD4NCjxjYWM6VGF4U2NoZW1lPg0KPGNiYzpJRD4wMTwvY2JjOklEPg0KPGNiYzpO YW1lPklWQTwvY2JjOk5hbWU+DQo8L2NhYzpUYXhTY2hlbWU+DQo8L2NhYzpUYXhDYXRlZ29yeT4N CjwvY2FjOlRheFN1YnRvdGFsPg0KPC9jYWM6VGF4VG90YWw+DQo8Y2FjOlRheFRvdGFsPg0KPGNi YzpUYXhBbW91bnQgY3VycmVuY3lJRD0iQ09QIj40Mjc1MC4wMDwvY2JjOlRheEFtb3VudD4NCjxj YWM6VGF4U3VidG90YWw+DQo8Y2JjOlRheGFibGVBbW91bnQgY3VycmVuY3lJRD0iQ09QIj4yODUw MDAuMDA8L2NiYzpUYXhhYmxlQW1vdW50Pg0KPGNiYzpUYXhBbW91bnQgY3VycmVuY3lJRD0iQ09Q Ij40Mjc1MC4wMDwvY2JjOlRheEFtb3VudD4NCjxjYWM6VGF4Q2F0ZWdvcnk+DQo8Y2JjOlBlcmNl bnQ+MTUuMDA8L2NiYzpQZXJjZW50Pg0KPGNhYzpUYXhTY2hlbWU+DQo8Y2JjOklEPjA1PC9jYmM6 SUQ+DQo8Y2JjOk5hbWU+UmV0ZUlWQTwvY2JjOk5hbWU+DQo8L2NhYzpUYXhTY2hlbWU+DQo8L2Nh YzpUYXhDYXRlZ29yeT4NCjwvY2FjOlRheFN1YnRvdGFsPg0KPC9jYWM6VGF4VG90YWw+DQoNCjxj YWM6SXRlbT4NCiA8Y2JjOkRlc2NyaXB0aW9uPkRlc2NyaXBjaW9uIGRlbCBpdGVtOiAxPC9jYmM6 RGVzY3JpcHRpb24+DQoNCjxjYWM6U3RhbmRhcmRJdGVtSWRlbnRpZmljYXRpb24+DQo8Y2JjOklE IHNjaGVtZUFnZW5jeUlEPSIxMCIgc2NoZW1lSUQ9IjAwMSIgc2NoZW1lTmFtZT0iVU5TUFNDIj4x PC9jYmM6SUQ+IA0KPC9jYWM6U3RhbmRhcmRJdGVtSWRlbnRpZmljYXRpb24+DQoNCg0KDQo8L2Nh YzpJdGVtPg0KPGNhYzpQcmljZT4NCjxjYmM6UHJpY2VBbW91bnQgY3VycmVuY3lJRD0iQ09QIj4x NTAwMDAwLjAwPC9jYmM6UHJpY2VBbW91bnQ+DQo8Y2JjOkJhc2VRdWFudGl0eSB1bml0Q29kZT0i RUEiPjE8L2NiYzpCYXNlUXVhbnRpdHk+DQo8L2NhYzpQcmljZT4NCg0KPC9jYWM6SW52b2ljZUxp bmU+DQo8L0ludm9pY2U+')";

                        cmd = new SqlCommand(insertDteDocuXlobXml, AbrirConexion());
                        cmd.ExecuteNonQuery();
                        CerrarConexion();

                        string insertDteJson = "insert into dte_docu_json (CORR_CONT, DOCU_JSON, FECH_CARG) values (" + corrCont + ", '', getdate())";

                        cmd = new SqlCommand(insertDteJson, AbrirConexion());
                        cmd.ExecuteNonQuery();
                        CerrarConexion();

                        string insertDteXlobQRD = "insert into dte_docu_xlob(CORR_CONT, TIPO_ARCH, CLOB_ARCH) values(" + corrCont + ", 'QRD', 'TnVtRmFjOiBTRVRQOTkwNTI1ODU2IApGZWNGYWM6IDIwMjAtMTEtMDQgCkhvckZhYzogMDk6MDc6 MTAtMDU6MDAKTml0RmFjOiA5MDA5MTgwMDQgCkRvY0FkcTogOTAwOTE4MDA0IApWYWxGYWM6IDE1 MDAwMDAuMDAgClZhbEl2YTogMjg1MDAwLjAwIApWYWxPdHJvSW06IDAuMDAgClZhbFRvbEZhYzog MTc4NTAwMC4wMCAKQ1VGRTogMWYxZjM5ZGYxODM5MzM1YTY5NGI3YmE0YWE0NmIwNTA0ZmM3MDRi ODQyYjE2Yjk2NTAyNzlkZjQ1ZWM5ZTYyMjM2ZjY5MjA3ZmVmNjEzNWE4ZjVlOGIyMjViOTUyZTBl IApRUkNvZGU6IGh0dHBzOi8vY2F0YWxvZ28tdnBmZS1oYWIuZGlhbi5nb3YuY28vZG9jdW1lbnQv c2VhcmNocXI/ZG9jdW1lbnRrZXk9MWYxZjM5ZGYxODM5MzM1YTY5NGI3YmE0YWE0NmIwNTA0ZmM3 MDRiODQyYjE2Yjk2NTAyNzlkZjQ1ZWM5ZTYyMjM2ZjY5MjA3ZmVmNjEzNWE4ZjVlOGIyMjViOTUy ZTBlIA==')";

                        cmd = new SqlCommand(insertDteXlobQRD, AbrirConexion());
                        cmd.ExecuteNonQuery();
                        CerrarConexion();

                        string insertDteDocuOper = "insert into dte_docu_oper (CORR_CONT, IDEN_SOFT,DOCU_CUFE, FECH_EMIS, IMPR_DEST, PLNT_ID) values (" + corrCont + ",'555e750e-d9c0-4980-aa42-948a227beff5','1f1f39df1839335a694b7ba4aa46b0504fc704b842b16b9650279df45ec9e62236f69207fef6135a8f5e8b225b952e0e','2020-11-04T09:07:10','',NULL)";

                        cmd = new SqlCommand(insertDteDocuOper, AbrirConexion());
                        cmd.ExecuteNonQuery();
                        CerrarConexion();
                    }
                }

            return val;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error Carga Directa BD: " + e.Message);
                CerrarConexion();
                return e.Number;
            }
        }

    }
}
