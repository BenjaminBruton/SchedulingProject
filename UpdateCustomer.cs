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
    public partial class UpdateCustomer : Form
    {
        public UpdateCustomer()
        {
            InitializeComponent();
        }

        public static Dictionary<string, string> cForm = new Dictionary<string, string>();

        public bool updateCustomer(Dictionary<string, string> updatedForm)
        {
            MySqlConnection c = new MySqlConnection(Classes.DataTool.con);
            c.Open();

            // UPDATES CUSTOMER TABLE
            string recUpdate = $"UPDATE customer" +
                $" SET customerName = '{updatedForm["customerName"]}', active = '{updatedForm["active"]}', lastUpdate = '{Classes.DataTool.createTimestamp()}', lastUpdateBy = '{Classes.DataTool.getCurrentUserName()}'" +
                $" WHERE customerName = '{cForm["customerName"]}'";
            MySqlCommand cmd = new MySqlCommand(recUpdate, c);
            int customerUpdated = cmd.ExecuteNonQuery();

            // UPDATES ADDRESS TABLE
            recUpdate = $"UPDATE address" +
                $" SET address = '{updatedForm["address"]}', postalCode = '{updatedForm["zip"]}', phone = '{updatedForm["phone"]}', lastUpdate = '{Classes.DataTool.createTimestamp()}', lastUpdateBy = '{Classes.DataTool.getCurrentUserName()}'" +
                $" WHERE address = '{cForm["address"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int addressUpdated = cmd.ExecuteNonQuery();

            // UPDATES CITY TABLE
            recUpdate = $"UPDATE city" +
                $" SET city = '{updatedForm["city"]}', lastUpdate = '{Classes.DataTool.createTimestamp()}', lastUpdateBy = '{Classes.DataTool.getCurrentUserName()}'" +
                $" WHERE city = '{cForm["city"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int cityUpdated = cmd.ExecuteNonQuery();

            // UPDATES COUNTRY TABLE
            recUpdate = $"UPDATE country" +
                $" SET country = '{updatedForm["country"]}', lastUpdate = '{Classes.DataTool.createTimestamp()}', lastUpdateBy = '{Classes.DataTool.getCurrentUserName()}'" +
                $" WHERE country = '{cForm["country"]}'";
            cmd = new MySqlCommand(recUpdate, c);
            int countryUpdated = cmd.ExecuteNonQuery();

            c.Close();

            if (customerUpdated != 0 && addressUpdated != 0 && cityUpdated != 0 && countryUpdated != 0)
                return true;
            else
                return false;
        }

        private void btnSearchUpdateCustomer_Click(object sender, EventArgs e)
        {
            int customerId = Classes.DataTool.findCustomer(searchUpdateCustomer.Text);
            if (customerId != 0)
            {
                cForm = Classes.DataTool.getCustomerDetails(customerId);
                txtBoxName.Text = cForm["customerName"];
                txtBoxPhone.Text = cForm["phone"];
                txtBoxAddress.Text = cForm["address"];
                txtBoxCity.Text = cForm["city"];
                txtBoxZip.Text = cForm["zip"];
                txtBoxCountry.Text = cForm["country"];
                if (cForm["active"] == "True")
                    radialActiveYes.Checked = true;
                else
                    radialActiveNo.Checked = true;
            }
            else
            {
                MessageBox.Show("Unable to find a customer by that name");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedForm = new Dictionary<string, string>();
            updatedForm.Add("customerName", txtBoxName.Text);
            updatedForm.Add("phone", txtBoxPhone.Text);
            updatedForm.Add("address", txtBoxAddress.Text);
            updatedForm.Add("city", txtBoxCity.Text);
            updatedForm.Add("zip", txtBoxZip.Text);
            updatedForm.Add("country", txtBoxCountry.Text);
            updatedForm.Add("active", radialActiveYes.Checked ? "1" : "0");

            if (updateCustomer(updatedForm))
            {
                MessageBox.Show("Update Complete!");
            }
            else
            {
                MessageBox.Show("Update Could not complete");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
