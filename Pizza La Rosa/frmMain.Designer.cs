namespace Pizza_La_Rosa
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtStrasse = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPostalCode = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtHouseNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtClientNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkPicksOrder = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClearAll = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.nudQuantity = new System.Windows.Forms.NumericUpDown();
            this.txtReferenceNo = new System.Windows.Forms.TextBox();
            this.grpVariations = new System.Windows.Forms.GroupBox();
            this.pnlIngredients = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.txtComment = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.lblRealPrice_1 = new System.Windows.Forms.Label();
            this.chkBaked = new System.Windows.Forms.CheckBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.pnlVariations = new System.Windows.Forms.Panel();
            this.chkDelivery = new System.Windows.Forms.CheckBox();
            this.cmbDrivers = new System.Windows.Forms.ComboBox();
            this.btnConfirmOrder = new System.Windows.Forms.Button();
            this.btnDone = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dgvOrders = new System.Windows.Forms.DataGridView();
            this.colMenge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colArtikel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBeschreibung = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEinzelpreis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPreis = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.btnDeleteSelected = new System.Windows.Forms.Button();
            this.cmbDeliverySector = new System.Windows.Forms.ComboBox();
            this.lblTotalSumPrice = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnYearly = new System.Windows.Forms.Button();
            this.btnMonthly = new System.Windows.Forms.Button();
            this.btnDaily = new System.Windows.Forms.Button();
            this.dtpDailyTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblRabbat = new System.Windows.Forms.Label();
            this.chcmbIngridients = new CheckComboBoxTest.CheckedComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).BeginInit();
            this.grpVariations.SuspendLayout();
            this.pnlIngredients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(31, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Telefon";
            // 
            // txtTelephone
            // 
            this.txtTelephone.AutoCompleteCustomSource.AddRange(new string[] {
            "narek",
            "valod",
            "poxos",
            "poxert",
            "poxalio",
            "natuisd",
            "leraa",
            "leriko"});
            this.txtTelephone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtTelephone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtTelephone.Location = new System.Drawing.Point(95, 64);
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(206, 20);
            this.txtTelephone.TabIndex = 2;
            this.txtTelephone.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTelephone_KeyDown);
            // 
            // txtName
            // 
            this.txtName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtName.Location = new System.Drawing.Point(95, 90);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(206, 20);
            this.txtName.TabIndex = 4;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Name";
            // 
            // txtStrasse
            // 
            this.txtStrasse.Location = new System.Drawing.Point(95, 120);
            this.txtStrasse.Name = "txtStrasse";
            this.txtStrasse.Size = new System.Drawing.Size(81, 20);
            this.txtStrasse.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Strasse";
            // 
            // txtPostalCode
            // 
            this.txtPostalCode.Location = new System.Drawing.Point(95, 148);
            this.txtPostalCode.Name = "txtPostalCode";
            this.txtPostalCode.Size = new System.Drawing.Size(57, 20);
            this.txtPostalCode.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 153);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "PLZ";
            // 
            // txtHouseNo
            // 
            this.txtHouseNo.Location = new System.Drawing.Point(261, 132);
            this.txtHouseNo.Name = "txtHouseNo";
            this.txtHouseNo.Size = new System.Drawing.Size(40, 20);
            this.txtHouseNo.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(186, 122);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Hausnummer";
            // 
            // txtCity
            // 
            this.txtCity.Location = new System.Drawing.Point(209, 148);
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(92, 20);
            this.txtCity.TabIndex = 12;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(185, 151);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(24, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "City";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 178);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Delivery Sector";
            this.label8.Visible = false;
            // 
            // txtClientNo
            // 
            this.txtClientNo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtClientNo.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtClientNo.Location = new System.Drawing.Point(95, 201);
            this.txtClientNo.Name = "txtClientNo";
            this.txtClientNo.Size = new System.Drawing.Size(114, 20);
            this.txtClientNo.TabIndex = 16;
            this.txtClientNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtClientNo_KeyDown);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 206);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Kundennummer";
            // 
            // chkPicksOrder
            // 
            this.chkPicksOrder.AutoSize = true;
            this.chkPicksOrder.Location = new System.Drawing.Point(95, 243);
            this.chkPicksOrder.Name = "chkPicksOrder";
            this.chkPicksOrder.Size = new System.Drawing.Size(90, 17);
            this.chkPicksOrder.TabIndex = 17;
            this.chkPicksOrder.Text = "Selbstabholer";
            this.chkPicksOrder.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(15, 276);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(93, 30);
            this.btnSave.TabIndex = 18;
            this.btnSave.Text = "Speichern";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClearAll
            // 
            this.btnClearAll.Location = new System.Drawing.Point(209, 276);
            this.btnClearAll.Name = "btnClearAll";
            this.btnClearAll.Size = new System.Drawing.Size(92, 30);
            this.btnClearAll.TabIndex = 19;
            this.btnClearAll.Text = "Felder löschen";
            this.btnClearAll.UseVisualStyleBackColor = true;
            this.btnClearAll.Click += new System.EventHandler(this.btnClearAll_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 334);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(286, 204);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(15, 547);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 30);
            this.btnClose.TabIndex = 21;
            this.btnClose.Text = "Beenden";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(339, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Menge";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(408, 51);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 13);
            this.label11.TabIndex = 23;
            this.label11.Text = "Artikel";
            // 
            // nudQuantity
            // 
            this.nudQuantity.Location = new System.Drawing.Point(342, 68);
            this.nudQuantity.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.nudQuantity.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQuantity.Name = "nudQuantity";
            this.nudQuantity.Size = new System.Drawing.Size(53, 20);
            this.nudQuantity.TabIndex = 24;
            this.nudQuantity.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtReferenceNo
            // 
            this.txtReferenceNo.Location = new System.Drawing.Point(411, 68);
            this.txtReferenceNo.Name = "txtReferenceNo";
            this.txtReferenceNo.Size = new System.Drawing.Size(54, 20);
            this.txtReferenceNo.TabIndex = 25;
            this.txtReferenceNo.Text = "5";
            this.txtReferenceNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtReferenceNo_KeyDown);
            // 
            // grpVariations
            // 
            this.grpVariations.Controls.Add(this.pnlIngredients);
            this.grpVariations.Controls.Add(this.txtComment);
            this.grpVariations.Controls.Add(this.lblComment);
            this.grpVariations.Controls.Add(this.lblRealPrice_1);
            this.grpVariations.Controls.Add(this.chkBaked);
            this.grpVariations.Controls.Add(this.lblPrice);
            this.grpVariations.Controls.Add(this.pnlVariations);
            this.grpVariations.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.grpVariations.Location = new System.Drawing.Point(483, 38);
            this.grpVariations.Name = "grpVariations";
            this.grpVariations.Size = new System.Drawing.Size(312, 210);
            this.grpVariations.TabIndex = 26;
            this.grpVariations.TabStop = false;
            // 
            // pnlIngredients
            // 
            this.pnlIngredients.Controls.Add(this.label12);
            this.pnlIngredients.Controls.Add(this.chcmbIngridients);
            this.pnlIngredients.Location = new System.Drawing.Point(119, 148);
            this.pnlIngredients.Name = "pnlIngredients";
            this.pnlIngredients.Size = new System.Drawing.Size(173, 53);
            this.pnlIngredients.TabIndex = 26;
            this.pnlIngredients.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(-2, 6);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(91, 15);
            this.label12.TabIndex = 26;
            this.label12.Text = "Weitere Belage";
            // 
            // txtComment
            // 
            this.txtComment.Location = new System.Drawing.Point(137, 38);
            this.txtComment.Multiline = true;
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(152, 43);
            this.txtComment.TabIndex = 29;
            this.txtComment.Visible = false;
            // 
            // lblComment
            // 
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(137, 20);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(71, 15);
            this.lblComment.TabIndex = 28;
            this.lblComment.Text = "Bemerkung";
            this.lblComment.Visible = false;
            // 
            // lblRealPrice_1
            // 
            this.lblRealPrice_1.AutoSize = true;
            this.lblRealPrice_1.Location = new System.Drawing.Point(211, 1);
            this.lblRealPrice_1.Name = "lblRealPrice_1";
            this.lblRealPrice_1.Size = new System.Drawing.Size(48, 15);
            this.lblRealPrice_1.TabIndex = 28;
            this.lblRealPrice_1.Text = "label18";
            // 
            // chkBaked
            // 
            this.chkBaked.AutoSize = true;
            this.chkBaked.Location = new System.Drawing.Point(153, 130);
            this.chkBaked.Name = "chkBaked";
            this.chkBaked.Size = new System.Drawing.Size(93, 19);
            this.chkBaked.TabIndex = 27;
            this.chkBaked.Text = "Uberbacken";
            this.chkBaked.UseVisualStyleBackColor = true;
            this.chkBaked.Visible = false;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPrice.Location = new System.Drawing.Point(212, 1);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(0, 15);
            this.lblPrice.TabIndex = 0;
            // 
            // pnlVariations
            // 
            this.pnlVariations.Location = new System.Drawing.Point(7, 30);
            this.pnlVariations.Name = "pnlVariations";
            this.pnlVariations.Size = new System.Drawing.Size(124, 117);
            this.pnlVariations.TabIndex = 25;
            // 
            // chkDelivery
            // 
            this.chkDelivery.AutoSize = true;
            this.chkDelivery.Location = new System.Drawing.Point(339, 204);
            this.chkDelivery.Name = "chkDelivery";
            this.chkDelivery.Size = new System.Drawing.Size(64, 17);
            this.chkDelivery.TabIndex = 31;
            this.chkDelivery.Text = "Delivery";
            this.chkDelivery.UseVisualStyleBackColor = true;
            this.chkDelivery.Visible = false;
            this.chkDelivery.CheckedChanged += new System.EventHandler(this.chkDelivery_CheckedChanged);
            // 
            // cmbDrivers
            // 
            this.cmbDrivers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDrivers.FormattingEnabled = true;
            this.cmbDrivers.Location = new System.Drawing.Point(339, 225);
            this.cmbDrivers.Name = "cmbDrivers";
            this.cmbDrivers.Size = new System.Drawing.Size(126, 21);
            this.cmbDrivers.TabIndex = 30;
            this.cmbDrivers.Visible = false;
            // 
            // btnConfirmOrder
            // 
            this.btnConfirmOrder.Image = ((System.Drawing.Image)(resources.GetObject("btnConfirmOrder.Image")));
            this.btnConfirmOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfirmOrder.Location = new System.Drawing.Point(339, 148);
            this.btnConfirmOrder.Name = "btnConfirmOrder";
            this.btnConfirmOrder.Size = new System.Drawing.Size(126, 37);
            this.btnConfirmOrder.TabIndex = 27;
            this.btnConfirmOrder.Text = "   Bestellung fertig";
            this.btnConfirmOrder.UseVisualStyleBackColor = true;
            this.btnConfirmOrder.Click += new System.EventHandler(this.btnConfirmOrder_Click);
            // 
            // btnDone
            // 
            this.btnDone.Image = ((System.Drawing.Image)(resources.GetObject("btnDone.Image")));
            this.btnDone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDone.Location = new System.Drawing.Point(339, 112);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(126, 30);
            this.btnDone.TabIndex = 28;
            this.btnDone.Text = "Felder löschen";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(309, 318);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(76, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Felder löschen";
            // 
            // dgvOrders
            // 
            this.dgvOrders.AllowUserToAddRows = false;
            this.dgvOrders.AllowUserToDeleteRows = false;
            this.dgvOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMenge,
            this.colArtikel,
            this.colBeschreibung,
            this.colEinzelpreis,
            this.colPreis});
            this.dgvOrders.Location = new System.Drawing.Point(312, 334);
            this.dgvOrders.Name = "dgvOrders";
            this.dgvOrders.ReadOnly = true;
            this.dgvOrders.Size = new System.Drawing.Size(488, 204);
            this.dgvOrders.TabIndex = 30;
            // 
            // colMenge
            // 
            this.colMenge.DataPropertyName = "Quantity";
            this.colMenge.FillWeight = 60F;
            this.colMenge.HeaderText = "Menge";
            this.colMenge.Name = "colMenge";
            this.colMenge.ReadOnly = true;
            this.colMenge.Width = 60;
            // 
            // colArtikel
            // 
            this.colArtikel.DataPropertyName = "ReferenceNo";
            this.colArtikel.FillWeight = 40F;
            this.colArtikel.HeaderText = "Artikel";
            this.colArtikel.Name = "colArtikel";
            this.colArtikel.ReadOnly = true;
            this.colArtikel.Width = 40;
            // 
            // colBeschreibung
            // 
            this.colBeschreibung.DataPropertyName = "Name";
            this.colBeschreibung.FillWeight = 200F;
            this.colBeschreibung.HeaderText = "Beschreibung";
            this.colBeschreibung.Name = "colBeschreibung";
            this.colBeschreibung.ReadOnly = true;
            this.colBeschreibung.Width = 200;
            // 
            // colEinzelpreis
            // 
            this.colEinzelpreis.DataPropertyName = "PricePerItem";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.colEinzelpreis.DefaultCellStyle = dataGridViewCellStyle1;
            this.colEinzelpreis.FillWeight = 60F;
            this.colEinzelpreis.HeaderText = "Einzelpreis";
            this.colEinzelpreis.Name = "colEinzelpreis";
            this.colEinzelpreis.ReadOnly = true;
            this.colEinzelpreis.Width = 60;
            // 
            // colPreis
            // 
            this.colPreis.DataPropertyName = "TotalPrice";
            dataGridViewCellStyle2.Format = "C2";
            dataGridViewCellStyle2.NullValue = null;
            this.colPreis.DefaultCellStyle = dataGridViewCellStyle2;
            this.colPreis.FillWeight = 60F;
            this.colPreis.HeaderText = "Preis";
            this.colPreis.Name = "colPreis";
            this.colPreis.ReadOnly = true;
            this.colPreis.Width = 60;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label14.Location = new System.Drawing.Point(663, 546);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 13);
            this.label14.TabIndex = 31;
            this.label14.Text = "Gesamt:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(717, 546);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(0, 13);
            this.lblTotalPrice.TabIndex = 32;
            // 
            // btnDeleteSelected
            // 
            this.btnDeleteSelected.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteSelected.Image")));
            this.btnDeleteSelected.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDeleteSelected.Location = new System.Drawing.Point(312, 546);
            this.btnDeleteSelected.Name = "btnDeleteSelected";
            this.btnDeleteSelected.Size = new System.Drawing.Size(142, 30);
            this.btnDeleteSelected.TabIndex = 33;
            this.btnDeleteSelected.Text = "     Ausgewählte löschen";
            this.btnDeleteSelected.UseVisualStyleBackColor = true;
            this.btnDeleteSelected.Click += new System.EventHandler(this.btnDeleteSelected_Click);
            // 
            // cmbDeliverySector
            // 
            this.cmbDeliverySector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDeliverySector.FormattingEnabled = true;
            this.cmbDeliverySector.Location = new System.Drawing.Point(95, 174);
            this.cmbDeliverySector.Name = "cmbDeliverySector";
            this.cmbDeliverySector.Size = new System.Drawing.Size(206, 21);
            this.cmbDeliverySector.TabIndex = 34;
            this.cmbDeliverySector.Visible = false;
            // 
            // lblTotalSumPrice
            // 
            this.lblTotalSumPrice.AutoSize = true;
            this.lblTotalSumPrice.Location = new System.Drawing.Point(720, 545);
            this.lblTotalSumPrice.Name = "lblTotalSumPrice";
            this.lblTotalSumPrice.Size = new System.Drawing.Size(0, 13);
            this.lblTotalSumPrice.TabIndex = 35;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnYearly);
            this.groupBox1.Controls.Add(this.btnMonthly);
            this.groupBox1.Controls.Add(this.btnDaily);
            this.groupBox1.Controls.Add(this.dtpDailyTimePicker);
            this.groupBox1.Location = new System.Drawing.Point(312, 254);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(483, 52);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report";
            // 
            // btnYearly
            // 
            this.btnYearly.Location = new System.Drawing.Point(399, 19);
            this.btnYearly.Name = "btnYearly";
            this.btnYearly.Size = new System.Drawing.Size(75, 23);
            this.btnYearly.TabIndex = 1;
            this.btnYearly.Text = "Yearly";
            this.btnYearly.UseVisualStyleBackColor = true;
            this.btnYearly.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnMonthly
            // 
            this.btnMonthly.Location = new System.Drawing.Point(318, 19);
            this.btnMonthly.Name = "btnMonthly";
            this.btnMonthly.Size = new System.Drawing.Size(75, 23);
            this.btnMonthly.TabIndex = 1;
            this.btnMonthly.Text = "Monthly";
            this.btnMonthly.UseVisualStyleBackColor = true;
            this.btnMonthly.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // btnDaily
            // 
            this.btnDaily.Location = new System.Drawing.Point(237, 19);
            this.btnDaily.Name = "btnDaily";
            this.btnDaily.Size = new System.Drawing.Size(75, 23);
            this.btnDaily.TabIndex = 1;
            this.btnDaily.Text = "Daily";
            this.btnDaily.UseVisualStyleBackColor = true;
            this.btnDaily.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // dtpDailyTimePicker
            // 
            this.dtpDailyTimePicker.Location = new System.Drawing.Point(17, 19);
            this.dtpDailyTimePicker.Name = "dtpDailyTimePicker";
            this.dtpDailyTimePicker.Size = new System.Drawing.Size(205, 20);
            this.dtpDailyTimePicker.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(720, 565);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(0, 13);
            this.label15.TabIndex = 39;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(718, 566);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(0, 13);
            this.label16.TabIndex = 38;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label17.Location = new System.Drawing.Point(667, 564);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 37;
            this.label17.Text = "Rabatt:";
            // 
            // lblRabbat
            // 
            this.lblRabbat.AutoSize = true;
            this.lblRabbat.Location = new System.Drawing.Point(716, 564);
            this.lblRabbat.Name = "lblRabbat";
            this.lblRabbat.Size = new System.Drawing.Size(0, 13);
            this.lblRabbat.TabIndex = 40;
            // 
            // chcmbIngridients
            // 
            this.chcmbIngridients.CheckOnClick = true;
            this.chcmbIngridients.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.chcmbIngridients.DropDownHeight = 1;
            this.chcmbIngridients.FormattingEnabled = true;
            this.chcmbIngridients.IntegralHeight = false;
            this.chcmbIngridients.Location = new System.Drawing.Point(1, 26);
            this.chcmbIngridients.Name = "chcmbIngridients";
            this.chcmbIngridients.Size = new System.Drawing.Size(170, 22);
            this.chcmbIngridients.TabIndex = 25;
            this.chcmbIngridients.ValueSeparator = ", ";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 583);
            this.Controls.Add(this.chkDelivery);
            this.Controls.Add(this.lblRabbat);
            this.Controls.Add(this.cmbDrivers);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblTotalSumPrice);
            this.Controls.Add(this.cmbDeliverySector);
            this.Controls.Add(this.btnDeleteSelected);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.dgvOrders);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.btnConfirmOrder);
            this.Controls.Add(this.grpVariations);
            this.Controls.Add(this.txtReferenceNo);
            this.Controls.Add(this.nudQuantity);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnClearAll);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.chkPicksOrder);
            this.Controls.Add(this.txtClientNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtCity);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtHouseNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPostalCode);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtStrasse);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pizza \"La Rosa\"";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudQuantity)).EndInit();
            this.grpVariations.ResumeLayout(false);
            this.grpVariations.PerformLayout();
            this.pnlIngredients.ResumeLayout(false);
            this.pnlIngredients.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrders)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtStrasse;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPostalCode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtHouseNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtClientNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkPicksOrder;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClearAll;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown nudQuantity;
        private System.Windows.Forms.TextBox txtReferenceNo;
        private System.Windows.Forms.GroupBox grpVariations;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Button btnConfirmOrder;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.DataGridView dgvOrders;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Button btnDeleteSelected;
        private System.Windows.Forms.ComboBox cmbDeliverySector;
        private System.Windows.Forms.Panel pnlVariations;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMenge;
        private System.Windows.Forms.DataGridViewTextBoxColumn colArtikel;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBeschreibung;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEinzelpreis;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPreis;
        private System.Windows.Forms.Label lblTotalSumPrice;
        private System.Windows.Forms.Panel pnlIngredients;
        private System.Windows.Forms.Label label12;
        private CheckComboBoxTest.CheckedComboBox chcmbIngridients;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpDailyTimePicker;
        private System.Windows.Forms.Button btnDaily;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblRabbat;
        private System.Windows.Forms.CheckBox chkBaked;
        private System.Windows.Forms.Label lblRealPrice_1;
        private System.Windows.Forms.Button btnYearly;
        private System.Windows.Forms.Button btnMonthly;
        private System.Windows.Forms.TextBox txtComment;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.ComboBox cmbDrivers;
        private System.Windows.Forms.CheckBox chkDelivery;
    }
}

