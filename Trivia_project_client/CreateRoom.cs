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

namespace Trivia_project_client
{
    public partial class CreateRoom : Form
    {
        private TcpClient _tcpClient;
        private string _username;
        public CreateRoom(TcpClient tcpClient, string username)
        {
            InitializeComponent();
            Thread t1 = new Thread(new ThreadStart(BeautyTriviaLabel));
            t1.Start();
            this._tcpClient = tcpClient;
            this._username = username;
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
            formGraphics.FillRectangle(brush, new Rectangle(85, 160, 700, 275));
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateRoom_Load(object sender, EventArgs e)
        {
            this.trivia_label.BackColor = Color.Black;
            this.problem_with_creation_label.Text = "";
            this.problem_with_creation_label.Hide();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            NetworkStream clientStream = this._tcpClient.GetStream();
            int bytesRead = 0;
            byte[] bufferIn = new byte[109];
            string message = "";
            string number_of_players = "", number_of_questions = "", time_for_question = "";
            int room_length = this.room_name_textBox.Text.Length;
            if (room_length == 0 || room_length > 99)
            {
                this.problem_with_creation_label.Text = "wrong room name";
                this.problem_with_creation_label.Show();
            }

            else
            {
                number_of_players = this.number_of_players_textBox.Text;
                if (number_of_players.Equals("") || number_of_players.Equals("0") || number_of_players.Length > 1)
                {
                    this.problem_with_creation_label.Text = "wrong number of players";
                    this.problem_with_creation_label.Show();
                }

                else
                {
                    number_of_questions = this.number_of_questions_textBox.Text;
                    if (number_of_questions.Equals("") || number_of_questions.Length > 2)
                    {
                        this.problem_with_creation_label.Text = "wrong number of questions";
                        this.problem_with_creation_label.Show();
                    }

                    else
                    {
                        time_for_question = this.time_for_question_textBox.Text;
                        if (time_for_question.Equals("") || time_for_question.Equals("0") || time_for_question.Length > 2)
                        {
                            this.problem_with_creation_label.Text = "wrong time for question";
                            this.problem_with_creation_label.Show();
                        }

                        else
                        {
                            this.problem_with_creation_label.Text = "";
                            this.problem_with_creation_label.Hide();
                        }
                    }
                }
            }

            if (this.problem_with_creation_label.Text.Length == 0)
            {
                try
                {
                    message = "213" + LengthForSend(this.room_name_textBox.Text) + this.room_name_textBox.Text
                    + number_of_players;
                    if (number_of_questions.Length < 2)
                        number_of_questions = "0" + number_of_questions;
                    message += number_of_questions;
                    if (time_for_question.Length < 2)
                        time_for_question = "0" + time_for_question;
                    message += time_for_question;
                    byte[] buffer = new ASCIIEncoding().GetBytes(message);
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();
                    bytesRead = clientStream.Read(bufferIn, 0, 4);
                    if (bytesRead == 0)
                    {
                        //the client has disconnected from the server
                        this._tcpClient.Close();
                    }
                    message = new ASCIIEncoding().GetString(bufferIn);
                }
                catch { }
            }
            if (message.Substring(0, 4).Equals("1140"))
            {
                this.Hide();
                BeforeBeginGame bbg = new BeforeBeginGame(this._tcpClient, true, this._username, this.room_name_textBox.Text, "", this.number_of_players_textBox.Text, this.number_of_questions_textBox.Text, this.time_for_question_textBox.Text);
                bbg.ShowDialog();
                this.Close();
            }
        }

        string LengthForSend(string text)
        {
            StringBuilder length = new StringBuilder("00");
            length[0] = (char)(text.Length / 10 + 48);
            length[1] = (char)(text.Length % 10 + 48);
            return length.ToString();
        }
    }
}