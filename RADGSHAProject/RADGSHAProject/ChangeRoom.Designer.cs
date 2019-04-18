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
            this.searchRoom = new System.Windows.Forms.TextBox();
            this.availableRoom = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(183, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Type in to search for available rooms:";
            // 
            // submitButton
            // 
            this.submitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.submitButton.Location = new System.Drawing.Point(418, 281);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(101, 41);
            this.submitButton.TabIndex = 10;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // searchRoom
            // 
            this.searchRoom.Location = new System.Drawing.Point(373, 36);
            this.searchRoom.Name = "searchRoom";
            this.searchRoom.Size = new System.Drawing.Size(100, 20);
            this.searchRoom.TabIndex = 11;
            this.searchRoom.TextChanged += new System.EventHandler(this.searchRoom_TextChanged);
            // 
            // availableRoom
            // 
            this.availableRoom.GridLines = true;
            this.availableRoom.Location = new System.Drawing.Point(185, 73);
            this.availableRoom.Name = "availableRoom";
            this.availableRoom.Size = new System.Drawing.Size(288, 96);
            this.availableRoom.TabIndex = 12;
            this.availableRoom.TileSize = new System.Drawing.Size(20, 1);
            this.availableRoom.UseCompatibleStateImageBehavior = false;
            this.availableRoom.View = System.Windows.Forms.View.Details;
            this.availableRoom.SelectedIndexChanged += new System.EventHandler(this.availableRoom_SelectedIndexChanged);
            this.availableRoom.Leave += new System.EventHandler(this.availableRoom_Leave);
            // 
            // ChangeRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 334);
            this.Controls.Add(this.availableRoom);
            this.Controls.Add(this.searchRoom);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.label2);
            this.Name = "ChangeRoom";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ChangeRoom";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormClose);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.submitButton, 0);
            this.Controls.SetChildIndex(this.searchRoom, 0);
            this.Controls.SetChildIndex(this.availableRoom, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox searchRoom;
        private System.Windows.Forms.ListView availableRoom;
    }
}