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

        private bool advancedSearch;


        public Form1()
        {
            InitializeComponent();
            resultsListView.View = View.Details;
            advancedSearch = false;


            this.Size = new System.Drawing.Size(838, 427);
            this.resultsListView.Location = new Point(373, 12);

            this.popularityLabel.Visible = false;
            this.popularityNumericUpDown.Visible = false;
            this.languageLabel.Visible = false;
            this.languageComboBox.Visible = false;
            this.budgetLabel.Visible = false;
            this.budgetNumericUpDown.Visible = false;
            this.grossLabel.Visible = false;
            this.grossNumbericUpdown.Visible = false;
            this.colorLabel.Visible = false;
            this.colorComboBox.Visible = false;
            this.countryLabel.Visible = false;
            this.countryComboBox.Visible = false;
            this.aspectRatioLabel.Visible = false;
            this.AspectRatioComboBox.Visible = false;






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
            ListViewItem newItem = new ListViewItem(movieTitle);
            newItem.SubItems.Add(directorFirstName);
            newItem.SubItems.Add(directorLastName);
            newItem.SubItems.Add(genre);
            newItem.SubItems.Add(ratingMin.ToString());
            newItem.SubItems.Add(ratingMax.ToString());
            resultsListView.Items.Add(newItem);
        }

        private void resetButton_Click(object sender, EventArgs e)
        {
            ratingSelectionSlider.ResetLabelValues();
            genreComboBox.Text = "";
            directorFirstNameTextbox.Text = "";
            directorLastNameTextBox.Text = "";
            movieTitleTextBox.Text = "";
            directorFirstNameTextbox.Text = "";
            directorLastNameTextBox.Text = "";
            popularityNumericUpDown.Value = 0;
            budgetNumericUpDown.Value = 0;
            grossNumbericUpdown.Value = 0;
            colorComboBox.Text = "";
            countryComboBox.Text = "";
            AspectRatioComboBox.Text = "";
        }

        private void advancedSearchLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(advancedSearch == false)
            {
                this.Size = new System.Drawing.Size(1113, 427);
                this.resultsListView.Location = new Point(655, 12);
                this.popularityLabel.Visible = true;
                this.popularityNumericUpDown.Visible = true;
                this.languageLabel.Visible = true;
                this.languageComboBox.Visible = true;
                this.budgetLabel.Visible = true;
                this.budgetNumericUpDown.Visible = true;
                this.grossLabel.Visible = true;
                this.grossNumbericUpdown.Visible = true;
                this.colorLabel.Visible = true;
                this.colorComboBox.Visible = true;
                this.countryLabel.Visible = true;
                this.countryComboBox.Visible = true;
                this.aspectRatioLabel.Visible = true;
                this.AspectRatioComboBox.Visible = true;
                advancedSearch = true;
            }
            else if (advancedSearch == true)
            {
                this.Size = new System.Drawing.Size(838, 427);
                this.resultsListView.Location = new Point(373, 12);
                this.popularityLabel.Visible = false;
                this.popularityNumericUpDown.Visible = false;
                this.languageLabel.Visible = false;
                this.languageComboBox.Visible = false;
                this.budgetLabel.Visible = false;
                this.budgetNumericUpDown.Visible = false;
                this.grossLabel.Visible = false;
                this.grossNumbericUpdown.Visible = false;
                this.colorLabel.Visible = false;
                this.colorComboBox.Visible = false;
                this.countryLabel.Visible = false;
                this.countryComboBox.Visible = false;
                this.aspectRatioLabel.Visible = false;
                this.AspectRatioComboBox.Visible = false;
                advancedSearch = false;
            }
        }
    }
}
