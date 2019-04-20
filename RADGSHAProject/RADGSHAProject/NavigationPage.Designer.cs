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
            this.searchPatientButton = new System.Windows.Forms.Button();
            this.addPatientButton = new System.Windows.Forms.Button();
            this.importToolButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.searchPatientButton);
            this.groupBox1.Controls.Add(this.addPatientButton);
            this.groupBox1.Controls.Add(this.importToolButton);
            this.groupBox1.Location = new System.Drawing.Point(13, 20);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(181, 417);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // searchPatientButton
            // 
            this.searchPatientButton.Location = new System.Drawing.Point(12, 20);
            this.searchPatientButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.searchPatientButton.Name = "searchPatientButton";
            this.searchPatientButton.Size = new System.Drawing.Size(148, 32);
            this.searchPatientButton.TabIndex = 2;
            this.searchPatientButton.Text = "Search Patient";
            this.searchPatientButton.UseVisualStyleBackColor = true;
            this.searchPatientButton.Click += new System.EventHandler(this.searchPatientButton_Click);
            // 
            // addPatientButton
            // 
            this.addPatientButton.Location = new System.Drawing.Point(12, 70);
            this.addPatientButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPatientButton.Name = "addPatientButton";
            this.addPatientButton.Size = new System.Drawing.Size(148, 30);
            this.addPatientButton.TabIndex = 1;
            this.addPatientButton.Text = "Add Patient";
            this.addPatientButton.UseVisualStyleBackColor = true;
            // 
            // importToolButton
            // 
            this.importToolButton.Location = new System.Drawing.Point(12, 350);
            this.importToolButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.importToolButton.Name = "importToolButton";
            this.importToolButton.Size = new System.Drawing.Size(148, 30);
            this.importToolButton.TabIndex = 0;
            this.importToolButton.Text = "Import Tool";
            this.importToolButton.UseVisualStyleBackColor = true;
            this.importToolButton.Click += new System.EventHandler(this.importToolButton_Click);
            // 
            // NavigationPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "NavigationPage";
            this.Text = "NavigationPage";
            this.Load += new System.EventHandler(this.NavigationPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button searchPatientButton;
        private System.Windows.Forms.Button addPatientButton;
        protected System.Windows.Forms.Button importToolButton;
    }
}