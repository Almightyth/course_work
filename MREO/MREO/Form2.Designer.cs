namespace MREO
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pass_text = new System.Windows.Forms.TextBox();
            this.login_text = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.second_pass = new System.Windows.Forms.TextBox();
            this.sign_up = new System.Windows.Forms.Button();
            this.sign_in = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(169, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Логін:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(170, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Пароль:";
            // 
            // pass_text
            // 
            this.pass_text.Location = new System.Drawing.Point(173, 146);
            this.pass_text.Multiline = true;
            this.pass_text.Name = "pass_text";
            this.pass_text.Size = new System.Drawing.Size(188, 33);
            this.pass_text.TabIndex = 5;
            // 
            // login_text
            // 
            this.login_text.Location = new System.Drawing.Point(173, 60);
            this.login_text.Multiline = true;
            this.login_text.Name = "login_text";
            this.login_text.Size = new System.Drawing.Size(188, 33);
            this.login_text.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F);
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(170, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(166, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Повторіть пароль:";
            // 
            // second_pass
            // 
            this.second_pass.Location = new System.Drawing.Point(173, 238);
            this.second_pass.Multiline = true;
            this.second_pass.Name = "second_pass";
            this.second_pass.Size = new System.Drawing.Size(188, 33);
            this.second_pass.TabIndex = 8;
            // 
            // sign_up
            // 
            this.sign_up.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sign_up.Location = new System.Drawing.Point(135, 302);
            this.sign_up.Name = "sign_up";
            this.sign_up.Size = new System.Drawing.Size(139, 50);
            this.sign_up.TabIndex = 10;
            this.sign_up.Text = "Реєстрація";
            this.sign_up.UseVisualStyleBackColor = true;
            this.sign_up.Click += new System.EventHandler(this.sign_up_Click_1);
            // 
            // sign_in
            // 
            this.sign_in.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.sign_in.Location = new System.Drawing.Point(308, 302);
            this.sign_in.Name = "sign_in";
            this.sign_in.Size = new System.Drawing.Size(139, 50);
            this.sign_in.TabIndex = 11;
            this.sign_in.Text = "Авторизуватись";
            this.sign_in.UseVisualStyleBackColor = true;
            this.sign_in.Click += new System.EventHandler(this.sign_in_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 376);
            this.Controls.Add(this.sign_in);
            this.Controls.Add(this.sign_up);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.second_pass);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pass_text);
            this.Controls.Add(this.login_text);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Реєстрація";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pass_text;
        private System.Windows.Forms.TextBox login_text;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox second_pass;
        private System.Windows.Forms.Button sign_up;
        private System.Windows.Forms.Button sign_in;
    }
}