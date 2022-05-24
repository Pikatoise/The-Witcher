using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheWitcher
{
    public partial class FormDiag : Form
    {
        public FormAuth formAuth;

        public FormDiag()
        {
            InitializeComponent();
        }

        private void FormDiag_Load(object sender, EventArgs e)
        {
            DiagMaker(textBoxGroup.Text);
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            if (buttonSort.Text == "Сортировать")
            {
                DiagMaker(textBoxGroup.Text);
                labelGroup.Visible = false;
                textBoxGroup.Enabled = false;
                textBoxGroup.Visible = false;
                buttonSort.Text = "Отмена";
            } else
            {
                DiagMaker("");
                labelGroup.Visible = true;
                textBoxGroup.Enabled = true;
                textBoxGroup.Visible = true;
                buttonSort.Text = "Сортировать";
            }
            
        }

        //
        //
        //

        public void DiagMaker(string sort)
        {
            if (formAuth.db.Count > 0)
            {
                chart1.Series[0].Points.Clear();
                int[] t = new int[] {0,0,0,0,0};
                string[] tName = new string[] {"Первая тема", "Вторая тема", "Третья тема", "Четвертая тема", "Пятая тема"};
                string[] tCheck = new string[] {"T1", "T2", "T3", "T4", "T5"};

                for (int i = 0; i < formAuth.db.Count; i++)
                {
                    if (formAuth.db[i].Count >= 6 && formAuth.db[i][5].Contains(sort))
                    {
                        for (int j = 6; j < formAuth.db[i].Count; j++)
                        {
                            for (int k = 0; k < tCheck.Length; k++)
                            {
                                if (formAuth.db[i][j].Equals(tCheck[k]))
                                {
                                    t[k]++;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i< t.Length; i++)
                {
                    if (t[i] > 0)
                    {
                        chart1.Series[0].Points.AddXY(tName[i], t[i]);
                    }
                }
                
                ///

                chart2.Series[0].Points.Clear();
                int[] o = new int[] {0,0,0,0,0};
                string[] oName = new string[] {"Два", "Три", "Четыре", "Пять"};
                string[] oCheck = new string[] {"2", "3", "4", "5"};

                for (int i = 0; i < formAuth.db.Count; i++)
                {
                    if (formAuth.db[i].Count >= 6 && formAuth.db[i][5].Contains(sort))
                    {
                        for (int j = 6; j < formAuth.db[i].Count; j++)
                        {
                            for (int k = 0; k < oCheck.Length; k++)
                            {
                                if (formAuth.db[i][j].Equals(oCheck[k]))
                                {
                                    o[k]++;
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < o.Length; i++)
                {
                    if (o[i] > 0)
                    {
                        chart2.Series[0].Points.AddXY(oName[i], o[i]);
                    }
                }
            }
            
        }
    }
}
