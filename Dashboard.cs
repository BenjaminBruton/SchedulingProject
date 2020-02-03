using MySql.Data.MySqlClient;
using System;
using System.Collections;
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
    // TODO: Make form larger, specifically the DGV to accomodate more columns for apopintments
    public partial class Dashboard : Form
    {
        public Main loginForm;
        public Dashboard()
        {
            InitializeComponent();
        }

        //APPOINTMENT REMINDER FUNCTIONALITY
        static public void reminderCheck(DataGridView calendar)
        {
            foreach (DataGridViewRow row in calendar.Rows)
            {
                DateTime now = DateTime.UtcNow;
                DateTime start = DateTime.Parse(row.Cells[2].Value.ToString()).ToUniversalTime();
                TimeSpan nowUntilStartOfApp = now - start;
                if (nowUntilStartOfApp.TotalMinutes >= -15 && nowUntilStartOfApp.TotalMinutes < 1)
                {
                    MessageBox.Show($"Reminder: You have a meeting with {row.Cells[4].Value} at {row.Cells[2].Value}");
                }
            }
        }

        static public Array getCalendar(bool weekView)
        {
            MySqlConnection c = new MySqlConnection(Classes.DataTool.con);
            c.Open();
            // QUERIES DB FOR ALL APPOINTMENTS RELATED TO LOGGED IN USER
            string query = $"SELECT customerId, type, start, end, appointmentId, userId FROM appointment WHERE userid = '{Classes.DataTool.getCurrentUserID()}'";
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();


            Dictionary<int, Hashtable> appointments = new Dictionary<int, Hashtable>();

            // DICTIONARY CREATED WITH ALL APPOINTMENTS
            while (rdr.Read())
            {

                Hashtable appointment = new Hashtable();
                appointment.Add("customerId", rdr[0]);
                appointment.Add("type", rdr[1]);
                appointment.Add("start", rdr[2]);
                appointment.Add("end", rdr[3]);
                appointment.Add("userId", rdr[5]);

                appointments.Add(Convert.ToInt32(rdr[4]), appointment);

            }
            rdr.Close();


            // ASSIGNS USERNAME TO EACH APPOINTMENT DICTIONARY
            foreach (var app in appointments.Values)
            {
                query = $"SELECT userName FROM user WHERE userId = '{app["userId"]}'";
                cmd = new MySqlCommand(query, c);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                app.Add("userName", rdr[0]);
                rdr.Close();
            }

            // ASSIGNS CUSTOMERNAME TO EACH APPOINTMENT DICTIONARY
            foreach (var app in appointments.Values)
            {
                query = $"SELECT customerName FROM customer WHERE customerId = '{app["customerId"]}'";
                cmd = new MySqlCommand(query, c);
                rdr = cmd.ExecuteReader();
                rdr.Read();
                app.Add("customerName", rdr[0]);
                rdr.Close();
            }

            Dictionary<int, Hashtable> parsedAppointments = new Dictionary<int, Hashtable>();
            // WEEK OR MONTH APPOINTMENT VIEW FUNCTIONALITY
            foreach (var app in appointments)
            {
                DateTime startTime = DateTime.Parse(app.Value["start"].ToString());
                DateTime endTime = DateTime.Parse(app.Value["end"].ToString());
                DateTime today = DateTime.UtcNow;

                if (weekView)
                {
                    DateTime sunday = today.AddDays(-(int)today.DayOfWeek);
                    DateTime saturday = today.AddDays(-(int)today.DayOfWeek + (int)DayOfWeek.Saturday);

                    if (startTime >= sunday && endTime < saturday)
                    {
                        parsedAppointments.Add(app.Key, app.Value);
                    }
                }
                else
                {
                    DateTime firstDayOfMonth = new DateTime(today.Year, today.Month, 1);
                    DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);
                    if (startTime >= firstDayOfMonth && endTime < lastDayOfMonth)
                    {
                        parsedAppointments.Add(app.Key, app.Value);
                    }
                }
            }

            Classes.DataTool.setAppointments(appointments);
            // FINAL DATASOURCE OF CALENDAR SHOWN TO USER
            var appointmentArray = from row in parsedAppointments
                                   select new
                                   {
                                       ID = row.Key,
                                       Type = row.Value["type"],
                                       StartTime = Classes.DataTool.convertToTimezone(row.Value["start"].ToString()),
                                       EndTime = Classes.DataTool.convertToTimezone(row.Value["end"].ToString()),
                                       Customer = row.Value["customerName"]
                                   };

            c.Close();

            return appointmentArray.ToArray();
        }

        public void updateCalendar()
        {
            dgvAppCal.DataSource = getCalendar(radioButtonWeek.Checked);
        }

        private void Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnAddCust_Click(object sender, EventArgs e)
        {
            AddCustomer createCustomer = new AddCustomer();
            createCustomer.Show();
        }

        private void btnUpdateCust_Click(object sender, EventArgs e)
        {
            UpdateCustomer updateCustomer = new UpdateCustomer();
            updateCustomer.Show();
        }

        private void btnDeleteCust_Click(object sender, EventArgs e)
        {
            DeleteCustomer deleteCustomer = new DeleteCustomer();
            deleteCustomer.Show();
        }

        private void btnAddApp_Click(object sender, EventArgs e)
        {
            AddAppointment addAppointment = new AddAppointment();
            addAppointment.mainFormObject = this;
            addAppointment.Show();
        }

        private void btnUpdateApp_Click(object sender, EventArgs e)
        {
            UpdateAppointment updateAppointment = new UpdateAppointment();
            updateAppointment.mainFormObject = this;
            updateAppointment.Show();
        }

        private void btnDeleteApp_Click(object sender, EventArgs e)
        {
            DeleteAppointment deleteAppointment = new DeleteAppointment();
            deleteAppointment.mainFormObject = this;
            deleteAppointment.Show();
        }

        private void btnAppReport_Click(object sender, EventArgs e)
        {
            NumberOfAppointmentsReport numberOfAppointments = new NumberOfAppointmentsReport();
            numberOfAppointments.Show();
        }

        private void btnSchedReport_Click(object sender, EventArgs e)
        {
            UserSchedules userSchedules = new UserSchedules();
            userSchedules.Show();
        }

        private void btnCustReport_Click(object sender, EventArgs e)
        {
            CustomerReport customerReport = new CustomerReport();
            customerReport.Show();
        }

        private void radioButtonWeek_CheckedChanged(object sender, EventArgs e)
        {
            updateCalendar();
        }
    }

}
