namespace RADGSHAProject
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
            this.SuspendLayout();
            // 
            // chooseFileButton
            // 
            this.chooseFileButton.Location = new System.Drawing.Point(711, 51);
            this.chooseFileButton.Name = "chooseFileButton";
            this.chooseFileButton.Size = new System.Drawing.Size(98, 22);
            this.chooseFileButton.TabIndex = 0;
            this.chooseFileButton.Text = "Choose File";
            this.chooseFileButton.UseVisualStyleBackColor = true;
            this.chooseFileButton.Click += new System.EventHandler(this.chooseFileButton_Click);
            // 
            // DirectoryInputField
            // 
            this.DirectoryInputField.Location = new System.Drawing.Point(182, 51);
            this.DirectoryInputField.Name = "DirectoryInputField";
            this.DirectoryInputField.Size = new System.Drawing.Size(523, 22);
            this.DirectoryInputField.TabIndex = 1;
            // 
            // importDataButton
            // 
            this.importDataButton.Location = new System.Drawing.Point(815, 248);
            this.importDataButton.Name = "importDataButton";
            this.importDataButton.Size = new System.Drawing.Size(240, 51);
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
            this.DataImportType.Location = new System.Drawing.Point(815, 51);
            this.DataImportType.Name = "DataImportType";
            this.DataImportType.Size = new System.Drawing.Size(240, 191);
            this.DataImportType.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // ImportTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.DataImportType);
            this.Controls.Add(this.importDataButton);
            this.Controls.Add(this.DirectoryInputField);
            this.Controls.Add(this.chooseFileButton);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ImportTool";
            this.Text = "ImportTool";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button chooseFileButton;
        private System.Windows.Forms.TextBox DirectoryInputField;
        private System.Windows.Forms.Button importDataButton;
        private System.Windows.Forms.CheckedListBox DataImportType;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}