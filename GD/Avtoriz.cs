using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace GD
{
    public partial class Avtoriz : Form
    {

        public Avtoriz()
        {
            InitializeComponent();
        }

        public void avtoris()
        {
            Avtoriz avtoriz = new Avtoriz();
            ApplicationContext db = new ApplicationContext();
            {

                User user1 = new User { Login = textBox2.Text, Password = maskedTextBox2.Text };
                if (db.Users.Any(u => (u.Login == textBox2.Text) && (u.Password == maskedTextBox2.Text)))
                {
                    User user = db.Users.Single(u => (u.Login == textBox2.Text) && (u.Password == maskedTextBox2.Text));

                    if (user.Role == "Администратор")
                    {
                        GDU gdu = new GDU();
                        gdu.Show();
                       

                        label7.Visible = false;
                    }
                    else
                    {
                        GDA gda = new GDA();
                        gda.Show();
                       
                        label7.Visible = false;
                    }
                    Program.CurrentUser = user;

                }
                else
                {
                    label7.Visible = true;
                }
            }
        }

        private void Avtoriz_Load(object sender, EventArgs e)
        {
            label7.Visible = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" & maskedTextBox2.Text != "")
            {
                avtoris();
            }
            else
            {
                MessageBox.Show("Логин или пароль не заполнены!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.Show();
            this.Hide();

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (int)Keys.Space) & (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= '@' && e.KeyChar <= '@') || (e.KeyChar >= '.' && e.KeyChar <= '.') || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }

        }

        private void maskedTextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (int)Keys.Space) & (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }
    }
}
