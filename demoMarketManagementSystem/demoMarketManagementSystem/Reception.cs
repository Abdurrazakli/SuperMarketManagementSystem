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
    public partial class Reception : Form
    {
        public Reception()
        {
            InitializeComponent();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            loadReception();
            loadReceived();

        }
        private void loadReception()
        {
            dataGridView2.DataSource = DatabaseFunctions.select("select * from storemanagement.view_reception_active ");
        }
        private void BtnSearch_Click(object sender, EventArgs e)
        {

        }

        private void loadReceived()
        {
            dataGridView1.DataSource = DatabaseFunctions.select("select * from storemanagement.view_received ");
        }
        private void DataGridView2_DoubleClick(object sender, EventArgs e)
        {
            string orderid = dataGridView2.SelectedRows[0].Cells[0].Value.ToString();
            
            string update = String.Format("update {0} set fk_ord_status_id = 2 where pk_order_id = '{1}' "
                    ,DatabaseFunctions.dbOrders,orderid);

            bool res = DatabaseFunctions.runner(update);
            if (res) { MessageBox.Show("Received!"); }
            else MessageBox.Show("Error in reception");
            loadReception();
        }
    }
}
