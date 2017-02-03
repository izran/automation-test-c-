using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Automation_Test.Utility {
    class Connectdb {
        private static int iCommandTimeOut = 30;
        public static int CommandTimeOut { get { return iCommandTimeOut; } set { iCommandTimeOut = value; } }


        public static SqlDataReader Query(string pSql) {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringMssql"]);
            conn.Open();
            SqlCommand cmd = new SqlCommand(pSql, conn);
            cmd.CommandTimeout = iCommandTimeOut;
            try {
                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (SqlException ex) {
                string sMessage = "";
                if (ex != null) {
                    if (ex.InnerException != null) {
                        sMessage = ex.InnerException.Message;
                    }
                    else sMessage = ex.Message;
                }

                throw ex;
                // return null;
            }
        }

        public static int Execute(string pSql) {

            SqlConnection conn = new SqlConnection(ConfigurationManager.AppSettings["ConnectionStringMssql"]);
            conn.Open();

            SqlCommand cmd = new SqlCommand(pSql, conn);
            cmd.CommandTimeout = iCommandTimeOut;
            int iRecordsAffected = -1; //cmd.ExecuteNonQuery();
            try {
                iRecordsAffected = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) {
                string sMessage = "";
                if (ex != null) {
                    if (ex.InnerException != null) {
                        sMessage = ex.InnerException.Message;
                    }
                    else sMessage = ex.Message;
                }

                conn.Close();
                throw ex;
                // return -1;
            }
            conn.Close();
            return iRecordsAffected;
        }

        public static string GetStringSingleValue(string strQuery) {

            System.Data.SqlClient.SqlDataReader TempData = Query(strQuery);
            try {
                if (TempData.Read()) {
                    return TempData[0].ToString();
                }
                else {
                    return "";
                }
            }
            catch (SqlException ex) {
                string sMessage = "";
                if (ex != null) {
                    if (ex.InnerException != null) {
                        sMessage = ex.InnerException.Message;
                    }
                    else sMessage = ex.Message;
                }
                throw ex;
                //return null;
            }
            finally {
                if (!TempData.IsClosed) {
                    TempData.Close();
                }
            }
        }


        public static MySqlDataReader QueryMysql(string pSql) {

            try {
                var conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = ConfigurationManager.AppSettings["ConnectionStringMysql"];
                conn.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = pSql;
                cmd.Connection = conn;
                cmd.CommandType = CommandType.Text;
                return cmd.ExecuteReader();
            }
            catch (Exception ex) {
                string sMessage = "";
                if (ex != null) {
                    if (ex.InnerException != null) {
                        sMessage = ex.InnerException.Message;
                    }
                    else sMessage = ex.Message;
                }

                throw ex;
                // return null;
            }
        }

    }
}
