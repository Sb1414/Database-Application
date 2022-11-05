using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace PassApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBoxLogin.Text = "Логин";
            textBoxLogin.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxPass.Text = "Пароль";
            textBoxPass.PasswordChar = '\0';
            textBoxPass.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxName.Text = "Имя";
            textBoxName.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxSurname.Text = "Фамилия";
            textBoxSurname.ForeColor = Color.FromArgb(127, 128, 132);
            labelInfo.Text = "";
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        Point lastPoint;
        private void panelUp_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panelUp_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
            this.Hide();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(230, 179, 51);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(127, 128, 132);
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "Логин")
            {
                textBoxLogin.Text = "";
                textBoxLogin.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel3.BackgroundImage = Properties.Resources.backLogClick;
            panel2.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxPass_Enter(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "Пароль")
            {
                textBoxPass.Text = "";
                textBoxPass.PasswordChar = '●';
                textBoxPass.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel3.BackgroundImage = Properties.Resources.backPassClick;
            panel2.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxPass_Leave(object sender, EventArgs e)
        {
            if (textBoxPass.Text == "")
            {
                textBoxPass.Text = "Пароль";
                textBoxPass.PasswordChar = '\0';
                textBoxPass.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel2.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxLogin_Leave(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "")
            {
                textBoxLogin.Text = "Логин";
                textBoxLogin.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel3.BackgroundImage = Properties.Resources.backClick;
            panel2.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxName_Enter(object sender, EventArgs e)
        {
            if (textBoxName.Text == "Имя")
            {
                textBoxName.Text = "";
                textBoxName.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backLogClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxName_Leave(object sender, EventArgs e)
        {
            if (textBoxName.Text == "")
            {
                textBoxName.Text = "Имя";
                textBoxName.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxSurname_Enter(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "Фамилия")
            {
                textBoxSurname.Text = "";
                textBoxSurname.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backPassClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxSurname_Leave(object sender, EventArgs e)
        {
            if (textBoxSurname.Text == "")
            {
                textBoxSurname.Text = "Фамилия";
                textBoxSurname.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panel2.BackgroundImage = Properties.Resources.backClick;
            panel3.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            if ((textBoxLogin.Text == "" | textBoxLogin.Text == "Логин") | (textBoxPass.Text == "" | textBoxPass.Text == "Пароль") | (textBoxName.Text == "" | textBoxName.Text == "Имя") | (textBoxSurname.Text == "" | textBoxSurname.Text == "Фамилия"))
            {
                labelInfo.Text = "Заполнены не все поля!";
                labelInfo.ForeColor = Color.Red;
            } else if (checkUser())
            {
                labelInfo.Text = "Такой логин уже существует";
                labelInfo.ForeColor = Color.Red;
            }
            else
            {
                DBclass db = new DBclass();
                MySqlCommand command = new MySqlCommand("INSERT INTO `user` (`login`, `password`, `name`, `surname`) VALUES (@login, @pass, @name, @surname)", db.getConnection());

                command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBoxLogin.Text;
                command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBoxPass.Text;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBoxName.Text;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBoxSurname.Text;

                db.openConnection();

                labelInfo.Text = "Создание аккаунта..";
                labelInfo.ForeColor = Color.FromArgb(230, 179, 51);

                if (command.ExecuteNonQuery() == 1)
                {
                    labelInfo.Text = "Аккаунт создан, войдите!";
                    labelInfo.ForeColor = Color.FromArgb(230, 179, 51);

                    DataBank.loginUser = textBoxLogin.Text;
                    DataBank.passwordUser = textBoxPass.Text;

                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();

                }
                else
                {
                    labelInfo.Text = "Аккаунт не был создан";
                    labelInfo.ForeColor = Color.Red;
                }
            }
        }

        public Boolean checkUser()
        {
            labelInfo.Text = "";
            DBclass db = new DBclass();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `Login` = @uL", db.getConnection());
            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBoxLogin.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
