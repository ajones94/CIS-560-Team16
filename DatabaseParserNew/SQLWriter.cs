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
        public void WriteToMovies(DataTable dataFromCSVFile)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team16;Integrated Security=True;"))
            {
                SqlBulkCopy bc = new SqlBulkCopy(dbConnection.ConnectionString, SqlBulkCopyOptions.TableLock);
                bc.DestinationTableName = "gp.Movies";
                try
                {
                    DataRow test = dataFromCSVFile.Rows[0];
                    if (Int32.TryParse(dataFromCSVFile.Rows[0].ItemArray[2].ToString(), out int s) == false || Int32.TryParse(dataFromCSVFile.Rows[0].ItemArray[3].ToString(), out int a) == false)
                    {
                        throw new Exception();
                    }
                    bc.BatchSize = dataFromCSVFile.Rows.Count;
                    dbConnection.Open();
                    bc.WriteToServer(dataFromCSVFile);
                    bc.Close();
                    dbConnection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// This writes the Datatable data to the SQL server.
        /// </summary>
        /// <param name="dataFromCSVFile"></param>
        public void WriteToRating(DataTable dataFromCSVFile)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team16;Integrated Security=True;"))
            {
                SqlBulkCopy bc = new SqlBulkCopy(dbConnection.ConnectionString, SqlBulkCopyOptions.TableLock);
                bc.DestinationTableName = "gp.Rating";
                try
                {
                    bc.BatchSize = dataFromCSVFile.Rows.Count;
                    dbConnection.Open();
                    bc.WriteToServer(dataFromCSVFile);
                    bc.Close();
                    dbConnection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// This writes the Datatable data to the SQL server.
        /// </summary>
        /// <param name="dataFromCSVFile"></param>
        public void WriteToGenre(DataTable dataFromCSVFile)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team16;Integrated Security=True;"))
            {
                SqlBulkCopy bc = new SqlBulkCopy(dbConnection.ConnectionString, SqlBulkCopyOptions.TableLock);
                bc.DestinationTableName = "gp.Genre";
                try
                {
                    bc.BatchSize = dataFromCSVFile.Rows.Count;
                    dbConnection.Open();
                    bc.WriteToServer(dataFromCSVFile);
                    bc.Close();
                    dbConnection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// This writes the Datatable data to the SQL server.
        /// </summary>
        /// <param name="dataFromCSVFile"></param>
        public void WriteToRegion(DataTable dataFromCSVFile)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team16;Integrated Security=True;"))
            {
                SqlBulkCopy bc = new SqlBulkCopy(dbConnection.ConnectionString, SqlBulkCopyOptions.TableLock);
                bc.DestinationTableName = "gp.Region";
                try
                {
                    bc.BatchSize = dataFromCSVFile.Rows.Count;
                    dbConnection.Open();
                    bc.WriteToServer(dataFromCSVFile);
                    bc.Close();
                    dbConnection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// This writes the Datatable data to the SQL server.
        /// </summary>
        /// <param name="dataFromCSVFile"></param>
        public void WriteToDirector(DataTable dataFromCSVFile)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team16;Integrated Security=True;"))
            {
                SqlBulkCopy bc = new SqlBulkCopy(dbConnection.ConnectionString, SqlBulkCopyOptions.TableLock);
                bc.DestinationTableName = "gp.Director";
                try
                {
                    bc.BatchSize = dataFromCSVFile.Rows.Count;
                    dbConnection.Open();
                    bc.WriteToServer(dataFromCSVFile);
                    bc.Close();
                    dbConnection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// This writes the Datatable data to the SQL server.
        /// </summary>
        /// <param name="dataFromCSVFile"></param>
        public void WriteToActor(DataTable dataFromCSVFile)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team16;Integrated Security=True;"))
            {
                SqlBulkCopy bc = new SqlBulkCopy(dbConnection.ConnectionString, SqlBulkCopyOptions.TableLock);
                bc.DestinationTableName = "gp.Actor";
                try
                {
                    bc.BatchSize = dataFromCSVFile.Rows.Count;
                    dbConnection.Open();
                    bc.WriteToServer(dataFromCSVFile);
                    bc.Close();
                    dbConnection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// This writes the Datatable data to the SQL server.
        /// </summary>
        /// <param name="dataFromCSVFile"></param>
        public void WriteToFinancial(DataTable dataFromCSVFile)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team16;Integrated Security=True;"))
            {
                SqlBulkCopy bc = new SqlBulkCopy(dbConnection.ConnectionString, SqlBulkCopyOptions.TableLock);
                bc.DestinationTableName = "gp.Financial";
                try
                {
                    bc.BatchSize = dataFromCSVFile.Rows.Count;
                    dbConnection.Open();
                    bc.WriteToServer(dataFromCSVFile);
                    bc.Close();
                    dbConnection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
        /// <summary>
        /// This writes the Datatable data to the SQL server.
        /// </summary>
        /// <param name="dataFromCSVFile"></param>
        public void WriteToAdditionalInfo(DataTable dataFromCSVFile)
        {
            using (SqlConnection dbConnection = new SqlConnection("Data Source=mssql.cs.ksu.edu;Initial Catalog=cis560_team16;Integrated Security=True;"))
            {
                SqlBulkCopy bc = new SqlBulkCopy(dbConnection.ConnectionString, SqlBulkCopyOptions.TableLock);
                bc.DestinationTableName = "gp.AdditionalInfo";
                try
                {
                    bc.BatchSize = dataFromCSVFile.Rows.Count;
                    dbConnection.Open();
                    bc.WriteToServer(dataFromCSVFile);
                    bc.Close();
                    dbConnection.Close();
                }
                catch (SqlException e)
                {
                    Console.WriteLine(e);
                }
            }
        }
    }
}
