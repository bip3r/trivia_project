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
    public partial class JoinRoom : Form
    {
        private TcpClient _tcpClient;
        private List<int> _ids_of_rooms;
        private Thread _write_into_players_listBox;
        private int _save_last_index;
        public JoinRoom(TcpClient tcpClient)
        {
            InitializeComponent();
            Thread t1 = new Thread(new ThreadStart(BeautyTriviaLabel));
            t1.Start();
            this._tcpClient = tcpClient;
            this._ids_of_rooms = new List<int>();
            this._save_last_index = 1;
            this.FormClosing += JoinClosing;
            this._write_into_players_listBox = new Thread(new ThreadStart(AddPlayersNamesToPlayersListBox));
            this._write_into_players_listBox.Start();
        }

        private void PaintRectangle(object sender, PaintEventArgs e)
        {
            System.Drawing.Graphics formGraphics = this.CreateGraphics();
            System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.White);
            formGraphics.FillRectangle(brush, new Rectangle(108, 120, 656, 350));
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

        void LoadRoomsNames()
        {
            NetworkStream clientStream = this._tcpClient.GetStream();
            int bytesRead = 0, number_of_rooms = 0, temp = 7, room_id = 0, room_length = 0;
            byte[] bufferIn = new byte[1049902];
            string message = "", room_name = "";
            try
            {
                byte[] buffer = new ASCIIEncoding().GetBytes("205");
                clientStream.Write(buffer, 0, buffer.Length);
                clientStream.Flush();
                bytesRead = clientStream.Read(bufferIn, 0, 1049902);
                if (bytesRead == 0)
                {
                    //the client has disconnected from the server
                    this._tcpClient.Close();
                }
                message = new ASCIIEncoding().GetString(bufferIn);
            }
            catch { }
            if (message.Length >= 7)
            {
                number_of_rooms = int.Parse(message.Substring(3, 4));
                for (int i = 0; i < number_of_rooms; i++)
                {
                    room_id = int.Parse(message.Substring(temp, 4));
                    temp += 4;
                    room_length = int.Parse(message.Substring(temp, 2));
                    temp += 2;
                    room_name = message.Substring(temp, room_length);
                    temp += room_length;
                    this._ids_of_rooms.Add(room_id);
                    this.rooms_names_listBox.Items.Add(room_name);
                }
            }
        }

        void AddPlayersNamesToPlayersListBox()
        {
            NetworkStream clientStream = this._tcpClient.GetStream();
            int bytesRead = 0, index = 0, int_room_id = 0, temp_length = 0;
            int number_of_players = 0, player_length_name = 0, temp = 4;
            byte[] bufferIn = new byte[913];
            string message = "", room_name = "", str_room_id = "";
            while (true)
            {
                index = this.rooms_names_listBox.SelectedIndex;
                if (index != -1 && index != this._save_last_index)
                {
                    this.problem_with_joining_label.Hide();
                    this.participants_in_room_listBox.Items.Clear();
                    this._save_last_index = index;
                    room_name = this.rooms_names_listBox.SelectedItem.ToString();
                    int_room_id = this._ids_of_rooms[index];
                    temp_length = 4 - int_room_id;
                    for (int i = 0; i < temp_length; i++)
                    {
                        str_room_id += "0";
                    }
                    str_room_id += int_room_id.ToString();
                    try
                    {
                        byte[] buffer = new ASCIIEncoding().GetBytes("207" + str_room_id);
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();
                        bytesRead = clientStream.Read(bufferIn, 0, 913);
                        if (bytesRead == 0)
                        {
                            //the client has disconnected from the server
                            this._tcpClient.Close();
                        }
                        message = new ASCIIEncoding().GetString(bufferIn);
                    }
                    catch { }
                    if (message.Length >= 4)
                    {
                        if (message.Substring(0, 3).Equals("108"))
                        {
                            number_of_players = message[3] - 48;
                            for (int i = 0; i < number_of_players; i++)
                            {
                                player_length_name = int.Parse(message.Substring(temp, 2));
                                temp += 2;
                                this.participants_in_room_listBox.Items.Add(message.Substring(temp, player_length_name));
                                temp += player_length_name;
                            }
                        }
                        this.participants_in_room_listBox.Show();
                        str_room_id = "";
                        temp = 4;
                    }
                }
            }
        }

        private void JoinRoom_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Black;
            this.trivia_label.BackColor = Color.Black;
            this.present_rooms_list_label.AutoSize = false;
            this.problem_with_joining_label.AutoSize = false;
            this.present_rooms_list_label.Size = new Size(432, 45);
            this.problem_with_joining_label.Size = new Size(432, 24);
            this.present_rooms_list_label.TextAlign = ContentAlignment.MiddleCenter;
            this.problem_with_joining_label.TextAlign = ContentAlignment.MiddleCenter;
            this.participants_in_room_listBox.Hide();
            LoadRoomsNames();
            if (this.rooms_names_listBox.Items.Count == 0)
                this.problem_with_joining_label.Text = "no available rooms";

            else
                this.problem_with_joining_label.Hide();
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            this._ids_of_rooms.Clear();
            this.rooms_names_listBox.Items.Clear();
            this.participants_in_room_listBox.Items.Clear();
            this.participants_in_room_listBox.Hide();
            LoadRoomsNames();
            if (this.rooms_names_listBox.Items.Count == 0)
            {
                this.participants_in_room_listBox.Hide();
                this.problem_with_joining_label.Text = "no available rooms";
            }

            else
                this.problem_with_joining_label.Hide();
            this._save_last_index = -1;
        }

        private void join_btn_Click(object sender, EventArgs e)
        {
            NetworkStream clientStream = this._tcpClient.GetStream();
            int bytesRead = 0;
            byte[] bufferIn = new byte[8];
            int index = this.rooms_names_listBox.SelectedIndex, int_room_id = 0, temp_length = 0;
            string room_name = "", message = "", str_room_id = "", number_of_questions = "", time_for_question = "";
            if (index != -1)
            {
                room_name = this.rooms_names_listBox.SelectedItem.ToString();
                int_room_id = this._ids_of_rooms[index];
                temp_length = 4 - int_room_id.ToString().Length;
                for (int i = 0; i < temp_length; i++)
                {
                    str_room_id += "0";
                }
                str_room_id += int_room_id.ToString();
                try
                {
                    byte[] buffer = new ASCIIEncoding().GetBytes("209" + str_room_id);
                    clientStream.Write(buffer, 0, buffer.Length);
                    clientStream.Flush();
                    bytesRead = clientStream.Read(bufferIn, 0, 8);
                    if (bytesRead == 0)
                    {
                        //the client has disconnected from the server
                        this._tcpClient.Close();
                    }
                    message = new ASCIIEncoding().GetString(bufferIn);
                }
                catch { }
                if (message.Substring(0, 4).Equals("1100"))
                {
                    number_of_questions = int.Parse(message.Substring(4, 2)).ToString();
                    time_for_question = int.Parse(message.Substring(6, 2)).ToString();
                    try
                    {
                        byte[] buffer = new ASCIIEncoding().GetBytes("207" + str_room_id);
                        clientStream.Write(buffer, 0, buffer.Length);
                        clientStream.Flush();
                    }
                    catch { }
                    this._write_into_players_listBox.Abort();
                    this.Hide();
                    BeforeBeginGame bbg = new BeforeBeginGame(this._tcpClient, false, "", room_name, str_room_id, "", number_of_questions, time_for_question);
                    bbg.ShowDialog();
                    this.Close();
                }

                else
                {
                    if (message.Substring(0, 4).Equals("1101"))
                    {
                        this.problem_with_joining_label.Text = "room is full";
                    }

                    else
                    {
                        this.problem_with_joining_label.Text = "game has started/room has closed etc...";
                    }
                    this.problem_with_joining_label.Show();
                }
            }

            else
            {
                if (this.rooms_names_listBox.Items.Count > 0)
                {
                    this.problem_with_joining_label.Text = "pick a room";
                    this.problem_with_joining_label.Show();
                }
            }
        }

        private void back_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void JoinClosing(object sender, EventArgs e)
        {
            this._write_into_players_listBox.Abort();
        }
    }
}