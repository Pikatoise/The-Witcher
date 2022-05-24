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
    public partial class FormAuth : Form
    {
        public string docPath;
        public string login;
        public string sessionPath;
        public string dbPath;
        public string answerPath;
        public int id;
        public int idAnswer;
        FormBookMenucs formBookMenucs = new FormBookMenucs();
        FormAdmin formAdmin = new FormAdmin();

        public List<List<string>> session = new List<List<string>>();
        public List<List<string>> db = new List<List<string>>();
        public List<List<string>> answer = new List<List<string>>();

        public FormAuth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e) // Нажатие кнопки входа
        {
            if (textBoxLogin.Text == "Admin" && textBoxPassword.Text == "ont2022") // Мастер админ
            {
                textBoxLogin.Text = ""; // Очистка полей
                textBoxPassword.Text = "";
                checkBox1.Checked = false;
                id = -2;
                ToAdmin();
            } else
            {
                if (Authorization(false, textBoxLogin.Text, textBoxPassword.Text, checkBox1.Checked)) // Проверка логина и пароля и занесение в сессии
                {
                    textBoxLogin.Text = ""; // Очистка полей
                    textBoxPassword.Text = "";
                    checkBox1.Checked = false;
                    NextForm(); // Загрузка следующего окна
                }
                else
                {
                    textBoxLogin.Text = ""; // Очистка полей вывод сообщения-ошибки
                    textBoxPassword.Text = "";
                    MessageBox.Show("Неверный логин или пароль!", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormAuth_Load(object sender, EventArgs e) // Загрузка формы авторизации
        {
            docPath = Directory.CreateDirectory($@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TheWitcherBook").FullName; // Путь до папки Документы
            sessionPath = $@"{docPath}\session.txt"; // Путь до файла с сессиями
            dbPath = $@"{docPath}\db.txt"; // Путь до файла с базой данных
            answerPath = $@"{docPath}\answer.txt";

            session = SessionLoad(sessionPath); // Загрузка сессий
            db = DbLoad(dbPath); // Загрузка дб
            answer = AnswerLoad(answerPath); // Загрузка ответов

            if (SessionCheck(ref login)) // Проверка последней сессии
            {
                if (Authorization(true)) // Проверка логина из последней сессии
                {
                    NextForm(); // Загрузка следующего окна
                }
            }
        }

        private void buttonReg_Click(object sender, EventArgs e) // Нажатие кнопки регистрации
        {
            if (textBoxFIO.Text.Length>3 && textBoxGroup.Text.Length>3) // Проверка данных
            {
                Reg(textBoxFIO.Text,textBoxGroup.Text); // Добавление данных в поле пользователя

                textBoxFIO.Text = "";
                textBoxGroup.Text = "";

                ShowReg(false); // Сворачивание регистрации и разворот авторизации
                ToBook(); // Переход на форму с темами
            } else
            {
                textBoxFIO.Text = ""; // Очистка полей и вывод сообщения-ошибки
                textBoxGroup.Text = "";
                MessageBox.Show("Неверный данные!", "Ошибка регистрации", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormAuth_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        ///
        ///
        ///

        public int AnswerID(int id)
        {
            for (int i = 0; i< answer.Count; i++)
            {
                if (answer[i][0].Equals(db[id][0]))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool SessionCheck(ref string login) // Проверяет последнюю сессию и если пользователь не вышел, записывает логин и возвращает авторизацию
        {
            if (session.Last().Contains("false")) // Проверка был ли выход в последней сессии
            {
                login = session.Last()[0]; // Сохранение логина последней сессии
                return true;
            }
            else return false;
        }

        public bool Authorization(bool isSession, string boxLogin="null", string boxPassword="null", bool isOut=false) // Проверяет пользователя по базе
        {
            id = -1;

            if (isSession) // Если при последней сессии не было выхода
            {
                for (int i = 0; i<db.Count; i++)
                {
                    if (db[i][0].Equals(login))
                    {
                        id = i;
                        break;
                    }
                } 
            } else // Eсли выход был
            {
                for (int i = 0; i<db.Count; i++)
                {
                    if (db[i][0].Equals(boxLogin) && db[i][1].Equals(boxPassword))
                    {
                        id = i;
                        if (isOut)
                        {
                            session.Add(new List<string> { $"{db[id][0]}", "false" });
                        } else session.Add(new List<string> { $"{db[id][0]}", "true" });
                        break;
                    }
                }
            }

            if (id == -1) // Если логин не найден в базе
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        public List<List<string>> DbLoad(string path) // Загружает и разбивает файл базы данных
        {
            List<List<string>> db = new List<List<string>> ();
            string[] tempFull;

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (StreamReader stream = new StreamReader(path))
            {
                tempFull = stream.ReadToEnd().Split(new char[] { '\n' });
                stream.Close();
            }

            for (int i = 0; i < tempFull.Length; i++)
            {
                tempFull[i] = tempFull[i].Replace("\r", "");
                tempFull[i] = tempFull[i].Replace("\n", "");

                db.Add(new List<string>());

                db[i] = tempFull[i].Split(new char[] { ' ' }).ToList();
            }

            return db;
        }

        public List<List<string>> AnswerLoad(string path) // Загружает и разбивает файл ответов
        {
            List<List<string>> tempOut = new List<List<string>>();
            string[] tempFull;

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (StreamReader stream = new StreamReader(path))
            {
                tempFull = stream.ReadToEnd().Split(new char[] { '\n' });
                stream.Close();
            }

            for (int i = 0; i < tempFull.Length; i++)
            {
                tempFull[i] = tempFull[i].Replace("\r", "");
                tempFull[i] = tempFull[i].Replace("\n", "");

                tempOut.Add(new List<string>());

                tempOut[i] = tempFull[i].Split(new char[] { ' ' }).ToList();
            }

            return tempOut;
        }

        public List<List<string>> SessionLoad(string path) // Загружает и разбивает файл сессий
        {
            List<List<string>> tempOut = new List<List<string>>();
            string[] temp;

            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }

            using (StreamReader stream = new StreamReader(path))
            {
                temp = stream.ReadToEnd().Split(new char[] { '\n' });
                stream.Close();
            }

            for (int i = 0; i < temp.Length; i++)
            {
                temp[i] = temp[i].Replace("\r", "");
                temp[i] = temp[i].Replace("\n", "");

                tempOut.Add(new List<string>());

                tempOut[i] = temp[i].Split(new char[] { ' ' }).ToList();
            }

            return tempOut;
        }

        public void NextForm() // Определение следующей формы для перехода
        {
            if (db[id][2].Equals("admin"))
            {
                ToAdmin();
            } else
            {
                if (db[id][3].Equals("false"))
                {
                    ShowReg(true);
                } else
                {
                    ToBook();
                }
            }
        }

        public void ToBook() // Переход на форму с темами
        {
            idAnswer = AnswerID(id);
            this.Hide();
            formBookMenucs.formAuth = this;
            formBookMenucs.isExit = true;
            formBookMenucs.ShowDialog();
        }

        public void ToAdmin() // Переход на форму админа
        {
            this.Hide();
            formAdmin.formAuth = this;
            formAdmin.isExit = true;
            formAdmin.ShowDialog();
        }

        public void Reg(string FIO, string group) // Добавляет пользователю в бд ФИО и группу
        {
            db[id][3] = "true";
            db[id].Add(FIO.Replace(" ", ""));
            db[id].Add(group.Replace(" ", ""));
        }

        public static void SaveAllData(bool IsDB, bool IsSession, bool isAnswer, string dbPath, string sessionPath, string answerPath, List<List<string>> db, List<List<string>> session, List<List<string>> answer) // Сохранение данных из списков в нужные файлы
        {
            if (IsDB) // Если нужно
            {
                using (StreamWriter stream = new StreamWriter(dbPath, false))
                {
                    for (int i = 0; i<db.Count; i++)
                    {
                        string temp = "";
                        for (int j = 0; j<db[i].Count; j++)
                        {
                            if (j == db[i].Count-1)
                            {
                                temp = temp + $"{db[i][j]}";
                            }
                            else temp = temp + $"{db[i][j]} ";
                        }

                        if (i == db.Count-1)
                        {
                            stream.Write(temp);
                        }
                        else stream.WriteLine(temp);

                    }
                }
            }

            if (IsSession) // Если нужно
            {
                using (StreamWriter stream = new StreamWriter(sessionPath, false))
                {
                    for (int i = 0; i<session.Count; i++)
                    {
                        string temp = "";
                        for (int j = 0; j<session[i].Count; j++)
                        {
                            if (j == session[i].Count-1)
                            {
                                temp = temp + $"{session[i][j]}";
                            }
                            else temp = temp + $"{session[i][j]} ";
                        }

                        if (i == session.Count-1)
                        {
                            stream.Write(temp);
                        }
                        else stream.WriteLine(temp);
                    }
                }
            }

            if (isAnswer)
            {
                using (StreamWriter stream = new StreamWriter(answerPath, false))
                {
                    for (int i = 0; i < answer.Count; i++)
                    {
                        string temp = "";
                        for (int j = 0; j < answer[i].Count; j++)
                        {
                            if (j == answer[i].Count - 1)
                            {
                                temp = temp + $"{answer[i][j]}";
                            }
                            else temp = temp + $"{answer[i][j]} ";
                        }

                        if (i == answer.Count - 1)
                        {
                            stream.Write(temp);
                        }
                        else stream.WriteLine(temp);
                    }
                }
            }
        }

        async public void ShowReg(bool isShow) // Раскрытие/Скрытие контролов регистрации и авторизации
        {
            if (isShow)
            {
                for (int i = panelAuth.Height; i>10;)
                {
                    i = i - 10;
                    panelAuth.Height = i;
                    await Task.Delay(1);
                }

                panelAuth.Enabled = false;

                panelReg.Location = new Point(panelReg.Location.X, 240);

                for (int i = panelReg.Height; i<150;)
                {
                    i = i + 10;
                    panelReg.Height = i;
                    await Task.Delay(1);
                }

                panelReg.Enabled = true;
            } else
            {
                panelReg.Height = 10;
                panelReg.Location = new Point(panelReg.Location.X, 400);
                panelReg.Enabled = false;

                panelAuth.Enabled = true;
                panelAuth.Height = 300;
            }
        }
    }
}
