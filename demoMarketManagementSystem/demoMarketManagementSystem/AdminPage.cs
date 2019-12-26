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
    public partial class AdminPage : Form
    {
        string adminID,name="",surname="",username="",userrole="";
        string databaseName = "storemanagement.users";
        const string mySQLConnectionString = @"server=localhost;user id=csharp;password=data1234;database=storemanagement";
        MySqlConnection conn;
        
        public AdminPage()
        {
            InitializeComponent();
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

        }
        public AdminPage(string AdminID)
        {
            adminID = AdminID;
            InitializeComponent();
            dataGridView1.MultiSelect = true;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
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
        private void btnSearch_Click(object sender, EventArgs e)
        {
            setAll();
            bool ans = select(generateSelectQuery());
            setAllToNull();
        }
        private string generateSelectQuery()
        {
           string query = "select u_name as NAME,u_surname as SURNAME,"
            + " u_user_name as USERNAME, u_role as ROLE, u_reg_date as REGISTIRATION_DATE"
            + " from " + databaseName + " where u_status = 1 ";

            if (name.Length > 0)
                query += String.Format("and u_name ='{0}' ", name);
            if (surname.Length > 0)
                query += String.Format("and u_surname ='{0}' ", surname);
            if (username.Length > 0)
                query += String.Format("and u_user_name ='{0}' ", username);
            if (userrole.Length > 0)
                query += String.Format("and u_role ='{0}' ", userrole);
            return query;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           if (e.RowIndex != -1 && dataGridView1.SelectedRows.Count > 0) {
                //  textBoxName.Text = dataGridView1.sel
                textBoxName.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                textBoxSurname.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBoxUsername.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                comboBoxUserRole.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            }
        }

        private void btnUpdateSelectedUser_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Multiple Selection is not allowed for Update command");
                dataGridView1.ClearSelection();
            }
            else if(dataGridView1.SelectedRows.Count == 1)
            {
                if (update())
                {
                    MessageBox.Show("Successfully updated!");
                    setAllToNull();
                    bool y = select(generateSelectQuery());
                   // MessageBox.Show(y.ToString());
                    
                }
            }

        }

        private bool update()
        {
            string query = "update " + databaseName + " set ";
            string subpart = null;
            string currentUsername = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            setAll();

            if (name.Length > 0)
                if(String.IsNullOrEmpty(subpart))
                subpart = String.Format("u_name ='{0}'", name);
            if (surname.Length > 0)
            {
                if (String.IsNullOrEmpty(subpart))
                    subpart += String.Format("u_surname ='{0}', ", surname);
                else
                    subpart += String.Format(" ,u_surname ='{0}' ", surname);
            }
            if (username.Length > 0)
            {
                if (String.IsNullOrEmpty(subpart))
                    subpart += String.Format("u_user_name ='{0}' ", username);
                else
                    subpart += String.Format(",u_user_name ='{0}' ", username);
            }
            if (userrole.Length > 0)
            {
                if (String.IsNullOrEmpty(subpart))
                    subpart += String.Format(" u_role ='{0}' ", userrole);
                else
                    subpart += String.Format(" ,u_role ='{0}' ", userrole);
            }
            query += subpart + "where " + String.Format("u_user_name ='{0}' ", currentUsername);
            bool res = false;
            if(connectToDatabase())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch(Exception e) { MessageBox.Show("Update function error:" + e.ToString()); }
                if (!closeConnectionToDatabase()) MessageBox.Show("Connection error update");
            }
            return res;
        }

        private void btnDeleteSelectedUser_Click(object sender, EventArgs e)
        {
            if (connectToDatabase())
            {
                for(int i = 0; i < dataGridView1.SelectedRows.Count;i++)
                {
                    deleteUser(dataGridView1.SelectedRows[i].Cells[2].Value.ToString());
                }
            }
            if (!closeConnectionToDatabase()) MessageBox.Show("Connection error delete");
            bool y = select(generateSelectQuery());
        }

        private void deleteUser(string userid) // it doesn't close connection its own
        {
            /*
            string query = "delete from " + databaseName + " where "
                + String.Format("u_user_name ='{0}' ", userid);
                */
            string query = "update "+databaseName +" set u_status = 0 where " 
                + String.Format("u_user_name ='{0}' ", userid);
            bool res = false;
            //textBoxName.Text = query;
            try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    res = true;
                }
                catch (Exception e) { MessageBox.Show("Delete function error:" + e.ToString()); }

            //return res;
            }

        private void btnCreateNewUser_Click(object sender, EventArgs e)
        {
            UserCreation usercr = new UserCreation();
            usercr.ShowDialog();
        }

        private void BtnResetUserPassword_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count < 1)
                MessageBox.Show("Please choose at least one user to reset password");
            else
            {
                DialogResult result = MessageBox.Show("Are you sure to reset passwords for selected users?","Confirmation",MessageBoxButtons.YesNo);
                List<string> errors = new List<string>();

                if(result==DialogResult.Yes)
                {
                    string defaulPassword = "123456789";
                    //changing passwords
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        string currentUsername = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                        string query = String.Format("update {0} set u_password = '{1}' where u_user_name = '{2}';", databaseName, defaulPassword, currentUsername);
                        bool check = DatabaseFunctions.runner(query);
                        if (check == false)
                        {
                            errors.Add(currentUsername);
                        }
                    }

                    if (errors.Count > 0) {
                        MessageBox.Show("Some accounts are not resetted.");
                            }
                    else
                        result = MessageBox.Show("Successfully reseted","Success",MessageBoxButtons.OK);

                }
            }

        }

        private void DataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        //Clears selections from datagridview
        private void AdminPage_Click(object sender, EventArgs e)
        {
            dataGridView1.ClearSelection();
        }

        private void AdminPage_DoubleClick(object sender, EventArgs e)
        {
            textBoxName.Text = null;
            textBoxSurname.Text = null;
            textBoxUsername.Text = null;
            comboBoxUserRole.SelectedIndex = -1;
        }

        private void setAll()
        {
            if (textBoxName.Text.Length > 0)
                name = textBoxName.Text;
            if (textBoxSurname.Text.Length > 0)
                surname = textBoxSurname.Text;
            if (textBoxUsername.Text.Length > 0)
                username = textBoxUsername.Text;
            //if(!String.IsNullOrEmpty(comboBoxUserRole.SelectedItem.ToString()))
            if (comboBoxUserRole.SelectedItem != null)
                userrole = comboBoxUserRole.SelectedItem.ToString();
        }
        private void setAllToNull()
        {
            name = "";
            surname = "";
            username = "";
            userrole = "";
        }
        private bool select(string query)
        {
            bool isSelected= false;
            if (connectToDatabase())
            {
                try
                {
                    string command = query;
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;
                    isSelected = true;
                }
                catch (Exception e) { MessageBox.Show(e.ToString());
                    isSelected = false;
                };
                bool ans = closeConnectionToDatabase();
            }

            return isSelected;

        }
        private void AdminPage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
