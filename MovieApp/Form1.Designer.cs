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
            this.queryButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.directorFirstName = new System.Windows.Forms.Label();
            this.directorLastName = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.actorFirstName = new System.Windows.Forms.Label();
            this.actorLastName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // queryButton
            // 
            this.queryButton.Location = new System.Drawing.Point(325, 257);
            this.queryButton.Name = "queryButton";
            this.queryButton.Size = new System.Drawing.Size(280, 117);
            this.queryButton.TabIndex = 0;
            this.queryButton.Text = "Look shit up";
            this.queryButton.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(107, 78);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(149, 20);
            this.textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(107, 125);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(149, 20);
            this.textBox2.TabIndex = 2;
            // 
            // directorFirstName
            // 
            this.directorFirstName.AutoSize = true;
            this.directorFirstName.Location = new System.Drawing.Point(129, 60);
            this.directorFirstName.Name = "directorFirstName";
            this.directorFirstName.Size = new System.Drawing.Size(113, 15);
            this.directorFirstName.TabIndex = 3;
            this.directorFirstName.Text = "Director First Name";
            // 
            // directorLastName
            // 
            this.directorLastName.AutoSize = true;
            this.directorLastName.Location = new System.Drawing.Point(129, 107);
            this.directorLastName.Name = "directorLastName";
            this.directorLastName.Size = new System.Drawing.Size(113, 15);
            this.directorLastName.TabIndex = 4;
            this.directorLastName.Text = "Director Last Name";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(325, 78);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(149, 20);
            this.textBox3.TabIndex = 5;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(325, 125);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(149, 20);
            this.textBox4.TabIndex = 6;
            // 
            // actorFirstName
            // 
            this.actorFirstName.AutoSize = true;
            this.actorFirstName.Location = new System.Drawing.Point(355, 60);
            this.actorFirstName.Name = "actorFirstName";
            this.actorFirstName.Size = new System.Drawing.Size(97, 15);
            this.actorFirstName.TabIndex = 7;
            this.actorFirstName.Text = "Actor First Name";
            // 
            // actorLastName
            // 
            this.actorLastName.AutoSize = true;
            this.actorLastName.Location = new System.Drawing.Point(355, 107);
            this.actorLastName.Name = "actorLastName";
            this.actorLastName.Size = new System.Drawing.Size(97, 15);
            this.actorLastName.TabIndex = 8;
            this.actorLastName.Text = "Actor Last Name";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 450);
            this.Controls.Add(this.actorLastName);
            this.Controls.Add(this.actorFirstName);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.directorLastName);
            this.Controls.Add(this.directorFirstName);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.queryButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button queryButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label directorFirstName;
        private System.Windows.Forms.Label directorLastName;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label actorFirstName;
        private System.Windows.Forms.Label actorLastName;
    }
}

