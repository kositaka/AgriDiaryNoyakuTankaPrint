
namespace AgriDiaryNoyakuTankaPrint
{
    partial class AllMainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView_Noyaku = new System.Windows.Forms.DataGridView();
            this.button_Seek = new System.Windows.Forms.Button();
            this.comboBox_KinMusi = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_Print = new System.Windows.Forms.Button();
            this.buttonF3 = new System.Windows.Forms.Button();
            this.button_F10B = new System.Windows.Forms.Button();
            this.button_Clear = new System.Windows.Forms.Button();
            this.button_Del = new System.Windows.Forms.Button();
            this.button_F7B = new System.Windows.Forms.Button();
            this.button_Update = new System.Windows.Forms.Button();
            this.button_Insert = new System.Windows.Forms.Button();
            this.button_Prn = new System.Windows.Forms.Button();
            this.button_F12A = new System.Windows.Forms.Button();
            this.button_F11A = new System.Windows.Forms.Button();
            this.button_F10A = new System.Windows.Forms.Button();
            this.button_F9A = new System.Windows.Forms.Button();
            this.button_F8A = new System.Windows.Forms.Button();
            this.button_F7A = new System.Windows.Forms.Button();
            this.button_F6A = new System.Windows.Forms.Button();
            this.button_F5A = new System.Windows.Forms.Button();
            this.button_F4A = new System.Windows.Forms.Button();
            this.button_F3A = new System.Windows.Forms.Button();
            this.button_F1A = new System.Windows.Forms.Button();
            this.button_F2A = new System.Windows.Forms.Button();
            this.button_Quit = new System.Windows.Forms.Button();
            this.button_F1B = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.comboBox_Nendo = new System.Windows.Forms.ComboBox();
            this.label41 = new System.Windows.Forms.Label();
            this.dateTimePicker_To = new System.Windows.Forms.DateTimePicker();
            this.label42 = new System.Windows.Forms.Label();
            this.dateTimePicker_From = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_Ja = new System.Windows.Forms.CheckBox();
            this.checkBox_Kojin = new System.Windows.Forms.CheckBox();
            this.checkBox_Ippan = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Noyaku)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_Noyaku
            // 
            this.dataGridView_Noyaku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Noyaku.Location = new System.Drawing.Point(521, 179);
            this.dataGridView_Noyaku.Name = "dataGridView_Noyaku";
            this.dataGridView_Noyaku.RowTemplate.Height = 21;
            this.dataGridView_Noyaku.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_Noyaku.Size = new System.Drawing.Size(770, 681);
            this.dataGridView_Noyaku.TabIndex = 19;
            this.dataGridView_Noyaku.TabStop = false;
            // 
            // button_Seek
            // 
            this.button_Seek.BackColor = System.Drawing.SystemColors.Control;
            this.button_Seek.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Seek.Location = new System.Drawing.Point(292, 33);
            this.button_Seek.Name = "button_Seek";
            this.button_Seek.Size = new System.Drawing.Size(112, 53);
            this.button_Seek.TabIndex = 20;
            this.button_Seek.TabStop = false;
            this.button_Seek.Text = "検索";
            this.button_Seek.UseVisualStyleBackColor = false;
            this.button_Seek.Click += new System.EventHandler(this.button_Seek_Click);
            // 
            // comboBox_KinMusi
            // 
            this.comboBox_KinMusi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_KinMusi.FormattingEnabled = true;
            this.comboBox_KinMusi.Items.AddRange(new object[] {
            "1 殺菌",
            "2 殺虫",
            "9 その他"});
            this.comboBox_KinMusi.Location = new System.Drawing.Point(412, 134);
            this.comboBox_KinMusi.Name = "comboBox_KinMusi";
            this.comboBox_KinMusi.Size = new System.Drawing.Size(94, 23);
            this.comboBox_KinMusi.TabIndex = 1;
            this.comboBox_KinMusi.TabStop = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(312, 138);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(97, 15);
            this.label16.TabIndex = 917;
            this.label16.Text = "殺菌殺虫区分";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.button_Print);
            this.panel1.Controls.Add(this.buttonF3);
            this.panel1.Controls.Add(this.button_F10B);
            this.panel1.Controls.Add(this.button_Clear);
            this.panel1.Controls.Add(this.button_Del);
            this.panel1.Controls.Add(this.button_F7B);
            this.panel1.Controls.Add(this.button_Update);
            this.panel1.Controls.Add(this.button_Insert);
            this.panel1.Controls.Add(this.button_Prn);
            this.panel1.Controls.Add(this.button_F12A);
            this.panel1.Controls.Add(this.button_F11A);
            this.panel1.Controls.Add(this.button_F10A);
            this.panel1.Controls.Add(this.button_F9A);
            this.panel1.Controls.Add(this.button_F8A);
            this.panel1.Controls.Add(this.button_F7A);
            this.panel1.Controls.Add(this.button_F6A);
            this.panel1.Controls.Add(this.button_F5A);
            this.panel1.Controls.Add(this.button_F4A);
            this.panel1.Controls.Add(this.button_F3A);
            this.panel1.Controls.Add(this.button_F1A);
            this.panel1.Controls.Add(this.button_F2A);
            this.panel1.Controls.Add(this.button_Quit);
            this.panel1.Controls.Add(this.button_F1B);
            this.panel1.Controls.Add(this.button_Seek);
            this.panel1.Location = new System.Drawing.Point(1, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1784, 98);
            this.panel1.TabIndex = 0;
            // 
            // button_Print
            // 
            this.button_Print.BackColor = System.Drawing.SystemColors.Control;
            this.button_Print.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Print.Location = new System.Drawing.Point(516, 33);
            this.button_Print.Name = "button_Print";
            this.button_Print.Size = new System.Drawing.Size(112, 53);
            this.button_Print.TabIndex = 24;
            this.button_Print.TabStop = false;
            this.button_Print.Text = "農薬単価調査表印刷";
            this.button_Print.UseVisualStyleBackColor = false;
            this.button_Print.Click += new System.EventHandler(this.button_Print_Click);
            // 
            // buttonF3
            // 
            this.buttonF3.BackColor = System.Drawing.SystemColors.Control;
            this.buttonF3.Enabled = false;
            this.buttonF3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonF3.Location = new System.Drawing.Point(404, 33);
            this.buttonF3.Name = "buttonF3";
            this.buttonF3.Size = new System.Drawing.Size(112, 53);
            this.buttonF3.TabIndex = 22;
            this.buttonF3.TabStop = false;
            this.buttonF3.UseVisualStyleBackColor = false;
            // 
            // button_F10B
            // 
            this.button_F10B.BackColor = System.Drawing.SystemColors.Control;
            this.button_F10B.Enabled = false;
            this.button_F10B.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F10B.Location = new System.Drawing.Point(1230, 33);
            this.button_F10B.Name = "button_F10B";
            this.button_F10B.Size = new System.Drawing.Size(112, 53);
            this.button_F10B.TabIndex = 21;
            this.button_F10B.TabStop = false;
            this.button_F10B.UseVisualStyleBackColor = false;
            // 
            // button_Clear
            // 
            this.button_Clear.BackColor = System.Drawing.SystemColors.Control;
            this.button_Clear.Enabled = false;
            this.button_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Clear.Location = new System.Drawing.Point(1117, 33);
            this.button_Clear.Name = "button_Clear";
            this.button_Clear.Size = new System.Drawing.Size(112, 53);
            this.button_Clear.TabIndex = 20;
            this.button_Clear.TabStop = false;
            this.button_Clear.UseVisualStyleBackColor = false;
            // 
            // button_Del
            // 
            this.button_Del.BackColor = System.Drawing.SystemColors.Control;
            this.button_Del.Enabled = false;
            this.button_Del.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Del.Location = new System.Drawing.Point(987, 33);
            this.button_Del.Name = "button_Del";
            this.button_Del.Size = new System.Drawing.Size(112, 53);
            this.button_Del.TabIndex = 19;
            this.button_Del.TabStop = false;
            this.button_Del.UseVisualStyleBackColor = false;
            // 
            // button_F7B
            // 
            this.button_F7B.BackColor = System.Drawing.SystemColors.Control;
            this.button_F7B.Enabled = false;
            this.button_F7B.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F7B.Location = new System.Drawing.Point(874, 33);
            this.button_F7B.Name = "button_F7B";
            this.button_F7B.Size = new System.Drawing.Size(112, 53);
            this.button_F7B.TabIndex = 18;
            this.button_F7B.TabStop = false;
            this.button_F7B.UseVisualStyleBackColor = false;
            // 
            // button_Update
            // 
            this.button_Update.BackColor = System.Drawing.SystemColors.Control;
            this.button_Update.Enabled = false;
            this.button_Update.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Update.Location = new System.Drawing.Point(762, 33);
            this.button_Update.Name = "button_Update";
            this.button_Update.Size = new System.Drawing.Size(112, 53);
            this.button_Update.TabIndex = 17;
            this.button_Update.TabStop = false;
            this.button_Update.UseVisualStyleBackColor = false;
            // 
            // button_Insert
            // 
            this.button_Insert.BackColor = System.Drawing.SystemColors.Control;
            this.button_Insert.Enabled = false;
            this.button_Insert.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Insert.Location = new System.Drawing.Point(649, 33);
            this.button_Insert.Name = "button_Insert";
            this.button_Insert.Size = new System.Drawing.Size(112, 53);
            this.button_Insert.TabIndex = 16;
            this.button_Insert.TabStop = false;
            this.button_Insert.UseVisualStyleBackColor = false;
            // 
            // button_Prn
            // 
            this.button_Prn.BackColor = System.Drawing.SystemColors.Control;
            this.button_Prn.Enabled = false;
            this.button_Prn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Prn.Location = new System.Drawing.Point(1342, 33);
            this.button_Prn.Name = "button_Prn";
            this.button_Prn.Size = new System.Drawing.Size(112, 53);
            this.button_Prn.TabIndex = 14;
            this.button_Prn.TabStop = false;
            this.button_Prn.UseVisualStyleBackColor = false;
            // 
            // button_F12A
            // 
            this.button_F12A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F12A.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_F12A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F12A.Location = new System.Drawing.Point(1654, 4);
            this.button_F12A.Name = "button_F12A";
            this.button_F12A.Size = new System.Drawing.Size(112, 23);
            this.button_F12A.TabIndex = 11;
            this.button_F12A.TabStop = false;
            this.button_F12A.Text = "Ｆ１２";
            this.button_F12A.UseVisualStyleBackColor = false;
            // 
            // button_F11A
            // 
            this.button_F11A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F11A.Enabled = false;
            this.button_F11A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F11A.Location = new System.Drawing.Point(1342, 4);
            this.button_F11A.Name = "button_F11A";
            this.button_F11A.Size = new System.Drawing.Size(112, 23);
            this.button_F11A.TabIndex = 10;
            this.button_F11A.TabStop = false;
            this.button_F11A.Text = "Ｆ１１";
            this.button_F11A.UseVisualStyleBackColor = false;
            // 
            // button_F10A
            // 
            this.button_F10A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F10A.Enabled = false;
            this.button_F10A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F10A.Location = new System.Drawing.Point(1230, 4);
            this.button_F10A.Name = "button_F10A";
            this.button_F10A.Size = new System.Drawing.Size(112, 23);
            this.button_F10A.TabIndex = 9;
            this.button_F10A.TabStop = false;
            this.button_F10A.Text = "Ｆ１０";
            this.button_F10A.UseVisualStyleBackColor = false;
            // 
            // button_F9A
            // 
            this.button_F9A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F9A.Enabled = false;
            this.button_F9A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F9A.Location = new System.Drawing.Point(1117, 4);
            this.button_F9A.Name = "button_F9A";
            this.button_F9A.Size = new System.Drawing.Size(112, 23);
            this.button_F9A.TabIndex = 8;
            this.button_F9A.TabStop = false;
            this.button_F9A.Text = "Ｆ９";
            this.button_F9A.UseVisualStyleBackColor = false;
            // 
            // button_F8A
            // 
            this.button_F8A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F8A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F8A.Location = new System.Drawing.Point(987, 4);
            this.button_F8A.Name = "button_F8A";
            this.button_F8A.Size = new System.Drawing.Size(112, 23);
            this.button_F8A.TabIndex = 7;
            this.button_F8A.TabStop = false;
            this.button_F8A.Text = "Ｆ８";
            this.button_F8A.UseVisualStyleBackColor = false;
            // 
            // button_F7A
            // 
            this.button_F7A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F7A.Enabled = false;
            this.button_F7A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F7A.Location = new System.Drawing.Point(874, 4);
            this.button_F7A.Name = "button_F7A";
            this.button_F7A.Size = new System.Drawing.Size(112, 23);
            this.button_F7A.TabIndex = 6;
            this.button_F7A.TabStop = false;
            this.button_F7A.Text = "Ｆ７";
            this.button_F7A.UseVisualStyleBackColor = false;
            // 
            // button_F6A
            // 
            this.button_F6A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F6A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F6A.Location = new System.Drawing.Point(762, 4);
            this.button_F6A.Name = "button_F6A";
            this.button_F6A.Size = new System.Drawing.Size(112, 23);
            this.button_F6A.TabIndex = 5;
            this.button_F6A.TabStop = false;
            this.button_F6A.Text = "Ｆ６";
            this.button_F6A.UseVisualStyleBackColor = false;
            // 
            // button_F5A
            // 
            this.button_F5A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F5A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F5A.Location = new System.Drawing.Point(649, 4);
            this.button_F5A.Name = "button_F5A";
            this.button_F5A.Size = new System.Drawing.Size(112, 23);
            this.button_F5A.TabIndex = 4;
            this.button_F5A.TabStop = false;
            this.button_F5A.Text = "Ｆ５";
            this.button_F5A.UseVisualStyleBackColor = false;
            // 
            // button_F4A
            // 
            this.button_F4A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F4A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F4A.Location = new System.Drawing.Point(516, 4);
            this.button_F4A.Name = "button_F4A";
            this.button_F4A.Size = new System.Drawing.Size(112, 23);
            this.button_F4A.TabIndex = 3;
            this.button_F4A.TabStop = false;
            this.button_F4A.Text = "Ｆ４";
            this.button_F4A.UseVisualStyleBackColor = false;
            // 
            // button_F3A
            // 
            this.button_F3A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F3A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F3A.Location = new System.Drawing.Point(404, 4);
            this.button_F3A.Name = "button_F3A";
            this.button_F3A.Size = new System.Drawing.Size(112, 23);
            this.button_F3A.TabIndex = 2;
            this.button_F3A.TabStop = false;
            this.button_F3A.Text = "Ｆ３";
            this.button_F3A.UseVisualStyleBackColor = false;
            // 
            // button_F1A
            // 
            this.button_F1A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F1A.Enabled = false;
            this.button_F1A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F1A.Location = new System.Drawing.Point(179, 4);
            this.button_F1A.Name = "button_F1A";
            this.button_F1A.Size = new System.Drawing.Size(112, 23);
            this.button_F1A.TabIndex = 0;
            this.button_F1A.TabStop = false;
            this.button_F1A.Text = "Ｆ１";
            this.button_F1A.UseVisualStyleBackColor = false;
            // 
            // button_F2A
            // 
            this.button_F2A.BackColor = System.Drawing.SystemColors.Control;
            this.button_F2A.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F2A.Location = new System.Drawing.Point(292, 4);
            this.button_F2A.Name = "button_F2A";
            this.button_F2A.Size = new System.Drawing.Size(112, 23);
            this.button_F2A.TabIndex = 1;
            this.button_F2A.TabStop = false;
            this.button_F2A.Text = "Ｆ２";
            this.button_F2A.UseVisualStyleBackColor = false;
            // 
            // button_Quit
            // 
            this.button_Quit.BackColor = System.Drawing.SystemColors.Control;
            this.button_Quit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_Quit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_Quit.Location = new System.Drawing.Point(1654, 33);
            this.button_Quit.Name = "button_Quit";
            this.button_Quit.Size = new System.Drawing.Size(112, 53);
            this.button_Quit.TabIndex = 23;
            this.button_Quit.TabStop = false;
            this.button_Quit.Text = "終了";
            this.button_Quit.UseVisualStyleBackColor = false;
            this.button_Quit.Click += new System.EventHandler(this.button_Quit_Click);
            // 
            // button_F1B
            // 
            this.button_F1B.BackColor = System.Drawing.SystemColors.Control;
            this.button_F1B.Enabled = false;
            this.button_F1B.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button_F1B.Location = new System.Drawing.Point(179, 33);
            this.button_F1B.Name = "button_F1B";
            this.button_F1B.Size = new System.Drawing.Size(112, 53);
            this.button_F1B.TabIndex = 12;
            this.button_F1B.TabStop = false;
            this.button_F1B.UseVisualStyleBackColor = false;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(1202, 103);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(536, 15);
            this.label43.TabIndex = 1801;
            this.label43.Text = "AgriDiaryNoyakuTankaPrint  Ver 1.02 2023/3/17 (Ver 1.00 2022/112/12) VS2019";
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(526, 138);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(37, 15);
            this.label40.TabIndex = 1909;
            this.label40.Text = "年度";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_Nendo
            // 
            this.comboBox_Nendo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Nendo.FormattingEnabled = true;
            this.comboBox_Nendo.Items.AddRange(new object[] {
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.comboBox_Nendo.Location = new System.Drawing.Point(569, 134);
            this.comboBox_Nendo.Name = "comboBox_Nendo";
            this.comboBox_Nendo.Size = new System.Drawing.Size(63, 23);
            this.comboBox_Nendo.TabIndex = 1908;
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(649, 138);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(37, 15);
            this.label41.TabIndex = 1910;
            this.label41.Text = "開始";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker_To
            // 
            this.dateTimePicker_To.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_To.Location = new System.Drawing.Point(871, 134);
            this.dateTimePicker_To.Name = "dateTimePicker_To";
            this.dateTimePicker_To.Size = new System.Drawing.Size(118, 22);
            this.dateTimePicker_To.TabIndex = 1907;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(815, 138);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(52, 15);
            this.label42.TabIndex = 1911;
            this.label42.Text = "～終了";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker_From
            // 
            this.dateTimePicker_From.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_From.Location = new System.Drawing.Point(692, 134);
            this.dateTimePicker_From.Name = "dateTimePicker_From";
            this.dateTimePicker_From.Size = new System.Drawing.Size(118, 22);
            this.dateTimePicker_From.TabIndex = 1906;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(524, 866);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 15);
            this.label1.TabIndex = 1912;
            this.label1.Text = "※使用中止を除く";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox_Ja
            // 
            this.checkBox_Ja.AutoSize = true;
            this.checkBox_Ja.Location = new System.Drawing.Point(1091, 136);
            this.checkBox_Ja.Name = "checkBox_Ja";
            this.checkBox_Ja.Size = new System.Drawing.Size(103, 19);
            this.checkBox_Ja.TabIndex = 1913;
            this.checkBox_Ja.Text = "JA推奨農薬";
            this.checkBox_Ja.UseVisualStyleBackColor = true;
            // 
            // checkBox_Kojin
            // 
            this.checkBox_Kojin.AutoSize = true;
            this.checkBox_Kojin.Location = new System.Drawing.Point(1206, 136);
            this.checkBox_Kojin.Name = "checkBox_Kojin";
            this.checkBox_Kojin.Size = new System.Drawing.Size(116, 19);
            this.checkBox_Kojin.TabIndex = 1914;
            this.checkBox_Kojin.Text = "個人推奨農薬";
            this.checkBox_Kojin.UseVisualStyleBackColor = true;
            this.checkBox_Kojin.Click += new System.EventHandler(this.checkBox_Kojin_Click);
            // 
            // checkBox_Ippan
            // 
            this.checkBox_Ippan.AutoSize = true;
            this.checkBox_Ippan.Location = new System.Drawing.Point(1334, 136);
            this.checkBox_Ippan.Name = "checkBox_Ippan";
            this.checkBox_Ippan.Size = new System.Drawing.Size(86, 19);
            this.checkBox_Ippan.TabIndex = 1915;
            this.checkBox_Ippan.Text = "一般農薬";
            this.checkBox_Ippan.UseVisualStyleBackColor = true;
            this.checkBox_Ippan.Click += new System.EventHandler(this.checkBox_Ippan_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1017, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 15);
            this.label2.TabIndex = 1916;
            this.label2.Text = "印刷条件";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AllMainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(1784, 890);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkBox_Ippan);
            this.Controls.Add(this.checkBox_Kojin);
            this.Controls.Add(this.checkBox_Ja);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label40);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.label41);
            this.Controls.Add(this.comboBox_Nendo);
            this.Controls.Add(this.dateTimePicker_To);
            this.Controls.Add(this.dateTimePicker_From);
            this.Controls.Add(this.comboBox_KinMusi);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.dataGridView_Noyaku);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label16);
            this.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AllMainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "農薬単価調査表印刷";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AllMainForm_FormClosing);
            this.Load += new System.EventHandler(this.AllMainForm_Load);
            this.Shown += new System.EventHandler(this.AllMainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Noyaku)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dataGridView_Noyaku;
        private System.Windows.Forms.Button button_Seek;
        private System.Windows.Forms.ComboBox comboBox_KinMusi;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonF3;
        private System.Windows.Forms.Button button_F10B;
        private System.Windows.Forms.Button button_Clear;
        private System.Windows.Forms.Button button_Del;
        private System.Windows.Forms.Button button_F7B;
        private System.Windows.Forms.Button button_Update;
        private System.Windows.Forms.Button button_Insert;
        private System.Windows.Forms.Button button_Prn;
        private System.Windows.Forms.Button button_F12A;
        private System.Windows.Forms.Button button_F11A;
        private System.Windows.Forms.Button button_F10A;
        private System.Windows.Forms.Button button_F9A;
        private System.Windows.Forms.Button button_F8A;
        private System.Windows.Forms.Button button_F7A;
        private System.Windows.Forms.Button button_F6A;
        private System.Windows.Forms.Button button_F5A;
        private System.Windows.Forms.Button button_F4A;
        private System.Windows.Forms.Button button_F3A;
        private System.Windows.Forms.Button button_F1A;
        private System.Windows.Forms.Button button_F2A;
        private System.Windows.Forms.Button button_Quit;
        private System.Windows.Forms.Button button_F1B;
        private System.Windows.Forms.Button button_Print;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.ComboBox comboBox_Nendo;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.DateTimePicker dateTimePicker_To;
        private System.Windows.Forms.DateTimePicker dateTimePicker_From;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_Ja;
        private System.Windows.Forms.CheckBox checkBox_Kojin;
        private System.Windows.Forms.CheckBox checkBox_Ippan;
        private System.Windows.Forms.Label label2;
    }
}

