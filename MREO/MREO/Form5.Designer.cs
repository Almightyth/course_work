namespace MREO
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form5));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.update = new System.Windows.Forms.Button();
            this.create_request = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.data_start = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pib_studen = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.exit_page4 = new System.Windows.Forms.Button();
            this.delete_profile = new System.Windows.Forms.Button();
            this.edit_profile = new System.Windows.Forms.Button();
            this.number_password = new System.Windows.Forms.TextBox();
            this.number_phone = new System.Windows.Forms.TextBox();
            this.surname = new System.Windows.Forms.TextBox();
            this.secondname = new System.Windows.Forms.TextBox();
            this.name = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.учніАвтошколиBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mREODataSet = new MREO.MREODataSet();
            this.учні_автошколиTableAdapter = new MREO.MREODataSetTableAdapters.Учні_автошколиTableAdapter();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.учніАвтошколиBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mREODataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(1, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1260, 812);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox3);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.update);
            this.tabPage1.Controls.Add(this.create_request);
            this.tabPage1.Controls.Add(this.comboBox2);
            this.tabPage1.Controls.Add(this.dateTimePicker2);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.search);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.data_start);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.pib_studen);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1252, 783);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Учні автошколи";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Антоненко В. М.",
            "Микитюк Є. С.",
            "Гнатюк. Л. Ф.",
            "Петренко Д. Ф.",
            "Сергієнко Л. В.",
            "Броварчук А. Ф.",
            "Мірошниченко О. В.",
            "Павлюк В. Р.",
            "Антоненко Т. Р.",
            "Шевчук О. Й."});
            this.comboBox3.Location = new System.Drawing.Point(380, 565);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(210, 24);
            this.comboBox3.TabIndex = 44;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "АвтоМайстер",
            "ДрайвМейкер",
            "Автошкола Профі",
            "Водійська Школа Експерт",
            "МайстерПередач"});
            this.comboBox1.Location = new System.Drawing.Point(91, 471);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(210, 24);
            this.comboBox1.TabIndex = 43;
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(380, 637);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(127, 65);
            this.update.TabIndex = 27;
            this.update.Text = "Оновити список";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // create_request
            // 
            this.create_request.Location = new System.Drawing.Point(856, 704);
            this.create_request.Name = "create_request";
            this.create_request.Size = new System.Drawing.Size(127, 65);
            this.create_request.TabIndex = 26;
            this.create_request.Text = "Створити запит";
            this.create_request.UseVisualStyleBackColor = true;
            this.create_request.Click += new System.EventHandler(this.create_request_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Антоненко В. М.",
            "Микитюк Є. С.",
            "Гнатюк. Л. Ф.",
            "Петренко Д. Ф.",
            "Сергієнко Л. В.",
            "Броварчук А. Ф.",
            "Мірошниченко О. В.",
            "Павлюк В. Р.",
            "Антоненко Т. Р.",
            "Шевчук О. Й."});
            this.comboBox2.Location = new System.Drawing.Point(789, 658);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(259, 24);
            this.comboBox2.TabIndex = 25;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(789, 540);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(259, 22);
            this.dateTimePicker2.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(707, 601);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(246, 40);
            this.label8.TabIndex = 23;
            this.label8.Text = "Оберіть інструктора з яким \r\nбажаєте навчатись:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(707, 484);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(348, 20);
            this.label9.TabIndex = 22;
            this.label9.Text = "Оберіть бажану дату початку навчання:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label10.Location = new System.Drawing.Point(706, 421);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(465, 25);
            this.label10.TabIndex = 21;
            this.label10.Text = "Форма подання запиту на реестрацію навчання:";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(168, 637);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(127, 65);
            this.search.TabIndex = 13;
            this.search.Text = "Фільтрувати пошук";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_page1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(376, 529);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "П.І.Б. інструктора:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(376, 424);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(214, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата початку навчання:";
            // 
            // data_start
            // 
            this.data_start.Location = new System.Drawing.Point(380, 462);
            this.data_start.Multiline = true;
            this.data_start.Name = "data_start";
            this.data_start.Size = new System.Drawing.Size(210, 33);
            this.data_start.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(87, 518);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "П.І.Б. учня:";
            // 
            // pib_studen
            // 
            this.pib_studen.Location = new System.Drawing.Point(91, 556);
            this.pib_studen.Multiline = true;
            this.pib_studen.Name = "pib_studen";
            this.pib_studen.Size = new System.Drawing.Size(204, 33);
            this.pib_studen.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(87, 435);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Назва автошколи:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1252, 359);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.exit_page4);
            this.tabPage4.Controls.Add(this.delete_profile);
            this.tabPage4.Controls.Add(this.edit_profile);
            this.tabPage4.Controls.Add(this.number_password);
            this.tabPage4.Controls.Add(this.number_phone);
            this.tabPage4.Controls.Add(this.surname);
            this.tabPage4.Controls.Add(this.secondname);
            this.tabPage4.Controls.Add(this.name);
            this.tabPage4.Controls.Add(this.label23);
            this.tabPage4.Controls.Add(this.label22);
            this.tabPage4.Controls.Add(this.label21);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1252, 783);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Особистий кабінет";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // exit_page4
            // 
            this.exit_page4.Location = new System.Drawing.Point(651, 368);
            this.exit_page4.Name = "exit_page4";
            this.exit_page4.Size = new System.Drawing.Size(148, 62);
            this.exit_page4.TabIndex = 31;
            this.exit_page4.Text = "Вийти з профілю";
            this.exit_page4.UseVisualStyleBackColor = true;
            this.exit_page4.Click += new System.EventHandler(this.exit_page4_Click);
            // 
            // delete_profile
            // 
            this.delete_profile.Location = new System.Drawing.Point(537, 467);
            this.delete_profile.Name = "delete_profile";
            this.delete_profile.Size = new System.Drawing.Size(148, 62);
            this.delete_profile.TabIndex = 30;
            this.delete_profile.Text = "Видалити профіль";
            this.delete_profile.UseVisualStyleBackColor = true;
            this.delete_profile.Click += new System.EventHandler(this.delete_profile_Click);
            // 
            // edit_profile
            // 
            this.edit_profile.Location = new System.Drawing.Point(444, 368);
            this.edit_profile.Name = "edit_profile";
            this.edit_profile.Size = new System.Drawing.Size(148, 62);
            this.edit_profile.TabIndex = 29;
            this.edit_profile.Text = "Редагувати профіль";
            this.edit_profile.UseVisualStyleBackColor = true;
            this.edit_profile.Click += new System.EventHandler(this.edit_profile_Click);
            // 
            // number_password
            // 
            this.number_password.Location = new System.Drawing.Point(480, 282);
            this.number_password.Multiline = true;
            this.number_password.Name = "number_password";
            this.number_password.Size = new System.Drawing.Size(291, 33);
            this.number_password.TabIndex = 28;
            // 
            // number_phone
            // 
            this.number_phone.Location = new System.Drawing.Point(480, 225);
            this.number_phone.Multiline = true;
            this.number_phone.Name = "number_phone";
            this.number_phone.Size = new System.Drawing.Size(291, 33);
            this.number_phone.TabIndex = 27;
            // 
            // surname
            // 
            this.surname.Location = new System.Drawing.Point(480, 174);
            this.surname.Multiline = true;
            this.surname.Name = "surname";
            this.surname.Size = new System.Drawing.Size(291, 33);
            this.surname.TabIndex = 26;
            // 
            // secondname
            // 
            this.secondname.Location = new System.Drawing.Point(480, 120);
            this.secondname.Multiline = true;
            this.secondname.Name = "secondname";
            this.secondname.Size = new System.Drawing.Size(291, 33);
            this.secondname.TabIndex = 25;
            // 
            // name
            // 
            this.name.Location = new System.Drawing.Point(480, 66);
            this.name.Multiline = true;
            this.name.Name = "name";
            this.name.Size = new System.Drawing.Size(291, 33);
            this.name.TabIndex = 24;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label23.Location = new System.Drawing.Point(294, 282);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(171, 25);
            this.label23.TabIndex = 23;
            this.label23.Text = "Номер паспорту:";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label22.Location = new System.Drawing.Point(283, 221);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(182, 25);
            this.label22.TabIndex = 22;
            this.label22.Text = "Номер телефону:";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label21.Location = new System.Drawing.Point(339, 174);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(126, 25);
            this.label21.TabIndex = 21;
            this.label21.Text = "По батькові:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label18.Location = new System.Drawing.Point(358, 120);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(107, 25);
            this.label18.TabIndex = 20;
            this.label18.Text = "Прізвище:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(410, 66);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(55, 25);
            this.label17.TabIndex = 19;
            this.label17.Text = "Ім\'я:";
            // 
            // учніАвтошколиBindingSource
            // 
            this.учніАвтошколиBindingSource.DataMember = "Учні автошколи";
            this.учніАвтошколиBindingSource.DataSource = this.mREODataSet;
            // 
            // mREODataSet
            // 
            this.mREODataSet.DataSetName = "MREODataSet";
            this.mREODataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // учні_автошколиTableAdapter
            // 
            this.учні_автошколиTableAdapter.ClearBeforeFill = true;
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1250, 805);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form5";
            this.Text = "Інформація про учня МРЕВ";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.учніАвтошколиBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mREODataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox data_start;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox pib_studen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button exit_page4;
        private System.Windows.Forms.Button delete_profile;
        private System.Windows.Forms.Button edit_profile;
        private System.Windows.Forms.TextBox number_password;
        private System.Windows.Forms.TextBox number_phone;
        private System.Windows.Forms.TextBox surname;
        private System.Windows.Forms.TextBox secondname;
        private System.Windows.Forms.TextBox name;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private MREODataSet mREODataSet;
        private System.Windows.Forms.BindingSource учніАвтошколиBindingSource;
        private MREODataSetTableAdapters.Учні_автошколиTableAdapter учні_автошколиTableAdapter;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button create_request;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}