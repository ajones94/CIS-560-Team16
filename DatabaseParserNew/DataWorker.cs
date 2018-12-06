using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseParser
{
    class DataWorker
    {
        /// <summary>
        /// This holds the csv data to import into SQL.
        /// </summary>
        public DataTable movieTable;
        public DataTable directorTable;
        public DataTable financialTable;
        public DataTable actorTable;
        public DataTable genreTable;
        public DataTable regionTable;
        public DataTable ratingTable;
        public DataTable randomTable;

        /// <summary>
        /// Getter for the csvData to use in the SQL class.
        /// </summary>
        //public DataTable MovieTable
        //{
        //    get {
        //        ;
        //}
        //public DataTable DirectorTable
        //{
        //    get;
        //}
        //public DataTable ActorTable
        //{
        //    get;
        //}
        //public DataTable GenreTable
        //{
        //    get;
        //}
        //public DataTable RegionTable
        //{
        //    get;
        //}
        //public DataTable RatingTable
        //{
        //    get;
        //}
        //public DataTable RandomTable
        //{
        //    get;
        //}
        //public DataTable FinancialTable
        //{
        //    get;
        //}










        /// <summary>
        /// Path to the CSV file.
        /// </summary>
        private string csvFilePath;
        

        public DataWorker(string filePath)
        {
            movieTable = new DataTable();
            directorTable = new DataTable();
            financialTable = new DataTable();
            actorTable = new DataTable();
            genreTable = new DataTable();
            regionTable = new DataTable();
            ratingTable = new DataTable();
            randomTable = new DataTable();
            csvFilePath = filePath;
        }


        /// <summary>
        /// This table iterates through the CSV file, parses and scrubs it, then adds it to the Datatable
        /// </summary>
        /// <returns>This returns the datatable with all of the columns in it.</returns>
        public void GetDataTableFromCSVFile()
        {
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csvFilePath))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;          //configuration for the reading of the file  
                    string[] colFields = csvReader.ReadFields();
                    InitializeDataTableTypes();
                    int movieID = 0;
                    List<String[]> databaseRows = new List<string[]>();
                    while (!csvReader.EndOfData)
                    {
                        
                        string[] fieldDataMovies = new string[5]; //Done    
                        string[] fieldDataRating = new string[4]; //Done
                        string[] fieldDataRegion = new string[4]; //Done
                        string[] fieldDataDirector = new string[4]; //Done
                        string[] fieldDataActor1 = new string[4]; //Done    
                        string[] fieldDataActor2 = new string[4]; //Done
                        string[] fieldDataActor3 = new string[4]; //Done
                        string[] fieldDataFinancial = new string[4]; //Done
                        string[] fieldDataAdditionalInfo = new string[5];
                        string[] fieldData = csvReader.ReadFields();
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            //fieldDataMovies = new string[4];
                            //fieldDataRating = new string[3];
                            //fieldDataRegion = new string[3];
                            //fieldDataDirector = new string[3];
                            //fieldDataActor1 = new string[3];
                            //fieldDataActor2 = new string[3];
                            //fieldDataActor3 = new string[3];
                            //fieldDataFinancial = new string[3];
                            //fieldDataAdditionalInfo = new string[4];
                            switch (i)
                            {
                                


                                case 0:
                                    //if(movieID == 1)
                                    //{
                                    //    break;
                                    //}
                                    //else
                                    //{
                                        fieldDataMovies[0] = movieID.ToString();
                                        fieldDataMovies[1] = fieldData[i];
                                        movieID++;
                                    //}
                                    
                                    continue;
                                case 1:
                                    if(movieID == 224 || movieID == 356 || movieID == 663 || movieID == 673 || movieID == 1744 || movieID == 44) {
                                        fieldDataDirector[0] = movieID.ToString();
                                        fieldDataDirector[1] = "0";
                                        fieldDataDirector[2] = "Mc";
                                        fieldDataDirector[3] = "G";
                                    }
                                    else
                                    {
                                        string[] breakUpName = BreakUpNameString(fieldData[i]);
                                        fieldDataDirector[0] = movieID.ToString();
                                        fieldDataDirector[1] = "0";
                                        fieldDataDirector[2] = breakUpName[0];
                                        fieldDataDirector[3] = breakUpName[1];
                                    }
                                    continue;
                                case 2:
                                    string[] breakUpName2 = BreakUpNameString(fieldData[i]);
                                    fieldDataActor1[0] = movieID.ToString();
                                    fieldDataActor1[1] = "0";
                                    fieldDataActor1[2] = breakUpName2[0];
                                    fieldDataActor1[3] = breakUpName2[1];
                                    continue;
                                case 3:
                                    string[] breakUpName3 = BreakUpNameString(fieldData[i]);
                                    fieldDataActor3[0] = movieID.ToString();
                                    fieldDataActor3[1] = "0";
                                    fieldDataActor3[2] = breakUpName3[0];
                                    fieldDataActor3[3] = breakUpName3[1];
                                    continue;
                                case 4:
                                    string[] breakUpName4 = BreakUpNameString(fieldData[i]);
                                    fieldDataActor2[0] = movieID.ToString();
                                    fieldDataActor2[1] = "0";
                                    fieldDataActor2[2] = breakUpName4[0];
                                    fieldDataActor2[3] = breakUpName4[1];
                                    continue;
                                case 5:
                                    if(int.TryParse(fieldData[i], out int n) == false)
                                    {
                                        fieldDataMovies[3] = "0";
                                    }
                                    else
                                    {
                                        fieldDataMovies[3] = fieldData[i];
                                    }
                                    continue;
                                case 6:
                                    fieldDataMovies[4] = fieldData[i];
                                    continue;
                                case 7:
                                    fieldDataFinancial[0] = "0";
                                    fieldDataFinancial[1] = movieID.ToString();
                                    if(fieldData[i] == "")
                                    {
                                        fieldDataFinancial[3] = "0";
                                    }
                                    else
                                    {
                                        fieldDataFinancial[3] = fieldData[i];
                                    }
                                    continue;
                                case 8:
                                    if (fieldData[i] == "")
                                    {
                                        fieldDataFinancial[2] = "0";
                                    }
                                    else {
                                        fieldDataFinancial[2] = fieldData[i];
                                    }
                                    continue;
                                case 9:
                                    fieldDataRating[0] = "0";
                                    fieldDataRating[1] = fieldData[i];
                                    fieldDataRating[3] = movieID.ToString();
                                    continue;
                                case 10:
                                    fieldDataRating[2] = fieldData[i];
                                    continue;
                                case 11:
                                    if(fieldData[i] == "" || int.TryParse(fieldData[i], out int s) == false)
                                    {
                                        fieldDataMovies[2] = "0";
                                    }
                                    else
                                    {
                                        fieldDataMovies[2] = fieldData[i];
                                    }
                                    continue;
                                case 12:
                                    string[] genres = BreakUpGenres(fieldData[i]);
                                    string[] temp = new string[3];
                                    for(int k = 0; k < genres.Length; k++)
                                    {
                                        temp[0] = movieID.ToString();
                                        temp[1] = "0";
                                        temp[2] = genres[k];
                                        genreTable.Rows.Add(temp);
                                        //databaseRows.Add(temp); //Add this here because we know it's full and we don't know how many there are
                                    }
                                    continue;
                                case 13:
                                    continue;
                                case 14:
                                    fieldDataAdditionalInfo[0] = "0";
                                    fieldDataAdditionalInfo[1] = movieID.ToString();
                                    fieldDataAdditionalInfo[2] = fieldData[i];
                                    continue;
                                case 15:
                                    fieldDataRegion[0] = "0";
                                    fieldDataRegion[1] = movieID.ToString();
                                    fieldDataRegion[3] = fieldData[i];
                                    continue;
                                case 16:
                                    fieldDataRegion[2] = fieldData[i];
                                    continue;

                                case 17:
                                    fieldDataAdditionalInfo[4] = fieldData[i];
                                    continue;
                                case 18:
                                    fieldDataAdditionalInfo[3] = fieldData[i];
                                    break;
                                default:
                                    break;
                            }

                            if (fieldDataMovies[0] == null)
                            {

                            }
                            else
                            {
                                movieTable.Rows.Add(fieldDataMovies);
                                ratingTable.Rows.Add(fieldDataRating);
                                regionTable.Rows.Add(fieldDataRegion);
                                directorTable.Rows.Add(fieldDataDirector);
                                actorTable.Rows.Add(fieldDataActor1);
                                actorTable.Rows.Add(fieldDataActor2);
                                actorTable.Rows.Add(fieldDataActor3);
                                financialTable.Rows.Add(fieldDataFinancial);
                                randomTable.Rows.Add(fieldDataAdditionalInfo);
                            }
                           
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            //return csvData;
        }


        private string[] BreakUpNameString(string fieldData)
        {
            string[] returner = new string[2];
            returner = fieldData.Split(' ');
            if(returner.Count() < 2)
            {
                string[] temp = new string[2];
                temp[0] = returner[0];
                temp[1] = " ";
                //returner[1] = " ";
                return temp;
            }
            if(returner.Count() > 2 && returner[2] != "Jr.")
            {
                returner[1] = returner[2]; //This is for when the middle name is included.
            }
            return returner;
        }

        private string[] BreakUpGenres(string fieldData)
        {
            string[] returner = fieldData.Split('|');
            return returner;
        }



        /// <summary>
        /// This determines what datatype the column should be, since normally everything would be string. The database has different types that need to change.
        /// This does not set the datatype of the column
        /// </summary>
        /// <param name="columnNumber">This is the column number, how it deceides what the datatype should be.</param>
        /// <returns>Returns the int that signifies the datatype of the column. This is then used later to make the datatype correct.</returns>
        private int returnDataType(int columnNumber)
        {
            if (columnNumber == 6 || columnNumber == 11 || columnNumber == 12)
            {
                //This is int
                return 0;
            }
            else if (columnNumber == 1 || columnNumber == 2 || columnNumber == 3 || columnNumber == 4 || columnNumber == 5 || columnNumber == 7 || columnNumber == 13 || columnNumber == 16 || columnNumber == 17 || columnNumber == 18)
            {
                //this is string
                return 1;
            }
            else if (columnNumber == 8 || columnNumber == 9)
            {
                //This is datetime
                //This is now Bigint   
                return 2;
            }
            else if (columnNumber == 10 || columnNumber == 19)
            {
                //this is time
                //this is now decimal
                return 3;
            }
            else
            {
                return 100;
            }
        }


        /// <summary>
        /// This sets the empty parts of the CSV file to an equalivent value.
        /// </summary>
        /// <param name="i">This is the data value that determines the datatype that it should be.</param>
        /// <returns>Returns a string of the value that should be added to the database.</returns>
        private string DataTypeEmptysInTable(int i)
        {
            switch (returnDataType(i))
            {
                case 0:
                    return "0";
                case 1:
                    return "";
                case 2:
                    DateTime temp = new DateTime(2999, 9, 9);
                    return temp.ToString();
                case 3:
                    TimeSpan tempTime = new TimeSpan();
                    return tempTime.ToString();
                case 4:
                    //DateTime tempDate = new DateTime(2999, 9, 9);
                    DateTime tempDate = new DateTime();
                    return tempDate.ToString();
                case 5:
                    return "0.00";
                case 6:
                    return "0";
                default:
                    return "";
                    break;
            }
        }



        /// <summary>
        /// This initializes the datatypes of the column to ensure that they are properly imported into the database
        /// </summary>
        /// <param name="i">This is the data value that determines which datatype it should be.</param>
        /// <param name="name">This is the name of the column</param>
        //private void InitializeDataTableTypes(int i, string name, DataTable databaseTable)
        private void InitializeDataTableTypes() 
        {
            //Director Table
            for(int j = 0; j < 4 ; j++)
            {
                switch (j)
                {
                    case 0:
                        DataColumn newColumn0 = new DataColumn("MovieID");
                        newColumn0.AllowDBNull = false;
                        directorTable.Columns.Add(newColumn0);
                        newColumn0.DataType = Type.GetType("System.Int32");
                        continue;
                    case 1:
                        DataColumn newColumn02 = new DataColumn("DirectorID");
                        newColumn02.AllowDBNull = false;
                        directorTable.Columns.Add(newColumn02);
                        newColumn02.DataType = Type.GetType("System.Int32");
                        continue;
                    case 2:
                        DataColumn newColumn = new DataColumn("FirstName");
                        newColumn.AllowDBNull = false;
                        directorTable.Columns.Add(newColumn);
                        newColumn.DataType = Type.GetType("System.String");
                        continue;
                    case 3:
                        DataColumn newColumn2 = new DataColumn("LastName");
                        newColumn2.AllowDBNull = false;
                        directorTable.Columns.Add(newColumn2);
                        newColumn2.DataType = Type.GetType("System.String");
                        continue;
                }
            }
            //Movie table
            for(int k = 0; k < 5; k++)
            {
                switch (k)
                {
                    case 0:
                        DataColumn newColumn0 = new DataColumn("MovieID");
                        newColumn0.AllowDBNull = false;
                        movieTable.Columns.Add(newColumn0);
                        newColumn0.DataType = Type.GetType("System.Int32");
                        continue;
                    case 1:
                        DataColumn newColumn1 = new DataColumn("Title");
                        newColumn1.AllowDBNull = false;
                        movieTable.Columns.Add(newColumn1);
                        newColumn1.DataType = Type.GetType("System.String");
                        continue;
                    case 2:
                        DataColumn newColumn = new DataColumn("Year");
                        newColumn.AllowDBNull = false;
                        movieTable.Columns.Add(newColumn);
                        newColumn.DataType = Type.GetType("System.Int32");

                        continue;
                    case 3:
                        DataColumn newColumn2 = new DataColumn("Runtime");
                        newColumn2.AllowDBNull = false;
                        movieTable.Columns.Add(newColumn2);
                        newColumn2.DataType = Type.GetType("System.Int32");
                        continue;
                    case 4:
                        DataColumn newColumn3 = new DataColumn("ContentRating");
                        newColumn3.AllowDBNull = false;
                        movieTable.Columns.Add(newColumn3);
                        newColumn3.DataType = Type.GetType("System.String");
                        continue;
                }
            }
            //Rating Table
            for(int l = 0; l < 4; l++)
            {
                switch(l)
                {
                    case 0:
                        DataColumn newColumn4 = new DataColumn("RatingID");
                        newColumn4.AllowDBNull = false;
                        ratingTable.Columns.Add(newColumn4);
                        newColumn4.DataType = Type.GetType("System.Int32");
                        continue;
                    case 1:
                        DataColumn newColumn0 = new DataColumn("IMDBScore");
                        newColumn0.AllowDBNull = false;
                        ratingTable.Columns.Add(newColumn0);
                        newColumn0.DataType = Type.GetType("System.Double");
                        continue;
                    case 2:
                        DataColumn newColumn = new DataColumn("VotesCount");
                        newColumn.AllowDBNull = false;
                        ratingTable.Columns.Add(newColumn);
                        newColumn.DataType = Type.GetType("System.Int32");
                        continue;
                    case 3:
                        DataColumn newColumn2 = new DataColumn("MovieID");
                        newColumn2.AllowDBNull = false;
                        ratingTable.Columns.Add(newColumn2);
                        newColumn2.DataType = Type.GetType("System.Int32");
                        continue;   
                }
            }
            //Actor table
            for(int a = 0; a < 4; a++)
            {
                switch(a)
                {
                    case 0:
                        DataColumn newColumn0 = new DataColumn("MovieID");
                        newColumn0.AllowDBNull = false;
                        actorTable.Columns.Add(newColumn0);
                        newColumn0.DataType = Type.GetType("System.Int32");
                        continue;
                    case 1:
                        DataColumn newColumn01 = new DataColumn("ActorID");
                        newColumn01.AllowDBNull = false;
                        actorTable.Columns.Add(newColumn01);
                        newColumn01.DataType = Type.GetType("System.Int32");
                        continue;
                    case 2:
                        DataColumn newColumn = new DataColumn("FirstName");
                        newColumn.AllowDBNull = false;
                        actorTable.Columns.Add(newColumn);
                        newColumn.DataType = Type.GetType("System.String");
                        continue;
                    case 3:
                        DataColumn newColumn2 = new DataColumn("LastName");
                        newColumn2.AllowDBNull = false;
                        actorTable.Columns.Add(newColumn2);
                        newColumn2.DataType = Type.GetType("System.String");
                        continue;
                }
            }
            //Genre Table
            for (int s = 0; s < 3; s++)
            {
                switch (s)
                {
                    case 0:
                        DataColumn newColumn0 = new DataColumn("MovieID");
                        newColumn0.AllowDBNull = false;
                        genreTable.Columns.Add(newColumn0);
                        newColumn0.DataType = Type.GetType("System.Int32");
                        continue;
                    case 1:
                        DataColumn newColumn1 = new DataColumn("GenreID");
                        newColumn1.AllowDBNull = false;
                        genreTable.Columns.Add(newColumn1);
                        newColumn1.DataType = Type.GetType("System.Int32");
                        continue;
                    case 2:
                        DataColumn newColumn = new DataColumn("Genre");
                        newColumn.AllowDBNull = false;
                        genreTable.Columns.Add(newColumn);
                        newColumn.DataType = Type.GetType("System.String");
                        continue;
                }
            }
            //Financial Table
            for (int d = 0; d < 4; d++)
            {
                switch (d)
                {
                    case 0:
                        DataColumn newColumn0 = new DataColumn("FinancialID");
                        newColumn0.AllowDBNull = false;
                        financialTable.Columns.Add(newColumn0);
                        newColumn0.DataType = Type.GetType("System.Int32");
                        continue;
                    case 1:
                        DataColumn newColumn01 = new DataColumn("MovieID");
                        newColumn01.AllowDBNull = false;
                        financialTable.Columns.Add(newColumn01);
                        newColumn01.DataType = Type.GetType("System.Int32");
                        continue;
                    case 2:
                        DataColumn newColumn = new DataColumn("Budget");
                        newColumn.AllowDBNull = false;
                        financialTable.Columns.Add(newColumn);
                        newColumn.DataType = Type.GetType("System.Int64");
                        continue;
                    case 3:
                        DataColumn newColumn2 = new DataColumn("Gross");
                        newColumn2.AllowDBNull = false;
                        financialTable.Columns.Add(newColumn2);
                        newColumn2.DataType = Type.GetType("System.Int64");
                        continue;
                }
            }
            //Region Table
            for (int f = 0; f < 4; f++)
            {
                switch (f)
                {
                    case 0:
                        DataColumn newColumn10 = new DataColumn("RegionID");
                        newColumn10.AllowDBNull = false;
                        regionTable.Columns.Add(newColumn10);
                        newColumn10.DataType = Type.GetType("System.Int32");
                        continue;
                    case 1:
                        DataColumn newColumn0 = new DataColumn("MovieID");
                        newColumn0.AllowDBNull = false;
                        regionTable.Columns.Add(newColumn0);
                        newColumn0.DataType = Type.GetType("System.Int32");
                        continue;
                    case 2:
                        DataColumn newColumn = new DataColumn("Country");
                        newColumn.AllowDBNull = false;
                        regionTable.Columns.Add(newColumn);
                        newColumn.DataType = Type.GetType("System.String");
                        continue;
                    case 3:
                        DataColumn newColumn2 = new DataColumn("Language");
                        newColumn2.AllowDBNull = false;
                        regionTable.Columns.Add(newColumn2);
                        newColumn2.DataType = Type.GetType("System.String");
                        continue;
                }
            }
            //Additional Info
            for (int k = 0; k < 5; k++)
            {
                switch (k)
                {
                    case 0:
                        DataColumn newColumn0 = new DataColumn("InfoID");
                        newColumn0.AllowDBNull = false;
                        randomTable.Columns.Add(newColumn0);
                        newColumn0.DataType = Type.GetType("System.Int32");
                        continue;
                    case 01:
                        DataColumn newColumn01 = new DataColumn("MovieID");
                        newColumn01.AllowDBNull = false;
                        randomTable.Columns.Add(newColumn01);
                        newColumn01.DataType = Type.GetType("System.Int32");
                        continue;
                    case 2:
                        DataColumn newColumn = new DataColumn("MovieLink");
                        newColumn.AllowDBNull = false;
                        randomTable.Columns.Add(newColumn);
                        newColumn.DataType = Type.GetType("System.String");
                        continue;
                    case 3:
                        DataColumn newColumn2 = new DataColumn("AspectRatio");
                        newColumn2.AllowDBNull = false;
                        randomTable.Columns.Add(newColumn2);
                        newColumn2.DataType = Type.GetType("System.String");
                        continue;
                    case 4:
                        DataColumn newColumn3 = new DataColumn("Color");
                        newColumn3.AllowDBNull = false;
                        randomTable.Columns.Add(newColumn3);
                        newColumn3.DataType = Type.GetType("System.String");
                        continue;
                }
            }
        }
    }
}



