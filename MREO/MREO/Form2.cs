using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace MREO
{
    public partial class Form2 : Form
    {
        private OleDbConnection connection;
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Курсач\MREO\MREO\MREO.accdb";

        public Form2()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void sign_in_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.FormClosed += new FormClosedEventHandler(form1_FormClosed);
            form1.Show();
            this.Hide();
        }

        private void sign_up_Click_1(object sender, EventArgs e)
        {
            string login = login_text.Text;
            string password = pass_text.Text;
            string confirmPassword = second_pass.Text;

            // Перевірка, чи паролі співпадають
            if (password != confirmPassword)
            {
                MessageBox.Show("Паролі не співпадають", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Перевірка довжини паролю
            if (password.Length < 6)
            {
                MessageBox.Show("Пароль повинен містити принаймні 6 символів", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Перевірка, чи логін вже існує у базі даних
                    string checkQuery = "SELECT COUNT(*) FROM [База клієнтів] WHERE [Логін] = @Login";
                    OleDbCommand checkCommand = new OleDbCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@Login", login);
                    int userCount = (int)checkCommand.ExecuteScalar();

                    if (userCount > 0)
                    {
                        MessageBox.Show("Користувач з таким логіном вже існує. Будь ласка, виберіть інший логін", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Вставка нового користувача, якщо всі перевірки пройшли успішно
                    string insertQuery = "INSERT INTO [База клієнтів] ([Логін], [Пароль]) VALUES (@Login, @Password)";
                    OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@Login", login);
                    insertCommand.Parameters.AddWithValue("@Password", password);
                    int rowsAffected = insertCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Ви успішно зареєструвалися", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Не вдалося зареєструватися", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
    }
}