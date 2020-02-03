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
    public partial class AddAppointment : Form
    {
        public AddAppointment()
        {
            InitializeComponent();
            pickerEndTime.Value = pickerEndTime.Value.AddHours(1);
        }

        public Dashboard mainFormObject;

        public static bool appHasConflict(DateTime startTime, DateTime endTime)
        {
            foreach (var app in Classes.DataTool.getAppointments().Values)
            {
                if (startTime < DateTime.Parse(app["end"].ToString()) && DateTime.Parse(app["start"].ToString()) < endTime)
                    return true;
            }
            return false;
        }

        public static bool appIsOutsideBusinessHours(DateTime startTime, DateTime endTime)
        {
            startTime = startTime.ToLocalTime();
            endTime = endTime.ToLocalTime();
            DateTime businessStart = DateTime.Today.AddHours(8); // 8am
            DateTime businessEnd = DateTime.Today.AddHours(17); // 5pm
            if (startTime.TimeOfDay > businessStart.TimeOfDay && startTime.TimeOfDay < businessEnd.TimeOfDay &&
                endTime.TimeOfDay > businessStart.TimeOfDay && endTime.TimeOfDay < businessEnd.TimeOfDay)
                return false;

            return true;
        }

        private void AddAppointment_Load(object sender, EventArgs e)
        {

        }

        private void btnAddApp_Click_1(object sender, EventArgs e)
        {
            string timestamp = Classes.DataTool.createTimestamp();
            int userId = Classes.DataTool.getCurrentUserID();
            string username = Classes.DataTool.getCurrentUserName();
            DateTime startTime = pickerStartTime.Value.ToUniversalTime();
            DateTime endTime = pickerEndTime.Value.ToUniversalTime();

            try
            {
                if (appHasConflict(startTime, endTime))
                    throw new Classes.AppointmentExceptions();
                else
                {
                    try
                    {
                        if (appIsOutsideBusinessHours(startTime, endTime))
                            throw new Classes.AppointmentExceptions();
                        else
                        {
                            Classes.DataTool.createRecord(timestamp, username, "appointment", $"'{txtBoxCustomerID.Text}', '{pickerStartTime.Value.ToUniversalTime().ToString("u")}', '{pickerEndTime.Value.ToUniversalTime().ToString("u")}', '{txtBoxType.Text}'", userId);
                            mainFormObject.updateCalendar();
                            Close();
                        }
                    }
                    catch (Classes.AppointmentExceptions ex) { ex.businessHours(); }
                }
            }
            catch (Classes.AppointmentExceptions ex) { ex.appOverlap(); }
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        public static Dictionary<string, string> aForm = new Dictionary<string, string>();
        private void btnSearchCust_Click(object sender, EventArgs e)
        {
            int customerId = Classes.DataTool.findCustomer(txtBoxCustomerID.Text);
            if (customerId != 0)
            {
                aForm = Classes.DataTool.getCustomerDetails(customerId);
                lblCustName.Text = aForm["customerName"];
                
            }
            else
            {
                MessageBox.Show("Unable to find a customer with that ID");
            }
        }
    }
}
