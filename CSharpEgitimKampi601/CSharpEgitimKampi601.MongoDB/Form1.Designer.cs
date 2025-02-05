namespace CSharpEgitimKampi601.MongoDB
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboCity = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.nmrcAccount = new System.Windows.Forms.NumericUpDown();
            this.nmrcTotal = new System.Windows.Forms.NumericUpDown();
            this.btnList = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnGetById = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcTotal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGetById);
            this.groupBox1.Controls.Add(this.btnUpdate);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnDelete);
            this.groupBox1.Controls.Add(this.btnList);
            this.groupBox1.Controls.Add(this.nmrcTotal);
            this.groupBox1.Controls.Add(this.nmrcAccount);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.comboCity);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtSurname);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mongo DB";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Müşteri ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(91, 30);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(153, 20);
            this.txtId.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(91, 56);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(153, 20);
            this.txtName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Müşteri Adı:";
            // 
            // txtSurname
            // 
            this.txtSurname.Location = new System.Drawing.Point(91, 82);
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(153, 20);
            this.txtSurname.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Müşteri Soyadı:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Müşteri Şehir:";
            // 
            // comboCity
            // 
            this.comboCity.FormattingEnabled = true;
            this.comboCity.Items.AddRange(new object[] {
            "Adana\t01",
            "Adıyaman\t02",
            "Afyon\t03",
            "Ağrı\t04",
            "Amasya\t05",
            "Ankara\t06",
            "Antalya\t07",
            "Artvin\t08",
            "Aydın\t09",
            "Balıkesir\t10",
            "Bilecik\t11",
            "Bingöl\t12",
            "Bitlis\t13",
            "Bolu\t14",
            "Burdur\t15",
            "Bursa\t16",
            "Çanakkale\t17",
            "Çankırı\t18",
            "Çorum\t19",
            "Denizli\t20",
            "Diyarbakır\t21",
            "Edirne\t22",
            "Elazığ\t23",
            "Erzincan\t24",
            "Erzurum\t25",
            "Eskişehir\t26",
            "Gaziantep\t27",
            "Giresun\t28",
            "Gümüşhane\t29",
            "Hakkari\t30",
            "Hatay\t31",
            "Isparta\t32",
            "İçel\t33",
            "İstanbul\t34",
            "İzmir\t35",
            "Kars\t36",
            "Kastamonu\t37",
            "Kayseri\t38",
            "Kırklareli\t39",
            "Kırşehir\t40",
            "Kocaeli\t41",
            "Konya\t42",
            "Kütahya\t43",
            "Malatya\t44",
            "Manisa\t45",
            "Kahramanmaraş\t46",
            "Mardin\t47",
            "Muğla\t48",
            "Muş\t49",
            "Nevşehir\t50",
            "Niğde\t51",
            "Ordu\t52",
            "Rize\t53",
            "Sakarya\t54",
            "Samsun\t55",
            "Siirt\t56",
            "Sinop\t57",
            "Sivas\t58",
            "Tekirdağ\t59",
            "Tokat\t60",
            "Trabzon\t61",
            "Tunceli\t62",
            "Şanlıurfa\t63",
            "Uşak\t64",
            "Van\t65",
            "Yozgat\t66",
            "Zonguldak\t67",
            "Aksaray\t68",
            "Bayburt\t69",
            "Karaman\t70",
            "Kırıkkale\t71",
            "Batman\t72",
            "Şırnak\t73",
            "Bartın\t74",
            "Ardahan\t75",
            "Iğdır\t76",
            "Yalova\t77",
            "Karabük\t78",
            "Kilis\t79",
            "Osmaniye\t80",
            "Düzce\t81"});
            this.comboCity.Location = new System.Drawing.Point(91, 111);
            this.comboCity.Name = "comboCity";
            this.comboCity.Size = new System.Drawing.Size(153, 21);
            this.comboCity.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Bakiye:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 168);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Alışveriş Tutar:";
            // 
            // nmrcAccount
            // 
            this.nmrcAccount.Location = new System.Drawing.Point(91, 141);
            this.nmrcAccount.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nmrcAccount.Name = "nmrcAccount";
            this.nmrcAccount.Size = new System.Drawing.Size(153, 20);
            this.nmrcAccount.TabIndex = 12;
            // 
            // nmrcTotal
            // 
            this.nmrcTotal.Location = new System.Drawing.Point(91, 168);
            this.nmrcTotal.Name = "nmrcTotal";
            this.nmrcTotal.Size = new System.Drawing.Size(153, 20);
            this.nmrcTotal.TabIndex = 13;
            // 
            // btnList
            // 
            this.btnList.BackColor = System.Drawing.Color.Lime;
            this.btnList.Location = new System.Drawing.Point(91, 216);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(153, 37);
            this.btnList.TabIndex = 14;
            this.btnList.Text = "Listele";
            this.btnList.UseVisualStyleBackColor = false;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.Cyan;
            this.btnAdd.Location = new System.Drawing.Point(91, 259);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(153, 37);
            this.btnAdd.TabIndex = 15;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.Red;
            this.btnDelete.Location = new System.Drawing.Point(91, 302);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(153, 37);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Sil";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.Yellow;
            this.btnUpdate.Location = new System.Drawing.Point(91, 343);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(153, 37);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Güncelle";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(269, 17);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(869, 421);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnGetById
            // 
            this.btnGetById.BackColor = System.Drawing.Color.Fuchsia;
            this.btnGetById.Location = new System.Drawing.Point(91, 382);
            this.btnGetById.Name = "btnGetById";
            this.btnGetById.Size = new System.Drawing.Size(153, 37);
            this.btnGetById.TabIndex = 18;
            this.btnGetById.Text = "ID\'ye Göre Getir";
            this.btnGetById.UseVisualStyleBackColor = false;
            this.btnGetById.Click += new System.EventHandler(this.btnGetById_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1150, 450);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Mongo DB ile CRUD";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nmrcTotal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSurname;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboCity;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.NumericUpDown nmrcTotal;
        private System.Windows.Forms.NumericUpDown nmrcAccount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnGetById;
    }
}

