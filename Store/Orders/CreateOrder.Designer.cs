namespace Store.Orders
{
    partial class CreateOrder
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
            this.textbox_Firstname = new System.Windows.Forms.TextBox();
            this.textbox_Secondname = new System.Windows.Forms.TextBox();
            this.textbox_Number = new System.Windows.Forms.TextBox();
            this.textBox_Email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button_Save = new System.Windows.Forms.Button();
            this.button_Cancel = new System.Windows.Forms.Button();
            this.textBox_Product = new System.Windows.Forms.TextBox();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Izpulnil = new System.Windows.Forms.TextBox();
            this.textBox_serialNum = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_komplktovka = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_neizpravnost = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox_zabelejki = new System.Windows.Forms.TextBox();
            this.textBox_workDone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textbox_Firstname
            // 
            this.textbox_Firstname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textbox_Firstname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textbox_Firstname.CausesValidation = false;
            this.textbox_Firstname.Location = new System.Drawing.Point(136, 14);
            this.textbox_Firstname.Name = "textbox_Firstname";
            this.textbox_Firstname.Size = new System.Drawing.Size(174, 20);
            this.textbox_Firstname.TabIndex = 0;
            // 
            // textbox_Secondname
            // 
            this.textbox_Secondname.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textbox_Secondname.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textbox_Secondname.CausesValidation = false;
            this.textbox_Secondname.Location = new System.Drawing.Point(136, 40);
            this.textbox_Secondname.Name = "textbox_Secondname";
            this.textbox_Secondname.Size = new System.Drawing.Size(174, 20);
            this.textbox_Secondname.TabIndex = 1;
            // 
            // textbox_Number
            // 
            this.textbox_Number.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textbox_Number.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textbox_Number.CausesValidation = false;
            this.textbox_Number.Location = new System.Drawing.Point(136, 66);
            this.textbox_Number.Name = "textbox_Number";
            this.textbox_Number.Size = new System.Drawing.Size(174, 20);
            this.textbox_Number.TabIndex = 2;
            this.textbox_Number.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_Number_KeyDown);
            // 
            // textBox_Email
            // 
            this.textBox_Email.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Email.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Email.Location = new System.Drawing.Point(136, 92);
            this.textBox_Email.Name = "textBox_Email";
            this.textBox_Email.Size = new System.Drawing.Size(174, 20);
            this.textBox_Email.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Име :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Фамилия :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Телефон :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 95);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "E-Mail :";
            // 
            // label5
            // 
            this.label5.AutoEllipsis = true;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Продукт :";
            // 
            // button_Save
            // 
            this.button_Save.Location = new System.Drawing.Point(154, 403);
            this.button_Save.Name = "button_Save";
            this.button_Save.Size = new System.Drawing.Size(75, 23);
            this.button_Save.TabIndex = 12;
            this.button_Save.Text = "Save";
            this.button_Save.UseVisualStyleBackColor = true;
            this.button_Save.Click += new System.EventHandler(this.button_Save_Click);
            // 
            // button_Cancel
            // 
            this.button_Cancel.Location = new System.Drawing.Point(235, 403);
            this.button_Cancel.Name = "button_Cancel";
            this.button_Cancel.Size = new System.Drawing.Size(75, 23);
            this.button_Cancel.TabIndex = 13;
            this.button_Cancel.Text = "Cancel";
            this.button_Cancel.UseVisualStyleBackColor = true;
            this.button_Cancel.Click += new System.EventHandler(this.button_Cancel_Click);
            // 
            // textBox_Product
            // 
            this.textBox_Product.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Product.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Product.Location = new System.Drawing.Point(136, 118);
            this.textBox_Product.Name = "textBox_Product";
            this.textBox_Product.Size = new System.Drawing.Size(174, 20);
            this.textBox_Product.TabIndex = 4;
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.Items.AddRange(new object[] {
            "Приета",
            "В процес на изпълнение",
            "Отказана",
            "Предадена на клиент",
            "Завършена"});
            this.comboBox_Status.Location = new System.Drawing.Point(154, 171);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(156, 21);
            this.comboBox_Status.TabIndex = 6;
            this.comboBox_Status.SelectedIndexChanged += new System.EventHandler(this.comboBox_Status_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoEllipsis = true;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 174);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Статус на поръчката :";
            // 
            // label9
            // 
            this.label9.AutoEllipsis = true;
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 201);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(120, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Изпълнил поръчката :";
            // 
            // textBox_Izpulnil
            // 
            this.textBox_Izpulnil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_Izpulnil.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_Izpulnil.Enabled = false;
            this.textBox_Izpulnil.Location = new System.Drawing.Point(136, 198);
            this.textBox_Izpulnil.Name = "textBox_Izpulnil";
            this.textBox_Izpulnil.Size = new System.Drawing.Size(174, 20);
            this.textBox_Izpulnil.TabIndex = 7;
            // 
            // textBox_serialNum
            // 
            this.textBox_serialNum.Location = new System.Drawing.Point(136, 145);
            this.textBox_serialNum.Name = "textBox_serialNum";
            this.textBox_serialNum.Size = new System.Drawing.Size(174, 20);
            this.textBox_serialNum.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(13, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 13);
            this.label7.TabIndex = 23;
            this.label7.Text = "Сериен No. :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 227);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "Комплектовка :";
            // 
            // textBox_komplktovka
            // 
            this.textBox_komplktovka.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_komplktovka.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_komplktovka.Location = new System.Drawing.Point(136, 224);
            this.textBox_komplktovka.Name = "textBox_komplktovka";
            this.textBox_komplktovka.Size = new System.Drawing.Size(174, 20);
            this.textBox_komplktovka.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 253);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Неизправност :";
            // 
            // textBox_neizpravnost
            // 
            this.textBox_neizpravnost.Location = new System.Drawing.Point(136, 250);
            this.textBox_neizpravnost.Multiline = true;
            this.textBox_neizpravnost.Name = "textBox_neizpravnost";
            this.textBox_neizpravnost.Size = new System.Drawing.Size(174, 44);
            this.textBox_neizpravnost.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(13, 306);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Забележки :";
            // 
            // textBox_zabelejki
            // 
            this.textBox_zabelejki.Location = new System.Drawing.Point(136, 303);
            this.textBox_zabelejki.Multiline = true;
            this.textBox_zabelejki.Name = "textBox_zabelejki";
            this.textBox_zabelejki.Size = new System.Drawing.Size(174, 44);
            this.textBox_zabelejki.TabIndex = 10;
            // 
            // textBox_workDone
            // 
            this.textBox_workDone.Location = new System.Drawing.Point(136, 353);
            this.textBox_workDone.Multiline = true;
            this.textBox_workDone.Name = "textBox_workDone";
            this.textBox_workDone.Size = new System.Drawing.Size(174, 44);
            this.textBox_workDone.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(13, 356);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(110, 13);
            this.label12.TabIndex = 31;
            this.label12.Text = "Извършена работа :";
            // 
            // CreateOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 437);
            this.Controls.Add(this.textBox_workDone);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox_zabelejki);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_neizpravnost);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_komplktovka);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_serialNum);
            this.Controls.Add(this.textBox_Izpulnil);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_Status);
            this.Controls.Add(this.textBox_Product);
            this.Controls.Add(this.button_Cancel);
            this.Controls.Add(this.button_Save);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Email);
            this.Controls.Add(this.textbox_Number);
            this.Controls.Add(this.textbox_Secondname);
            this.Controls.Add(this.textbox_Firstname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CreateOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CreateOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textbox_Firstname;
        private System.Windows.Forms.TextBox textbox_Secondname;
        private System.Windows.Forms.TextBox textbox_Number;
        private System.Windows.Forms.TextBox textBox_Email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button_Save;
        private System.Windows.Forms.Button button_Cancel;
        private System.Windows.Forms.TextBox textBox_Product;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Izpulnil;
        private System.Windows.Forms.TextBox textBox_serialNum;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_komplktovka;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_neizpravnost;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox_zabelejki;
        private System.Windows.Forms.TextBox textBox_workDone;
        private System.Windows.Forms.Label label12;
    }
}