namespace Trivia_project_client
{
    partial class BeforeBeginGame
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
            this.leave_room_btn = new System.Windows.Forms.Button();
            this.trivia_label = new System.Windows.Forms.Label();
            this.start_game_btn = new System.Windows.Forms.Button();
            this.present_room_name_label = new System.Windows.Forms.Label();
            this.info_about_game_label = new System.Windows.Forms.Label();
            this.room_name_label = new System.Windows.Forms.Label();
            this.present_current_participants_label = new System.Windows.Forms.Label();
            this.participant1_label = new System.Windows.Forms.Label();
            this.participant7_label = new System.Windows.Forms.Label();
            this.participant2_label = new System.Windows.Forms.Label();
            this.participant5_label = new System.Windows.Forms.Label();
            this.participant6_label = new System.Windows.Forms.Label();
            this.participant8_label = new System.Windows.Forms.Label();
            this.participant9_label = new System.Windows.Forms.Label();
            this.participant3_label = new System.Windows.Forms.Label();
            this.participant4_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // leave_room_btn
            // 
            this.leave_room_btn.BackColor = System.Drawing.Color.White;
            this.leave_room_btn.Font = new System.Drawing.Font("Matura MT Script Capitals", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.leave_room_btn.Location = new System.Drawing.Point(326, 492);
            this.leave_room_btn.Name = "leave_room_btn";
            this.leave_room_btn.Size = new System.Drawing.Size(213, 53);
            this.leave_room_btn.TabIndex = 1;
            this.leave_room_btn.Text = "Leave room";
            this.leave_room_btn.UseVisualStyleBackColor = false;
            this.leave_room_btn.Click += new System.EventHandler(this.leave_room_btn_Click);
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
            // start_game_btn
            // 
            this.start_game_btn.BackColor = System.Drawing.Color.White;
            this.start_game_btn.Font = new System.Drawing.Font("Matura MT Script Capitals", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.start_game_btn.Location = new System.Drawing.Point(313, 563);
            this.start_game_btn.Name = "start_game_btn";
            this.start_game_btn.Size = new System.Drawing.Size(239, 58);
            this.start_game_btn.TabIndex = 2;
            this.start_game_btn.Text = "Start game";
            this.start_game_btn.UseVisualStyleBackColor = false;
            this.start_game_btn.Click += new System.EventHandler(this.start_game_btn_Click);
            // 
            // present_room_name_label
            // 
            this.present_room_name_label.AutoSize = true;
            this.present_room_name_label.BackColor = System.Drawing.Color.White;
            this.present_room_name_label.Font = new System.Drawing.Font("Segoe Print", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.present_room_name_label.ForeColor = System.Drawing.Color.DarkBlue;
            this.present_room_name_label.Location = new System.Drawing.Point(30, 150);
            this.present_room_name_label.Name = "present_room_name_label";
            this.present_room_name_label.Size = new System.Drawing.Size(639, 65);
            this.present_room_name_label.TabIndex = 3;
            this.present_room_name_label.Text = "You are connected to the room: ";
            // 
            // info_about_game_label
            // 
            this.info_about_game_label.AutoSize = true;
            this.info_about_game_label.BackColor = System.Drawing.Color.White;
            this.info_about_game_label.Font = new System.Drawing.Font("Gisha", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_about_game_label.ForeColor = System.Drawing.Color.Red;
            this.info_about_game_label.Location = new System.Drawing.Point(30, 265);
            this.info_about_game_label.Name = "info_about_game_label";
            this.info_about_game_label.Size = new System.Drawing.Size(631, 23);
            this.info_about_game_label.TabIndex = 4;
            this.info_about_game_label.Text = "max_number_players: 3  number_of_questions: 5  time_per_question: 4";
            // 
            // room_name_label
            // 
            this.room_name_label.AutoSize = true;
            this.room_name_label.BackColor = System.Drawing.Color.White;
            this.room_name_label.Font = new System.Drawing.Font("Segoe Print", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.room_name_label.ForeColor = System.Drawing.Color.DarkBlue;
            this.room_name_label.Location = new System.Drawing.Point(30, 200);
            this.room_name_label.Name = "room_name_label";
            this.room_name_label.Size = new System.Drawing.Size(237, 62);
            this.room_name_label.TabIndex = 5;
            this.room_name_label.Text = "Room name";
            // 
            // present_current_participants_label
            // 
            this.present_current_participants_label.AutoSize = true;
            this.present_current_participants_label.BackColor = System.Drawing.Color.White;
            this.present_current_participants_label.Font = new System.Drawing.Font("Segoe Print", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.present_current_participants_label.Location = new System.Drawing.Point(26, 301);
            this.present_current_participants_label.Name = "present_current_participants_label";
            this.present_current_participants_label.Size = new System.Drawing.Size(367, 47);
            this.present_current_participants_label.TabIndex = 6;
            this.present_current_participants_label.Text = "Current participants are:";
            // 
            // participant1_label
            // 
            this.participant1_label.AutoSize = true;
            this.participant1_label.BackColor = System.Drawing.Color.White;
            this.participant1_label.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participant1_label.Location = new System.Drawing.Point(30, 360);
            this.participant1_label.Name = "participant1_label";
            this.participant1_label.Size = new System.Drawing.Size(148, 31);
            this.participant1_label.TabIndex = 7;
            this.participant1_label.Text = "participant1";
            // 
            // participant7_label
            // 
            this.participant7_label.AutoSize = true;
            this.participant7_label.BackColor = System.Drawing.Color.White;
            this.participant7_label.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participant7_label.Location = new System.Drawing.Point(30, 446);
            this.participant7_label.Name = "participant7_label";
            this.participant7_label.Size = new System.Drawing.Size(148, 31);
            this.participant7_label.TabIndex = 9;
            this.participant7_label.Text = "participant7";
            // 
            // participant2_label
            // 
            this.participant2_label.AutoSize = true;
            this.participant2_label.BackColor = System.Drawing.Color.White;
            this.participant2_label.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participant2_label.Location = new System.Drawing.Point(300, 360);
            this.participant2_label.Name = "participant2_label";
            this.participant2_label.Size = new System.Drawing.Size(148, 31);
            this.participant2_label.TabIndex = 10;
            this.participant2_label.Text = "participant2";
            // 
            // participant5_label
            // 
            this.participant5_label.AutoSize = true;
            this.participant5_label.BackColor = System.Drawing.Color.White;
            this.participant5_label.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participant5_label.Location = new System.Drawing.Point(300, 403);
            this.participant5_label.Name = "participant5_label";
            this.participant5_label.Size = new System.Drawing.Size(148, 31);
            this.participant5_label.TabIndex = 12;
            this.participant5_label.Text = "participant5";
            // 
            // participant6_label
            // 
            this.participant6_label.AutoSize = true;
            this.participant6_label.BackColor = System.Drawing.Color.White;
            this.participant6_label.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participant6_label.Location = new System.Drawing.Point(570, 403);
            this.participant6_label.Name = "participant6_label";
            this.participant6_label.Size = new System.Drawing.Size(148, 31);
            this.participant6_label.TabIndex = 13;
            this.participant6_label.Text = "participant6";
            // 
            // participant8_label
            // 
            this.participant8_label.AutoSize = true;
            this.participant8_label.BackColor = System.Drawing.Color.White;
            this.participant8_label.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participant8_label.Location = new System.Drawing.Point(300, 446);
            this.participant8_label.Name = "participant8_label";
            this.participant8_label.Size = new System.Drawing.Size(148, 31);
            this.participant8_label.TabIndex = 14;
            this.participant8_label.Text = "participant8";
            // 
            // participant9_label
            // 
            this.participant9_label.AutoSize = true;
            this.participant9_label.BackColor = System.Drawing.Color.White;
            this.participant9_label.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participant9_label.Location = new System.Drawing.Point(570, 446);
            this.participant9_label.Name = "participant9_label";
            this.participant9_label.Size = new System.Drawing.Size(148, 31);
            this.participant9_label.TabIndex = 15;
            this.participant9_label.Text = "participant9";
            // 
            // participant3_label
            // 
            this.participant3_label.AutoSize = true;
            this.participant3_label.BackColor = System.Drawing.Color.White;
            this.participant3_label.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participant3_label.Location = new System.Drawing.Point(570, 360);
            this.participant3_label.Name = "participant3_label";
            this.participant3_label.Size = new System.Drawing.Size(148, 31);
            this.participant3_label.TabIndex = 11;
            this.participant3_label.Text = "participant3";
            // 
            // participant4_label
            // 
            this.participant4_label.AutoSize = true;
            this.participant4_label.BackColor = System.Drawing.Color.White;
            this.participant4_label.Font = new System.Drawing.Font("Segoe Script", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participant4_label.Location = new System.Drawing.Point(30, 403);
            this.participant4_label.Name = "participant4_label";
            this.participant4_label.Size = new System.Drawing.Size(148, 31);
            this.participant4_label.TabIndex = 8;
            this.participant4_label.Text = "participant4";
            // 
            // BeforeBeginGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(865, 686);
            this.Controls.Add(this.participant9_label);
            this.Controls.Add(this.participant8_label);
            this.Controls.Add(this.participant6_label);
            this.Controls.Add(this.participant5_label);
            this.Controls.Add(this.participant3_label);
            this.Controls.Add(this.participant2_label);
            this.Controls.Add(this.participant7_label);
            this.Controls.Add(this.participant4_label);
            this.Controls.Add(this.participant1_label);
            this.Controls.Add(this.present_current_participants_label);
            this.Controls.Add(this.room_name_label);
            this.Controls.Add(this.info_about_game_label);
            this.Controls.Add(this.present_room_name_label);
            this.Controls.Add(this.start_game_btn);
            this.Controls.Add(this.leave_room_btn);
            this.Controls.Add(this.trivia_label);
            this.Name = "BeforeBeginGame";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BeforeBeginGame";
            this.Load += new System.EventHandler(this.BeforeBeginGame_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintRectangle);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button leave_room_btn;
        private System.Windows.Forms.Label trivia_label;
        private System.Windows.Forms.Button start_game_btn;
        private System.Windows.Forms.Label present_room_name_label;
        private System.Windows.Forms.Label info_about_game_label;
        private System.Windows.Forms.Label room_name_label;
        private System.Windows.Forms.Label present_current_participants_label;
        private System.Windows.Forms.Label participant1_label;
        private System.Windows.Forms.Label participant7_label;
        private System.Windows.Forms.Label participant2_label;
        private System.Windows.Forms.Label participant5_label;
        private System.Windows.Forms.Label participant6_label;
        private System.Windows.Forms.Label participant8_label;
        private System.Windows.Forms.Label participant9_label;
        private System.Windows.Forms.Label participant3_label;
        private System.Windows.Forms.Label participant4_label;
    }
}