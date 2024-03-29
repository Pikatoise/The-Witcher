﻿using System;
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
    public partial class FormAdd : Form
    {
        public string tempLogin = null;
        public string tempPassword;
        public bool IsAdmin;

        public FormAdd()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e) // Проверяет и заносит данные в переменные для будущего сохранения
        {
            string tempL = textBoxLogin.Text.Replace(" ", "");
            string tempP = textBoxPassword.Text.Replace(" ", "");
            if (tempL.Length > 2 && tempP.Length >2)
            {
                tempLogin = tempL;
                tempPassword = tempP;
                
                if (checkBoxAdmin.Checked)
                {
                    IsAdmin = true;
                } else IsAdmin = false;
            }

            this.Close();
        }
    }
}
