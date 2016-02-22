using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hello
{
    public partial class Form1 : Form
    {
        double number = 0.0;
        double step = 0.001;
        string outfile = "param.txt";
        string infile = "";
        bool add_date = false;
        string animal = "none";
        int multiplier_arg = 0;
        bool is_rotated = false;
        Bitmap bitmap1;
        string repo_url = "https://github.com/MrRomanMaccaruni/wpf-gui-test";

        public Form1()
        {
            InitializeComponent();
            init_bmp();
            Load += new EventHandler(Form1_Load);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            notifyIcon1.BalloonTipIcon = ToolTipIcon.Info;
            notifyIcon1.BalloonTipTitle = "NOTIFICATION TEST:";
            notifyIcon1.BalloonTipText = "Notifications are usefull!!!";
            notifyIcon1.ShowBalloonTip(1000);
        }

        private void init_bmp()
        {
            bitmap1 = (Bitmap)Bitmap.FromFile(@"C:\\Users\\Alessandro\\Codice\\wpf-gui-test\\bottle_small.png");
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.Image = bitmap1;
        }

        // message pop up button
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello !!!");
            DialogResult dialogResult = MessageBox.Show("Is this cool???", "AWESOME", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("HIGH FIVE!!!");
            }
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("oh no...");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = textBox1.Text;
        }

        // exit button
        private void button4_Click(object sender, EventArgs e)
        {
            notifyIcon1.Visible = false;
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            number = 0;
            label1.Text = number.ToString() + " (click me to reset)";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            number += step;
            label1.Text = number.ToString() + " (click me to reset)";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            number -= step;
            label1.Text = number.ToString() + " (click me to reset)";
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label3.Text = trackBar1.Value.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            // Writes an array of lines to a specific file
            string[] lines = { "# SUMMARY FILE", "# Here you have all the parameters set by user." };
            System.IO.File.WriteAllLines(@outfile, lines);

            // Append other text to an existing file
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(@outfile, true))
            {
                file.WriteLine("integer value : " + number.ToString());
                file.WriteLine("textbox value : " + textBox1.Text);
                file.WriteLine("slider  value : " + trackBar1.Value.ToString());
                file.WriteLine("animal  value : " + animal);
            }

            if (add_date)
            {
                DateTime localDate = DateTime.Now;
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@outfile, true))
                {
                    file.WriteLine("date          : " + localDate.ToString());
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                add_date = true;
                label5.Text = "(date included)";
            }
            else
            {
                this.label5.Text = "(date NOT included)";
            }
        }

        private void animal_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton animalRadio = sender as RadioButton;
            foreach (RadioButton rb in groupBox1.Controls)
            {
                if (animalRadio.Name == rb.Name)
                {
                    label6.Text = "you pick : " + rb.Text;
                    animal = rb.Text;
                }
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // multibox handler coming soon...
        }

        private void button6_Click(object sender, EventArgs e)
        {
            System.IO.StreamReader reader = System.IO.File.OpenText(infile);
            string line;
            string name, age, birthplace;
            name = age = birthplace = "";
            while ((line = reader.ReadLine()) != null)
            {
                string[] tokens = line.Split(' ');
                if (tokens[0] == "name")
                {
                    name = tokens[2];
                }
                else if (tokens[0] == "age")
                {
                    age = tokens[2];
                }
                else if (tokens[0] == "birthplace")
                {
                    birthplace = tokens[2];
                }

            }

            if (name != "" && age != "" && birthplace != "")
            {
                label9.Text = name + " is " + age + " and born in " + birthplace;
                label9.Font = new Font(label9.Font, FontStyle.Underline);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                infile = openFileDialog1.FileName;
            }
            if (infile != "")
            {
                label10.Text = infile;
                button6.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            multiplier_arg = Int32.Parse(comboBox1.SelectedItem.ToString());
            label11.Text = "you pick : " + comboBox1.SelectedItem.ToString();
            button8.Enabled = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/C multiplier.exe " + multiplier_arg.ToString();
            process.StartInfo = startInfo;
            process.Start();
            MessageBox.Show("file product.txt created!");
        }

        private void button9_Click(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(500);
        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(repo_url);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            while (true)
            {
                MessageBox.Show("loop", "INFINITE");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if( is_rotated )
            {
                bitmap1.RotateFlip(RotateFlipType.Rotate270FlipNone);
                pictureBox1.Image = bitmap1;
                button11.Text = "knock down bottle";
                is_rotated = false;
            }
            else
            {
                bitmap1.RotateFlip(RotateFlipType.Rotate90FlipNone);
                pictureBox1.Image = bitmap1;
                button11.Text = "lift bottle";
                is_rotated = true;
            }
        }

    }
}