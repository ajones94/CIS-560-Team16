namespace MovieApp
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.movieTitleTextBox = new System.Windows.Forms.TextBox();
            this.movieTitleLabel = new System.Windows.Forms.Label();
            this.directorLastNameTextBox = new System.Windows.Forms.TextBox();
            this.directorFirstNameTextbox = new System.Windows.Forms.TextBox();
            this.directorFirstNameLabel = new System.Windows.Forms.Label();
            this.directorLastNameLabel = new System.Windows.Forms.Label();
            this.genreComboBox = new System.Windows.Forms.ComboBox();
            this.genreLabel = new System.Windows.Forms.Label();
            this.ratingLabel = new System.Windows.Forms.Label();
            this.labelLowerRating = new System.Windows.Forms.Label();
            this.labelHigherRating = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.resultsListView = new System.Windows.Forms.ListView();
            this.movieTitleHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.directorFirstNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.directorLastNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.genreHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.minHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.maxHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.searchButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.popularityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.languageComboBox = new System.Windows.Forms.ComboBox();
            this.languageLabel = new System.Windows.Forms.Label();
            this.popularityLabel = new System.Windows.Forms.Label();
            this.actorFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.actorLastNameTextBox = new System.Windows.Forms.TextBox();
            this.labelActorFirstName = new System.Windows.Forms.Label();
            this.actorlastNameLabel = new System.Windows.Forms.Label();
            this.advancedSearchLinkLabel = new System.Windows.Forms.LinkLabel();
            this.budgetNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.grossNumbericUpdown = new System.Windows.Forms.NumericUpDown();
            this.budgetLabel = new System.Windows.Forms.Label();
            this.grossLabel = new System.Windows.Forms.Label();
            this.countryComboBox = new System.Windows.Forms.ComboBox();
            this.countryLabel = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.colorLabel = new System.Windows.Forms.Label();
            this.AspectRatioComboBox = new System.Windows.Forms.ComboBox();
            this.aspectRatioLabel = new System.Windows.Forms.Label();
            this.actor2LastNameTextBox = new System.Windows.Forms.TextBox();
            this.actor2FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.actor2LastNameLabel = new System.Windows.Forms.Label();
            this.actor2FirstNameLabel = new System.Windows.Forms.Label();
            this.actor3FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.actor3LastNameTextBox = new System.Windows.Forms.TextBox();
            this.actor3FirstNameLabel = new System.Windows.Forms.Label();
            this.actor3LastNameLabel = new System.Windows.Forms.Label();
            this.ratingSelectionSlider = new MovieApp.SelectionRangeSlider();
            ((System.ComponentModel.ISupportInitialize)(this.popularityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grossNumbericUpdown)).BeginInit();
            this.SuspendLayout();
            // 
            // movieTitleTextBox
            // 
            this.movieTitleTextBox.Location = new System.Drawing.Point(12, 64);
            this.movieTitleTextBox.Name = "movieTitleTextBox";
            this.movieTitleTextBox.Size = new System.Drawing.Size(136, 20);
            this.movieTitleTextBox.TabIndex = 0;
            // 
            // movieTitleLabel
            // 
            this.movieTitleLabel.AutoSize = true;
            this.movieTitleLabel.Location = new System.Drawing.Point(46, 46);
            this.movieTitleLabel.Name = "movieTitleLabel";
            this.movieTitleLabel.Size = new System.Drawing.Size(59, 13);
            this.movieTitleLabel.TabIndex = 1;
            this.movieTitleLabel.Text = "Movie Title";
            // 
            // directorLastNameTextBox
            // 
            this.directorLastNameTextBox.Location = new System.Drawing.Point(180, 159);
            this.directorLastNameTextBox.Name = "directorLastNameTextBox";
            this.directorLastNameTextBox.Size = new System.Drawing.Size(130, 20);
            this.directorLastNameTextBox.TabIndex = 2;
            // 
            // directorFirstNameTextbox
            // 
            this.directorFirstNameTextbox.Location = new System.Drawing.Point(12, 159);
            this.directorFirstNameTextbox.Name = "directorFirstNameTextbox";
            this.directorFirstNameTextbox.Size = new System.Drawing.Size(136, 20);
            this.directorFirstNameTextbox.TabIndex = 3;
            // 
            // directorFirstNameLabel
            // 
            this.directorFirstNameLabel.AutoSize = true;
            this.directorFirstNameLabel.Location = new System.Drawing.Point(15, 143);
            this.directorFirstNameLabel.Name = "directorFirstNameLabel";
            this.directorFirstNameLabel.Size = new System.Drawing.Size(97, 13);
            this.directorFirstNameLabel.TabIndex = 4;
            this.directorFirstNameLabel.Text = "Director First Name";
            // 
            // directorLastNameLabel
            // 
            this.directorLastNameLabel.AutoSize = true;
            this.directorLastNameLabel.Location = new System.Drawing.Point(213, 143);
            this.directorLastNameLabel.Name = "directorLastNameLabel";
            this.directorLastNameLabel.Size = new System.Drawing.Size(98, 13);
            this.directorLastNameLabel.TabIndex = 5;
            this.directorLastNameLabel.Text = "Director Last Name";
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Items.AddRange(new object[] {
            "Family",
            "Crime",
            "Biography",
            "News",
            "Comedy",
            "Drama",
            "Horror",
            "Adventure",
            "War",
            "Sport",
            "Sci-Fi",
            "Short",
            "Animation",
            "Thriller",
            "Romance",
            "History",
            "Mystery",
            "Action",
            "Western",
            "Film-Noir",
            "Documentary",
            "Musical",
            "Music",
            "Fantasy"});
            this.genreComboBox.Location = new System.Drawing.Point(174, 63);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(136, 21);
            this.genreComboBox.TabIndex = 6;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(226, 46);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(36, 13);
            this.genreLabel.TabIndex = 7;
            this.genreLabel.Text = "Genre";
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Location = new System.Drawing.Point(145, 197);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(38, 13);
            this.ratingLabel.TabIndex = 10;
            this.ratingLabel.Text = "Rating";
            // 
            // labelLowerRating
            // 
            this.labelLowerRating.AutoSize = true;
            this.labelLowerRating.Location = new System.Drawing.Point(9, 221);
            this.labelLowerRating.Name = "labelLowerRating";
            this.labelLowerRating.Size = new System.Drawing.Size(13, 13);
            this.labelLowerRating.TabIndex = 11;
            this.labelLowerRating.Text = "0";
            // 
            // labelHigherRating
            // 
            this.labelHigherRating.AutoSize = true;
            this.labelHigherRating.Location = new System.Drawing.Point(303, 221);
            this.labelHigherRating.Name = "labelHigherRating";
            this.labelHigherRating.Size = new System.Drawing.Size(25, 13);
            this.labelHigherRating.TabIndex = 12;
            this.labelHigherRating.Text = "100";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(14, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Admin Mode";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // resultsListView
            // 
            this.resultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.movieTitleHeader,
            this.directorFirstNameHeader,
            this.directorLastNameHeader,
            this.genreHeader,
            this.minHeader,
            this.maxHeader});
            this.resultsListView.Location = new System.Drawing.Point(655, 12);
            this.resultsListView.Name = "resultsListView";
            this.resultsListView.Size = new System.Drawing.Size(416, 351);
            this.resultsListView.TabIndex = 15;
            this.resultsListView.UseCompatibleStateImageBehavior = false;
            // 
            // movieTitleHeader
            // 
            this.movieTitleHeader.Text = "Movie Title";
            // 
            // directorFirstNameHeader
            // 
            this.directorFirstNameHeader.Text = "Director First Name";
            // 
            // directorLastNameHeader
            // 
            this.directorLastNameHeader.Text = "Director Last Name";
            // 
            // genreHeader
            // 
            this.genreHeader.Text = "Genre";
            // 
            // minHeader
            // 
            this.minHeader.Text = "Minimum Rating";
            // 
            // maxHeader
            // 
            this.maxHeader.Text = "Max Rating";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(12, 288);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(142, 40);
            this.searchButton.TabIndex = 16;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(174, 288);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(142, 40);
            this.resetButton.TabIndex = 17;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // popularityNumericUpDown
            // 
            this.popularityNumericUpDown.Location = new System.Drawing.Point(355, 62);
            this.popularityNumericUpDown.Name = "popularityNumericUpDown";
            this.popularityNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.popularityNumericUpDown.TabIndex = 18;
            // 
            // languageComboBox
            // 
            this.languageComboBox.FormattingEnabled = true;
            this.languageComboBox.Items.AddRange(new object[] {
            "English",
            "Zulu",
            "Dzongkha",
            "Telugu",
            "Cantonese",
            "Indonesian",
            "Swedish",
            "Japanese",
            "Tamil",
            "Dari",
            "Czech",
            "Portuguese",
            "Danish",
            "Norwegian",
            "Romanian",
            "None",
            "Thai",
            "Panjabi",
            "Hungarian",
            "Chinese",
            "Aboriginal",
            "Swahili",
            "German",
            "Persian",
            "Mandarin",
            "Russian",
            "Kazakh",
            "Hindi",
            "French",
            "Maya",
            "Bosnian",
            "Aramaic",
            "Dutch",
            "Spanish",
            "Filipino",
            "Vietnamese",
            "Slovenian",
            "Mongolian",
            "Polish",
            "Icelandic",
            "Hebrew",
            "Italian",
            "Arabic",
            "Greek",
            "Korean"});
            this.languageComboBox.Location = new System.Drawing.Point(494, 61);
            this.languageComboBox.Name = "languageComboBox";
            this.languageComboBox.Size = new System.Drawing.Size(120, 21);
            this.languageComboBox.TabIndex = 19;
            // 
            // languageLabel
            // 
            this.languageLabel.AutoSize = true;
            this.languageLabel.Location = new System.Drawing.Point(529, 46);
            this.languageLabel.Name = "languageLabel";
            this.languageLabel.Size = new System.Drawing.Size(55, 13);
            this.languageLabel.TabIndex = 20;
            this.languageLabel.Text = "Language";
            // 
            // popularityLabel
            // 
            this.popularityLabel.AutoSize = true;
            this.popularityLabel.Location = new System.Drawing.Point(388, 46);
            this.popularityLabel.Name = "popularityLabel";
            this.popularityLabel.Size = new System.Drawing.Size(53, 13);
            this.popularityLabel.TabIndex = 21;
            this.popularityLabel.Text = "Popularity";
            // 
            // actorFirstNameTextBox
            // 
            this.actorFirstNameTextBox.Location = new System.Drawing.Point(12, 108);
            this.actorFirstNameTextBox.Name = "actorFirstNameTextBox";
            this.actorFirstNameTextBox.Size = new System.Drawing.Size(136, 20);
            this.actorFirstNameTextBox.TabIndex = 22;
            // 
            // actorLastNameTextBox
            // 
            this.actorLastNameTextBox.Location = new System.Drawing.Point(180, 108);
            this.actorLastNameTextBox.Name = "actorLastNameTextBox";
            this.actorLastNameTextBox.Size = new System.Drawing.Size(130, 20);
            this.actorLastNameTextBox.TabIndex = 23;
            // 
            // labelActorFirstName
            // 
            this.labelActorFirstName.AutoSize = true;
            this.labelActorFirstName.Location = new System.Drawing.Point(14, 92);
            this.labelActorFirstName.Name = "labelActorFirstName";
            this.labelActorFirstName.Size = new System.Drawing.Size(85, 13);
            this.labelActorFirstName.TabIndex = 24;
            this.labelActorFirstName.Text = "Actor First Name";
            // 
            // actorlastNameLabel
            // 
            this.actorlastNameLabel.AutoSize = true;
            this.actorlastNameLabel.Location = new System.Drawing.Point(224, 92);
            this.actorlastNameLabel.Name = "actorlastNameLabel";
            this.actorlastNameLabel.Size = new System.Drawing.Size(86, 13);
            this.actorlastNameLabel.TabIndex = 25;
            this.actorlastNameLabel.Text = "Actor Last Name";
            // 
            // advancedSearchLinkLabel
            // 
            this.advancedSearchLinkLabel.AutoSize = true;
            this.advancedSearchLinkLabel.Location = new System.Drawing.Point(12, 182);
            this.advancedSearchLinkLabel.Name = "advancedSearchLinkLabel";
            this.advancedSearchLinkLabel.Size = new System.Drawing.Size(93, 13);
            this.advancedSearchLinkLabel.TabIndex = 26;
            this.advancedSearchLinkLabel.TabStop = true;
            this.advancedSearchLinkLabel.Text = "Advanced Search";
            this.advancedSearchLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.advancedSearchLinkLabel_LinkClicked);
            // 
            // budgetNumericUpDown
            // 
            this.budgetNumericUpDown.Location = new System.Drawing.Point(355, 108);
            this.budgetNumericUpDown.Name = "budgetNumericUpDown";
            this.budgetNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.budgetNumericUpDown.TabIndex = 27;
            // 
            // grossNumbericUpdown
            // 
            this.grossNumbericUpdown.Location = new System.Drawing.Point(494, 108);
            this.grossNumbericUpdown.Name = "grossNumbericUpdown";
            this.grossNumbericUpdown.Size = new System.Drawing.Size(120, 20);
            this.grossNumbericUpdown.TabIndex = 28;
            // 
            // budgetLabel
            // 
            this.budgetLabel.AutoSize = true;
            this.budgetLabel.Location = new System.Drawing.Point(388, 92);
            this.budgetLabel.Name = "budgetLabel";
            this.budgetLabel.Size = new System.Drawing.Size(41, 13);
            this.budgetLabel.TabIndex = 29;
            this.budgetLabel.Text = "Budget";
            // 
            // grossLabel
            // 
            this.grossLabel.AutoSize = true;
            this.grossLabel.Location = new System.Drawing.Point(529, 92);
            this.grossLabel.Name = "grossLabel";
            this.grossLabel.Size = new System.Drawing.Size(34, 13);
            this.grossLabel.TabIndex = 30;
            this.grossLabel.Text = "Gross";
            // 
            // countryComboBox
            // 
            this.countryComboBox.FormattingEnabled = true;
            this.countryComboBox.Location = new System.Drawing.Point(494, 158);
            this.countryComboBox.Name = "countryComboBox";
            this.countryComboBox.Size = new System.Drawing.Size(121, 21);
            this.countryComboBox.TabIndex = 31;
            // 
            // countryLabel
            // 
            this.countryLabel.AutoSize = true;
            this.countryLabel.Location = new System.Drawing.Point(529, 142);
            this.countryLabel.Name = "countryLabel";
            this.countryLabel.Size = new System.Drawing.Size(43, 13);
            this.countryLabel.TabIndex = 32;
            this.countryLabel.Text = "Country";
            // 
            // colorComboBox
            // 
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Items.AddRange(new object[] {
            "Color",
            "Black and White"});
            this.colorComboBox.Location = new System.Drawing.Point(354, 158);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(121, 21);
            this.colorComboBox.TabIndex = 33;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(394, 143);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(31, 13);
            this.colorLabel.TabIndex = 34;
            this.colorLabel.Text = "Color";
            // 
            // AspectRatioComboBox
            // 
            this.AspectRatioComboBox.FormattingEnabled = true;
            this.AspectRatioComboBox.Items.AddRange(new object[] {
            "1.75",
            "1.2",
            "2",
            "1.85",
            "1.44",
            "2.24",
            "2.76",
            "1.66",
            "16",
            "2.39",
            "1.77",
            "1.78",
            "1.5",
            "1.37",
            "2.55",
            "1.18",
            "1.33",
            "2.4",
            "2.2",
            "2.35"});
            this.AspectRatioComboBox.Location = new System.Drawing.Point(421, 213);
            this.AspectRatioComboBox.Name = "AspectRatioComboBox";
            this.AspectRatioComboBox.Size = new System.Drawing.Size(121, 21);
            this.AspectRatioComboBox.TabIndex = 35;
            // 
            // aspectRatioLabel
            // 
            this.aspectRatioLabel.AutoSize = true;
            this.aspectRatioLabel.Location = new System.Drawing.Point(449, 197);
            this.aspectRatioLabel.Name = "aspectRatioLabel";
            this.aspectRatioLabel.Size = new System.Drawing.Size(68, 13);
            this.aspectRatioLabel.TabIndex = 36;
            this.aspectRatioLabel.Text = "Aspect Ratio";
            // 
            // actor2LastNameTextBox
            // 
            this.actor2LastNameTextBox.Location = new System.Drawing.Point(494, 255);
            this.actor2LastNameTextBox.Name = "actor2LastNameTextBox";
            this.actor2LastNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.actor2LastNameTextBox.TabIndex = 37;
            // 
            // actor2FirstNameTextBox
            // 
            this.actor2FirstNameTextBox.Location = new System.Drawing.Point(354, 255);
            this.actor2FirstNameTextBox.Name = "actor2FirstNameTextBox";
            this.actor2FirstNameTextBox.Size = new System.Drawing.Size(121, 20);
            this.actor2FirstNameTextBox.TabIndex = 38;
            // 
            // actor2LastNameLabel
            // 
            this.actor2LastNameLabel.AutoSize = true;
            this.actor2LastNameLabel.Location = new System.Drawing.Point(507, 239);
            this.actor2LastNameLabel.Name = "actor2LastNameLabel";
            this.actor2LastNameLabel.Size = new System.Drawing.Size(95, 13);
            this.actor2LastNameLabel.TabIndex = 39;
            this.actor2LastNameLabel.Text = "Actor 2 Last Name";
            // 
            // actor2FirstNameLabel
            // 
            this.actor2FirstNameLabel.AutoSize = true;
            this.actor2FirstNameLabel.Location = new System.Drawing.Point(371, 239);
            this.actor2FirstNameLabel.Name = "actor2FirstNameLabel";
            this.actor2FirstNameLabel.Size = new System.Drawing.Size(94, 13);
            this.actor2FirstNameLabel.TabIndex = 40;
            this.actor2FirstNameLabel.Text = "Actor 2 First Name";
            // 
            // actor3FirstNameTextBox
            // 
            this.actor3FirstNameTextBox.Location = new System.Drawing.Point(355, 308);
            this.actor3FirstNameTextBox.Name = "actor3FirstNameTextBox";
            this.actor3FirstNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.actor3FirstNameTextBox.TabIndex = 41;
            // 
            // actor3LastNameTextBox
            // 
            this.actor3LastNameTextBox.Location = new System.Drawing.Point(494, 308);
            this.actor3LastNameTextBox.Name = "actor3LastNameTextBox";
            this.actor3LastNameTextBox.Size = new System.Drawing.Size(120, 20);
            this.actor3LastNameTextBox.TabIndex = 42;
            // 
            // actor3FirstNameLabel
            // 
            this.actor3FirstNameLabel.AutoSize = true;
            this.actor3FirstNameLabel.Location = new System.Drawing.Point(371, 288);
            this.actor3FirstNameLabel.Name = "actor3FirstNameLabel";
            this.actor3FirstNameLabel.Size = new System.Drawing.Size(94, 13);
            this.actor3FirstNameLabel.TabIndex = 43;
            this.actor3FirstNameLabel.Text = "Actor 3 First Name";
            // 
            // actor3LastNameLabel
            // 
            this.actor3LastNameLabel.AutoSize = true;
            this.actor3LastNameLabel.Location = new System.Drawing.Point(507, 288);
            this.actor3LastNameLabel.Name = "actor3LastNameLabel";
            this.actor3LastNameLabel.Size = new System.Drawing.Size(95, 13);
            this.actor3LastNameLabel.TabIndex = 44;
            this.actor3LastNameLabel.Text = "Actor 3 Last Name";
            // 
            // ratingSelectionSlider
            // 
            this.ratingSelectionSlider.Location = new System.Drawing.Point(28, 215);
            this.ratingSelectionSlider.Max = 100;
            this.ratingSelectionSlider.Min = 0;
            this.ratingSelectionSlider.Name = "ratingSelectionSlider";
            this.ratingSelectionSlider.SelectedMax = 100;
            this.ratingSelectionSlider.SelectedMin = 0;
            this.ratingSelectionSlider.Size = new System.Drawing.Size(269, 19);
            this.ratingSelectionSlider.TabIndex = 13;
            this.ratingSelectionSlider.Value = 50;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 388);
            this.Controls.Add(this.actor3LastNameLabel);
            this.Controls.Add(this.actor3FirstNameLabel);
            this.Controls.Add(this.actor3LastNameTextBox);
            this.Controls.Add(this.actor3FirstNameTextBox);
            this.Controls.Add(this.actor2FirstNameLabel);
            this.Controls.Add(this.actor2LastNameLabel);
            this.Controls.Add(this.actor2FirstNameTextBox);
            this.Controls.Add(this.actor2LastNameTextBox);
            this.Controls.Add(this.aspectRatioLabel);
            this.Controls.Add(this.AspectRatioComboBox);
            this.Controls.Add(this.colorLabel);
            this.Controls.Add(this.colorComboBox);
            this.Controls.Add(this.countryLabel);
            this.Controls.Add(this.countryComboBox);
            this.Controls.Add(this.grossLabel);
            this.Controls.Add(this.budgetLabel);
            this.Controls.Add(this.grossNumbericUpdown);
            this.Controls.Add(this.budgetNumericUpDown);
            this.Controls.Add(this.advancedSearchLinkLabel);
            this.Controls.Add(this.actorlastNameLabel);
            this.Controls.Add(this.labelActorFirstName);
            this.Controls.Add(this.actorLastNameTextBox);
            this.Controls.Add(this.actorFirstNameTextBox);
            this.Controls.Add(this.popularityLabel);
            this.Controls.Add(this.languageLabel);
            this.Controls.Add(this.languageComboBox);
            this.Controls.Add(this.popularityNumericUpDown);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.resultsListView);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.ratingSelectionSlider);
            this.Controls.Add(this.labelHigherRating);
            this.Controls.Add(this.labelLowerRating);
            this.Controls.Add(this.ratingLabel);
            this.Controls.Add(this.genreLabel);
            this.Controls.Add(this.genreComboBox);
            this.Controls.Add(this.directorLastNameLabel);
            this.Controls.Add(this.directorFirstNameLabel);
            this.Controls.Add(this.directorFirstNameTextbox);
            this.Controls.Add(this.directorLastNameTextBox);
            this.Controls.Add(this.movieTitleLabel);
            this.Controls.Add(this.movieTitleTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.popularityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.budgetNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grossNumbericUpdown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox movieTitleTextBox;
        private System.Windows.Forms.Label movieTitleLabel;
        private System.Windows.Forms.TextBox directorLastNameTextBox;
        private System.Windows.Forms.TextBox directorFirstNameTextbox;
        private System.Windows.Forms.Label directorFirstNameLabel;
        private System.Windows.Forms.Label directorLastNameLabel;
        private System.Windows.Forms.ComboBox genreComboBox;
        private System.Windows.Forms.Label genreLabel;
        private System.Windows.Forms.Label ratingLabel;
        private System.Windows.Forms.Label labelLowerRating;
        private System.Windows.Forms.Label labelHigherRating;
        private SelectionRangeSlider ratingSelectionSlider;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView resultsListView;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ColumnHeader movieTitleHeader;
        private System.Windows.Forms.ColumnHeader directorFirstNameHeader;
        private System.Windows.Forms.ColumnHeader directorLastNameHeader;
        private System.Windows.Forms.ColumnHeader genreHeader;
        private System.Windows.Forms.ColumnHeader minHeader;
        private System.Windows.Forms.ColumnHeader maxHeader;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.NumericUpDown popularityNumericUpDown;
        private System.Windows.Forms.ComboBox languageComboBox;
        private System.Windows.Forms.Label languageLabel;
        private System.Windows.Forms.Label popularityLabel;
        private System.Windows.Forms.TextBox actorFirstNameTextBox;
        private System.Windows.Forms.TextBox actorLastNameTextBox;
        private System.Windows.Forms.Label labelActorFirstName;
        private System.Windows.Forms.Label actorlastNameLabel;
        private System.Windows.Forms.LinkLabel advancedSearchLinkLabel;
        private System.Windows.Forms.NumericUpDown budgetNumericUpDown;
        private System.Windows.Forms.NumericUpDown grossNumbericUpdown;
        private System.Windows.Forms.Label budgetLabel;
        private System.Windows.Forms.Label grossLabel;
        private System.Windows.Forms.ComboBox countryComboBox;
        private System.Windows.Forms.Label countryLabel;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.ComboBox AspectRatioComboBox;
        private System.Windows.Forms.Label aspectRatioLabel;
        private System.Windows.Forms.TextBox actor2LastNameTextBox;
        private System.Windows.Forms.TextBox actor2FirstNameTextBox;
        private System.Windows.Forms.Label actor2LastNameLabel;
        private System.Windows.Forms.Label actor2FirstNameLabel;
        private System.Windows.Forms.TextBox actor3FirstNameTextBox;
        private System.Windows.Forms.TextBox actor3LastNameTextBox;
        private System.Windows.Forms.Label actor3FirstNameLabel;
        private System.Windows.Forms.Label actor3LastNameLabel;
    }
}

