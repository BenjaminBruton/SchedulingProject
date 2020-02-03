using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___BOP1___BBruton___Scheduling_Project
{
    public partial class AddCustomer : Form
    {
        public AddCustomer()
        {
            InitializeComponent();
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            string timestamp = Classes.DataTool.createTimestamp();
            string userName = Classes.DataTool.getCurrentUserName();
            if (string.IsNullOrEmpty(txtBoxCountry.Text) ||
                string.IsNullOrEmpty(txtBoxCity.Text) ||
                string.IsNullOrEmpty(txtBoxAddress.Text) ||
                string.IsNullOrEmpty(txtBoxZip.Text) ||
                string.IsNullOrEmpty(txtBoxPhone.Text) ||
                string.IsNullOrEmpty(txtBoxName.Text) ||
                (radialActiveYes.Checked == false && radialActiveNo.Checked == false))
            {
                MessageBox.Show("Please enter all fields");
            }
            else
            {
                int countryId = Classes.DataTool.createRecord(timestamp, userName, "country", $"'{txtBoxCountry.Text}'");
                int cityId = Classes.DataTool.createRecord(timestamp, userName, "city", $"'{txtBoxCity.Text}', '{countryId}'");
                int addressId = Classes.DataTool.createRecord(timestamp, userName, "address", $"'{txtBoxAddress.Text}', '', '{cityId}', '{txtBoxZip.Text}', '{txtBoxPhone.Text}'");
                Classes.DataTool.createRecord(timestamp, userName, "customer", $"'{txtBoxName.Text}', '{addressId}', '{(radialActiveYes.Checked ? 1 : 0)}'");

                Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
