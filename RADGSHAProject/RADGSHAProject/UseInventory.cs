﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RADGSHAProject
{
    public partial class UseInventory : Form
    {
        Form previousForm;//Used for displaying the previous Form when closing this one

        public UseInventory()//this constructor can probably be safely removed
        {
            InitializeComponent();
        }

        public UseInventory(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void FormClose(object sender, FormClosedEventArgs e)//shows the previous form after closing this one
        {
            if (previousForm != null)
            {
                previousForm.Show();
            }
            this.Dispose();
        }
    }
}