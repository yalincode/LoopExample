using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoopExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                Button button = new Button();
                button.Name = "btn1"+i.ToString();
                button.Width = 50;
                button.Height = 50;
                button.Text = i.ToString();
                button.Click += Button_Click;//+= tab tab yaparak click eventi oluşturulur.
                flowLayoutPanel1.Controls.Add(button);
            }
            label2.Text = $"Level: {timer1.Interval}";


        }
        int puan = 0;

        private void Button_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;//Tıkladığımız button senderdan buraya gelir.
            if (button.BackColor == Color.Red)
            {
                puan += 10;
                
            }
            else
            {
                puan -= 5;
                
            }
            label1.Text = $"Puan: {puan}";
        }

        Random rnd = new Random();
        private void timer1_Tick(object sender, EventArgs e)
        {
            int rastgeleSayi = rnd.Next(0, 101);
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                Control control = flowLayoutPanel1.Controls[i];
                if (control is Button)
                {
                    Button button = control as Button;
                    int buttonNumber = Convert.ToInt32(button.Text);
                    if (rastgeleSayi==buttonNumber)
                    {
                        button.BackColor = Color.Red;
                        button.ForeColor = Color.Yellow;
                    }
                    else
                    {
                        button.BackColor = Color.White;
                        button.ForeColor = Color.Black;
                    }

                }
            }
        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                timer1.Start();
            }
        }

        private void btnLevelArttir_Click(object sender, EventArgs e)
        {
            
            timer1.Interval = timer1.Interval - 100;
            label2.Text = $"Level: {timer1.Interval}";
            
        }

        private void btnLevelAzalt_Click(object sender, EventArgs e)
        {
            timer1.Interval = timer1.Interval + 100;
            label2.Text = $"Level: {timer1.Interval}";
        }
    }
}
