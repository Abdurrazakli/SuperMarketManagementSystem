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
    public partial class ProductsPage : Form
    {
        
        public ProductsPage()
        {
            InitializeComponent();
            loadElements();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }
        public DataTable getProductsInformation()
        {
            string query = "select * from storemanagement.view_products;";
            return DatabaseFunctions.select(query);
        }
        private void loadComboboxStatus()
        {
            DataTable dt = new DataTable();
            string query = "select st_sales_description from storemanagement.status_sales;";
            dt = DatabaseFunctions.select(query);
            comboBoxStatus.DataSource = dt;
            comboBoxStatus.DisplayMember = "st_sales_description";

        }
        private void loadElements()
        {
            DataTable dt = getProductsInformation();
            loadComboboxStatus();
            dataGridView1.DataSource = dt;
            string query = "select upper(category_name) as category" +
                " from storemanagement.categories;";
            //MySqlDataAdapter da = new MySqlDataAdapter();
            dt = DatabaseFunctions.select(query);
            comboBoxCategory.DataSource = dt;
            comboBoxCategory.DisplayMember = "category";
            
            
            query = "select upper(storemanagement.product_type.prodtype_name) as type " +
                "from storemanagement.product_type;";
            dt = DatabaseFunctions.select(query);
            comboBoxProductType.DataSource = dt;
            comboBoxProductType.DisplayMember = "type";

            query = "select upper(storemanagement.suppliers.sup_companyname) as company " +
                "from storemanagement.suppliers where end_date is null ;";
            dt = DatabaseFunctions.select(query);
            comboBoxSupplier.DataSource = dt;
            comboBoxSupplier.DisplayMember = "company";

            textBoxBarcode.Text = null;
            textBoxBrand.Text = null;
            textBoxName.Text = null;
            textBoxPurchasePrice.Text = null;
            textBoxQuantity.Text = null;
            textBoxSalesPrice.Text = null;
            
        }
        private void BtnAdd_Click(object sender, EventArgs e) //erroru var
        {
            String name, brand, barcode, supplier, 
                category, purchasePrice, salesPrice, 
                quantity, type;

            name = textBoxName.Text.Trim().ToUpper();
            brand = textBoxBrand.Text.Trim().ToUpper();
            barcode = textBoxBarcode.Text.Trim().ToUpper();
            supplier = comboBoxSupplier.Text.ToString().Trim().ToUpper();
            category = comboBoxCategory.Text.ToString().Trim().ToUpper();
            type = comboBoxProductType.Text.ToString().Trim().ToUpper();
            purchasePrice = textBoxPurchasePrice.Text.Trim().ToUpper();
            salesPrice = textBoxSalesPrice.Text.Trim().ToUpper(); 
            quantity = textBoxQuantity.Text.Trim().ToUpper();

            if(String.IsNullOrEmpty(name)|| String.IsNullOrEmpty(brand) || String.IsNullOrEmpty(barcode) ||
                String.IsNullOrEmpty(supplier) || String.IsNullOrEmpty(category) || String.IsNullOrEmpty(type) ||
                String.IsNullOrEmpty(purchasePrice) || String.IsNullOrEmpty(salesPrice) || String.IsNullOrEmpty(quantity))
            {
                MessageBox.Show("Please fill all fields");
            }
            else
            {
                string supplier_id, category_id, type_id;
                supplier_id = DatabaseFunctions.selectScalar(
                    String.Format("select pk_sup_id from storemanagement.suppliers" +
                    " where sup_companyname = '{0}' and end_date is null;", supplier));
                category_id = DatabaseFunctions.selectScalar(
                    String.Format("select pk_category_id from storemanagement.categories " +
                    "where category_name = '{0}';", category));
                type_id = DatabaseFunctions.selectScalar(
                    String.Format("select pk_prodtype_id from storemanagement.product_type " +
                    "where prodtype_name = '{0}';", type));
               
                string query = String.Format("insert into storemanagement.products " +
                    "(prod_name, prod_brand, barcode, prod_quantity, " +
                    "fk_prod_type, purchase_price, sales_price, fk_sup_id," +
                    " fk_category_id,fk_sales_s_id ) " +
                    "values ('{0}','{1}','{2}','{3}'," +
                    "'{4}','{5}','{6}','{7}','{8}',1) ;",name,brand,barcode,quantity,type_id,
                    purchasePrice,salesPrice,supplier_id,category_id);
                
                bool result = DatabaseFunctions.runner(query);

                if (result) { MessageBox.Show("Successfully Added!"); }
                else { MessageBox.Show("Error in creating new product!"); }

                loadElements();
            }
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string product_id = dataGridView1.SelectedRows[0].Cells[0].Value.ToString().Trim();
            string status = comboBoxStatus.Text.Trim();
            if(status.Length > 4) { 
            string status_id = DatabaseFunctions.selectScalar(
                String.Format("select pk_sales_status_id from storemanagement.status_sales" +
                " where st_sales_description = '{0}'", status));
            string update = String.Format("update products set fk_sales_s_id = '{0}'" +
                " where pk_prod_id = '{1}';", status_id, product_id);
            bool res = DatabaseFunctions.runner(update);
            if (res) { MessageBox.Show("Status updated!"); }
            else { MessageBox.Show("Error while updating status of product"); }
                loadElements();
            }
        }
    }
}
