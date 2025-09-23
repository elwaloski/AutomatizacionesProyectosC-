

namespace Metodos
{
    public class CargaMTA
    {
        static string qmta_rece_info = Definiciones.qmta_rece_info();
        static string qmta_rece_part = Definiciones.qmta_rece_part();
        public static string FechaActual { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");

        public static string CargaMTADocumento(string Documento)
        {
            ConexionBD con = new ConexionBD();
            string[] Datos = con.RecuperaDatosHolding();
            string holding = Datos[0];
            string codi_empr = Datos[1];
            string RutEmis = Datos[2];
            string DigiEmis = Datos[3];
            string nombreEmprCorrecto = Datos[4];
            LeerParametros.LeeParamConfig();
            string Rutrece = LeerParametros.RutRece;
            string Digirece = LeerParametros.DigiRece;
            int CargaDesde = Int32.Parse(LeerParametros.CargaDesde);
            int CargaHasta = Int32.Parse(LeerParametros.CargaHasta);

            try
            {
                for (int i = CargaDesde; i <= CargaHasta; i++)
                 {    
                     con.abrirBD();
                     String Dato = con.recupera_dato("select top 1 [mail_msid]from qmta_rece_info  order by corr_info desc");
    
                     if (Dato == "")
                     {
                         Dato = "0";
                     }
                     int mail_msid = int.Parse(Dato);
                     mail_msid = mail_msid + 1;
    
                     String a = qmta_rece_info + "(" + mail_msid + ",'Waldo Gonzalez <waldo.gonzalez@dbnetcorp.com>', N'jorgeflores@mt5.dbnetcorp.com', '', 'Documentos','" + FechaActual + " 00:00:00', N'NEW', NULL,'" + FechaActual + " 00:00:00.570', NULL, NULL)";
                     con.EjecutarSql(a);
    
                     String imprime = Documentos.XMLdocumento(Documento, Convert.ToInt32(i), nombreEmprCorrecto + "<");
                     String PDF64A = Documentos.PDF();
    
                     String B = qmta_rece_part + "(" + mail_msid + ",'DocumentoProveedor','envCliE" + i + ".xml','text/xml','US-ASCII','" + imprime + "','NEW',NULL,'" + FechaActual + " 00:00:00.033')" +
                     qmta_rece_part + "(" + mail_msid + ", 'Otro adjunto', 'PDFA" + mail_msid + i + ".pdf', 'application/pdf', '', '" + PDF64A + "', 'NEW', NULL, '" + FechaActual + " 00:00:00.033')";
    
                     con.EjecutarSql(B);
                     con.CerraBD();
                 }
                 return "Carga Documentos tipo " + Documento + " Correcto";                    
            }
            catch (Exception ex)
            {
                con.CerraBD();
                return ("Error en carga doc tipo " + Documento + " " + ex);

            }
        }
             
        public static string EjecutaPRCFILEAIE()
        {
            try
            {
                Documentos.CMD();
                return ("SE Ejecuto de forma exitosa PRCFILEAIE Recepcion");
            }
            catch (Exception ex)
            {
                return ("Error en Ejecutar PRCFILEAIE" + ex);
            }

        }

        public static string EliminaDataSEDTO(string tipo_docu)
        {
            ConexionBD con = new ConexionBD();
            try
            {
                con.abrirBD();
                con.EliminaDTOControSE(tipo_docu);
                con.CerraBD();
                return ("Eliminacion correcta SE para los documentos "+ tipo_docu);
            }
            catch (Exception ex)
            {
                return ("Error en Eliminar Data SE" + ex);

            }
        }
    }
}
