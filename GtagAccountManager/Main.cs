using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace GtagAccountManager
{
    public partial class Main : Form
    {
        private readonly string encryptionKeyFilePath;
        private readonly string accountsFilePath;
        private byte[] encryptionKey;

        public Main()
        {
            InitializeComponent();
            InitializeListView();

            // Set the paths for the encryption key and accounts file
            string appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "Gtag Account Manager");
            Directory.CreateDirectory(appDataPath);
            encryptionKeyFilePath = Path.Combine(appDataPath, "encryptionKey.bin");
            accountsFilePath = Path.Combine(appDataPath, "accounts.txt");

            // Load or generate encryption key
            LoadOrGenerateEncryptionKey();

            // Load data from the accounts file
            LoadData();
        }

        private void InitializeListView()
        {
            account_list.View = View.Details;
            account_list.Columns.Clear();
            account_list.Columns.Add("Username", -2, HorizontalAlignment.Left);
            account_list.Columns.Add("Password", -2, HorizontalAlignment.Left);
            account_list.Columns.Add("Status", -2, HorizontalAlignment.Left);
        }

        private void LoadOrGenerateEncryptionKey()
        {
            if (File.Exists(encryptionKeyFilePath))
            {
                try
                {
                    encryptionKey = File.ReadAllBytes(encryptionKeyFilePath);
                }
                catch
                {
                    // If there's an issue loading the key, generate a new one
                    GenerateNewEncryptionKey();
                }
            }
            else
            {
                GenerateNewEncryptionKey();
            }
        }

        private void GenerateNewEncryptionKey()
        {
            using (Aes aes = Aes.Create())
            {
                aes.GenerateKey();
                encryptionKey = aes.Key;
                File.WriteAllBytes(encryptionKeyFilePath, encryptionKey);
            }
        }

        private byte[] EncryptStringToBytes_Aes(string plainText, Aes aes)
        {
            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(plainText);
                    }
                }

                return ms.ToArray();
            }
        }

        private string DecryptStringFromBytes_Aes(byte[] cipherText, Aes aes)
        {
            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(cipherText))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        return sr.ReadToEnd();
                    }
                }
            }
        }

        private string Encrypt(string plainText)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = encryptionKey;
                aes.GenerateIV();
                byte[] iv = aes.IV;

                byte[] encrypted = EncryptStringToBytes_Aes(plainText, aes);

                // Combine IV and encrypted data
                byte[] combinedData = new byte[iv.Length + encrypted.Length];
                Array.Copy(iv, 0, combinedData, 0, iv.Length);
                Array.Copy(encrypted, 0, combinedData, iv.Length, encrypted.Length);

                return Convert.ToBase64String(combinedData);
            }
        }

        private string Decrypt(string encryptedText)
        {
            byte[] combinedData = Convert.FromBase64String(encryptedText);
            byte[] iv = new byte[16]; // Aes block size
            byte[] cipherText = new byte[combinedData.Length - iv.Length];

            Array.Copy(combinedData, 0, iv, 0, iv.Length);
            Array.Copy(combinedData, iv.Length, cipherText, 0, cipherText.Length);

            using (Aes aes = Aes.Create())
            {
                aes.Key = encryptionKey;
                aes.IV = iv;

                return DecryptStringFromBytes_Aes(cipherText, aes);
            }
        }

        private void SaveData()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(accountsFilePath))
                {
                    foreach (ListViewItem item in account_list.Items)
                    {
                        string username = item.Text;
                        string password = (string)item.Tag; // Retrieve the actual password
                        string status = item.SubItems[2].Text;

                        // Save data as plain text
                        string formattedText = $"{username}:{password}:{status}";
                        writer.WriteLine(formattedText);
                    }
                }

                // Encrypt the file after saving
                EncryptFile(accountsFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the file: {ex.Message}");
            }
        }

        private void LoadData()
        {
            try
            {
                // Decrypt the file if it exists
                if (File.Exists(accountsFilePath))
                {
                    DecryptFile(accountsFilePath);

                    if (File.Exists(accountsFilePath))
                    {
                        string[] lines = File.ReadAllLines(accountsFilePath);

                        foreach (string line in lines)
                        {
                            char delimiter = DetermineDelimiter(line);
                            if (delimiter != '\0')
                            {
                                string[] parts = line.Split(delimiter);
                                if (parts.Length >= 2)
                                {
                                    string username = parts[0].Trim();
                                    string password = parts[1].Trim();
                                    string status = parts.Length > 2 ? ProcessStatus(parts[2].Trim()) : "Unchecked";

                                    // Add account to ListView
                                    AddAccountToListView(username, password, status);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading the file: {ex.Message}");
            }
        }

        private void EncryptFile(string filePath)
        {
            byte[] fileData = File.ReadAllBytes(filePath);
            using (Aes aes = Aes.Create())
            {
                aes.Key = encryptionKey;
                aes.GenerateIV();
                byte[] iv = aes.IV;

                byte[] encryptedData = EncryptStringToBytes_Aes(Encoding.UTF8.GetString(fileData), aes);

                // Combine IV and encrypted data
                byte[] combinedData = new byte[iv.Length + encryptedData.Length];
                Array.Copy(iv, 0, combinedData, 0, iv.Length);
                Array.Copy(encryptedData, 0, combinedData, iv.Length, encryptedData.Length);

                File.WriteAllBytes(filePath, combinedData);
            }
        }

        private void DecryptFile(string filePath)
        {
            if (File.Exists(filePath))
            {
                byte[] combinedData = File.ReadAllBytes(filePath);
                byte[] iv = new byte[16]; // Aes block size
                byte[] encryptedData = new byte[combinedData.Length - iv.Length];

                Array.Copy(combinedData, 0, iv, 0, iv.Length);
                Array.Copy(combinedData, iv.Length, encryptedData, 0, encryptedData.Length);

                using (Aes aes = Aes.Create())
                {
                    aes.Key = encryptionKey;
                    aes.IV = iv;

                    string decryptedData = DecryptStringFromBytes_Aes(encryptedData, aes);
                    File.WriteAllText(filePath, decryptedData);
                }
            }
        }

        private void AddAccountToListView(string username, string password, string status)
        {
            if (account_list.Columns.Count == 0)
            {
                InitializeListView();
            }

            if (IsAccountInList(username))
            {
                MessageBox.Show("An account with this username already exists.", "Duplicate Account", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ListViewItem item = new ListViewItem(username);
            item.SubItems.Add(MaskPassword(password)); // Masked password
            item.SubItems.Add(status);

            // Store the actual password in the Tag property
            item.Tag = password;

            account_list.Items.Add(item);

            foreach (ColumnHeader column in account_list.Columns)
            {
                column.Width = -2;
            }

            // Update the ListInfo text
            UpdateListInfo();

            // Save the updated data to file
            SaveData();
        }

        private string MaskPassword(string password)
        {
            return new string('*', password.Length);
        }

        private void UpdateListInfo()
        {
            int unbannedCount = 0;
            int bannedCount = 0;
            int uncheckedCount = 0;

            foreach (ListViewItem item in account_list.Items)
            {
                string status = item.SubItems[2].Text;
                if (status.Equals("Banned", StringComparison.OrdinalIgnoreCase))
                {
                    bannedCount++;
                }
                else if (status.StartsWith("Banned -", StringComparison.OrdinalIgnoreCase))
                {
                    bannedCount++;
                }
                else if (status.Equals("Unchecked", StringComparison.OrdinalIgnoreCase))
                {
                    uncheckedCount++;
                }
                else
                {
                    unbannedCount++;
                }
            }

            ListInfo.Text = $"Unbanned: {unbannedCount}, Banned: {bannedCount}, Unchecked: {uncheckedCount}";
        }

        private bool IsAccountInList(string username)
        {
            foreach (ListViewItem item in account_list.Items)
            {
                if (item.Text.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        private char DetermineDelimiter(string line)
        {
            if (line.Contains(":"))
                return ':';
            else if (line.Contains("|"))
                return '|';
            else if (line.Contains(" "))
                return ' ';
            else
                return '\0';
        }

        private string ProcessStatus(string status)
        {
            if (status.Equals("banned", StringComparison.OrdinalIgnoreCase))
            {
                return "Banned";
            }
            else if (status.Equals("unbanned", StringComparison.OrdinalIgnoreCase))
            {
                return "Unbanned";
            }
            else if (status.StartsWith("Banned -", StringComparison.OrdinalIgnoreCase))
            {
                return $"Banned - {status.Substring(9).Trim()}";
            }
            else if (int.TryParse(status, out int time))
            {
                return $"Banned - {time}";
            }
            else
            {
                return "Unchecked";
            }
        }

        private void import_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Import Account List";
            openFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                try
                {
                    string[] lines = File.ReadAllLines(filePath);

                    foreach (string line in lines)
                    {
                        char delimiter = DetermineDelimiter(line);
                        if (delimiter != '\0')
                        {
                            string[] parts = line.Split(delimiter);
                            if (parts.Length >= 2)
                            {
                                string username = parts[0].Trim();
                                string password = parts[1].Trim();
                                string status = parts.Length > 2 ? ProcessStatus(parts[2].Trim()) : "Unchecked";

                                AddAccountToListView(username, password, status);
                            }
                        }
                    }

                    MessageBox.Show($"Imported {lines.Count()} accounts!", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while reading the file: {ex.Message}");
                }
            }
        }

        private void export_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Export Account List";
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog.DefaultExt = "txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                try
                {
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        foreach (ListViewItem item in account_list.Items)
                        {
                            string username = item.Text;
                            string password = (string)item.Tag; // Retrieve the actual password
                            string status = item.SubItems[2].Text;

                            string formattedStatus;
                            if (status.Equals("Banned", StringComparison.OrdinalIgnoreCase))
                            {
                                formattedStatus = "banned";
                            }
                            else if (status.Equals("Unbanned", StringComparison.OrdinalIgnoreCase))
                            {
                                formattedStatus = "unbanned";
                            }
                            else if (status.StartsWith("Banned - ", StringComparison.OrdinalIgnoreCase))
                            {
                                formattedStatus = status;
                            }
                            else if (status.Equals("Unchecked", StringComparison.OrdinalIgnoreCase))
                            {
                                formattedStatus = "unchecked";
                            }
                            else
                            {
                                formattedStatus = "unchecked";
                            }

                            string formattedText = $"{username}:{password}:{formattedStatus}";
                            writer.WriteLine(formattedText);
                        }
                    }

                    MessageBox.Show("Export completed successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the file: {ex.Message}");
                }
            }
        }

        private void add_click(object sender, EventArgs e)
        {
            using (AddAccount addForm = new AddAccount())
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    string username = addForm.username;
                    string password = addForm.password;
                    string status = addForm.Status;
                    string timeLeft = addForm.TimeLeft;

                    string formattedStatus = status;
                    if (status == "Banned" && int.TryParse(timeLeft, out int time))
                    {
                        formattedStatus = $"Banned - {time}";
                    }

                    AddAccountToListView(username, password, formattedStatus);
                }
            }
        }

        private void account_list_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ListViewItem item = account_list.HitTest(e.X, e.Y).Item;
                if (item != null)
                {
                    account_list.SelectedItems.Clear();
                    item.Selected = true;
                    contextMenuStrip.Show(account_list, e.Location);
                }
            }
        }

        private void copyUsernameAndPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (account_list.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = account_list.SelectedItems[0];
                string username = selectedItem.Text;
                string password = (string)selectedItem.Tag; // Retrieve the actual password
                string textToCopy = $"{username}:{password}";

                Clipboard.SetText(textToCopy);
                MessageBox.Show("Copied To Clipboard!", "Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (account_list.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = account_list.SelectedItems[0];
                string username = selectedItem.Text;
                string password = (string)selectedItem.Tag; // Retrieve the actual password
                string status = selectedItem.SubItems[2].Text;
                string timeLeft = status.StartsWith("Banned - ") ? status.Substring(9).Trim() : "";

                using (AddAccount addForm = new AddAccount(
                    existingUsername: username,
                    existingPassword: password,
                    existingStatus: status.StartsWith("Banned - ") ? "Banned" : status,
                    existingTimeLeft: timeLeft))
                {
                    if (addForm.ShowDialog() == DialogResult.OK)
                    {
                        selectedItem.Text = addForm.username;
                        selectedItem.SubItems[1].Text = MaskPassword(addForm.password); // Mask the password
                        selectedItem.SubItems[2].Text = addForm.Status == "Banned" && int.TryParse(addForm.TimeLeft, out int time)
                            ? $"Banned - {time}"
                            : addForm.Status;

                        // Update the stored password
                        selectedItem.Tag = addForm.password;
                    }
                }
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (account_list.SelectedItems.Count > 0)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to remove the selected account?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    account_list.Items.Remove(account_list.SelectedItems[0]);

                    // Update the ListInfo text
                    UpdateListInfo();
                }
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            InitializeListView();
            LoadData(); // Load the data when the form loads
            UpdateListInfo(); // Ensure ListInfo is updated when the form loads
        }
    }
}
