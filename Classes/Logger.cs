using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969___BOP1___BBruton___Scheduling_Project.Classes
{
    class Logger
    {
        public static void writeUserLoginLog(int userId)
        {
            //CHANGE PATH BELOW FOR LOCAL FUNCTIONALITY
            string path = String.Format(@"{0}\log.txt", Environment.CurrentDirectory);
            //string path = "C:\\Users\\benth\\OneDrive\\School Work\\Software II - C#\\C969 - BOP1 - BBruton - Scheduling Project\\log.txt";
            string log = $"User with ID of {userId} logged in at {DataTool.createTimestamp()}" + Environment.NewLine;

            File.AppendAllText(path, log);
        }
    }
}
