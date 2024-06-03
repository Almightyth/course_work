using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MREO
{
    public partial class Form1 : Form
    {
        private string login;
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Курсач\MREO\MREO\MREO.accdb";

        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void sign_up_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.FormClosed += new FormClosedEventHandler(FormClosed);
            form2.Show();
            this.Hide();
        }

        void FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void sign_in_Click(object sender, EventArgs e)
        {
            login = login_text.Text;
            string password = pass_text.Text;

            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM [База клієнтів] WHERE [Логін] = @Login AND [Пароль] = @Password";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", login);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = (int)command.ExecuteScalar();

                    if (count > 0)
                    {
                        // Перевірка, чи є користувач адміністратором
                        if (login == "Admin" && password == "admin")
                        {
                            Form3 form3 = new Form3();
                            form3.FormClosed += new FormClosedEventHandler(FormClosed);
                            form3.Show();
                            this.Hide();
                        }
                        else
                        {
                            // Перевірка наявності записів у всіх стовпцях
                            query = "SELECT [Прізвище], [Ім'я], [По батькові], [Номер паспорту], [Назва автошколи], [Номер телефону] " +
                                    "FROM [База клієнтів] WHERE [Логін] = @Login";
                            command = new OleDbCommand(query, connection);
                            command.Parameters.AddWithValue("@Login", login);
                            using (OleDbDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    bool allFieldsFilled = !reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) &&
                                                           !reader.IsDBNull(3) && !reader.IsDBNull(4) && !reader.IsDBNull(5);

                                    if (allFieldsFilled)
                                    {
                                        Form5 form5 = new Form5(login);
                                        form5.FormClosed += new FormClosedEventHandler(FormClosed);
                                        form5.Show();
                                        this.Hide();
                                    }
                                    else
                                    {
                                        Form4 form4 = new Form4(login); // Передача значення login в конструктор Form4
                                        form4.FormClosed += new FormClosedEventHandler(FormClosed);
                                        form4.Show();
                                        this.Hide();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильний логін або пароль", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}