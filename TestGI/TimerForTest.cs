using System;
using System.Drawing;
using System.Windows.Forms;

namespace TestGI
{
    public class TimerForTest : Label
    {
        int timeTotal;
        int timeCurrent;
        Timer timer;
        public event EventHandler<string> TimeCompleted;

        public TimerForTest(int time, int x, int y)
        {
            this.timeTotal = time;
            this.Text = time.ToString();
            this.Font = new System.Drawing.Font("Arial", 20);
            this.BackColor = SystemColors.ActiveCaption;
            this.Width = timeTotal.ToString().Length * 40;
            this.Height = 50;
            this.Top = y;
            this.Left = x;
            this.TextAlign = ContentAlignment.MiddleCenter;
            timer = new Timer();
            timer.Tick += Timer_Tick;
            timer.Interval = 100;
        }

        public void Start()
        {
            timeCurrent = timeTotal;
            timer.Enabled = true;
        }
        public void Stop()
        {
            timeCurrent = 0;
            timer.Enabled = false;
        }
        private void Timer_Tick(object sender, System.EventArgs e)
        {
            if (timeCurrent == 0)
            {
                timer.Enabled = false;
                TimeCompleted?.Invoke(this, "Время закончилось!");
                return;
            }
            Tick();
        }

        private void Tick()
        {
            this.Text = timeCurrent.ToString();
            timeCurrent--;
        }
    }
}
