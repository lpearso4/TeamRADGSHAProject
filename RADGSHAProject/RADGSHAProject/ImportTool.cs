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
    public partial class ImportTool : NavigationPage
    {
        Form previousForm;//Used for displaying the previous Form when closing this one

        public ImportTool()//This constructor can probably be safely removed
        {
            InitializeComponent();
            DataImportType.ItemCheck += DataImportType_ItemCheck;
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
            if (DataImportType.SelectedItems.Count==0)
            {
                string message = "Please select a file type to import!";
                string caption = "Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            if (DirectoryInputField.Text.Trim() == "")
            {
                string message = "Please select a file to import!";
                string caption = "Error!";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                MessageBox.Show(message, caption, buttons);
                return;
            }
            const int MED_RECORD_INDEX = 0; const int INV_RECORD_INDEX = 1; const int ROOM_RECORD_INDEX = 2;
            if (DataImportType.SelectedIndex.Equals(MED_RECORD_INDEX))
            {
                // medical record
                IT.importPatientData(DirectoryInputField.Text);
            }
            else if (DataImportType.SelectedIndex.Equals(INV_RECORD_INDEX))
            {
                //inventory
                IT.importInventoryData(DirectoryInputField.Text);
            }
            else if (DataImportType.SelectedIndex.Equals(ROOM_RECORD_INDEX))
            {
                // rooms
                IT.importRoomData(DirectoryInputField.Text);
            }

        }

        private void DataImportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ImportTool_Load(object sender, EventArgs e)
        {

        }
    }
}
