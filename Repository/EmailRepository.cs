using Automation_Test.Model;
using Automation_Test.Utility;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation_Test.Repository {
    public class EmailRepository {

        #region "Queries"

        public static List<Email> Get(int pDBType =0) {
            List<Email> oEmailList = new List<Email>();
            switch (pDBType) {
                case 0://xls
                    oEmailList = LoadFromXLS();
                    break;
                case 1://mysql
                    oEmailList = LoadFromMySql();
                    break;
                case 2://mongodb
                    oEmailList = LoadFromMongoDB();
                    break;
                case 3://MSSQL
                    oEmailList = LoadFromMSSql();
                    break;
            }

            return oEmailList;
        }

        private static List<Email> LoadFromMSSql() {
            List<Email> oEmailList = new List<Email>();
            using (var reader = Connectdb.Query("SELECT * FROM YahooEmails")) {
                if (reader.HasRows) {
                    while (reader.Read()) {
                        Email oEmail = new Email();
                        oEmail.ToEmail = !reader.IsDBNull(reader.GetOrdinal("ToEmail")) ? reader["ToEmail"].ToString() : "";
                        oEmail.Subject = !reader.IsDBNull(reader.GetOrdinal("Subject")) ? reader["Subject"].ToString() : "";
                        oEmail.Body = !reader.IsDBNull(reader.GetOrdinal("Body")) ? reader["Body"].ToString() : "";
                        oEmailList.Add(oEmail);
                    }
                }
                reader.Close();
            }
            return oEmailList;
        }

        private static List<Email> LoadFromMySql() {
            List<Email> oEmailList = new List<Email>();
            using (var reader = Connectdb.QueryMysql("SELECT * FROM emailstosend")) {
                if (reader.HasRows) {
                    while (reader.Read()) {
                        Email oEmail = new Email();
                        oEmail.ToEmail = !reader.IsDBNull(reader.GetOrdinal("email")) ? reader["email"].ToString() : "";
                        oEmail.Subject = !reader.IsDBNull(reader.GetOrdinal("subject")) ? reader["subject"].ToString() : "";
                        oEmail.Body = !reader.IsDBNull(reader.GetOrdinal("body")) ? reader["body"].ToString() : "";
                        oEmailList.Add(oEmail);
                    }
                }
                reader.Close();
            }
            return oEmailList;
        }

        private static List<Email> LoadFromXLS() {
            List<Email> oEmailList = new List<Email>();

            using (OleDbConnection connection = new OleDbConnection(ConfigurationManager.AppSettings["ConnectionStringXLS"])) {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection);
                OleDbDataAdapter adap = new OleDbDataAdapter(command);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                if (ds.Tables.Count >= 1) {
                    foreach (DataRow reader in ds.Tables[0].Rows) {
                        //                        TextBox1.Text = row["ImagePath"].ToString();
                        Email oEmail = new Email();
                        oEmail.ToEmail = reader["ToEmail"].ToString();
                        oEmail.Subject = reader["Subject"].ToString();
                        oEmail.Body = reader["Body"].ToString();
                        oEmailList.Add(oEmail);
                    }
                }
            }

            return oEmailList;
        }

        private static List<Email> LoadFromMongoDB() {
            List<Email> oEmailList = new List<Email>();
            var oMongoClient = new MongoClient(ConfigurationManager.AppSettings["ConnectionStringMongoDb"]);
            var db = oMongoClient.GetDatabase("demo3");

            var collection = db.GetCollection<SendEmailMongodb>("emailstosend");
            var filter = Builders<SendEmailMongodb>.Filter.Empty;
            var list = collection.Find(filter).ToList();

            foreach (var oEmailMDb in list) {
                Email oEmail = new Email();
                oEmail.ToEmail = oEmailMDb.email;
                oEmail.Subject = oEmailMDb.subject;
                oEmail.Body = oEmailMDb.body;
                oEmailList.Add(oEmail);
            };
            return oEmailList;
        }
        #endregion
    }


}
