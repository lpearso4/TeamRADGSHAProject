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
            this.SuspendLayout();
            // 
            // useInventoryButton
            // 
            this.useInventoryButton.Location = new System.Drawing.Point(230, 303);
            this.useInventoryButton.Name = "useInventoryButton";
            this.useInventoryButton.Size = new System.Drawing.Size(87, 23);
            this.useInventoryButton.TabIndex = 0;
            this.useInventoryButton.Text = "Use Inventory";
            this.useInventoryButton.UseVisualStyleBackColor = true;
            this.useInventoryButton.Click += new System.EventHandler(this.useInventoryButton_Click);
            // 
            // changeRoomButton
            // 
            this.changeRoomButton.Location = new System.Drawing.Point(397, 303);
            this.changeRoomButton.Name = "changeRoomButton";
            this.changeRoomButton.Size = new System.Drawing.Size(85, 23);
            this.changeRoomButton.TabIndex = 1;
            this.changeRoomButton.Text = "Change Room";
            this.changeRoomButton.UseVisualStyleBackColor = true;
            this.changeRoomButton.Click += new System.EventHandler(this.changeRoomButton_Click);
            // 
            // diagnosisWizardButton
            // 
            this.diagnosisWizardButton.Location = new System.Drawing.Point(152, 196);
            this.diagnosisWizardButton.Name = "diagnosisWizardButton";
            this.diagnosisWizardButton.Size = new System.Drawing.Size(101, 23);
            this.diagnosisWizardButton.TabIndex = 2;
            this.diagnosisWizardButton.Text = "Diagnosis Wizard";
            this.diagnosisWizardButton.UseVisualStyleBackColor = true;
            this.diagnosisWizardButton.Click += new System.EventHandler(this.diagnosisWizardButton_Click);
            // 
            // Patient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.diagnosisWizardButton);
            this.Controls.Add(this.changeRoomButton);
            this.Controls.Add(this.useInventoryButton);
            this.Name = "Patient";
            this.Text = "Patient";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Load += new System.EventHandler(this.Patient_Load);
            this.Click += new System.EventHandler(this.diagnosisWizardButton_Click);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button useInventoryButton;
        private System.Windows.Forms.Button changeRoomButton;
        private System.Windows.Forms.Button diagnosisWizardButton;
    }
}