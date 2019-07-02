namespace Trivia_project_client
{
    partial class Game
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
            this.room_name_label = new System.Windows.Forms.Label();
            this.current_question_label = new System.Windows.Forms.Label();
            this.exit_btn = new System.Windows.Forms.Button();
            this.answer1_btn = new System.Windows.Forms.Button();
            this.answer2_btn = new System.Windows.Forms.Button();
            this.answer3_btn = new System.Windows.Forms.Button();
            this.answer4_btn = new System.Windows.Forms.Button();
            this.time_for_question_label = new System.Windows.Forms.Label();
            this.score_label = new System.Windows.Forms.Label();
            this.question_label = new System.Windows.Forms.Label();
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
            // room_name_label
            // 
            this.room_name_label.AutoSize = true;
            this.room_name_label.BackColor = System.Drawing.Color.Black;
            this.room_name_label.Font = new System.Drawing.Font("Showcard Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.room_name_label.ForeColor = System.Drawing.Color.White;
            this.room_name_label.Location = new System.Drawing.Point(12, 25);
            this.room_name_label.Name = "room_name_label";
            this.room_name_label.Size = new System.Drawing.Size(126, 23);
            this.room_name_label.TabIndex = 1;
            this.room_name_label.Text = "room_name";
            // 
            // current_question_label
            // 
            this.current_question_label.AutoSize = true;
            this.current_question_label.BackColor = System.Drawing.Color.Black;
            this.current_question_label.Font = new System.Drawing.Font("Levenim MT", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.current_question_label.ForeColor = System.Drawing.Color.White;
            this.current_question_label.Location = new System.Drawing.Point(362, 140);
            this.current_question_label.Name = "current_question_label";
            this.current_question_label.Size = new System.Drawing.Size(146, 29);
            this.current_question_label.TabIndex = 2;
            this.current_question_label.Text = "question: 0/3";
            // 
            // exit_btn
            // 
            this.exit_btn.BackColor = System.Drawing.Color.Red;
            this.exit_btn.Font = new System.Drawing.Font("High Tower Text", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exit_btn.Location = new System.Drawing.Point(753, 13);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(100, 43);
            this.exit_btn.TabIndex = 3;
            this.exit_btn.Text = "exit";
            this.exit_btn.UseVisualStyleBackColor = false;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            // 
            // answer1_btn
            // 
            this.answer1_btn.BackColor = System.Drawing.Color.White;
            this.answer1_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer1_btn.Location = new System.Drawing.Point(200, 274);
            this.answer1_btn.Name = "answer1_btn";
            this.answer1_btn.Size = new System.Drawing.Size(473, 41);
            this.answer1_btn.TabIndex = 4;
            this.answer1_btn.Text = "answer1";
            this.answer1_btn.UseVisualStyleBackColor = false;
            this.answer1_btn.Click += new System.EventHandler(this.answer1_btn_Click);
            // 
            // answer2_btn
            // 
            this.answer2_btn.BackColor = System.Drawing.Color.White;
            this.answer2_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer2_btn.Location = new System.Drawing.Point(200, 342);
            this.answer2_btn.Name = "answer2_btn";
            this.answer2_btn.Size = new System.Drawing.Size(473, 41);
            this.answer2_btn.TabIndex = 5;
            this.answer2_btn.Text = "answer2";
            this.answer2_btn.UseVisualStyleBackColor = false;
            this.answer2_btn.Click += new System.EventHandler(this.answer2_btn_Click);
            // 
            // answer3_btn
            // 
            this.answer3_btn.BackColor = System.Drawing.Color.White;
            this.answer3_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer3_btn.Location = new System.Drawing.Point(200, 410);
            this.answer3_btn.Name = "answer3_btn";
            this.answer3_btn.Size = new System.Drawing.Size(473, 41);
            this.answer3_btn.TabIndex = 6;
            this.answer3_btn.Text = "answer3";
            this.answer3_btn.UseVisualStyleBackColor = false;
            this.answer3_btn.Click += new System.EventHandler(this.answer3_btn_Click);
            // 
            // answer4_btn
            // 
            this.answer4_btn.BackColor = System.Drawing.Color.White;
            this.answer4_btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.answer4_btn.Location = new System.Drawing.Point(200, 478);
            this.answer4_btn.Name = "answer4_btn";
            this.answer4_btn.Size = new System.Drawing.Size(473, 41);
            this.answer4_btn.TabIndex = 7;
            this.answer4_btn.Text = "answer4";
            this.answer4_btn.UseVisualStyleBackColor = false;
            this.answer4_btn.Click += new System.EventHandler(this.answer4_btn_Click);
            // 
            // time_for_question_label
            // 
            this.time_for_question_label.AutoSize = true;
            this.time_for_question_label.BackColor = System.Drawing.Color.Black;
            this.time_for_question_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.time_for_question_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_for_question_label.ForeColor = System.Drawing.Color.White;
            this.time_for_question_label.Location = new System.Drawing.Point(360, 569);
            this.time_for_question_label.Name = "time_for_question_label";
            this.time_for_question_label.Size = new System.Drawing.Size(150, 35);
            this.time_for_question_label.TabIndex = 8;
            this.time_for_question_label.Text = "4 seconds";
            // 
            // score_label
            // 
            this.score_label.AutoSize = true;
            this.score_label.BackColor = System.Drawing.Color.Black;
            this.score_label.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.score_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.score_label.ForeColor = System.Drawing.Color.White;
            this.score_label.Location = new System.Drawing.Point(385, 630);
            this.score_label.Name = "score_label";
            this.score_label.Size = new System.Drawing.Size(104, 26);
            this.score_label.TabIndex = 9;
            this.score_label.Text = "score: 0/4";
            // 
            // question_label
            // 
            this.question_label.AutoSize = true;
            this.question_label.BackColor = System.Drawing.Color.White;
            this.question_label.Font = new System.Drawing.Font("David", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.question_label.ForeColor = System.Drawing.Color.DarkBlue;
            this.question_label.Location = new System.Drawing.Point(0, 212);
            this.question_label.Name = "question_label";
            this.question_label.Size = new System.Drawing.Size(111, 27);
            this.question_label.TabIndex = 10;
            this.question_label.Text = "question";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(865, 686);
            this.Controls.Add(this.question_label);
            this.Controls.Add(this.score_label);
            this.Controls.Add(this.time_for_question_label);
            this.Controls.Add(this.answer4_btn);
            this.Controls.Add(this.answer3_btn);
            this.Controls.Add(this.answer2_btn);
            this.Controls.Add(this.answer1_btn);
            this.Controls.Add(this.exit_btn);
            this.Controls.Add(this.current_question_label);
            this.Controls.Add(this.room_name_label);
            this.Controls.Add(this.trivia_label);
            this.Name = "Game";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label trivia_label;
        private System.Windows.Forms.Label room_name_label;
        private System.Windows.Forms.Label current_question_label;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Button answer1_btn;
        private System.Windows.Forms.Button answer2_btn;
        private System.Windows.Forms.Button answer3_btn;
        private System.Windows.Forms.Button answer4_btn;
        private System.Windows.Forms.Label time_for_question_label;
        private System.Windows.Forms.Label score_label;
        private System.Windows.Forms.Label question_label;
    }
}