using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DatabaseParser
{
    class Controller
    {
        string[] callLogFiles;

        public Controller()
        {
            
        }

        /// <summary>
        /// This controls the flow of the program.
        /// </summary>
        public void StartProgram()
        {
            GetFiles();
            foreach (string fileName in callLogFiles)
            {
                DataWorker callLogWorker = new DataWorker(fileName);
                DataTable dataFromCSV = callLogWorker.GetDataTableFromCSVFile();
                SQLWriter databaseWorker = new SQLWriter();
                databaseWorker.WriteSQLDataToServer(dataFromCSV);
            }
            //deleteFiles(); I believe that the Five9 will overwrite the file so this is uneeded.
        }

        /// <summary>
        /// This method is only used for testing the program.
        /// </summary>
        public void TestProgram()
        {
            //SQLWriter databaseWorker = new SQLWriter(emailHandler);
            //DataTable emptyTable = new DataTable();
            //databaseWorker.WriteSQLDataToServer(emptyTable);
           // emailHandler.SendSuccessMessage();
        }

        /// <summary>
        /// This gets all of the files to be inserted into the database. The paths and names here need to be changed to reflect the desired outcome
        /// </summary>
        private void GetFiles()
        {
            string partialName = "Call_Log";
            //callLogFiles = Directory.GetFiles(@"C:\Users\iriley.adm\Downloads\Five9DatabaseWCD\CSVFiles", "*" + partialName + "*.*");
            try
            {
                callLogFiles = Directory.GetFiles(@"\\COUKAP01\Recordings\reports", "*" + partialName + "*.*");
                //callLogFiles = Directory.GetFiles(@"C:\\Users\iriley.adm\Downloads\Five9DatabaseWCD\CSVFiles", "*" + partialName + "*.*");
            }
            catch (Exception ex)
            {
                //emailHandler.SendFailureMessage(ex);
            }
        }

        /// <summary>
        /// This deletes all of the files that were added to the database to ensure that there is no overlap of data on next run.
        /// </summary>
        private void deleteFiles()
        {
            foreach (string file in callLogFiles)
            {
                //This will delete all of the files that have been used.
                try
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }
                catch (Exception ex)
                {
                    //emailHandler.SendFailureMessage(ex);
                }
            }
        }
    }
}
