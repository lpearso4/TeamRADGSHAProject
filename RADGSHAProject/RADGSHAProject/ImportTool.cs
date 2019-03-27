using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImportToolLibrary;

namespace RADGSHAProject
{
    public partial class ImportTool : Form
    {
        Form previousForm;//Used for displaying the previous Form when closing this one

        public ImportTool()//This constructor can probably be safely removed
        {
            InitializeComponent();
        }

        public ImportTool(Form previousForm)
        {
            InitializeComponent();
            this.previousForm = previousForm;
        }

        private void FormClose(object sender, FormClosedEventArgs e)//shows the previous Form when closing this one
        {
            if(previousForm != null)
            {
                previousForm.Show();
            }
            Dispose();
        }

        private void chooseFileButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                DirectoryInputField.Text = openFileDialog1.FileName;
            }
        }

        private void DataImportType_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int ix = 0; ix < DataImportType.Items.Count; ++ix)
                if (ix != e.Index) DataImportType.SetItemChecked(ix, false);
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void importDataButton_Click(object sender, EventArgs e)
        {
            ImportToolLibrary.ImportTool IT = new ImportToolLibrary.ImportTool();
            IT.importPatientData(DirectoryInputField.Text);
        }
    }
}
