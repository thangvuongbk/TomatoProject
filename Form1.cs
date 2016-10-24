using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TomatoTimer
{
    public partial class TomatoTimer : Form
    {
        ///
        int iMinute = 0;
        int iSecond = 0;
        bool fPodomoro = false;
        bool fShort = false;
        bool fLong = false;        
     //   string path = Directory.GetCurrentDirectory();
        SoundPlayer simpleSound = new SoundPlayer(Directory.GetCurrentDirectory() + @"\alarmAlert.wav");


        public TomatoTimer()
        {
            InitializeComponent();
            Rectangle workingArea = Screen.GetWorkingArea(this);
            this.Location = new Point(workingArea.Right - Size.Width,
                                      workingArea.Bottom - Size.Height);
        }
        private void playSimpleSound()
        {
             simpleSound.Play();           
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            iMinute = 25;
            iSecond = 00;
            lbMinute.Text = iMinute.ToString();
            lbSecond.Text = "0" + iSecond.ToString();            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            //
            iSecond--;
            if(iSecond <= 0)
            {
                iSecond = 59;
                iMinute--;
                if (iMinute < 0)
                {
                    iMinute = 0;
                    iSecond = 0;
                    timer1.Stop();
                    playSimpleSound();
                }
            }
            //
            if (iSecond < 10 && iMinute < 10)
            {
                lbSecond.Text = "0" + iSecond.ToString();
                lbMinute.Text = "0" + iMinute.ToString();
            }
            else if (iSecond < 10 && iMinute > 10)
            {
                lbSecond.Text = "0" + iSecond.ToString();
                lbMinute.Text = iMinute.ToString();
            }
            else if (iMinute < 10)
            {
                lbMinute.Text = "0" + iMinute.ToString();
                lbSecond.Text = iSecond.ToString();                
            }           
            else
            {
                lbMinute.Text = iMinute.ToString();
                lbSecond.Text = iSecond.ToString();
            }
            
        }

        private void btnPomodoro_Click(object sender, EventArgs e)
        {
            iMinute = 25;
            iSecond = 00;
            lbMinute.Text = iMinute.ToString();
            lbSecond.Text = "0" + iSecond.ToString();
            // 
            fPodomoro = true;
            fShort = false;
            fLong = false;
            simpleSound.Stop();
            timer1.Start();
            //playSimpleSound();
        }

        private void btnShorBreak_Click(object sender, EventArgs e)
        {
            iMinute = 05;
            iSecond = 00;
            lbMinute.Text = "0" + iMinute.ToString();
            lbSecond.Text = "0" + iSecond.ToString();
            // 
            fPodomoro = false;
            fShort = true;
            fLong = false;
            simpleSound.Stop();
            timer1.Start();
        }

        private void btnLongBreak_Click(object sender, EventArgs e)
        {
            iMinute = 10;
            iSecond = 00;
            lbMinute.Text = iMinute.ToString();
            lbSecond.Text = "0" + iSecond.ToString();
            // 
            fPodomoro = false;
            fShort = false;
            fLong = true;
            simpleSound.Stop();
            timer1.Start();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            timer1.Start();
            simpleSound.Stop();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            simpleSound.Stop();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            simpleSound.Stop();
            if (fPodomoro == true)
            {
                iMinute = 25;
                iSecond = 00;
                lbMinute.Text = iMinute.ToString();
                lbSecond.Text = "0" + iSecond.ToString();
                timer1.Stop();
            }
            else if(fShort)
            {
                iMinute = 05;
                iSecond = 00;
                lbMinute.Text = "0" + iMinute.ToString();
                lbSecond.Text = "0" + iSecond.ToString();
                timer1.Stop();
            }
            else if(fLong)
            {
                iMinute = 10;
                iSecond = 00;
                lbMinute.Text = iMinute.ToString();
                lbSecond.Text = "0" + iSecond.ToString();
                timer1.Stop();
            }
           
        }
    }
}
