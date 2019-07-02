namespace Trivia_project_client
{
    partial class MyStatus_BestScores
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
            this.number_of_games_label = new System.Windows.Forms.Label();
            this.number_of_right_answers_label = new System.Windows.Forms.Label();
            this.number_of_wrong_answers_label = new System.Windows.Forms.Label();
            this.average_time_for_answer = new System.Windows.Forms.Label();
            this.performance_label = new System.Windows.Forms.Label();
            this.back_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // trivia_label
            // 
            this.trivia_label.AutoSize = true;
            this.trivia_label.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trivia_label.Location = new System.Drawing.Point(328, 9);
            this.trivia_label.Name = "trivia_label";
            this.trivia_label.Size = new System.Drawing.Size(213, 90);
            this.trivia_label.TabIndex = 0;
            this.trivia_label.Text = "Trivia";
            // 
            // number_of_games_label
            // 
            this.number_of_games_label.AutoSize = true;
            this.number_of_games_label.Font = new System.Drawing.Font("Matura MT Script Capitals", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number_of_games_label.Location = new System.Drawing.Point(35, 208);
            this.number_of_games_label.Name = "number_of_games_label";
            this.number_of_games_label.Size = new System.Drawing.Size(358, 50);
            this.number_of_games_label.TabIndex = 1;
            this.number_of_games_label.Text = "Number of games - ";
            // 
            // number_of_right_answers_label
            // 
            this.number_of_right_answers_label.AutoSize = true;
            this.number_of_right_answers_label.Font = new System.Drawing.Font("Matura MT Script Capitals", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number_of_right_answers_label.Location = new System.Drawing.Point(35, 273);
            this.number_of_right_answers_label.Name = "number_of_right_answers_label";
            this.number_of_right_answers_label.Size = new System.Drawing.Size(451, 47);
            this.number_of_right_answers_label.TabIndex = 2;
            this.number_of_right_answers_label.Text = "Number of right answers - ";
            // 
            // number_of_wrong_answers_label
            // 
            this.number_of_wrong_answers_label.AutoSize = true;
            this.number_of_wrong_answers_label.Font = new System.Drawing.Font("Matura MT Script Capitals", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.number_of_wrong_answers_label.Location = new System.Drawing.Point(35, 338);
            this.number_of_wrong_answers_label.Name = "number_of_wrong_answers_label";
            this.number_of_wrong_answers_label.Size = new System.Drawing.Size(474, 47);
            this.number_of_wrong_answers_label.TabIndex = 3;
            this.number_of_wrong_answers_label.Text = "Number of wrong answers - ";
            // 
            // average_time_for_answer
            // 
            this.average_time_for_answer.AutoSize = true;
            this.average_time_for_answer.Font = new System.Drawing.Font("Matura MT Script Capitals", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.average_time_for_answer.Location = new System.Drawing.Point(35, 403);
            this.average_time_for_answer.Name = "average_time_for_answer";
            this.average_time_for_answer.Size = new System.Drawing.Size(443, 47);
            this.average_time_for_answer.TabIndex = 4;
            this.average_time_for_answer.Text = "Average time for answer - ";
            // 
            // performance_label
            // 
            this.performance_label.AutoSize = true;
            this.performance_label.Font = new System.Drawing.Font("Stencil", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.performance_label.Location = new System.Drawing.Point(35, 143);
            this.performance_label.Name = "performance_label";
            this.performance_label.Size = new System.Drawing.Size(352, 42);
            this.performance_label.TabIndex = 5;
            this.performance_label.Text = "My performances:";
            // 
            // back_btn
            // 
            this.back_btn.Font = new System.Drawing.Font("High Tower Text", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.ForeColor = System.Drawing.Color.DarkBlue;
            this.back_btn.Location = new System.Drawing.Point(753, 13);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(100, 43);
            this.back_btn.TabIndex = 6;
            this.back_btn.Text = "back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // MyStatus_BestScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 686);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.performance_label);
            this.Controls.Add(this.average_time_for_answer);
            this.Controls.Add(this.number_of_wrong_answers_label);
            this.Controls.Add(this.number_of_right_answers_label);
            this.Controls.Add(this.number_of_games_label);
            this.Controls.Add(this.trivia_label);
            this.Name = "MyStatus_BestScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MyStatus";
            this.Load += new System.EventHandler(this.MyStatus_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintRectangle);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label trivia_label;
        private System.Windows.Forms.Label number_of_games_label;
        private System.Windows.Forms.Label number_of_right_answers_label;
        private System.Windows.Forms.Label number_of_wrong_answers_label;
        private System.Windows.Forms.Label average_time_for_answer;
        private System.Windows.Forms.Label performance_label;
        private System.Windows.Forms.Button back_btn;
    }
}