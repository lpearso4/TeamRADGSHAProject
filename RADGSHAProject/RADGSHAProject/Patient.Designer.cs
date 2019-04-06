namespace RADGSHAProject
{
    partial class Patient
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
            this.useInventoryButton = new System.Windows.Forms.Button();
            this.changeRoomButton = new System.Windows.Forms.Button();
            this.diagnosisWizardButton = new System.Windows.Forms.Button();
            this.PatientGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.PatientLastNameLabel = new System.Windows.Forms.Label();
            this.PatientMiddleInitialTextBox = new System.Windows.Forms.TextBox();
            this.PatientMiddleInitialLabel = new System.Windows.Forms.Label();
            this.PatientFirstNameLabel = new System.Windows.Forms.Label();
            this.patientFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.VisitGroupBox = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.RoomNumberLabel = new System.Windows.Forms.Label();
            this.EntryDateLabel = new System.Windows.Forms.Label();
            this.EntryDatePicker = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DiagnosisLabel = new System.Windows.Forms.Label();
            this.VisitDiagnosisTextBox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.VisitSymptomsLabel = new System.Windows.Forms.Label();
            this.PatientGroupBox.SuspendLayout();
            this.VisitGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // useInventoryButton
            // 
            this.useInventoryButton.Location = new System.Drawing.Point(468, 639);
            this.useInventoryButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.useInventoryButton.Name = "useInventoryButton";
            this.useInventoryButton.Size = new System.Drawing.Size(116, 28);
            this.useInventoryButton.TabIndex = 0;
            this.useInventoryButton.Text = "Use Inventory";
            this.useInventoryButton.UseVisualStyleBackColor = true;
            this.useInventoryButton.Click += new System.EventHandler(this.useInventoryButton_Click);
            // 
            // changeRoomButton
            // 
            this.changeRoomButton.Location = new System.Drawing.Point(329, 639);
            this.changeRoomButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.changeRoomButton.Name = "changeRoomButton";
            this.changeRoomButton.Size = new System.Drawing.Size(113, 28);
            this.changeRoomButton.TabIndex = 1;
            this.changeRoomButton.Text = "Change Room";
            this.changeRoomButton.UseVisualStyleBackColor = true;
            this.changeRoomButton.Click += new System.EventHandler(this.changeRoomButton_Click);
            // 
            // diagnosisWizardButton
            // 
            this.diagnosisWizardButton.Location = new System.Drawing.Point(608, 639);
            this.diagnosisWizardButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.diagnosisWizardButton.Name = "diagnosisWizardButton";
            this.diagnosisWizardButton.Size = new System.Drawing.Size(135, 28);
            this.diagnosisWizardButton.TabIndex = 2;
            this.diagnosisWizardButton.Text = "Diagnosis Wizard";
            this.diagnosisWizardButton.UseVisualStyleBackColor = true;
            this.diagnosisWizardButton.Click += new System.EventHandler(this.diagnosisWizardButton_Click);
            // 
            // PatientGroupBox
            // 
            this.PatientGroupBox.Controls.Add(this.textBox1);
            this.PatientGroupBox.Controls.Add(this.PatientLastNameLabel);
            this.PatientGroupBox.Controls.Add(this.PatientMiddleInitialTextBox);
            this.PatientGroupBox.Controls.Add(this.PatientMiddleInitialLabel);
            this.PatientGroupBox.Controls.Add(this.PatientFirstNameLabel);
            this.PatientGroupBox.Controls.Add(this.patientFirstNameTextBox);
            this.PatientGroupBox.Location = new System.Drawing.Point(221, 20);
            this.PatientGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatientGroupBox.Name = "PatientGroupBox";
            this.PatientGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatientGroupBox.Size = new System.Drawing.Size(835, 153);
            this.PatientGroupBox.TabIndex = 6;
            this.PatientGroupBox.TabStop = false;
            this.PatientGroupBox.Text = "Patient Info";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(668, 32);
            this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(153, 22);
            this.textBox1.TabIndex = 5;
            // 
            // PatientLastNameLabel
            // 
            this.PatientLastNameLabel.AutoSize = true;
            this.PatientLastNameLabel.Location = new System.Drawing.Point(581, 35);
            this.PatientLastNameLabel.Name = "PatientLastNameLabel";
            this.PatientLastNameLabel.Size = new System.Drawing.Size(80, 17);
            this.PatientLastNameLabel.TabIndex = 4;
            this.PatientLastNameLabel.Text = "Last Name:";
            // 
            // PatientMiddleInitialTextBox
            // 
            this.PatientMiddleInitialTextBox.Location = new System.Drawing.Point(399, 31);
            this.PatientMiddleInitialTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatientMiddleInitialTextBox.Name = "PatientMiddleInitialTextBox";
            this.PatientMiddleInitialTextBox.Size = new System.Drawing.Size(153, 22);
            this.PatientMiddleInitialTextBox.TabIndex = 3;
            // 
            // PatientMiddleInitialLabel
            // 
            this.PatientMiddleInitialLabel.AutoSize = true;
            this.PatientMiddleInitialLabel.Location = new System.Drawing.Point(304, 35);
            this.PatientMiddleInitialLabel.Name = "PatientMiddleInitialLabel";
            this.PatientMiddleInitialLabel.Size = new System.Drawing.Size(89, 17);
            this.PatientMiddleInitialLabel.TabIndex = 2;
            this.PatientMiddleInitialLabel.Text = "Middle Initial:";
            // 
            // PatientFirstNameLabel
            // 
            this.PatientFirstNameLabel.AutoSize = true;
            this.PatientFirstNameLabel.Location = new System.Drawing.Point(22, 36);
            this.PatientFirstNameLabel.Name = "PatientFirstNameLabel";
            this.PatientFirstNameLabel.Size = new System.Drawing.Size(80, 17);
            this.PatientFirstNameLabel.TabIndex = 1;
            this.PatientFirstNameLabel.Text = "First Name:";
            // 
            // patientFirstNameTextBox
            // 
            this.patientFirstNameTextBox.Location = new System.Drawing.Point(109, 33);
            this.patientFirstNameTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.patientFirstNameTextBox.Name = "patientFirstNameTextBox";
            this.patientFirstNameTextBox.Size = new System.Drawing.Size(153, 22);
            this.patientFirstNameTextBox.TabIndex = 0;
            // 
            // VisitGroupBox
            // 
            this.VisitGroupBox.Controls.Add(this.VisitSymptomsLabel);
            this.VisitGroupBox.Controls.Add(this.textBox2);
            this.VisitGroupBox.Controls.Add(this.VisitDiagnosisTextBox);
            this.VisitGroupBox.Controls.Add(this.DiagnosisLabel);
            this.VisitGroupBox.Controls.Add(this.comboBox1);
            this.VisitGroupBox.Controls.Add(this.RoomNumberLabel);
            this.VisitGroupBox.Controls.Add(this.EntryDateLabel);
            this.VisitGroupBox.Controls.Add(this.EntryDatePicker);
            this.VisitGroupBox.Location = new System.Drawing.Point(221, 190);
            this.VisitGroupBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VisitGroupBox.Name = "VisitGroupBox";
            this.VisitGroupBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VisitGroupBox.Size = new System.Drawing.Size(835, 164);
            this.VisitGroupBox.TabIndex = 7;
            this.VisitGroupBox.TabStop = false;
            this.VisitGroupBox.Text = "Visit Info";
            // 
            // comboBox1
            // 
            this.comboBox1.Enabled = false;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(572, 38);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(199, 24);
            this.comboBox1.TabIndex = 3;
            // 
            // RoomNumberLabel
            // 
            this.RoomNumberLabel.AutoSize = true;
            this.RoomNumberLabel.Location = new System.Drawing.Point(462, 38);
            this.RoomNumberLabel.Name = "RoomNumberLabel";
            this.RoomNumberLabel.Size = new System.Drawing.Size(103, 17);
            this.RoomNumberLabel.TabIndex = 2;
            this.RoomNumberLabel.Text = "Room Number:";
            // 
            // EntryDateLabel
            // 
            this.EntryDateLabel.AutoSize = true;
            this.EntryDateLabel.Location = new System.Drawing.Point(22, 38);
            this.EntryDateLabel.Name = "EntryDateLabel";
            this.EntryDateLabel.Size = new System.Drawing.Size(79, 17);
            this.EntryDateLabel.TabIndex = 1;
            this.EntryDateLabel.Text = "Entry Date:";
            // 
            // EntryDatePicker
            // 
            this.EntryDatePicker.Enabled = false;
            this.EntryDatePicker.Location = new System.Drawing.Point(109, 38);
            this.EntryDatePicker.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.EntryDatePicker.Name = "EntryDatePicker";
            this.EntryDatePicker.Size = new System.Drawing.Size(241, 22);
            this.EntryDatePicker.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(768, 639);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(128, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Check In/Out";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(919, 639);
            this.SaveButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(100, 28);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(221, 439);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(835, 154);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Previous Visit Info";
            // 
            // DiagnosisLabel
            // 
            this.DiagnosisLabel.AutoSize = true;
            this.DiagnosisLabel.Location = new System.Drawing.Point(25, 127);
            this.DiagnosisLabel.Name = "DiagnosisLabel";
            this.DiagnosisLabel.Size = new System.Drawing.Size(74, 17);
            this.DiagnosisLabel.TabIndex = 4;
            this.DiagnosisLabel.Text = "Diagnosis:";
            // 
            // VisitDiagnosisTextBox
            // 
            this.VisitDiagnosisTextBox.Location = new System.Drawing.Point(109, 127);
            this.VisitDiagnosisTextBox.Name = "VisitDiagnosisTextBox";
            this.VisitDiagnosisTextBox.Size = new System.Drawing.Size(284, 22);
            this.VisitDiagnosisTextBox.TabIndex = 5;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(108, 67);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(662, 54);
            this.textBox2.TabIndex = 6;
            // 
            // VisitSymptomsLabel
            // 
            this.VisitSymptomsLabel.AutoSize = true;
            this.VisitSymptomsLabel.Location = new System.Drawing.Point(25, 67);
            this.VisitSymptomsLabel.Name = "VisitSymptomsLabel";
            this.VisitSymptomsLabel.Size = new System.Drawing.Size(77, 17);
            this.VisitSymptomsLabel.TabIndex = 7;
            this.VisitSymptomsLabel.Text = "Symptoms:";
            // 
            // Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 682);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.VisitGroupBox);
            this.Controls.Add(this.PatientGroupBox);
            this.Controls.Add(this.diagnosisWizardButton);
            this.Controls.Add(this.changeRoomButton);
            this.Controls.Add(this.useInventoryButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Patient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.Patient_Load);
            this.Click += new System.EventHandler(this.diagnosisWizardButton_Click);
            this.Controls.SetChildIndex(this.useInventoryButton, 0);
            this.Controls.SetChildIndex(this.changeRoomButton, 0);
            this.Controls.SetChildIndex(this.diagnosisWizardButton, 0);
            this.Controls.SetChildIndex(this.PatientGroupBox, 0);
            this.Controls.SetChildIndex(this.VisitGroupBox, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.SaveButton, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.PatientGroupBox.ResumeLayout(false);
            this.PatientGroupBox.PerformLayout();
            this.VisitGroupBox.ResumeLayout(false);
            this.VisitGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button useInventoryButton;
        private System.Windows.Forms.Button changeRoomButton;
        private System.Windows.Forms.Button diagnosisWizardButton;
        private System.Windows.Forms.GroupBox PatientGroupBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label PatientLastNameLabel;
        private System.Windows.Forms.TextBox PatientMiddleInitialTextBox;
        private System.Windows.Forms.Label PatientMiddleInitialLabel;
        private System.Windows.Forms.Label PatientFirstNameLabel;
        private System.Windows.Forms.TextBox patientFirstNameTextBox;
        private System.Windows.Forms.GroupBox VisitGroupBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label RoomNumberLabel;
        private System.Windows.Forms.Label EntryDateLabel;
        private System.Windows.Forms.DateTimePicker EntryDatePicker;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label VisitSymptomsLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox VisitDiagnosisTextBox;
        private System.Windows.Forms.Label DiagnosisLabel;
    }
}