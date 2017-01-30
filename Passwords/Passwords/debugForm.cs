using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passwords
{
    public partial class debugForm : Form
    {
        public debugForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Load the display from another form/class
        /// </summary>
        /// <param name="content"></param>
        public void loadView(string content)
        {
            this.displayBox.Text = content;
            this.displayBox.Refresh();
        }
    }
}
