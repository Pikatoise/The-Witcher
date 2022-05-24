using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace TheWitcher
{
    public partial class FormT1 : Form
    {
        public string tempT ="null";
        public bool isTest = false;
        public int time = 180;
        public bool isTestEnd = false;
        public string answerF = "";
        public string answerT = "";
        public int tempOcenka = 0;
        public Test test;
        string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TheWitcherBook\T1.txt";

        public FormT1()
        {
            InitializeComponent();
            if (File.Exists(path))
            {
                test = new Test(path, panelTest, panelText, buttonEnd);
            }
            else test = new Test(panelTest, panelText, buttonEnd, Properties.Resources.T1);
            test.LayoutTest();
        }

        private void buttonTestStart_Click(object sender, EventArgs e)
        {
            test.ShowTest(false);
            buttonTestStart.Visible = false;
            buttonTestStart.Enabled = false;
            labelWarning.Visible = false;
            tempT = "T1";
            timer1.Start();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            timer1.Stop();

            tempOcenka = test.End(ref answerT, ref answerF);
            if (tempOcenka == 2)
            {
                tempOcenka = 0;
                tempT = "null";
                MessageBox.Show("Тест провален!\nПовторите теорию и попробуйте заного", "Провал", MessageBoxButtons.OK);
            }

            this.Close();
        }

        private void FormT1_Load(object sender, EventArgs e)
        {
            if (isTest)
            {
                test.ShowTest(true);
                timer1.Start();
                labelWarning.Visible = false;
                buttonTestStart.Visible = false;
                buttonTestStart.Enabled = false;
            }

            if (isTestEnd)
            {
                buttonTestStart.Visible = false;
                buttonTestStart.Enabled = false;
                labelWarning.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = test.TimerWork(labelTimer, time);
            if (labelTimer.Text == "0:0")
            {
                timer1.Stop();

                tempOcenka = test.End(ref answerT, ref answerF);
                if (tempOcenka == 2)
                {
                    tempOcenka = 0;
                    tempT = "null";
                    MessageBox.Show("Тест провален!\nПовторите теорию и попробуйте заного", "Провал", MessageBoxButtons.OK);
                }

                this.Close();
            }
        }
    }
}
