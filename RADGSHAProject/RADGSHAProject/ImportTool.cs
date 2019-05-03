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
        
        ImportToolLibrary.ImportTool IT;
        public ImportTool()
        {
            InitializeComponent();
            DataImportType.ItemCheck += DataImportType_ItemCheck;
        }

        private void FormClose(object sender, FormClosedEventArgs e)//shows the previous Form when closing this one
        {

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
            IT = new ImportToolLibrary.ImportTool();
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
            const int MED_RECORD_INDEX = 2; const int INV_RECORD_INDEX = 1; const int ROOM_RECORD_INDEX = 0; const int USER_RECORD_INDEX = 3;
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
            else if (DataImportType.SelectedIndex.Equals(USER_RECORD_INDEX))
            {
                IT.importUserData(DirectoryInputField.Text);
            }

            importDataButton.Enabled = false;
            importToolButton.Enabled = false;
            searchPatientButton.Enabled = false;
            addPatientButton.Enabled = false;
            logOutButton.Enabled = false;
            labelStatus.Text = "Import has begun please wait...";
            timerStatus.Enabled = true;
            autoLogout.Enabled = false;
        }

        private void DataImportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ImportTool_Load(object sender, EventArgs e)
        {

        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            ImportToolLibrary.ImportStatus status = IT.getStatus();
            progressBar1.Value = (int) status.PercentDone;
           // Console.WriteLine(status.PercentDone + " or in int = " + (int)status.PercentDone);
            labelStatus.Text = "Importing record " + status.Imported + " out of " + status.Total;

            if (status.PercentDone==100)
            {
                labelStatus.Text = "Import Complete.";
                importDataButton.Enabled = true;
                importToolButton.Enabled = true;
                searchPatientButton.Enabled = true;
                addPatientButton.Enabled = true;
                logOutButton.Enabled = true;
                autoLogout.Enabled = true;
            }
        }

        private void ImportTool_FormClosing(object sender, FormClosingEventArgs e)
        {
            loginPage.Close();
        }
    }
}
