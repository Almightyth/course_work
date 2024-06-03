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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace MREO
{
    public partial class Form5 : Form
    {
        private OleDbConnection connection;
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Курсач\MREO\MREO\MREO.accdb";
        private string login;
        public Form5(string login)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.login = login;
            FillUserData(login);
            LoadData();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mREODataSet.Учні_автошколи". При необходимости она может быть перемещена или удалена.
            this.учні_автошколиTableAdapter.Fill(this.mREODataSet.Учні_автошколи);

        }
        private void LoadData()
        {
            try
            {
                using (OleDbDataAdapter lostItemsAdapter = new OleDbDataAdapter("SELECT * FROM [Учні автошколи]", connectionString))
                {
                    DataTable lostItemsTable = new DataTable();
                    lostItemsAdapter.Fill(lostItemsTable);
                    dataGridView1.DataSource = lostItemsTable;

                    // Перевірка наявності стовпця "Код" і приховання його
                    if (dataGridView1.Columns.Contains("Код"))
                    {
                        dataGridView1.Columns["Код"].Visible = false;
                    }

                    // Встановлення автоматичного розширення стовпців для всіх DataGridView
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
        private void FillUserData(string login)
        {
            try
            {
                using (connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT [Ім'я], [Прізвище], [По батькові], [Номер телефону], [Номер паспорту], [Назва автошколи] FROM [База клієнтів] WHERE [Логін] = @Login";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", login);
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            name.Text = reader.GetString(0); // Ім'я
                            secondname.Text = reader.GetString(1); // Прізвище
                            surname.Text = reader.GetString(2); // По батькові
                            number_phone.Text = reader.GetString(3); // Номер телефону
                            number_password.Text = reader.GetString(4); // Номер паспорту
                                                                 //textBox6.Text = reader.GetString(5); // Назва автошколи (зберігається в змінній, але не відображається)
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        void FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }
        private void exit_page4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.FormClosed += new FormClosedEventHandler(FormClosed);
            form1.Show();
            this.Hide();
        }

        private void edit_profile_Click(object sender, EventArgs e)
        {
            // Перевірка формату номера телефону
            string phoneNumber = number_phone.Text;
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^(?:\+?380)?(?:\d{9})$"))
            {
                MessageBox.Show("Невірний формат номера телефону. Номер повинен бути у форматі +380123456789, 380123456789 або 0123456789", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Перевірка формату номера паспорту
            string passportNumber = number_password.Text;
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

                    // Оновлення даних у таблиці "База клієнтів"
                    string updateQuery = "UPDATE [База клієнтів] SET [Ім'я] = @FirstName, [Прізвище] = @LastName, [По батькові] = @MiddleName, [Номер телефону] = @PhoneNumber, [Номер паспорту] = @PassportNumber WHERE [Логін] = @Login";
                    OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@FirstName", name.Text);
                    updateCommand.Parameters.AddWithValue("@LastName", secondname.Text);
                    updateCommand.Parameters.AddWithValue("@MiddleName", surname.Text);
                    updateCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    updateCommand.Parameters.AddWithValue("@PassportNumber", passportNumber);
                    updateCommand.Parameters.AddWithValue("@Login", login);
                    updateCommand.ExecuteNonQuery();

                    MessageBox.Show("Профіль успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void create_request_Click(object sender, EventArgs e)
        {
            // Перевірка наявності значень в обов'язкових полях
            if (string.IsNullOrWhiteSpace(secondname.Text) || string.IsNullOrWhiteSpace(name.Text) || string.IsNullOrWhiteSpace(surname.Text) ||
                string.IsNullOrWhiteSpace(number_phone.Text) || string.IsNullOrWhiteSpace(number_password.Text) || string.IsNullOrWhiteSpace(dateTimePicker2.Text) || comboBox2.SelectedItem == null)
            {
                MessageBox.Show("Будь ласка, заповніть усі обов'язкові поля", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Формування ПІБ учня з трьох відповідних полів
            string fullName = $"{secondname.Text} {name.Text} {surname.Text}";

            // Перевірка формату номера телефону
            string phoneNumber = number_phone.Text;
            if (!System.Text.RegularExpressions.Regex.IsMatch(phoneNumber, @"^(?:\+?380)?(?:\d{9})$"))
            {
                MessageBox.Show("Невірний формат номера телефону. Номер повинен бути у форматі +380123456789, 380123456789 або 0123456789", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Перевірка формату номера паспорту
            string passportNumber = number_password.Text;
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

                    // Перевірка наявності записів у таблицях "Учні автошколи" або "Заявки на навчання"
                    string checkQuery = "SELECT COUNT(*) FROM [Учні автошколи] WHERE [ПІБ учня] = @FullName " +
                                        "UNION ALL " +
                                        "SELECT COUNT(*) FROM [Заявки на навчання] WHERE [Прізвище] = @SecondName AND [Ім'я] = @FirstName AND [По батькові] = @MiddleName";
                    OleDbCommand checkCommand = new OleDbCommand(checkQuery, connection);
                    checkCommand.Parameters.AddWithValue("@FullName", fullName);
                    checkCommand.Parameters.AddWithValue("@SecondName", secondname.Text);
                    checkCommand.Parameters.AddWithValue("@FirstName", name.Text);
                    checkCommand.Parameters.AddWithValue("@MiddleName", surname.Text);

                    int existingRecords = 0;
                    using (OleDbDataReader reader = checkCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            existingRecords += reader.GetInt32(0);
                        }
                    }

                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Ви вже надіслали заявку на навчання, очікуйте на підтвердження!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Додавання запису до таблиці "Заявки на навчання"
                    string insertQuery1 = "INSERT INTO [Заявки на навчання] ([Прізвище], [Ім'я], [По батькові], [Номер телефону], [Номер паспорту], [Статус]) VALUES (@LastName, @FirstName, @MiddleName, @PhoneNumber, @PassportNumber, 'Очікує підтвердження')";
                    OleDbCommand insertCommand1 = new OleDbCommand(insertQuery1, connection);
                    insertCommand1.Parameters.AddWithValue("@LastName", secondname.Text);
                    insertCommand1.Parameters.AddWithValue("@FirstName", name.Text);
                    insertCommand1.Parameters.AddWithValue("@MiddleName", surname.Text);
                    insertCommand1.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    insertCommand1.Parameters.AddWithValue("@PassportNumber", passportNumber);
                    insertCommand1.ExecuteNonQuery();

                    // Отримання значення для поля "ПІБ інструктора"
                    string instructorFullName = comboBox2.SelectedItem.ToString();

                    // Отримання значення для поля "Назва автошколи" з бази даних
                    string autoSchoolName = string.Empty;
                    string query = "SELECT [Назва автошколи] FROM [База клієнтів] WHERE [Логін] = @Login";
                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("@Login", login);
                    autoSchoolName = (string)command.ExecuteScalar();

                    // Додавання запису до таблиці "Учні автошколи"
                    string insertQuery2 = "INSERT INTO [Учні автошколи] ([Назва автошколи], [Дата початку навчання], [Дата закінчення навчання], [ПІБ учня], [ПІБ інструктора], [Статус]) VALUES (@AutoSchool, @StartDate, @EndDate, @FullName, @InstructorFullName, 'Очікує підтвердження')";
                    OleDbCommand insertCommand2 = new OleDbCommand(insertQuery2, connection);
                    insertCommand2.Parameters.AddWithValue("@AutoSchool", autoSchoolName);
                    insertCommand2.Parameters.AddWithValue("@StartDate", dateTimePicker2.Value.ToShortDateString());
                    insertCommand2.Parameters.AddWithValue("@EndDate", dateTimePicker2.Value.AddMonths(3).ToShortDateString()); // Припустимо, що навчання триває 3 місяці
                    insertCommand2.Parameters.AddWithValue("@FullName", fullName);
                    insertCommand2.Parameters.AddWithValue("@InstructorFullName", instructorFullName);
                    insertCommand2.ExecuteNonQuery();

                    MessageBox.Show("Заявку на навчання створено успішно", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void update_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void search_page1_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Створення запиту для пошуку
                    string query = "SELECT * FROM [Учні автошколи] WHERE 1=1";

                    if (!string.IsNullOrEmpty(comboBox1.Text))
                    {
                        query += " AND [Назва автошколи] = @AutoSchoolName";
                    }

                    DateTime startDate;
                    bool isDateValid = DateTime.TryParse(data_start.Text, out startDate);
                    if (isDateValid)
                    {
                        query += " AND [Дата початку навчання] = @StartDate";
                    }

                    if (!string.IsNullOrEmpty(pib_studen.Text))
                    {
                        query += " AND [ПІБ учня] LIKE @StudentName";
                    }

                    if (!string.IsNullOrEmpty(comboBox3.Text))
                    {
                        query += " AND [ПІБ інструктора] = @InstructorName";
                    }

                    OleDbCommand command = new OleDbCommand(query, connection);

                    if (!string.IsNullOrEmpty(comboBox1.Text))
                    {
                        command.Parameters.AddWithValue("@AutoSchoolName", comboBox1.Text);
                    }

                    if (isDateValid)
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.ToShortDateString());
                    }

                    if (!string.IsNullOrEmpty(pib_studen.Text))
                    {
                        command.Parameters.AddWithValue("@StudentName", "%" + pib_studen.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(comboBox3.Text))
                    {
                        command.Parameters.AddWithValue("@InstructorName", comboBox3.Text);
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable searchResultsTable = new DataTable();
                    adapter.Fill(searchResultsTable);
                    dataGridView1.DataSource = searchResultsTable;

                    // Перевірка наявності стовпця "Код" і приховання його
                    if (dataGridView1.Columns.Contains("Код"))
                    {
                        dataGridView1.Columns["Код"].Visible = false;
                    }

                    // Встановлення автоматичного розширення стовпців для всіх DataGridView
                    dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_profile_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ви точно хочете видалити свій аккаунт?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();

                        // Отримання ПІБ клієнта для пошуку в інших таблицях
                        string query = "SELECT [Прізвище], [Ім'я], [По батькові] FROM [База клієнтів] WHERE [Логін] = @Login";
                        OleDbCommand command = new OleDbCommand(query, connection);
                        command.Parameters.AddWithValue("@Login", login);

                        OleDbDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string lastName = reader["Прізвище"].ToString();
                            string firstName = reader["Ім'я"].ToString();
                            string middleName = reader["По батькові"].ToString();
                            string fullName = $"{lastName} {firstName} {middleName}";

                            reader.Close();

                            // Отримання даних для архіву з таблиці "Учні автошколи"
                            string studentDataQuery = "SELECT [Назва автошколи], [ПІБ інструктора], [Дата початку навчання], [Дата закінчення навчання], [Статус] FROM [Учні автошколи] WHERE [ПІБ учня] = @FullName";
                            OleDbCommand studentDataCommand = new OleDbCommand(studentDataQuery, connection);
                            studentDataCommand.Parameters.AddWithValue("@FullName", fullName);

                            OleDbDataReader studentDataReader = studentDataCommand.ExecuteReader();
                            if (studentDataReader.Read())
                            {
                                string autoSchoolName = studentDataReader["Назва автошколи"].ToString();
                                string instructorFullName = studentDataReader["ПІБ інструктора"].ToString();
                                string startDate = studentDataReader["Дата початку навчання"].ToString();
                                string endDate = studentDataReader["Дата закінчення навчання"].ToString();
                                string status = studentDataReader["Статус"].ToString();

                                studentDataReader.Close();

                                // Змінюємо формат дати закінчення навчання на дд.мм.рр
                                endDate = DateTime.Parse(endDate).ToString("dd.MM.yyyy");

                                // Отримання номеру паспорту з таблиці "Заявки на навчання"
                                string passportNumberQuery = "SELECT [Номер паспорту] FROM [Заявки на навчання] WHERE [Прізвище] = @LastName AND [Ім'я] = @FirstName AND [По батькові] = @MiddleName";
                                OleDbCommand passportNumberCommand = new OleDbCommand(passportNumberQuery, connection);
                                passportNumberCommand.Parameters.AddWithValue("@LastName", lastName);
                                passportNumberCommand.Parameters.AddWithValue("@FirstName", firstName);
                                passportNumberCommand.Parameters.AddWithValue("@MiddleName", middleName);

                                string passportNumber = passportNumberCommand.ExecuteScalar()?.ToString();

                                if (!string.IsNullOrEmpty(passportNumber))
                                {
                                    // Видалення відповідних записів з таблиці "Заявки на навчання"
                                    string deleteApplicationQuery = "DELETE FROM [Заявки на навчання] WHERE [Прізвище] = @LastName AND [Ім'я] = @FirstName AND [По батькові] = @MiddleName";
                                    OleDbCommand deleteApplicationCommand = new OleDbCommand(deleteApplicationQuery, connection);
                                    deleteApplicationCommand.Parameters.AddWithValue("@LastName", lastName);
                                    deleteApplicationCommand.Parameters.AddWithValue("@FirstName", firstName);
                                    deleteApplicationCommand.Parameters.AddWithValue("@MiddleName", middleName);
                                    deleteApplicationCommand.ExecuteNonQuery();

                                    // Визначення результатів іспитів
                                    string resultTheory = "Іспит не складено";
                                    string resultPractice = "Іспит не складено";
                                    string driverLicenseNumber = "-";

                                    if (status == "Очікує підтвердження")
                                    {
                                        resultTheory = "Іспит не складено";
                                        resultPractice = "Іспит не складено";
                                    }
                                    else if (status == "Складено теоритичний іспит")
                                    {
                                        resultTheory = "Іспит складено";
                                    }
                                    else if (status == "Практичний іспит не складено")
                                    {
                                        resultTheory = "Іспит складено";
                                    }
                                    else if (status == "Видано посвідчення водія")
                                    {
                                        resultTheory = "Іспит складено";
                                        resultPractice = "Іспит складено";
                                        driverLicenseNumber = GenerateDriverLicenseNumber();
                                    }

                                    // Додавання запису до таблиці "Архів іспитів"
                                    string insertArchiveQuery = "INSERT INTO [Архів іспитів] ([ПІБ учня], [Номер паспорту учня], [Назва автошколи], [ПІБ інструктора], [Дата початку навчання], [Дата закінчення навчання], [Результат теоритичного іспиту], [Результат практичного іспиту], [Номер водійського посвідчення]) VALUES (@FullName, @PassportNumber, @AutoSchoolName, @InstructorFullName, @StartDate, @EndDate, @ResultTheory, @ResultPractice, @DriverLicenseNumber)";
                                    OleDbCommand insertArchiveCommand = new OleDbCommand(insertArchiveQuery, connection);
                                    insertArchiveCommand.Parameters.AddWithValue("@FullName", fullName);
                                    insertArchiveCommand.Parameters.AddWithValue("@PassportNumber", passportNumber);
                                    insertArchiveCommand.Parameters.AddWithValue("@AutoSchoolName", autoSchoolName);
                                    insertArchiveCommand.Parameters.AddWithValue("@InstructorFullName", instructorFullName);
                                    insertArchiveCommand.Parameters.AddWithValue("@StartDate", startDate);
                                    insertArchiveCommand.Parameters.AddWithValue("@EndDate", endDate);
                                    insertArchiveCommand.Parameters.AddWithValue("@ResultTheory", resultTheory);
                                    insertArchiveCommand.Parameters.AddWithValue("@ResultPractice", resultPractice);
                                    insertArchiveCommand.Parameters.AddWithValue("@DriverLicenseNumber", driverLicenseNumber);
                                    insertArchiveCommand.ExecuteNonQuery();
                                }

                                // Видалення запису з таблиці "Учні автошколи"
                                string deleteStudentQuery = "DELETE FROM [Учні автошколи] WHERE [ПІБ учня] = @FullName";
                                OleDbCommand deleteStudentCommand = new OleDbCommand(deleteStudentQuery, connection);
                                deleteStudentCommand.Parameters.AddWithValue("@FullName", fullName);
                                deleteStudentCommand.ExecuteNonQuery();

                                // Видалення запису з таблиці "База клієнтів"
                                string deleteClientQuery = "DELETE FROM [База клієнтів] WHERE [Логін] = @Login";
                                OleDbCommand deleteClientCommand = new OleDbCommand(deleteClientQuery, connection);
                                deleteClientCommand.Parameters.AddWithValue("@Login", login);
                                deleteClientCommand.ExecuteNonQuery();

                                MessageBox.Show("Акаунт успішно видалено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Form1 form1 = new Form1();
                                form1.FormClosed += new FormClosedEventHandler(FormClosed);
                                form1.Show();
                                this.Hide();
                            }
                            else
                            {
                                reader.Close();

                                // Видалення запису з таблиці "База клієнтів" якщо відповідних записів немає в інших таблицях
                                string deleteClientQuery = "DELETE FROM [База клієнтів] WHERE [Логін] = @Login";
                                OleDbCommand deleteClientCommand = new OleDbCommand(deleteClientQuery, connection);
                                deleteClientCommand.Parameters.AddWithValue("@Login", login);
                                deleteClientCommand.ExecuteNonQuery();

                                MessageBox.Show("Акаунт успішно видалено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                Form1 form1 = new Form1();
                                form1.FormClosed += new FormClosedEventHandler(FormClosed);
                                form1.Show();
                                this.Hide();
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


        private string GenerateDriverLicenseNumber()
        {
            Random random = new Random();
            string letters = "АБВГДЕЄЖЗИКЛМНОПРСТУФХЦЧШЩЮЯ";
            string driverLicenseNumber = new string(Enumerable.Repeat(letters, 3).Select(s => s[random.Next(s.Length)]).ToArray()) + random.Next(100000, 999999).ToString();
            return driverLicenseNumber;
        }
    }
}
