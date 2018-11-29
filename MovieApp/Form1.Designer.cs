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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Rating = new System.Windows.Forms.Label();
            this.labelLowerRating = new System.Windows.Forms.Label();
            this.labelHigherRating = new System.Windows.Forms.Label();
            this.selectionRangeSlider1 = new MovieApp.SelectionRangeSlider();
            this.label5 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(98, 75);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(136, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(130, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Movie Title";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(180, 116);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(130, 20);
            this.textBox2.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(12, 116);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(130, 20);
            this.textBox3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Director First Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Director Last Name";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Action",
            "Comedy",
            "Western",
            "Thriller",
            "Drama",
            "Rom-Com",
            "Musical"});
            this.comboBox1.Location = new System.Drawing.Point(98, 172);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(136, 21);
            this.comboBox1.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(143, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Genre";
            // 
            // Rating
            // 
            this.Rating.AutoSize = true;
            this.Rating.Location = new System.Drawing.Point(141, 206);
            this.Rating.Name = "Rating";
            this.Rating.Size = new System.Drawing.Size(43, 15);
            this.Rating.TabIndex = 10;
            this.Rating.Text = "Rating";
            // 
            // labelLowerRating
            // 
            this.labelLowerRating.AutoSize = true;
            this.labelLowerRating.Location = new System.Drawing.Point(9, 224);
            this.labelLowerRating.Name = "labelLowerRating";
            this.labelLowerRating.Size = new System.Drawing.Size(14, 15);
            this.labelLowerRating.TabIndex = 11;
            this.labelLowerRating.Text = "0";
            // 
            // labelHigherRating
            // 
            this.labelHigherRating.AutoSize = true;
            this.labelHigherRating.Location = new System.Drawing.Point(316, 224);
            this.labelHigherRating.Name = "labelHigherRating";
            this.labelHigherRating.Size = new System.Drawing.Size(28, 15);
            this.labelHigherRating.TabIndex = 12;
            this.labelHigherRating.Text = "100";
            // 
            // selectionRangeSlider1
            // 
            this.selectionRangeSlider1.Location = new System.Drawing.Point(28, 224);
            this.selectionRangeSlider1.Max = 100;
            this.selectionRangeSlider1.Min = 0;
            this.selectionRangeSlider1.Name = "selectionRangeSlider1";
            this.selectionRangeSlider1.SelectedMax = 100;
            this.selectionRangeSlider1.SelectedMin = 0;
            this.selectionRangeSlider1.Size = new System.Drawing.Size(282, 19);
            this.selectionRangeSlider1.TabIndex = 13;
            this.selectionRangeSlider1.Value = 50;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(0, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 15);
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(34, 302);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(256, 106);
            this.button1.TabIndex = 16;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.selectionRangeSlider1);
            this.Controls.Add(this.labelHigherRating);
            this.Controls.Add(this.labelLowerRating);
            this.Controls.Add(this.Rating);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Rating;
        private System.Windows.Forms.Label labelLowerRating;
        private System.Windows.Forms.Label labelHigherRating;
        private SelectionRangeSlider selectionRangeSlider1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Button button1;
    }
}

