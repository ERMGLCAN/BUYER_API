using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace wsApiAutofin.Services
{
    public class HelperSql
    {
        private static SqlConnection GetConnection()
        {
            SqlConnection cnn = null;
            try
            {
                //cnn = new SqlConnection("Data Source=EROMEROM-PC\\SQLEXPRESS;Initial Catalog=Buyer;Integrated Security=True");
                cnn = new SqlConnection("Data Source=10.5.4.34,49170;Initial Catalog=Buyer;Persist Security Info=True;User ID=eromerom;Password=Mhn11021412");
                return cnn;

            }
            catch (Exception _e)
            {

                Console.WriteLine(_e.Message);
            }
            return cnn;

        }


        public static DataSet ObtieneDataSet(string sStoredProcedure, params object[] ArrayParametros)
        {
            SqlConnection cnn = new SqlConnection();

            SqlCommand comm = null;
            SqlDataAdapter adp = null;
            DataSet ds = new DataSet();
            try
            {
                cnn = GetConnection();
                cnn.Open();
                comm = GetCommand(cnn, sStoredProcedure, CommandType.StoredProcedure);
                PutParametersCommand(ref comm, ArrayParametros);
                adp = GetAdapter(comm);
                adp.Fill(ds, "<TGeneric>");
            }
            catch (SqlException exSQL)
            {
                throw exSQL;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (!(adp == null))
                {
                    adp.Dispose();
                }

                if (!(comm == null))
                {
                    comm.Dispose();
                }

                if (cnn != null)
                {
                    if ((cnn.State == ConnectionState.Open))
                    {
                        cnn.Close();
                    }

                    cnn.Dispose();
                }

            }

            return ds;
        }

        private static SqlCommand GetCommand(SqlConnection sqlConn, string sQuery, CommandType tipo)
        {
            SqlCommand cmd = new SqlCommand(sQuery, sqlConn);
            cmd.CommandType = tipo;
            return cmd;
        }

        private static void PutParametersCommand(ref SqlCommand comm, object[] parametters)
        {
            char delimiter = Convert.ToChar(".");
            int indexparam = 0;
            SqlCommandBuilder.DeriveParameters(comm);
            foreach (SqlParameter p in comm.Parameters)
            {
                if ((p.Direction == ParameterDirection.Input))
                {
                    if (!(parametters[indexparam] == null))
                    {

                        if (parametters[indexparam].GetType() == typeof(DataTable))
                        {

                            p.TypeName = p.TypeName.ToString().Split(delimiter).Last();
                            p.SqlDbType = SqlDbType.Structured;
                        }

                    }
                    else
                    {
                        //parametters[indexparam] = "";
                        parametters[indexparam] = DBNull.Value;
                    }
                    p.SqlValue = parametters[indexparam];
                    indexparam += 1;

                }
            }

        }

        private static SqlDataAdapter GetAdapter(SqlCommand comm)
        {
            SqlDataAdapter adp = new SqlDataAdapter(comm);
            return adp;
        }
    }
}