using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoMarketManagementSystem
{
    public partial class UserCreation : Form
    {
        public UserCreation()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        string admin, name = "", surname = "", username = "", userrole = "",password = "",repassword="";
        string databaseName = "storemanagement.users";
        const string mySQLConnectionString = @"server=localhost;user id=csharp;password=data1234;database=storemanagement";
        MySqlConnection conn;
        private bool connectToDatabase()
        {
            conn = new MySqlConnection(mySQLConnectionString);
            try
            {
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed");
                return false;
            }
        }

        private string generateUsername(string role)
        {
            string query = String.Format("select (count(u_role)+1) from storemanagement.users where u_role = '{0}'", role);
            return role.Substring(0, 3) + DatabaseFunctions.count(query).ToString();
        }
        private void ComboBoxUserRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedRole = comboBoxUserRole.SelectedItem.ToString();
            textBoxUsername.Text = generateUsername(selectedRole);
            /*
            switch (selectedRole)
            {
                case "admin":
                    textBoxUsername.Text = get
                    break;
                case "dataman": break;
                case "cashier": break;
                default: break;
            }*/
        }

        private void UserCreation_Load(object sender, EventArgs e)
        {
        }

        private void TimerPasswords_Tick(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = true;
            textBoxRePassword.UseSystemPasswordChar = true;
            timerPasswords.Stop();
        }

        private void TextBoxPassword_DoubleClick(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            textBoxRePassword.UseSystemPasswordChar = false;
            timerPasswords.Interval = 4000;
            timerPasswords.Start();
        }

        private void TextBoxRePassword_DoubleClick(object sender, EventArgs e)
        {
            textBoxPassword.UseSystemPasswordChar = false;
            textBoxRePassword.UseSystemPasswordChar = false;
            timerPasswords.Interval = 4000;
            timerPasswords.Start();
        }

        private void textBoxRePassword_TextChanged(object sender, EventArgs e)
        {

        }

        private bool closeConnectionToDatabase()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch
            {
                MessageBox.Show("Connection couldn't closed");
                return false;
            }
        }
        private void btnValidate_Click(object sender, EventArgs e)
        {
            if(!IsFieldsEmpty(textBoxName,textBoxPassword,textBoxSurname,textBoxUsername,comboBoxUserRole))
                {
                if (setAll())
                {

                    add();
                    MessageBox.Show("Successfully added");
                    this.Close();
                }
                }
        }
        private void add()
        {
            string query = "insert into " + databaseName + "(u_user_name, u_name, u_surname, u_role,u_password, u_reg_date, u_status) values "
                + String.Format("('{0}','{1}','{2}','{3}','{4}',sysdate() ,1)",username,name,surname,userrole,password);
            bool res = false;
            //textBoxName.Text = query;
            bool connect = connectToDatabase();
            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = conn;
                cmd.ExecuteNonQuery();
                textBoxName.Text = query;
                res = true;
            }
            catch (Exception e) { MessageBox.Show("ADD function error:" + e.ToString()); }
            bool close = closeConnectionToDatabase();
        }
        private bool setAll()
        {
            if (textBoxName.Text.Length > 0)
                name = textBoxName.Text;
            if (textBoxSurname.Text.Length > 0)
                surname = textBoxSurname.Text;
            if (textBoxUsername.Text.Length > 0)
                username = textBoxUsername.Text.ToLower().Trim();
            if (comboBoxUserRole.SelectedItem.ToString().Length > 0)
                userrole = comboBoxUserRole.SelectedItem.ToString();
            if (textBoxPassword.Text.Length > 0)
                password = textBoxPassword.Text;
            if (textBoxRePassword.Text.Length > 0)
                repassword = textBoxPassword.Text;

            if(!password.Equals(repassword))
            {
                MessageBox.Show("Passwords should be same");
                return false;
            }
            return true;
            // MessageBox.Show(name + surname + username + userrole + password);
        }
        private bool IsFieldsEmpty(TextBox obj, TextBox obj2,TextBox obj3, TextBox obj4,ComboBox cb)
        {
            if (String.IsNullOrEmpty(obj.Text) || String.IsNullOrEmpty(obj2.Text) || String.IsNullOrEmpty(obj3.Text) || String.IsNullOrEmpty(obj4.Text) || String.IsNullOrEmpty(cb.Text))
            {
                MessageBox.Show("Please fill all fields");
                return true;
            }
            return false;
        }
    }
}
