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
    public partial class Form1 : Form
    {
        private TcpClient _tcpClient;
        private NetworkStream _clientStream;
        private byte[] _bufferIn;
        private int _bytesRead;

        public Form1()
        {
            Application.Run(new SplashScreen());
            InitializeComponent();
            this.ConnectToServer();
            Thread t = new Thread(new ThreadStart(BeautyTriviaLabel));
            t.Start();
            this.FormClosing += Form1_FormClosing;
            this._bufferIn = new byte[4];
            this._bytesRead = 0;
        }

        private void ReadConfig(string[] properties)
        {
            int index = 0;
            string line = "";
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(@"config.txt");
                while ((line = file.ReadLine()) != null)
                {
                    properties[index] = line;
                    index++;
                }
                file.Close();
            }
            catch
            {
                MessageBox.Show("The config file is missing");
            }
        }

        string SearchForTheProperty(string whole_property, string str_check)
        {
            string property = "";
            int index_of = whole_property.IndexOf(str_check);
            if (index_of == 0)
            {
                index_of += str_check.Length;
                property = whole_property.Substring(index_of, whole_property.Length - index_of);
            }
            return property;
        }

        private void ConnectToServer()
        {
            bool succeeded = false;
            DialogResult dr = DialogResult.Yes;
            string[] properties = new string[2];

            string ip = "", str_port = "";
            int int_port = 0;
            while (!succeeded && dr == DialogResult.Yes)
            {
                try
                {
                    ReadConfig(properties);
                    ip = SearchForTheProperty(properties[0], "server_ip=");
                    if (ip.Length > 0)
                    {
                        str_port = SearchForTheProperty(properties[1], "port=");
                        if (str_port.Length > 0)
                        {
                            int_port = int.Parse(str_port);
                            this._tcpClient = new TcpClient();
                            this._tcpClient.Connect(ip, int_port);
                            this._clientStream = this._tcpClient.GetStream();
                            succeeded = true;
                        }

                        else
                        {
                            dr = MessageBox.Show("The config wasn't initiallized properly or the server isn't working. Would you like to try again?", "connect to server", MessageBoxButtons.YesNo,
                            MessageBoxIcon.Information);
                        }

                    }

                    else
                    {
                        dr = MessageBox.Show("The config wasn't initiallized properly or the server isn't working. Would you like to try again?", "connect to server", MessageBoxButtons.YesNo,
                        MessageBoxIcon.Information);
                    }
                }
                catch
                {
                    dr = MessageBox.Show("The config wasn't initiallized properly or the server isn't working. Would you like to try again?", "connect to server", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information);
                }
            }
            if (!succeeded)
                this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.trivia_label.BackColor = Color.Black;
            this.welcome_label.BackColor = Color.Black;
            this.welcome_label.AutoSize = false;
            this.welcome_label.Size = new Size(864, 54);
            this.welcome_label.Hide();
            this.join_room_btn.Hide();
            this.create_room_btn.Hide();
            this.my_status_btn.Hide();
            this.best_scores_btn.Hide();
            this.problem_in_sign_in_label.Hide();
            this.problem_in_sign_in_label.AutoSize = false;
            this.problem_in_sign_in_label.Size = new Size(274, 24);
            this.problem_in_sign_in_label.TextAlign = ContentAlignment.MiddleCenter;
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
            System.Drawing.SolidBrush brush = null;
            if (this.sign_up_btn.Text.Equals("Sign up"))
            {

                brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            }

            else
            {
                brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            }
            formGraphics.FillRectangle(brush, new Rectangle(100, 150, 660, 95));
        }

        private void quit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void sign_in_btn_Click(object sender, EventArgs e)
        {
            string message = "";
            string username = this.username_textBox.Text;
            string password = this.password_textBox.Text;
            string username_length = "", password_length = "";
            if (username.Length < 10)
                username_length = "0" + username.Length.ToString();

            if (password.Length < 10)
                password_length = "0" + password.Length.ToString();
            try
            {
                byte[] buffer = new ASCIIEncoding().GetBytes("200" + username_length + username
                + password_length + password);
                this._clientStream.Write(buffer, 0, buffer.Length);
                this._clientStream.Flush();
                this._bytesRead = this._clientStream.Read(this._bufferIn, 0, 4);
                if (this._bytesRead == 0)
                {
                    //the client has disconnected from the server
                    this._tcpClient.Close();
                }
                message = new ASCIIEncoding().GetString(this._bufferIn);
            }
            catch { }

            if (message.Equals("1020"))
            {
                this.username.Hide();
                this.password.Hide();
                this.username_textBox.Hide();
                this.password_textBox.Hide();
                this.sign_in_btn.Hide();
                this.problem_in_sign_in_label.Hide();
                this.welcome_label.ForeColor = Color.White;
                this.welcome_label.Text = "Hello " + this.username_textBox.Text;
                this.welcome_label.TextAlign = ContentAlignment.MiddleCenter;
                this.welcome_label.Show();
                this.sign_up_btn.Text = "Sign out";
                this.join_room_btn.Show();
                this.create_room_btn.Show();
                this.my_status_btn.Show();
                this.best_scores_btn.Show();

            }

            else
            {
                if (message.Equals("1021"))
                    this.problem_in_sign_in_label.Text = "wrong username or password";

                else
                    this.problem_in_sign_in_label.Text = "user has already connected";
                this.problem_in_sign_in_label.Show();
            }
        }

        private void sign_up_btn_Click(object sender, EventArgs e)
        {
            if (this.sign_up_btn.Text.Equals("Sign up"))
            {
                this.Hide();
                SignUp sign_up = new SignUp(this._tcpClient);
                sign_up.ShowDialog();
                this.Show();
            }

            else
            {
                try
                {
                    byte[] buffer = new ASCIIEncoding().GetBytes("201");
                    this._clientStream.Write(buffer, 0, buffer.Length);
                    this._clientStream.Flush();
                }
                catch { }
                this.BackColor = Color.Black;
                this.trivia_label.BackColor = Color.Black;
                this.welcome_label.Hide();
                this.username.Show();
                this.password.Show();
                this.username_textBox.Show();
                this.password_textBox.Show();
                this.sign_up_btn.Text = "Sign up";
                this.sign_in_btn.Show();
                this.join_room_btn.Hide();
                this.create_room_btn.Hide();
                this.my_status_btn.Hide();
                this.best_scores_btn.Hide();
            }
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                byte[] buffer = new ASCIIEncoding().GetBytes("299");
                this._clientStream.Write(buffer, 0, buffer.Length);
                this._clientStream.Flush();
            }
            catch { }
        }

        private void join_room_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            JoinRoom jr = new JoinRoom(this._tcpClient);
            jr.ShowDialog();
            this.Show();
        }

        private void create_room_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateRoom cr = new CreateRoom(this._tcpClient, this.username_textBox.Text);
            cr.ShowDialog();
            this.Show();
        }

        private void my_status_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyStatus_BestScores sign_up = new MyStatus_BestScores(this._tcpClient, true);
            sign_up.ShowDialog();
            this.Show();
        }

        private void best_scores_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MyStatus_BestScores sign_up = new MyStatus_BestScores(this._tcpClient, false);
            sign_up.ShowDialog();
            this.Show();
        }
    }
}