﻿namespace RADGSHAProject
{
    partial class DiagnosisWizard
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Appetite Suppression",
            "20%"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Test Symptom",
            "1%"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Brain Fog",
            "100%"}, -1);
            this.QuestionLabel = new System.Windows.Forms.Label();
            this.PatientHasSymptomButton = new System.Windows.Forms.Button();
            this.PatientDoesNotHaveSymptomButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AddResultsToPatientButton = new System.Windows.Forms.Button();
            this.ReturnToPatientButton = new System.Windows.Forms.Button();
            this.SymptomListView = new System.Windows.Forms.ListView();
            this.symptomNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SymptomProbabilityColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // QuestionLabel
            // 
            this.QuestionLabel.AutoSize = true;
            this.QuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuestionLabel.Location = new System.Drawing.Point(146, 24);
            this.QuestionLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.QuestionLabel.Name = "QuestionLabel";
            this.QuestionLabel.Size = new System.Drawing.Size(344, 22);
            this.QuestionLabel.TabIndex = 6;
            this.QuestionLabel.Text = "Does PATIENT_NAME have SYMPTOM?";
            // 
            // PatientHasSymptomButton
            // 
            this.PatientHasSymptomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientHasSymptomButton.Location = new System.Drawing.Point(176, 58);
            this.PatientHasSymptomButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PatientHasSymptomButton.Name = "PatientHasSymptomButton";
            this.PatientHasSymptomButton.Size = new System.Drawing.Size(101, 42);
            this.PatientHasSymptomButton.TabIndex = 7;
            this.PatientHasSymptomButton.Text = "YES";
            this.PatientHasSymptomButton.UseVisualStyleBackColor = true;
            this.PatientHasSymptomButton.Click += new System.EventHandler(this.PatientHasSymptomButton_Click);
            // 
            // PatientDoesNotHaveSymptomButton
            // 
            this.PatientDoesNotHaveSymptomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientDoesNotHaveSymptomButton.Location = new System.Drawing.Point(320, 58);
            this.PatientDoesNotHaveSymptomButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.PatientDoesNotHaveSymptomButton.Name = "PatientDoesNotHaveSymptomButton";
            this.PatientDoesNotHaveSymptomButton.Size = new System.Drawing.Size(101, 42);
            this.PatientDoesNotHaveSymptomButton.TabIndex = 8;
            this.PatientDoesNotHaveSymptomButton.Text = "NO";
            this.PatientDoesNotHaveSymptomButton.UseVisualStyleBackColor = true;
            this.PatientDoesNotHaveSymptomButton.Click += new System.EventHandler(this.PatientDoesNotHaveSymptomButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PatientHasSymptomButton);
            this.groupBox2.Controls.Add(this.PatientDoesNotHaveSymptomButton);
            this.groupBox2.Controls.Add(this.QuestionLabel);
            this.groupBox2.Location = new System.Drawing.Point(171, 32);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(609, 145);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Question";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AddResultsToPatientButton);
            this.groupBox3.Controls.Add(this.ReturnToPatientButton);
            this.groupBox3.Controls.Add(this.SymptomListView);
            this.groupBox3.Location = new System.Drawing.Point(171, 216);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox3.Size = new System.Drawing.Size(609, 215);
            this.groupBox3.TabIndex = 11;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Current Result";
            // 
            // AddResultsToPatientButton
            // 
            this.AddResultsToPatientButton.Location = new System.Drawing.Point(467, 165);
            this.AddResultsToPatientButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddResultsToPatientButton.Name = "AddResultsToPatientButton";
            this.AddResultsToPatientButton.Size = new System.Drawing.Size(130, 46);
            this.AddResultsToPatientButton.TabIndex = 2;
            this.AddResultsToPatientButton.Text = "Add Results to Patient";
            this.AddResultsToPatientButton.UseVisualStyleBackColor = true;
            this.AddResultsToPatientButton.Click += new System.EventHandler(this.AddResultsToPatientButton_Click);
            // 
            // ReturnToPatientButton
            // 
            this.ReturnToPatientButton.Location = new System.Drawing.Point(320, 165);
            this.ReturnToPatientButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.ReturnToPatientButton.Name = "ReturnToPatientButton";
            this.ReturnToPatientButton.Size = new System.Drawing.Size(130, 46);
            this.ReturnToPatientButton.TabIndex = 1;
            this.ReturnToPatientButton.Text = "Return to Patient";
            this.ReturnToPatientButton.UseVisualStyleBackColor = true;
            this.ReturnToPatientButton.Click += new System.EventHandler(this.ReturnToPatient_Click);
            // 
            // SymptomListView
            // 
            this.SymptomListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.symptomNameColumn,
            this.SymptomProbabilityColumn});
            this.SymptomListView.FullRowSelect = true;
            this.SymptomListView.GridLines = true;
            this.SymptomListView.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.SymptomListView.Location = new System.Drawing.Point(40, 35);
            this.SymptomListView.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.SymptomListView.Name = "SymptomListView";
            this.SymptomListView.Size = new System.Drawing.Size(410, 83);
            this.SymptomListView.TabIndex = 0;
            this.SymptomListView.UseCompatibleStateImageBehavior = false;
            this.SymptomListView.View = System.Windows.Forms.View.Details;
            this.SymptomListView.SelectedIndexChanged += new System.EventHandler(this.SymptomListView_SelectedIndexChanged);
            // 
            // symptomNameColumn
            // 
            this.symptomNameColumn.Tag = "Symptom Name";
            this.symptomNameColumn.Text = "Symptom Name";
            this.symptomNameColumn.Width = 305;
            // 
            // SymptomProbabilityColumn
            // 
            this.SymptomProbabilityColumn.Text = "Probability(%)";
            this.SymptomProbabilityColumn.Width = 100;
            // 
            // DiagnosisWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.Name = "DiagnosisWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DiagnosisWizard";
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label QuestionLabel;
        private System.Windows.Forms.Button PatientHasSymptomButton;
        private System.Windows.Forms.Button PatientDoesNotHaveSymptomButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView SymptomListView;
        private System.Windows.Forms.ColumnHeader symptomNameColumn;
        private System.Windows.Forms.ColumnHeader SymptomProbabilityColumn;
        private System.Windows.Forms.Button AddResultsToPatientButton;
        private System.Windows.Forms.Button ReturnToPatientButton;
    }
}