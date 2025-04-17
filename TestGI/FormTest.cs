using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestGI
{


    public partial class FormTest : Form
    {

        TestGeniusIdiot test;
        TimerForTest timer;

        public FormTest()
        {
            InitializeComponent();
            timer = new TimerForTest(20, 50, 100);
            this.Controls.Add(timer);
            StartTest();
            timer.TimeCompleted += BreakTime;
        }

        void  BreakTime(object sender, string message)
        {
            MessageBox.Show(message);
            NextQuestion();
        }

        void StartTest()
        {
            test = new TestGeniusIdiot();
            ShowQuestion();
        }

        void ShowQuestion()
        {
            labelQuestion.Text = test.NextQuestion();
            labelNumberOfQuestion.Text = "Вопрос №" + test.NumberQuestion();
            timer.Start();
        }

        public void NextQuestion()
        {
            try
            {
                int userAnswer = Convert.ToInt32(textBoxUserAnswer.Text);
                test.CheckAnswer(userAnswer);

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("В ответе может быть только число");
            }

            if (test.EndOfTest())
            {
                MessageBox.Show(test.Diagnose());
                buttonNewStart.Visible = true;
            }
            else
            {
                ShowQuestion();
            }
        }

        private void buttonNextQuestion_Click(object sender, EventArgs e)
        {
            NextQuestion();
        }

        private void buttonNewStart_Click(object sender, EventArgs e)
        {
            StartTest();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {

        }
    }
}
