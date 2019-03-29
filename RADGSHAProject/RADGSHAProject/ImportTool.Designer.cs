﻿namespace RADGSHAProject
{
    partial class ImportTool
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
            this.chooseFileButton = new System.Windows.Forms.Button();
            this.DirectoryInputField = new System.Windows.Forms.TextBox();
            this.importDataButton = new System.Windows.Forms.Button();
            this.DataImportType = new System.Windows.Forms.CheckedListBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.searchPatientButton = new System.Windows.Forms.Button();
            this.addPatientButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(533, 41);
            this.chooseFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(74, 20);
            this.chooseFileButton.TabIndex = 0;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // DirectoryInputField
            // 
            this.DirectoryInputField.Location = new System.Drawing.Point(153, 41);
            this.DirectoryInputField.Margin = new System.Windows.Forms.Padding(2);
            this.DirectoryInputField.Name = "DirectoryInputField";
            this.DirectoryInputField.Size = new System.Drawing.Size(376, 20);
            this.DirectoryInputField.TabIndex = 1;
            // 
            // importDataButton
            // 
            this.importDataButton.Location = new System.Drawing.Point(611, 202);
            this.importDataButton.Margin = new System.Windows.Forms.Padding(2);
            this.importDataButton.Name = "importDataButton";
            this.importDataButton.Size = new System.Drawing.Size(180, 41);
            this.importDataButton.TabIndex = 2;
            this.importDataButton.Text = "IMPORT DATA";
            this.importDataButton.UseVisualStyleBackColor = true;
            this.importDataButton.Click += new System.EventHandler(this.importDataButton_Click);
            // 
            // DataImportType
            // 
            this.DataImportType.CheckOnClick = true;
            this.DataImportType.FormattingEnabled = true;
            this.DataImportType.Items.AddRange(new object[] {
            "Medical Records",
            "Inventory",
            "Rooms"});
            this.DataImportType.Location = new System.Drawing.Point(611, 41);
            this.DataImportType.Margin = new System.Windows.Forms.Padding(2);
            this.DataImportType.Name = "DataImportType";
            this.DataImportType.Size = new System.Drawing.Size(181, 154);
            this.DataImportType.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchPatientButton);
            this.groupBox1.Controls.Add(this.addPatientButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 426);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // searchPatientButton
            // 
            this.searchPatientButton.Location = new System.Drawing.Point(9, 16);
            this.searchPatientButton.Margin = new System.Windows.Forms.Padding(2);
            this.searchPatientButton.Name = "searchPatientButton";
            this.searchPatientButton.Size = new System.Drawing.Size(111, 26);
            this.searchPatientButton.TabIndex = 2;
            this.searchPatientButton.Text = "Search Patient";
            this.searchPatientButton.UseVisualStyleBackColor = true;
            // 
            // addPatientButton
            // 
            this.addPatientButton.Location = new System.Drawing.Point(9, 57);
            this.addPatientButton.Margin = new System.Windows.Forms.Padding(2);
            this.addPatientButton.Name = "addPatientButton";
            this.addPatientButton.Size = new System.Drawing.Size(111, 24);
            this.addPatientButton.TabIndex = 1;
            this.addPatientButton.Text = "Add Patient";
            this.addPatientButton.UseVisualStyleBackColor = true;
            // 
            // ImportTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.DataImportType);
            this.Controls.Add(this.importDataButton);
            this.Controls.Add(this.DirectoryInputField);
            this.Controls.Add(this.chooseFileButton);
            this.Name = "ImportTool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ImportTool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.TextBox DirectoryInputField;
        private System.Windows.Forms.Button importDataButton;
        private System.Windows.Forms.CheckedListBox DataImportType;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button searchPatientButton;
        private System.Windows.Forms.Button addPatientButton;
    }
}