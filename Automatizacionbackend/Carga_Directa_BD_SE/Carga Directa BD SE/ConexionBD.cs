using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Collections;
using System.Collections.Generic;

namespace Carga_Directa_BD_SE
{
    class ConexionBD
    {
        public SqlConnection ConectarBD = new SqlConnection();
        public OracleConnection conexionOracles = new OracleConnection();
        public String QueryORACLE = "";
      


        #region SQLSERVER

        public ConexionBD(String Plataforma = "")
        {
            if (Plataforma == "SQL")
            {
                LeerParametros.LeeParamConfig();
                ConectarBD.ConnectionString = LeerParametros.ConexionSQL;
            }
            else if (Plataforma == "CLOUD")
            {
                LeerParametros.LeeParamConfig();
                ConectarBD.ConnectionString = LeerParametros.ConexionCLOUD;
            }
            else if (Plataforma == "SQLCF")
            {
                LeerParametros.LeeParamConfig();
                ConectarBD.ConnectionString = LeerParametros.ConexionSQLCF;
            }
            else if (Plataforma == "CLOUDCF")
            {
                LeerParametros.LeeParamConfig();
                ConectarBD.ConnectionString = LeerParametros.ConexionCLOUDCF;
            }

        }

        public void abrirBD()
        {
            try
            {
                ConectarBD.Open();

               // MessageBox.Show("Conexion Abierta");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Conexion ", ex.Message);
            }
        }
        public void CerraBD()
        {
            ConectarBD.Close();
        }
        public void EjecutarSql(String Query, int folio = 0)
        {
      
            try
            {
                SqlCommand MiComando = new SqlCommand(Query, ConectarBD);
                MiComando.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                //MessageBox.Show("Folio " + folio + "  Repetido, error al insertar "); Se quita ya que, no necesariamente es por folio repetido
                MessageBox.Show("Error SQL de EjecutarSql: " + ex.Message); //Se deja el error sql ya que es una app para uso de QA

            }
        }

        public void EjecutarSqlCF(String Query, Int32 folio = 0)
        {
           
            try
            {
                SqlCommand MiComando = new SqlCommand(Query, ConectarBD);
                MiComando.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                //MessageBox.Show("Folio " + folio + "  Repetido, error al insertar "); Se quita ya que, no necesariamente es por folio repetido
                MessageBox.Show("Error SQL de EjecutarSql: " + ex.Message); //Se deja el error sql ya que es una app para uso de QA
            }
        }

        public string  DevolverCorr_arch()
        {
            string h = "";
            string sql = "select top 1 CORR_ARCH from ARCH_DTE_INFO_SII where  NOMB_ARCH='InsertDirecto' order by CORR_ARCH desc";

            SqlCommand cmd = new SqlCommand(sql, ConectarBD);
            SqlDataReader dato = cmd.ExecuteReader();
                if (dato.Read()) {
                    h = dato["CORR_ARCH"].ToString();               
                }
            return h;
        }

    #endregion


    public void ConexionOracle()
        {


            try
            {
                LeerParametros.LeeParamConfig();
                OracleConnection conexionOracle = new OracleConnection(LeerParametros.ConexionORACLE);
                conexionOracle.Open();

                if (conexionOracle.State == ConnectionState.Open)
                {
                 
                    conexionOracle.Close();
                }

            }
            catch (Exception ex)
            {
                //Mensaje de Error en caso de no establecer conexión
                MessageBox.Show("No se realizar la conexion. Error ORACLE : "+ ex);
            }
        }
        public void CerrarBDOracle()
        {
            conexionOracles.Close();
        }

        public void EjecutaQueryOracle(string InsertOracle)
        {
            LeerParametros.LeeParamConfig();
            using (OracleConnection connection = new OracleConnection(LeerParametros.ConexionORACLE))
            {
                connection.Open();
                OracleCommand command = connection.CreateCommand();
                OracleTransaction transaction;
                transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
                command.Transaction = transaction;
                try
                {
                    command.CommandText = InsertOracle;
                    command.ExecuteNonQuery();
                    transaction.Commit();
                   // MessageBox.Show("Insertado.");
                }
                catch (Exception e)
                {
                    transaction.Rollback();
                    Console.WriteLine(e.ToString());
                    MessageBox.Show("error al insertar.");
                }
                connection.Close();
            }
        }

        public ArrayList SelectErpORACLE(String queryBDSQL)
        {
            try
            {
                LeerParametros.LeeParamConfig();
                using (OracleConnection connection = new OracleConnection(LeerParametros.ConexionORACLE))
                {
                    OracleCommand command = new OracleCommand(queryBDSQL, connection);
                    connection.Open();
                    ArrayList items = new ArrayList();
                    using (OracleDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            items.Add(reader.GetDecimal(13) + "-" + reader.GetString(14) + "," + reader.GetDecimal(1) + "," + reader.GetDecimal(2)
                            + "," + reader.GetString(7) + "," + reader.GetDecimal(35));

                        }
                        connection.Close();
                        return items;
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
                return null;
            }
        }
        public ArrayList SelectErpSQL(String queryBDSQL)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(queryBDSQL, ConectarBD);
                SqlDataReader reader = cmd.ExecuteReader();
                ArrayList items = new ArrayList();
                while (reader.Read())
                {
                    items.Add(reader.GetDecimal(13) + "-" + reader.GetString(14) + "," + reader.GetDecimal(1) + "," + reader.GetDecimal(2)
                    + "," + reader.GetString(7) + "," + reader.GetDecimal(35));
                }
                CerraBD();
                return items;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
                return null;
            }

        }
        public ArrayList SelectErpCLOUD(String queryBDSQL)
        {
            try
            {

                SqlCommand cmd = new SqlCommand(queryBDSQL, ConectarBD);
                SqlDataReader reader = cmd.ExecuteReader();
                ArrayList items = new ArrayList();
                while (reader.Read())
                {
                    items.Add(reader.GetDecimal(14) + "-" + reader.GetString(15) + "," + reader.GetDecimal(2) + "," + reader.GetDecimal(3)
                     + "," + reader.GetString(8) + "," + reader.GetDecimal(36));
                }
                CerraBD();
                return items;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
                return null;
            }

        }

        public String recupera_dato(String queryBDSQL)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(queryBDSQL, ConectarBD);
                var reader = cmd.ExecuteReader();
                String Dato = "";

                while (reader.Read())
                {
                    Dato=reader.GetString(0);
                }
                
                return Dato;
            }
            catch (SqlException e)
            {
                Console.WriteLine("Error SQL: " + e.Message);
                return "";
            }

        }

        public decimal recupera_dato_recimal(String queryBDSQL)
        {
            decimal Dato = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(queryBDSQL, ConectarBD);
                var reader = cmd.ExecuteReader();
                

                while (reader.Read())
                {
                    Dato = reader.GetDecimal(0);
                }

                return Dato;
            }
            catch (SqlException e)
            {
                Dato = 0;
                Console.WriteLine("Error SQL: " + e.Message);
                return Dato;
            }

        }
    }
}
