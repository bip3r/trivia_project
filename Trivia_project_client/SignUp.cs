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

    public partial class SignUp : Form
    {
        private TcpClient _tcpClient;
        public SignUp(TcpClient tcpClient)
        {
            InitializeComponent();
            Thread t1 = new Thread(new ThreadStart(BeautyTriviaLabel));
            t1.Start();
            this._tcpClient = tcpClient;
        }

        private void SignUp_Load(object sender, EventArgs e)
        {
            this.trivia_label.BackColor = Color.Black;
            this.arrow_picture_box.Image = Image.FromFile("arrow.png");
            this.arrow_picture_box.SizeMode = PictureBoxSizeMode.StretchImage;
            this.checking_sign_up_label.AutoSize = false;
            this.checking_sign_up_label.Size = new Size(274, 29);
            this.checking_sign_up_label.TextAlign = ContentAlignment.MiddleCenter;
            this.checking_sign_up_label.Hide();
            Thread t2 = new Thread(new ThreadStart(MoveArrow));
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
            formGraphics.FillRectangle(brush, new Rectangle(200, 170, 530, 185));
        }

        private void MoveArrow()
        {
            int y = this.arrow_picture_box.Location.Y, start_y = y, end_y = 500;
            bool entered_to_first_if = true;
            while (true)
            {
                if (y == start_y)
                {
                    entered_to_first_if = true;
                    y++;
                }

                else if (y == end_y)
                {
                    entered_to_first_if = false;
                    y--;
                }

                else if (entered_to_first_if)
                    y++;

                else
                    y--;
                this.arrow_picture_box.Location = new Point(this.arrow_picture_box.Location.X, y);
                Thread.Sleep(10);
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void submit_btn_Click(object sender, EventArgs e)
        {
            this.submit_btn.Enabled = false;
            this.checking_sign_up_label.Text = "checking your info...";
            NetworkStream clientStream = this._tcpClient.GetStream();
            byte[] bufferIn = new byte[4];
            int bytesRead = 0;
            string message = "";
            string username = this.username_textBox.Text;
            string password = this.password_textBox.Text;
            string email = this.email_textBox.Text;
            this.checking_sign_up_label.Show();
            try
            {
                byte[] buffer = new ASCIIEncoding().GetBytes("203" + LengthForSend(username) + username
                + LengthForSend(password) + password + LengthForSend(email) + email);
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
            Thread t = new Thread(() => CheckInfo(message));
            t.Start();
        }

        void CheckInfo(string messageFromServer)
        {
            Thread.Sleep(1000);
            if (messageFromServer.Equals("1040"))
                this.checking_sign_up_label.Text = "signing up success!";

            else
            {
                if (messageFromServer.Equals("1041"))
                    this.checking_sign_up_label.Text = "password is illegal";

                else if (messageFromServer.Equals("1042"))
                    this.checking_sign_up_label.Text = "username is already exists";

                else if (messageFromServer.Equals("1043"))
                    this.checking_sign_up_label.Text = "username is illegal";

                else
                    this.checking_sign_up_label.Text = "some problem with sign up";
            }
            Thread.Sleep(1000);
            this.checking_sign_up_label.Hide();
            this.submit_btn.Enabled = true;
        }
        string LengthForSend(string text)
        {
            StringBuilder length = new StringBuilder("00");
            if (text.Length < 100)
            {
                length[0] = (char)(text.Length / 10 + 48);
                length[1] = (char)(text.Length % 10 + 48);
            }
            return length.ToString();
        }
    }
}
