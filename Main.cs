using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Globalization;

namespace C969___BOP1___BBruton___Scheduling_Project
{
    public partial class Main : Form
    {

        public string errorMessage = "The username and password did not match.";
        public Main()
        {
            MySqlConnection conLog = new MySqlConnection(Classes.DataTool.con);
            conLog.Close();
            InitializeComponent();
            SetDefaultValues();


            //French for the secondary language below
            if (CultureInfo.CurrentUICulture.LCID == 1036)
            {
                lblAppCity.Text = "APPointed";
                lblUsername.Text = "Nom d'utilisateur";
                lblPassword.Text = "Mot de passe";
                btnLogin.Text = "S'identifier";
                btnCancel.Text = "Annuler";
                errorMessage = "Le nom d'utilisateur et le mot de passe ne correspondent pas.";
            }
        }

        //USED TO RESET TEXT BOX VALUES IF WRONG INFO ENTERED
        private void SetDefaultValues()
        {
            
            txtBoxUsername.Text = "";
            txtBoxPassword.Text = "";
        }

        static public int FindUser(string userName, string password)
        {
            MySqlConnection conn = new MySqlConnection(Classes.DataTool.con);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand($"SELECT userId FROM user WHERE userName = '{userName}' AND password = '{password}'", conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            if (rdr.HasRows)
            {
                rdr.Read();
                Classes.DataTool.setCurrentUserID(Convert.ToInt32(rdr[0]));
                Classes.DataTool.setCurrentUserName(userName);
                rdr.Close(); conn.Close();
                return Classes.DataTool.getCurrentUserID();
            }
            return 0;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            // CHECK DB FOR USERNAME/PASSWORD COMBO IN 'user' TABLE
            try
            {
                if (FindUser(txtBoxUsername.Text, txtBoxPassword.Text) != 0)
                {
                    this.Hide();
                    Dashboard Dashboard = new Dashboard();
                    Dashboard.loginForm = this;
                    Classes.Logger.writeUserLoginLog(Classes.DataTool.getCurrentUserID());
                    Dashboard.Show();
                }
                else
                {
                    MessageBox.Show(errorMessage);
                    txtBoxPassword.Text = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        private void txtBoxUsername_MouseClick(object sender, MouseEventArgs e)
        {
            this.SetDefaultValues();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (txtBoxPassword.UseSystemPasswordChar == true)
            {
                txtBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                txtBoxPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
