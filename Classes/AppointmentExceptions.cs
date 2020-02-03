using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969___BOP1___BBruton___Scheduling_Project.Classes
{
    class AppointmentExceptions : ApplicationException
    {
        public void businessHours()
        {
            MessageBox.Show("Exception occured: Selected time not within normal business hours");
        }

        public void appOverlap()
        {
            MessageBox.Show("Exception occured: Selected appointment time is already reserved.");
        }
    }
}
