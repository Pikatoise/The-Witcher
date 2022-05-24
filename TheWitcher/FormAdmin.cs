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
    public partial class FormAdmin : Form
    {
        public FormAuth formAuth;
        public bool isExit = true;

        public FormAdmin()
        {
            InitializeComponent();
        }

        private void buttonExit_Click(object sender, EventArgs e) // Выход из аккаунта
        {
            if (formAuth.session.Last().Count > 1)
            {
                formAuth.session.Last()[1] = "true";
            }
            
            FormAuth.SaveAllData(true, true, false, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);

            LoginUpdate(false);
            isExit = false;
            this.Hide();

            formAuth.Show();
        }

        private void FormAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isExit)
            {
                FormAuth.SaveAllData(true, true, false, formAuth.dbPath, formAuth.sessionPath, formAuth.answerPath, formAuth.db, formAuth.session, formAuth.answer);
                Application.Exit();
            }
        }

        private void FormAdmin_Load(object sender, EventArgs e)
        {
            LoginUpdate(true);
        }

        private void buttonDB_Click(object sender, EventArgs e)
        {
            FormDB formDB = new FormDB();
            formDB.formAuth = formAuth;
            formDB.login = labelLogin.Text;
            formDB.ShowDialog();
        }

        private void buttonDiag_Click(object sender, EventArgs e)
        {
            FormDiag formDiag = new FormDiag();
            formDiag.formAuth = formAuth;
            formDiag.ShowDialog();
        }

        private void buttonTestEdit_Click(object sender, EventArgs e)
        {
            FormTestEdit formTestEdit = new FormTestEdit();
            formTestEdit.ShowDialog();
        }

        //
        //
        //

        public void LoginUpdate(bool AddOrRemove) // Показывает логин админа
        {
            if (AddOrRemove)
            {
                if (formAuth.id == -2)
                {
                    labelLogin.Text = "Admin";
                } else labelLogin.Text = formAuth.db[formAuth.id][0];
            }
            else labelLogin.Text = "";
        }
    }
}
