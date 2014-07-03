using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
//using Oracle.DataAccess.Client;
using System.Data.OracleClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DatabaseAuditCreator
{
    public partial class DatabaseAuditCreator : Form
    {
        #region Variables

        List<string> logMessages = new List<string>();

        private readonly int sessionID = new Int32();
        Random randomGen = new Random((int)DateTime.Now.Ticks);

        private enum MessageSeverity
        {
            Warning = 1,
            Error = 2,
            Success = 3,
            Info = 4,
        }

        #endregion Variables

        #region Constructor
        public DatabaseAuditCreator()
        {
            sessionID = randomGen.Next(Int32.MinValue, Int32.MaxValue);
            InitializeComponent();
        }
        #endregion Constructor

        #region Oracle And OraDB Database Interaction Functions

        #region Get Database Table's Column Names
        private List<string> GetDatabaseTableColumnNames_OracleDA(string tableName)
        {
            var conStr = GetConnectionString_OracleDA();
            List<string> listOfColumnNames = new List<string>();

            try
            {
                using (var con = new OracleConnection(conStr))
                {
                    con.Open();
                    using (var cmd = new OracleCommand("select * from " + tableName, con))
                    using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        var table = reader.GetSchemaTable();
                        var nameCol = table.Columns["ColumnName"];
                        foreach (DataRow row in table.Rows)
                        {
                            listOfColumnNames.Add(row[nameCol].ToString());
                        }
                    }
                }
            }
            catch(OracleException ex)
            {
                MessageBox.Show("Failure in  function GetDatabaseTableColumnNames_OracleDA. Exception - " + ex.Message);
                LogMessage("Failure in  function GetDatabaseTableColumnNames_OracleDA. Exception - " + ex.Message, MessageSeverity.Error);
            }

            return listOfColumnNames;
        }

        /// <summary>
        /// This method will not work with some column types, use the oracleDA one, which will work for most(all) column types
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private List<string> GetDatabaseTableColumnNames_OleDBDA(string tableName)
        {
            var conStr = GetConnectionString_OleDBDA();
            List<string> listOfColumnNames = new List<string>();

            try
            {
                using (var con = new OleDbConnection(conStr))
                {
                    con.Open();
                    using (var cmd = new OleDbCommand("select * from " + tableName, con))
                    using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly))
                    {
                        var table = reader.GetSchemaTable();
                        var nameCol = table.Columns["ColumnName"];
                        foreach (DataRow row in table.Rows)
                        {
                            listOfColumnNames.Add(row[nameCol].ToString());
                        }
                    }
                }
            }
            catch(OleDbException ex)
            {
                MessageBox.Show("Failure in  function GetDatabaseTableColumnNames_OleDBDA. Exception - " + ex.Message);
                LogMessage("Failure in  function GetDatabaseTableColumnNames_OleDBDA. Exception - " + ex.Message, MessageSeverity.Error);
            }

            return listOfColumnNames;
        }
        #endregion Get Database Table's Column Names


        #region Get Database Tables
        private DataTable GetDatabaseTables_OracleDA()
        {
            throw new NotImplementedException();
        }

        private DataTable GetDatabaseTables_OleDBDA()
        {
            OleDbConnection conn;
            string connetionString = GetConnectionString_OleDBDA();
            conn = new OleDbConnection(connetionString);

            try
            {
                conn.Open();
                DataTable schemaTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                return schemaTable;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Exception in GetDatabaseTables_OleDBDA - " + ex.Message);
                LogMessage("Exception in GetDatabaseTables_OleDBDA - " + ex.Message, MessageSeverity.Error);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        #endregion Get Database Tables


        #region Does Table Have Audit Record
        private bool DoesTableHaveAuditRecordSetToYes_OracleDA(string tableName)
        {
            try
            {
                var conStr = GetConnectionString_OracleDA();
                using (var con = new OracleConnection(conStr))
                {
                    con.Open();
                    using (var cmd = new OracleCommand("select * from audit_table where audit_table_name = '" + tableName.ToUpper() + "'", con))
                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (reader.Read())
                        {
                            if (reader["AUDIT_INDICATOR"].ToString().ToUpper() == "Y")
                                return true;
                            //How To Read the field values:
                            //string myString = "";
                            //for (int i = 0; i < reader.FieldCount; i++)
                            //{
                            //    myString += reader[i] + "\t";
                            //}
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Failure in  function DoesTableHaveAuditRecord_OracleDA. Exception - " + ex.Message);
                LogMessage("Failure in  function DoesTableHaveAuditRecord_OracleDA. Exception - " + ex.Message, MessageSeverity.Error);
            }

            return false;
        }

        private bool DoesTableHaveAuditRecord_OleDBDA(string tableName)
        {
            try
            {
                var conStr = GetConnectionString_OleDBDA();
                using (var con = new OleDbConnection (conStr))
                {
                    con.Open();
                    using (var cmd = new OleDbCommand("select * from audit_table where audit_table_name = '" + tableName.ToUpper() + "'", con))
                    using (var reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        while (reader.Read())
                        {
                            return true;
                            //How To Read the field values:
                            //string myString = "";
                            //for(int i = 0; i < reader.FieldCount; i++)
                            //{
                            //    myString += reader[i] + "\t";
                            //}
                        }
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Failure in  function GetConnectionString_OleDBDA. Exception - " + ex.Message);
                LogMessage("Failure in  function GetConnectionString_OleDBDA. Exception - " + ex.Message, MessageSeverity.Error);
            }

            return false;
        }
        #endregion Check If Table Has Audit Record


        #region Get Database Schema
        private DataTable GetSchema_OleDBDA()
        {
            OleDbConnection conn;
            string connetionString = GetConnectionString_OleDBDA();
            conn = new OleDbConnection(connetionString);

            try
            {
                conn.Open();
                DataTable schemaTable = conn.GetSchema();
                return schemaTable;
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Exception in GetSchema_OleDBDA - " + ex.Message);
                LogMessage("Exception in GetSchema_OleDBDA - " + ex.Message, MessageSeverity.Error);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }

        private DataTable GetSchema_OracleDA()
        {
            OracleConnection conn;
            string connetionString = GetConnectionString_OracleDA();
            conn = new OracleConnection(connetionString);

            try
            {
                conn.Open();
                DataTable schemaTable = conn.GetSchema();
                return schemaTable;
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Exception in GetSchema_OracleDA - " + ex.Message);
                LogMessage("Exception in GetSchema_OracleDA - " + ex.Message, MessageSeverity.Error);
            }
            finally
            {
                conn.Close();
            }
            return null;
        }
        #endregion Get Database Schema


        #region Get Connection String
        private string GetConnectionString_OleDBDA()
        {
            if (databaseNameTextBox.Text.Replace(" ", "").ToUpper().Contains("PBILL"))
                throw new NotImplementedException();

            return "Provider=MSDAORA;Data Source=" + databaseNameTextBox.Text + ";user id=" + databaseUsernameTextBox.Text + ";password=" + databasePasswordTextBox.Text + ";";
        }

        private string GetConnectionString_OracleDA()
        {
            if (databaseNameTextBox.Text.Replace(" ", "").ToUpper().Contains("PBILL"))
                throw new NotImplementedException();


            return "Data Source=" + databaseNameTextBox.Text + ";user id=" + databaseUsernameTextBox.Text + ";password=" + databasePasswordTextBox.Text + ";";
        }
        #endregion Get Connection String


        #region Test Database Connections
        private void TestDatabaseConnection_OraceDA()
        {
            OracleConnection conn;
            string connetionString = GetConnectionString_OracleDA();
            conn = new OracleConnection(connetionString);

            try
            {
                conn.Open();
                MessageBox.Show("Oracle Data Access Connection Open!");
                LogMessage("Oracle Data Access Connection Open!", MessageSeverity.Success);
            }
            catch (OleDbException ex)
            {
                MessageBox.Show("Connection Unable To Open - Exception:" + ex.Message);
                LogMessage("Connection Unable To Open - Exception:" + ex.Message, MessageSeverity.Error);
            }
            finally
            {
                conn.Close();
            }
        }

        private void TestDatabaseConnection_OleDBDA()
        {
            OleDbConnection conn;
            string connetionString = GetConnectionString_OleDBDA();
            conn = new OleDbConnection(connetionString);

            try
            {
                conn.Open();
                MessageBox.Show("Ole DB Data Access Connection Open!");
                LogMessage("Ole DB Data Access Connection Open!", MessageSeverity.Success);
            }
             catch (OleDbException ex)
            {
                MessageBox.Show("Connection Unable To Open - Exception:" + ex.Message);
                LogMessage("Connection Unable To Open - Exception:" + ex.Message, MessageSeverity.Error);
            }
            finally
            {
                conn.Close();
            }
        }
        #endregion Test Database Connections


        #region Get Current Audit Trigger Text For A Given Table Name
        /// <summary>
        /// When I attempted to create this function, using OracleConnection and OracleCommand, it would not return the
        /// TRIGGER_BODY of the audit for some reason. - Do not use.
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        private List<string> GetOldAuditTriggerStringForTable_OracleDA(string tableName)
        {
            throw new NotImplementedException();
        }


        private List<string> GetOldAuditTriggerStringForTable_OleDBDA(string tableName)
        {
            tableName = tableName.ToUpper();
            string auditName = tableName + "_AUDIT";
            if (DoesAuditTriggerHaveDifferentNameThanTable(tableName))
            {
                auditName = GetAuditTriggerNameForTable(tableName);
                MessageBox.Show(tableName + " backup audit is named " + auditName + " as per the tableNameToAuditTriggerPairing.txt file");
                LogMessage(tableName + " backup audit is named " + auditName + " as per the tableNameToAuditTriggerPairing.txt file", MessageSeverity.Info);
            }
            try
            {
                var conStr = GetConnectionString_OleDBDA();
                using (var con = new OleDbConnection(conStr))
                {
                    con.Open();
                    using (var cmd = new OleDbCommand("select DESCRIPTION, TRIGGER_BODY from user_triggers where trigger_name = '" + auditName.ToUpper() + "'", con))
                    using (var reader = cmd.ExecuteReader(CommandBehavior.Default))
                    {
                        while (reader.Read())
                        {
                            List<string> description = reader["DESCRIPTION"].ToString().Split('\n').ToList();
                            List<string> triggerBody = reader["TRIGGER_BODY"].ToString().Split('\n').ToList();
                            List<string> auditTriggerText = new List<string>();
                            auditTriggerText.AddRange(description);
                            auditTriggerText.AddRange(triggerBody);
                            return auditTriggerText;
                        }
                    }
                }
            }
            catch (OracleException ex)
            {
                MessageBox.Show("Failure in  function GetOldAuditTriggerStringForTable. Exception - " + ex.Message);
                LogMessage("Failure in  function GetOldAuditTriggerStringForTable. Exception - " + ex.Message, MessageSeverity.Error);
            }
            return null;
        }

        #endregion Get Current Audit Trigger Text For A Given Table Name

        #endregion Oracle And OraDB Database Interaction Functions

        #region Button Click Event Handlers

        private void loadTablesIntoComboBoxButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            DataTable results = GetDatabaseTables_OleDBDA();
            FillDatabaseTablesComboBoxWithTableNames(results);
            UpdateTableCountLabel(results.Rows.Count);

            Cursor = Cursors.Arrow;
        }

        private void testConnectionButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            TestDatabaseConnection_OleDBDA();
            TestDatabaseConnection_OraceDA();

            Cursor = Cursors.Arrow;
        }

        private void getColumnsForSelectedTableButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            List<string> columnNameList = GetDatabaseTableColumnNames_OracleDA(databaseTablesComboBox.Text);
            FillColumnNameComboBoxWithColumnNames(columnNameList);

            Cursor = Cursors.Arrow;
        }

        private void checkForAuditRecordForTableButton_Click(object sender, EventArgs e)
        {
            doesTableHaveAuditRecordLabel.Text = DoesTableHaveAuditRecordSetToYes_OracleDA(databaseTablesComboBox.Text).ToString();
        }

        private void testFileWriteButton_Click(object sender, EventArgs e)
        {
            List<string> myList = new List<string>() { 
                    "Audit Test File", 
                    "Path - '" + auditFilePathTextBox.Text+"'", 
                    "File Name - '" + auditFileNameTextBox.Text+"'", 
                    "Local Date/Time - " + DateTime.Now.ToString(),
                    "UTC Date/Time - " + DateTime.UtcNow.ToString()};

            WriteStringListToFile(GetFilePathForAuditCreation(), GetFilePathForAuditCreation()+"test.sql", myList, true, true);

        }

        private void writeSelectedTableTriggerButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            List<string> auditString = GetNewAuditTriggerStringForTable(databaseTablesComboBox.Text, GetDatabaseTableColumnNames_OracleDA(databaseTablesComboBox.Text));
            if(auditString != null)
                WriteStringListToFile(GetFilePathForAuditCreation(), GetFilePathForAuditCreation() + databaseTablesComboBox.Text + GetFileName(), auditString, true, true);
            this.Cursor = Cursors.Arrow;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void writeAllAuditTriggersButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PerformAuditTriggerBackupToFile();
            WriteAllAuditTriggersToFileIfPossible();
            this.Cursor = Cursors.Arrow;
        }

        private void backupCurrentAuditTriggersButton_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            PerformAuditTriggerBackupToFile();
            this.Cursor = Cursors.Arrow;
        }

        #endregion Button Click Event Handlers

        #region Helper Functions

        private List<string> GetTableNamesFromDataTableObject(DataTable results)
        {
            List<string> tableNames = new List<string>();
            foreach (DataRow row in results.Rows)
            {
                tableNames.Add(row["TABLE_NAME"].ToString());
            }
            return tableNames;
        }

        private void WriteAllAuditTriggersToFileIfPossible()
        {
            DataTable results = GetDatabaseTables_OleDBDA();
            List<string> auditFile = new List<string>();
            auditFile.AddRange(GetSQLScriptHeader());
            int countOfTablesWithAuditTriggersCreated = 0;
            foreach (DataRow row in results.Rows)
            {
                string tableName = row["TABLE_NAME"].ToString();
                bool createAudit = DoesTableHaveAuditRecordSetToYes_OracleDA(tableName);
                if (createAudit)
                {
                    List<string> columnNameList = GetDatabaseTableColumnNames_OracleDA(tableName);
                    List<string> triggerText = GetNewAuditTriggerStringForTable(tableName, columnNameList);
                    if (triggerText == null)
                        continue;
                    auditFile.AddRange(triggerText);
                    LogMessage("Table " + tableName + " created a audit trigger", MessageSeverity.Success);
                    countOfTablesWithAuditTriggersCreated += 1;
                }
                else
                    LogMessage("Ignoring audit trigger creation for " + tableName + " as there is no record for it in the audit_table database table.", MessageSeverity.Warning);
            }

            LogMessage("Count of audit triggers created = " + countOfTablesWithAuditTriggersCreated.ToString(), MessageSeverity.Success);

            auditFile.AddRange(GetSQLScriptFooter());
            WriteStringListToFile(GetFilePathForAuditCreation(), GetFilePathForAuditCreationWithFileName(), auditFile, true, true);
        }

        private void WriteStringListToFile(string filePath, string filePathWithFileName, List<string> stringList, bool openFileLocation, bool showMessageBoxes)
        {
            try
            {
                string[] lines = stringList.ToArray();

                Directory.CreateDirectory(filePath);

                System.IO.File.WriteAllLines(filePathWithFileName, lines);

                if (openFileLocation)
                {
                    Process.Start(filePathWithFileName);
                    if (showMessageBoxes)
                        MessageBox.Show("Success in file writing - Opened document in text editor.");
                    LogMessage("Success in file writing - Opened document in text editor.", MessageSeverity.Success);
                }
                else
                {
                    if (showMessageBoxes)
                        MessageBox.Show("Success in file writing");
                    LogMessage("Success in file writing", MessageSeverity.Success);
                }
            }
            catch (Exception ex)
            {
                if(showMessageBoxes)
                    MessageBox.Show("File Write Failed.  Exception - " + ex.Message);
                LogMessage("File Write Failed.  Exception - " + ex.Message, MessageSeverity.Error);
            }
        }

        private void WriteLogToFile(string filePath, string filePathWithFileName, List<string> stringList, bool openFileLocation)
        {
            try
            {
                string[] lines = stringList.ToArray();

                Directory.CreateDirectory(filePath);

                System.IO.File.WriteAllLines(filePathWithFileName, lines);

                if (openFileLocation)
                {
                    Process.Start(filePathWithFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void PerformAuditTriggerBackupToFile()
        {
            DataTable tables = GetDatabaseTables_OleDBDA();
            List<string> tableNames = GetTableNamesFromDataTableObject(tables);

            foreach (string tableName in tableNames)
            {
                bool createAudit = DoesTableHaveAuditRecordSetToYes_OracleDA(tableName);
                if (createAudit)
                {
                    List<string> columnNameList = GetDatabaseTableColumnNames_OracleDA(tableName);
                    List<string> triggerText = GetOldAuditTriggerStringForTable_OleDBDA(tableName);
                    if (triggerText == null)
                    {
                        LogMessage("Failed to write backup - Could not get audit text from database for " + tableName, MessageSeverity.Error);
                        continue;
                    }
                    WriteStringListToFile(GetFilePathForBackup(), GetFilePathForBackupWithFileName(tableName + "_audit_Backup.sql"), triggerText, false, false);
                    LogMessage("Created backup for Table " + tableName, MessageSeverity.Success);
                }
                else
                    LogMessage("Not backing up table " + tableName + " as there is no record for it in the audit_table database table.", MessageSeverity.Warning);
            }

        }
        
        private void LogMessage(string message, MessageSeverity severity)
        {
            logMessages.Add(Enum.GetName(typeof(MessageSeverity), severity) + " - " + DateTime.Now.ToLongTimeString() + " - " + message);

            WriteLogToFile(GetFilePathForAuditCreation(), GetFilePathForAuditCreation() + "log.txt", logMessages, false);
        }

        #region UI Manipulation Functions
        private void UpdateTableCountLabel(int count)
        {
            label1.Text = "Table Count = " + count.ToString();
        }

        private void FillDatabaseTablesComboBoxWithTableNames(DataTable results)
        {
            databaseTablesComboBox.Items.Clear();
            databaseTablesComboBox.SelectedIndex = -1;

            foreach (DataRow row in results.Rows)
            {
                databaseTablesComboBox.Items.Add(row["TABLE_NAME"].ToString());
            }

            if (databaseTablesComboBox.Items.Count >= 1)
                databaseTablesComboBox.SelectedIndex = 0;

        }

        private void FillColumnNameComboBoxWithColumnNames(List<string> columnNameList)
        {
            selectedTablesColumnsComboBox.Items.Clear();
            selectedTablesColumnsComboBox.SelectedIndex = -1;

            foreach (string column in columnNameList)
            {
                selectedTablesColumnsComboBox.Items.Add(column);
            }

            if (columnNameList.Count >= 1)
                selectedTablesColumnsComboBox.SelectedIndex = 0;
        }
        #endregion UI Manipulation Functions

        #region Get File Name And File Path For Audit Creation And Backup Functions

        private string GetFilePathForAuditCreationWithFileName()
        {
            return auditFilePathTextBox.Text + DateTime.Now.ToShortDateString().ToString().Replace("/", "-") + "-(" + sessionID + ")\\" + auditFileNameTextBox.Text;
        }

        private string GetFilePathForBackupWithFileName(string fileName)
        {
            return auditFilePathTextBox.Text + DateTime.Now.ToShortDateString().ToString().Replace("/", "-") + "-(" + sessionID + ")\\Backup\\" + fileName;
        }

        private string GetFilePathForBackup()
        {
            return auditFilePathTextBox.Text + DateTime.Now.ToShortDateString().ToString().Replace("/", "-") + "-(" + sessionID + ")\\Backup\\";
        }

        private string GetFilePathForAuditCreation()
        {
            return auditFilePathTextBox.Text + DateTime.Now.ToShortDateString().ToString().Replace("/", "-") + "-(" + sessionID + ")\\";
        }

        private string GetFileName()
        {
            return auditFileNameTextBox.Text;
        }

        #endregion Get File Name And File Path For Audit Creation And Backup Functions

        #region File Interaction Functions - Checks Audit Names and Ignored Tables from files

        private string GetAuditTriggerNameForTable(string tableName)
        {
            List<KeyValuePair<string, string>> dictionary = GetCustomAuditNamesFromExternalFile();
            return dictionary.FirstOrDefault(x => x.Key.ToUpper() == tableName.ToUpper()).Value.ToUpper();
        }

        private bool DoesAuditTriggerHaveDifferentNameThanTable(string tableName)
        {
            List<KeyValuePair<string, string>> dictionary = GetCustomAuditNamesFromExternalFile();
            return dictionary.Exists(x => x.Key.ToUpper() == tableName.ToUpper());
        }

        private static List<KeyValuePair<string, string>> GetCustomAuditNamesFromExternalFile()
        {
            List<KeyValuePair<string, string>> dictionary = new List<KeyValuePair<string, string>>();

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader("tableNameToAuditTriggerPairing.txt");
            while ((line = file.ReadLine()) != null)
            {
                string[] array = line.Split('-');
                KeyValuePair<string, string> entry = new KeyValuePair<string, string>(array[0], array[1]);
                dictionary.Add(entry);
            }

            file.Close();
            return dictionary;
        }

        private bool AreWeIgnoringAuditCreationForTable(string tableName)
        {
            List<string> dictionary = GetTablesToIgnoreFromExternalFile();
            return dictionary.Exists(x => x.ToUpper() == tableName.ToUpper());
        }

        private static List<string> GetTablesToIgnoreFromExternalFile()
        {
            List<string> dictionary = new List<string>();

            string line;

            System.IO.StreamReader file = new System.IO.StreamReader("tablesToIgnoreWhenCreatingNewAuditTrigger.txt");
            while ((line = file.ReadLine()) != null)
            {
                dictionary.Add(line);
            }

            file.Close();
            return dictionary;
        }

        #endregion File Interaction Functions - Checks Audit Names and Ignored Tables from files

        #region Audit String Creation Functions

        private List<string> GetNewAuditTriggerStringForTable(string tableName, List<string> columnNames)
        {
            List<string> auditTriggerText = new List<string>();

            tableName = tableName.ToUpper();

            bool foundUpdateDateColumn = false;
            bool foundUpdateUserColumn = false;
            bool foundAuditIDColumn = false;
            bool foundCompanyIDColumn = false;
            foreach (string columnName in columnNames)
            {
                string columnNameToUpper = columnName.ToUpper();
                if (columnNameToUpper == "AUDIT_ID")
                    foundAuditIDColumn = true;
                if (columnNameToUpper == "UPDATE_DATE")
                    foundUpdateDateColumn = true;
                if (columnNameToUpper == "UPDATE_USER")
                    foundUpdateUserColumn = true;
                if (columnNameToUpper == "COMPANY_ID")
                    foundCompanyIDColumn = true;
            }

            if (!foundAuditIDColumn)
            {
                MessageBox.Show(tableName + " has no audit ID column - abandoning audit trigger creation for this table");
                LogMessage(tableName + " has no audit ID column - abandoning audit trigger creation for this table", MessageSeverity.Error);
                return null;
            }
            if (!foundUpdateDateColumn)
            {
                MessageBox.Show(tableName + " has no update date column - abandoning audit trigger creation for this table");
                LogMessage(tableName + " has no update date column - abandoning audit trigger creation for this table", MessageSeverity.Error);
                return null;
            }
            if (!foundUpdateUserColumn)
            {
                MessageBox.Show(tableName + " has no update date column - abandoning audit trigger creation for this table");
                LogMessage(tableName + " has no update user column - abandoning audit trigger creation for this table", MessageSeverity.Error);
                return null;
            }
            if (!foundCompanyIDColumn)
            {
                MessageBox.Show(tableName + " has no company ID column - will replace company_id with NULL");
                LogMessage(tableName + " has no company ID column - will replace company_id with NULL", MessageSeverity.Warning);
            }

            if (AreWeIgnoringAuditCreationForTable(tableName))
            {
                MessageBox.Show(tableName + " audit creation is being ignored as per the tablesToIgnoreWhenCreatingNewAuditTrigger.txt file");
                LogMessage(tableName + " audit creation is being ignored as per the tablesToIgnoreWhenCreatingNewAuditTrigger.txt file", MessageSeverity.Info);
                return null;
            }



            string auditName = tableName + "_AUDIT";
            if (DoesAuditTriggerHaveDifferentNameThanTable(tableName))
            {
                auditName = GetAuditTriggerNameForTable(tableName);
                MessageBox.Show(tableName + " audit is named " + auditName + " as per the tableNameToAuditTriggerPairing.txt file");
                LogMessage(tableName + " audit is named " + auditName + " as per the tableNameToAuditTriggerPairing.txt file", MessageSeverity.Info);
            }

            List<string> auditTriggerHeader = new List<string>()
            {

                "create or replace",
                "trigger \"" + auditName + "\"",
                "BEFORE INSERT OR UPDATE OR DELETE",
                "ON " + tableName,
                "REFERENCING NEW AS NEW OLD AS OLD",
                "FOR EACH ROW",
                "DECLARE",
                "vAudit_Ind		CHAR(1);",
                "vNew_Audit_Id		NUMBER;",
                "vAudit_Table_Id		NUMBER;",
                "vWhat_Changed		VARCHAR2(4000);",
                "AUDIT_ID_CHANGED	EXCEPTION;",
                " -- Created with a tool on " + DateTime.Now.ToLongDateString() + " at " + DateTime.Now.ToLongTimeString(),
                "BEGIN",
                "  IF INSERTING",
                "  THEN",
	            "    -- Get the AUDIT_ID and put it on the source record",
	            "    SELECT AUDIT_HISTORY_SEQ.NEXTVAL INTO vNew_Audit_Id FROM dual;",
	            "    :NEW.AUDIT_ID := vNew_Audit_Id;",
                "  END IF; --IF INSERTING",

                "  IF UPDATING",
                "    THEN",
	            "    SELECT AUDIT_TABLE_ID, AUDIT_INDICATOR",
	            "    INTO vAudit_Table_Id, vAudit_Ind",
	            "    FROM AUDIT_TABLE",
	            "    WHERE AUDIT_TABLE_NAME='" + tableName + "';",
	            "    -- Only create an Audit Record if auditing is turned on for the " + tableName + " table",
	            "    IF vAudit_Ind = 'Y'",
	            "    THEN",
		        "        -- Write a record to the AUDIT_HISTORY table with supplied :OLD.AUDIT_ID",
		        "        -- The :OLD.AUDIT_ID and :NEW.AUDIT_ID should be the same",
		        "        -- 1) Get the AUDIT_TABLE_ID from AUDIT_TABLE using this table name (" + tableName + ")",
		        "        -- 2) Determine what changed using the :NEW, :OLD values and build the WHAT_CHANGED string",
		        "        -- 3) Set the AUDIT_ACTION column to \"U\"",
		        "        -- 4) Add any comments",
		        "        -- 5) Write the new row to the AUDIT_HISTORY table",
		        "        --",
		        "        -- Use the supplied :OLD.AUDIT_ID and other OLD variables (other than the UPDATE stamp).",
		        "        IF :OLD.AUDIT_ID <> :NEW.AUDIT_ID THEN",
			    "            RAISE AUDIT_ID_CHANGED;",
		        "        END IF;",
            };

            auditTriggerText.AddRange(auditTriggerHeader);

            List<string> columnAudits = new List<string>();

            foreach (string columnName in columnNames)
            {
                string columnNameToUpper = columnName.ToUpper();

                if (columnNameToUpper == "UPDATE_DATE")
                    continue;
                if (columnNameToUpper == "UPDATE_USER")
                    continue;
                if (columnNameToUpper == "AUDIT_ID")
                    continue;

                List<string> columnAudit = new List<string>()
                {
                    "        IF (:OLD." + columnNameToUpper + " IS NULL AND :NEW." + columnNameToUpper + " IS NOT NULL) OR",
                    "           (:OLD." + columnNameToUpper + " IS NOT NULL AND :NEW." + columnNameToUpper + " IS NULL) OR",
		            "           (:OLD." + columnNameToUpper + " <> :NEW." + columnNameToUpper + ") THEN",
			        "               vWhat_Changed := vWhat_Changed || '," + columnNameToUpper + "='||:OLD." + columnNameToUpper + ";",
		            "        END IF;",
                };

                columnAudits.AddRange(columnAudit);
            }

            auditTriggerText.AddRange(columnAudits);

            string ifLengthOfWhatChangesIsGreaterThanZero =
                "        IF LENGTH(vWhat_Changed) > 0 THEN --INSERT INTO AUDIT_HISTORY";

            auditTriggerText.Add(ifLengthOfWhatChangesIsGreaterThanZero);

            if (foundUpdateDateColumn)
            {
                List<string> updateDateAudit = new List<string>()
                {
                    "          IF (:OLD.UPDATE_DATE IS NULL AND :NEW.UPDATE_DATE IS NOT NULL) OR",
                    "             (:OLD.UPDATE_DATE IS NOT NULL AND :NEW.UPDATE_DATE IS NULL) OR",
			        "             (:OLD.UPDATE_DATE <> :NEW.UPDATE_DATE) THEN",
				    "                 vWhat_Changed := vWhat_Changed || ',UPDATE_DATE='||:NEW.UPDATE_DATE;",
			        "          END IF;",
                };

                auditTriggerText.AddRange(updateDateAudit);
            }
            if (foundUpdateUserColumn)
            {
                List<string> updateDateAudit = new List<string>()
                {
			        "          IF (:OLD.UPDATE_USER IS NULL AND :NEW.UPDATE_USER IS NOT NULL) OR",
			        "             (:OLD.UPDATE_USER IS NOT NULL AND :NEW.UPDATE_USER IS NULL) OR",
			        "             (:OLD.UPDATE_USER <> :NEW.UPDATE_USER) THEN",
				    "              vWhat_Changed := vWhat_Changed || ',UPDATE_USER='||:NEW.UPDATE_USER;",
			        "          END IF;",
                };

                auditTriggerText.AddRange(updateDateAudit);
            }

            List<string> insertIntoAuditHistoryAndEndIfForThreeIfStatements;

            if (foundCompanyIDColumn)
            {
                insertIntoAuditHistoryAndEndIfForThreeIfStatements = new List<string>()
                {
			    "          INSERT INTO AUDIT_HISTORY",
			    "            (AUDIT_TABLE_ID,AUDIT_ID,AUDIT_DATE,USER_ID,AUDIT_ACTION,WHAT_CHANGED,COMMENTS,COMPANY_ID)",
			    "          VALUES",
			    "            (vAudit_Table_Id,:NEW.AUDIT_ID,SYSDATE,:NEW.UPDATE_USER,'U',vWhat_Changed,'" + tableName + " update',:NEW.COMPANY_ID);",
		        "        END IF; --IF LENGTH(vWhat_Changed) > 0",
                "    END IF; --IF vAudit_Ind = 'Y'",
                "  END IF; --IF UPDATING",
                };
            }
            else
            {
                insertIntoAuditHistoryAndEndIfForThreeIfStatements = new List<string>()
                {
			    "          INSERT INTO AUDIT_HISTORY",
			    "            (AUDIT_TABLE_ID,AUDIT_ID,AUDIT_DATE,USER_ID,AUDIT_ACTION,WHAT_CHANGED,COMMENTS,COMPANY_ID)",
			    "          VALUES",
			    "            (vAudit_Table_Id,:NEW.AUDIT_ID,SYSDATE,:NEW.UPDATE_USER,'U',vWhat_Changed,'" + tableName + " update',NULL);",
		        "        END IF; --IF LENGTH(vWhat_Changed) > 0",
                "    END IF; --IF vAudit_Ind = 'Y'",
                "  END IF; --IF UPDATING",
                };
            }

            auditTriggerText.AddRange(insertIntoAuditHistoryAndEndIfForThreeIfStatements);

            List<string> ifDeletingHeader = new List<string>()
            {
              "  IF DELETING",
              "  THEN",
	          "    SELECT AUDIT_TABLE_ID, AUDIT_INDICATOR",
	          "    INTO vAudit_Table_Id, vAudit_Ind",
	          "    FROM AUDIT_TABLE",
	          "    WHERE AUDIT_TABLE_NAME='" + tableName + "';",
	          "    -- Only create an Audit Record if auditing is turned on for the " + tableName + " table",
	          "    IF vAudit_Ind = 'Y'",
	          "    THEN",
		      "        -- Write a record to the AUDIT_HISTORY table:",
		      "        -- AUDIT_ID",
		      "        -- AUDIT_TABLE_ID",
		      "        -- AUDIT_DATE",
		      "        -- USER_ID",
		      "        -- WHAT_CHANGED",
		      "        -- AUDIT_ACTION",
		      "        -- COMMENTS",
		      "        -- COMPANY_ID",
		      "        --",
		      "        -- Use the supplied :OLD.AUDIT_ID and other OLD variables.",
		      "        -- Note: we do not have a User ID as the only one available is",
		      "        --       the database connection User ID, which is a generic one.",
            };

            auditTriggerText.AddRange(ifDeletingHeader);

            List<string> whatChangedTextForDeletion = new List<string>();
            foreach (string columnName in columnNames)
            {
                string columnNameToUpper = columnName.ToUpper();

                if (columnNameToUpper == "AUDIT_ID")
                    continue;

                if (columnName == columnNames[0].ToUpper() && columnNames.Count == 1)
                {
                    whatChangedTextForDeletion.Add("    vWhat_Changed := '" + columnNameToUpper + "='	||:OLD." + columnNameToUpper);
                    continue;
                }
                else if (columnName == columnNames[0].ToUpper() && columnNames.Count >= 2)
                {
                    whatChangedTextForDeletion.Add("    vWhat_Changed := '" + columnNameToUpper + "='	||:OLD." + columnNameToUpper + " ||");
                    continue;
                }

                whatChangedTextForDeletion.Add("        '," + columnNameToUpper + "='		||:OLD." + columnNameToUpper);

                if (columnName != columnNames[columnNames.Count - 1].ToUpper())
                    whatChangedTextForDeletion.Add("        ||");
                else
                    whatChangedTextForDeletion.Add("        ;");

            }

            auditTriggerText.AddRange(whatChangedTextForDeletion);

            List<string> ifDeletingFooter;

            if (foundCompanyIDColumn)
            {
                ifDeletingFooter = new List<string>()
                {
		        "        INSERT INTO AUDIT_HISTORY",
		        "          (AUDIT_TABLE_ID,AUDIT_ID,AUDIT_DATE,USER_ID,AUDIT_ACTION,WHAT_CHANGED,COMMENTS,COMPANY_ID)",
		        "        VALUES",
		        "          (vAudit_Table_Id,:OLD.AUDIT_ID,SYSDATE,NULL,'D',vWhat_Changed,'" + tableName + " deletion',:OLD.COMPANY_ID);",
	            "    END IF; --IF vAudit_Ind = 'Y'",
                "  END IF; --IF DELETING",
                };
            }
            else
            {
                ifDeletingFooter = new List<string>()
                {
		        "        INSERT INTO AUDIT_HISTORY",
		        "          (AUDIT_TABLE_ID,AUDIT_ID,AUDIT_DATE,USER_ID,AUDIT_ACTION,WHAT_CHANGED,COMMENTS,COMPANY_ID)",
		        "        VALUES",
		        "          (vAudit_Table_Id,:OLD.AUDIT_ID,SYSDATE,NULL,'D',vWhat_Changed,'" + tableName + " deletion',NULL);",
	            "    END IF; --IF vAudit_Ind = 'Y'",
                "  END IF; --IF DELETING",
                };
            }

            auditTriggerText.AddRange(ifDeletingFooter);

            List<string> auditFooter = new List<string>()
            {
                "  EXCEPTION",
                "  WHEN AUDIT_ID_CHANGED THEN",
	            "  DBMS_OUTPUT.PUT_LINE('Audit ID attempted to be changed on update');",
	            "  RAISE_APPLICATION_ERROR(-20000, 'AUDIT ID attempted To be changed ON UPDATE');",
	            "  ROLLBACK WORK;",
	            "  WHEN OTHERS THEN",
		        "      -- Consider logging the error and then re-raise",
	            "  RAISE;",
                "END ;",
                "/",
                "",
                "",
            };

            auditTriggerText.AddRange(auditFooter);

            return auditTriggerText;
        }

        private List<string> GetSQLScriptHeader()
        {
            return new List<string>()
            {
                "SET echo ON;",
                "SET feedback ON;",
                "SET verify off;",
                "SET wrap off;",
                "SET serveroutput ON SIZE 100000;",
                "SET linesize 999;",
                "SET pagesize 5000;",
                "",
                "",
                "--LOG FILE NAME & LOCATION...",
                "spool &logLocation\\" + GetFileName().Replace(".sql", "") + ".log;",
                "",
                "",
                "-- INSERT THE SQL CODE BELOW",
                "",
            };
        }

        private List<string> GetSQLScriptFooter()
        {
            return new List<string>()
            {
                "commit;",
                "",
                "spool off;",
            };
        }

        #endregion Audit String Creation Functions

        #endregion Helper Functions
    }
}
