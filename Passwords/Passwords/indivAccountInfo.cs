using System;
using System.Windows.Forms;
using System.Xml;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Passwords
{
    public partial class indivAccountInfo : Form
    {
        //This is the account that we will be working with
        public clsAccount currAcct;

        /// <summary>
        /// What to do when the form starts
        /// </summary>
        public indivAccountInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Use the given clsAccount to update the display
        /// </summary>
        public void loadDisplay()
        {
            this.acctNameTB.Text = currAcct.name;
            this.UserNameTB.Text = currAcct.user;
            this.passwordTB.Text = currAcct.pass;
        }

        /// <summary>
        /// Save the new settings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Click(object sender, EventArgs e)
        {
            currAcct.name = this.acctNameTB.Text;
            currAcct.user = this.UserNameTB.Text;
            currAcct.pass = this.passwordTB.Text;

            this.Dispose();
        }

        /// <summary>
        /// Undo all changes. If new, do not add to the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            currAcct.name = "X";
            currAcct.user = "";
            currAcct.pass = "";
            this.Dispose();
        }
    }
}
