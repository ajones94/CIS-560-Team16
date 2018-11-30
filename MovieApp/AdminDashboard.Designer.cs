namespace MovieApp
{
    partial class AdminDashboard
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
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.movieTitleAdminLabel = new System.Windows.Forms.Label();
            this.directorFirstNameAdminLabel = new System.Windows.Forms.Label();
            this.directorLastNameAdminLabel = new System.Windows.Forms.Label();
            this.genreAdminLabel = new System.Windows.Forms.Label();
            this.ratingAdminLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(151, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(223, 56);
            this.button1.TabIndex = 0;
            this.button1.Text = "CLICK";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 43);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(173, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(69, 94);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(173, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(275, 94);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(173, 20);
            this.textBox3.TabIndex = 3;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(69, 149);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 21);
            this.comboBox1.TabIndex = 4;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown1.Location = new System.Drawing.Point(326, 150);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(60, 20);
            this.numericUpDown1.TabIndex = 5;
            this.numericUpDown1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // movieTitleAdminLabel
            // 
            this.movieTitleAdminLabel.AutoSize = true;
            this.movieTitleAdminLabel.Location = new System.Drawing.Point(119, 25);
            this.movieTitleAdminLabel.Name = "movieTitleAdminLabel";
            this.movieTitleAdminLabel.Size = new System.Drawing.Size(66, 15);
            this.movieTitleAdminLabel.TabIndex = 6;
            this.movieTitleAdminLabel.Text = "Movie Title";
            // 
            // directorFirstNameAdminLabel
            // 
            this.directorFirstNameAdminLabel.AutoSize = true;
            this.directorFirstNameAdminLabel.Location = new System.Drawing.Point(97, 76);
            this.directorFirstNameAdminLabel.Name = "directorFirstNameAdminLabel";
            this.directorFirstNameAdminLabel.Size = new System.Drawing.Size(113, 15);
            this.directorFirstNameAdminLabel.TabIndex = 7;
            this.directorFirstNameAdminLabel.Text = "Director First Name";
            // 
            // directorLastNameAdminLabel
            // 
            this.directorLastNameAdminLabel.AutoSize = true;
            this.directorLastNameAdminLabel.Location = new System.Drawing.Point(308, 76);
            this.directorLastNameAdminLabel.Name = "directorLastNameAdminLabel";
            this.directorLastNameAdminLabel.Size = new System.Drawing.Size(113, 15);
            this.directorLastNameAdminLabel.TabIndex = 8;
            this.directorLastNameAdminLabel.Text = "Director Last Name";
            // 
            // genreAdminLabel
            // 
            this.genreAdminLabel.AutoSize = true;
            this.genreAdminLabel.Location = new System.Drawing.Point(130, 131);
            this.genreAdminLabel.Name = "genreAdminLabel";
            this.genreAdminLabel.Size = new System.Drawing.Size(41, 15);
            this.genreAdminLabel.TabIndex = 9;
            this.genreAdminLabel.Text = "Genre";
            // 
            // ratingAdminLabel
            // 
            this.ratingAdminLabel.AutoSize = true;
            this.ratingAdminLabel.Location = new System.Drawing.Point(343, 131);
            this.ratingAdminLabel.Name = "ratingAdminLabel";
            this.ratingAdminLabel.Size = new System.Drawing.Size(43, 15);
            this.ratingAdminLabel.TabIndex = 10;
            this.ratingAdminLabel.Text = "Rating";
            // 
            // AdminDashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 450);
            this.Controls.Add(this.ratingAdminLabel);
            this.Controls.Add(this.genreAdminLabel);
            this.Controls.Add(this.directorLastNameAdminLabel);
            this.Controls.Add(this.directorFirstNameAdminLabel);
            this.Controls.Add(this.movieTitleAdminLabel);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "AdminDashboard";
            this.Text = "AdminDashboard";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label movieTitleAdminLabel;
        private System.Windows.Forms.Label directorFirstNameAdminLabel;
        private System.Windows.Forms.Label directorLastNameAdminLabel;
        private System.Windows.Forms.Label genreAdminLabel;
        private System.Windows.Forms.Label ratingAdminLabel;
    }
}