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
    public partial class FormDB : Form
    {
        public FormAuth formAuth;
        public DB db;
        public string login;

        public FormDB()
        {
            InitializeComponent();
            
        }

        private void FormDB_Load(object sender, EventArgs e)
        {
            db = new DB(formAuth.db);
            db.DataToGrid(mainGrid);
            foreach (DataGridViewColumn column in mainGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.Frozen = false;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (!(textBoxFIO.Text == ""))
            {
                Find(mainGrid, textBoxFIO);
            }
            else MessageBox.Show("Введите ФИО!", "Ошибка", MessageBoxButtons.OK);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            FormAdd formAdd = new FormAdd();
            formAdd.ShowDialog();

            if (formAdd.tempLogin != null)
            {
                db.AddUser(formAdd.tempLogin, formAdd.tempPassword, formAdd.IsAdmin, mainGrid);
            }
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (db.records.Count > 0 && mainGrid.CurrentCell.RowIndex >= 0)
            {
                if (mainGrid.CurrentCell.RowIndex == formAuth.id)
                {
                    MessageBox.Show("Вы не можете удалить собственный аккаунт!", "Ошибка", MessageBoxButtons.OK);
                } else if (MessageBox.Show("Вы действительно хотите удалить контакт?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    db.RemoveUser(mainGrid, mainGrid.CurrentCell.RowIndex);
                    formAuth.id = IdUpdate(formAuth.db);
                }
            }
            else MessageBox.Show("Выберите контакт!", "Ошибка", MessageBoxButtons.OK);
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            db.Sort(mainGrid, textBox1 , buttonSort, labelGroup, buttonAdd,buttonDel);
        }

        //
        //
        //

        public void Find(DataGridView grid, TextBox box)
        {
            grid.ClearSelection();
            for (int i = 0; i< grid.Rows.Count; i++)
            {
                if ((grid.Rows[i].Cells[4].Value != null) && (grid.Rows[i].Cells[4].Value.ToString().Contains(box.Text)))
                {
                    grid.Rows[i].Selected = true;
                }
            }
        }

        public int IdUpdate(List<List<string>> db)
        {
            for (int i = 0; i < db.Count; i++)
            {
                if (db[i][0] == login)
                {
                    return i;
                }
            }
            return -1;
        }

        public class DB
        {
            public List<List<string>> records = new List<List<string>>();

            public DB(List<List<string>> db)
            {
                records = db;
            }

            public void DataToGrid(DataGridView grid)
            {
                grid.Rows.Clear();
                for (int i = 0; i < records.Count; i++)
                {
                    grid.Rows.Add();
                    for (int j= 0; j < records[i].Count; j++)
                    {
                        grid.Rows[i].Cells[j].Value = records[i][j];
                    }
                }
            }

            public void RemoveUser(DataGridView grid, int index)
            {
                this.records.RemoveAt(index);

                this.DataToGrid(grid);
            }

            public void AddUser(string login,string password,bool isAdmin, DataGridView grid)
            {
                bool lTaken = false;

                for (int i=0; i < records.Count; i++)
                {
                    if (records[i][0] == login)
                    {
                        lTaken = true;
                        MessageBox.Show("Логин занят", "Ошибка", MessageBoxButtons.OK);
                    }
                }

                if (!lTaken)
                {
                    if (isAdmin)
                    {
                        this.records.Add(new List<string> { login, password, "admin" });
                    }
                    else
                    {
                        this.records.Add(new List<string> { login, password, "user", "false" });
                    }

                    this.DataToGrid(grid);
                }
            }

            public void Sort(DataGridView grid, TextBox textBoxGroup, Button bSort, Label l, Button Add, Button Del)
            {
                if (bSort.Text.Contains("Сортировать"))
                {
                    List<List<string>> result = new List<List<string>>();

                    for (int i = 0; i<records.Count; i++)
                    {
                        if (records[i].Count >= 6 && records[i][5].Contains(textBoxGroup.Text))
                        {
                            result.Add(records[i]);
                        }
                    }

                    for (int i = 0; i < result.Count; i++)
                    {
                        for (int j = i + 1; j < result.Count; j++)
                        {
                            List<string> temp = new List<string>();

                            if (result[i][4][0] > result[j][4][0])
                            {
                                temp = result[i];
                                result[i] = result[j];
                                result[j] = temp;
                            }
                        }
                    }

                    grid.Rows.Clear();
                    for (int i = 0; i < result.Count; i++)
                    {
                        grid.Rows.Add();
                        for (int j = 0; j < result[i].Count; j++)
                        {
                            grid.Rows[i].Cells[j].Value = result[i][j];
                        }
                    }

                    bSort.Text = "Отмена";
                    textBoxGroup.Enabled = false;
                    textBoxGroup.Visible = false;
                    Add.Enabled = false;
                    Add.Visible = false;
                    Del.Enabled = false;
                    Del.Visible = false;
                    l.Visible = false;
                } else if (bSort.Text.Contains("Отмена"))
                {
                    this.DataToGrid(grid);
                    bSort.Text = "Сортировать";
                    textBoxGroup.Enabled = true;
                    textBoxGroup.Visible = true;
                    Add.Enabled = true;
                    Add.Visible = true;
                    Del.Enabled = true;
                    Del.Visible = true;
                    l.Visible = true;
                }
            }
        }
    }
}
