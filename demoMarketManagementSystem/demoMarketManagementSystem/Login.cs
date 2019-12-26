using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace demoMarketManagementSystem
{
    public partial class Login : Form
    {
        string userName=null, userPassword=null, userRole = null;
        string userID;
        const string mySQLConnectionString = @"server=localhost;user id=csharp;password=data1234;database=storemanagement";
        MySqlConnection conn;
        public Login()
        {
            InitializeComponent();
            //fixing size and preventing resizing at runtime
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void setUserCredentials(string userName, string password)
        {
            this.userName = userName.ToLower().Trim();
            this.userPassword = password;
   
        }
        private bool connectToDatabase() {
            conn = new MySqlConnection(mySQLConnectionString);
            try {
                conn.Open();
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Connection failed");
                return false;
            }
        }
        private bool closeConnectionToDatabase()
        {
            try
            {
                conn.Close();
                return true;
            }
            catch {
                MessageBox.Show("Connection couldn't closed");
                return false;
            }
        }
        private bool isUserFound(string username, string password)
        {
            if(connectToDatabase())
            {
                try
                {
                    string command = String.Format("select u_role from storemanagement.users where u_user_name = '{0}' and u_password = '{1}'", username, password);
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if(reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            userRole = reader.GetString(0);
                        }
                        bool ans = closeConnectionToDatabase();
                        // MessageBox.Show("YES");
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Access Denied. Username or password is wrong");
                        bool ans = closeConnectionToDatabase();
                        return false;
                    }
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); bool ans = closeConnectionToDatabase(); };
                
            }
          //  MessageBox.Show("Access Denied. Username or password is wrong");
            return false;
            
        }
        private bool IsFieldsEmpty(TextBox obj,TextBox obj2)
        {
            if(String.IsNullOrEmpty(obj.Text)|| String.IsNullOrEmpty(obj2.Text))
            {
                MessageBox.Show("Please fill all fields");
                return true;
            }
            return false;
         }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!IsFieldsEmpty(textboxUsername, textboxPassword))
            {
                //
                setUserCredentials(textboxUsername.Text, textboxPassword.Text);
                if (isUserFound(userName, userPassword))
                {
                    setUserID();
                    openUsersPage(userRole);
                }
            }
        }
        private void setUserID()
        {
            string userid = DatabaseFunctions.selectScalar(
                String.Format("select u_user_id from storemanagement.users" +
                " where u_user_name = '{0}' and u_password = '{1}';",userName,userPassword));
            this.userID = userid;
        }
        private void openUsersPage(string userRole)
        {

            switch (userRole)
            {
                case "admin":
                    AdminPage admin = new AdminPage(userID);
                   // this.Hide();
                    admin.ShowDialog();
                    break;
                case "dataman":
                    DatamanPage dp = new DatamanPage(userID);
                    dp.ShowDialog();
                    break;
                default: break;
            }
        }
    }
}
