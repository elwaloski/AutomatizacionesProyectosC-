using ApiWalde.Models;
using System.Data;
using System.Data.SqlClient;

namespace ApiWalde.Datos
{
    public class ConsultaFolioDatos
    {
        public static List<DteRangFoli> Listar()
        {
            List<DteRangFoli> oListadterangfoli = new();
            try
            {
                LeerParametros.AbrirBD();
                SqlCommand cmd = new("QA_01_PRC_DTE_RANG_FOLI_HOLD_VAL", LeerParametros.ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oListadterangfoli.Add(new DteRangFoli()
                    {
                        CODI_EMEX = dr["CODI_EMEX"].ToString(),
                        CODI_EMPR = Convert.ToInt32(dr["CODI_EMPR"]),
                        TIPO_DORA = Convert.ToInt32(dr["TIPO_DORA"]),
                        FOLI_DESD = Convert.ToInt32(dr["FOLI_DESD"]),
                        FOLI_HAST = Convert.ToInt32(dr["FOLI_HAST"])
                    });
                }
                LeerParametros.CerraBD();
                return oListadterangfoli;
            }
            catch (Exception)
            {
                LeerParametros.CerraBD();
                return oListadterangfoli;
            }

        }

        public static DteRangFoli1 Obtener(string codi_emex, int codi_empr, int tipo_docu, string TipoDTEoBEL)
        {

            DteRangFoli1 RangFoli = new();
            string sql = "";
            TipoDTEoBEL = TipoDTEoBEL.ToUpper();
            codi_emex = codi_emex.ToUpper();

            string ExisteCodiEmex = LeerParametros.ConsultaExisteHolding(codi_emex);
            if (codi_emex == null || codi_emex == "" )
            {
                RangFoli = new DteRangFoli1()
                {
                    Folio_Disponible = Convert.ToInt32("-5"),
                };
                return RangFoli;
            }

            if (ExisteCodiEmex == "NoExiste" || codi_emex == "Error")
            {
                RangFoli = new DteRangFoli1()
                {
                    Folio_Disponible = Convert.ToInt32("-6"),
                };
                return RangFoli;
            }
            if (codi_empr == 0 || codi_empr < 0)
            {
                RangFoli = new DteRangFoli1()
                {
                    Folio_Disponible = Convert.ToInt32("-7"),
                };
                return RangFoli;
            }

            if (TipoDTEoBEL == null || TipoDTEoBEL == "")
            {
                RangFoli = new DteRangFoli1()
                {
                    Folio_Disponible = Convert.ToInt32("-8"),
                };                
                return RangFoli;
            }

            if (TipoDTEoBEL != "DTE" && TipoDTEoBEL != "BEL")
            {
                RangFoli = new DteRangFoli1()
                {
                    Folio_Disponible = Convert.ToInt32("-9"),
                };
                return RangFoli;
            }

            if (TipoDTEoBEL == "DTE" && (tipo_docu == 33 || tipo_docu==34 || tipo_docu == 43 || tipo_docu == 46 || tipo_docu == 52 || tipo_docu == 56 || tipo_docu == 61 || tipo_docu == 110 || tipo_docu == 111 || tipo_docu == 112))
            {
                sql = "QA_01_OBTENERFOLIODISPONIBLEFACTURAS";
            }
            if (TipoDTEoBEL == "BEL" && (tipo_docu == 39 || tipo_docu == 41))
            {
                sql = "QA_01_OBTENERFOLIODISPONIBLEBOLETAS";
            }
            if (sql == "")
            {
                RangFoli = new DteRangFoli1()
                {
                    Folio_Disponible = Convert.ToInt32("-10"),
                };
                return RangFoli;
            }
            try
            {
                LeerParametros.AbrirBD();
                SqlCommand cmd = new(sql, LeerParametros.ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codi_emex", codi_emex);
                cmd.Parameters.AddWithValue("@tipo_docu", tipo_docu);
                cmd.Parameters.AddWithValue("@codi_empr", codi_empr);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RangFoli = new DteRangFoli1()
                    {
                        Folio_Disponible = Convert.ToInt32(dr["Folio_disponible"]),

                    };
                }
                LeerParametros.CerraBD();
                return RangFoli;
            }
            catch (Exception)
            {
                LeerParametros.CerraBD();
                return RangFoli;
            }
        }

    }
}
