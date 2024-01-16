/// <summary>
/// The User class represents a user in the licensure application.
/// </summary>
/// <remarks>
/// This class defines the properties corresponding to the 'login' page.
/// </remarks>
/// <author>Drey Smith</author>
/// <created>01/01/2024</created>

// User.cs
namespace AdminDB
{
    public class User
    {
        /// <summary>
        /// Gets or sets the Email of the administrative personnel.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password of the administrative personnel.
        /// </summary>
        public string Password { get; set; }
    }
}