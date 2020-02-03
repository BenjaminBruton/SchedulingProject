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
    public struct UserReport
    {
        public int userId;
        public string userName;
        public string type;
        public string startTime;
        public string endTime;
        public string customerName;
    }
    public partial class UserSchedules : Form
    {
        public UserSchedules()
        {
            InitializeComponent();
            userReport.DataSource = getReport();
        }

        public static Array getReport()
        {
            Dictionary<int, Hashtable> userReport = Classes.DataTool.getAppointments();

            var appointmentArray = from row in userReport
                                   select new
                                   {
                                       UserName = row.Value["userName"],
                                       Type = row.Value["type"],
                                       StartTime = Classes.DataTool.convertToTimezone(row.Value["start"].ToString()),
                                       EndTime = Classes.DataTool.convertToTimezone(row.Value["end"].ToString()),
                                       Customer = row.Value["customerName"]
                                   };

            return appointmentArray.ToArray();
        }
    }
}
