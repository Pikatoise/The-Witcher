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
    public partial class FormBookMenucs : Form
    {
        public FormAuth formAuth;
        public bool isExit = true;
        public string tempTest;
        public int tempOcenka;

        public FormBookMenucs()
        {
            InitializeComponent();
        }

        private void FormBookMenucs_Load(object sender, EventArgs e)
        {
            UpdateData(true, formAuth.id, formAuth.db);
            UpdateProgress(true, formAuth.id, formAuth.db);
        }

        private void FormBookMenucs_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                FormAuth.SaveAllData(true, true, true, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);
                Application.Exit();

            }
        }

        private void buttonExit_Click(object sender, EventArgs e) // Выход из аккаунта, сохранение данных, очистка полей
        {
            formAuth.session.Last()[1] = "true";
            FormAuth.SaveAllData(true, true, true, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);

            UpdateData(false);
            UpdateProgress(false);

            isExit = false;
            this.Hide();

            formAuth.Show();
        }

        //Далее жопа
        private void buttonT1_Click(object sender, EventArgs e) // Открывает тему в зависимости от предыдущих действий(Теория с тестом\Тест без теории\Теория без теста)
        {
            FormT1 formT1 = new FormT1();
            
            if (formAuth.db[formAuth.id].Count >= 8)
            {
                formT1.isTestEnd = true;
            } else if (formAuth.db[formAuth.id].Count >= 7)
            {
                formT1.isTest = true;
            }
            formT1.ShowDialog();

            if (formAuth.db[formAuth.id].Count < 7 && formT1.tempT != "null")
            {
                formAuth.db[formAuth.id].Add(formT1.tempT);
            }
            if (formT1.tempOcenka != 0)
            {
                formAuth.db[formAuth.id].Add($"{formT1.tempOcenka}");

                if (formAuth.idAnswer == -1)
                {
                    formAuth.answer.Add(new List<string> { formAuth.db[formAuth.id][0], formT1.answerT, formT1.answerF });
                    formAuth.idAnswer = formAuth.answer.Count-1;
                }
                else
                {
                    formAuth.answer[formAuth.idAnswer].Add(formT1.answerT);
                    formAuth.answer[formAuth.idAnswer].Add(formT1.answerF);
                }
            }

            FormAuth.SaveAllData(true, false, true, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);
            UpdateProgress(true, formAuth.id, formAuth.db);

        }

        private void buttonT2_Click(object sender, EventArgs e)
        {
            FormT2 formT2 = new FormT2();
            if (formAuth.db[formAuth.id].Count >= 10)
            {
                formT2.isTestEnd = true;
            }
            else if (formAuth.db[formAuth.id].Count >= 9)
            {
                formT2.isTest = true;
            }
            formT2.ShowDialog();
            
            if (formT2.tempOcenka != 0)
            {
                if (formAuth.db[formAuth.id].Count < 9 && formT2.tempT != "null")
                {
                    formAuth.db[formAuth.id].Add(formT2.tempT);
                }

                formAuth.db[formAuth.id].Add($"{formT2.tempOcenka}");

                if (formAuth.idAnswer == -1)
                {
                    formAuth.answer.Add(new List<string> { formAuth.db[formAuth.id][0], formT2.answerT, formT2.answerF });
                    formAuth.idAnswer = formAuth.answer.Count - 1;
                }
                else
                {
                    formAuth.answer[formAuth.idAnswer].Add(formT2.answerT);
                    formAuth.answer[formAuth.idAnswer].Add(formT2.answerF);
                }
            }

            FormAuth.SaveAllData(true, false, true, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);
            UpdateProgress(true, formAuth.id, formAuth.db);
        }

        private void buttonT3_Click(object sender, EventArgs e)
        {
            FormT3 formT3 = new FormT3();
            if (formAuth.db[formAuth.id].Count >= 12)
            {
                formT3.isTestEnd = true;
            }
            else if (formAuth.db[formAuth.id].Count >= 11)
            {
                formT3.isTest = true;
            }
            formT3.ShowDialog();

            if (formAuth.db[formAuth.id].Count < 11 && formT3.tempT != "null")
            {
                formAuth.db[formAuth.id].Add(formT3.tempT);
            }
            if (formT3.tempOcenka != 0)
            {
                formAuth.db[formAuth.id].Add($"{formT3.tempOcenka}");

                if (formAuth.idAnswer == -1)
                {
                    formAuth.answer.Add(new List<string> { formAuth.db[formAuth.id][0], formT3.answerT, formT3.answerF });
                    formAuth.idAnswer = formAuth.answer.Count - 1;
                }
                else
                {
                    formAuth.answer[formAuth.idAnswer].Add(formT3.answerT);
                    formAuth.answer[formAuth.idAnswer].Add(formT3.answerF);
                }
            }

            FormAuth.SaveAllData(true, false, true, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);
            UpdateProgress(true, formAuth.id, formAuth.db);
        }

        private void buttonT4_Click(object sender, EventArgs e)
        {
            FormT4 formT4 = new FormT4();
            if (formAuth.db[formAuth.id].Count >= 14)
            {
                formT4.isTestEnd = true;
            }
            else if (formAuth.db[formAuth.id].Count >= 13)
            {
                formT4.isTest = true;
            }
            formT4.ShowDialog();

            if (formAuth.db[formAuth.id].Count < 13 && formT4.tempT != "null")
            {
                formAuth.db[formAuth.id].Add(formT4.tempT);
            }
            if (formT4.tempOcenka != 0)
            {
                formAuth.db[formAuth.id].Add($"{formT4.tempOcenka}");

                if (formAuth.idAnswer == -1)
                {
                    formAuth.answer.Add(new List<string> { formAuth.db[formAuth.id][0], formT4.answerT, formT4.answerF });
                    formAuth.idAnswer = formAuth.answer.Count - 1;
                }
                else
                {
                    formAuth.answer[formAuth.idAnswer].Add(formT4.answerT);
                    formAuth.answer[formAuth.idAnswer].Add(formT4.answerF);
                }
            }

            FormAuth.SaveAllData(true, false, true, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);
            UpdateProgress(true, formAuth.id, formAuth.db);
        }

        private void buttonT5_Click(object sender, EventArgs e)
        {
            FormT5 formT5 = new FormT5();
            if (formAuth.db[formAuth.id].Count >= 16)
            {
                formT5.isTestEnd = true;
            }
            else if (formAuth.db[formAuth.id].Count >= 15)
            {
                formT5.isTest = true;
            }
            formT5.ShowDialog();

            if (formAuth.db[formAuth.id].Count < 15 && formT5.tempT != "null")
            {
                formAuth.db[formAuth.id].Add(formT5.tempT);
            }
            if (formT5.tempOcenka != 0)
            {
                formAuth.db[formAuth.id].Add($"{formT5.tempOcenka}");

                if (formAuth.idAnswer == -1)
                {
                    formAuth.answer.Add(new List<string> { formAuth.db[formAuth.id][0], formT5.answerT, formT5.answerF });
                    formAuth.idAnswer = formAuth.answer.Count - 1;
                }
                else
                {
                    formAuth.answer[formAuth.idAnswer].Add(formT5.answerT);
                    formAuth.answer[formAuth.idAnswer].Add(formT5.answerF);
                }
            }

            FormAuth.SaveAllData(true, false, true, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);
            UpdateProgress(true, formAuth.id, formAuth.db);
        }

        private void buttonF_Click(object sender, EventArgs e)
        {
            FormF formF = new FormF();
            formF.ShowDialog();

            if (formAuth.db[formAuth.id].Count < 17 && formF.tempT != "null")
            {
                formAuth.db[formAuth.id].Add(formF.tempT);
            }
            if (formF.tempOcenka != 0)
            {
                formAuth.db[formAuth.id].Add($"{formF.tempOcenka}");

                if (formAuth.idAnswer == -1)
                {
                    formAuth.answer.Add(new List<string> { formAuth.db[formAuth.id][0], formF.answerT, formF.answerF });
                    formAuth.idAnswer = formAuth.answer.Count - 1;
                }
                else
                {
                    formAuth.answer[formAuth.idAnswer].Add(formF.answerT);
                    formAuth.answer[formAuth.idAnswer].Add(formF.answerF);
                }
            }

            FormAuth.SaveAllData(true, false, true, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);
            UpdateProgress(true, formAuth.id, formAuth.db);
        }

        //
        //
        //

        public void UpdateProgress(bool AddOrClear, int id = -1, List<List<string>> db = null) // Отображает на форме прогресс прохождения в виде оценок, процента и доступности тем
        {
            List<Control> controlsLabel = new List<Control> { labelT1Ocenka, labelT2Ocenka, labelT3Ocenka, labelT4Ocenka, labelT5Ocenka , labelFOcenka};
            List<Control> controlsButton = new List<Control> { buttonT1, buttonT2, buttonT3, buttonT4, buttonT5 , buttonF};
            List<Control> controlsLabelA = new List<Control> {labelAT1,labelAF1, labelAT2, labelAF2, labelAT3, labelAF3, labelAT4, labelAF4, labelAT5, labelAF5 , labelAT6, labelAF6};
            
            if (AddOrClear)
            {
                int procent = (db[id].Count-6) * 9; // Высчитывание и отображение процента
                if (procent > 100) procent = 100;
                labelProcent.Text = $"{procent}%";

                int tempLabel = 2;
                for (int i= 0; i < controlsLabel.Count; i++) // Цикл отображения оценок
                {
                    if (5+tempLabel <= db[id].Count-1)
                    {
                        controlsLabel[i].Text = db[id][5+tempLabel];
                        tempLabel = tempLabel + 2;
                    }
                    else
                    {
                        for (int j = i; j < controlsLabel.Count; j++)
                        {
                            controlsLabel[j].Text = "-";
                        }
                        break;
                    }
                }

                for (int i = 0; i < controlsButton.Count; i++) // Цикл отображения доступности тем и ответов по пройденным тестам
                {
                    if (controlsLabel[i].Text == "-")
                    {
                        controlsButton[i].Enabled = true;
                        break;
                    } else
                    {
                        if (i == 5)
                        {
                            controlsButton[i].Enabled = false;
                        } else controlsButton[i].Enabled = true;

                        switch (i)
                        {
                            case 0:
                                controlsLabelA[0].Text = formAuth.answer[formAuth.idAnswer][1];
                                controlsLabelA[1].Text = formAuth.answer[formAuth.idAnswer][2];
                                break;
                            case 1:
                                controlsLabelA[2].Text = formAuth.answer[formAuth.idAnswer][3];
                                controlsLabelA[3].Text = formAuth.answer[formAuth.idAnswer][4];
                                break;
                            case 2:
                                controlsLabelA[4].Text = formAuth.answer[formAuth.idAnswer][5];
                                controlsLabelA[5].Text = formAuth.answer[formAuth.idAnswer][6];
                                break;
                            case 3:
                                controlsLabelA[6].Text = formAuth.answer[formAuth.idAnswer][7];
                                controlsLabelA[7].Text = formAuth.answer[formAuth.idAnswer][8];
                                break;
                            case 4:
                                controlsLabelA[8].Text = formAuth.answer[formAuth.idAnswer][9];
                                controlsLabelA[9].Text = formAuth.answer[formAuth.idAnswer][10];
                                break;
                            case 5:
                                controlsLabelA[10].Text = formAuth.answer[formAuth.idAnswer][11];
                                controlsLabelA[11].Text = formAuth.answer[formAuth.idAnswer][12];
                                break;
                        }
                    } 
                        
                }
            }
            else // Очистка
            {
                labelProcent.Text = "";
                for (int i = 0; i < controlsLabel.Count; i++)
                {
                    controlsLabel[i].Text = "";
                }

                for (int i = 0; i< controlsButton.Count; i++)
                {
                    controlsButton[i].Enabled = false;
                }

                for (int i = 0; i< controlsLabelA.Count; i++)
                {
                    controlsLabelA[i].Text = "";
                }
            }
        }

        public void UpdateData(bool AddOrClear, int id=-1, List<List<string>> db = null) // Загрузка фио и группы пользователя
        {
            if (AddOrClear)
            {
                labelFIO.Text = db[id][4];
                labelGroup.Text = db[id][5];
            } else
            {
                labelFIO.Text = "";
                labelGroup.Text = "";
            }
            
        }
    }
}
