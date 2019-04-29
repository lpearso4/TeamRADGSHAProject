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
            this.patientZipTextBox = new System.Windows.Forms.TextBox();
            this.zipcodeLabel = new System.Windows.Forms.Label();
            this.patientStateTextBox = new System.Windows.Forms.TextBox();
            this.stateLabel = new System.Windows.Forms.Label();
            this.cityLabel = new System.Windows.Forms.Label();
            this.patientCityTextBox = new System.Windows.Forms.TextBox();
            this.patientAddressLine1TextBox = new System.Windows.Forms.TextBox();
            this.patientAddressLine2TextBox = new System.Windows.Forms.TextBox();
            this.addressLine2Label = new System.Windows.Forms.Label();
            this.addressLine1Label = new System.Windows.Forms.Label();
            this.patientLastNameTextBox = new System.Windows.Forms.TextBox();
            this.PatientLastNameLabel = new System.Windows.Forms.Label();
            this.PatientMiddleInitialTextBox = new System.Windows.Forms.TextBox();
            this.PatientMiddleInitialLabel = new System.Windows.Forms.Label();
            this.PatientFirstNameLabel = new System.Windows.Forms.Label();
            this.patientFirstNameTextBox = new System.Windows.Forms.TextBox();
            this.VisitGroupBox = new System.Windows.Forms.GroupBox();
            this.textAttendingPhy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.VisitSymptomsLabel = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.VisitDiagnosisTextBox = new System.Windows.Forms.TextBox();
            this.DiagnosisLabel = new System.Windows.Forms.Label();
            this.roomNumber = new System.Windows.Forms.ComboBox();
            this.RoomNumberLabel = new System.Windows.Forms.Label();
            this.EntryDateLabel = new System.Windows.Forms.Label();
            this.EntryDatePicker = new System.Windows.Forms.DateTimePicker();
            this.checkInOutButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PatientGroupBox.SuspendLayout();
            this.VisitGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // useInventoryButton
            // 
            this.useInventoryButton.Location = new System.Drawing.Point(351, 519);
            this.useInventoryButton.Name = "useInventoryButton";
            this.useInventoryButton.Size = new System.Drawing.Size(87, 23);
            this.useInventoryButton.TabIndex = 0;
            this.useInventoryButton.Text = "Use Inventory";
            this.useInventoryButton.UseVisualStyleBackColor = true;
            this.useInventoryButton.Click += new System.EventHandler(this.useInventoryButton_Click);
            // 
            // changeRoomButton
            // 
            this.changeRoomButton.Location = new System.Drawing.Point(247, 519);
            this.changeRoomButton.Name = "changeRoomButton";
            this.changeRoomButton.Size = new System.Drawing.Size(85, 23);
            this.changeRoomButton.TabIndex = 1;
            this.changeRoomButton.Text = "Change Room";
            this.changeRoomButton.UseVisualStyleBackColor = true;
            this.changeRoomButton.Click += new System.EventHandler(this.changeRoomButton_Click);
            // 
            // diagnosisWizardButton
            // 
            this.diagnosisWizardButton.Location = new System.Drawing.Point(456, 519);
            this.diagnosisWizardButton.Name = "diagnosisWizardButton";
            this.diagnosisWizardButton.Size = new System.Drawing.Size(101, 23);
            this.diagnosisWizardButton.TabIndex = 2;
            this.diagnosisWizardButton.Text = "Diagnosis Wizard";
            this.diagnosisWizardButton.UseVisualStyleBackColor = true;
            this.diagnosisWizardButton.Click += new System.EventHandler(this.diagnosisWizardButton_Click);
            // 
            // PatientGroupBox
            // 
            this.PatientGroupBox.Controls.Add(this.patientZipTextBox);
            this.PatientGroupBox.Controls.Add(this.zipcodeLabel);
            this.PatientGroupBox.Controls.Add(this.patientStateTextBox);
            this.PatientGroupBox.Controls.Add(this.stateLabel);
            this.PatientGroupBox.Controls.Add(this.cityLabel);
            this.PatientGroupBox.Controls.Add(this.patientCityTextBox);
            this.PatientGroupBox.Controls.Add(this.patientAddressLine1TextBox);
            this.PatientGroupBox.Controls.Add(this.patientAddressLine2TextBox);
            this.PatientGroupBox.Controls.Add(this.addressLine2Label);
            this.PatientGroupBox.Controls.Add(this.addressLine1Label);
            this.PatientGroupBox.Controls.Add(this.patientLastNameTextBox);
            this.PatientGroupBox.Controls.Add(this.PatientLastNameLabel);
            this.PatientGroupBox.Controls.Add(this.PatientMiddleInitialTextBox);
            this.PatientGroupBox.Controls.Add(this.PatientMiddleInitialLabel);
            this.PatientGroupBox.Controls.Add(this.PatientFirstNameLabel);
            this.PatientGroupBox.Controls.Add(this.patientFirstNameTextBox);
            this.PatientGroupBox.Location = new System.Drawing.Point(166, 16);
            this.PatientGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.PatientGroupBox.Name = "PatientGroupBox";
            this.PatientGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.PatientGroupBox.Size = new System.Drawing.Size(626, 124);
            this.PatientGroupBox.TabIndex = 6;
            this.PatientGroupBox.TabStop = false;
            this.PatientGroupBox.Text = "Patient Info";
            // 
            // patientZipTextBox
            // 
            this.patientZipTextBox.Location = new System.Drawing.Point(501, 86);
            this.patientZipTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.patientZipTextBox.Name = "patientZipTextBox";
            this.patientZipTextBox.Size = new System.Drawing.Size(116, 20);
            this.patientZipTextBox.TabIndex = 18;
            // 
            // zipcodeLabel
            // 
            this.zipcodeLabel.AutoSize = true;
            this.zipcodeLabel.Location = new System.Drawing.Point(436, 88);
            this.zipcodeLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.zipcodeLabel.Name = "zipcodeLabel";
            this.zipcodeLabel.Size = new System.Drawing.Size(49, 13);
            this.zipcodeLabel.TabIndex = 17;
            this.zipcodeLabel.Text = "Zipcode:";
            // 
            // patientStateTextBox
            // 
            this.patientStateTextBox.Location = new System.Drawing.Point(360, 87);
            this.patientStateTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.patientStateTextBox.Name = "patientStateTextBox";
            this.patientStateTextBox.Size = new System.Drawing.Size(42, 20);
            this.patientStateTextBox.TabIndex = 16;
            // 
            // stateLabel
            // 
            this.stateLabel.AutoSize = true;
            this.stateLabel.Location = new System.Drawing.Point(277, 90);
            this.stateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.stateLabel.Name = "stateLabel";
            this.stateLabel.Size = new System.Drawing.Size(35, 13);
            this.stateLabel.TabIndex = 15;
            this.stateLabel.Text = "State:";
            // 
            // cityLabel
            // 
            this.cityLabel.AutoSize = true;
            this.cityLabel.Location = new System.Drawing.Point(17, 89);
            this.cityLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.cityLabel.Name = "cityLabel";
            this.cityLabel.Size = new System.Drawing.Size(27, 13);
            this.cityLabel.TabIndex = 14;
            this.cityLabel.Text = "City:";
            // 
            // patientCityTextBox
            // 
            this.patientCityTextBox.Location = new System.Drawing.Point(98, 87);
            this.patientCityTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.patientCityTextBox.Name = "patientCityTextBox";
            this.patientCityTextBox.Size = new System.Drawing.Size(149, 20);
            this.patientCityTextBox.TabIndex = 13;
            // 
            // patientAddressLine1TextBox
            // 
            this.patientAddressLine1TextBox.Location = new System.Drawing.Point(98, 57);
            this.patientAddressLine1TextBox.Name = "patientAddressLine1TextBox";
            this.patientAddressLine1TextBox.Size = new System.Drawing.Size(149, 20);
            this.patientAddressLine1TextBox.TabIndex = 11;
            // 
            // patientAddressLine2TextBox
            // 
            this.patientAddressLine2TextBox.Location = new System.Drawing.Point(360, 57);
            this.patientAddressLine2TextBox.Name = "patientAddressLine2TextBox";
            this.patientAddressLine2TextBox.Size = new System.Drawing.Size(137, 20);
            this.patientAddressLine2TextBox.TabIndex = 12;
            // 
            // addressLine2Label
            // 
            this.addressLine2Label.AutoSize = true;
            this.addressLine2Label.Location = new System.Drawing.Point(277, 63);
            this.addressLine2Label.Name = "addressLine2Label";
            this.addressLine2Label.Size = new System.Drawing.Size(80, 13);
            this.addressLine2Label.TabIndex = 7;
            this.addressLine2Label.Text = "Address Line 2:";
            // 
            // addressLine1Label
            // 
            this.addressLine1Label.AutoSize = true;
            this.addressLine1Label.Location = new System.Drawing.Point(16, 63);
            this.addressLine1Label.Name = "addressLine1Label";
            this.addressLine1Label.Size = new System.Drawing.Size(80, 13);
            this.addressLine1Label.TabIndex = 6;
            this.addressLine1Label.Text = "Address Line 1:";
            // 
            // patientLastNameTextBox
            // 
            this.patientLastNameTextBox.Location = new System.Drawing.Point(501, 26);
            this.patientLastNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.patientLastNameTextBox.Name = "patientLastNameTextBox";
            this.patientLastNameTextBox.Size = new System.Drawing.Size(116, 20);
            this.patientLastNameTextBox.TabIndex = 5;
            // 
            // PatientLastNameLabel
            // 
            this.PatientLastNameLabel.AutoSize = true;
            this.PatientLastNameLabel.Location = new System.Drawing.Point(436, 28);
            this.PatientLastNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PatientLastNameLabel.Name = "PatientLastNameLabel";
            this.PatientLastNameLabel.Size = new System.Drawing.Size(61, 13);
            this.PatientLastNameLabel.TabIndex = 4;
            this.PatientLastNameLabel.Text = "Last Name:";
            // 
            // PatientMiddleInitialTextBox
            // 
            this.PatientMiddleInitialTextBox.Location = new System.Drawing.Point(360, 27);
            this.PatientMiddleInitialTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.PatientMiddleInitialTextBox.Name = "PatientMiddleInitialTextBox";
            this.PatientMiddleInitialTextBox.Size = new System.Drawing.Size(42, 20);
            this.PatientMiddleInitialTextBox.TabIndex = 3;
            // 
            // PatientMiddleInitialLabel
            // 
            this.PatientMiddleInitialLabel.AutoSize = true;
            this.PatientMiddleInitialLabel.Location = new System.Drawing.Point(277, 30);
            this.PatientMiddleInitialLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PatientMiddleInitialLabel.Name = "PatientMiddleInitialLabel";
            this.PatientMiddleInitialLabel.Size = new System.Drawing.Size(68, 13);
            this.PatientMiddleInitialLabel.TabIndex = 2;
            this.PatientMiddleInitialLabel.Text = "Middle Initial:";
            // 
            // PatientFirstNameLabel
            // 
            this.PatientFirstNameLabel.AutoSize = true;
            this.PatientFirstNameLabel.Location = new System.Drawing.Point(16, 29);
            this.PatientFirstNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.PatientFirstNameLabel.Name = "PatientFirstNameLabel";
            this.PatientFirstNameLabel.Size = new System.Drawing.Size(60, 13);
            this.PatientFirstNameLabel.TabIndex = 1;
            this.PatientFirstNameLabel.Text = "First Name:";
            // 
            // patientFirstNameTextBox
            // 
            this.patientFirstNameTextBox.Location = new System.Drawing.Point(98, 27);
            this.patientFirstNameTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.patientFirstNameTextBox.Name = "patientFirstNameTextBox";
            this.patientFirstNameTextBox.Size = new System.Drawing.Size(149, 20);
            this.patientFirstNameTextBox.TabIndex = 0;
            // 
            // VisitGroupBox
            // 
            this.VisitGroupBox.Controls.Add(this.textAttendingPhy);
            this.VisitGroupBox.Controls.Add(this.label1);
            this.VisitGroupBox.Controls.Add(this.VisitSymptomsLabel);
            this.VisitGroupBox.Controls.Add(this.textBox2);
            this.VisitGroupBox.Controls.Add(this.VisitDiagnosisTextBox);
            this.VisitGroupBox.Controls.Add(this.DiagnosisLabel);
            this.VisitGroupBox.Controls.Add(this.roomNumber);
            this.VisitGroupBox.Controls.Add(this.RoomNumberLabel);
            this.VisitGroupBox.Controls.Add(this.EntryDateLabel);
            this.VisitGroupBox.Controls.Add(this.EntryDatePicker);
            this.VisitGroupBox.Location = new System.Drawing.Point(166, 154);
            this.VisitGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.VisitGroupBox.Name = "VisitGroupBox";
            this.VisitGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.VisitGroupBox.Size = new System.Drawing.Size(626, 133);
            this.VisitGroupBox.TabIndex = 7;
            this.VisitGroupBox.TabStop = false;
            this.VisitGroupBox.Text = "Visit Info";
            this.VisitGroupBox.Enter += new System.EventHandler(this.VisitGroupBox_Enter);
            // 
            // textAttendingPhy
            // 
            this.textAttendingPhy.Location = new System.Drawing.Point(406, 103);
            this.textAttendingPhy.Name = "textAttendingPhy";
            this.textAttendingPhy.Size = new System.Drawing.Size(100, 20);
            this.textAttendingPhy.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Attending Physician:";
            // 
            // VisitSymptomsLabel
            // 
            this.VisitSymptomsLabel.AutoSize = true;
            this.VisitSymptomsLabel.Location = new System.Drawing.Point(19, 54);
            this.VisitSymptomsLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.VisitSymptomsLabel.Name = "VisitSymptomsLabel";
            this.VisitSymptomsLabel.Size = new System.Drawing.Size(58, 13);
            this.VisitSymptomsLabel.TabIndex = 7;
            this.VisitSymptomsLabel.Text = "Symptoms:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(81, 54);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(498, 45);
            this.textBox2.TabIndex = 6;
            // 
            // VisitDiagnosisTextBox
            // 
            this.VisitDiagnosisTextBox.Location = new System.Drawing.Point(82, 103);
            this.VisitDiagnosisTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.VisitDiagnosisTextBox.Name = "VisitDiagnosisTextBox";
            this.VisitDiagnosisTextBox.Size = new System.Drawing.Size(214, 20);
            this.VisitDiagnosisTextBox.TabIndex = 5;
            // 
            // DiagnosisLabel
            // 
            this.DiagnosisLabel.AutoSize = true;
            this.DiagnosisLabel.Location = new System.Drawing.Point(19, 103);
            this.DiagnosisLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DiagnosisLabel.Name = "DiagnosisLabel";
            this.DiagnosisLabel.Size = new System.Drawing.Size(56, 13);
            this.DiagnosisLabel.TabIndex = 4;
            this.DiagnosisLabel.Text = "Diagnosis:";
            // 
            // roomNumber
            // 
            this.roomNumber.Enabled = false;
            this.roomNumber.FormattingEnabled = true;
            this.roomNumber.Location = new System.Drawing.Point(429, 31);
            this.roomNumber.Margin = new System.Windows.Forms.Padding(2);
            this.roomNumber.Name = "roomNumber";
            this.roomNumber.Size = new System.Drawing.Size(150, 21);
            this.roomNumber.TabIndex = 3;
            // 
            // RoomNumberLabel
            // 
            this.RoomNumberLabel.AutoSize = true;
            this.RoomNumberLabel.Location = new System.Drawing.Point(346, 31);
            this.RoomNumberLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.RoomNumberLabel.Name = "RoomNumberLabel";
            this.RoomNumberLabel.Size = new System.Drawing.Size(78, 13);
            this.RoomNumberLabel.TabIndex = 2;
            this.RoomNumberLabel.Text = "Room Number:";
            // 
            // EntryDateLabel
            // 
            this.EntryDateLabel.AutoSize = true;
            this.EntryDateLabel.Location = new System.Drawing.Point(16, 31);
            this.EntryDateLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EntryDateLabel.Name = "EntryDateLabel";
            this.EntryDateLabel.Size = new System.Drawing.Size(60, 13);
            this.EntryDateLabel.TabIndex = 1;
            this.EntryDateLabel.Text = "Entry Date:";
            // 
            // EntryDatePicker
            // 
            this.EntryDatePicker.Enabled = false;
            this.EntryDatePicker.Location = new System.Drawing.Point(82, 31);
            this.EntryDatePicker.Margin = new System.Windows.Forms.Padding(2);
            this.EntryDatePicker.Name = "EntryDatePicker";
            this.EntryDatePicker.Size = new System.Drawing.Size(182, 20);
            this.EntryDatePicker.TabIndex = 0;
            // 
            // checkInOutButton
            // 
            this.checkInOutButton.Location = new System.Drawing.Point(576, 519);
            this.checkInOutButton.Name = "checkInOutButton";
            this.checkInOutButton.Size = new System.Drawing.Size(96, 23);
            this.checkInOutButton.TabIndex = 8;
            this.checkInOutButton.Text = "Check In";
            this.checkInOutButton.UseVisualStyleBackColor = true;
            this.checkInOutButton.Click += new System.EventHandler(this.checkInOutButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(689, 519);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 9;
            this.SaveButton.Text = "Edit";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(166, 357);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(626, 125);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Previous Visit Info";
            // 
            // Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.checkInOutButton);
            this.Controls.Add(this.VisitGroupBox);
            this.Controls.Add(this.PatientGroupBox);
            this.Controls.Add(this.diagnosisWizardButton);
            this.Controls.Add(this.changeRoomButton);
            this.Controls.Add(this.useInventoryButton);
            this.Margin = new System.Windows.Forms.Padding(3);
            this.Name = "Patient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Patient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.Patient_Load);
            this.Controls.SetChildIndex(this.useInventoryButton, 0);
            this.Controls.SetChildIndex(this.changeRoomButton, 0);
            this.Controls.SetChildIndex(this.diagnosisWizardButton, 0);
            this.Controls.SetChildIndex(this.PatientGroupBox, 0);
            this.Controls.SetChildIndex(this.VisitGroupBox, 0);
            this.Controls.SetChildIndex(this.checkInOutButton, 0);
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
        private System.Windows.Forms.TextBox patientLastNameTextBox;
        private System.Windows.Forms.Label PatientLastNameLabel;
        private System.Windows.Forms.TextBox PatientMiddleInitialTextBox;
        private System.Windows.Forms.Label PatientMiddleInitialLabel;
        private System.Windows.Forms.Label PatientFirstNameLabel;
        private System.Windows.Forms.TextBox patientFirstNameTextBox;
        private System.Windows.Forms.GroupBox VisitGroupBox;
        private System.Windows.Forms.ComboBox roomNumber;
        private System.Windows.Forms.Label RoomNumberLabel;
        private System.Windows.Forms.Label EntryDateLabel;
        private System.Windows.Forms.DateTimePicker EntryDatePicker;
        private System.Windows.Forms.Button checkInOutButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label VisitSymptomsLabel;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox VisitDiagnosisTextBox;
        private System.Windows.Forms.Label DiagnosisLabel;
        private System.Windows.Forms.TextBox patientZipTextBox;
        private System.Windows.Forms.Label zipcodeLabel;
        private System.Windows.Forms.TextBox patientStateTextBox;
        private System.Windows.Forms.Label stateLabel;
        private System.Windows.Forms.Label cityLabel;
        private System.Windows.Forms.TextBox patientCityTextBox;
        private System.Windows.Forms.TextBox patientAddressLine1TextBox;
        private System.Windows.Forms.TextBox patientAddressLine2TextBox;
        private System.Windows.Forms.Label addressLine2Label;
        private System.Windows.Forms.Label addressLine1Label;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textAttendingPhy;
    }
}