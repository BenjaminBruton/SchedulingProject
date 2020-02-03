using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___BOP1___BBruton___Scheduling_Project
{

    public struct Customer
    {
        public string customerName;
        public int numberOfApps;
    }
    public partial class CustomerReport : Form
    {
        public CustomerReport()
        {
            InitializeComponent();
            dgvCustomerReport.DataSource = getReport();
        }


        public static DataTable getReport()
        {
            // Display each customer's name and how many appointments they have

            Dictionary<int, Hashtable> appointments = Classes.DataTool.getAppointments();

            DataTable dt = new DataTable();
            dt.Clear();
            dt.Columns.Add("Customer");
            dt.Columns.Add("Appointments");


            // :BELOW: LAMBDA USED TO SELECT EACH CUSTOMER FROM THE APPOINTMENTS COLLECTION
            IEnumerable<string> customers = appointments.Select(i => i.Value["customerName"].ToString()).Distinct(); 

            foreach (string customer in customers)
            {
                DataRow row = dt.NewRow();
                row["Customer"] = customer;
                // :BELOW: LAMBDA USED TO COUNT THE NUMBER OF APPOINTMENTS EACH CUSTOMER HAS FROM APPOINTMNET COLLECTION
                row["Appointments"] = appointments.Where(i => i.Value["customerName"].ToString() == customer.ToString()).Count().ToString();
                dt.Rows.Add(row);
            }

            return dt;
        }
    }


}
