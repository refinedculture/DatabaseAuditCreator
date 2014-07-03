namespace DatabaseAuditCreator
{
    partial class DatabaseAuditCreator
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
            this.loadTablesIntoComboBoxButton = new System.Windows.Forms.Button();
            this.databaseTablesComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.databasePasswordTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.databaseUsernameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.testConnectionButton = new System.Windows.Forms.Button();
            this.databaseNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.getColumnsForSelectedTableButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.selectedTablesColumnsComboBox = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.doesTableHaveAuditRecordLabel = new System.Windows.Forms.Label();
            this.auditRecordLabel = new System.Windows.Forms.Label();
            this.checkForAuditRecordForTableButton = new System.Windows.Forms.Button();
            this.testFileWriteButton = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.writeAuditTriggersGroupBox = new System.Windows.Forms.GroupBox();
            this.backupCurrentAuditTriggersButton = new System.Windows.Forms.Button();
            this.writeAllAuditTriggersButton = new System.Windows.Forms.Button();
            this.writeSelectedTableTriggerButton = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.auditFilePathTextBox = new System.Windows.Forms.TextBox();
            this.auditFileNameTextBox = new System.Windows.Forms.TextBox();
            this.closeButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.writeAuditTriggersGroupBox.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // loadTablesIntoComboBoxButton
            // 
            this.loadTablesIntoComboBoxButton.Location = new System.Drawing.Point(6, 19);
            this.loadTablesIntoComboBoxButton.Name = "loadTablesIntoComboBoxButton";
            this.loadTablesIntoComboBoxButton.Size = new System.Drawing.Size(244, 23);
            this.loadTablesIntoComboBoxButton.TabIndex = 0;
            this.loadTablesIntoComboBoxButton.Text = "Load Combo With Table Names";
            this.loadTablesIntoComboBoxButton.UseVisualStyleBackColor = true;
            this.loadTablesIntoComboBoxButton.Click += new System.EventHandler(this.loadTablesIntoComboBoxButton_Click);
            // 
            // databaseTablesComboBox
            // 
            this.databaseTablesComboBox.FormattingEnabled = true;
            this.databaseTablesComboBox.Location = new System.Drawing.Point(6, 56);
            this.databaseTablesComboBox.Name = "databaseTablesComboBox";
            this.databaseTablesComboBox.Size = new System.Drawing.Size(244, 21);
            this.databaseTablesComboBox.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.loadTablesIntoComboBoxButton);
            this.groupBox1.Controls.Add(this.databaseTablesComboBox);
            this.groupBox1.Location = new System.Drawing.Point(6, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 122);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tables";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Table Count = ";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.databasePasswordTextBox);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.databaseUsernameTextBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.testConnectionButton);
            this.groupBox2.Controls.Add(this.databaseNameTextBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(6, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(518, 100);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Connection Information";
            // 
            // databasePasswordTextBox
            // 
            this.databasePasswordTextBox.Location = new System.Drawing.Point(355, 51);
            this.databasePasswordTextBox.Name = "databasePasswordTextBox";
            this.databasePasswordTextBox.Size = new System.Drawing.Size(154, 20);
            this.databasePasswordTextBox.TabIndex = 9;
            this.databasePasswordTextBox.Text = "MZd#$0RP#E";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(265, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // databaseUsernameTextBox
            // 
            this.databaseUsernameTextBox.Location = new System.Drawing.Point(355, 22);
            this.databaseUsernameTextBox.Name = "databaseUsernameTextBox";
            this.databaseUsernameTextBox.Size = new System.Drawing.Size(154, 20);
            this.databaseUsernameTextBox.TabIndex = 7;
            this.databaseUsernameTextBox.Text = "master_bill";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Username";
            // 
            // testConnectionButton
            // 
            this.testConnectionButton.Location = new System.Drawing.Point(6, 71);
            this.testConnectionButton.Name = "testConnectionButton";
            this.testConnectionButton.Size = new System.Drawing.Size(244, 23);
            this.testConnectionButton.TabIndex = 4;
            this.testConnectionButton.Text = "Test Connection";
            this.testConnectionButton.UseVisualStyleBackColor = true;
            this.testConnectionButton.Click += new System.EventHandler(this.testConnectionButton_Click);
            // 
            // databaseNameTextBox
            // 
            this.databaseNameTextBox.Location = new System.Drawing.Point(96, 22);
            this.databaseNameTextBox.Name = "databaseNameTextBox";
            this.databaseNameTextBox.Size = new System.Drawing.Size(154, 20);
            this.databaseNameTextBox.TabIndex = 5;
            this.databaseNameTextBox.Text = "dbill";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Database Name";
            // 
            // getColumnsForSelectedTableButton
            // 
            this.getColumnsForSelectedTableButton.Location = new System.Drawing.Point(6, 19);
            this.getColumnsForSelectedTableButton.Name = "getColumnsForSelectedTableButton";
            this.getColumnsForSelectedTableButton.Size = new System.Drawing.Size(244, 23);
            this.getColumnsForSelectedTableButton.TabIndex = 4;
            this.getColumnsForSelectedTableButton.Text = "Get Columns For Selected Table";
            this.getColumnsForSelectedTableButton.UseVisualStyleBackColor = true;
            this.getColumnsForSelectedTableButton.Click += new System.EventHandler(this.getColumnsForSelectedTableButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.selectedTablesColumnsComboBox);
            this.groupBox3.Controls.Add(this.getColumnsForSelectedTableButton);
            this.groupBox3.Location = new System.Drawing.Point(268, 19);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(256, 122);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Columns";
            // 
            // selectedTablesColumnsComboBox
            // 
            this.selectedTablesColumnsComboBox.FormattingEnabled = true;
            this.selectedTablesColumnsComboBox.Location = new System.Drawing.Point(6, 56);
            this.selectedTablesColumnsComboBox.Name = "selectedTablesColumnsComboBox";
            this.selectedTablesColumnsComboBox.Size = new System.Drawing.Size(244, 21);
            this.selectedTablesColumnsComboBox.TabIndex = 5;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.doesTableHaveAuditRecordLabel);
            this.groupBox4.Controls.Add(this.auditRecordLabel);
            this.groupBox4.Controls.Add(this.checkForAuditRecordForTableButton);
            this.groupBox4.Location = new System.Drawing.Point(540, 19);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(256, 122);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Audit Record Exists?";
            // 
            // doesTableHaveAuditRecordLabel
            // 
            this.doesTableHaveAuditRecordLabel.AutoSize = true;
            this.doesTableHaveAuditRecordLabel.Location = new System.Drawing.Point(130, 91);
            this.doesTableHaveAuditRecordLabel.Name = "doesTableHaveAuditRecordLabel";
            this.doesTableHaveAuditRecordLabel.Size = new System.Drawing.Size(0, 13);
            this.doesTableHaveAuditRecordLabel.TabIndex = 5;
            // 
            // auditRecordLabel
            // 
            this.auditRecordLabel.AutoSize = true;
            this.auditRecordLabel.Location = new System.Drawing.Point(6, 91);
            this.auditRecordLabel.Name = "auditRecordLabel";
            this.auditRecordLabel.Size = new System.Drawing.Size(118, 13);
            this.auditRecordLabel.TabIndex = 4;
            this.auditRecordLabel.Text = "Table Being Audited  = ";
            // 
            // checkForAuditRecordForTableButton
            // 
            this.checkForAuditRecordForTableButton.Location = new System.Drawing.Point(6, 19);
            this.checkForAuditRecordForTableButton.Name = "checkForAuditRecordForTableButton";
            this.checkForAuditRecordForTableButton.Size = new System.Drawing.Size(244, 23);
            this.checkForAuditRecordForTableButton.TabIndex = 4;
            this.checkForAuditRecordForTableButton.Text = "Check If Table Had Audit Record Set To Yes";
            this.checkForAuditRecordForTableButton.UseVisualStyleBackColor = true;
            this.checkForAuditRecordForTableButton.Click += new System.EventHandler(this.checkForAuditRecordForTableButton_Click);
            // 
            // testFileWriteButton
            // 
            this.testFileWriteButton.Location = new System.Drawing.Point(6, 19);
            this.testFileWriteButton.Name = "testFileWriteButton";
            this.testFileWriteButton.Size = new System.Drawing.Size(244, 23);
            this.testFileWriteButton.TabIndex = 7;
            this.testFileWriteButton.Text = "Test File Writing";
            this.testFileWriteButton.UseVisualStyleBackColor = true;
            this.testFileWriteButton.Click += new System.EventHandler(this.testFileWriteButton_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.groupBox2);
            this.groupBox5.Location = new System.Drawing.Point(12, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1049, 129);
            this.groupBox5.TabIndex = 8;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Configuraiton";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.groupBox1);
            this.groupBox6.Controls.Add(this.groupBox3);
            this.groupBox6.Controls.Add(this.groupBox4);
            this.groupBox6.Location = new System.Drawing.Point(12, 147);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1049, 152);
            this.groupBox6.TabIndex = 9;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Information Lookup";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.writeAuditTriggersGroupBox);
            this.groupBox7.Controls.Add(this.groupBox8);
            this.groupBox7.Location = new System.Drawing.Point(12, 305);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1049, 149);
            this.groupBox7.TabIndex = 10;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Audit";
            // 
            // writeAuditTriggersGroupBox
            // 
            this.writeAuditTriggersGroupBox.Controls.Add(this.backupCurrentAuditTriggersButton);
            this.writeAuditTriggersGroupBox.Controls.Add(this.writeAllAuditTriggersButton);
            this.writeAuditTriggersGroupBox.Controls.Add(this.writeSelectedTableTriggerButton);
            this.writeAuditTriggersGroupBox.Location = new System.Drawing.Point(274, 19);
            this.writeAuditTriggersGroupBox.Name = "writeAuditTriggersGroupBox";
            this.writeAuditTriggersGroupBox.Size = new System.Drawing.Size(250, 124);
            this.writeAuditTriggersGroupBox.TabIndex = 10;
            this.writeAuditTriggersGroupBox.TabStop = false;
            this.writeAuditTriggersGroupBox.Text = "Write Audit Triggers";
            // 
            // backupCurrentAuditTriggersButton
            // 
            this.backupCurrentAuditTriggersButton.Location = new System.Drawing.Point(6, 80);
            this.backupCurrentAuditTriggersButton.Name = "backupCurrentAuditTriggersButton";
            this.backupCurrentAuditTriggersButton.Size = new System.Drawing.Size(238, 23);
            this.backupCurrentAuditTriggersButton.TabIndex = 11;
            this.backupCurrentAuditTriggersButton.Text = "Backup Current Audit Triggers";
            this.backupCurrentAuditTriggersButton.UseVisualStyleBackColor = true;
            this.backupCurrentAuditTriggersButton.Click += new System.EventHandler(this.backupCurrentAuditTriggersButton_Click);
            // 
            // writeAllAuditTriggersButton
            // 
            this.writeAllAuditTriggersButton.Location = new System.Drawing.Point(6, 51);
            this.writeAllAuditTriggersButton.Name = "writeAllAuditTriggersButton";
            this.writeAllAuditTriggersButton.Size = new System.Drawing.Size(238, 23);
            this.writeAllAuditTriggersButton.TabIndex = 10;
            this.writeAllAuditTriggersButton.Text = "Backup and ReWrite All Audit Triggers Possible";
            this.writeAllAuditTriggersButton.UseVisualStyleBackColor = true;
            this.writeAllAuditTriggersButton.Click += new System.EventHandler(this.writeAllAuditTriggersButton_Click);
            // 
            // writeSelectedTableTriggerButton
            // 
            this.writeSelectedTableTriggerButton.Location = new System.Drawing.Point(6, 19);
            this.writeSelectedTableTriggerButton.Name = "writeSelectedTableTriggerButton";
            this.writeSelectedTableTriggerButton.Size = new System.Drawing.Size(238, 23);
            this.writeSelectedTableTriggerButton.TabIndex = 9;
            this.writeSelectedTableTriggerButton.Text = "Write Selected Table\'s Audit Trigger";
            this.writeSelectedTableTriggerButton.UseVisualStyleBackColor = true;
            this.writeSelectedTableTriggerButton.Click += new System.EventHandler(this.writeSelectedTableTriggerButton_Click);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.label6);
            this.groupBox8.Controls.Add(this.label5);
            this.groupBox8.Controls.Add(this.auditFilePathTextBox);
            this.groupBox8.Controls.Add(this.auditFileNameTextBox);
            this.groupBox8.Controls.Add(this.testFileWriteButton);
            this.groupBox8.Location = new System.Drawing.Point(6, 19);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(256, 124);
            this.groupBox8.TabIndex = 8;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Document Configuration";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "File Name =";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Path =";
            // 
            // auditFilePathTextBox
            // 
            this.auditFilePathTextBox.Location = new System.Drawing.Point(73, 74);
            this.auditFilePathTextBox.Name = "auditFilePathTextBox";
            this.auditFilePathTextBox.Size = new System.Drawing.Size(177, 20);
            this.auditFilePathTextBox.TabIndex = 10;
            this.auditFilePathTextBox.Text = "C:\\_AuditTriggerCreation\\";
            // 
            // auditFileNameTextBox
            // 
            this.auditFileNameTextBox.Location = new System.Drawing.Point(73, 48);
            this.auditFileNameTextBox.Name = "auditFileNameTextBox";
            this.auditFileNameTextBox.Size = new System.Drawing.Size(177, 20);
            this.auditFileNameTextBox.TabIndex = 9;
            this.auditFileNameTextBox.Text = "AuditUpdate.sql";
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(726, 460);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(335, 55);
            this.closeButton.TabIndex = 11;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // DatabaseAuditCreator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1069, 524);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Name = "DatabaseAuditCreator";
            this.Text = "Database Audit Creator";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.writeAuditTriggersGroupBox.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button loadTablesIntoComboBoxButton;
        private System.Windows.Forms.ComboBox databaseTablesComboBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox databaseNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button testConnectionButton;
        private System.Windows.Forms.Button getColumnsForSelectedTableButton;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox selectedTablesColumnsComboBox;
        private System.Windows.Forms.TextBox databasePasswordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox databaseUsernameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label doesTableHaveAuditRecordLabel;
        private System.Windows.Forms.Label auditRecordLabel;
        private System.Windows.Forms.Button checkForAuditRecordForTableButton;
        private System.Windows.Forms.Button testFileWriteButton;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox auditFilePathTextBox;
        private System.Windows.Forms.TextBox auditFileNameTextBox;
        private System.Windows.Forms.Button writeSelectedTableTriggerButton;
        private System.Windows.Forms.GroupBox writeAuditTriggersGroupBox;
        private System.Windows.Forms.Button writeAllAuditTriggersButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Button backupCurrentAuditTriggersButton;
    }
}

