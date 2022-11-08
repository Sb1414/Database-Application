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
        private bool flag = false;
        private bool visXO = false;
        private bool pass = false;

        string t = "";
        Random rnd = new Random(); // кто первый ходит
        int[] array = new int[9];
        System.Windows.Forms.Button[] btn = new System.Windows.Forms.Button[9];

        public Form3()
        {
            InitializeComponent();
            search();
            goArr();
            textBoxOld.Text = "Старый пароль";
            textBoxNew.Text = "Новый пароль";
            textBoxOld.ForeColor = Color.FromArgb(127, 128, 132);
            textBoxNew.ForeColor = Color.FromArgb(127, 128, 132);
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

        private void buttonMinimiz_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonMaximiz_Click(object sender, EventArgs e)
        {
            if (!flag)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
            flag = !flag;
        }


        private void mSave_Click(object sender, EventArgs e)
        {
            if (!pass)
            {
                panelPass.Visible = true;
                pass = true;
            } else
            {
                panelPass.Visible = false;
                pass = false;
            }
        }

        public void goArr()
        {
            if (rnd.Next(1, 10) <= 5)
            {
                t = "крестики";
                labelXO.Text = "Первыми ходят X";
            }
            else
            {
                t = "нолики";
                labelXO.Text = "Первыми ходят O";
            }

            btn[0] = button1;
            btn[1] = button2;
            btn[2] = button3;
            btn[3] = button4;
            btn[4] = button5;
            btn[5] = button6;
            btn[6] = button7;
            btn[7] = button8;
            btn[8] = button9;
        }

        public void drawColorWin()
        {
            if (array[0] == 1 && array[1] == 1 && array[2] == 1)
            {
                btn[0].BackgroundImage = Properties.Resources.XOgoriz;
                btn[1].BackgroundImage = Properties.Resources.XOgoriz;
                btn[2].BackgroundImage = Properties.Resources.XOgoriz;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли крестики";
            } else if (array[3] == 1 && array[4] == 1 && array[5] == 1) 
            {
                btn[3].BackgroundImage = Properties.Resources.XOgoriz;
                btn[4].BackgroundImage = Properties.Resources.XOgoriz;
                btn[5].BackgroundImage = Properties.Resources.XOgoriz;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли крестики";
            } else if (array[6] == 1 && array[7] == 1 && array[8] == 1)
            {
                btn[6].BackgroundImage = Properties.Resources.XOgoriz;
                btn[7].BackgroundImage = Properties.Resources.XOgoriz;
                btn[8].BackgroundImage = Properties.Resources.XOgoriz;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли крестики";
            } else if (array[2] == 1 && array[5] == 1 && array[8] == 1)
            {
                btn[2].BackgroundImage = Properties.Resources.XOvertical;
                btn[5].BackgroundImage = Properties.Resources.XOvertical;
                btn[8].BackgroundImage = Properties.Resources.XOvertical;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли крестики";
            } else if (array[1] == 1 && array[4] == 1 && array[7] == 1)
            {
                btn[1].BackgroundImage = Properties.Resources.XOvertical;
                btn[4].BackgroundImage = Properties.Resources.XOvertical;
                btn[7].BackgroundImage = Properties.Resources.XOvertical;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли крестики";
            } else if (array[0] == 1 && array[3] == 1 && array[6] == 1)
            {
                btn[0].BackgroundImage = Properties.Resources.XOvertical;
                btn[3].BackgroundImage = Properties.Resources.XOvertical;
                btn[6].BackgroundImage = Properties.Resources.XOvertical;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли крестики";
            } else if (array[0] == 1 && array[4] == 1 && array[8] == 1)
            {
                btn[0].BackgroundImage = Properties.Resources.XOglavnDiag;
                btn[4].BackgroundImage = Properties.Resources.XOglavnDiag;
                btn[8].BackgroundImage = Properties.Resources.XOglavnDiag;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли крестики";
            } else if (array[2] == 1 && array[4] == 1 && array[6] == 1)
            {
                btn[2].BackgroundImage = Properties.Resources.XOpobochnDiag;
                btn[4].BackgroundImage = Properties.Resources.XOpobochnDiag;
                btn[6].BackgroundImage = Properties.Resources.XOpobochnDiag;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли крестики";
            } else if (array[0] == 2 && array[1] == 2 && array[2] == 2)
            {
                btn[0].BackgroundImage = Properties.Resources.XOgoriz;
                btn[1].BackgroundImage = Properties.Resources.XOgoriz;
                btn[2].BackgroundImage = Properties.Resources.XOgoriz;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли нолики";
            }
            else if (array[3] == 2 && array[4] == 2 && array[5] == 2)
            {
                btn[3].BackgroundImage = Properties.Resources.XOgoriz;
                btn[4].BackgroundImage = Properties.Resources.XOgoriz;
                btn[5].BackgroundImage = Properties.Resources.XOgoriz;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли нолики";
            }
            else if (array[6] == 2 && array[7] == 2 && array[8] == 2)
            {
                btn[6].BackgroundImage = Properties.Resources.XOgoriz;
                btn[7].BackgroundImage = Properties.Resources.XOgoriz;
                btn[8].BackgroundImage = Properties.Resources.XOgoriz;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли нолики";
            }
            else if (array[2] == 2 && array[5] == 2 && array[8] == 2)
            {
                btn[2].BackgroundImage = Properties.Resources.XOvertical;
                btn[5].BackgroundImage = Properties.Resources.XOvertical;
                btn[8].BackgroundImage = Properties.Resources.XOvertical;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли нолики";
            }
            else if (array[1] == 2 && array[4] == 2 && array[7] == 2)
            {
                btn[1].BackgroundImage = Properties.Resources.XOvertical;
                btn[4].BackgroundImage = Properties.Resources.XOvertical;
                btn[7].BackgroundImage = Properties.Resources.XOvertical;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли нолики";
            }
            else if (array[0] == 2 && array[3] == 2 && array[6] == 2)
            {
                btn[0].BackgroundImage = Properties.Resources.XOvertical;
                btn[3].BackgroundImage = Properties.Resources.XOvertical;
                btn[6].BackgroundImage = Properties.Resources.XOvertical;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли нолики";
            }
            else if (array[0] == 2 && array[4] == 2 && array[8] == 2)
            {
                btn[0].BackgroundImage = Properties.Resources.XOglavnDiag;
                btn[4].BackgroundImage = Properties.Resources.XOglavnDiag;
                btn[8].BackgroundImage = Properties.Resources.XOglavnDiag;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли нолики";
            }
            else if (array[2] == 2 && array[4] == 2 && array[6] == 2)
            {
                btn[2].BackgroundImage = Properties.Resources.XOpobochnDiag;
                btn[4].BackgroundImage = Properties.Resources.XOpobochnDiag;
                btn[6].BackgroundImage = Properties.Resources.XOpobochnDiag;
                for (int i = 0; i < btn.Length; i++)
                {
                    btn[i].Enabled = false;
                }
                button10.Enabled = true;
                labelXO.Text = "Выиграли нолики";
            }
        }

        private void Click(object sender, EventArgs e) // Создаем функцию для нажатия каждой кнопки из формы
        {
            if (t == "крестики")
            {
                for (int i = 0; i < btn.Length; i++)
                {
                    if (sender == btn[i])
                    {
                        btn[i].Text = "X";
                        t = "нолики";
                        btn[i].Enabled = false;
                        array[i] = 1;
                        labelXO.Text = "Ходят O";
                        break;
                    }
                }
            } else
            {
                for (int i = 0; i < btn.Length; i++)
                {
                    if (sender == btn[i])
                    {
                        btn[i].Text = "O";
                        t = "крестики";
                        btn[i].Enabled = false;
                        array[i] = 2;
                        labelXO.Text = "Ходят X";
                        break;
                    }
                }
            }
            drawColorWin();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < btn.Length; i++)
            {
                array[i] = 0;
                btn[i].Text = "";

                if (rnd.Next(1, 10) <= 5)
                {
                    t = "крестики";
                    labelXO.Text = "Первыми ходят X";
                }
                else
                {
                    t = "нолики";
                    labelXO.Text = "Первыми ходят O";
                }
                btn[i].Enabled = true;
                btn[i].BackgroundImage = null;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (!visXO)
            {
                panelGame.Visible = true;
                button10.Visible = true;
                labelXO.Visible = true;
                visXO = true;
            } else
            {
                panelGame.Visible = false;
                button10.Visible = false;
                labelXO.Visible = false;
                visXO = false;
            }
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            labelInfo.Text = "";
            if ((textBoxOld.Text == "" | textBoxOld.Text == "Старый пароль") | (textBoxNew.Text == "" | textBoxNew.Text == "Новый пароль"))
            {
                labelInfo.Text = "Заполнены не все поля!";
                labelInfo.ForeColor = Color.Red;
            } else if (textBoxOld.Text == textBoxNew.Text) {
                labelInfo.Text = "Пароли совпадают!";
                labelInfo.ForeColor = Color.Red;
            }
            else
            {
                DBclass db1 = new DBclass();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("SELECT * FROM `user` WHERE `Login` = @uL AND `Password` = @uP", db1.getConnection());
                command1.Parameters.Add("@uL", MySqlDbType.VarChar).Value = DataBank.loginUser;
                command1.Parameters.Add("@uP", MySqlDbType.VarChar).Value = textBoxOld.Text;

                adapter.SelectCommand = command1;
                adapter.Fill(table);

                labelInfo.Text = "Проверка...";
                labelInfo.ForeColor = Color.FromArgb(230, 179, 51);

                if (table.Rows.Count > 0)
                {
                    DBclass db = new DBclass();
                    MySqlCommand command = new MySqlCommand("UPDATE `user` SET `password` = @newpass WHERE `user`.`login` = @login", db.getConnection());

                    command.Parameters.Add("@newpass", MySqlDbType.VarChar).Value = textBoxNew.Text;
                    command.Parameters.Add("@login", MySqlDbType.VarChar).Value = DataBank.loginUser;

                    db.openConnection();

                    labelInfo.Text = "Смена пароля..";
                    labelInfo.ForeColor = Color.FromArgb(230, 179, 51);

                    if (command.ExecuteNonQuery() == 1)
                    {
                        labelInfo.Text = "Пароль изменён!";
                        labelInfo.ForeColor = Color.FromArgb(230, 179, 51); 
                        textBoxOld.Text = "Старый пароль";
                        textBoxNew.Text = "Новый пароль";
                        textBoxOld.ForeColor = Color.FromArgb(127, 128, 132);
                        textBoxNew.ForeColor = Color.FromArgb(127, 128, 132);

                    }
                    else
                    {
                        labelInfo.Text = "Ошибка, пароль не изменен";
                        labelInfo.ForeColor = Color.Red;
                        textBoxOld.Text = "Старый пароль";
                        textBoxNew.Text = "Новый пароль";
                        textBoxOld.ForeColor = Color.FromArgb(127, 128, 132);
                        textBoxNew.ForeColor = Color.FromArgb(127, 128, 132);
                    }
                }
                else
                {
                    labelInfo.Text = "Старый пароль неверный";
                    labelInfo.ForeColor = Color.Red;
                    textBoxOld.Text = "Старый пароль";
                    textBoxNew.Text = "Новый пароль";
                    textBoxOld.ForeColor = Color.FromArgb(127, 128, 132);
                    textBoxNew.ForeColor = Color.FromArgb(127, 128, 132);
                }
            }
        }

        private void textBoxOld_Enter(object sender, EventArgs e)
        {
            if (textBoxOld.Text == "Старый пароль")
            {
                textBoxOld.Text = "";
                textBoxOld.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panelBackPass.BackgroundImage = Properties.Resources.backLogClick;
            labelInfo.Text = "";
        }

        private void textBoxOld_Leave(object sender, EventArgs e)
        {
            if (textBoxOld.Text == "")
            {
                textBoxOld.Text = "Старый пароль";
                textBoxOld.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panelBackPass.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void textBoxNew_Enter(object sender, EventArgs e)
        {
            if (textBoxNew.Text == "Новый пароль")
            {
                textBoxNew.Text = "";
                textBoxNew.ForeColor = Color.FromArgb(230, 179, 51);
            }
            panelBackPass.BackgroundImage = Properties.Resources.backPassClick;
            labelInfo.Text = "";
        }

        private void textBoxNew_Leave(object sender, EventArgs e)
        {
            if (textBoxNew.Text == "")
            {
                textBoxNew.Text = "Новый пароль";
                textBoxNew.ForeColor = Color.FromArgb(127, 128, 132);
            }
            panelBackPass.BackgroundImage = Properties.Resources.backClick;
            labelInfo.Text = "";
        }

        private void mLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("действительно выйти?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("действительно удалить аккаунт?", "Warning", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                DBclass db1 = new DBclass();
                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                MySqlCommand command1 = new MySqlCommand("DELETE FROM user WHERE `user`.`login` = @uL", db1.getConnection());
                command1.Parameters.Add("@uL", MySqlDbType.VarChar).Value = DataBank.loginUser;

                adapter.SelectCommand = command1;
                adapter.Fill(table);

                labelInfo.Text = "Проверка...";
                labelInfo.ForeColor = Color.FromArgb(230, 179, 51);

                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();
            }
            
        }
    }
}
