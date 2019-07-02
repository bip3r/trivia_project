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
    public partial class MyStatus_BestScores : Form
    {
        private TcpClient _tcpClient;
        private bool _isMyStatus;
        public MyStatus_BestScores(TcpClient tcpClient, bool isMyStatus)
        {
            InitializeComponent();
            this._tcpClient = tcpClient;
            this._isMyStatus = isMyStatus;
            Thread t = new Thread(new ThreadStart(BeautyTriviaLabel));
            t.Start();
            NetworkStream clientStream = tcpClient.GetStream();
            byte[] bufferIn = new byte[324];
            int bytesRead = 0;
            string message = "";
            string send = "";
            if (this._isMyStatus)
                send = "225";

            else
            {
                this.average_time_for_answer.Hide();
                send = "223";
                this.number_of_games_label.Text = "";
                this.number_of_right_answers_label.Text = "";
                this.number_of_wrong_answers_label.Text = "";
            }
            try
            {
                byte[] buffer = new ASCIIEncoding().GetBytes(send);
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
                bytesRead = clientStream.Read(bufferIn, 0, bufferIn.Length);
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
                if (message.Substring(0, 3).Equals("126"))
                {
                    this.GetMyStatus(message);
                }

                else if (message.Substring(0, 3).Equals("124"))
                {
                    this.GetBestScores(message);
                }
            }
        }

        private void GetMyStatus(string messageFromServer)
        {
            string ave_time = "";
            this.number_of_games_label.Text += " " + int.Parse(messageFromServer.Substring(3, 4)).ToString();
            this.number_of_right_answers_label.Text += " " + int.Parse(messageFromServer.Substring(7, 6)).ToString();
            this.number_of_wrong_answers_label.Text += " " + int.Parse(messageFromServer.Substring(13, 6)).ToString();
            ave_time = int.Parse(messageFromServer.Substring(19, 4)).ToString();
            if (ave_time.Length > 1)
            {
                ave_time = ave_time.Insert(1, ".");
            }
            else
            {
                ave_time += ".0";
            }
            this.average_time_for_answer.Text += " " + ave_time;
        }

        private void GetBestScores(string messageFromServer)
        {
            int length1 = 0, length2 = 0, length3 = 0;
            this.performance_label.Text = "Best scores:";
            length1 = int.Parse(messageFromServer.Substring(3, 2));
            if (length1 != 0)
            {
                this.number_of_games_label.Text += " " + messageFromServer.Substring(5, length1) + " - "
                + int.Parse(messageFromServer.Substring(5 + length1, 6)).ToString();
                length2 = int.Parse(messageFromServer.Substring(11 + length1, 2));
                if (length2 != 0)
                {
                    this.number_of_right_answers_label.Text += " " + messageFromServer.Substring(13 + length1, length2) + " - "
                    + int.Parse(messageFromServer.Substring(13 + length1 + length2, 6)).ToString();
                    length3 = int.Parse(messageFromServer.Substring(19 + length1 + length2, 2));
                    if (length3 != 0)
                    {
                        this.number_of_wrong_answers_label.Text += " " + messageFromServer.Substring(21 + length1 + length2, length3) + " - "
                     + int.Parse(messageFromServer.Substring(21 + length1 + length2 + length3, 6)).ToString();
                    }

                    else
                    {
                        this.number_of_wrong_answers_label.Hide();
                    }
                }

                else
                {
                    this.number_of_right_answers_label.Hide();
                    this.number_of_wrong_answers_label.Hide();
                }
            }

            else
            {
                this.number_of_games_label.Hide();
                this.number_of_right_answers_label.Hide();
                this.number_of_wrong_answers_label.Hide();
            }
        }

        private void MyStatus_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.performance_label.AutoSize = false;
            this.number_of_games_label.AutoSize = false;
            this.number_of_right_answers_label.AutoSize = false;
            this.number_of_wrong_answers_label.AutoSize = false;
            this.average_time_for_answer.AutoSize = false;
            this.performance_label.Size = new Size(800, 54);
            this.number_of_games_label.Size = new Size(800, 54);
            this.number_of_right_answers_label.Size = new Size(800, 54);
            this.number_of_wrong_answers_label.Size = new Size(800, 54);
            this.average_time_for_answer.Size = new Size(800, 54);
            this.performance_label.TextAlign = ContentAlignment.MiddleCenter;
            this.number_of_games_label.TextAlign = ContentAlignment.MiddleCenter;
            this.number_of_right_answers_label.TextAlign = ContentAlignment.MiddleCenter;
            this.number_of_wrong_answers_label.TextAlign = ContentAlignment.MiddleCenter;
            this.average_time_for_answer.TextAlign = ContentAlignment.MiddleCenter;
            this.performance_label.BackColor = Color.Green;
            this.performance_label.ForeColor = Color.White;
            this.number_of_games_label.BackColor = Color.White;
            this.number_of_right_answers_label.BackColor = Color.White;
            this.number_of_wrong_answers_label.BackColor = Color.White;
            this.average_time_for_answer.BackColor = Color.White;

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
            formGraphics.FillRectangle(brush, new Rectangle(35, 100, 800, 550));
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}