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
    public partial class DatamanPage : Form
    {
        string myUserID;
        public DatamanPage()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        public DatamanPage(string userID)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            myUserID = userID;
        }
        private void BtnCategories_Click(object sender, EventArgs e)
        {
            TypesPage typesPage = new TypesPage("categories");
            typesPage.ShowDialog();
        }

        private void BtnTypes_Click(object sender, EventArgs e)
        {
            TypesPage typesPage = new TypesPage("general");
            typesPage.ShowDialog();
        }

        private void BtnSuppliers_Click(object sender, EventArgs e)
        {
            SupplierPage supplierPage = new SupplierPage();
            supplierPage.ShowDialog();
        }

        private void BtnProducts_Click(object sender, EventArgs e)
        {
            ProductsPage productsPage = new ProductsPage();
            productsPage.ShowDialog();
        }

        private void BtnOrders_Click(object sender, EventArgs e)
        {
            OrdersPage op = new OrdersPage(myUserID);
            op.ShowDialog();
        }

        private void BtnReception_Click(object sender, EventArgs e)
        {
            Reception reception = new Reception();
            reception.ShowDialog();
        }

        private void DatamanPage_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "Attention", MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
                Application.Exit();

        }
    }
}
