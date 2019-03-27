using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImportToolLibrary;

namespace RADGSHAProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ImportToolLibrary.ImportTool it = new ImportToolLibrary.ImportTool();
            //it.importPatientData(@"D:\stuff\COLLEGE\semester 6\CSCI ROSEN\GHSAProject\import_data\MedicalRecords.txt");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginPage());
        }
    }
}
