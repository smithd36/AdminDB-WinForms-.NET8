using System;
using System.Globalization;

/// <summary>
/// The Employee class represents an employee in the licensure application.
/// </summary>
/// <remarks>
/// This class defines the properties corresponding to the 'employee' table schema in SQLite.
/// </remarks>
/// <author>Drey Smith</author>
/// <created>01/01/2024</created>
public class Employee
{
    /// <summary>
    /// Gets or sets the name of the employee.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the email of the employee.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// Gets or sets the CEVO Issued date of the employee.
    /// </summary>
    public string CevoIss { get; set; }

    /// <summary>
    /// Gets or sets the DOT Expiry date of the employee.
    /// </summary>
    public string DotExp { get; set; }

    /// <summary>
    /// Gets or sets the EMS Expiry date of the employee.
    /// </summary>
    public string EmsExp { get; set; }

    /// <summary>
    /// Gets or sets the Drivers Expiry date of the employee.
    /// </summary>
    public string DriversExp { get; set; }

    /// <summary>
    /// Gets or sets the BLS Expiry date of the employee.
    /// </summary>
    public string BlsExp { get; set; }

    /// <summary>
    /// Gets or sets the licensure level of the employee.
    /// </summary>
    public string LicensureLevel { get; set; }

    /// <summary>
    /// Gets or sets the MVR Expiry date of the employee.
    /// </summary>
    public string MvrExp { get; set; }

    /// <summary>
    /// Converts the date string to a DateTime object.
    /// </summary>
    /// <param name="date">The date string to convert.</param>
    /// <returns>A DateTime object representing the converted date.</returns>
    public DateTime ConvertToDate(string date)
    {
        if (DateTime.TryParseExact(date, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime convertedDate))
            return convertedDate;

        // Handle parsing error by throwing an exception
        throw new ArgumentException($"Invalid date format: {date}. Expected format: yyyy-MM-dd");
    }

    /// <summary>
    /// Checks if the date is expired.
    /// </summary>
    /// <param name="date">The date string to check.</param>
    /// <returns>True if the date is expired; otherwise, false.</returns>
    public bool IsDateExpired(string date)
    {
        if (string.IsNullOrEmpty(date))
        {
            // Handle null or empty case
            return false;
        }

        DateTime convertedDate = ConvertToDate(date);
        return convertedDate < DateTime.Today;
    }
}