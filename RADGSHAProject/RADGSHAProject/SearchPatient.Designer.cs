namespace RADGSHAProject
{
    partial class SearchPatient
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
            this.viewPatientButton = new System.Windows.Forms.Button();
            this.PatientFirstNameField = new System.Windows.Forms.TextBox();
            this.PatientSSNField = new System.Windows.Forms.TextBox();
            this.VisitRoomNumberField = new System.Windows.Forms.TextBox();
            this.PatientListView = new System.Windows.Forms.ListView();
            this.FirstNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LastNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SSNColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RoomNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PatientFirstNameLabel = new System.Windows.Forms.Label();
            this.PatientSSNLabel = new System.Windows.Forms.Label();
            this.VisitRoomNumberLabel = new System.Windows.Forms.Label();
            this.PatientLastNameLabel = new System.Windows.Forms.Label();
            this.PatientLastNameField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // viewPatientButton
            // 
            this.viewPatientButton.Enabled = false;
            this.viewPatientButton.Location = new System.Drawing.Point(611, 389);
            this.viewPatientButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.viewPatientButton.Name = "viewPatientButton";
            this.viewPatientButton.Size = new System.Drawing.Size(139, 39);
            this.viewPatientButton.TabIndex = 0;
            this.viewPatientButton.Text = "Submit";
            this.viewPatientButton.UseVisualStyleBackColor = true;
            this.viewPatientButton.Click += new System.EventHandler(this.viewPatientButton_Click);
            // 
            // PatientFirstNameField
            // 
            this.PatientFirstNameField.Location = new System.Drawing.Point(309, 33);
            this.PatientFirstNameField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatientFirstNameField.Name = "PatientFirstNameField";
            this.PatientFirstNameField.Size = new System.Drawing.Size(284, 22);
            this.PatientFirstNameField.TabIndex = 1;
            this.PatientFirstNameField.TextChanged += new System.EventHandler(this.PatientNameField_TextChanged);
            // 
            // PatientSSNField
            // 
            this.PatientSSNField.Location = new System.Drawing.Point(309, 110);
            this.PatientSSNField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatientSSNField.Name = "PatientSSNField";
            this.PatientSSNField.Size = new System.Drawing.Size(284, 22);
            this.PatientSSNField.TabIndex = 2;
            this.PatientSSNField.TextChanged += new System.EventHandler(this.PatientSSNField_TextChanged);
            // 
            // VisitRoomNumberField
            // 
            this.VisitRoomNumberField.Location = new System.Drawing.Point(309, 146);
            this.VisitRoomNumberField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.VisitRoomNumberField.Name = "VisitRoomNumberField";
            this.VisitRoomNumberField.Size = new System.Drawing.Size(284, 22);
            this.VisitRoomNumberField.TabIndex = 3;
            this.VisitRoomNumberField.TextChanged += new System.EventHandler(this.VisitRoomNumberField_TextChanged);
            // 
            // PatientListView
            // 
            this.PatientListView.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.PatientListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FirstNameColumn,
            this.LastNameColumn,
            this.SSNColumn,
            this.RoomNumber});
            this.PatientListView.FullRowSelect = true;
            this.PatientListView.GridLines = true;
            this.PatientListView.Location = new System.Drawing.Point(195, 185);
            this.PatientListView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatientListView.Name = "PatientListView";
            this.PatientListView.Size = new System.Drawing.Size(577, 187);
            this.PatientListView.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.PatientListView.TabIndex = 1;
            this.PatientListView.Tag = "";
            this.PatientListView.TileSize = new System.Drawing.Size(20, 1);
            this.PatientListView.UseCompatibleStateImageBehavior = false;
            this.PatientListView.View = System.Windows.Forms.View.Details;
            this.PatientListView.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.PatientListView.Leave += new System.EventHandler(this.PatientListView_Leave);
            // 
            // FirstNameColumn
            // 
            this.FirstNameColumn.Text = "First Name";
            this.FirstNameColumn.Width = 120;
            // 
            // LastNameColumn
            // 
            this.LastNameColumn.Text = "Last Name";
            this.LastNameColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LastNameColumn.Width = 120;
            // 
            // SSNColumn
            // 
            this.SSNColumn.Text = "SSN";
            this.SSNColumn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SSNColumn.Width = 90;
            // 
            // RoomNumber
            // 
            this.RoomNumber.Text = "Room Number";
            this.RoomNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RoomNumber.Width = 90;
            // 
            // PatientFirstNameLabel
            // 
            this.PatientFirstNameLabel.AutoSize = true;
            this.PatientFirstNameLabel.Location = new System.Drawing.Point(192, 33);
            this.PatientFirstNameLabel.Name = "PatientFirstNameLabel";
            this.PatientFirstNameLabel.Size = new System.Drawing.Size(80, 17);
            this.PatientFirstNameLabel.TabIndex = 6;
            this.PatientFirstNameLabel.Text = "First Name:";
            // 
            // PatientSSNLabel
            // 
            this.PatientSSNLabel.AutoSize = true;
            this.PatientSSNLabel.Location = new System.Drawing.Point(192, 110);
            this.PatientSSNLabel.Name = "PatientSSNLabel";
            this.PatientSSNLabel.Size = new System.Drawing.Size(88, 17);
            this.PatientSSNLabel.TabIndex = 7;
            this.PatientSSNLabel.Text = "Patient SSN:";
            // 
            // VisitRoomNumberLabel
            // 
            this.VisitRoomNumberLabel.AutoSize = true;
            this.VisitRoomNumberLabel.Location = new System.Drawing.Point(192, 146);
            this.VisitRoomNumberLabel.Name = "VisitRoomNumberLabel";
            this.VisitRoomNumberLabel.Size = new System.Drawing.Size(103, 17);
            this.VisitRoomNumberLabel.TabIndex = 8;
            this.VisitRoomNumberLabel.Text = "Room Number:";
            // 
            // PatientLastNameLabel
            // 
            this.PatientLastNameLabel.AutoSize = true;
            this.PatientLastNameLabel.Location = new System.Drawing.Point(192, 70);
            this.PatientLastNameLabel.Name = "PatientLastNameLabel";
            this.PatientLastNameLabel.Size = new System.Drawing.Size(80, 17);
            this.PatientLastNameLabel.TabIndex = 10;
            this.PatientLastNameLabel.Text = "Last Name:";
            // 
            // PatientLastNameField
            // 
            this.PatientLastNameField.Location = new System.Drawing.Point(309, 70);
            this.PatientLastNameField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.PatientLastNameField.Name = "PatientLastNameField";
            this.PatientLastNameField.Size = new System.Drawing.Size(284, 22);
            this.PatientLastNameField.TabIndex = 9;
            this.PatientLastNameField.TextChanged += new System.EventHandler(this.PatientLastNameField_TextChanged);
            // 
            // SearchPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.PatientLastNameLabel);
            this.Controls.Add(this.PatientLastNameField);
            this.Controls.Add(this.VisitRoomNumberLabel);
            this.Controls.Add(this.PatientSSNLabel);
            this.Controls.Add(this.PatientFirstNameLabel);
            this.Controls.Add(this.PatientListView);
            this.Controls.Add(this.VisitRoomNumberField);
            this.Controls.Add(this.PatientSSNField);
            this.Controls.Add(this.PatientFirstNameField);
            this.Controls.Add(this.viewPatientButton);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SearchPatient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SearchPatient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button viewPatientButton;//after implementing the patient search functions, this button may not be necessary
        private System.Windows.Forms.TextBox PatientFirstNameField;
        private System.Windows.Forms.TextBox PatientSSNField;
        private System.Windows.Forms.TextBox VisitRoomNumberField;
        private System.Windows.Forms.ListView PatientListView;
        private System.Windows.Forms.Label PatientFirstNameLabel;
        private System.Windows.Forms.Label PatientSSNLabel;
        private System.Windows.Forms.Label VisitRoomNumberLabel;
        private System.Windows.Forms.ColumnHeader FirstNameColumn;
        private System.Windows.Forms.ColumnHeader LastNameColumn;
        private System.Windows.Forms.ColumnHeader SSNColumn;
        private System.Windows.Forms.ColumnHeader RoomNumber;
        private System.Windows.Forms.Label PatientLastNameLabel;
        private System.Windows.Forms.TextBox PatientLastNameField;
    }
}