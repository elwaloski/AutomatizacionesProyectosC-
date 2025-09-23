using ApiWalde.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ApiWalde.Datos
{
    public class ParaEmprDatos
    {
        public static string Eliminar(ParaEmprEli ParaEmprElix)
        {
            Codigo Codigos = new Codigo();
            

            string? codi_emex = ParaEmprElix.codi_emex;
            string? codi_paem = ParaEmprElix.codi_paem;
            int codi_empr = ParaEmprElix.codi_empr;

            if (codi_emex == null || codi_emex == "")
            {
                Codigos = new Codigo()
                {
                    Codigos = "-9"                
                };
                return JsonConvert.SerializeObject(Codigos);               
            }

            string existeholding = LeerParametros.ConsultaExisteHolding(codi_emex);

            if (existeholding=="NoExiste" || existeholding == "Error")
            {
                Codigos = new Codigo()
                {
                    Codigos = "-10"
                };
                return JsonConvert.SerializeObject(Codigos);
            }
            if (codi_paem == null || codi_paem == "")
            {
                Codigos = new Codigo()
                {
                    Codigos = "-11"
                };
                return JsonConvert.SerializeObject(Codigos);
                
            }
            if (codi_empr == 0 || codi_empr < 0)
            {
                Codigos = new Codigo()
                {
                    Codigos = "-12"
                };
                return JsonConvert.SerializeObject(Codigos);
                
            }
            
            string ExisteParametro = LeerParametros.ConsultarDatospara_empr_hold(codi_emex, codi_paem, codi_empr);
            LeerParametros.CerraBD();
            if (ExisteParametro == "NoExiste")
            {
                Codigos = new Codigo()
                {
                    Codigos = "-13"
                };
                return JsonConvert.SerializeObject(Codigos);
                //return "Parametro No Existe en la BaseDatos";

            }
            try
            {
                string sql = "QA_01_ELIMINA_PARA_EMPR_HOLD";
                LeerParametros.AbrirBD();
                SqlCommand cmd = new SqlCommand(sql, LeerParametros.ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codi_emex", codi_emex);
                cmd.Parameters.AddWithValue("@codi_paem", codi_paem);
                cmd.Parameters.AddWithValue("@codi_empr", codi_empr);
                cmd.ExecuteNonQuery();
                LeerParametros.CerraBD();
                var successResponse = new
                {
                    Codigos = "Parametro "+ codi_paem + " Eliminado correctamente",
                };
                return JsonConvert.SerializeObject(successResponse);
            }
            catch (Exception)
            {
                var ErrorResponse = new
                {
                    Codigos = "-4",
                };
                return JsonConvert.SerializeObject(ErrorResponse);
            }
        }
        public static string Registrar(ParaEmpr ParaEmpr)
        {
            string? codi_emex = ParaEmpr.codi_emex;
            int codi_empr = ParaEmpr.codi_empr;
            string? codi_paem = ParaEmpr.codi_paem;
            string? tipo_como = ParaEmpr.tipo_como;
            string? desc_paem = ParaEmpr.desc_paem;
            string? valo_paem = ParaEmpr.valo_paem;
            string? obli_paem = ParaEmpr.obli_paem;

            if (codi_emex == null || codi_emex == "")
            {
                return "-5";
            }
            if (codi_empr == 0 || codi_empr < 0)
            {
                return "-6";
            }
            if (codi_paem == null || codi_paem == "")
            {
                return "-7";
            }
            if (tipo_como == null || tipo_como == "")
            {
                return "-8";
            }
            if (desc_paem == null || desc_paem == "")
            {
                return "-9";
            }
            if (valo_paem == null || valo_paem == "")
            {
                return "-10";
            }
            if (obli_paem == null || obli_paem == "")
            {
                return "-11";
            }

            string ExisteParametro = LeerParametros.ConsultarDatospara_empr_hold(codi_emex, codi_paem, codi_empr);
            LeerParametros.CerraBD();
            if (ExisteParametro == "Existe")

            {
                return "-12";

            }
            if (ExisteParametro == "Error")

            {
                return "-13";

            }
            string ExisteHoldig=LeerParametros.ConsultaExisteHolding(codi_emex);
            if (ExisteHoldig == "NoExiste" || ExisteHoldig == "Error")
            {
                return "-14";
            }
          
          
            string sql = "QA_01_INSERTA_PARA_EMPR_HOLD";
            try
            {

                LeerParametros.AbrirBD();
                SqlCommand cmd = new SqlCommand(sql, LeerParametros.ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codi_emex", codi_emex);
                cmd.Parameters.AddWithValue("@codi_paem", codi_paem);
                cmd.Parameters.AddWithValue("@codi_empr", codi_empr);
                cmd.Parameters.AddWithValue("@valo_paem", valo_paem);
                cmd.Parameters.AddWithValue("@tipo_como", tipo_como);
                cmd.Parameters.AddWithValue("@desc_paem", desc_paem);
                cmd.Parameters.AddWithValue("@obli_paem", obli_paem);

                cmd.ExecuteNonQuery();
                LeerParametros.CerraBD();
                return "Parametro " + codi_paem + " insertado correctamente";


            }
            catch (Exception)
            {
                LeerParametros.CerraBD();
                return "0";
            }

        }
        public static string Modificar(ParaEmprEXP ParaEmpr)
        {
            Listar();
            string? codi_emex = ParaEmpr.codi_emex;
            string? codi_paem = ParaEmpr.codi_paem;
            int codi_empr = ParaEmpr.codi_empr;
            string? valo_paem = ParaEmpr.valo_paem;

            try
            {

                if (codi_emex == null || codi_emex == "")
                {
                    return "-5";
                }
                if (codi_paem == null || codi_paem == "")
                {
                    return "-6";
                }
                if (codi_empr == 0 || codi_empr < 0)
                {
                    return "-7";
                }
                if (valo_paem == null || valo_paem == "")
                {
                    return "-8";
                }
                string existeHolding = LeerParametros.ConsultarDatospara_empr_hold(codi_emex, codi_paem, codi_empr);

                if (existeHolding == "NoExiste")
                {
                    return "-9";
                }
                if (existeHolding == "Error")
                {
                    return "-10";
                }
                
                else
                {
                    if (LeerParametros.ConsultarDatospara_empr_hold(codi_emex, codi_paem, codi_empr) == "Existe")
                    {
                        string sql = "QA_01_ACTUALIZA_PARA_EMPR_HOLD";
                        LeerParametros.AbrirBD();
                        SqlCommand cmd = new SqlCommand(sql, LeerParametros.ConectarBD);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@codi_emex", codi_emex);
                        cmd.Parameters.AddWithValue("@codi_paem", codi_paem);
                        cmd.Parameters.AddWithValue("@codi_empr", codi_empr);
                        cmd.Parameters.AddWithValue("@valo_paem", valo_paem);
                        cmd.ExecuteNonQuery();                        
                        LeerParametros.CerraBD();
                        return "Datos Actualizados Correctamente";
                    }
                    else
                        return ("Codi_emex o Parametro no existe en la BD");
                }
            }

            catch (Exception)
            {
                LeerParametros.CerraBD();
                return "-0";
            }

        }
        public static List<ParaEmpr> Listar()
        {
            List<ParaEmpr> oListaParaEmpr = new List<ParaEmpr>();
            string Prc = "QA_01_SELECT_PARA_EMPR";
            try
            {
                LeerParametros.AbrirBD();               
                SqlCommand cmd = new(Prc, LeerParametros.ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    oListaParaEmpr.Add(new ParaEmpr()
                    {
                        codi_emex = dr["codi_emex"].ToString(),
                        codi_empr = Convert.ToInt32(dr["codi_empr"]),
                        codi_paem = dr["codi_paem"].ToString(),
                        tipo_como = dr["tipo_como"].ToString(),
                        desc_paem = dr["desc_paem"].ToString(),
                        valo_paem = dr["valo_paem"].ToString(),
                        obli_paem = dr["obli_paem"].ToString(),
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
        public static ParaEmpr Obtener(string codi_emex,string codi_paem, int codi_empr)
        {
            Listar();
            ParaEmpr oUsuario = new ParaEmpr();
            string sql = "";

            if (codi_paem == "" && codi_emex == "")
            {
                oUsuario = new ParaEmpr()
                {
                    desc_paem = "-5",
                };
                return oUsuario;
            }

            if (codi_emex != "" && codi_paem == "")
            {
                oUsuario = new ParaEmpr()
                {
                    desc_paem = "-6",
                };
                return oUsuario;
            }
            if (codi_emex == "" && codi_paem != "")
            {
                oUsuario = new ParaEmpr()
                {
                    desc_paem = "-7",
                };
                return oUsuario;
            }
            string existeHolding=LeerParametros.ConsultarDatospara_empr_hold(codi_emex,codi_paem,codi_empr);
            
            if (existeHolding == "NoExiste" )
            {
                oUsuario = new ParaEmpr()
                {
                    desc_paem = "-8",
                };
                return oUsuario;
            }
            if (existeHolding == "Error")
            {
                oUsuario = new ParaEmpr()
                {
                    desc_paem = "-9",
                };
                return oUsuario;
            }
            if (codi_empr == 0 || codi_empr < 0)
            {
                oUsuario = new ParaEmpr()
                {
                    desc_paem = "-10",
                };
                return oUsuario;
            }
            if (codi_emex != "" && codi_paem != "" && codi_empr > 0)
            {
                sql = "QA_01_SELECT_PARA_EMPR_CODI_PAEM_HOLD";
            }

            try
            {
                LeerParametros.AbrirBD();
                SqlCommand cmd = new SqlCommand(sql, LeerParametros.ConectarBD);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@codi_emex", codi_emex);
                cmd.Parameters.AddWithValue("@codi_paem", codi_paem);
                cmd.Parameters.AddWithValue("@codi_empr", codi_empr);
                cmd.ExecuteNonQuery();
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    oUsuario = new ParaEmpr()
                    {
                        codi_emex = dr["codi_emex"].ToString(),
                        codi_empr = Convert.ToInt32(dr["codi_empr"]),
                        codi_paem = dr["codi_paem"].ToString(),
                        tipo_como = dr["tipo_como"].ToString(),
                        desc_paem = dr["desc_paem"].ToString(),
                        valo_paem = dr["valo_paem"].ToString(),
                        obli_paem = dr["obli_paem"].ToString(),
                    };
                }
                LeerParametros.CerraBD();
                return oUsuario;
            }
            catch (Exception)
            {
                LeerParametros.CerraBD();
                return oUsuario;
            }
        }

    }
}
