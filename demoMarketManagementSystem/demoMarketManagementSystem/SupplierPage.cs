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
    public partial class SupplierPage : Form
    {
        public SupplierPage()
        {
            InitializeComponent();
            showAllSuppliers();
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
        }
        private void showAllSuppliers() {
            string query = "select * from storemanagement.suppliers order by sup_companyname asc;";
            dataGridView1.DataSource = DatabaseFunctions.select(query);
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            String companyName, type, adress, personNameSurname, number, email;
            companyName = textBoxCompanyName.Text.Trim().ToUpper();
            type = comboBoxType.SelectedItem.ToString().Trim().ToUpper();
            adress = textBoxAdress.Text.Trim().ToUpper();
            personNameSurname = textBoxNameSurname.Text.Trim().ToUpper();
            number = textBoxNumber.Text.Trim();
            email = textBoxEmail.Text.Trim().ToUpper();

            if (String.IsNullOrEmpty(companyName) || String.IsNullOrEmpty(type) ||
                String.IsNullOrEmpty(adress) || String.IsNullOrEmpty(personNameSurname) ||
                String.IsNullOrEmpty(number) || String.IsNullOrEmpty(email))
                MessageBox.Show("Please fill all fields!");
            else {
               string query = String.Format("insert into storemanagement.suppliers " +
                   "(sup_type,sup_companyname,sup_adress,sup_personalname," +
                    "sup_telnumber,sup_email,contract_date) values('{0}', '{1}'," +
                    " '{2}', '{3}', '{4}', '{5}', sysdate());",
                    type,companyName,adress,personNameSurname,number,email);
                bool check = DatabaseFunctions.runner(query);
                if (check) { MessageBox.Show("Successfully added"); }
                else { MessageBox.Show("Error in creating new supplier"); }

                textBoxAdress.Text = null;
                textBoxCompanyName.Text = null;
                textBoxEmail.Text = null;
                comboBoxType.SelectedIndex = -1;
                textBoxNameSurname.Text = null;
                textBoxNumber.Text = null;
            }

        }

        private void BtnEndContract_Click(object sender, EventArgs e)
        {
            int count = 0;
            for(int i = 0;i< dataGridView1.SelectedRows.Count;i++)
            {
                string id = dataGridView1.SelectedRows[i].Cells[0].Value.ToString();
                string ended = dataGridView1.SelectedRows[i].Cells[8].Value.ToString().Trim();
                string query = String.Format("update storemanagement.suppliers " +
                    "set end_date = date(sysdate()) where pk_sup_id = {0}", id);

                if (ended.Length == 0)
                {
                bool res = DatabaseFunctions.runner(query);
                if(res == false) { count++; }
                 }
            }
            if(count > 0)
            { MessageBox.Show("Some items may not be ended"); }
            else { MessageBox.Show("Successfully ended contracts"); }
            showAllSuppliers();
        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            showAllSuppliers();
        }
    }
}
