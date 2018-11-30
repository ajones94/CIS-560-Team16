﻿namespace MovieApp
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
            this.ratingSelectionSlider = new MovieApp.SelectionRangeSlider();
            this.label5 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.searchButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // movieTitleTextBox
            // 
            this.movieTitleTextBox.Location = new System.Drawing.Point(98, 75);
            this.movieTitleTextBox.Name = "movieTitleTextBox";
            this.movieTitleTextBox.Size = new System.Drawing.Size(136, 20);
            this.movieTitleTextBox.TabIndex = 0;
            // 
            // movieTitleLabel
            // 
            this.movieTitleLabel.AutoSize = true;
            this.movieTitleLabel.Location = new System.Drawing.Point(130, 46);
            this.movieTitleLabel.Name = "movieTitleLabel";
            this.movieTitleLabel.Size = new System.Drawing.Size(59, 13);
            this.movieTitleLabel.TabIndex = 1;
            this.movieTitleLabel.Text = "Movie Title";
            // 
            // directorLastNameTextBox
            // 
            this.directorLastNameTextBox.Location = new System.Drawing.Point(180, 116);
            this.directorLastNameTextBox.Name = "directorLastNameTextBox";
            this.directorLastNameTextBox.Size = new System.Drawing.Size(130, 20);
            this.directorLastNameTextBox.TabIndex = 2;
            // 
            // directorFirstNameTextbox
            // 
            this.directorFirstNameTextbox.Location = new System.Drawing.Point(12, 116);
            this.directorFirstNameTextbox.Name = "directorFirstNameTextbox";
            this.directorFirstNameTextbox.Size = new System.Drawing.Size(130, 20);
            this.directorFirstNameTextbox.TabIndex = 3;
            // 
            // directorFirstNameLabel
            // 
            this.directorFirstNameLabel.AutoSize = true;
            this.directorFirstNameLabel.Location = new System.Drawing.Point(12, 98);
            this.directorFirstNameLabel.Name = "directorFirstNameLabel";
            this.directorFirstNameLabel.Size = new System.Drawing.Size(97, 13);
            this.directorFirstNameLabel.TabIndex = 4;
            this.directorFirstNameLabel.Text = "Director First Name";
            // 
            // directorLastNameLabel
            // 
            this.directorLastNameLabel.AutoSize = true;
            this.directorLastNameLabel.Location = new System.Drawing.Point(177, 98);
            this.directorLastNameLabel.Name = "directorLastNameLabel";
            this.directorLastNameLabel.Size = new System.Drawing.Size(98, 13);
            this.directorLastNameLabel.TabIndex = 5;
            this.directorLastNameLabel.Text = "Director Last Name";
            // 
            // genreComboBox
            // 
            this.genreComboBox.FormattingEnabled = true;
            this.genreComboBox.Items.AddRange(new object[] {
            "Action",
            "Comedy",
            "Western",
            "Thriller",
            "Drama",
            "Rom-Com",
            "Musical"});
            this.genreComboBox.Location = new System.Drawing.Point(98, 172);
            this.genreComboBox.Name = "genreComboBox";
            this.genreComboBox.Size = new System.Drawing.Size(136, 21);
            this.genreComboBox.TabIndex = 6;
            // 
            // genreLabel
            // 
            this.genreLabel.AutoSize = true;
            this.genreLabel.Location = new System.Drawing.Point(143, 154);
            this.genreLabel.Name = "genreLabel";
            this.genreLabel.Size = new System.Drawing.Size(36, 13);
            this.genreLabel.TabIndex = 7;
            this.genreLabel.Text = "Genre";
            // 
            // ratingLabel
            // 
            this.ratingLabel.AutoSize = true;
            this.ratingLabel.Location = new System.Drawing.Point(141, 206);
            this.ratingLabel.Name = "ratingLabel";
            this.ratingLabel.Size = new System.Drawing.Size(38, 13);
            this.ratingLabel.TabIndex = 10;
            this.ratingLabel.Text = "Rating";
            // 
            // labelLowerRating
            // 
            this.labelLowerRating.AutoSize = true;
            this.labelLowerRating.Location = new System.Drawing.Point(9, 224);
            this.labelLowerRating.Name = "labelLowerRating";
            this.labelLowerRating.Size = new System.Drawing.Size(13, 13);
            this.labelLowerRating.TabIndex = 11;
            this.labelLowerRating.Text = "0";
            // 
            // labelHigherRating
            // 
            this.labelHigherRating.AutoSize = true;
            this.labelHigherRating.Location = new System.Drawing.Point(316, 224);
            this.labelHigherRating.Name = "labelHigherRating";
            this.labelHigherRating.Size = new System.Drawing.Size(25, 13);
            this.labelHigherRating.TabIndex = 12;
            this.labelHigherRating.Text = "100";
            // 
            // ratingSelectionSlider
            // 
            this.ratingSelectionSlider.Location = new System.Drawing.Point(28, 224);
            this.ratingSelectionSlider.Max = 100;
            this.ratingSelectionSlider.Min = 0;
            this.ratingSelectionSlider.Name = "ratingSelectionSlider";
            this.ratingSelectionSlider.SelectedMax = 100;
            this.ratingSelectionSlider.SelectedMin = 0;
            this.ratingSelectionSlider.Size = new System.Drawing.Size(282, 19);
            this.ratingSelectionSlider.TabIndex = 13;
            this.ratingSelectionSlider.Value = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(66, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Admin Mode";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(626, 33);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(364, 402);
            this.listView1.TabIndex = 15;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(41, 299);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(256, 86);
            this.searchButton.TabIndex = 16;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 450);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.listView1);
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
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button searchButton;
    }
}

