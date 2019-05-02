namespace RADGSHAProject
{
    partial class ChangeRoom
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
            this.label2 = new System.Windows.Forms.Label();
            this.submitButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.roomField = new System.Windows.Forms.TextBox();
            this.RoomListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Type in to search for available rooms:";
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(176, 205);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(101, 41);
            this.submitButton.TabIndex = 10;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(283, 205);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(101, 41);
            this.cancelButton.TabIndex = 11;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // roomField
            // 
            this.roomField.Location = new System.Drawing.Point(219, 33);
            this.roomField.Name = "roomField";
            this.roomField.Size = new System.Drawing.Size(129, 20);
            this.roomField.TabIndex = 12;
            this.roomField.TextChanged += new System.EventHandler(this.roomField_TextChanged);
            // 
            // RoomListView
            // 
            this.RoomListView.Location = new System.Drawing.Point(33, 75);
            this.RoomListView.Name = "RoomListView";
            this.RoomListView.Size = new System.Drawing.Size(314, 90);
            this.RoomListView.TabIndex = 13;
            this.RoomListView.UseCompatibleStateImageBehavior = false;
            this.RoomListView.SelectedIndexChanged += new System.EventHandler(this.RoomListView_SelectedIndexChanged);
            this.RoomListView.Leave += new System.EventHandler(this.RoomListView_Leave);
            // 
            // ChangeRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 258);
            this.Controls.Add(this.RoomListView);
            this.Controls.Add(this.roomField);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label2);
            this.Name = "ChangeRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeRoom";
            this.Load += new System.EventHandler(this.ChangeRoom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox roomField;
        private System.Windows.Forms.ListView RoomListView;
    }
}