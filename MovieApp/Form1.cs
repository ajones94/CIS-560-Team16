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
        private string actorFirstName;
        private string actorLastName;
        private string actor2FirstName;
        private string actor2LastName;
        private string actor3FirstName;
        private string actor3LastName;
        private int popularity;
        private string language;
        private Int64 budget;
        private Int64 gross;
        private string color;
        private string country;
        private double aspectRatio;
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
            this.actor2FirstNameLabel.Visible = false;
            this.actor2FirstNameTextBox.Visible = false;
            this.actor3FirstNameLabel.Visible = false;
            this.actor3FirstNameTextBox.Visible = false;
            this.actor2LastNameLabel.Visible = false;
            this.actor2LastNameTextBox.Visible = false;
            this.actor3LastNameLabel.Visible = false;
            this.actor3LastNameTextBox.Visible = false;





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
            if (actorFirstNameTextBox.Text != "" || actorFirstNameTextBox.Text != " ")
            {
                actorFirstName = actorFirstNameTextBox.Text;
            }
            if (actorLastNameTextBox.Text != "" || actorLastNameTextBox.Text != " ")
            {
                actorLastName = actorLastNameTextBox.Text;
            }
            if (actor2FirstNameTextBox.Text != "" || actorFirstNameTextBox.Text != " ")
            {
                actorFirstName = actorFirstNameTextBox.Text;
            }
            if (actor2LastNameTextBox.Text != "" || actorLastNameTextBox.Text != " ")
            {
                actor2LastName = actor2LastNameTextBox.Text;
            }
            if (actor3FirstNameTextBox.Text != "" || actorFirstNameTextBox.Text != " ")
            {
                actorFirstName = actorFirstNameTextBox.Text;
            }
            if (actor3LastNameTextBox.Text != "" || actorLastNameTextBox.Text != " ")
            {
                actor3LastName = actor3LastNameTextBox.Text;
            }
            if(popularityNumericUpDown.Value != 0)
            {
                popularity = (int)popularityNumericUpDown.Value;
            }
            if(languageComboBox.Text != "")
            {
                language = languageComboBox.Text;
            }
            if(budgetNumericUpDown.Value != 0)
            {
                budget = (Int64)budgetNumericUpDown.Value;
            }
            if (grossNumbericUpdown.Value != 0)
            {
                gross = (Int64)grossNumbericUpdown.Value;
            }
            if(colorComboBox.Text != "")
            {
                color = colorComboBox.Text;
            }
            if(countryComboBox.Text != "")
            {
                country = countryComboBox.Text;
            }
            if(AspectRatioComboBox.Text != "")
            {
                aspectRatio = Double.Parse(AspectRatioComboBox.Text);
            }














            //ListViewItem newItem = new ListViewItem(movieTitle);
            //newItem.SubItems.Add(directorFirstName);
            //newItem.SubItems.Add(directorLastName);
            //newItem.SubItems.Add(genre);
            //newItem.SubItems.Add(ratingMin.ToString());
            //newItem.SubItems.Add(ratingMax.ToString());
            //resultsListView.Items.Add(newItem);
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
            languageComboBox.Text = "";
            grossNumbericUpdown.Value = 0;
            colorComboBox.Text = "";
            countryComboBox.Text = "";
            AspectRatioComboBox.Text = "";
            actorFirstNameTextBox.Text = "";
            actor2FirstNameTextBox.Text = "";
            actor3FirstNameTextBox.Text = "";
            actorLastNameTextBox.Text = "";
            actor2LastNameTextBox.Text = "";
            actor3LastNameTextBox.Text = "";
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
                this.actor2FirstNameLabel.Visible = true;
                this.actor2FirstNameTextBox.Visible = true;
                this.actor3FirstNameLabel.Visible = true;
                this.actor3FirstNameTextBox.Visible = true;
                this.actor2LastNameLabel.Visible = true;
                this.actor2LastNameTextBox.Visible = true;
                this.actor3LastNameLabel.Visible = true;
                this.actor3LastNameTextBox.Visible = true;
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
                this.actor2FirstNameLabel.Visible = false;
                this.actor2FirstNameTextBox.Visible = false;
                this.actor3FirstNameLabel.Visible = false;
                this.actor3FirstNameTextBox.Visible = false;
                this.actor2LastNameLabel.Visible = false;
                this.actor2LastNameTextBox.Visible = false;
                this.actor3LastNameLabel.Visible = false;
                this.actor3LastNameTextBox.Visible = false;
                advancedSearch = false;
            }
        }
    }
}
