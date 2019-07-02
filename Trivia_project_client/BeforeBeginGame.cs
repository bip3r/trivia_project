using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Configuration;
using System.Data.SqlClient;

namespace Trivia_project_client
{
    public partial class BeforeBeginGame : Form
    {
        private TcpClient _tcpClient;
        private string _room_id;
        private string _room_name;
        private string _number_of_questions;
        private string _time_for_question;
        private int _last_shown_label;
        private bool _leave;
        private Thread _listen_to_server;
        private string _message;
        private string _question;
        private string _answer1;
        private string _answer2;
        private string _answer3;
        private string _answer4;

        public BeforeBeginGame(TcpClient tcpClient, bool isAdmin, string username, string room_name, string room_id, string number_of_players, string number_of_questions, string time_for_question)
        {
            InitializeComponent();
            this._tcpClient = tcpClient;
            this.info_about_game_label.Text = "";
            this._last_shown_label = 1;
            this._leave = false;
            if (!isAdmin)
            {
                this._room_id = room_id;
                this.start_game_btn.Hide();
            }

            else
            {
                this.leave_room_btn.Text = "Close room";
                this.info_about_game_label.Text = "max_number_players: " + number_of_players;
            }
            this.info_about_game_label.Text += "  number_of_questions: " + number_of_questions + "  time_for_question: " + time_for_question;
            this._room_name = room_name;
            this._number_of_questions = number_of_questions;
            this._time_for_question = time_for_question;
            this.room_name_label.Text = room_name;
            this.participant1_label.Text = username;
            this._message = "";
            this._listen_to_server = new Thread(new ThreadStart(ListenToServer));
            this._listen_to_server.Start();
            this.FormClosing += BBGClosing;
            Thread t2 = new Thread(new ThreadStart(BeautyTriviaLabel));
            t2.Start();
        }

        void BeautyTriviaLabel()
        {
            Random rnd = new Random();
            int R = 0, G = 0, B = 0;
            while (true)
            {
                R = rnd.Next(0, 255);
                G = rnd.Next(0, 255);
                B = rnd.Next(0, 255);
                this.trivia_label.ForeColor = Color.FromArgb(R, G, B);
                Thread.Sleep(500);
            }
        }

        private void PaintRectangle(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            formGraphics.FillRectangle(brush, new Rectangle(20, 130, 827, 350));
        }

        private void BeforeBeginGame_Load(object sender, EventArgs e)
        {
            this.trivia_label.BackColor = Color.Black;
            this.present_room_name_label.AutoSize = false;
            this.room_name_label.AutoSize = false;
            this.info_about_game_label.AutoSize = false;
            this.present_current_participants_label.AutoSize = false;
            this.participant1_label.AutoSize = false;
            this.participant2_label.AutoSize = false;
            this.participant3_label.AutoSize = false;
            this.participant4_label.AutoSize = false;
            this.participant5_label.AutoSize = false;
            this.participant6_label.AutoSize = false;
            this.participant7_label.AutoSize = false;
            this.participant8_label.AutoSize = false;
            this.participant9_label.AutoSize = false;
            this.present_room_name_label.Size = new Size(803, 65);
            this.room_name_label.Size = new Size(803, 62);
            this.info_about_game_label.Size = new Size(803, 23);
            this.present_current_participants_label.Size = new Size(803, 47);
            this.participant1_label.Size = new Size(267, 31);
            this.participant2_label.Size = new Size(267, 31);
            this.participant3_label.Size = new Size(267, 31);
            this.participant4_label.Size = new Size(267, 31);
            this.participant5_label.Size = new Size(267, 31);
            this.participant6_label.Size = new Size(267, 31);
            this.participant7_label.Size = new Size(267, 31);
            this.participant8_label.Size = new Size(267, 31);
            this.participant9_label.Size = new Size(267, 31);
            this.present_room_name_label.TextAlign = ContentAlignment.MiddleCenter;
            this.room_name_label.TextAlign = ContentAlignment.MiddleCenter;
            this.info_about_game_label.TextAlign = ContentAlignment.MiddleCenter;
            this.present_current_participants_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant1_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant2_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant3_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant4_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant5_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant6_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant7_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant8_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant9_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participant1_label.BackColor = Color.Green;
            this.participant2_label.BackColor = Color.Red;
            this.participant3_label.BackColor = Color.Yellow;
            this.participant4_label.BackColor = Color.Green;
            this.participant5_label.BackColor = Color.Red;
            this.participant6_label.BackColor = Color.Yellow;
            this.participant7_label.BackColor = Color.Green;
            this.participant8_label.BackColor = Color.Red;
            this.participant9_label.BackColor = Color.Yellow;
            this.participant2_label.Hide();
            this.participant3_label.Hide();
            this.participant4_label.Hide();
            this.participant5_label.Hide();
            this.participant6_label.Hide();
            this.participant7_label.Hide();
            this.participant8_label.Hide();
            this.participant9_label.Hide();
        }

        void ListenToServer()
        {
            NetworkStream clientStream = this._tcpClient.GetStream();
            byte[] bufferIn = new byte[913];
            int bytesRead = 0, number_of_players = 0, temp = 4, player_length_name = 0, i = 0;
            string player_name = "";
            while (true)
            {
                try
                {
                    bytesRead = clientStream.Read(bufferIn, 0, 913);
                    if (bytesRead == 0)
                    {
                        //the client has disconnected from the server
                        this._tcpClient.Close();
                        break;
                    }
                    this._message = new ASCIIEncoding().GetString(bufferIn);
                }
                catch { }
                if (this._message.Substring(0, 3).Equals("116") || this._leave)
                {
                    break;
                }

                else if (this._message.Substring(0, 4).Equals("1120"))
                {
                    try
                    {
                        byte[] buffer = new ASCIIEncoding().GetBytes("207" + this._room_id);
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();
                    }
                    catch { }
                }

                else if (this._message.Substring(0, 3).Equals("108"))
                {
                    Thread.Sleep(100);
                    ShowPlayerLabel(this._last_shown_label, "", false);
                    if (this._message[3] != 0)
                    {
                        number_of_players = this._message[3] - 48;
                        this._last_shown_label = number_of_players;
                        for (i = 1; i <= number_of_players; i++)
                        {
                            player_length_name = int.Parse(this._message.Substring(temp, 2));
                            temp += 2;
                            player_name = this._message.Substring(temp, player_length_name);
                            ShowPlayerLabel(i, player_name, true);
                            temp += player_length_name;
                        }
                    }
                    temp = 4;
                }

                else if (this._message.Substring(0, 3).Equals("118"))
                {
                    StartGame();
                    break;
                }
            }
            this.Close();
        }

        private void RequestToLeaveRoom()
        {
            NetworkStream clientStream = this._tcpClient.GetStream();
            try
            {
                if (this.leave_room_btn.Text.Equals("Leave room"))
                {
                    try
                    {
                        byte[] buffer = new ASCIIEncoding().GetBytes("211");
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();
                    }
                    catch { }
                }

                else
                {
                    try
                    {
                        byte[] buffer = new ASCIIEncoding().GetBytes("215");
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void leave_room_btn_Click(object sender, EventArgs e)
        {
            this.RequestToLeaveRoom();
            this._leave = true;
        }

        void ShowPlayerLabel(int switch_on, string name, bool visible)
        {
            switch (switch_on)
            {
                case 1:
                    this.participant1_label.Text = name;
                    this.participant1_label.Visible = visible;
                    break;
                case 2:
                    this.participant2_label.Text = name;
                    this.participant2_label.Visible = visible;
                    break;
                case 3:
                    this.participant3_label.Text = name;
                    this.participant3_label.Visible = visible;
                    break;
                case 4:
                    this.participant4_label.Text = name;
                    this.participant4_label.Visible = visible;
                    break;
                case 5:
                    this.participant5_label.Text = name;
                    this.participant5_label.Visible = visible;
                    break;
                case 6:
                    this.participant6_label.Text = name;
                    this.participant6_label.Visible = visible;
                    break;
                case 7:
                    this.participant7_label.Text = name;
                    this.participant7_label.Visible = visible;
                    break;
                case 8:
                    this.participant8_label.Text = name;
                    this.participant8_label.Visible = visible;
                    break;
                case 9:
                    this.participant9_label.Text = name;
                    this.participant9_label.Visible = visible;
                    break;
            }
        }

        void StartGame()
        {
            int question_length = 0, answer1_length = 0, answer2_length = 0, answer3_length = 0, answer4_length = 0;
            question_length = int.Parse(this._message.Substring(3, 3));
            if (question_length != 0)
            {

                this._question = this._message.Substring(6, question_length);
                answer1_length = int.Parse(this._message.Substring(6 + question_length, 3));
                this._answer1 = this._message.Substring(9 + question_length, answer1_length);
                answer2_length = int.Parse(this._message.Substring(9 + question_length + answer1_length, 3));
                this._answer2 = this._message.Substring(12 + question_length + answer1_length, answer2_length);
                answer3_length = int.Parse(this._message.Substring(12 + question_length + answer1_length + answer2_length, 3));
                this._answer3 = this._message.Substring(15 + question_length + answer1_length + answer2_length, answer3_length);
                answer4_length = int.Parse(this._message.Substring(15 + question_length + answer1_length + answer2_length + answer3_length, 3));
                this._answer4 = this._message.Substring(18 + question_length + answer1_length + answer2_length + answer3_length, answer4_length);
            }
        }

        private void start_game_btn_Click(object sender, EventArgs e)
        {
            NetworkStream clientStream = this._tcpClient.GetStream();
            try
            {
                byte[] buffer = new ASCIIEncoding().GetBytes("217");
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
            }
            catch { }
        }

        private void BBGClosing(object sender, EventArgs e)
        {
            if (this._listen_to_server.IsAlive)
                this._listen_to_server.Abort();

            if (!this._leave)
                this.RequestToLeaveRoom();
                
            if (this._message.Length >= 3)
            {
                if (this._message.Substring(0, 3).Equals("118"))
                {
                    this.Hide();
                    Game game = new Game(this._tcpClient, this._room_name, this._number_of_questions, this._time_for_question, this._question, this._answer1, this._answer2, this._answer3, this._answer4);
                    game.ShowDialog();
                }
            }
        }
    }
}