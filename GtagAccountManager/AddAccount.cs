using System;
using System.Drawing;
using System.Windows.Forms;

namespace GtagAccountManager
{
    public partial class AddAccount : Form
    {
        // Properties to hold the entered data
        public string username { get; private set; }
        public string password { get; private set; }
        public string Status { get; private set; }
        public string TimeLeft { get; private set; }

        // Placeholders
        private const string UserPlaceholder = "Username";
        private const string PassPlaceholder = "Password";
        private const string BanTimePlaceholder = "Ban Time (hours)";

        public AddAccount(string existingUsername = "", string existingPassword = "", string existingStatus = "", string existingTimeLeft = "")
        {
            InitializeComponent();

            // Populate status ComboBox
            statuscomboBox.Items.AddRange(new object[] { "Unchecked", "Unbanned", "Banned" });

            // Pre-fill fields if values are provided
            Username.Text = string.IsNullOrEmpty(existingUsername) ? UserPlaceholder : existingUsername;
            Password.Text = string.IsNullOrEmpty(existingPassword) ? PassPlaceholder : existingPassword;
            BanTime.Text = string.IsNullOrEmpty(existingTimeLeft) ? BanTimePlaceholder : existingTimeLeft;
            statuscomboBox.SelectedItem = string.IsNullOrEmpty(existingStatus) ? "Unchecked" : existingStatus;

            // Show or hide the BanTime text box based on the existing status
            ToggleBanTimeVisibility(existingStatus);

            // Set form title
            this.Text = string.IsNullOrEmpty(existingUsername) ? "Add Account" : "Edit Account";

            // Hook up the event handler for statuscomboBox changes
            statuscomboBox.SelectedIndexChanged += (sender, e) =>
            {
                ToggleBanTimeVisibility(statuscomboBox.SelectedItem?.ToString());
            };

            // Placeholder text event handlers
            Username.Enter += (sender, e) => RemovePlaceholder(Username, UserPlaceholder);
            Username.Leave += (sender, e) => SetPlaceholder(Username, UserPlaceholder);
            Password.Enter += (sender, e) => RemovePlaceholder(Password, PassPlaceholder);
            Password.Leave += (sender, e) => SetPlaceholder(Password, PassPlaceholder);
            BanTime.Enter += (sender, e) => RemovePlaceholder(BanTime, BanTimePlaceholder);
            BanTime.Leave += (sender, e) => SetPlaceholder(BanTime, BanTimePlaceholder);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            // Retrieve values from controls
            username = Username.Text.Trim();
            password = Password.Text.Trim();
            Status = statuscomboBox.SelectedItem?.ToString() ?? "Unchecked";
            TimeLeft = BanTime.Text.Trim();

            // Validate the inputs
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Username and password cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Close the form with DialogResult.OK
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ToggleBanTimeVisibility(string status)
        {
            if (status == "Banned")
            {
                BanTime.Visible = true;
            }
            else
            {
                BanTime.Visible = false;
            }
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.White;
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }
    }
}
