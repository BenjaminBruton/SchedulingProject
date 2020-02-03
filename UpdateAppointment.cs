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
using System.Globalization;

namespace C969___BOP1___BBruton___Scheduling_Project
{
    public partial class UpdateAppointment : Form
    {
        public UpdateAppointment()
        {
            InitializeComponent();
        }

        public Dashboard mainFormObject;
        public static Dictionary<string, string> aForm = new Dictionary<string, string>();

        public static bool updateAppointment(Dictionary<string, string> updatedForm)
        {
            MySqlConnection c = new MySqlConnection(Classes.DataTool.con);
            c.Open();

            // UPDATES CUSTOMERS TABLE
            string recUpdate = $"UPDATE appointment" +
                $" SET customerId = '{updatedForm["customerId"]}', start = '{updatedForm["start"]}', end = '{updatedForm["end"]}', type = '{updatedForm["type"]}', lastUpdate = '{Classes.DataTool.createTimestamp()}', lastUpdateBy = '{Classes.DataTool.getCurrentUserName()}'" +
                $" WHERE appointmentId = '{aForm["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(recUpdate, c);
            int appointmentUpdated = cmd.ExecuteNonQuery();

            if (appointmentUpdated != 0)
                return true;
            else
                return false;
        }

        private void btnSearchAppID_Click(object sender, EventArgs e)
        {
            string appointmentId = searchAppID.Text;
            aForm = Classes.DataTool.getAppointmentDetails(appointmentId);
            txtBoxCustomerID.Text = aForm["customerId"];
            txtBoxType.Text = aForm["type"];
            // "MM/dd/yyyy HH:mm tt";
            // TODO: Some sort of string parsing issue to fix here
                
            pickerStartTime.Value = DateTime.Parse(Classes.DataTool.convertToTimezone(aForm["start"]));
            pickerEndTime.Value = DateTime.Parse(Classes.DataTool.convertToTimezone(aForm["end"]));
        }

        private void btnUpdateApp_Click(object sender, EventArgs e)
        {
            Dictionary<string, string> updatedForm = new Dictionary<string, string>();
            updatedForm.Add("type", txtBoxType.Text);
            updatedForm.Add("customerId", txtBoxCustomerID.Text);
            updatedForm.Add("start", pickerStartTime.Value.ToUniversalTime().ToString("u"));
            updatedForm.Add("end", pickerEndTime.Value.ToUniversalTime().ToString("u"));

            if (updateAppointment(updatedForm))
            {
                mainFormObject.updateCalendar();
                MessageBox.Show("Update Complete!");
                Close();
            }
            else
                MessageBox.Show("Update could not complete");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
