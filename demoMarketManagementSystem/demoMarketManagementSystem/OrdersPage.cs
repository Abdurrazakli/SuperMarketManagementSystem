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
    public partial class OrdersPage : Form
    {
        string myOrderUserID;
        public OrdersPage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        public OrdersPage(string userID)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            myOrderUserID = userID;
            dataGridView1.DataSource = DatabaseFunctions.getProductsInformation();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
        private void OrdersPage_Load(object sender, EventArgs e)
        {

        }

        private void BtnOrder_Click(object sender, EventArgs e)
        {
            string orderAmount = numericUpDown1.Value.ToString();
            string type = dataGridView1.SelectedRows[0].Cells[6].Value.ToString().Trim().ToLower();
            string productID = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            if(type == "weighted")
            {
                orderAmount = (numericUpDown1.Value * 1000).ToString();
            }

            string query = String.Format("insert into {0}(order_quantity,order_date," +
                "fk_ord_user_id,fk_ord_prod_id,fk_ord_status_id) " +
                "values('{1}',date(sysdate()),'{2}','{3}',1);",
                DatabaseFunctions.dbOrders, orderAmount, myOrderUserID, productID);
            textBox1.Text = query;
            bool res = DatabaseFunctions.runner(query);

            if (res) { MessageBox.Show("Product ordered!"); }
            else { MessageBox.Show("Error in order process"); }
        }
    }
}
