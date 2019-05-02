namespace RADGSHAProject
{
    partial class NavigationPage
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.logOutButton = new System.Windows.Forms.Button();
            this.searchPatientButton = new System.Windows.Forms.Button();
            this.addPatientButton = new System.Windows.Forms.Button();
            this.importToolButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.logOutButton);
            this.groupBox1.Controls.Add(this.searchPatientButton);
            this.groupBox1.Controls.Add(this.addPatientButton);
            this.groupBox1.Controls.Add(this.importToolButton);
            this.groupBox1.Location = new System.Drawing.Point(10, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 339);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // logOutButton
            // 
            this.logOutButton.BackColor = System.Drawing.Color.Red;
            this.logOutButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.logOutButton.Location = new System.Drawing.Point(9, 286);
            this.logOutButton.Name = "logOutButton";
            this.logOutButton.Size = new System.Drawing.Size(111, 29);
            this.logOutButton.TabIndex = 3;
            this.logOutButton.Text = "Log Out";
            this.logOutButton.UseVisualStyleBackColor = false;
            this.logOutButton.Click += new System.EventHandler(this.logOutButton_Click);
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
            this.searchPatientButton.Click += new System.EventHandler(this.searchPatientButton_Click);
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
            // importToolButton
            // 
            this.importToolButton.Location = new System.Drawing.Point(9, 178);
            this.importToolButton.Margin = new System.Windows.Forms.Padding(2);
            this.importToolButton.Name = "importToolButton";
            this.importToolButton.Size = new System.Drawing.Size(111, 24);
            this.importToolButton.TabIndex = 0;
            this.importToolButton.Text = "Import Tool";
            this.importToolButton.UseVisualStyleBackColor = true;
            this.importToolButton.Click += new System.EventHandler(this.importToolButton_Click);
            // 
            // NavigationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "NavigationPage";
            this.Text = "NavigationPage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NavigationPage_FormClosing);
            this.Load += new System.EventHandler(this.NavigationPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button searchPatientButton;
        private System.Windows.Forms.Button addPatientButton;
        protected System.Windows.Forms.Button importToolButton;
        private System.Windows.Forms.Button logOutButton;
    }
}