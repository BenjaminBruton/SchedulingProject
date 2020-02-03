using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;

namespace C969___BOP1___BBruton___Scheduling_Project.Classes
{

    // TODO: Clean up Dashboard DGV, columns are too big/long.

    public class DataTool
    {
        private static Dictionary<int, Hashtable> _appointments = new Dictionary<int, Hashtable>();
        private static int _currentUserId;
        private static string _currentUserName;
        public static string con = "server=3.227.166.251;userid=U063xo;database=U063xo;password=53688680039;port=3306;SslMode=None";


        public static int getCurrentUserID()
        {
            return _currentUserId;
        }

        public static void setCurrentUserID(int currentUserID)
        {
            _currentUserId = currentUserID;
        }

        public static string getCurrentUserName()
        {
            return _currentUserName;
        }

        public static void setCurrentUserName(string currentUserName)
        {
            _currentUserName = currentUserName;
        }

        public static Dictionary<int, Hashtable> getAppointments()
        {
            return _appointments;
        }

        public static void setAppointments(Dictionary<int, Hashtable> appointments)
        {
            _appointments = appointments;
        }

        public static int newID(List<int> idList)
        {
            int highestID = 0;
            foreach (int id in idList)
            {
                if (id > highestID)
                    highestID = id;
            }
            return highestID + 1;
        }

        public static string createTimestamp()
        {
            return DateTime.Now.ToString("u");
        }

        public static int createID(string table)
        {
            MySqlConnection c = new MySqlConnection(con);
            c.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT {table + "Id"} FROM {table}", c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            List<int> idList = new List<int>();
            while (rdr.Read())
            {
                idList.Add(Convert.ToInt32(rdr[0]));
            }
            rdr.Close();
            c.Close();
            return newID(idList);
        }

        static public int createRecord(string timestamp, string userName, string table, string partOfQuery, int userId = 0)
        {
            int recId = createID(table);
            string recInsert;
                if (userId == 0)
                {
                    recInsert = $"INSERT INTO {table}" +
                    $" VALUES ('{recId}', {partOfQuery}, '{timestamp}', '{userName}', '{timestamp}', '{userName}')";
                }
                else
                {
                    recInsert = $"INSERT INTO {table} (appointmentId, customerId, start, end, type, userId, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                    $" VALUES ('{recId}', {partOfQuery}, '{userId}', '{timestamp}', '{userName}', '{timestamp}', '{userName}')";
                }

                MySqlConnection c = new MySqlConnection(con);
                c.Open();
                MySqlCommand cmd = new MySqlCommand(recInsert, c);
                cmd.ExecuteNonQuery();
                c.Close();

                return recId;
            
        }

        static public int findCustomer(string search)
        {
            int customerId;
            string query;
            if (int.TryParse(search, out customerId))
            {
                query = $"SELECT customerId FROM customer WHERE customerId = '{search.ToString()}'";
            }
            else
            {
                query = $"SELECT customerId FROM customer WHERE customerName LIKE '{search}'";
            }
            MySqlConnection c = new MySqlConnection(DataTool.con);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                customerId = Convert.ToInt32(rdr[0]);
                rdr.Close(); c.Close();
                return customerId;
            }
            return 0;
        }

        static public Dictionary<string, string> getCustomerDetails(int customerId)
        {

            // Details of CUSTOMER Table
            Dictionary<string, string> customerDict = new Dictionary<string, string>();

            string query = $"SELECT * FROM customer WHERE customerId = '{customerId.ToString()}'";
            MySqlConnection c = new MySqlConnection(DataTool.con);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                customerDict.Add("customerName", rdr[1].ToString());
                customerDict.Add("addressId", rdr[2].ToString());
                customerDict.Add("active", rdr[3].ToString());
            }
            rdr.Close();

            // Details of ADDRESS Table
            query = $"SELECT * FROM address WHERE addressId = '{customerDict["addressId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                customerDict.Add("address", rdr[1].ToString());
                customerDict.Add("cityId", rdr[3].ToString());
                customerDict.Add("zip", rdr[4].ToString());
                customerDict.Add("phone", rdr[5].ToString());
            }
            rdr.Close();

            // Details of CITY Table
            query = $"SELECT * FROM city WHERE cityId = '{customerDict["cityId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                customerDict.Add("city", rdr[1].ToString());
                customerDict.Add("countryId", rdr[2].ToString());
            }
            rdr.Close();

            // Details of COUNTRY Table
            query = $"SELECT * FROM country WHERE countryId = '{customerDict["countryId"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                customerDict.Add("country", rdr[1].ToString());
            }                
            rdr.Close();
            
            //ADDING FOR TESTING APPOINTMENT DELETION IN CUSTOMER DELETE FORM
            query = $"SELECT customerId FROM customer" +
                $" WHERE customerName = '{customerDict["customerName"]}'";
            cmd = new MySqlCommand(query, c);
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                customerDict.Add("customerId", rdr[0].ToString());
            }           
            rdr.Close();
            
            c.Close();

            return customerDict;
        }

        static public Dictionary<string, string> getAppointmentDetails(string appointmentId)
        {
            string query = $"SELECT * FROM appointment WHERE appointmentId = '{appointmentId}'";
            MySqlConnection c = new MySqlConnection(DataTool.con);
            c.Open();
            MySqlCommand cmd = new MySqlCommand(query, c);
            MySqlDataReader rdr = cmd.ExecuteReader();
            rdr.Read();

            Dictionary<string, string> appointmentDict = new Dictionary<string, string>();
            // Customer Table Details
            appointmentDict.Add("appointmentId", appointmentId);
            appointmentDict.Add("customerId", rdr[1].ToString());
            appointmentDict.Add("type", rdr[7].ToString());
            appointmentDict.Add("start", rdr[9].ToString());
            appointmentDict.Add("end", rdr[10].ToString());
            rdr.Close();

            return appointmentDict;
        }

        static public string convertToTimezone(string dateTime)
        {
            
            DateTime utcDateTime = DateTime.Parse(dateTime.ToString());
            DateTime localDateTime = utcDateTime.ToLocalTime();

            return localDateTime.ToString("MM/dd/yyyy hh:mm tt");
        }

    }
}

