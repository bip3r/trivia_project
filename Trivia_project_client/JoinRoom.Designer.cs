namespace Trivia_project_client
{
    partial class JoinRoom
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
            this.rooms_names_listBox = new System.Windows.Forms.ListBox();
            this.trivia_label = new System.Windows.Forms.Label();
            this.refresh_btn = new System.Windows.Forms.Button();
            this.join_btn = new System.Windows.Forms.Button();
            this.problem_with_joining_label = new System.Windows.Forms.Label();
            this.present_rooms_list_label = new System.Windows.Forms.Label();
            this.participants_in_room_listBox = new System.Windows.Forms.ListBox();
            this.back_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rooms_names_listBox
            // 
            this.rooms_names_listBox.BackColor = System.Drawing.Color.White;
            this.rooms_names_listBox.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rooms_names_listBox.FormattingEnabled = true;
            this.rooms_names_listBox.ItemHeight = 32;
            this.rooms_names_listBox.Location = new System.Drawing.Point(219, 252);
            this.rooms_names_listBox.Name = "rooms_names_listBox";
            this.rooms_names_listBox.Size = new System.Drawing.Size(432, 68);
            this.rooms_names_listBox.TabIndex = 0;
            // 
            // trivia_label
            // 
            this.trivia_label.AutoSize = true;
            this.trivia_label.BackColor = System.Drawing.Color.White;
            this.trivia_label.Font = new System.Drawing.Font("Comic Sans MS", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trivia_label.Location = new System.Drawing.Point(328, 9);
            this.trivia_label.Name = "trivia_label";
            this.trivia_label.Size = new System.Drawing.Size(213, 90);
            this.trivia_label.TabIndex = 1;
            this.trivia_label.Text = "Trivia";
            // 
            // refresh_btn
            // 
            this.refresh_btn.Font = new System.Drawing.Font("High Tower Text", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.refresh_btn.ForeColor = System.Drawing.Color.DarkBlue;
            this.refresh_btn.Location = new System.Drawing.Point(356, 490);
            this.refresh_btn.Name = "refresh_btn";
            this.refresh_btn.Size = new System.Drawing.Size(157, 41);
            this.refresh_btn.TabIndex = 2;
            this.refresh_btn.Text = "Refresh";
            this.refresh_btn.UseVisualStyleBackColor = true;
            this.refresh_btn.Click += new System.EventHandler(this.refresh_btn_Click);
            // 
            // join_btn
            // 
            this.join_btn.Font = new System.Drawing.Font("High Tower Text", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.join_btn.ForeColor = System.Drawing.Color.DarkBlue;
            this.join_btn.Location = new System.Drawing.Point(336, 550);
            this.join_btn.Name = "join_btn";
            this.join_btn.Size = new System.Drawing.Size(196, 68);
            this.join_btn.TabIndex = 3;
            this.join_btn.Text = "Join";
            this.join_btn.UseVisualStyleBackColor = true;
            this.join_btn.Click += new System.EventHandler(this.join_btn_Click);
            // 
            // problem_with_joining_label
            // 
            this.problem_with_joining_label.AutoSize = true;
            this.problem_with_joining_label.BackColor = System.Drawing.Color.White;
            this.problem_with_joining_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.problem_with_joining_label.ForeColor = System.Drawing.Color.DarkRed;
            this.problem_with_joining_label.Location = new System.Drawing.Point(219, 332);
            this.problem_with_joining_label.Name = "problem_with_joining_label";
            this.problem_with_joining_label.Size = new System.Drawing.Size(179, 24);
            this.problem_with_joining_label.TabIndex = 4;
            this.problem_with_joining_label.Text = "problem with joining";
            // 
            // present_rooms_list_label
            // 
            this.present_rooms_list_label.AutoSize = true;
            this.present_rooms_list_label.BackColor = System.Drawing.Color.White;
            this.present_rooms_list_label.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.present_rooms_list_label.Location = new System.Drawing.Point(219, 194);
            this.present_rooms_list_label.Name = "present_rooms_list_label";
            this.present_rooms_list_label.Size = new System.Drawing.Size(185, 45);
            this.present_rooms_list_label.TabIndex = 5;
            this.present_rooms_list_label.Text = "Rooms list:";
            // 
            // participants_in_room_listBox
            // 
            this.participants_in_room_listBox.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.participants_in_room_listBox.FormattingEnabled = true;
            this.participants_in_room_listBox.ItemHeight = 30;
            this.participants_in_room_listBox.Location = new System.Drawing.Point(254, 359);
            this.participants_in_room_listBox.Name = "participants_in_room_listBox";
            this.participants_in_room_listBox.Size = new System.Drawing.Size(367, 94);
            this.participants_in_room_listBox.TabIndex = 6;
            // 
            // back_btn
            // 
            this.back_btn.Font = new System.Drawing.Font("High Tower Text", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.back_btn.ForeColor = System.Drawing.Color.DarkBlue;
            this.back_btn.Location = new System.Drawing.Point(746, 13);
            this.back_btn.Name = "back_btn";
            this.back_btn.Size = new System.Drawing.Size(100, 43);
            this.back_btn.TabIndex = 7;
            this.back_btn.Text = "back";
            this.back_btn.UseVisualStyleBackColor = true;
            this.back_btn.Click += new System.EventHandler(this.back_btn_Click);
            // 
            // JoinRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(865, 686);
            this.Controls.Add(this.back_btn);
            this.Controls.Add(this.participants_in_room_listBox);
            this.Controls.Add(this.present_rooms_list_label);
            this.Controls.Add(this.problem_with_joining_label);
            this.Controls.Add(this.join_btn);
            this.Controls.Add(this.refresh_btn);
            this.Controls.Add(this.trivia_label);
            this.Controls.Add(this.rooms_names_listBox);
            this.Name = "JoinRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "JoinRoom";
            this.Load += new System.EventHandler(this.JoinRoom_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaintRectangle);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox rooms_names_listBox;
        private System.Windows.Forms.Label trivia_label;
        private System.Windows.Forms.Button refresh_btn;
        private System.Windows.Forms.Button join_btn;
        private System.Windows.Forms.Label problem_with_joining_label;
        private System.Windows.Forms.Label present_rooms_list_label;
        private System.Windows.Forms.ListBox participants_in_room_listBox;
        private System.Windows.Forms.Button back_btn;
    }
}