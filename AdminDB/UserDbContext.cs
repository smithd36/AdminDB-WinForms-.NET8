/// <summary>
/// The <c>UserDbContext</c> class manages the data access and operations related to user authentication in the application.
/// </summary>
/// <remarks>
/// This class utilizes SQLite for data storage and Dapper for simplified data access.
/// </remarks>
/// <author>Drey Smith</author>
/// <created>01/01/2024</created>
/// 
using System;
using System.Data.SQLite;
using AdminDB;
using Dapper;
using AdminDB;

public class UserDbContext
{
    private readonly string connectionString;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserDbContext"/> class with the specified connection string.
    /// </summary>
    /// <param name="connectionString">The connection string for the SQLite database.</param>
    public UserDbContext(string connectionString)
    {

        this.connectionString = $"Data Source={connectionString};";

        InitializeDatabase();
    }

    /// <summary>
    /// Establishes database connection and logs outcome.
    /// </summary>
    private void InitializeDatabase()
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("Connection to the database successful!");

                string workingDir = Environment.CurrentDirectory;
                Console.WriteLine("Working Dir: " +  workingDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }

    /// <summary>
    /// Validates a user's login credentials against the database.
    /// </summary>
    /// <param name="email">The user's email address.</param>
    /// <param name="password">The user's password.</param>
    /// <returns><c>true</c> if the login is successful; otherwise, <c>false</c>.</returns>
    public bool ValidateLogin(string email, string password)
    {
        using (var connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // check against the database with Dapper to simplify data access
            var user = connection.QueryFirstOrDefault<User>("SELECT * FROM users WHERE email = @email AND password = @password",
                new { email = email, password = password });

            connection.Close();
            return user != null;
        }
    }
}