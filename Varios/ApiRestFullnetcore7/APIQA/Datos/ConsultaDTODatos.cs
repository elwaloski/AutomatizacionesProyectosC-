using APIQA.Models;
using System.Data;
using System.Data.SqlClient;

namespace APIQA.Datos
{
    public class ConsultaDTODatos
    {
        public static decimal UltimoFolioRecepcionado(string rutRece, string tipoDocu, string? codiEmex)
        {
            string sql = "SELECT nume_docu FROM dte_control " +
                    "WHERE tipo_oper = 'RCP' " +
                    "AND iden_rece = @idenRece " +
                    "AND tipo_docu = @tipoDocu " +
                    "ORDER BY nume_docu DESC";

            var cmd = new SqlCommand(sql, LeerParametros.ConectarBD);
            cmd.Parameters.AddWithValue("@idenRece", rutRece);
            cmd.Parameters.AddWithValue("@tipoDocu", tipoDocu);
            if (!string.IsNullOrEmpty(codiEmex))
                cmd.Parameters.AddWithValue("@codiEmex", codiEmex);

            try
            {
                LeerParametros.AbrirBD();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    decimal folioRecuperado = dr.GetDecimal(0);
                    return folioRecuperado;
                }
                return 0;
            }
            catch
            {
                return 0;
            }
            finally
            {
                LeerParametros.CerraBD();
            }
        }

        public static int CountQmtaReceInfo()
        {
            string sql = "SELECT COUNT(*) FROM qmta_rece_info";
            var cmd = new SqlCommand(sql, LeerParametros.ConectarBD);
            try
            {
                LeerParametros.AbrirBD();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr.GetInt32(0);
                }
                return -1;
            }
            catch 
            { 
                return -2; 
            }
            finally
            {
                LeerParametros.CerraBD();
            }
        }

        public static decimal UltimoCorrContDteControl()
        {
            string sql = "SELECT TOP 1 corr_cont FROM dte_control ORDER BY corr_cont DESC";
            var cmd = new SqlCommand(sql, LeerParametros.ConectarBD);
            try
            {
                LeerParametros.AbrirBD();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    return dr.GetDecimal(0);
                }
                return -1;
            }
            catch
            {
                return -2;
            }
            finally
            {
                LeerParametros.CerraBD();
            }
        }

    }
}
