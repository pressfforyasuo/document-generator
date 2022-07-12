using System;
using System.Linq;
using System.Windows.Forms;


namespace GD
{
    public partial class GDA : Form
    {
        private void button2_Click(object sender, EventArgs e)
        {
            Avtoriz avtoriz = (Avtoriz)Application.OpenForms[0];
            avtoriz.Show();
            Close();
        }

        public GDA()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
            {
                MessageBox.Show("Выберите справку!");
            }
            else
            {
                perenos();
                MessageBox.Show("Заказ сделан.");
            }
        }

        private void GDA_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        public void perenos()
        {
            using ApplicationContext db = new ApplicationContext();
            User user = db.Users.SingleOrDefault(u => u.Login == Program.CurrentUser.Login);
            InformationTo informationTo = new InformationTo()
            {
                doc1 = comboBox1.Text,
                mail1 = user.Login,
                fio1 = user.Sername + ' ' + user.Name + ' ' + user.Otchestvo,
                group1 = user.Group,
                kyrs = user.Kyrs
            };
            db.InformationTos.Add(informationTo);
            db.SaveChanges();
        }        
    }
}

