/// <summary>
/// UserController.cs serves as the controller in the MVC design pattern for the user authentication process in the licensure application.
/// </summary>
/// <remarks>
/// This class handles the interaction between the login view (LoginForm) and the user data model (UserDbContext).
/// </remarks>
/// <author>Drey Smith</author>
/// <created>01/01/2024</created>

namespace AdminDB
{
    public class UserController
    {
        private readonly LoginForm view;
        private readonly UserDbContext userDbContext;
        
        /// <summary>
        /// Constructor for the UserController, defines model and view
        /// </summary>
        /// <param name="view"></param>
        /// <param name="userDbContext"></param>
        public UserController(LoginForm view, UserDbContext userDbContext)
        {
            this.view = view;
            this.userDbContext = userDbContext;
        }

        /// <summary>
        /// Validates the user login credentials.
        /// </summary>
        /// <param name="email">The user's email address.</param>
        /// <param name="password">The user's password.</param>
        /// <returns>
        /// True if the login is successful; otherwise, false.
        /// </returns>
        /// <remarks>
        /// This method calls the UserDbContext to validate the provided email and password.
        /// If the validation is successful, it navigates to the main page; otherwise, it displays an error message.
        /// </remarks>
        /// <author>Drey Smith</author>
        /// <created>01-01-2024</created>
        public bool ValidateLogin(string email, string password)
        {
            // Call the model to validate login
            if (userDbContext.ValidateLogin(email, password))
            {
                view.goToMainPage();
                return true;
            } 
            else
            {
                view.ShowMessage("Invalid Credentials.");
                return false;
            }
        }
    }
}