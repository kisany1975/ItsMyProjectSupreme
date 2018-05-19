using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeonCube_Undermove
{
    public partial class Leaderboard : Form
    {
        int score;

        public Leaderboard(int currentScore)
        {
            InitializeComponent();
            score = currentScore;
            textBox1.Text = File.ReadAllText("leaders.txt");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.AppendText(textBox2.Text + ": " + score + Environment.NewLine);
        }

        private void Leaderboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            File.WriteAllText("leaders.txt", textBox1.Text);
        }
    }
}
