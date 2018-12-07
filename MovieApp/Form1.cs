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
        private int movieId;
        private bool advancedSearch;


        public Form1()
        {
            InitializeComponent();
            resultsListView.View = View.Details;
            advancedSearch = false;

            this.Size = new System.Drawing.Size(838, 427);
            this.resultsListView.Location = new Point(373, 12);
            insertButton.Visible = false;
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
            resultsListView.Columns.Clear();
            movieTitle = null;
            directorFirstName = null;
            directorLastName = null;
            genre = null;
            actorFirstName = null;
            actorLastName = null;
            actor2FirstName = null;
            actor2LastName = null;
            actor3FirstName = null;
            actor3LastName = null;
           // popularity = null;
            language = null;
           // budget = null;
            //gross = null;
            color = null;
            country = null;
            //aspectRatio = null;
            //If it's the advanced search, do the advanced search
            if(advancedSearch == true)
            {

                #region putting values in variables
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
                #endregion
                //If everything but the actors name box is empty look for all of the movies that actor is in.
                if(genreComboBox.Text == "" && movieTitleTextBox.Text == "" && countryComboBox.Text == "" && directorFirstNameTextbox.Text == "" && directorLastNameTextBox.Text == "" && actorFirstNameTextBox.Text != "" && actorLastNameTextBox.Text != "")
                {
                    SqlCommand cmd2 = new SqlCommand("GP.ActorSearch", connect);
                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@FirstName", actorFirstName));
                    cmd2.Parameters.Add(new SqlParameter("@LastName", actorLastName));
                    using (SqlDataReader rdr = cmd2.ExecuteReader())
                    {
                        if (rdr.HasRows == false)
                        {
                            MessageBox.Show("Nothing returned for that query");
                        }
                        else
                        {
                            int count = 0;
                            for (int col = 0; col < rdr.FieldCount; col++)
                            {
                                resultsListView.Columns.Add(rdr.GetName(col).ToString());
                            }
                            while (rdr.Read())
                            {
                                ListViewItem item = new ListViewItem(rdr[0].ToString());
                                for (int col = 1; col < rdr.FieldCount; col++)
                                {
                                    item.SubItems.Add(rdr[col].ToString());
                                }
                                resultsListView.Items.Add(item);
                                count++;
                            }
                        }
                    }
                }
                else {
                    SqlCommand cmd2 = new SqlCommand("GP.GeneralSearch", connect);

                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@MovieTitle", movieTitle));
                    cmd2.Parameters.Add(new SqlParameter("@Genre", genre));
                    cmd2.Parameters.Add(new SqlParameter("@Country", country));
                    cmd2.Parameters.Add(new SqlParameter("@Language", language));
                    cmd2.Parameters.Add(new SqlParameter("@DirectorFirstName", directorFirstName));
                    cmd2.Parameters.Add(new SqlParameter("@DirectorLastName", directorLastName));
                    cmd2.Parameters.Add(new SqlParameter("@Actor1FirstName", actorFirstName));
                    cmd2.Parameters.Add(new SqlParameter("@Actor1LastName", actorLastName));
                    cmd2.Parameters.Add(new SqlParameter("@Actor2FirstName", actor2FirstName));
                    cmd2.Parameters.Add(new SqlParameter("@Actor2LastName", actor2LastName));
                    cmd2.Parameters.Add(new SqlParameter("@Actor3FirstName", actor3FirstName));
                    cmd2.Parameters.Add(new SqlParameter("@Actor3LastName", actor3LastName));
                    cmd2.Parameters.Add(new SqlParameter("@MinRating", ratingMin));
                    cmd2.Parameters.Add(new SqlParameter("@MaxRating", ratingMax));
                    cmd2.Parameters.Add(new SqlParameter("@Popularity", null));
                    cmd2.Parameters.Add(new SqlParameter("@Color", color));
                    cmd2.Parameters.Add(new SqlParameter("@Budget", null));
                    cmd2.Parameters.Add(new SqlParameter("@Gross", null));
                    cmd2.Parameters.Add(new SqlParameter("@AspectRatio", null));
                    using (SqlDataReader rdr = cmd2.ExecuteReader())
                    {
                        if (rdr.HasRows == false)
                        {
                            MessageBox.Show("Nothing returned for that query");
                        }
                        else
                        {
                            int count = 0;
                            for (int col = 0; col < rdr.FieldCount; col++)
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
                                resultsListView.Items.Add(item);
                                count++;
                            }
                        }
                    }
                }
                
                    
            }
            if (searchForMovies.Checked == true)
            {
                #region putting values in variables
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
#endregion
                //If everything is empty do a rating search
                if(genreComboBox.Text == "" && movieTitleTextBox.Text == "" && countryComboBox.Text == "" && directorFirstNameTextbox.Text == "" && directorLastNameTextBox.Text == "")
                {
                    SqlCommand cmd2 = new SqlCommand("GP.RatingRangeSearch", connect);

                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@MinRating", ratingMin));
                    cmd2.Parameters.Add(new SqlParameter("@MaxRating", ratingMax));
                    using (SqlDataReader rdr = cmd2.ExecuteReader())
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
                //A title only search to check the inserted values
                if (genreComboBox.Text == "" && movieTitleTextBox.Text != "" && countryComboBox.Text == "" && directorFirstNameTextbox.Text == "" && directorLastNameTextBox.Text == "")
                {
                    SqlCommand cmd2 = new SqlCommand("GP.TitleSearch", connect);

                    cmd2.CommandType = CommandType.StoredProcedure;
                    cmd2.Parameters.Add(new SqlParameter("@Title", movieTitle));
                    using (SqlDataReader rdr = cmd2.ExecuteReader())
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
                            ListViewItem item = new ListViewItem(rdr["Title"].ToString());
                            for (int col = 1; col < rdr.FieldCount; col++)
                            {
                                item.SubItems.Add(rdr[col].ToString());
                            }
                            resultsListView.Items.Add(item);
                            count++;
                        }
                    }

                }
                //everything else 
                else
                {
                    SqlCommand cmd2 = new SqlCommand("GP.MovieSearch", connect);

                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.Add(new SqlParameter("@MovieTitle", movieTitle));
                    cmd2.Parameters.Add(new SqlParameter("@Genre", genre));
                    cmd2.Parameters.Add(new SqlParameter("@Country", country));
                    cmd2.Parameters.Add(new SqlParameter("@Language", language));
                    cmd2.Parameters.Add(new SqlParameter("@DirectorFirstName", directorFirstName));
                    cmd2.Parameters.Add(new SqlParameter("@DirectorLastName", directorLastName));
                    using (SqlDataReader rdr = cmd2.ExecuteReader())
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
                            ListViewItem item = new ListViewItem(rdr["Title"].ToString());
                            for (int col = 1; col < rdr.FieldCount; col++)
                            {
                                item.SubItems.Add(rdr[col].ToString());
                            }
                            resultsListView.Items.Add(item);
                            count++;
                        }
                    }
                }
                
            }
            if (searchForDirectors.Checked == true)
            {
                #region variable value setting
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
                #endregion
                //If just director's name is inputted run the director profit top 100 and movie count
                if (directorFirstNameTextbox.Text != "" && directorLastNameTextBox.Text != "" && genreComboBox.Text == "" && movieTitleTextBox.Text == "" && countryComboBox.Text == "")
                {
                    directorFirstName = directorFirstNameTextbox.Text;
                    directorLastName = directorLastNameTextBox.Text;
                    SqlCommand cmd1 = new SqlCommand("GP.DirectorGross", connect);

                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.Parameters.Add(new SqlParameter("@DirectorFirstName", directorFirstName));
                    cmd1.Parameters.Add(new SqlParameter("@DirectorLastName", directorLastName));
                    using (SqlDataReader rdr = cmd1.ExecuteReader())
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
                            resultsListView.Items.Add(item);
                            count++;
                        }
                    }
                    SqlCommand cmd2 = new SqlCommand("GP.DirectorCount", connect);

                    cmd2.CommandType = CommandType.StoredProcedure;

                    cmd2.Parameters.Add(new SqlParameter("@DirectorFirstName", directorFirstName));
                    cmd2.Parameters.Add(new SqlParameter("@DirectorLastName", directorLastName));
                    using (SqlDataReader rdr = cmd2.ExecuteReader())
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
                            ListViewItem item = new ListViewItem("Movie count: " + (rdr["MovieCount"].ToString()));
                            for (int col = 1; col < rdr.FieldCount; col++)
                            {
                                item.SubItems.Add(rdr[col].ToString());
                            }
                            resultsListView.Items.Add(item);
                            count++;
                        }
                    }
                }
                //General search
                else
                {
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
                            resultsListView.Items.Add(item);
                            count++;
                        }
                    }
                }
                
            }

            if (searchForFinancial.Checked == true)
            {
                #region variable value setting
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
                #endregion
                //If everything but genre is empty get the genre profit and stuff
                if (genreComboBox.Text != "" && movieTitleTextBox.Text == "" && countryComboBox.Text == "" && directorFirstNameTextbox.Text == "" && directorLastNameTextBox.Text == "")
                {
                    genre = genreComboBox.Text;
                    SqlCommand cmd3 = new SqlCommand("GP.GenreGross", connect);

                    cmd3.CommandType = CommandType.StoredProcedure;

                    cmd3.Parameters.Add(new SqlParameter("@GenreName", genre));
                    using (SqlDataReader rdr = cmd3.ExecuteReader())
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
                            ListViewItem item = new ListViewItem(rdr["GenreGross"].ToString());
                            for (int col = 1; col < rdr.FieldCount; col++)
                            {
                                item.SubItems.Add(rdr[col].ToString());
                            }
                            resultsListView.Items.Add(item);
                            count++;
                        }
                    }
                }
                //If everything is empty get the top 100 grossing movies
                if(genreComboBox.Text == "" && movieTitleTextBox.Text == "" && countryComboBox.Text == "" && directorFirstNameTextbox.Text == "" && directorLastNameTextBox.Text == "")
                {
                    SqlCommand cmd3 = new SqlCommand("GP.TopMovieProfit_100", connect);

                    cmd3.CommandType = CommandType.StoredProcedure;

                    //cmd3.Parameters.Add(new SqlParameter("@GenreName", genre));
                    using (SqlDataReader rdr = cmd3.ExecuteReader())
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
                            ListViewItem item = new ListViewItem(rdr["Profit"].ToString());
                            for (int col = 1; col < rdr.FieldCount; col++)
                            {
                                item.SubItems.Add(rdr[col].ToString());
                            }
                            resultsListView.Items.Add(item);
                            count++;
                        }
                    }
                }
                //If only movie title return the data for that movie.
                if (genreComboBox.Text == "" && movieTitleTextBox.Text != "" && countryComboBox.Text == "" && directorFirstNameTextbox.Text == "" && directorLastNameTextBox.Text == "")
                {
                    SqlCommand cmd3 = new SqlCommand("GP.MovieProfit", connect);

                    cmd3.CommandType = CommandType.StoredProcedure;

                    cmd3.Parameters.Add(new SqlParameter("@Title", movieTitle));
                    using (SqlDataReader rdr = cmd3.ExecuteReader())
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
                            ListViewItem item = new ListViewItem(rdr["MovieGross"].ToString());
                            for (int col = 1; col < rdr.FieldCount; col++)
                            {
                                item.SubItems.Add(rdr[col].ToString());
                            }
                            resultsListView.Items.Add(item);
                            count++;
                        }
                    }
                }

            }

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
                //this.languageLabel.Visible = true;
                //this.languageComboBox.Visible = true;
                this.budgetLabel.Visible = true;
                this.budgetNumericUpDown.Visible = true;
                this.grossLabel.Visible = true;
                this.grossNumbericUpdown.Visible = true;
                this.colorLabel.Visible = true;
                this.colorComboBox.Visible = true;
               // this.countryLabel.Visible = true;
                //this.countryComboBox.Visible = true;
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
                this.labelActorFirstName.Visible = true;
                this.actorFirstNameTextBox.Visible = true;
                this.actorlastNameLabel.Visible = true;
                this.actorLastNameTextBox.Visible = true;
                this.insertButton.Visible = true;
                advancedSearch = true;
            }
            else if (advancedSearch == true)
            {
                this.Size = new System.Drawing.Size(838, 427);
                this.resultsListView.Location = new Point(373, 12);
                this.popularityLabel.Visible = false;
                this.popularityNumericUpDown.Visible = false;
                //this.languageLabel.Visible = false;
                ///this.languageComboBox.Visible = false;
                this.budgetLabel.Visible = false;
                this.budgetNumericUpDown.Visible = false;
                this.grossLabel.Visible = false;
                this.grossNumbericUpdown.Visible = false;
                this.colorLabel.Visible = false;
                this.colorComboBox.Visible = false;
              //  this.countryLabel.Visible = false;
               // this.countryComboBox.Visible = false;
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
                this.insertButton.Visible = true;
                advancedSearch = false;
            }
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            
            #region putting values in variables
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
            #endregion
            //If anything is missing don't allow the insert.
            if (movieTitleTextBox.Text == "" || genreComboBox.Text == "" || languageComboBox.Text == "" || countryComboBox.Text == "" || directorFirstNameTextbox.Text == "" || directorLastNameTextBox.Text == "" || popularityNumericUpDown.Value == 0 || colorComboBox.Text == "" || budgetNumericUpDown.Value == 0 || budgetNumericUpDown.Value == 0 || grossNumbericUpdown.Value == 0 || actorFirstNameTextBox.Text == "" || actorLastNameTextBox.Text == "" || actor2FirstNameTextBox.Text == "" || actor2LastNameTextBox.Text == "" || actor3FirstNameTextBox.Text == "" || actor3LastNameTextBox.Text == "" || AspectRatioComboBox.Text == "")
            {
                MessageBox.Show("All fields must be filled out to insert");
            }
            else
            {

                SqlCommand movieIdCommand = new SqlCommand("GP.GetMovieID", connect);
                using (SqlDataReader reader = movieIdCommand.ExecuteReader())
                {
                    if(reader.HasRows == false)
                    {
                        MessageBox.Show("ERROR");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            movieId = int.Parse(reader[0].ToString());
                        }
                            
                    }
                    
                }
                //Insert the stuff
                //Movie
                SqlCommand cmd2 = new SqlCommand("GP.InsertMovie", connect);
                cmd2.CommandType = CommandType.StoredProcedure;
                //cmd2.Parameters.Add(new SqlParameter("@MovieID", movieId));
                cmd2.Parameters.Add(new SqlParameter("@Title", movieTitle));
                cmd2.Parameters.Add(new SqlParameter("@Year", "1900"));
                cmd2.Parameters.Add(new SqlParameter("@RunTime", "0"));
                cmd2.Parameters.Add(new SqlParameter("@ContentRating", "G"));
                cmd2.ExecuteNonQuery();
                //Rating
                SqlCommand cmd3 = new SqlCommand("GP.InsertRating", connect);
                cmd3.CommandType = CommandType.StoredProcedure;
                cmd3.Parameters.Add(new SqlParameter("@MovieID", movieId));
                cmd3.Parameters.Add(new SqlParameter("@IMDBScore", "10"));
                cmd3.Parameters.Add(new SqlParameter("@VotesCount", popularity));
                cmd3.ExecuteNonQuery();
                //Director
                SqlCommand cmd4 = new SqlCommand("GP.InsertDirector", connect);
                cmd4.CommandType = CommandType.StoredProcedure;
                cmd4.Parameters.Add(new SqlParameter("@MovieID", movieId));
                cmd4.Parameters.Add(new SqlParameter("@FirstName", directorFirstName));
                cmd4.Parameters.Add(new SqlParameter("@LastName", directorLastName));
                cmd4.ExecuteNonQuery();
                //Actor 
                SqlCommand cmd5 = new SqlCommand("GP.InsertActor", connect);
                cmd5.CommandType = CommandType.StoredProcedure;
                cmd5.Parameters.Add(new SqlParameter("@MovieID", movieId));
                cmd5.Parameters.Add(new SqlParameter("@FirstName", actorFirstName));
                cmd5.Parameters.Add(new SqlParameter("@LastName", actorLastName));
                cmd5.ExecuteNonQuery();
                SqlCommand cmd6 = new SqlCommand("GP.InsertActor", connect);
                cmd6.CommandType = CommandType.StoredProcedure;
                cmd6.Parameters.Add(new SqlParameter("@MovieID", movieId));
                cmd6.Parameters.Add(new SqlParameter("@FirstName", actor2FirstName));
                cmd6.Parameters.Add(new SqlParameter("@LastName", actor2LastName));
                cmd6.ExecuteNonQuery();
                SqlCommand cmd7 = new SqlCommand("GP.InsertActor", connect);
                cmd7.CommandType = CommandType.StoredProcedure;
                cmd7.Parameters.Add(new SqlParameter("@MovieID", movieId));
                cmd7.Parameters.Add(new SqlParameter("@FirstName", actor3FirstName));
                cmd7.Parameters.Add(new SqlParameter("@LastName", actor3LastName));
                cmd7.ExecuteNonQuery();
                //Genre
                SqlCommand cmd8 = new SqlCommand("GP.InsertGenre", connect);
                cmd8.CommandType = CommandType.StoredProcedure;
                cmd8.Parameters.Add(new SqlParameter("@MovieID", movieId));
                cmd8.Parameters.Add(new SqlParameter("@Genre", genre));
                cmd8.ExecuteNonQuery();
                //Region
                SqlCommand cmd9 = new SqlCommand("GP.InsertRegion", connect);
                cmd9.CommandType = CommandType.StoredProcedure;
                cmd9.Parameters.Add(new SqlParameter("@MovieID", movieId));
                cmd9.Parameters.Add(new SqlParameter("@Country", country));
                cmd9.Parameters.Add(new SqlParameter("@Language", language));
                cmd9.ExecuteNonQuery();
                //Additional Info
                SqlCommand cmd1 = new SqlCommand("GP.InsertAdditionalInfo", connect);
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.Parameters.Add(new SqlParameter("@MovieID", movieId));
                cmd1.Parameters.Add(new SqlParameter("@MovieLink", "google.com"));
                cmd1.Parameters.Add(new SqlParameter("@AspectRatio", aspectRatio));
                cmd1.Parameters.Add(new SqlParameter("@Color", color));
                cmd1.ExecuteNonQuery();
                
            }
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
