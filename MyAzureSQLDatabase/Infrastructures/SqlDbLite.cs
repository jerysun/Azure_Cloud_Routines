using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAzureSQLDatabase.Infrastructures
{
    public class SqlDbLite
    {
        private static string connString = string.Empty;

        public string ConnString
        {
            get
            {
                return connString;
            }
        }

        public SqlDbLite(string key)
        {
            connString = GetConnString(key);
        }

        private static string GetConnString(string key)
        {
            if (key.Equals("connString") && !string.IsNullOrEmpty(connString))
                return connString;

            try
            {
                NameValueCollection appSettings = ConfigurationManager.AppSettings;
                string[] values = appSettings.GetValues(key);
                return connString = values[0];
            }
            catch (ConfigurationErrorsException e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return string.Empty;
            }
        }

        public async Task DoTransactionNonQueryAsync(SqlCommand cmd, SqlConnection conn)
        {
            if (cmd == null || conn == null)
                return;

            try
            {
                conn.Open();
                await cmd.ExecuteNonQueryAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public async Task<SqlDataReader> DoTransactionReaderAsync(SqlCommand cmd, SqlConnection conn)
        {
            if (cmd == null || conn == null)
                return null;

            SqlDataReader dataReader;

            try
            {
                conn.Open();
                dataReader = await cmd.ExecuteReaderAsync();
                return dataReader;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
