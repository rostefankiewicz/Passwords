using System;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Passwords
{
    public partial class xmlForm : Form
    {
        //Global variables
        bool debugMode = false;
        string testXML = "";
        string XMLFilePath = Environment.GetFolderPath(Environment.SpecialFolder.MyDoc‌​uments) + "\\PWD\\";
        string XMLFile = "pwd.xml";
        List<clsAccount> allAccounts = new List<clsAccount>();

        /// <summary>
        /// What to do on startup
        /// </summary>
        public xmlForm()
        {
            InitializeComponent();
            //Don't display this just yet
            this.Hide();
            this.acctCB.DropDownStyle = ComboBoxStyle.DropDownList;

            //Get the file content
            readXMLDoc();
            //Parse the content
            parseAccountXML();
        }

        /// <summary>
        /// Read everything from the file if we can. If there is no file then we will return a default string
        /// </summary>
        private void readXMLDoc()
        {
            //do something
            string fileContent = "";
            try
            {
                //Try to read from the file.
                fileContent = System.IO.File.ReadAllText(XMLFilePath + XMLFile).Replace("&", " and ").Replace("  ", " ");
            }
            catch
            {
                //If the file does not exist, then it will end up throwing an error.
                //Catch it here and return a default string.
                fileContent = "";
            }
            //Set the variable with our file content
            testXML = fileContent;
        }

        /// <summary>
        /// Take the xml string that we have and parse it into the collections
        /// </summary>
        private void parseAccountXML()
        {
            //Declare the string builder
            StringBuilder OP = new StringBuilder();
            //Declare the xmlDocument variable
            XmlDocument xmlDoc = new XmlDocument();

            if (testXML.Trim() != "")
            {
                //Load the XML string into the xmlDoc variable
                xmlDoc.LoadXml(testXML);
                //Sort all of the main XML tags into a collection
                XmlNodeList acct = xmlDoc.GetElementsByTagName("account");


                //Loop through out colletion and use the values that we currenctly need
                for (int i = 0; i < acct.Count; i++)
                {
                    //Take the broken down XML tag and parse through that so we do not run into index errors
                    XmlDocument tempDoc = new XmlDocument();
                    tempDoc.LoadXml(acct[i].OuterXml);
                    string name = tempDoc.GetElementsByTagName("name")[0].InnerText; //Get the first name tag from this document
                    string user = Program.Base64Decode(tempDoc.GetElementsByTagName("user")[0].InnerText); //Get the first user name from this document
                    string pass = Program.Base64Decode(tempDoc.GetElementsByTagName("pass")[0].InnerText); //Get the first password from this doucment

                    if (debugMode)
                    {
                        //Add everything into the output stringbuilder
                        OP.Append("Account-" + i.ToString() + "---------------------------\r\n");
                        OP.Append("NAME: " + name + "\r\n");
                        OP.Append("USER: " + user + "\r\n");
                        OP.Append("PASS: " + pass + "\r\n\r\n");
                    }
                    else
                    {
                        //Declare a new instance of the clsAccount
                        clsAccount tempAcct = new clsAccount();
                        tempAcct.name = name; //Get the first name tag from this document
                        tempAcct.user = user; //Get the first user name from this document
                        tempAcct.pass = pass; //Get the first password from this doucment
                                              //Add the tempAccount to the global collection
                        allAccounts.Add(tempAcct);
                    }
                } //acct.count

                //Lets sort the collection alphabetically by account name
                sortList();
            }
           
            if (debugMode)
            {
                //Load the debug window and display it
                debugForm DF = new debugForm();
                DF.loadView(OP.ToString());
                DF.Refresh();
                DF.Show();
            }
            else
            {
                //Load this page and display it
                loadDisplay(true);
                this.Show();
            }
        }

        /// <summary>
        /// Sort the account collection by the account name
        /// </summary>
        private void sortList()
        {
            allAccounts.Sort((name1, name2) => name1.name.CompareTo(name2.name));
        }

        /// <summary>
        /// Using our global collection, load all of the controls that we need
        /// </summary>
        private void loadDisplay(bool clearAll = true)
        {
            //Clear the collection so we can reload
            this.acctCB.Items.Clear();
            //Load the combo box
            this.acctCB.Text = "Select a value";
            //Add the actual values now
            for (int i = 0; i < allAccounts.Count; i++)
            {
                this.acctCB.Items.Add(allAccounts[i].name);
            }
            if (clearAll)
            {
                //Clear the textbox values
                this.UserNameTB.Text = "";
                this.passwordTB.Text = "";
            }
        }

        /// <summary>
        /// Go through all of the accounts and save them to our XML file
        /// </summary>
        private void saveAll()
        {
            try
            {
                //Do all of the saving functionality here
                string fileContent = "<accounts>"; //Root element
                for (int i = 0; i < allAccounts.Count; i++)
                {
                    if(allAccounts[i].name == "") { continue; }
                    //Add all of the accounts to the file content
                    fileContent += allAccounts[i].toXML();
                }
                fileContent += "</accounts>"; //Root element

                if (!System.IO.Directory.Exists(XMLFilePath))
                {
                    System.IO.Directory.CreateDirectory(XMLFilePath);
                }
                System.IO.File.WriteAllText(XMLFilePath + XMLFile, fileContent);
            }
            catch (Exception x)
            {
                MessageBox.Show("Failed to save your account settings.\r\n\r\nError:\r\n" + x.ToString(), "Save", MessageBoxButtons.OK);
            }
        }

        /// <summary>
        /// This single function will allow us to open a new or existing account to be edited
        /// </summary>
        /// <param name="currAcct"></param>
        /// <returns></returns>
        private clsAccount openIndivAccount(clsAccount currAcct)
        {
            indivAccountInfo IAC = new indivAccountInfo();
            IAC.currAcct = currAcct;
            IAC.loadDisplay();
            IAC.Refresh();
            //ShowDialog should pause the application until that form is done
            IAC.ShowDialog();
            return currAcct;
        }

        #region CONTROL ACTION FUNCTION
        /// <summary>
        /// When the drop down is changed, get the account info and display it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void acctCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Using linq, get the first account that has the same name as requested
            clsAccount acct = allAccounts.FirstOrDefault(tempAcct => tempAcct.name == acctCB.SelectedItem.ToString());
            //Add the values to the output screen
            this.UserNameTB.Text = acct.user;
            this.passwordTB.Text = acct.pass;
        }

        /// <summary>
        /// Display the add account screen then update the drop down list
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addAcctButton_Click(object sender, EventArgs e)
        {
            clsAccount newAcct = new clsAccount();
            newAcct = openIndivAccount(newAcct);
            //We will assume that this is true for starters
            bool validAccount = true;
            //Check that all values are filled out
            if (newAcct.name.Trim() == "" || newAcct.user.Trim() == "" || newAcct.pass.Trim() == "" || allAccounts.Any(tempAcct => tempAcct.name == newAcct.name)) { validAccount = false; }

            if (validAccount)
            {
                //Add the account to the collection
                allAccounts.Add(newAcct);
                //Sort the list now that we added something to it
                sortList();
                //Save the selected item so we can add that back after we refresh the list
                var selectedItem = this.acctCB.SelectedItem;
                //Load the display
                loadDisplay(false);
                //Put the "SelectedItem" back in
                this.acctCB.SelectedItem = selectedItem;
                //Refresh so the display is actually updated
                this.acctCB.Refresh();
            }
            else
            {
                if (newAcct.name != "X")
                {
                    MessageBox.Show("The account that you are trying to enter is either blank or already exists.", "Warning", MessageBoxButtons.OK);
                }
            }
        }

        /// <summary>
        /// Edit the selected account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void editAcctButton_Click(object sender, EventArgs e)
        {
            if (acctCB.SelectedItem == null)
            {
                MessageBox.Show("No account selected", "Remove", MessageBoxButtons.OK);
            }
            else
            {
                //Using linq, get the first account that has the same name as requested
                clsAccount acct = allAccounts.FirstOrDefault(tempAcct => tempAcct.name == acctCB.SelectedItem.ToString());
                //Keep track of the old values that we have
                clsAccount BKPacct = new clsAccount();
                BKPacct.name = acct.name;
                BKPacct.user = acct.user;
                BKPacct.pass = acct.pass;
                //Open the form for the new values
                acct = openIndivAccount(acct);

                //We will assume that this is true for starters
                bool validAccount = true;
                //Check that all values are filled out
                if (acct.name.Trim() == "" || acct.user.Trim() == "" || acct.pass.Trim() == "") { validAccount = false; }

                if (validAccount)
                {
                    //get the item that was seleteced
                    var selectedItem = this.acctCB.SelectedItem;
                    //Load the display
                    loadDisplay(true);
                    //Put the "SelectedItem" back in
                    this.acctCB.SelectedItem = selectedItem;
                    //Refresh so the display is actually updated
                    this.acctCB.Refresh();

                    this.UserNameTB.Text = acct.user;
                    this.passwordTB.Text = acct.pass;
                    this.UserNameTB.Refresh();
                    this.passwordTB.Refresh();
                }else
                {
                    if (acct.name != "X")
                    {
                        MessageBox.Show("The account that you are trying to enter is either blank or already exists.", "Warning", MessageBoxButtons.OK);
                    }
                    //Act like nothing happened
                    acct.name = BKPacct.name;
                    acct.user = BKPacct.user;
                    acct.pass = BKPacct.pass;
                }
            }
        }

        /// <summary>
        /// Remove the selected account
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void removeAcctButton_Click(object sender, EventArgs e)
        {
            if (acctCB.SelectedItem == null)
            {
                MessageBox.Show("No account selected", "Remove", MessageBoxButtons.OK);
            }
            else
            {
                if (MessageBox.Show("Are you sure you would like to remove the selected account?", "Remove", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    //Remove the given selected account using linq
                    allAccounts.Remove(allAccounts.SingleOrDefault(tempAcct => tempAcct.name == acctCB.SelectedItem.ToString()));
                    //No need to sort since we are not adding anything
                    loadDisplay(true);
                }
            }
        }

        /// <summary>
        /// The user opted to save. So call the save function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton_Click(object sender, EventArgs e)
        {
            saveAll();
        }
        #endregion
    }
}
