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
using System.Diagnostics;

namespace TheWitcher
{
    public partial class FormTestEdit : Form
    {
        string temp;
        string docPath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\TheWitcherBook"; // путь до документов

        public FormTestEdit()
        {
            InitializeComponent();
        }

        private void buttonT_MouseEnter(object sender, EventArgs e) // При наведении меняет надпись
        {
            ((Button)sender).SuspendLayout();
            temp = ((Button)sender).Text;
            ((Button)sender).Text = "Редактировать";
            ((Button)sender).ResumeLayout();
        }

        private void buttonT_MouseLeave(object sender, EventArgs e) // При выходе мыши из кнопки возвращает надпись
        {
            ((Button)sender).SuspendLayout();
            ((Button)sender).Text = temp;
            ((Button)sender).ResumeLayout();
        }

        private void buttonT_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "buttonT1":
                    EditT($@"{docPath}\T1.txt");
                    break;
                case "buttonT2":
                    EditT($@"{docPath}\T2.txt");
                    break;
                case "buttonT3":
                    EditT($@"{docPath}\T3.txt");
                    break;
                case "buttonT4":
                    EditT($@"{docPath}\T4.txt");
                    break;
                case "buttonT5":
                    EditT($@"{docPath}\T5.txt");
                    break;
                case "buttonF":
                    EditT($@"{docPath}\F.txt");
                    break;
            }
        }

        private void buttonTLoad_MouseEnter(object sender, EventArgs e)
        {
            ((Button)sender).SuspendLayout();
            temp = ((Button)sender).Text;
            ((Button)sender).Text = "Скачать";
            ((Button)sender).ResumeLayout();
        }

        private void buttonTLoad_Click(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "buttonT1Load":
                    DownloadT(Properties.Resources.T1);
                    break;
                case "buttonT2Load":
                    DownloadT(Properties.Resources.T2);
                    break;
                case "buttonT3Load":
                    DownloadT(Properties.Resources.T3);
                    break;
                case "buttonT4Load":
                    DownloadT(Properties.Resources.T4);
                    break;
                case "buttonT5Load":
                    DownloadT(Properties.Resources.T5);
                    break;
                case "buttonFLoad":
                    DownloadT(Properties.Resources.F);
                    break;
            }
        }

        void EditT(string path) // Открытие/Создание файла теста для редактирования
        {
            if (File.Exists(path))
            {
                Process.Start(path);
            }
            else
            {
                FileStream file = File.Create(path);
                file.Close();
                Process.Start(path);
            }
        }

        void DownloadT(string text) // Скачать тест из ресурсов в txt
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                DefaultExt = "txt",
                AddExtension = true,
                Title = "Выберите путь",
                OverwritePrompt = true
            };
            string path;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog.FileName;

                FileStream file = File.Create(path);
                file.Close();

                using (StreamWriter stream = new StreamWriter(path, false))
                {
                    stream.Write(text);
                }
            }
        }
    }
}
