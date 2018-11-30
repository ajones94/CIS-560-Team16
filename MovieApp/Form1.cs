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
        private static SqlConnection connect;

        private string movieTitle;

        private string directorFirstName;

        private string directorLastName;

        private string genre;

        private int ratingMin;

        private int ratingMax;


        public Form1()
        {
            InitializeComponent();
            ratingSelectionSlider.SetLabels(labelLowerRating, labelHigherRating);
            connect = new SqlConnection();
            connect.ConnectionString = "Data Source = mssql.cs.ksu.edu;" +
                "Initial Catalog=cis560_team16;" +
                "Integrated Security=SSPI;";
            connect.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            //Application.Run(new AdminDashboard());
            AdminDashboard admin = new AdminDashboard();
            admin.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            ratingMin = ratingSelectionSlider.SelectedMin;
            ratingMax = ratingSelectionSlider.SelectedMax;
            if (movieTitleTextBox.Text != "" || movieTitleTextBox.Text != " ")
            {
                movieTitle = movieTitleTextBox.Text;
            }
            if(directorFirstNameTextbox.Text != "" || directorFirstNameTextbox.Text != " ")
            {
                directorFirstName = directorFirstNameTextbox.Text;
            }
            if (directorLastNameTextBox.Text != "" || directorLastNameTextBox.Text != " ")
            {
                directorLastName = directorLastNameTextBox.Text;
            }
            if(genreComboBox.Text != "")
            {
                genre = genreComboBox.Text;
            }
        }
    }
}
