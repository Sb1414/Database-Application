using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace PassApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBoxLogin.Text = "Логин";
            textBoxLogin.ForeColor = Color.FromArgb(127, 128, 132); 
            textBoxPass.Text = "Пароль";
            textBoxPass.PasswordChar = '\0';
            textBoxPass.ForeColor = Color.FromArgb(127, 128, 132);
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
            labelInfo.Text = "";
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(127, 128, 132);
            labelInfo.Text = "";
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            if ((textBoxLogin.Text == "" | textBoxLogin.Text == "Логин") | (textBoxPass.Text == "" | textBoxPass.Text == "Пароль"))
            {
                labelInfo.Text = "Заполнены не все поля!";
                labelInfo.ForeColor = Color.Red;
            }
            else
            {
                string loginUser = textBoxLogin.Text;
                string passUser = textBoxPass.Text;

                DataBank.loginUser = loginUser;
                DataBank.passwordUser = passUser;

                DBclass db = new DBclass();

                DataTable table = new DataTable();

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `Login` = @uL AND `Password` = @uP", db.getConnection());
                command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = loginUser;
                command.Parameters.Add("@uP", MySqlDbType.VarChar).Value = passUser;

                adapter.SelectCommand = command;
                adapter.Fill(table);

                labelInfo.Text = "Проверка...";
                labelInfo.ForeColor = Color.FromArgb(230, 179, 51);

                if (table.Rows.Count > 0)
                {
                    labelInfo.Text = "Выполняется вход";
                    labelInfo.ForeColor = Color.FromArgb(230, 179, 51);

                    Form3 form3 = new Form3();
                    form3.Show();
                    this.Hide();

                }
                else
                {
                    labelInfo.Text = "Пользователь не найден";
                    labelInfo.ForeColor = Color.Red;
                }
            }
        }

        private void textBoxLogin_Enter(object sender, EventArgs e)
        {
            if (textBoxLogin.Text == "Логин")
            {
                textBoxLogin.Text = "";
                textBoxLogin.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panel2.BackgroundImage = Properties.Resources.backLogClick;
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
            panel2.BackgroundImage = Properties.Resources.backPassClick;
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
            panel2.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

    }
}
