/// <summary>
/// LoginForm serves as the user interface for user authentication in the licensure application.
/// Users can enter their credentials and attempt to log in.
/// </summary>
/// <remarks>
/// This form is responsible for handling user login attempts and displaying the login status.
/// It interacts with the UserController to validate user credentials against the database.
/// </remarks>
/// <author>Drey Smith</author>
/// <created>01/01/2024</created>

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminDB
{
    public partial class LoginForm : Form
    {
        // instiantiate class level vars
        UserController controller;
        
        /// <summary>
        /// Constructor Method for the LoginForm
        /// </summary>
        /// <param name="dbContext"></param>
        public LoginForm(UserDbContext dbContext)
        {
            // set up ui and controller
            InitializeComponent();
            controller = new UserController(this, dbContext);
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // no init logic needed for login page at current development stage
        }

        /// <summary>
        /// Handles the click event of the Sign In button.
        /// Validates user input, checks the credentials in the database, and displays the login status.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments.</param>

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            // Get values from textboxes
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Validate inside the database via the controller

            // For simplicity as we build front end
            bool isValidLogin = controller.ValidateLogin(email, password);

            // Display success or failure message
            if (isValidLogin)
            {
                lblMessage.Text = "Login Successful";
                lblMessage.ForeColor = Color.Green; // indicate success
            }
            else
            {
                lblMessage.Text = "Login Failed";
                lblMessage.ForeColor = Color.Red; // indicate failure
            }
        }

        /// <summary>
        /// Shows message passed inside of a label
        /// </summary>
        /// <param name="message"></param>
        public void ShowMessage(string message)
        {
            lblMessage.Text += message;
        }
        /// <summary>
        /// Called on login success, opens MainForm
        /// </summary>
        public void goToMainPage()
        {
            // close current page
            this.Hide();

            // instantiate main page
            MainForm mainForm = new MainForm();

            // show main form
            mainForm.ShowDialog();
        }
    }
}
