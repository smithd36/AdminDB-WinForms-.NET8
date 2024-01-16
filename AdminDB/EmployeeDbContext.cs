/// <summary>
/// The <c>EmployeeDbContext</c> class functions as the database "model" in the MVC design pattern
/// for the licensure application.
/// </summary>
/// <remarks>
/// Contains logic to perform CRUD operations on the SQLite database's employee table.
/// </remarks>
/// <author>Drey Smith</author>
/// <created>01/01/2024</created>

using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Dapper;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace AdminDB
{
    internal class EmployeeDbContext
    {
        private readonly string connectionString;

        /// <summary>
        /// Constructor for EmployeeDbContext
        /// </summary>
        /// <param name="connectionString"></param>
        public EmployeeDbContext(string connectionString)
        {
            this.connectionString = connectionString;
            InitializeDatabase();
        }

        /// <summary>
        /// Initializes the database and creates the employees table if it doesn't exist.
        /// </summary>
        private void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Create the employees table if it doesn't exist
                connection.Execute(@"
                    CREATE TABLE IF NOT EXISTS employees (
                        name TEXT,
                        email TEXT,
                        cevoIss TEXT,
                        dotExp TEXT,
                        emsExp TEXT,
                        driversExp TEXT,
                        blsExp TEXT,
                        licensureLevel TEXT,
                        mvrExp TEXT
                    )");
            }
        }

        /// <summary>
        /// Retrieves all employees from the database.
        /// </summary>
        /// <returns>A collection of Employee objects representing all employees in the database.</returns>
        public IEnumerable<Employee> GetEmployees()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Retrieve all employees from the database
                return connection.Query<Employee>("SELECT * FROM employees");
            }
        }

        /// <summary>
        /// Adds a new employee to the database.
        /// </summary>
        /// <param name="employee">The Employee object to be added to the database.</param>
        /// <returns><c>true</c> if the employee is successfully added; otherwise, <c>false</c>.</returns>
        public bool AddEmployee(Employee employee)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Insert the employee into the database
                int rowsAffected = connection.Execute(@"
                    INSERT INTO employees (name, email, cevoIss, dotExp, emsExp, driversExp, blsExp, licensureLevel, mvrExp)
                    VALUES (@Name, @Email, @CevoIss, @DotExp, @EmsExp, @DriversExp, @BlsExp, @LicensureLevel, @MvrExp)", employee);

                // Return true if at least one row was affected (successful insertion)
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// Deletes an employee from the database based on the provided email.
        /// </summary>
        /// <param name="email">The email of the employee to be deleted.</param>
        /// <returns><c>true</c> if the employee is successfully deleted; otherwise, <c>false</c>.</returns>
        public bool DeleteEmployee(string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Use a parameterized query to avoid SQL injection
                string query = "DELETE FROM employees WHERE email = @Email";

                using (var command = new SQLiteCommand(query, connection))
                {
                    // Add the parameter
                    command.Parameters.AddWithValue("@Email", email);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();

                    // Check if any rows were affected to determine if the deletion was successful
                    return rowsAffected > 0;
                }
            }
        }

        public Employee GetEmployee(string email)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                // Use a parameterized query to avoid SQL injection
                string query = "SELECT * FROM employees WHERE email = @Email";

                // Execute the query and retrieve a single employee
                return connection.QueryFirstOrDefault<Employee>(query, new { Email = email });
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Update the employee in the database
                    int rowsAffected = connection.Execute(@"
                        UPDATE employees 
                        SET name = @Name, 
                            cevoIss = @CevoIss,
                            dotExp = @DotExp,
                            emsExp = @EmsExp,
                            driversExp = @DriversExp,
                            blsExp = @BlsExp,
                            licensureLevel = @LicensureLevel,
                            mvrExp = @MvrExp
                        WHERE email = @Email", employee);

                    // Return true if at least one row was affected (successful update)
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating employee: {ex.Message}");
                return false;
            }
        }
    }
}

