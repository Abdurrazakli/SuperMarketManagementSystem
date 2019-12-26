using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoMarketManagementSystem
{
   public class DatabaseFunctions
    {
        static int userId;
        const string mySQLConnectionString = @"server=localhost;user id=csharp;password=data1234;database=storemanagement";
        static MySqlConnection conn;
        public const string dbUsers = "storemanagement.users";
        public const string dbCategories = "storemanagement.categories",
            dbOrders = "storemanagement.orders",
            dbProduct_Type = "storemanagement.Product_Type",
            dbProducts = "storemanagement.Products",
            dbReceptions = "storemanagement.Receptions",
            dbSales = "storemanagement.Sales",
            dbSales_Detailed = "storemanagement.Sales_Detailed",
            dbStatus_Orders = "storemanagement.Status_Orders",
            dbStatus_Sales = "storemanagement.Status_Sales",
            dbSuppliers = "storemanagement.Suppliers";

        private static bool connectToDatabase()
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
        private static bool closeConnectionToDatabase()
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

        public static DataTable select(string query)
        {
            if (connectToDatabase())
            {
                try
                {
                    string command = query;
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                };
                bool ans = closeConnectionToDatabase();
            }
            return null;
        }
       
        public static bool runner(string query)
        {
            bool result = false;
            if (connectToDatabase())
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = conn;
                    cmd.ExecuteNonQuery();
                    result = true;
                }
                catch (Exception e) { MessageBox.Show("Runner function error:" + e.ToString()); }
                if (!closeConnectionToDatabase()) MessageBox.Show("Connection error Runner");
            }
            return result;
        }
        public static int count(string query)
        {
            int count = -1;

            if (connectToDatabase())
            {
                try
                {
                    string command = query;
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    count = int.Parse(cmd.ExecuteScalar() + "");
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                };
            }

            return count;
        }
        public static string selectScalar(string query)
        {
            string result = null;
            if (connectToDatabase())
            {
                try
                {
                    string command = query;
                    MySqlCommand cmd = new MySqlCommand(command, conn);
                    result = cmd.ExecuteScalar().ToString();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                };
            }
            return result;
        }
        public static DataTable getProductsInformation()
        {
            string query = "select * from storemanagement.view_products;";
            return DatabaseFunctions.select(query);
        }
    }
       


}
