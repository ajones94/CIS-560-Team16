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
            //this.languageLabel.Visible = false;
            //this.languageComboBox.Visible = false;
            this.budgetLabel.Visible = false;
            this.budgetNumericUpDown.Visible = false;
            this.grossLabel.Visible = false;
            this.grossNumbericUpdown.Visible = false;
            this.colorLabel.Visible = false;
            this.colorComboBox.Visible = false;
            //this.countryLabel.Visible = false;
            //this.countryComboBox.Visible = false;
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
            this.labelActorFirstName.Visible = false;
            this.actorFirstNameTextBox.Visible = false;
            this.actorlastNameLabel.Visible = false;
            this.actorLastNameTextBox.Visible = false;





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
            //resultsListView = new ListView();
            resultsListView.Items.Clear();
            movieTitle = null;
            directorFirstName = null;
            directorLastName = null;
            genre = null;
            actorFirstName = null;
             actorLastName = null;

            if(searchForMovies.Checked == true)
            {
                ratingMin = ratingSelectionSlider.SelectedMin;
                ratingMax = ratingSelectionSlider.SelectedMax;
                if (movieTitleTextBox.Text != "")
                {
                    movieTitle = movieTitleTextBox.Text;

                }
                if (directorFirstNameTextbox.Text != "")
                {
                    directorFirstName = directorFirstNameTextbox.Text;
                }
                if (directorLastNameTextBox.Text != "")
                {
                    directorLastName = directorLastNameTextBox.Text;
                }
                if (genreComboBox.Text != "")
                {
                    genre = genreComboBox.Text;
                }
                if (actorFirstNameTextBox.Text != "")
                {
                    actorFirstName = actorFirstNameTextBox.Text;
                }
                if (actorLastNameTextBox.Text != "")
                {
                    actorLastName = actorLastNameTextBox.Text;
                }
                if (actor2FirstNameTextBox.Text != "")
                {
                    actor2FirstName = actorFirstNameTextBox.Text;
                }
                if (actor2LastNameTextBox.Text != "")
                {
                    actor2LastName = actor2LastNameTextBox.Text;
                }
                if (actor3FirstNameTextBox.Text != "")
                {
                    actor3FirstName = actorFirstNameTextBox.Text;
                }
                if (actor3LastNameTextBox.Text != "")
                {
                    actor3LastName = actor3LastNameTextBox.Text;
                }
                if (popularityNumericUpDown.Value != 0)
                {
                    popularity = (int)popularityNumericUpDown.Value;
                }
                if (languageComboBox.Text != "")
                {
                    language = languageComboBox.Text;
                }
                if (budgetNumericUpDown.Value != 0)
                {
                    budget = (Int64)budgetNumericUpDown.Value;
                }
                if (grossNumbericUpdown.Value != 0)
                {
                    gross = (Int64)grossNumbericUpdown.Value;
                }
                if (colorComboBox.Text != "")
                {
                    color = colorComboBox.Text;
                }
                if (countryComboBox.Text != "")
                {
                    country = countryComboBox.Text;
                }
                if (AspectRatioComboBox.Text != "")
                {
                    aspectRatio = Double.Parse(AspectRatioComboBox.Text);
                }
                SqlCommand cmd = new SqlCommand("GP.MovieSearch", connect);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MovieTitle", movieTitle));
                cmd.Parameters.Add(new SqlParameter("@Genre", genre));
                cmd.Parameters.Add(new SqlParameter("@Country", country));
                cmd.Parameters.Add(new SqlParameter("@Language", language));
                cmd.Parameters.Add(new SqlParameter("@DirectorFirstName", directorFirstName));
                cmd.Parameters.Add(new SqlParameter("@DirectorLastName", directorLastName));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows == false)
                    {
                        MessageBox.Show("Nothing returned for that query");
                    }
                    int count = 0;
                    for(int col = 0; col < rdr.FieldCount; col++)
                    {
                        resultsListView.Columns.Add(rdr.GetName(col).ToString());
                    }
                    while (rdr.Read())
                    {
                        ListViewItem item = new ListViewItem(rdr["Title"].ToString());
                        for (int col = 1; col < rdr.FieldCount; col++)
                        {
                            item.SubItems.Add(rdr[col].ToString());   
                        }
                        //ListViewItem item = new ListViewItem(rdr["Title"].ToString());
                        //item.SubItems.Add(rdr["FirstName"].ToString());
                        //item.SubItems.Add(rdr["LastName"].ToString());
                        //item.SubItems.Add(rdr["Year"].ToString());
                        //item.SubItems.Add(rdr["Runtime"].ToString());
                        //item.SubItems.Add(rdr["ContentRating"].ToString());
                        //item.SubItems.Add(rdr["FirstName"].ToString());
                        //ListViewItem item = new ListViewItem(rdr["Title"].ToString());
                        //item.SubItems.Add(rdr["Year"].ToString());
                        //item.SubItems.Add(rdr["Runtime"].ToString());
                        //item.SubItems.Add(rdr["ContentRating"].ToString());
                        resultsListView.Items.Add(item);
                        count++;
                    }
                }

            }
            if(searchForDirectors.Checked == true)
            {
                ratingMin = ratingSelectionSlider.SelectedMin;
                ratingMax = ratingSelectionSlider.SelectedMax;
                if (movieTitleTextBox.Text != "")
                {
                    movieTitle = movieTitleTextBox.Text;

                }
                if (directorFirstNameTextbox.Text != "")
                {
                    directorFirstName = directorFirstNameTextbox.Text;
                }
                if (directorLastNameTextBox.Text != "")
                {
                    directorLastName = directorLastNameTextBox.Text;
                }
                if (genreComboBox.Text != "")
                {
                    genre = genreComboBox.Text;
                }
                if (actorFirstNameTextBox.Text != "")
                {
                    actorFirstName = actorFirstNameTextBox.Text;
                }
                if (actorLastNameTextBox.Text != "")
                {
                    actorLastName = actorLastNameTextBox.Text;
                }
                if (actor2FirstNameTextBox.Text != "")
                {
                    actor2FirstName = actorFirstNameTextBox.Text;
                }
                if (actor2LastNameTextBox.Text != "")
                {
                    actor2LastName = actor2LastNameTextBox.Text;
                }
                if (actor3FirstNameTextBox.Text != "")
                {
                    actor3FirstName = actorFirstNameTextBox.Text;
                }
                if (actor3LastNameTextBox.Text != "")
                {
                    actor3LastName = actor3LastNameTextBox.Text;
                }
                if (popularityNumericUpDown.Value != 0)
                {
                    popularity = (int)popularityNumericUpDown.Value;
                }
                if (languageComboBox.Text != "")
                {
                    language = languageComboBox.Text;
                }
                if (budgetNumericUpDown.Value != 0)
                {
                    budget = (Int64)budgetNumericUpDown.Value;
                }
                if (grossNumbericUpdown.Value != 0)
                {
                    gross = (Int64)grossNumbericUpdown.Value;
                }
                if (colorComboBox.Text != "")
                {
                    color = colorComboBox.Text;
                }
                if (countryComboBox.Text != "")
                {
                    country = countryComboBox.Text;
                }
                if (AspectRatioComboBox.Text != "")
                {
                    aspectRatio = Double.Parse(AspectRatioComboBox.Text);
                }
                SqlCommand cmd = new SqlCommand("GP.DirectorSearch", connect);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add(new SqlParameter("@MovieTitle", movieTitle));
                cmd.Parameters.Add(new SqlParameter("@Genre", genre));
                cmd.Parameters.Add(new SqlParameter("@Country", country));
                cmd.Parameters.Add(new SqlParameter("@Language", language));
                cmd.Parameters.Add(new SqlParameter("@DirectorFirstName", directorFirstName));
                cmd.Parameters.Add(new SqlParameter("@DirectorLastName", directorLastName));
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    if (rdr.HasRows == false)
                    {
                        MessageBox.Show("Nothing returned for that query");
                    }
                    int count = 0;
                    for (int col = 0; col < rdr.FieldCount; col++)
                    {
                        resultsListView.Columns.Add(rdr.GetName(col).ToString());
                    }
                    while (rdr.Read())
                    {
                        ListViewItem item = new ListViewItem(rdr["FirstName"].ToString());
                        for (int col = 1; col < rdr.FieldCount; col++)
                        {
                            item.SubItems.Add(rdr[col].ToString());
                        }
                        //ListViewItem item = new ListViewItem(rdr["Title"].ToString());
                        //item.SubItems.Add(rdr["FirstName"].ToString());
                        //item.SubItems.Add(rdr["LastName"].ToString());
                        //item.SubItems.Add(rdr["Year"].ToString());
                        //item.SubItems.Add(rdr["Runtime"].ToString());
                        //item.SubItems.Add(rdr["ContentRating"].ToString());
                        //item.SubItems.Add(rdr["FirstName"].ToString());
                        //ListViewItem item = new ListViewItem(rdr["Title"].ToString());
                        //item.SubItems.Add(rdr["Year"].ToString());
                        //item.SubItems.Add(rdr["Runtime"].ToString());
                        //item.SubItems.Add(rdr["ContentRating"].ToString());
                        resultsListView.Items.Add(item);
                        count++;
                    }
                }
            }
            if(searchForFinancial.Checked == true)
            {

            }























            ratingMin = ratingSelectionSlider.SelectedMin;
            ratingMax = ratingSelectionSlider.SelectedMax;
            if (movieTitleTextBox.Text != "")
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
            if(genreComboBox.Text == "")
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
                actor2FirstName = actorFirstNameTextBox.Text;
            }
            if (actor2LastNameTextBox.Text != "" || actorLastNameTextBox.Text != " ")
            {
                actor2LastName = actor2LastNameTextBox.Text;
            }
            if (actor3FirstNameTextBox.Text != "" || actorFirstNameTextBox.Text != " ")
            {
                actor3FirstName = actorFirstNameTextBox.Text;
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




            //SqlCommand cmd = new SqlCommand("GP.AllSearch", connect);

            //cmd.CommandType = CommandType.StoredProcedure;

            ////cmd.Parameters.Add(new SqlParameter("@MovieTitle", movieTitle));
            ////cmd.Parameters.Add(new SqlParameter("@Genre", genre));
            ////cmd.Parameters.Add(new SqlParameter("@ActorFirstName", actorFirstName));
            ////cmd.Parameters.Add(new SqlParameter("@ActorLastName", actorLastName));
            ////cmd.Parameters.Add(new SqlParameter("@DirectorFirstName", directorFirstName));
            ////cmd.Parameters.Add(new SqlParameter("@DirectorLastName", directorLastName));
            ////cmd.Parameters.Add(new SqlParameter("@MinRating", ratingMin));
            ////cmd.Parameters.Add(new SqlParameter("@MaxRating", ratingMax));
            ////cmd.Parameters.Add(new SqlParameter("@Popularity", popularity));
            ////cmd.Parameters.Add(new SqlParameter("@Language", language));
            ////cmd.Parameters.Add(new SqlParameter("@Budget", budget));
            ////cmd.Parameters.Add(new SqlParameter("@Gross", gross));
            ////cmd.Parameters.Add(new SqlParameter("@Color", color));
            ////cmd.Parameters.Add(new SqlParameter("@Country", country));
            ////cmd.Parameters.Add(new SqlParameter("@AspectRatio", aspectRatio));
            ////cmd.Parameters.Add(new SqlParameter("@Actor2FirstName", actor2FirstName));
            ////cmd.Parameters.Add(new SqlParameter("@Actor2LastName", actor2LastName));
            ////cmd.Parameters.Add(new SqlParameter("@Actor3FirstName", actor3FirstName));
            ////cmd.Parameters.Add(new SqlParameter("@Actor3LastName", actor3LastName));
            //cmd.Parameters.Add(new SqlParameter("@MovieTitle", null));
            //cmd.Parameters.Add(new SqlParameter("@Genre", genre));
            //cmd.Parameters.Add(new SqlParameter("@ActorFirstName", null));
            //cmd.Parameters.Add(new SqlParameter("@ActorLastName", null));
            //cmd.Parameters.Add(new SqlParameter("@DirectorFirstName", null));
            //cmd.Parameters.Add(new SqlParameter("@DirectorLastName", null));
            //cmd.Parameters.Add(new SqlParameter("@MinRating", ratingMin));
            //cmd.Parameters.Add(new SqlParameter("@MaxRating", ratingMax));
            //cmd.Parameters.Add(new SqlParameter("@Popularity", null));
            //cmd.Parameters.Add(new SqlParameter("@Language", null));
            //cmd.Parameters.Add(new SqlParameter("@Budget", null));
            //cmd.Parameters.Add(new SqlParameter("@Gross", null));
            //cmd.Parameters.Add(new SqlParameter("@Color", null));
            //cmd.Parameters.Add(new SqlParameter("@Country", null));
            //cmd.Parameters.Add(new SqlParameter("@AspectRatio", null));

            //using (SqlDataReader rdr = cmd.ExecuteReader())
            //{
            //    if (rdr.HasRows == false)
            //    {
            //        MessageBox.Show("Nothing returned for that query");
            //    }
            //    int count = 0;
            //    while (rdr.Read())
            //    {
            //        ListViewItem item = new ListViewItem(rdr["Title"].ToString());
            //        //item.SubItems.Add(rdr["Year"].ToString());
            //        //item.SubItems.Add(rdr["Runtime"].ToString());
            //        //item.SubItems.Add(rdr["ContentRating"].ToString());
            //        //item.SubItems.Add(rdr["FirstName"].ToString());
            //        //ListViewItem item = new ListViewItem(rdr["Title"].ToString());
            //        //item.SubItems.Add(rdr["Year"].ToString());
            //        //item.SubItems.Add(rdr["Runtime"].ToString());
            //        //item.SubItems.Add(rdr["ContentRating"].ToString());
            //        resultsListView.Items.Add(item);
            //        count++;
            //    }
            //}



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

        private void insertButton_Click(object sender, EventArgs e)
        {

        }

        private void searchForMovies_CheckedChanged(object sender, EventArgs e)
        {
           // searchForActors.Checked = false;
            searchForDirectors.Checked = false;
            searchForFinancial.Checked = false;
        }

        private void searchForActors_CheckedChanged(object sender, EventArgs e)
        {
            searchForMovies.Checked = false;
            searchForDirectors.Checked = false;
            searchForFinancial.Checked = false;
        }

        private void searchForDirectors_CheckedChanged(object sender, EventArgs e)
        {
           // searchForActors.Checked = false;
            searchForMovies.Checked = false;
            searchForFinancial.Checked = false;
        }

        private void searchForFinancial_CheckedChanged(object sender, EventArgs e)
        {
           // searchForActors.Checked = false;
            searchForMovies.Checked = false;
            searchForDirectors.Checked = false;
        }
    }
}
