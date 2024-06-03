using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MREO
{
    public partial class Form4 : Form
    {
        private string login;
        private OleDbConnection connection;
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Курсач\MREO\MREO\MREO.accdb";
        public Form4(string login)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.login = login; // Збереження значення login
        }
        void FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        private void agree_Click(object sender, EventArgs e)
        {
            // Перевірка заповненості полів
            if (string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) ||
                string.IsNullOrWhiteSpace(textBox5.Text) || string.IsNullOrWhiteSpace(textBox6.Text))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Перевірка формату номера телефону
            string phoneNumber = textBox5.Text;
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^(?:\+?38)?\d{10}$"))
            {
                MessageBox.Show("Невірний формат номера телефону. Номер повинен бути у форматі +38XXXXXXXXXX або 38XXXXXXXXXX", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Додати префікс "+38", якщо його немає
            if (!phoneNumber.StartsWith("+"))
            {
                phoneNumber = "+38" + phoneNumber.Substring(phoneNumber.Length - 10);
            }

            // Перевірка формату номера паспорту
            string passportNumber = textBox6.Text;
            if (!System.Text.RegularExpressions.Regex.IsMatch(passportNumber, @"^([A-Z]{2}\d{6}|\d{9})$"))
            {
                MessageBox.Show("Невірний формат номера паспорту. Паспорт повинен бути у форматі 9 цифр або 2 великі латинські літери та 6 цифр після них", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Занесення даних у таблиці "База клієнтів"
                    string insertQuery = "UPDATE [База клієнтів] SET [Назва автошколи] = @AutoSchool, [Ім'я] = @FirstName, [Прізвище] = @LastName, [По батькові] = @MiddleName, [Номер телефону] = @PhoneNumber, [Номер паспорту] = @PassportNumber WHERE [Логін] = @Login";
                    OleDbCommand insertCommand = new OleDbCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@AutoSchool", comboBox1.Text);
                    insertCommand.Parameters.AddWithValue("@FirstName", textBox2.Text);
                    insertCommand.Parameters.AddWithValue("@LastName", textBox3.Text);
                    insertCommand.Parameters.AddWithValue("@MiddleName", textBox4.Text);
                    insertCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    insertCommand.Parameters.AddWithValue("@PassportNumber", passportNumber);
                    insertCommand.Parameters.AddWithValue("@Login", login);
                    insertCommand.ExecuteNonQuery();

                    // Перевірка наявності записів у всіх стовпцях
                    string query = "SELECT [Прізвище], [Ім'я], [По батькові], [Номер паспорту], [Назва автошколи], [Номер телефону] " +
                                    "FROM [База клієнтів] WHERE [Логін] = @Login";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", login);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            bool allFieldsFilled = !reader.IsDBNull(0) && !reader.IsDBNull(1) && !reader.IsDBNull(2) &&
                                                   !reader.IsDBNull(3) && !reader.IsDBNull(4) && !reader.IsDBNull(5);

                            if (allFieldsFilled)
                            {
                                MessageBox.Show("Реєстрація успішно завершена", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                Form5 form5 = new Form5(login);
                                form5.FormClosed += new FormClosedEventHandler(FormClosed);
                                form5.Show();
                                this.Hide();
                            }
                        }
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