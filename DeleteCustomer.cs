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

namespace C969___BOP1___BBruton___Scheduling_Project
{
    public partial class DeleteCustomer : Form
    {
        public DeleteCustomer()
        {
            InitializeComponent();
        }

        public static Dictionary<string, string> customerDetails = new Dictionary<string, string>();

        public bool deleteCustomer()
        {
            MySqlConnection c = new MySqlConnection(Classes.DataTool.con);
            c.Open();
           

            string fKC = "SET FOREIGN_KEY_CHECKS = 0";
            MySqlCommand cmmd = new MySqlCommand(fKC, c);
            int setForeignKeyOff = cmmd.ExecuteNonQuery();

            // DELETES COUNTRY 
            string recUpdate = $"DELETE FROM country" +
                $" WHERE country = '{customerDetails["country"]}'";
            MySqlCommand cmd = new MySqlCommand(recUpdate, c);
            int countryUpdated = cmd.ExecuteNonQuery();

            // DELETES CITY 
            recUpdate = $"DELETE FROM city" +
                $" WHERE city = '{customerDetails["city"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int cityUpdated = cmd.ExecuteNonQuery();

            // DELETES ADDRESS 
            recUpdate = $"DELETE FROM address" +
                $" WHERE address = '{customerDetails["address"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int addressUpdated = cmd.ExecuteNonQuery();

            // DELETES CUSTOMER
            recUpdate = $"DELETE FROM customer" +
                $" WHERE customerName = '{customerDetails["customerName"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int customerUpdated = cmd.ExecuteNonQuery();

            // DELETES ASSOCIATED APPOINTMENT 
            recUpdate = $"DELETE FROM appointment" +
                $" WHERE customerId = '{customerDetails["customerId"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int appointmentUpdated = cmd.ExecuteNonQuery();


            fKC = "SET FOREIGN_KEY_CHECKS = 1";
            cmmd = new MySqlCommand(fKC, c);
            setForeignKeyOff = cmmd.ExecuteNonQuery();




            c.Close();

            if (appointmentUpdated != 0 && customerUpdated != 0 && addressUpdated != 0 && cityUpdated != 0 && countryUpdated != 0)
                return true;
            else
                return false;
        }

        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            // SEARCH DB FOR CUSTOMER AND DISPLAY WITH LABELS
            int customerId = Classes.DataTool.findCustomer(searchCustomer.Text);
            if (customerId != 0)
            {
                customerDetails = Classes.DataTool.getCustomerDetails(customerId);
                lblName.Text = customerDetails["customerName"];
                lblPhone.Text = customerDetails["phone"];
                lblAddress.Text = customerDetails["address"];
                lblCity.Text = customerDetails["city"];
                lblZipCode.Text = customerDetails["zip"];
                lblCountry.Text = customerDetails["country"];
                if (customerDetails["active"] == "True")
                    lblActive.Text = "True";
                else
                    lblActive.Text = "False";
                
                
            }
            else
            {
                MessageBox.Show("Unable to find a customer by that name");
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            // MESSAGE CONFIRMS DELETION
            DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this contact?", "Deletion Confirm", MessageBoxButtons.YesNo);
            if (confirmDelete == DialogResult.Yes)
            {
                // DELETES CUST RECORD
                MessageBox.Show($"Customer: {customerDetails["customerName"]} was successfully deleted");
                
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
