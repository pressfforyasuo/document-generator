using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;

namespace GD
{
    public partial class GDU : Form
    {
        public static string file;
        private readonly string TemplateFileName1 = @"D:\GD\GD\documents\Справка1.dotx";
        private readonly string TemplateFileName2 = @"D:\GD\GD\documents\Справка2.dotx";
        private readonly string TemplateFileName3 = @"D:\GD\GD\documents\Справка3.dotx";
        public string mail, doc, fio, group, document1, document1New;


        public GDU()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Справка №1")
            {              
                var Name = textBox1.Text; //ФИО
                var Date = dateTimePicker1.Value.ToShortDateString(); //Дата выдачи
                var Group = textBox2.Text; //Группа
                var Kyrs = textBox3.Text; //Курс
                var wordApp = new Word.Application();
                try
                {
                    var wordDocument = wordApp.Documents.Open(TemplateFileName1);

                    ReplaceWord("{Name}", Name, wordDocument);
                    ReplaceWord("{Date}", Date, wordDocument);
                    ReplaceWord("{Group}", Group, wordDocument);
                    ReplaceWord("{Kyrs}", Kyrs, wordDocument);

                    wordApp.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Ошибка в заполнении");

                }
            }

            if (comboBox1.Text == "Справка №2")
            {
                var Name = textBox1.Text; //ФИО
                var Date = dateTimePicker1.Value.ToShortDateString(); //Дата выдачи
                var Group = textBox2.Text; //Группа
                var Kyrs = textBox3.Text; //Курс
                var wordApp = new Word.Application();
                try
                {
                    var wordDocument = wordApp.Documents.Open(TemplateFileName2);

                    ReplaceWord("{Name}", Name, wordDocument);
                    ReplaceWord("{Date}", Date, wordDocument);
                    ReplaceWord("{Group}", Group, wordDocument);
                    ReplaceWord("{Kyrs}", Kyrs, wordDocument);

                    wordApp.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Ошибка в заполнении");

                }
            }

            if (comboBox1.Text == "Справка №3")
            {
                var Name = textBox1.Text; //ФИО
                var Date = dateTimePicker1.Value.ToShortDateString(); //Дата выдачи
                var Group = textBox2.Text; //Группа
                var Kyrs = textBox3.Text; //Курс
                var wordApp = new Word.Application();
                try
                {
                    var wordDocument = wordApp.Documents.Open(TemplateFileName3);

                    ReplaceWord("{Name}", Name, wordDocument);
                    ReplaceWord("{Date}", Date, wordDocument);
                    ReplaceWord("{Group}", Group, wordDocument);
                    ReplaceWord("{Kyrs}", Kyrs, wordDocument);

                    wordApp.Visible = true;
                }
                catch
                {
                    MessageBox.Show("Ошибка в заполнении");

                }
            }




        }

        private void ReplaceWord(string stubToPeplace, string text, Word.Document wordDocument)
        {
            var range = wordDocument.Content;
            range.Find.ClearFormatting();
            range.Find.Execute(FindText: stubToPeplace, ReplaceWith: text);
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void GDU_Load(object sender, EventArgs e)
        {
            GTable();
            ProcessStartInfo si = new ProcessStartInfo();
            si.FileName = @"D:\GD\GD\documents\Справка1.dotx";
            si.UseShellExecute = true;

            Process.Start(si);

            comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var selectedRow = (sender as DataGridView).SelectedRows[0];
            comboBox1.SelectedItem = selectedRow.Cells[0].Value.ToString();
            textBox1.Text = selectedRow.Cells[2].Value.ToString();
            textBox2.Text = selectedRow.Cells[3].Value.ToString();
            textBox3.Text = selectedRow.Cells[4].Value.ToString();
            textBox4.Text = selectedRow.Cells[1].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "docx files (*.docx)|*.docx|All files (*.docx*)|*.docx*";
                    openFileDialog.ShowDialog();
                    file = openFileDialog.FileName;
                    string polych;
                    polych = textBox4.Text;
                    MailAddress from = new MailAddress("nngajcu@gmail.com", "Андрей");
                    MailAddress to = new MailAddress(polych);
                    System.Net.Mail.MailMessage m = new System.Net.Mail.MailMessage(from, to);
                    m.Subject = "Справка";
                    m.Body = "";
                    Attachment attach = new Attachment(file, MediaTypeNames.Application.Octet);
                    m.Attachments.Add(attach);
                    m.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                    smtp.Credentials = new NetworkCredential("nngajcu@gmail.com", "O380550rus");
                    smtp.EnableSsl = true;
                    smtp.Send(m);
                    MessageBox.Show("Письмо отправлено!");
                }
            }
            else
            {
                MessageBox.Show("Заполните почту!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Avtoriz avtoriz = (Avtoriz)Application.OpenForms[0];
            avtoriz.Show();
            this.Close();
        }

        public void GTable()
        {
            using ApplicationContext db = new ApplicationContext();
            dataGridView1.DataSource = db.InformationTos.ToList();
        }
    }
}
