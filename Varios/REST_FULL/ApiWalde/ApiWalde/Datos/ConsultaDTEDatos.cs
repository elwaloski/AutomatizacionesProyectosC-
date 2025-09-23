using ApiWalde.Models;
using System.Data;
using System.Data.SqlClient;

namespace ApiWalde.Datos
{
    public class ConsultaDTEDatos
    {
        public static List<ConsultaDTE> Listar()
        {
            List<ConsultaDTE> oListaParaEmpr = new List<ConsultaDTE>();
            string sql = "QA_01_SELECT_DTE_ENCA_DOCU_HOLD";

            try
            {
                LeerParametros.AbrirBD();
                SqlCommand cmd = new SqlCommand(sql, LeerParametros.ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oListaParaEmpr.Add(new ConsultaDTE()
                    {
                        Codi_emex = dr["codi_emex"].ToString(),
                        Codi_empr = Convert.ToInt32(dr["codi_empr"]),
                        Tipo_docu = Convert.ToInt32(dr["tipo_docu"]),
                        Foli_docu = Convert.ToInt32(dr["foli_docu"]),
                        Esta_docu = dr["esta_docu"].ToString()
                    });
                }
                LeerParametros.CerraBD();
                return oListaParaEmpr;
            }
            catch (Exception)
            {
                LeerParametros.CerraBD();
                return oListaParaEmpr;
            }
        }

        public static ConsultaDTE Obtener(string codi_emex, int codi_empr, int tipo_docu, int foli_docu)
        {
            Listar();
            ConsultaDTE Consulta = new ConsultaDTE();
            string sql = "";

            if (codi_emex==null || codi_emex == "")
            {
                Consulta = new ConsultaDTE()
                {
                    Codi_emex = "-5",
                };
                return Consulta;
            }

            if (codi_empr == 0 || codi_empr < 0)
            {
                Consulta = new ConsultaDTE()
                {
                    Codi_emex = "-6",
                };
                return Consulta;
            }
            if (tipo_docu == 0 || tipo_docu < 0)
            {
                Consulta = new ConsultaDTE()
                {
                    Codi_emex = "-7",
                };
                return Consulta;
            }
            if (foli_docu == 0 || foli_docu < 0)
            {
                Consulta = new ConsultaDTE()
                {
                    Codi_emex = "-8",
                };
                return Consulta;
            }

            string ExisteCodiEmex = LeerParametros.ConsultaExisteHolding(codi_emex);
            if (ExisteCodiEmex == "NoExiste" || ExisteCodiEmex == "Error")
            {
                Consulta = new ConsultaDTE()
                {
                    Codi_emex = "-9",
                };
                return Consulta;
            }
            string ExisteEmprCodiemex = LeerParametros.ConsultaExisteEMPRHolding(codi_emex, codi_empr);
            if (ExisteEmprCodiemex== "NoExiste" || ExisteEmprCodiemex == "Error") 
            {
                Consulta = new ConsultaDTE()
                {
                    Codi_emex = "-10",
                };
                return Consulta;
            }

            if (tipo_docu ==33 || tipo_docu == 34 || tipo_docu == 43 || tipo_docu == 46 || tipo_docu == 52 || tipo_docu == 56 || tipo_docu == 61 || tipo_docu == 110 || tipo_docu == 111 || tipo_docu == 112)
            {
                sql = "QA_01_SELECT_DTE_ENCA_DOCU_HOLD_PARAM";
            }
            else 
            {
                Consulta = new ConsultaDTE()
                {
                    Codi_emex = "-11",
                };
                return Consulta;
            }

            try
            {
                LeerParametros.AbrirBD();
                SqlCommand cmd = new SqlCommand(sql, LeerParametros.ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codi_emex", codi_emex);
                cmd.Parameters.AddWithValue("@Codi_empr", codi_empr);
                cmd.Parameters.AddWithValue("@tipo_docu", tipo_docu);
                cmd.Parameters.AddWithValue("@foli_docu", foli_docu);
                
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Consulta = new ConsultaDTE()
                        {
                            Codi_emex = dr["codi_emex"].ToString(),
                            Codi_empr = Convert.ToInt32(dr["codi_empr"]),
                            Tipo_docu = Convert.ToInt32(dr["tipo_docu"]),
                            Foli_docu = Convert.ToInt32(dr["foli_docu"]),
                            Esta_docu = dr["esta_docu"].ToString()
                        };
                    }
                }
                else
                {
                    Consulta = new ConsultaDTE()
                    {
                        Codi_emex = "-12",
                    };
                    return Consulta;
                }
                LeerParametros.CerraBD();
                return Consulta;
            }
            catch (Exception )
            {
                Consulta = new ConsultaDTE()
                {
                    Codi_emex = "0",
                };;
                LeerParametros.CerraBD();
                return Consulta;
            }
        }
    }
}
