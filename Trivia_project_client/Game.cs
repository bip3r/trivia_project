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
    public partial class Game : Form
    {
        private TcpClient _tcpClient;
        private NetworkStream _clientStream;
        private string _number_of_questions;
        private string _time_for_question;
        private int _number_answered;
        private System.Timers.Timer _timer;
        private int _current_question;
        private int _time_left;
        private int _score;

        public Game(TcpClient tcpClient, string room_name, string number_of_questions, string time_for_question, string question, string answer1, string answer2, string answer3, string answer4)
        {
            InitializeComponent();
            this._tcpClient = tcpClient;
            this._clientStream = tcpClient.GetStream();
            Thread t = new Thread(new ThreadStart(BeautyTriviaLabel));
            t.Start();
            this.room_name_label.Text = room_name;
            this.question_label.Text = question;
            this.answer1_btn.Text = answer1;
            this.answer2_btn.Text = answer2;
            this.answer3_btn.Text = answer3;
            this.answer4_btn.Text = answer4;
            this._number_of_questions = number_of_questions;
            this._time_for_question = time_for_question;
            this._number_answered = 5;
            this._current_question = 1;
            this._score = 0;
            this.current_question_label.Text = "question: 1/" + number_of_questions;
            this.time_for_question_label.Text = time_for_question + " seconds";
            this.score_label.Text = "score: 0/" + number_of_questions;
            this._time_left = int.Parse(time_for_question);
            this._timer = new System.Timers.Timer(1000);
            this._timer.Elapsed += timer_Tick;
            this._timer.Start();
            this.FormClosing += GameClosing;
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

        private void Game_Load(object sender, EventArgs e)
        {
            this.trivia_label.BackColor = Color.Black;
            this.question_label.AutoSize = false;
            this.question_label.Size = new Size(881, 27);
            this.question_label.TextAlign = ContentAlignment.MiddleCenter;
        }

        void LoadQuestion(char checkAnswer, string message)
        {
            string question = "", answer1 = "", answer2 = "", answer3 = "", answer4 = "";
            int question_length = 0, answer1_length = 0, answer2_length = 0, answer3_length = 0, answer4_length = 0;
            PaintAnswer(checkAnswer);
            Thread.Sleep(500);
            question_length = int.Parse(message.Substring(3, 3));
            if (question_length != 0)
            {
                try
                {
                    question = message.Substring(6, question_length);
                    answer1_length = int.Parse(message.Substring(6 + question_length, 3));
                    answer1 = message.Substring(9 + question_length, answer1_length);
                    answer2_length = int.Parse(message.Substring(9 + question_length + answer1_length, 3));
                    answer2 = message.Substring(12 + question_length + answer1_length, answer2_length);
                    answer3_length = int.Parse(message.Substring(12 + question_length + answer1_length + answer2_length, 3));
                    answer3 = message.Substring(15 + question_length + answer1_length + answer2_length, answer3_length);
                    answer4_length = int.Parse(message.Substring(15 + question_length + answer1_length + answer2_length + answer3_length, 3));
                    answer4 = message.Substring(18 + question_length + answer1_length + answer2_length + answer3_length, answer4_length);
                }
                catch { }
            }
            PaintTheAnswer(Color.White);
            this.question_label.Text = question;
            this.answer1_btn.Text = answer1;
            this.answer2_btn.Text = answer2;
            this.answer3_btn.Text = answer3;
            this.answer4_btn.Text = answer4;
            this._number_answered = 5;
            this._current_question++;
            this.current_question_label.Text = "question: " + this._current_question.ToString() + "/" + this._number_of_questions;
            this.time_for_question_label.Text = this._time_for_question + " seconds";
            this._time_left = int.Parse(this._time_for_question);
            this.answer1_btn.Enabled = true;
            this.answer2_btn.Enabled = true;
            this.answer3_btn.Enabled = true;
            this.answer4_btn.Enabled = true;
            this._timer.Interval = 1000;
            this._timer.Enabled = true;
        }

        void PaintTheAnswer(Color color)
        {
            switch (this._number_answered)
            {
                case 1:
                    this.answer1_btn.BackColor = color;
                    break;
                case 2:
                    this.answer2_btn.BackColor = color;
                    break;
                case 3:
                    this.answer3_btn.BackColor = color;
                    break;
                case 4:
                    this.answer4_btn.BackColor = color;
                    break;
            }
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (this._time_left > 0)
            {
                this._time_left -= 1;
                this.time_for_question_label.Text = this._time_left.ToString() + " seconds";
            }
            else
            {
                this._timer.Enabled = false;
                this.time_for_question_label.Text = "Time's up!";
                if (this._number_answered == 5)
                    SendTheAnswer();
            }
        }

        void SendTheAnswer()
        {
            byte[] bufferIn = new byte[5013];
            int bytesRead = 0;
            string message = "";
            char checkAnswer = ' ';
            this.answer1_btn.Enabled = false;
            this.answer2_btn.Enabled = false;
            this.answer3_btn.Enabled = false;
            this.answer4_btn.Enabled = false;
            try
            {
                byte[] buffer = new ASCIIEncoding().GetBytes("219" + this._number_answered.ToString() + this.AnswerTime());
                this._clientStream.Write(buffer, 0, buffer.Length);
                this._clientStream.Flush();
                bytesRead = this._clientStream.Read(bufferIn, 0, 4);
                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    this._tcpClient.Close();
                }
                message = new ASCIIEncoding().GetString(bufferIn);
            }
            catch { }

            if (message.Length >= 3)
            {
                if (message.Substring(0, 3).Equals("120"))
                {
                    checkAnswer = message[3];
                    bytesRead = this._clientStream.Read(bufferIn, 0, 5013);
                    if (bytesRead == 0)
                    {
                        //the client has disconnected from the server
                        this._tcpClient.Close();
                    }
                    message = new ASCIIEncoding().GetString(bufferIn);
                    if (message.Length >= 3)
                    {
                        if (message.Substring(0, 3).Equals("118"))
                        {
                            Thread load_question = new Thread(() => LoadQuestion(checkAnswer, message));
                            load_question.Start();
                        }

                        else if (message.Substring(0, 3).Equals("121"))
                        {
                            this._timer.Stop();
                            PaintAnswer(checkAnswer);
                            Scores scores = new Scores(message);
                            scores.ShowDialog();
                            this.Close();
                        }
                    }
                }
            }
        }

        void PaintAnswer(char checkAnswer)
        {
            if (checkAnswer == '0')
                PaintTheAnswer(Color.Red);

            else
            {
                PaintTheAnswer(Color.Green);
                this._score++;
                this.score_label.Text = "score: " + this._score.ToString() + "/" + this._number_of_questions;
            }
        }

        private void answer1_btn_Click(object sender, EventArgs e)
        {
            this._number_answered = 1;
            this.answer1_btn.BackColor = Color.Yellow;
            SendTheAnswer();
        }

        private void answer2_btn_Click(object sender, EventArgs e)
        {
            this._number_answered = 2;
            this.answer2_btn.BackColor = Color.Yellow;
            SendTheAnswer();
        }

        private void answer3_btn_Click(object sender, EventArgs e)
        {
            this._number_answered = 3;
            this.answer3_btn.BackColor = Color.Yellow;
            SendTheAnswer();
        }

        private void answer4_btn_Click(object sender, EventArgs e)
        {
            this._number_answered = 4;
            this.answer4_btn.BackColor = Color.Yellow;
            SendTheAnswer();
        }

        private string AnswerTime()
        {
            string time_for_question = (int.Parse(this._time_for_question) - this._time_left).ToString();
            if (time_for_question.Length == 1)
                time_for_question = "0" + time_for_question;
            return time_for_question;
        }

        private void GameClosing(object sender, EventArgs e)
        {
            this._timer.Stop();
            try
            {
                byte[] buffer = new ASCIIEncoding().GetBytes("222");
                this._clientStream.Write(buffer, 0, buffer.Length);
                this._clientStream.Flush();
            }
            catch { }
        }
    }
}