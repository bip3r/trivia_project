using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Trivia_project_client
{
    public partial class Scores : Form
    {
        public Scores(string messageFromServer)
        {
            InitializeComponent();
            List<string> scores = new List<string>();
            int number_of_players = messageFromServer[3] - 48, player_length_name = 0, temp = 4, y_label = 13, y_location = -26;
            string player_name = "", player_score = "", player_info = "", text = "";
            for (int i = 1; i <= number_of_players; i++)
            {
                player_length_name = int.Parse(messageFromServer.Substring(temp, 2));
                temp += 2;
                player_name = messageFromServer.Substring(temp, player_length_name);
                temp += player_length_name;
                player_score = messageFromServer.Substring(temp, 2);
                temp += 2;
                scores.Add(player_score + player_name);
            }
            scores.Sort();
            scores.Reverse();
            Label l = null;
            for (int i = 1; i <= number_of_players; i++)
            {
                player_info = scores[i - 1];
                player_name = player_info.Substring(2, player_info.Length - 2);
                player_score = int.Parse(player_info.Substring(0, 2)).ToString();
                text = player_name + " scores " + player_score + " points";
                l = new Label();
                l.AutoSize = true;
                l.Location = new Point(13, y_label);
                l.Font = new Font("Microsoft Sans Serif", 16, FontStyle.Bold);
                l.Text = text;
                this.Controls.Add(l);
                y_label += 39;
                y_location += 39;
            }
            Button ok_btn = new Button();
            ok_btn.Location = new Point(305, y_location + 40);
            ok_btn.Font = new Font("High Tower Text", 36, FontStyle.Bold);
            ok_btn.ForeColor = Color.DarkBlue;
            ok_btn.Size = new Size(130, 58);
            ok_btn.Text = "OK";
            ok_btn.Click += delegate (Object sender1, EventArgs e)
                        {
                            this.Close();
                        };
            this.Controls.Add(ok_btn);
            this.AutoSize = false;
            this.Size = new Size(749, y_location + 150);
        }
    }
}
