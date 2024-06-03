using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Globalization;

namespace MREO
{
    public partial class Form3 : Form
    {
        private OleDbConnection connection;
        private const string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Курсач\MREO\MREO\MREO.accdb";
        public Form3()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadData();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mREODataSet2.Архів_іспитів". При необходимости она может быть перемещена или удалена.
            this.архів_іспитівTableAdapter.Fill(this.mREODataSet2.Архів_іспитів);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mREODataSet2.Заявки_на_навчання". При необходимости она может быть перемещена или удалена.
            this.заявки_на_навчанняTableAdapter.Fill(this.mREODataSet2.Заявки_на_навчання);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mREODataSet2.Учні_автошколи". При необходимости она может быть перемещена или удалена.
            this.учні_автошколиTableAdapter.Fill(this.mREODataSet2.Учні_автошколи);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mREODataSet1.Архів_іспитів". При необходимости она может быть перемещена или удалена.
            this.архів_іспитівTableAdapter.Fill(this.mREODataSet1.Архів_іспитів);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mREODataSet.Архів_іспитів". При необходимости она может быть перемещена или удалена.
            this.архів_іспитівTableAdapter.Fill(this.mREODataSet.Архів_іспитів);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "mREODataSet.Заявки_на_навчання". При необходимости она может быть перемещена или удалена.
            this.заявки_на_навчанняTableAdapter.Fill(this.mREODataSet.Заявки_на_навчання);
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
                using (OleDbDataAdapter lostItemsAdapter = new OleDbDataAdapter("SELECT * FROM [Заявки на навчання]", connectionString))
                {
                    DataTable lostItemsTable = new DataTable();
                    lostItemsAdapter.Fill(lostItemsTable);
                    dataGridView2.DataSource = lostItemsTable;

                    // Перевірка наявності стовпця "Код" і приховання його
                    if (dataGridView2.Columns.Contains("Код"))
                    {
                        dataGridView2.Columns["Код"].Visible = false;
                    }

                    // Встановлення автоматичного розширення стовпців для всіх DataGridView
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
                using (OleDbDataAdapter lostItemsAdapter = new OleDbDataAdapter("SELECT * FROM [Архів іспитів]", connectionString))
                {
                    DataTable lostItemsTable = new DataTable();
                    lostItemsAdapter.Fill(lostItemsTable);
                    dataGridView3.DataSource = lostItemsTable;

                    // Перевірка наявності стовпця "Код" і приховання його
                    if (dataGridView3.Columns.Contains("Код"))
                    {
                        dataGridView3.Columns["Код"].Visible = false;
                    }

                    // Встановлення автоматичного розширення стовпців для всіх DataGridView
                    dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
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

        private void search_page1_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Створення запиту для пошуку
                    string query = "SELECT * FROM [Учні автошколи] WHERE 1=1";

                    if (!string.IsNullOrEmpty(comboBox2.Text))
                    {
                        query += " AND [Назва автошколи] = @AutoSchoolName";
                    }

                    DateTime startDate;
                    bool isStartDateValid = DateTime.TryParse(data_start.Text, out startDate);
                    if (isStartDateValid)
                    {
                        query += " AND [Дата початку навчання] = @StartDate";
                    }

                    DateTime endDate;
                    bool isEndDateValid = DateTime.TryParse(date_stop.Text, out endDate);
                    if (isEndDateValid)
                    {
                        query += " AND [Дата закінчення навчання] = @EndDate";
                    }

                    if (!string.IsNullOrEmpty(pib_studen.Text))
                    {
                        query += " AND [ПІБ учня] LIKE @StudentName";
                    }

                    if (!string.IsNullOrEmpty(comboBox3.Text))
                    {
                        query += " AND [ПІБ інструктора] = @InstructorName";
                    }

                    if (!string.IsNullOrEmpty(status.Text))
                    {
                        query += " AND [Статус] = @Status";
                    }

                    OleDbCommand command = new OleDbCommand(query, connection);

                    if (!string.IsNullOrEmpty(comboBox2.Text))
                    {
                        command.Parameters.AddWithValue("@AutoSchoolName", comboBox2.Text);
                    }

                    if (isStartDateValid)
                    {
                        command.Parameters.AddWithValue("@StartDate", startDate.ToShortDateString());
                    }

                    if (isEndDateValid)
                    {
                        command.Parameters.AddWithValue("@EndDate", endDate.ToShortDateString());
                    }

                    if (!string.IsNullOrEmpty(pib_studen.Text))
                    {
                        command.Parameters.AddWithValue("@StudentName", "%" + pib_studen.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(comboBox3.Text))
                    {
                        command.Parameters.AddWithValue("@InstructorName", comboBox3.Text);
                    }

                    if (!string.IsNullOrEmpty(status.Text))
                    {
                        command.Parameters.AddWithValue("@Status", status.Text);
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

        private void edit_page1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Отримання вибраного рядка
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Перевірка введення в поле status
                    if (string.IsNullOrEmpty(status.Text))
                    {
                        MessageBox.Show("Оберіть статус", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Перевірка поточного статусу
                    string currentStatus = selectedRow.Cells["Статус"].Value.ToString();
                    if (currentStatus == "Очікує підтвердження")
                    {
                        MessageBox.Show("Спочатку необхідно підтвердити заявку на навчання!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Отримання значення нового статусу
                    string newStatus = status.Text;

                    // Отримання значення "Код" для ідентифікації запису
                    int recordId = Convert.ToInt32(selectedRow.Cells["Код"].Value);

                    using (connection = new OleDbConnection(connectionString))
                    {
                        connection.Open();

                        // Оновлення статусу у базі даних
                        string updateQuery = "UPDATE [Учні автошколи] SET [Статус] = @Status WHERE [Код] = @RecordId";
                        OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection);
                        updateCommand.Parameters.AddWithValue("@Status", newStatus);
                        updateCommand.Parameters.AddWithValue("@RecordId", recordId);

                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Оновлення значення у DataGridView
                            selectedRow.Cells["Статус"].Value = newStatus;
                            MessageBox.Show("Статус успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Не вдалося оновити статус", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Оберіть рядок для редагування", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_page1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    // Отримання вибраного рядка
                    DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                    // Отримання значення "Код" для ідентифікації запису
                    int recordId = Convert.ToInt32(selectedRow.Cells["Код"].Value);

                    // Отримання значень з обраного рядка
                    string fullName = selectedRow.Cells["ПІБ учня"].Value.ToString();
                    string autoSchoolName = selectedRow.Cells["Назва автошколи"].Value.ToString();
                    string instructorFullName = selectedRow.Cells["ПІБ інструктора"].Value.ToString();
                    string startDate = selectedRow.Cells["Дата початку навчання"].Value.ToString();
                    string endDate = selectedRow.Cells["Дата закінчення навчання"].Value.ToString();
                    string status = selectedRow.Cells["Статус"].Value.ToString();

                    // Змінюємо формат дати закінчення навчання на дд.мм.рр
                    endDate = DateTime.Parse(endDate).ToString("dd.MM.yyyy");

                    // Виведення повідомлення з підтвердженням
                    DialogResult result = MessageBox.Show("Ви точно хочете видалити обраний запис?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();

                            // Отримання номеру паспорту з таблиці "Заявки на навчання"
                            string passportNumberQuery = "SELECT [Номер паспорту] FROM [Заявки на навчання] WHERE [Прізвище] = @LastName AND [Ім'я] = @FirstName AND [По батькові] = @MiddleName";
                            OleDbCommand passportNumberCommand = new OleDbCommand(passportNumberQuery, connection);
                            string[] names = fullName.Split(' ');
                            passportNumberCommand.Parameters.AddWithValue("@LastName", names[0]);
                            passportNumberCommand.Parameters.AddWithValue("@FirstName", names[1]);
                            passportNumberCommand.Parameters.AddWithValue("@MiddleName", names.Length > 2 ? names[2] : "");
                            string passportNumber = passportNumberCommand.ExecuteScalar().ToString();

                            // Видалення запису з таблиці "Учні автошколи"
                            string deleteQuery = "DELETE FROM [Учні автошколи] WHERE [Код] = @RecordId";
                            OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@RecordId", recordId);
                            deleteCommand.ExecuteNonQuery();

                            // Видалення відповідних записів з таблиці "Заявки на навчання"
                            string deleteQuery2 = "DELETE FROM [Заявки на навчання] WHERE [Прізвище] = @LastName AND [Ім'я] = @FirstName AND [По батькові] = @MiddleName";
                            OleDbCommand deleteCommand2 = new OleDbCommand(deleteQuery2, connection);
                            deleteCommand2.Parameters.AddWithValue("@LastName", names[0]);
                            deleteCommand2.Parameters.AddWithValue("@FirstName", names[1]);
                            deleteCommand2.Parameters.AddWithValue("@MiddleName", names.Length > 2 ? names[2] : "");
                            deleteCommand2.ExecuteNonQuery();

                            // Додавання запису до таблиці "Архів іспитів"
                            string resultTheory = "Іспит не складено";
                            string resultPractice = "Іспит не складено";
                            string driverLicenseNumber = "-";

                            if (status == "Складено теоритичний іспит")
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

                            // Видалення рядка з DataGridView
                            dataGridView1.Rows.Remove(selectedRow);

                            MessageBox.Show("Запис успішно видалено та додано до архіву", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadData();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Оберіть рядок для видалення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GenerateDriverLicenseNumber()
        {
            Random random = new Random();
            string letters = "АБВГДЕЄЖЗИКЛМНОПРСТУФХЦЧШЩЮЯ";
            string driverLicenseNumber = new string(Enumerable.Repeat(letters, 3).Select(s => s[random.Next(s.Length)]).ToArray()) + random.Next(100000, 999999).ToString();
            return driverLicenseNumber;
        }

        private void search_page2_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Створення запиту для пошуку
                    string query = "SELECT * FROM [Заявки на навчання] WHERE 1=1";

                    // Перевірка поля ПІБ і додавання умов пошуку для кожного стовпця
                    if (!string.IsNullOrEmpty(pib_page2.Text))
                    {
                        string[] keywords = pib_page2.Text.Split(' ');
                        foreach (string keyword in keywords)
                        {
                            query += " AND ([Прізвище] LIKE @Keyword OR [Ім'я] LIKE @Keyword OR [По батькові] LIKE @Keyword)";
                        }
                    }

                    // Перевірка поля Номер паспорту
                    if (!string.IsNullOrEmpty(number_pass_page2.Text))
                    {
                        query += " AND [Номер паспорту] LIKE @PassportNumber";
                    }

                    // Перевірка поля Номер телефону
                    if (!string.IsNullOrEmpty(number_phone_page2.Text))
                    {
                        query += " AND [Номер телефону] LIKE @PhoneNumber";
                    }

                    // Перевірка поля Статус
                    if (!string.IsNullOrEmpty(comboBox1.Text))
                    {
                        query += " AND [Статус] = @Status";
                    }

                    OleDbCommand command = new OleDbCommand(query, connection);

                    // Додавання параметрів до запиту
                    if (!string.IsNullOrEmpty(pib_page2.Text))
                    {
                        string[] keywords = pib_page2.Text.Split(' ');
                        foreach (string keyword in keywords)
                        {
                            command.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                        }
                    }

                    if (!string.IsNullOrEmpty(number_pass_page2.Text))
                    {
                        command.Parameters.AddWithValue("@PassportNumber", "%" + number_pass_page2.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(number_phone_page2.Text))
                    {
                        command.Parameters.AddWithValue("@PhoneNumber", "%" + number_phone_page2.Text + "%");
                    }

                    if (!string.IsNullOrEmpty(comboBox1.Text))
                    {
                        command.Parameters.AddWithValue("@Status", comboBox1.Text);
                    }

                    OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                    DataTable searchResultsTable = new DataTable();
                    adapter.Fill(searchResultsTable);
                    dataGridView2.DataSource = searchResultsTable;

                    // Перевірка наявності стовпця "Код" і приховання його
                    if (dataGridView2.Columns.Contains("Код"))
                    {
                        dataGridView2.Columns["Код"].Visible = false;
                    }

                    // Встановлення автоматичного розширення стовпців для всіх DataGridView
                    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void edit_page2_Click(object sender, EventArgs e)
        {
            // Перевірка, чи вибрано рядок у dataGridView2
            if (dataGridView2.SelectedRows.Count == 0)
            {
                MessageBox.Show("Оберіть рядок для редагування", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Перевірка, чи вибрано значення у comboBox1
            if (string.IsNullOrEmpty(comboBox1.Text))
            {
                MessageBox.Show("Оберіть статус", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    // Отримання обраного рядка з dataGridView2
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];
                    string selectedLastName = selectedRow.Cells["Прізвище"].Value.ToString();
                    string selectedFirstName = selectedRow.Cells["Ім'я"].Value.ToString();
                    string selectedMiddleName = selectedRow.Cells["По батькові"].Value.ToString();

                    // Оновлення статусу у таблиці "Заявки на навчання"
                    string updateQuery1 = "UPDATE [Заявки на навчання] SET [Статус] = @Status WHERE [Прізвище] = @LastName AND [Ім'я] = @FirstName AND [По батькові] = @MiddleName";
                    OleDbCommand updateCommand1 = new OleDbCommand(updateQuery1, connection);
                    updateCommand1.Parameters.AddWithValue("@Status", comboBox1.Text);
                    updateCommand1.Parameters.AddWithValue("@LastName", selectedLastName);
                    updateCommand1.Parameters.AddWithValue("@FirstName", selectedFirstName);
                    updateCommand1.Parameters.AddWithValue("@MiddleName", selectedMiddleName);
                    updateCommand1.ExecuteNonQuery();

                    // Оновлення статусу у таблиці "Учні автошколи"
                    string fullName = $"{selectedLastName} {selectedFirstName} {selectedMiddleName}";
                    string updateQuery2 = "UPDATE [Учні автошколи] SET [Статус] = @Status WHERE [ПІБ учня] = @FullName";
                    OleDbCommand updateCommand2 = new OleDbCommand(updateQuery2, connection);
                    updateCommand2.Parameters.AddWithValue("@Status", comboBox1.Text);
                    updateCommand2.Parameters.AddWithValue("@FullName", fullName);
                    updateCommand2.ExecuteNonQuery();

                    MessageBox.Show("Статус успішно оновлено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadData(); // Перезавантаження даних у dataGridView2
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void delete_page2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.SelectedRows.Count > 0)
                {
                    // Отримання вибраного рядка
                    DataGridViewRow selectedRow = dataGridView2.SelectedRows[0];

                    // Отримання значення "Код" для ідентифікації запису
                    int recordId = Convert.ToInt32(selectedRow.Cells["Код"].Value);

                    // Виведення повідомлення з підтвердженням
                    DialogResult result = MessageBox.Show("Ви точно хочете видалити обраний запис?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        using (connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();

                            // Видалення запису з бази даних
                            string deleteQuery = "DELETE FROM [Заявки на навчання] WHERE [Код] = @RecordId";
                            OleDbCommand deleteCommand = new OleDbCommand(deleteQuery, connection);
                            deleteCommand.Parameters.AddWithValue("@RecordId", recordId);

                            int rowsAffected = deleteCommand.ExecuteNonQuery();
                            if (rowsAffected > 0)
                            {
                                // Видалення рядка з DataGridView
                                dataGridView2.Rows.Remove(selectedRow);
                                MessageBox.Show("Запис успішно видалено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Не вдалося видалити запис", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Оберіть рядок для видалення", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void search_page3_Click(object sender, EventArgs e)
        {
            try
            {
                using (connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT * FROM [Архів іспитів] WHERE ";
                    List<string> conditions = new List<string>();
                    List<OleDbParameter> parameters = new List<OleDbParameter>();

                    // Додаємо умови для пошуку залежно від заповнених полів
                    if (!string.IsNullOrEmpty(comboBox4.Text))
                    {
                        conditions.Add("[Назва автошколи] = @AutoSchoolName");
                        parameters.Add(new OleDbParameter("@AutoSchoolName", comboBox4.Text));
                    }
                    if (!string.IsNullOrEmpty(comboBox5.Text))
                    {
                        conditions.Add("[ПІБ інструктора] = @InstructorFullName");
                        parameters.Add(new OleDbParameter("@InstructorFullName", comboBox5.Text));
                    }
                    if (!string.IsNullOrEmpty(pib_page3.Text))
                    {
                        conditions.Add("[ПІБ учня] LIKE @StudentFullName");
                        parameters.Add(new OleDbParameter("@StudentFullName", "%" + pib_page3.Text + "%"));
                    }
                    if (!string.IsNullOrEmpty(date_start_page3.Text))
                    {
                        conditions.Add("[Дата початку навчання] = @StartDate");
                        parameters.Add(new OleDbParameter("@StartDate", date_start_page3.Text));
                    }
                    if (!string.IsNullOrEmpty(date_stop_page3.Text))
                    {
                        conditions.Add("[Дата закінчення навчання] = @EndDate");
                        parameters.Add(new OleDbParameter("@EndDate", date_stop_page3.Text));
                    }
                    if (!string.IsNullOrEmpty(password_page3.Text))
                    {
                        if (System.Text.RegularExpressions.Regex.IsMatch(password_page3.Text, @"^\d{9}$") || System.Text.RegularExpressions.Regex.IsMatch(password_page3.Text, @"^[A-Z]{2}\d{6}$"))
                        {
                            conditions.Add("[Номер паспорту учня] = @PassportNumber");
                            parameters.Add(new OleDbParameter("@PassportNumber", password_page3.Text));
                        }
                        else
                        {
                            MessageBox.Show("Невірний формат номера паспорту. Номер повинен бути або 9 цифр, або 2 великі літери латинського алфавіту і потім 6 цифр", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }
                    if (!string.IsNullOrEmpty(comboBox6.Text))
                    {
                        conditions.Add("[Результат теоритичного іспиту] = @ResultTheory");
                        parameters.Add(new OleDbParameter("@ResultTheory", comboBox6.Text));
                    }
                    if (!string.IsNullOrEmpty(comboBox7.Text))
                    {
                        conditions.Add("[Результат практичного іспиту] = @ResultPractice");
                        parameters.Add(new OleDbParameter("@ResultPractice", comboBox7.Text));
                    }
                    if (!string.IsNullOrEmpty(number_passDrive_page3.Text))
                    {
                        conditions.Add("[Номер водійського посвідчення] = @DriverLicenseNumber");
                        parameters.Add(new OleDbParameter("@DriverLicenseNumber", number_passDrive_page3.Text));
                    }

                    // Формуємо кінцевий запит з доданими умовами
                    if (conditions.Count > 0)
                    {
                        query += string.Join(" AND ", conditions);
                        OleDbCommand command = new OleDbCommand(query, connection);
                        command.Parameters.AddRange(parameters.ToArray());

                        OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        // Відображаємо результати у dataGridView3
                        dataGridView3.DataSource = dataTable;
                    }
                    else
                    {
                        MessageBox.Show("Введіть принаймні один параметр для пошуку", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void delete_page3_Click(object sender, EventArgs e)
        {
            // Перевіряємо, чи користувач обрав рядок
            if (dataGridView3.SelectedRows.Count > 0)
            {
                // Отримуємо значення ідентифікатора обраного запису (наприклад, номер рядка)
                int selectedRowId = Convert.ToInt32(dataGridView3.SelectedRows[0].Cells["Код"].Value);

                // Виводимо діалогове вікно для підтвердження видалення
                DialogResult result = MessageBox.Show("Ви дійсно хочете видалити цей запис?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Перевіряємо, чи користувач підтвердив видалення
                if (result == DialogResult.Yes)
                {
                    // Виконуємо SQL запит для видалення запису з бази даних
                    try
                    {
                        using (connection = new OleDbConnection(connectionString))
                        {
                            connection.Open();

                            // Формуємо SQL запит
                            string deleteQuery = "DELETE FROM [Архів іспитів] WHERE [Код] = @Id";

                            // Створюємо команду для виконання SQL запиту
                            using (OleDbCommand command = new OleDbCommand(deleteQuery, connection))
                            {
                                // Додаємо параметри до запиту
                                command.Parameters.AddWithValue("@Id", selectedRowId);

                                // Виконуємо запит
                                int rowsAffected = command.ExecuteNonQuery();

                                // Перевіряємо, чи було успішно видалено хоча б один запис
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Запис успішно видалено", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show("Не вдалося видалити запис", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Помилка при видаленні запису: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Оберіть рядок для видалення", "Попередження", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            LoadData();
        }
    }
}
