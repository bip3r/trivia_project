namespace Trivia_project_client
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
            this.trivia_label = new System.Windows.Forms.Label();
            this.username = new System.Windows.Forms.Label();
            this.password = new System.Windows.Forms.Label();
            this.username_textBox = new System.Windows.Forms.TextBox();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.sign_in_btn = new System.Windows.Forms.Button();
            this.sign_up_btn = new System.Windows.Forms.Button();
            this.join_room_btn = new System.Windows.Forms.Button();
            this.create_room_btn = new System.Windows.Forms.Button();
            this.my_status_btn = new System.Windows.Forms.Button();
            this.best_scores_btn = new System.Windows.Forms.Button();
            this.quit_btn = new System.Windows.Forms.Button();
            this.welcome_label = new System.Windows.Forms.Label();
            this.problem_in_sign_in_label = new System.Windows.Forms.Label();
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
            // username
            // 
            this.username.AutoSize = true;
            this.username.BackColor = System.Drawing.Color.White;
            this.username.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.username.Location = new System.Drawing.Point(128, 161);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(96, 20);
            this.username.TabIndex = 1;
            this.username.Text = "Username:";
            // 
            // password
            // 
            this.password.AutoSize = true;
            this.password.BackColor = System.Drawing.Color.White;
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(128, 193);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(91, 20);
            this.password.TabIndex = 2;
            this.password.Text = "Password:";
            // 
            // username_textBox
            // 
            this.username_textBox.Location = new System.Drawing.Point(230, 162);
            this.username_textBox.Name = "username_textBox";
            this.username_textBox.Size = new System.Drawing.Size(343, 20);
            this.username_textBox.TabIndex = 3;
            this.username_textBox.Text = "Omri";
            // 
            // password_textBox
            // 
            this.password_textBox.Location = new System.Drawing.Point(230, 195);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.Size = new System.Drawing.Size(343, 20);
            this.password_textBox.TabIndex = 4;
            this.password_textBox.Text = "Wallak12";
            // 
            // sign_in_btn
            // 
            this.sign_in_btn.BackColor = System.Drawing.Color.White;
            this.sign_in_btn.Font = new System.Drawing.Font("Matura MT Script Capitals", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_in_btn.Location = new System.Drawing.Point(579, 160);
            this.sign_in_btn.Name = "sign_in_btn";
            this.sign_in_btn.Size = new System.Drawing.Size(157, 55);
            this.sign_in_btn.TabIndex = 5;
            this.sign_in_btn.Text = "Sign in";
            this.sign_in_btn.UseVisualStyleBackColor = false;
            this.sign_in_btn.Click += new System.EventHandler(this.sign_in_btn_Click);
            // 
            // sign_up_btn
            // 
            this.sign_up_btn.BackColor = System.Drawing.Color.White;
            this.sign_up_btn.Font = new System.Drawing.Font("Matura MT Script Capitals", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sign_up_btn.Location = new System.Drawing.Point(297, 250);
            this.sign_up_btn.Name = "sign_up_btn";
            this.sign_up_btn.Size = new System.Drawing.Size(267, 47);
            this.sign_up_btn.TabIndex = 6;
            this.sign_up_btn.Text = "Sign up";
            this.sign_up_btn.UseVisualStyleBackColor = false;
            this.sign_up_btn.Click += new System.EventHandler(this.sign_up_btn_Click);
            // 
            // join_room_btn
            // 
            this.join_room_btn.BackColor = System.Drawing.Color.White;
            this.join_room_btn.Font = new System.Drawing.Font("Matura MT Script Capitals", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.join_room_btn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.join_room_btn.Location = new System.Drawing.Point(297, 326);
            this.join_room_btn.Name = "join_room_btn";
            this.join_room_btn.Size = new System.Drawing.Size(267, 47);
            this.join_room_btn.TabIndex = 7;
            this.join_room_btn.Text = "Join room";
            this.join_room_btn.UseVisualStyleBackColor = false;
            this.join_room_btn.Click += new System.EventHandler(this.join_room_btn_Click);
            // 
            // create_room_btn
            // 
            this.create_room_btn.BackColor = System.Drawing.Color.White;
            this.create_room_btn.Font = new System.Drawing.Font("Matura MT Script Capitals", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.create_room_btn.Location = new System.Drawing.Point(297, 397);
            this.create_room_btn.Name = "create_room_btn";
            this.create_room_btn.Size = new System.Drawing.Size(267, 47);
            this.create_room_btn.TabIndex = 8;
            this.create_room_btn.Text = "Create room";
            this.create_room_btn.UseVisualStyleBackColor = false;
            this.create_room_btn.Click += new System.EventHandler(this.create_room_btn_Click);
            // 
            // my_status_btn
            // 
            this.my_status_btn.BackColor = System.Drawing.Color.White;
            this.my_status_btn.Font = new System.Drawing.Font("Matura MT Script Capitals", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.my_status_btn.Location = new System.Drawing.Point(297, 473);
            this.my_status_btn.Name = "my_status_btn";
            this.my_status_btn.Size = new System.Drawing.Size(267, 47);
            this.my_status_btn.TabIndex = 9;
            this.my_status_btn.Text = "My status";
            this.my_status_btn.UseVisualStyleBackColor = false;
            this.my_status_btn.Click += new System.EventHandler(this.my_status_btn_Click);
            // 
            // best_scores_btn
            // 
            this.best_scores_btn.BackColor = System.Drawing.Color.White;
            this.best_scores_btn.Font = new System.Drawing.Font("Matura MT Script Capitals", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.best_scores_btn.Location = new System.Drawing.Point(297, 551);
            this.best_scores_btn.Name = "best_scores_btn";
            this.best_scores_btn.Size = new System.Drawing.Size(267, 47);
            this.best_scores_btn.TabIndex = 10;
            this.best_scores_btn.Text = "Best scores";
            this.best_scores_btn.UseVisualStyleBackColor = false;
            this.best_scores_btn.Click += new System.EventHandler(this.best_scores_btn_Click);
            // 
            // quit_btn
            // 
            this.quit_btn.Font = new System.Drawing.Font("High Tower Text", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quit_btn.ForeColor = System.Drawing.Color.DarkBlue;
            this.quit_btn.Location = new System.Drawing.Point(365, 616);
            this.quit_btn.Name = "quit_btn";
            this.quit_btn.Size = new System.Drawing.Size(126, 49);
            this.quit_btn.TabIndex = 11;
            this.quit_btn.Text = "Quit";
            this.quit_btn.UseVisualStyleBackColor = true;
            this.quit_btn.Click += new System.EventHandler(this.quit_btn_Click);
            // 
            // welcome_label
            // 
            this.welcome_label.AutoSize = true;
            this.welcome_label.BackColor = System.Drawing.Color.White;
            this.welcome_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 35.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcome_label.Location = new System.Drawing.Point(1, 161);
            this.welcome_label.Name = "welcome_label";
            this.welcome_label.Size = new System.Drawing.Size(134, 54);
            this.welcome_label.TabIndex = 12;
            this.welcome_label.Text = "Hello";
            // 
            // problem_in_sign_in_label
            // 
            this.problem_in_sign_in_label.AutoSize = true;
            this.problem_in_sign_in_label.BackColor = System.Drawing.Color.White;
            this.problem_in_sign_in_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.problem_in_sign_in_label.ForeColor = System.Drawing.Color.DarkRed;
            this.problem_in_sign_in_label.Location = new System.Drawing.Point(290, 218);
            this.problem_in_sign_in_label.Name = "problem_in_sign_in_label";
            this.problem_in_sign_in_label.Size = new System.Drawing.Size(160, 24);
            this.problem_in_sign_in_label.TabIndex = 13;
            this.problem_in_sign_in_label.Text = "problem in sign in";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(865, 686);
            this.Controls.Add(this.problem_in_sign_in_label);
            this.Controls.Add(this.welcome_label);
            this.Controls.Add(this.quit_btn);
            this.Controls.Add(this.best_scores_btn);
            this.Controls.Add(this.my_status_btn);
            this.Controls.Add(this.create_room_btn);
            this.Controls.Add(this.join_room_btn);
            this.Controls.Add(this.sign_up_btn);
            this.Controls.Add(this.sign_in_btn);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.username_textBox);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.trivia_label);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintRectangle);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label trivia_label;
        private System.Windows.Forms.Label username;
        private System.Windows.Forms.Label password;
        private System.Windows.Forms.TextBox username_textBox;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.Button sign_in_btn;
        private System.Windows.Forms.Button sign_up_btn;
        private System.Windows.Forms.Button join_room_btn;
        private System.Windows.Forms.Button create_room_btn;
        private System.Windows.Forms.Button my_status_btn;
        private System.Windows.Forms.Button best_scores_btn;
        private System.Windows.Forms.Button quit_btn;
        private System.Windows.Forms.Label welcome_label;
        private System.Windows.Forms.Label problem_in_sign_in_label;
    }
}

