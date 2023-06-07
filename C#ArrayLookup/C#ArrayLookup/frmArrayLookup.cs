using System;
using System.Windows.Forms;

/*
 *  Write a GUI application that looks up employee 
 *  information by ID, first name, last name, or department:
 *
 *  The program must store this information in four parallel 
 *  arrays and use appropriate loops. Here is the data:
 *
ID:		      First Name	     Last Name			 Department
----------------------------------------------------------------------------------------------
1347		Scott 			    Gray			    Information Technology
2698		Greg 			    Green		        Web Programming
1444		Brian 		        Black			    Networking
1987		Mary 			    Brown		        Web Programming
3421		Joe 			    Barnes		        Networking
7860		Gail 			    White			    Information Technology
5590		Karen 		        Clark			    Database Programming
6329		Mike			    King			    Networking
8701		Barb			    Jones		        Web Programming
5513		Cory			    Kent			    Database Programming


The GUI app should include the following 4 arrays:

int[] ids;
string[] firstNames;
string[] lastNames;
string[] departments;
 */

namespace C_ArrayLookup
{
    public partial class frmArrayLookup : Form
    {
        public frmArrayLookup()
        {
            InitializeComponent();
        }

        //  Declare and initialize program constants
        const int MINEMPLOYEEID = 1000;
        const int MAXEMPLOYEEID = 9999;

        //  Declare and initialize global arrays
        int[] ids =
        {
            1347, 2698, 1444, 1987, 3421,
            7860, 5590, 6329, 8701, 5513
        };

        string[] firstNames =
        {
            "Scott", "Greg", "Brian", "Mary", "Joe",
            "Gail", "Karen", "Mike",  "Barb", "Cory"
        };

        string[] lastNames =
        {
            "Gray",  "Green", "Black", "Brown", "Barnes",
            "White", "Clark", "King",  "Jones", "Kent"
        };

        string[] departments =
        {
            "Information Technology", "Web Programming",
            "Networking",             "Web Programming",
            "Networking",             "Information Technology",
            "Database Programming",   "Networking",
            "Web Programming",        "Database Programming"
        };

        private void btnSearchByID_Click(object sender, EventArgs e)
        {
            SearchForInputtedID();
        }

        private void SearchForInputtedID()
        {
            string term = txtSearchTerm.Text;

            //  Validate the presence of text in txtSearchTerm
            string errMsg = IsPresent(term, "employeeID", txtSearchTerm);

            //  No text in txtSearchTerm so show error
            DisplayTheErrorMessage(errMsg);

            //  Validate that the text in txtSearchTerm is an integer
            errMsg = IsInt32(term, "employeeID", txtSearchTerm);

            //  No integer value in txtSearchTerm so show error
            DisplayTheErrorMessage(errMsg);

            //  Validate that the int in txtSearchTerm is in range
            errMsg = IsWithinRange(term, "employeeID",
                                   MINEMPLOYEEID, MAXEMPLOYEEID,
                                   txtSearchTerm);

            //  No integer value in txtSearchTerm so show error
            DisplayTheErrorMessage(errMsg);

            //  txtSearchTerm.Text holds a valid int value (1000 - 9999)
            for (int lcv = 0; lcv < ids.Length; lcv++)
            {
                //  If the current id is in the ids array
                if (ids[lcv].ToString().Contains(term))
                {
                    //  Show the data for that employee
                    ShowTheData(lcv);
                    return;
                }
            }

            //  There was no match, i.e., no employee with that ID
            //  Show ERROR in each of the 4 textboxes
            ShowNoData();
        }

        private void btnSearchFirstName_Click(object sender, EventArgs e)
        {
            SearchForInputtedFirstName();
        }

        private void SearchForInputtedFirstName()
        {
            string term = txtSearchTerm.Text;

            //  Validate the presence of text in txtSearchTerm
            string errMsg = IsPresent(term, "firstName", txtSearchTerm);

            //  No text in txtSearchTerm so show error
            DisplayTheErrorMessage(errMsg);

            //  txtSearchTerm.Text holds a valid first name
            for (int lcv = 0; lcv < firstNames.Length; lcv++)
            {
                //  If the current id is in the ids array
                if (firstNames[lcv].ToString().ToUpper().Contains(term.ToString().ToUpper()))
                {
                    //  Show the data for that employee
                    ShowTheData(lcv);
                    return;
                }
            }

            //  There was no match, i.e., no employee with that first name
            //  Show ERROR in each of the 4 textboxes
            ShowNoData();
        }

        private void btnSearchLastName_Click(object sender, EventArgs e)
        {
            SearchForInputtedLastName();
        }

        private void SearchForInputtedLastName()
        {
            string term = txtSearchTerm.Text;

            //  Validate the presence of text in txtSearchTerm
            string errMsg = IsPresent(term, "lastName", txtSearchTerm);

            //  No text in txtSearchTerm so show error
            DisplayTheErrorMessage(errMsg);

            //  txtSearchTerm.Text holds a valid last name
            for (int lcv = 0; lcv < lastNames.Length; lcv++)
            {
                //  If the current id is in the ids array
                if (lastNames[lcv].ToString().ToUpper().Contains(term.ToString().ToUpper()))
                {
                    //  Show the data for that employee
                    ShowTheData(lcv);
                    return;
                }
            }

            //  There was no match, i.e., no employee with that last name
            //  Show ERROR in each of the 4 textboxes
            ShowNoData();
        }

        private void btnSearchepartment_Click(object sender, EventArgs e)
        {
            SearchForInputtedDepartment();
        }

        private void SearchForInputtedDepartment()
        {
            string term = txtSearchTerm.Text;

            //  Validate the presence of text in txtSearchTerm
            string errMsg = IsPresent(term, "department", txtSearchTerm);

            //  No text in txtSearchTerm so show error
            DisplayTheErrorMessage(errMsg);

            //  txtSearchTerm.Text holds a valid department
            for (int lcv = 0; lcv < lastNames.Length; lcv++)
            {
                //  If the current id is in the ids array
                if (departments[lcv].ToString().ToUpper().Contains(term.ToString().ToUpper()))
                {
                    //  Show the data for that employee
                    ShowTheData(lcv);
                    return;
                }
            }

            //  There was no match, i.e., no employee with that department
            //  Show ERROR in each of the 4 textboxes
            ShowNoData();
        }

        private void DisplayTheErrorMessage(string errMsg)
        {
            //  No text in txtSearchTerm so show error
            if (errMsg != "")
            {
                ShowMessage(errMsg, "ERROR");
            }
        }

        //  Validate the presence or absence of control textbox text
        private string IsPresent(string value, string name, Control ctrl)
        {
            string msg = "";

            if (value == "")
            {
                msg = name + " is a required field.\n";
                ClearAndSetFocusToCorrectControl(ctrl);
            }

            return msg;
        }

        //  Validate the control textbox text is an integer
        private string IsInt32(string value, string name, Control ctrl)
        {
            string msg = "";

            if (!Int32.TryParse(value, out _))
            {
                msg = name + " must be a valid integer value.\n";
                ClearAndSetFocusToCorrectControl(ctrl);
            }

            return msg;
        }

        //  Validate the control textbox text is between a min and max
        private string IsWithinRange(string value, string name, 
                                     int min, int max, Control ctrl)
        {
            string msg = "";
            int    id;

            if (Int32.TryParse(value, out id))
            {
                if ((id < min) || (id > max))
                {
                    msg = name + " must be between " + min + 
                          " and " + max + "\n";
                    ClearAndSetFocusToCorrectControl(ctrl);
                }
            }

            return msg;
        }

        private void ClearAndSetFocusToCorrectControl(Control ctrl)
        {
            ctrl.Text = "";
            ctrl.Focus();
        }

        private void ShowTheData(int lcv)
        {
            txtEmployeeID.Text  = ids[lcv].ToString();
            txtFirstName.Text   = firstNames[lcv];
            txtLastName.Text    = lastNames[lcv];
            txtDepartment.Text  = departments[lcv];
        }

        private void ShowNoData()
        {
            txtEmployeeID.Text  = "ERROR";
            txtFirstName.Text   = "ERROR";
            txtLastName.Text    = "ERROR";
            txtDepartment.Text  = "ERROR";
            txtSearchTerm.Text  = "";
            txtSearchTerm.Focus();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearAll();
        }

        private void ClearAll() 
        {
            txtSearchTerm.Text = "";
            txtEmployeeID.Text = "";
            txtFirstName.Text  = "";
            txtLastName.Text   = "";
            txtDepartment.Text = "";
            txtSearchTerm.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ExitProgramOrNot();
        }

        private void ExitProgramOrNot()
        {
            DialogResult dialog = MessageBox.Show(
            "Do You Really Want To Exit The Program?",
            "EXIT NOW?",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        //  Custom Error Message MessageBoxes
        private void ShowMessage(string msg, string title)
        {
            MessageBox.Show(msg, title,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
        }
    }
}
