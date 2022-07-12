using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GD
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
            
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" & textBox2.Text != "" & textBox4.Text != "" & textBox5.Text != "" & comboBox1.Text != "" & textBox6.Text != "" & comboBox2.Text != "")
            {
                Record();
            }
            else
            {
                MessageBox.Show("Заполните все поля!");
            }
        }
        
        public void Record()
        {
           
                using (ApplicationContext db = new ApplicationContext())
                {
                    if (!db.Users.Any(u => (u.Login == textBox4.Text)))
                    {
                        User user1 = new User { Login = textBox4.Text, Password = textBox5.Text, Sername = textBox1.Text, Name = textBox2.Text, Otchestvo = textBox3.Text, BirDay = dateTimePicker1.Text, Role = comboBox1.Text, Group = textBox6.Text, Kyrs = comboBox2.Text };

                        db.Users.Add(user1);
                        db.SaveChanges();

                        MessageBox.Show("Данные успешно добавлены");
                    }
                    else
                    {
                        MessageBox.Show("Данный логин уже зарегистрирован");
                    }
                }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Avtoriz avtoriz = (Avtoriz)Application.OpenForms[0];
            avtoriz.Show();
            Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar == (int)Keys.Space) & (e.KeyChar >= 'A' && e.KeyChar <= 'Z') || (e.KeyChar >= 'a' && e.KeyChar <= 'z') || (e.KeyChar >= '0' && e.KeyChar <= '9') || (e.KeyChar >= '@' && e.KeyChar <= '@') || (e.KeyChar >= '.' && e.KeyChar <= '.') || (e.KeyChar >= '_' && e.KeyChar <= '_') || (e.KeyChar >= '-' && e.KeyChar <= '-') || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {            
            char c = e.KeyChar;
            e.Handled = c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c >= '0' && c <= '9' || e.KeyChar == (char)Keys.Space;

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c >= '0' && c <= '9' || e.KeyChar == (char)Keys.Space;

        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c >= '0' && c <= '9' || e.KeyChar == (char)Keys.Space;
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            e.Handled = c >= 'A' && c <= 'Z' || c >= 'a' && c <= 'z' || c >= 'а' && c <= 'я' || e.KeyChar == (char)Keys.Space;


        }
    }
    
}
