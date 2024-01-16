/// <summary>
/// MainForm.cs functions as the Main "view" for the licensure application.
/// From this page, administrative personnel can add or remove new employees.
/// 
/// Future plans are to include color-coding within the DataGridView to signify
/// if a license is expired.
/// </summary>
/// <author>Drey Smith</author>
/// <created>01/01/2024</created>

using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace AdminDB
{
    public partial class MainForm : Form, IEmployeeView
    {
        private readonly EmployeeController controller;

        /// <summary>
        /// Constructor for the MainForm
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            // Initialize and configure the DataGridView
            InitializeDataGridView();

            // Ensure full-screen
            this.WindowState = FormWindowState.Maximized;

            // Get the application data folder
            string appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // Combine the application data folder with your app name and database file name
            string databasePath = Path.Combine(appDataFolder, "AdminDB", "appdata.db");

            // Instantiate the EmployeeDbContext
            var empDbContext = new EmployeeDbContext($"Data Source={databasePath}");

            // Instantiate the EmployeeController with the MainForm and EmployeeDbContext
            controller = new EmployeeController(this, empDbContext);

            // Subscribe to the EmployeesUpdated event to handle both table update and cell styles
            controller.EmployeesUpdated += UpdateEmployeeTableAndCellStyles;

            // Load employees into the DataGridView
            controller.LoadEmployees();
        }

        public void UpdateCellStyles(IEnumerable<Employee> employees)
        {
            foreach (DataGridViewRow row in tableEmployees.Rows)
            {
                var employee = row.DataBoundItem as Employee;
                if (employee != null)
                {
                    SetCellStyleBasedOnExpiration(row, employee);
                }
            }
        }

        /// <summary>
        /// Method to initialize the DataGridView
        /// </summary>
        private void InitializeDataGridView()
        {
            // Add columns to the DataGridView
            tableEmployees.Columns.Add("Name", "Name");
            tableEmployees.Columns.Add("Email", "Email");
            tableEmployees.Columns.Add("CevoIss", "CEVO Issued");
            tableEmployees.Columns.Add("DotExp", "DOT Expiry");
            tableEmployees.Columns.Add("EmsExp", "EMS Expiry");
            tableEmployees.Columns.Add("DriversExp", "Drivers Expiry");
            tableEmployees.Columns.Add("BlsExp", "BLS Expiry");
            tableEmployees.Columns.Add("LicensureLevel", "Licensure Level");
            tableEmployees.Columns.Add("MvrExp", "MVR Expiry");
        }

        /// <summary>
        /// Method to update the DataGridView with a collection of employees
        /// </summary>
        /// <param name="employees"></param>
        public void UpdateEmployeeTable(IEnumerable<Employee> employees)
        {
            tableEmployees.Rows.Clear(); // Clear existing rows

            // Iterate through employees and add rows to the DataGridView
            foreach (var employee in employees)
            {
                // Add a new row to the DataGridView and set cell values
                tableEmployees.Rows.Add(
                    employee.Name,
                    employee.Email,
                    employee.CevoIss,
                    employee.DotExp,
                    employee.EmsExp,
                    employee.DriversExp,
                    employee.BlsExp,
                    employee.LicensureLevel,
                    employee.MvrExp
                );
            }
        }

        /// <summary>
        /// Event handler for the "Add Employee" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmp_Click(object sender, EventArgs e)
        {
            // Create a new Employee object
            Employee employee = new Employee();

            // Retrieve data from textboxes
            employee.Name = txtNewName.Text;
            employee.Email = txtNewEmail.Text;

            // Retrieve data from datetime pickers (convert to string in "YYYY-MM-DD" format)
            employee.CevoIss = dateCevo.Checked ? dateCevo.Value.ToString("yyyy-MM-dd") : null;
            employee.DotExp = dateDot.Checked ? dateDot.Value.ToString("yyyy-MM-dd") : null;
            employee.EmsExp = dateEms.Checked ? dateEms.Value.ToString("yyyy-MM-dd") : null;
            employee.DriversExp = dateDrivers.Checked ? dateDrivers.Value.ToString("yyyy-MM-dd") : null;
            employee.BlsExp = dateBls.Checked ? dateBls.Value.ToString("yyyy-MM-dd") : null;
            employee.MvrExp = dateMvr.Checked ? dateMvr.Value.ToString("yyyy-MM-dd") : null;

            // Retrieve data from other controls
            employee.LicensureLevel = txtLicensure.Text;

            // Add the employee to the database
            if (controller.AddEmployee(employee))
            {
                MessageBox.Show($"{employee.Name}, added successfully.");
                
                // Reload to show the updated table
                controller.LoadEmployees();
            }
        }

        /// <summary>
        /// Event handler for the form load event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            // No runtime initializations needed for now
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (tableEmployees.SelectedRows.Count > 0)
            {
                string email = tableEmployees.SelectedRows[0].Cells["Email"].Value.ToString();

                Employee selectedEmployee = controller.RetrieveEmployeeByEmail(email);

                // open the form and pass selected employee to it
                EditForm editForm = new EditForm(selectedEmployee);

                // Subscribe to the EmployeeUpdated event
                editForm.EmployeeUpdated += UpdatedEmployeeHandler;

                // show on top of current window
                editForm.Show();
            }
            else
            {
                MessageBox.Show("Please select a row to edit.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void UpdatedEmployeeHandler(Employee updatedEmployee)
        {
            // Handle the updated employee (e.g., refresh the DataGridView)
            // You can call your controller method to reload employees or update the specific row
            controller.LoadEmployees();
        }

        /// <summary>
        /// Event handler for the "Delete Employee" button click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Ensure a row is selected in the DataGridView
            if (tableEmployees.SelectedRows.Count > 0)
            {
                // Get the email of the employee in the selected row
                string email = tableEmployees.SelectedRows[0].Cells["Email"].Value.ToString();

                // Prompt the user for confirmation
                DialogResult result = MessageBox.Show($"Are you sure you want to delete the employee with email: {email}?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Call the DeleteEmployee method
                    bool success = controller.DeleteEmployee(email);

                    if (success)
                    {
                        // Refresh the DataGridView after deletion
                        controller.LoadEmployees();
                        MessageBox.Show("Employee deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Employee not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        /// <summary>
        /// ALL CODE BELOW THIS LINE IS STILL BEING TESTED AND DEVELOPED
        /// Code does not throw errors, but some issues lie in the data types being passed
        /// from various classes for date validation to correctly identify expirations.
        /// </summary>

        private void UpdateEmployeeTableAndCellStyles(IEnumerable<Employee> updatedEmployees)
        {
            UpdateEmployeeTable(updatedEmployees);
            UpdateCellStyles();
        }

        private void UpdateCellStyles()
        {
            foreach (DataGridViewRow row in tableEmployees.Rows)
            {
                var employee = row.DataBoundItem as Employee;
                if (employee != null)
                {
                    SetCellStyleBasedOnExpiration(row, employee);
                }
            }
        }

        private void SetCellStyleBasedOnExpiration(DataGridViewRow row, Employee employee)
        {
            foreach (DataGridViewCell cell in row.Cells)
            {
                if (IsDateColumn(cell.OwningColumn.Name))
                {
                    string dateValue = cell.Value?.ToString();
                    if (!string.IsNullOrEmpty(dateValue) && employee.IsDateExpired(dateValue))
                    {
                        cell.Style.BackColor = Color.Red;
                        cell.Style.ForeColor = Color.White;
                    }
                    else
                    {
                        // Reset styles for non-expired dates
                        cell.Style.BackColor = tableEmployees.DefaultCellStyle.BackColor;
                        cell.Style.ForeColor = tableEmployees.DefaultCellStyle.ForeColor;
                    }
                }
            }
        }

        private bool IsDateColumn(string columnName)
        {
            string[] dateColumns = { "DotExp", "EmsExp", "DriversExp", "BlsExp", "MvrExp" };
            return Array.Exists(dateColumns, column => column.Equals(columnName));
        }
    }
}