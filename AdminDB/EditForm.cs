using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace AdminDB
{
    public partial class EditForm : Form, IEmployeeView
    {
        private readonly Employee selectedEmployee;
        private readonly EmployeeController controller;

        public event Action<Employee> EmployeeUpdated;


        public EditForm(Employee employee)
        {
            InitializeComponent();
            this.selectedEmployee = employee;

            // populate the controls with employee details
            PopulateControls();

            // controller Initialization:
            // Get the application data folder
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Combine the application data folder with your app name and database file name
            string databasePath = Path.Combine(appDataFolder, "AdminDB", "appdata.db");

            // Instantiate the EmployeeDbContext
            var empDbContext = new EmployeeDbContext($"Data Source={databasePath}");

            // Instantiate the EmployeeController with the EditForm and EmployeeDbContext
            controller = new EmployeeController(this, empDbContext);
        }

        private void PopulateControls()
        {
            // populate form controls with the selected data
            // store in the Employee object

            // get name
            txtEditName.Text = selectedEmployee.Name;

            // set name as editform header
            lblEditHeader.Text = $"{selectedEmployee.Name}'s Information";

            txtEditEmail.Text = selectedEmployee.Email;
            txtEditLicensureLevel.Text = selectedEmployee.LicensureLevel;

            dateEditCevo.Value = string.IsNullOrEmpty(selectedEmployee.CevoIss)
                ? DateTime.Now // default
                : DateTime.ParseExact(selectedEmployee.CevoIss, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            dateEditDot.Value = string.IsNullOrEmpty(selectedEmployee.DotExp)
                ? DateTime.Now // default
                : DateTime.ParseExact(selectedEmployee.DotExp, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            dateEditEms.Value = string.IsNullOrEmpty(selectedEmployee.EmsExp)
                ? DateTime.Now // default
                : DateTime.ParseExact(selectedEmployee.EmsExp, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            dateEditDrivers.Value = string.IsNullOrEmpty(selectedEmployee.EmsExp)
                ? DateTime.Now // default
                : DateTime.ParseExact(selectedEmployee.EmsExp, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            dateEditBls.Value = string.IsNullOrEmpty(selectedEmployee.EmsExp)
                ? DateTime.Now // default
                : DateTime.ParseExact(selectedEmployee.EmsExp, "yyyy-MM-dd", CultureInfo.InvariantCulture);

            dateEditMvr.Value = string.IsNullOrEmpty(selectedEmployee.EmsExp)
                ? DateTime.Now // default
                : DateTime.ParseExact(selectedEmployee.EmsExp, "yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            // close the edit window only in its current state
            this.Close();
        }

        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the employee's new attributes from the form controls
                Employee updatedEmployee = new Employee
                {
                    Name = txtEditName.Text,
                    Email = txtEditEmail.Text,
                    CevoIss = dateEditCevo.Value.ToString("yyyy-MM-dd"),
                    DotExp = dateEditDot.Value.ToString("yyyy-MM-dd"),
                    EmsExp = dateEditEms.Value.ToString("yyyy-MM-dd"),
                    DriversExp = dateEditDrivers.Value.ToString("yyyy-MM-dd"),
                    BlsExp = dateEditBls.Value.ToString("yyyy-MM-dd"),
                    LicensureLevel = txtEditLicensureLevel.Text,
                    MvrExp = dateEditMvr.Value.ToString("yyyy-MM-dd")
                };

                // Update the employee in the database
                bool success = controller.UpdateEmployee(updatedEmployee);

                if (success)
                {
                    MessageBox.Show("Employee updated successfully.");
                    // Close the dialog after successful save operation
                    this.Close();

                    EmployeeUpdated?.Invoke(updatedEmployee);
                }
                else
                {
                    MessageBox.Show("Failed to update employee.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// REQUIRED METHOD
        /// Acts as access point for IEmployeeView,
        /// which is the interface needed to contain
        /// both MainForm and EditForm to the same controller.
        /// </summary>
        /// <param name="employees"></param>
        public void UpdateEmployeeTable(IEnumerable<Employee> employees)
        {
            // no table to update in editform

            // ambiguous call to controller to refresh table
            controller.EmployeesUpdated += Controller_EmployeesUpdated;
        }

        private void Controller_EmployeesUpdated(IEnumerable<Employee> obj)
        {
            throw new NotImplementedException();
        }

        private void EditForm_Load(object sender, EventArgs e)
        {

        }
    }
}