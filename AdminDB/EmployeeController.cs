/// <summary>
/// The <c>EmployeeController</c> class acts as a controller in the MVC pattern for handling
/// operations related to employees, such as loading, adding, and deleting employees.
/// </summary>
/// <remarks>
/// This class represents the controller part of the MVC pattern, interacting with both
/// the <see cref="MainForm"/> view and the <see cref="EmployeeDbContext"/> model.
/// </remarks>
/// <author>Drey Smith</author>
/// <created>01/01/2024</created>

using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Diagnostics.Eventing.Reader;
using System.Windows.Forms;

namespace AdminDB
{
    internal class EmployeeController
    {
        private readonly EmployeeDbContext empDbContext;
        private readonly IEmployeeView view;
        private IEnumerable<Employee> employees;

        public event Action<IEnumerable<Employee>> EmployeesUpdated;

        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeeController"/> class.
        /// </summary>
        /// <param name="view">The MainForm view associated with the controller.</param>
        /// <param name="empDbContext">The EmployeeDbContext model associated with the controller.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown if either the view or the employee database context is null.
        /// </exception>
        public EmployeeController(IEmployeeView view, EmployeeDbContext empDbContext)
        {
            this.view = view ?? throw new ArgumentNullException(nameof(view));
            this.empDbContext = empDbContext ?? throw new ArgumentNullException(nameof(empDbContext));

            // Subscribe to the event in the MainForm
            this.EmployeesUpdated += view.UpdateEmployeeTable;
        }

        /// <summary>
        /// Loads employees from the database and updates the associated MainForm view.
        /// </summary>
        public void LoadEmployees()
        {
            try
            {
                // Get employees from the database
                employees = empDbContext.GetEmployees();

                // Invoke the event to notify subscribers (MainForm) about the updated employees
                EmployeesUpdated?.Invoke(employees);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Data Error", $"Unable to load employees, try restarting the app. \nERROR MESSAGE:\n{ex.Message}");
            }
        }

        /// <summary>
        /// Adds an employee to the local database through the associated EmployeeDbContext.
        /// </summary>
        /// <param name="employee">The employee to be added.</param>
        /// <returns>
        /// <c>true</c> if the employee is successfully added; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the provided employee is null.
        /// </exception>
        public bool AddEmployee(Employee employee)
        {
            try
            {
                if (employee == null)
                    throw new ArgumentNullException(nameof(employee));

                bool success = empDbContext.AddEmployee(employee);

                if (success)
                {
                    // Invoke the event to notify subscribers (MainForm) about the updated employees
                    EmployeesUpdated?.Invoke(empDbContext.GetEmployees());
                }

                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding employee: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Deletes an employee from the local database based on the provided email.
        /// </summary>
        /// <param name="email">The email of the employee to be deleted.</param>
        /// <returns>
        /// <c>true</c> if the employee is successfully deleted; otherwise, <c>false</c>.
        /// </returns>
        public bool DeleteEmployee(string email)
        {
            try
            {
                bool success = empDbContext.DeleteEmployee(email);

                if (success)
                {
                    // Invoke the event to notify subscribers (MainForm) about the updated employees
                    EmployeesUpdated?.Invoke(empDbContext.GetEmployees());
                }

                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting employee: {ex.Message}");
                return false;
            }
        }

        public Employee RetrieveEmployeeByEmail(string email)
        {
            if (!string.IsNullOrEmpty(email))
                return empDbContext.GetEmployee(email);
          
            return null;
        }

        public bool UpdateEmployee(Employee updatedEmployee)
        {
            try
            {
                // Check if the provided updatedEmployee is not null
                if (updatedEmployee == null)
                {
                    Console.WriteLine("Updated employee is null.");
                    return false;
                }

                // Update the employee in the database
                bool success = empDbContext.UpdateEmployee(updatedEmployee);

                if (success)
                {
                    // Notify subscribers (MainForm) about the updated employees
                    EmployeesUpdated?.Invoke(empDbContext.GetEmployees());
                }

                return success;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating employee: {ex.Message}");
                return false;
            }
        }
    }
}
