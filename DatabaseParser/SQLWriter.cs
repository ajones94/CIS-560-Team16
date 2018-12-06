using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseParser
{
    class SQLWriter
    {

        public SQLWriter()
        {
        }

        /// <summary>
        /// This writes the Datatable data to the SQL server.
        /// </summary>
        /// <param name="dataFromCSVFile"></param>
        public void WriteSQLDataToServer(DataTable dataFromCSVFile)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=COUKDB02\\MSSQLSERVER2017;Initial Catalog=Five9;Integrated Security=SSPI;"))
            {
                SqlBulkCopy bc = new SqlBulkCopy(dbConnection.ConnectionString, SqlBulkCopyOptions.TableLock);
                bc.DestinationTableName = "dbo.Call_Log_Latest";
                try
                {
                    bc.BatchSize = dataFromCSVFile.Rows.Count;
                    dbConnection.Open();
                    bc.WriteToServer(dataFromCSVFile);
                    bc.Close();
                    dbConnection.Close();
                    emailSender.SendSuccessMessage();
                }
                catch (SqlException e)
                {
                    emailSender.SendFailureMessage(e);
                    Console.WriteLine(e);
                }
            }
        }
    }
}
