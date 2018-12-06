using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.VisualBasic.FileIO;
//using Microsoft.VisualBasic.CompilerServices;
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
        private DataTable csvData;

        /// <summary>
        /// Getter for the csvData to use in the SQL class.
        /// </summary>
        public DataTable CsvData
        {
            get;
        }

        /// <summary>
        /// Path to the CSV file.
        /// </summary>
        private string csvFilePath;
        

        public DataWorker(string filePath)
        {
            csvData = new DataTable();
            csvFilePath = filePath;
        }


        /// <summary>
        /// This table iterates through the CSV file, parses and scrubs it, then adds it to the Datatable
        /// </summary>
        /// <returns>This returns the datatable with all of the columns in it.</returns>
        public DataTable GetDataTableFromCSVFile()
        {
            try
            {
                using (TextFieldParser csvReader = new TextFieldParser(csvFilePath))
                {
                    csvReader.SetDelimiters(new string[] { "," });
                    csvReader.HasFieldsEnclosedInQuotes = true;          //configuration for the reading of the file  
                    string[] colFields = csvReader.ReadFields();
                    int counter = 0; //This will keep count of the column number, so in the other method it knows what to do.
                    foreach (string column in colFields) //Go through the columns
                    {
                        InitializeDataTableTypes(counter, column);
                        counter++;
                    }
                    while (!csvReader.EndOfData)
                    {
                        string[] fieldData = csvReader.ReadFields();
                        for (int i = 0; i < fieldData.Length; i++)
                        {
                            fieldData[i] = fieldData[i].Replace("%", string.Empty);//Get rid of any symbols
                            fieldData[i] = fieldData[i].Replace("$", string.Empty);

                            if (fieldData[i] == "" || fieldData[i] == "Unavailable" || fieldData[i] == "xxxxx4020") //These extra two are special fields in the csv file. They need to be scrubbed.
                            {
                                fieldData[i] = DataTypeEmptysInTable(i);
                            }
                            else if (i == 119 && fieldData[i] != "") //This is to make sure the final 4 social column is actually 4 digits rather than the whole entire SSN.
                            {
                                int temp = fieldData[i].Length;
                                fieldData[i] = fieldData[i].Substring(temp - 4);
                            }
                        }
                        csvData.Rows.Add(fieldData); //Add the row of data to the DataTable
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return csvData;
        }

        /// <summary>
        /// This determines what datatype the column should be, since normally everything would be string. The database has different types that need to change.
        /// This does not set the datatype of the column
        /// </summary>
        /// <param name="columnNumber">This is the column number, how it deceides what the datatype should be.</param>
        /// <returns>Returns the int that signifies the datatype of the column. This is then used later to make the datatype correct.</returns>
        private int returnDataType(int columnNumber)
        {
            if (columnNumber == 0 || columnNumber == 20 || columnNumber == 21 || columnNumber == 22 || columnNumber == 23 || columnNumber == 27 || columnNumber == 31 || columnNumber == 36 || columnNumber == 38 || columnNumber == 40 || columnNumber == 43 || columnNumber == 44 || columnNumber == 45 || columnNumber == 47 || columnNumber == 48 || columnNumber == 49 || columnNumber == 51 || columnNumber == 55 || columnNumber == 56 || columnNumber == 59 || columnNumber == 74 || columnNumber == 75 || columnNumber == 95 || columnNumber == 100 || columnNumber == 100 || columnNumber == 102 || columnNumber == 119 || columnNumber == 122)
            {
                //This is int
                return 0;
            }
            else if (columnNumber == 2 || columnNumber == 3 || columnNumber == 4 || columnNumber == 5 || columnNumber == 6 || columnNumber == 8 || columnNumber == 24 || columnNumber == 28 || columnNumber == 32 || columnNumber == 35 || columnNumber == 39 || columnNumber == 41 || columnNumber == 42 || columnNumber == 46 || columnNumber == 50 || columnNumber == 52 || columnNumber == 53 || columnNumber == 54 || columnNumber == 57 || columnNumber == 58 || columnNumber == 60 || columnNumber == 61 || columnNumber == 69 || columnNumber == 70 || columnNumber == 71 || columnNumber == 72 || columnNumber == 81 || columnNumber == 82 || columnNumber == 83 || columnNumber == 84 || columnNumber == 85 || columnNumber == 86 || columnNumber == 87 || columnNumber == 88 || columnNumber == 89 || columnNumber == 90 || columnNumber == 91 || columnNumber == 92 || columnNumber == 93 || columnNumber == 94 || columnNumber == 96 || columnNumber == 97 || columnNumber == 98 || columnNumber == 99 || columnNumber == 101 || columnNumber == 103 || columnNumber == 104 || columnNumber == 106 || columnNumber == 107 || columnNumber == 108 || columnNumber == 109 || columnNumber == 111 || columnNumber == 117 || columnNumber == 118 || columnNumber == 120 || columnNumber == 121 || columnNumber == 123 || columnNumber == 124 || columnNumber == 125 || columnNumber == 126 || columnNumber == 127 || columnNumber == 129 || columnNumber == 130 || columnNumber == 131 || columnNumber == 132 || columnNumber == 133 || columnNumber == 134)
            {
                //this is string
                return 1;
            }
            else if (columnNumber == 1 || columnNumber == 26 || columnNumber == 105 || columnNumber == 110 || columnNumber == 112)
            {
                //This is datetime
                return 2;
            }
            else if (columnNumber == 10 || columnNumber == 11 || columnNumber == 13 || columnNumber == 14 || columnNumber == 15 || columnNumber == 16 || columnNumber == 17 || columnNumber == 18 || columnNumber == 19 || columnNumber == 29 || columnNumber == 30 || columnNumber == 33 || columnNumber == 34 || columnNumber == 62 || columnNumber == 63 || columnNumber == 64 || columnNumber == 65 || columnNumber == 66 || columnNumber == 67 || columnNumber == 68 || columnNumber == 73 || columnNumber == 76 || columnNumber == 78 || columnNumber == 79 || columnNumber == 80)
            {
                //this is time
                return 3;
            }
            else if (columnNumber == 25 || columnNumber == 115 || columnNumber == 116)
            {
                //this is date
                return 4;
            }
            else if (columnNumber == 12 || columnNumber == 37 || columnNumber == 77 || columnNumber == 113 || columnNumber == 114 || columnNumber == 128)
            {
                //this is decimal
                return 5;
            }
            else if (columnNumber == 7 || columnNumber == 9)
            {
                return 6;
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
        private void InitializeDataTableTypes(int i, string name)
        {
            int returnedColumnNumber = returnDataType(i);
            DataColumn datecolumn = new DataColumn(name);
            datecolumn.AllowDBNull = false;
            csvData.Columns.Add(datecolumn);
            switch (returnedColumnNumber)
            {
                case 0:
                    csvData.Columns[i].DataType = typeof(int);
                    break;
                case 1:
                    csvData.Columns[i].DataType = typeof(string);
                    break;
                case 2:
                    csvData.Columns[i].DataType = typeof(DateTime);
                    break;
                case 3:
                    csvData.Columns[i].DataType = typeof(TimeSpan);
                    break;
                case 4:
                    csvData.Columns[i].DataType = typeof(DateTime);
                    break;
                case 5:
                    csvData.Columns[i].DataType = typeof(decimal);
                    break;
                case 6:
                    csvData.Columns[i].DataType = typeof(long);
                    break;
                default:
                    throw new Exception("Something fucked up here." + " Column Number " + i + " Column Name " + name);
                    break;
            }
        }
    }
}



