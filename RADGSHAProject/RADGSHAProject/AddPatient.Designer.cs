namespace RADGSHAProject
{
    partial class AddPatient
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
            this.PatientGroupBox = new System.Windows.Forms.GroupBox();
            this.birthDate = new System.Windows.Forms.DateTimePicker();
            this.comboDonorStatus = new System.Windows.Forms.ComboBox();
            this.comboDNR = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.patientInsurer = new System.Windows.Forms.TextBox();
            this.patientSSN = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.genderBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.label1 = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.PatientGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PatientGroupBox
            // 
            this.PatientGroupBox.Controls.Add(this.birthDate);
            this.PatientGroupBox.Controls.Add(this.comboDonorStatus);
            this.PatientGroupBox.Controls.Add(this.comboDNR);
            this.PatientGroupBox.Controls.Add(this.label7);
            this.PatientGroupBox.Controls.Add(this.patientInsurer);
            this.PatientGroupBox.Controls.Add(this.patientSSN);
            this.PatientGroupBox.Controls.Add(this.label6);
            this.PatientGroupBox.Controls.Add(this.label5);
            this.PatientGroupBox.Controls.Add(this.label4);
            this.PatientGroupBox.Controls.Add(this.genderBox);
            this.PatientGroupBox.Controls.Add(this.label3);
            this.PatientGroupBox.Controls.Add(this.label2);
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
            this.PatientGroupBox.Location = new System.Drawing.Point(163, 32);
            this.PatientGroupBox.Margin = new System.Windows.Forms.Padding(2);
            this.PatientGroupBox.Name = "PatientGroupBox";
            this.PatientGroupBox.Padding = new System.Windows.Forms.Padding(2);
            this.PatientGroupBox.Size = new System.Drawing.Size(626, 202);
            this.PatientGroupBox.TabIndex = 7;
            this.PatientGroupBox.TabStop = false;
            this.PatientGroupBox.Text = "Patient Info";
            // 
            // birthDate
            // 
            this.birthDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.birthDate.Location = new System.Drawing.Point(510, 119);
            this.birthDate.Name = "birthDate";
            this.birthDate.Size = new System.Drawing.Size(88, 20);
            this.birthDate.TabIndex = 31;
            // 
            // comboDonorStatus
            // 
            this.comboDonorStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDonorStatus.FormattingEnabled = true;
            this.comboDonorStatus.Items.AddRange(new object[] {
            "True",
            "False",
            " "});
            this.comboDonorStatus.Location = new System.Drawing.Point(546, 151);
            this.comboDonorStatus.Name = "comboDonorStatus";
            this.comboDonorStatus.Size = new System.Drawing.Size(68, 21);
            this.comboDonorStatus.TabIndex = 30;
            // 
            // comboDNR
            // 
            this.comboDNR.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDNR.FormattingEnabled = true;
            this.comboDNR.Items.AddRange(new object[] {
            "True",
            "False",
            " "});
            this.comboDNR.Location = new System.Drawing.Point(344, 151);
            this.comboDNR.Name = "comboDNR";
            this.comboDNR.Size = new System.Drawing.Size(68, 21);
            this.comboDNR.TabIndex = 29;
            this.comboDNR.SelectedIndexChanged += new System.EventHandler(this.comboDNR_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "SSN:";
            // 
            // patientInsurer
            // 
            this.patientInsurer.Location = new System.Drawing.Point(98, 152);
            this.patientInsurer.Name = "patientInsurer";
            this.patientInsurer.Size = new System.Drawing.Size(149, 20);
            this.patientInsurer.TabIndex = 28;
            // 
            // patientSSN
            // 
            this.patientSSN.Location = new System.Drawing.Point(98, 118);
            this.patientSSN.Name = "patientSSN";
            this.patientSSN.Size = new System.Drawing.Size(149, 20);
            this.patientSSN.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(436, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 13);
            this.label6.TabIndex = 26;
            this.label6.Text = "Organ Donor Status:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(277, 155);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 13);
            this.label5.TabIndex = 25;
            this.label5.Text = "DNR Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Insurer:";
            // 
            // genderBox
            // 
            this.genderBox.Location = new System.Drawing.Point(360, 118);
            this.genderBox.Name = "genderBox";
            this.genderBox.Size = new System.Drawing.Size(42, 20);
            this.genderBox.TabIndex = 21;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Birthdate:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(277, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Gender:";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "SSN:";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(709, 321);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(85, 30);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(602, 321);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(85, 30);
            this.cancelButton.TabIndex = 9;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // AddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 363);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.PatientGroupBox);
            this.Name = "AddPatient";
            this.Text = "AddPatient";
            this.Controls.SetChildIndex(this.PatientGroupBox, 0);
            this.Controls.SetChildIndex(this.saveButton, 0);
            this.Controls.SetChildIndex(this.cancelButton, 0);
            this.PatientGroupBox.ResumeLayout(false);
            this.PatientGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PatientGroupBox;
        private System.Windows.Forms.TextBox genderBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.TextBox patientLastNameTextBox;
        private System.Windows.Forms.Label PatientLastNameLabel;
        private System.Windows.Forms.TextBox PatientMiddleInitialTextBox;
        private System.Windows.Forms.Label PatientMiddleInitialLabel;
        private System.Windows.Forms.Label PatientFirstNameLabel;
        private System.Windows.Forms.TextBox patientFirstNameTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox patientInsurer;
        private System.Windows.Forms.TextBox patientSSN;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ComboBox comboDNR;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboDonorStatus;
        private System.Windows.Forms.DateTimePicker birthDate;
    }
}