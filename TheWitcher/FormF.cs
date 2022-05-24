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
    public partial class FormF : Form // Форма с тестом как и все
    {
        public string tempT = "null";
        public int tempOcenka = 0;
        public int time = 300;
        public string answerF = "";
        public string answerT = "";
        public Test test;
        string path = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TheWitcherBook\F.txt";

        public FormF()
        {
            InitializeComponent();
            if (File.Exists(path))
            {
                test = new Test(path, panelTest, buttonEnd);
            }
            else test = new Test(panelTest, buttonEnd, Properties.Resources.F);
            test.LayoutTest();
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            tempT = "F";
            tempOcenka = test.End(ref answerT, ref answerF);
            timer1.Stop();
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time = test.TimerWork(labelTimer, time);
            if (labelTimer.Text == "0:0")
            {
                timer1.Stop();
                tempT = "F";
                tempOcenka = test.End(ref answerT, ref answerF);
                
                this.Close();
            }
        }

        private void FormF_Load(object sender, EventArgs e)
        {
            timer1.Start();
            test.ShowTest(true);
        }
    }
}
