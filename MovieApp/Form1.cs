using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MovieApp
{
    public partial class Form1 : Form
    {
        private static string databaseConnectionString;



        public Form1()
        {
            InitializeComponent();
            SqlConnection connect = new SqlConnection();
            connect.ConnectionString = "Data Source = mssql.cs.ksu.edu;" +
                "Initial Catalog=cis560_team16;" +
                "Integrated Security=SSPI;";
            connect.Open();
        }
    }
}
