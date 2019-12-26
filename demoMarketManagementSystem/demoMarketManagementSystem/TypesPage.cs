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
    public partial class TypesPage : Form
    {
        string currentWorkType;
        public TypesPage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        public TypesPage(string type)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            currentWorkType = type;
            switch (currentWorkType)
            {
                case "categories":
                    categoriesLoad();
                    break;
                case "general":
                    generalTypeLoad();
                    break;
                default: break;
            }
        }


        private void Label_Name_Click(object sender, EventArgs e)
        {
            
        }
        private void generalTypeLoad()
        {
            label_Name.Text = "It will be activated \r\nafter choosing an operation";
            panel1.Enabled = false;
        }
       
        private void categoriesLoad()
        {
            label_choose.Text = "Welcome!";
            comboBox1.Visible = false;
            string query = "select * from storemanagement.categories order by category_name;";
            dataGridView1.DataSource = DatabaseFunctions.select(query);
            textBoxEntry.Text = null;
        }
        private void insertTable(string tableName,string columnName)
        {
            string value = textBoxEntry.Text.Trim().ToUpper();
            string query = String.Format("insert into storemanagement.{0}({1}) values('{2}');",tableName,columnName,value);

            bool added = DatabaseFunctions.runner(query);
            if (added) { MessageBox.Show("Succesfully added"); }
            else { MessageBox.Show("Error in new creation in "+tableName); }
        }
        private void Btn_add_Click(object sender, EventArgs e)
        {
            switch (currentWorkType)
            {
                case "categories":
                    insertTable("categories", "category_name");
                    categoriesLoad();
                    break;
                case "general":
                    switch (comboBox1.SelectedIndex)
                    {
                        case 0: //sales status
                            insertTable("status_sales", "st_sales_description");
                            break;
                        case 1: //product
                            insertTable("product_type", "prodtype_name");
                            break;
                        case 2: //order
                            insertTable("status_orders", "st_orders_description");
                            break;
                        default: break;

                    }
                    check();
                    break;
                default: break;
            }
        }
        private void salesStatusLoad()
        {
            string query = "select * from storemanagement.status_sales;";
            dataGridView1.DataSource = DatabaseFunctions.select(query);
            textBoxEntry.Text = null;
        }

        private void ordersStatusLoad()
        {
            string query = "select * from storemanagement.status_orders;";
            dataGridView1.DataSource = DatabaseFunctions.select(query);
            textBoxEntry.Text = null;
        }
        private void productTypeStatusLoad()
        {
            string query = "select * from storemanagement.product_type;";
            dataGridView1.DataSource = DatabaseFunctions.select(query);
            textBoxEntry.Text = null;
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            check();
        }
        private void check()
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: //sales status
                    salesStatusLoad();
                    break;
                case 1: //product
                    productTypeStatusLoad();
                    break;
                case 2: //order
                    ordersStatusLoad();
                    break;
                default: break;

            }
            label_Name.Text = "Description";
            panel1.Enabled = true;
        }
    }
}
