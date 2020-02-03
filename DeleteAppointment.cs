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
    public partial class DeleteAppointment : Form
    {
        public DeleteAppointment()
        {
            InitializeComponent();
        }

        public Dashboard mainFormObject;
        public static Dictionary<string, string> appointmentDetails = new Dictionary<string, string>();

        public static bool deleteAppointment()
        {
            MySqlConnection c = new MySqlConnection(Classes.DataTool.con);
            c.Open();

            // DELETE THE APPOINTMENT
            string recDelete = $"DELETE FROM appointment" +
                $" WHERE appointmentId = '{appointmentDetails["appointmentId"]}'";
            MySqlCommand cmd = new MySqlCommand(recDelete, c);
            int appointmentDeleted = cmd.ExecuteNonQuery();

            c.Close();

            if (appointmentDeleted != 0)
                return true;
            else
                return false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDeleteApp_Click(object sender, EventArgs e)
        {
                // MESSAGE CONFIRMS DELETION
                DialogResult confirmDelete = MessageBox.Show("Are you sure you want to delete this appointment?", "Deletion Confirm", MessageBoxButtons.YesNo);
                if (confirmDelete == DialogResult.Yes)
                {
                    // DELETES CUST RECORD
                    if (deleteAppointment())
                    {
                        mainFormObject.updateCalendar();
                        MessageBox.Show($"Customer: {appointmentDetails["type"]} was successfully deleted");
                    }
                    else
                        MessageBox.Show($"Customer: {appointmentDetails["type"]} could not be deleted");
                }

                Close();
            }

        private void btnAppSearch_Click(object sender, EventArgs e)
        {
            string appointmentId = searchAppID.Text;
            appointmentDetails = Classes.DataTool.getAppointmentDetails(appointmentId);
            lblCustomerID.Text = appointmentDetails["customerId"];
            lblAppType.Text = appointmentDetails["type"];
            lblStart.Text = appointmentDetails["start"];
            lblEnd.Text = appointmentDetails["end"];
        }

       
    }
    }
    
