using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Threading;


namespace TheWitcher
{
    public class Test
    {
        string path; // Путь до файла с вопросами
        int hPanel; // Высота панели теста
        Panel pTest; // Панель для теста
        Panel pText = null; // Панель для теории
        Button bEnd; // Кнопка завершения теста
        Button fieldIn; // Внутреннее поле
        Button fieldOut; // Внешнее поле

        List<List<string>> questions = new List<List<string>>(); // Список вопросов с ответами
        List<GroupBox> groups = new List<GroupBox>(); // Список групп для каждого вопроса
        List<RadioButton> rBTrue = new List<RadioButton>(); // Список правильных ответов

        public Test(string path, Panel pTest, Panel pText, Button bEnd) // Создание экземпляра для чтения вопросов из файла
        {
            this.path = path;
            this.bEnd = bEnd;
            this.pTest = pTest;
            this.pText = pText;

            ReadText(path, false);
        }

        public Test(Panel pTest, Panel pText, Button bEnd, string text) // Создание экземпляра для чтения из ресурсов программы
        {
            this.pTest = pTest;
            this.bEnd = bEnd;
            this.pText = pText;

            ReadText(text, true);
        }

        public Test(Panel pTest, Button bEnd, string text) // Создание экземпляра для чтения из ресурсов программы для формы без теории
        {
            this.pTest = pTest;
            this.bEnd = bEnd;

            ReadText(text, true);
        }

        public Test(string path, Panel pTest, Button bEnd) // Создание экземпляра для чтения из ресурсов программы для формы без теории
        {
            this.pTest = pTest;
            this.bEnd = bEnd;
            this.path = path;

            ReadText(path, false);
        }

        void ReadText(string pathOrText, bool isText) // Считывание из файла\ресурсов и разбиение на списки вопросов
        {
            string[] arr;

            if (!isText)
            {
                using (StreamReader stream = new StreamReader(path))
                {
                    arr = stream.ReadToEnd().Split(new char[] { '\n' });
                }
            }
            else arr = pathOrText.Split(new char[] { '\n' });


            for (int i = 0; i < arr.Length; i++)
            {
                arr[i].Replace("\n", "");
                arr[i].Replace("\r", "");

                if (arr[i].Length > 0)
                {
                    this.questions.Add(new List<string>());
                    this.questions[i] = arr[i].Split(new char[] { '_' }).ToList();
                }
            }
        }

        public void LayoutTest() // Вывод всех элементов панели теста в неё
        {

            int locationHeightGroup = 65; // Положение каждой группы
            List<Point> locationRB = new List<Point>() // Положение каждого радиобаттона
            {
                new Point(20, 30),
                new Point(20, 85),
                new Point(470, 30),
                new Point(470, 85)
            };

            this.pTest.SuspendLayout(); // Остановка панели
            this.pTest.Size = new Size(pTest.Width, 20); // Уменьшение панели

            for (int i = 0; i<this.questions.Count; i++) // Цикл добавления вопросов на панель
            {
                this.groups.Add(new GroupBox());
                this.groups[i].SuspendLayout();
                this.groups[i].Text = this.questions[i][0];
                this.groups[i].Location = new Point(19, locationHeightGroup);
                this.groups[i].Size = new Size(860, 130);
                this.groups[i].TabStop = false;
                this.groups[i].ForeColor = Color.FromArgb(255, 224, 192);
                locationHeightGroup += 135;

                for (int j = 1; j<this.questions[i].Count-1; j++)
                {
                    if (Convert.ToInt32(questions[i][5]) == j)
                    {
                        this.rBTrue.Add(new RadioButton()
                        {
                            Text = questions[i][j],
                            Location = locationRB[j-1],
                            AutoSize = true
                        });

                        this.groups[i].Controls.Add(rBTrue.Last());
                    }
                    else this.groups[i].Controls.Add(new RadioButton()
                    {
                        Text = questions[i][j],
                        Location = locationRB[j-1],
                        AutoSize = true
                    });
                }

                this.pTest.Controls.Add(this.groups[i]);
                this.groups[i].ResumeLayout();
            }

            hPanel = (groups.Count+1) * 140; // Максимальный размер панели

            bEnd.Location = new Point(bEnd.Location.X, locationHeightGroup); // Положение кнопки завершения

            fieldOut = new Button()
            {
                BackColor = Color.Transparent,
                Enabled = false,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(1, 12),
                UseVisualStyleBackColor = false,
                Size = new Size(this.pTest.Width-27, hPanel-60)
            };

            fieldOut.FlatAppearance.BorderColor = Color.FromArgb(255,224,192);

            fieldIn = new Button()
            {
                BackColor = Color.Transparent,
                Enabled = false,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(4, 16),
                UseVisualStyleBackColor = false,
                Size = new Size(this.pTest.Width-34, hPanel-68)
            };

            fieldIn.FlatAppearance.BorderColor = Color.FromArgb(255, 224, 192);

            pTest.Controls.Add(fieldIn);
            pTest.Controls.Add(fieldOut);

            this.pTest.ResumeLayout();
        }

        async public void ShowTest(bool isFast)
        {
            if (this.pText != null) this.pText.SuspendLayout();
            this.pTest.SuspendLayout();

            pTest.Visible = true;

            if (isFast)
            {
                if (this.pText != null) this.pText.Size = new Size(this.pText.Width, 10);
                if (this.pText != null)
                {
                    this.pTest.Size = new Size(this.pText.Width, hPanel);
                }
                else this.pTest.Size = new Size(this.pTest.Width, hPanel);

                if (this.pText != null)
                {
                    this.pTest.Location = new Point(this.pTest.Location.X, pText.Location.Y + 10);
                } else this.pTest.Location = new Point(this.pTest.Location.X, 116);
            }
            else
            {
                for (int i = this.pText.Height; i > 10; i= i -20)
                {
                    this.pText.Height = i;
                    await Task.Delay(1);

                }

                pText.Height = 10;
                this.pTest.Location = new Point(this.pTest.Location.X, pText.Location.Y+10);

                for (int i = pTest.Height; i < hPanel; i = i + 20)
                {
                    this.pTest.Height = i;
                    await Task.Delay(1);
                }
            }

            if (this.pText != null) this.pText.ResumeLayout();
            this.pTest.ResumeLayout();
            // Скрыть кнопку старта и предупреждение
        }

        public int TimerWork(Label l, int time)
        {
            int min = time / 60;
            int sec = time % 60 - 1;

            time = (min*60) + sec;
            l.Text = $"{min}:{sec}";

            return time;
        }

        public int End(ref string answerT, ref string answerF)
        {
            answerT += "[";
            answerF += "[";
            int count = 0;
            int ocenka = 2;

            for (int i = 0; i < rBTrue.Count; i++)
            {
                if (rBTrue[i].Checked)
                {
                    count++;
                    answerT += $"{i + 1},";
                }
                else answerF += $"{i + 1},";
            }

            double procent = (double)count / (double)rBTrue.Count * 100;
            if (procent < 90)
            {
                if (procent < 70)
                {
                    if (procent < 50)
                    {
                        ocenka = 2;
                    }
                    else ocenka = 3;
                }
                else ocenka = 4;
            }
            else ocenka = 5;

            if (answerT.Last() == ',')
            {
                answerT = answerT.Remove(answerT.Length - 1);
                answerT += "]";

            }
            else answerT += "]";

            if (answerF.Last() == ',')
            {
                answerF = answerF.Remove(answerF.Length - 1);
                answerF += "]";
            }
            else answerF += "]";

            return ocenka;
        }
    }
}
