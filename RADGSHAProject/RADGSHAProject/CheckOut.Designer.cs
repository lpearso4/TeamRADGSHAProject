namespace RADGSHAProject
{
    partial class CheckOut
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.roomListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.suppliesListView = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.proceduresListView = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.returnButton = new System.Windows.Forms.Button();
            this.checkOutButton = new System.Windows.Forms.Button();
            this.patientName = new System.Windows.Forms.TextBox();
            this.totalDue = new System.Windows.Forms.TextBox();
            this.textRoomSub = new System.Windows.Forms.TextBox();
            this.textSuppliesSub = new System.Windows.Forms.TextBox();
            this.textServicesSub = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(170, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "PATIENT:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(169, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Room Info:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(789, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 13);
            this.label8.TabIndex = 13;
            this.label8.Text = "Subtotal:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(169, 189);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 13);
            this.label9.TabIndex = 14;
            this.label9.Text = "Supplies used:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(789, 293);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 19;
            this.label14.Text = "Subtotal:";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(169, 342);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(109, 13);
            this.label15.TabIndex = 20;
            this.label15.Text = "Procedure performed:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(164, 469);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(101, 17);
            this.label18.TabIndex = 23;
            this.label18.Text = "TOTAL DUE:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(789, 403);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(58, 13);
            this.label19.TabIndex = 24;
            this.label19.Text = "Subtotal:";
            // 
            // roomListView
            // 
            this.roomListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.roomListView.Location = new System.Drawing.Point(167, 96);
            this.roomListView.Name = "roomListView";
            this.roomListView.Size = new System.Drawing.Size(613, 69);
            this.roomListView.TabIndex = 25;
            this.roomListView.UseCompatibleStateImageBehavior = false;
            this.roomListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Room Number";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Rate (hourly)";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Length of stay (dd:hh:mm)";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Charge";
            // 
            // suppliesListView
            // 
            this.suppliesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.suppliesListView.Location = new System.Drawing.Point(167, 223);
            this.suppliesListView.Name = "suppliesListView";
            this.suppliesListView.Size = new System.Drawing.Size(613, 108);
            this.suppliesListView.TabIndex = 26;
            this.suppliesListView.UseCompatibleStateImageBehavior = false;
            this.suppliesListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Supplies Used";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Qty used:";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Cost";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Charge";
            // 
            // proceduresListView
            // 
            this.proceduresListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9,
            this.columnHeader10});
            this.proceduresListView.Location = new System.Drawing.Point(167, 384);
            this.proceduresListView.Name = "proceduresListView";
            this.proceduresListView.Size = new System.Drawing.Size(613, 63);
            this.proceduresListView.TabIndex = 27;
            this.proceduresListView.UseCompatibleStateImageBehavior = false;
            this.proceduresListView.View = System.Windows.Forms.View.Details;
            this.proceduresListView.SelectedIndexChanged += new System.EventHandler(this.proceduresListView_SelectedIndexChanged);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Procedure";
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Charge";
            // 
            // returnButton
            // 
            this.returnButton.Location = new System.Drawing.Point(692, 485);
            this.returnButton.Name = "returnButton";
            this.returnButton.Size = new System.Drawing.Size(103, 26);
            this.returnButton.TabIndex = 28;
            this.returnButton.Text = "Return to Patient";
            this.returnButton.UseVisualStyleBackColor = true;
            this.returnButton.Click += new System.EventHandler(this.returnButton_Click);
            // 
            // checkOutButton
            // 
            this.checkOutButton.Location = new System.Drawing.Point(811, 485);
            this.checkOutButton.Name = "checkOutButton";
            this.checkOutButton.Size = new System.Drawing.Size(103, 26);
            this.checkOutButton.TabIndex = 29;
            this.checkOutButton.Text = "Confirm Checkout";
            this.checkOutButton.UseVisualStyleBackColor = true;
            this.checkOutButton.Click += new System.EventHandler(this.checkOutButton_Click);
            // 
            // patientName
            // 
            this.patientName.Location = new System.Drawing.Point(404, 32);
            this.patientName.Name = "patientName";
            this.patientName.Size = new System.Drawing.Size(226, 20);
            this.patientName.TabIndex = 30;
            // 
            // totalDue
            // 
            this.totalDue.Location = new System.Drawing.Point(404, 469);
            this.totalDue.Name = "totalDue";
            this.totalDue.Size = new System.Drawing.Size(100, 20);
            this.totalDue.TabIndex = 31;
            // 
            // textRoomSub
            // 
            this.textRoomSub.Location = new System.Drawing.Point(792, 144);
            this.textRoomSub.Name = "textRoomSub";
            this.textRoomSub.Size = new System.Drawing.Size(100, 20);
            this.textRoomSub.TabIndex = 32;
            // 
            // textSuppliesSub
            // 
            this.textSuppliesSub.Location = new System.Drawing.Point(792, 310);
            this.textSuppliesSub.Name = "textSuppliesSub";
            this.textSuppliesSub.Size = new System.Drawing.Size(100, 20);
            this.textSuppliesSub.TabIndex = 33;
            // 
            // textServicesSub
            // 
            this.textServicesSub.Location = new System.Drawing.Point(790, 425);
            this.textServicesSub.Name = "textServicesSub";
            this.textServicesSub.Size = new System.Drawing.Size(100, 20);
            this.textServicesSub.TabIndex = 34;
            // 
            // CheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(926, 523);
            this.Controls.Add(this.textServicesSub);
            this.Controls.Add(this.textSuppliesSub);
            this.Controls.Add(this.textRoomSub);
            this.Controls.Add(this.totalDue);
            this.Controls.Add(this.patientName);
            this.Controls.Add(this.checkOutButton);
            this.Controls.Add(this.returnButton);
            this.Controls.Add(this.proceduresListView);
            this.Controls.Add(this.suppliesListView);
            this.Controls.Add(this.roomListView);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "CheckOut";
            this.Text = "CheckOut";
            this.Load += new System.EventHandler(this.CheckOut_Load);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label8, 0);
            this.Controls.SetChildIndex(this.label9, 0);
            this.Controls.SetChildIndex(this.label14, 0);
            this.Controls.SetChildIndex(this.label15, 0);
            this.Controls.SetChildIndex(this.label18, 0);
            this.Controls.SetChildIndex(this.label19, 0);
            this.Controls.SetChildIndex(this.roomListView, 0);
            this.Controls.SetChildIndex(this.suppliesListView, 0);
            this.Controls.SetChildIndex(this.proceduresListView, 0);
            this.Controls.SetChildIndex(this.returnButton, 0);
            this.Controls.SetChildIndex(this.checkOutButton, 0);
            this.Controls.SetChildIndex(this.patientName, 0);
            this.Controls.SetChildIndex(this.totalDue, 0);
            this.Controls.SetChildIndex(this.textRoomSub, 0);
            this.Controls.SetChildIndex(this.textSuppliesSub, 0);
            this.Controls.SetChildIndex(this.textServicesSub, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ListView roomListView;
        private System.Windows.Forms.ListView suppliesListView;
        private System.Windows.Forms.ListView proceduresListView;
        private System.Windows.Forms.Button returnButton;
        private System.Windows.Forms.Button checkOutButton;
        private System.Windows.Forms.TextBox patientName;
        private System.Windows.Forms.TextBox totalDue;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TextBox textRoomSub;
        private System.Windows.Forms.TextBox textSuppliesSub;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.TextBox textServicesSub;
    }
}