using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PassApp
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            search();
        }

        public void search()
        {
            DBclass db = new DBclass();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `user` WHERE `login` LIKE '@log'", db.getConnection());

            command.Parameters.Add("@log", MySqlDbType.VarChar).Value = DataBank.loginUser;

            labelName.Text = "Добро пожаловать, ";
            labelName.Text += DataBank.loginUser;

            MySqlDataReader reader;

            try
            {
                command.Connection.Open();
                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    labelName.Text = reader["name"].ToString() + " " + reader["surname"].ToString();
                }
                reader.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

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

    }
}
