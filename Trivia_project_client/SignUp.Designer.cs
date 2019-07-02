namespace Trivia_project_client
{
    partial class SignUp
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
            this.trivia_label = new System.Windows.Forms.Label();
            this.username_label = new System.Windows.Forms.Label();
            this.password_label = new System.Windows.Forms.Label();
            this.email_label = new System.Windows.Forms.Label();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.email_textBox = new System.Windows.Forms.TextBox();
            this.submit_btn = new System.Windows.Forms.Button();
            this.back_btn = new System.Windows.Forms.Button();
            this.arrow_picture_box = new System.Windows.Forms.PictureBox();
            this.checking_sign_up_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.arrow_picture_box)).BeginInit();
            this.SuspendLayout();
            // 
            // trivia_label
            // 
            this.trivia_label.AutoSize = true;
            this.trivia_label.BackColor = System.Drawing.Color.White;
            this.trivia_label.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trivia_label.Location = new System.Drawing.Point(328, 9);
            this.trivia_label.Name = "trivia_label";
            this.trivia_label.Size = new System.Drawing.Size(213, 90);
            this.trivia_label.TabIndex = 0;
            this.trivia_label.Text = "Trivia";
            // 
            // username_label
            // 
            this.username_label.AutoSize = true;
            this.username_label.BackColor = System.Drawing.Color.White;
            this.username_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_label.Location = new System.Drawing.Point(208, 183);
            this.username_label.Name = "username_label";
            this.username_label.Size = new System.Drawing.Size(125, 25);
            this.username_label.TabIndex = 1;
            this.username_label.Text = "Username:";
            // 
            // password_label
            // 
            this.password_label.AutoSize = true;
            this.password_label.BackColor = System.Drawing.Color.White;
            this.password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_label.Location = new System.Drawing.Point(208, 235);
            this.password_label.Name = "password_label";
            this.password_label.Size = new System.Drawing.Size(121, 25);
            this.password_label.TabIndex = 2;
            this.password_label.Text = "Password:";
            // 
            // email_label
            // 
            this.email_label.AutoSize = true;
            this.email_label.BackColor = System.Drawing.Color.White;
            this.email_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_label.Location = new System.Drawing.Point(208, 287);
            this.email_label.Name = "email_label";
            this.email_label.Size = new System.Drawing.Size(77, 25);
            this.email_label.TabIndex = 3;
            this.email_label.Text = "Email:";
            // 
            // username_textBox
            // 
            this.username_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username_textBox.Location = new System.Drawing.Point(339, 185);
            this.username_textBox.Multiline = true;
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(343, 29);
            this.username_textBox.TabIndex = 4;
            // 
            // password_textBox
            // 
            this.password_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_textBox.Location = new System.Drawing.Point(339, 235);
            this.password_textBox.Multiline = true;
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(343, 29);
            this.password_textBox.TabIndex = 5;
            // 
            // email_textBox
            // 
            this.email_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.email_textBox.Location = new System.Drawing.Point(339, 285);
            this.email_textBox.Multiline = true;
            this.email_textBox.Name = "email_textBox";
            this.email_textBox.Size = new System.Drawing.Size(343, 29);
            this.email_textBox.TabIndex = 6;
            // 
            // submit_btn
            // 
            this.submit_btn.Font = new System.Drawing.Font("High Tower Text", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.submit_btn.ForeColor = System.Drawing.Color.DarkBlue;
            this.submit_btn.Location = new System.Drawing.Point(368, 567);
            this.submit_btn.Name = "submit_btn";
            this.submit_btn.Size = new System.Drawing.Size(134, 48);
            this.submit_btn.TabIndex = 7;
            this.submit_btn.Text = "Submit";
            this.submit_btn.UseVisualStyleBackColor = true;
            this.submit_btn.Click += new System.EventHandler(this.submit_btn_Click);
            // 
            // back_btn
            // 
            this.back_btn.Font = new System.Drawing.Font("High Tower Text", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.ForeColor = System.Drawing.Color.DarkBlue;
            this.back_btn.Location = new System.Drawing.Point(753, 13);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(100, 43);
            this.back_btn.TabIndex = 8;
            this.back_btn.Text = "back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // arrow_picture_box
            // 
            this.arrow_picture_box.Location = new System.Drawing.Point(396, 457);
            this.arrow_picture_box.Name = "arrow_picture_box";
            this.arrow_picture_box.Size = new System.Drawing.Size(75, 50);
            this.arrow_picture_box.TabIndex = 9;
            this.arrow_picture_box.TabStop = false;
            // 
            // checking_sign_up_label
            // 
            this.checking_sign_up_label.AutoSize = true;
            this.checking_sign_up_label.BackColor = System.Drawing.Color.White;
            this.checking_sign_up_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checking_sign_up_label.ForeColor = System.Drawing.Color.DarkRed;
            this.checking_sign_up_label.Location = new System.Drawing.Point(335, 317);
            this.checking_sign_up_label.Name = "checking_sign_up_label";
            this.checking_sign_up_label.Size = new System.Drawing.Size(179, 24);
            this.checking_sign_up_label.TabIndex = 10;
            this.checking_sign_up_label.Text = "checking your info...";
            // 
            // SignUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(865, 686);
            this.Controls.Add(this.checking_sign_up_label);
            this.Controls.Add(this.arrow_picture_box);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.submit_btn);
            this.Controls.Add(this.email_textBox);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.email_label);
            this.Controls.Add(this.password_label);
            this.Controls.Add(this.username_label);
            this.Controls.Add(this.trivia_label);
            this.Name = "SignUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SignUp";
            this.Load += new System.EventHandler(this.SignUp_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintRectangle);
            ((System.ComponentModel.ISupportInitialize)(this.arrow_picture_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label trivia_label;
        private System.Windows.Forms.Label username_label;
        private System.Windows.Forms.Label password_label;
        private System.Windows.Forms.Label email_label;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox email_textBox;
        private System.Windows.Forms.Button submit_btn;
        private System.Windows.Forms.Button back_btn;
        private System.Windows.Forms.PictureBox arrow_picture_box;
        private System.Windows.Forms.Label checking_sign_up_label;
    }
}