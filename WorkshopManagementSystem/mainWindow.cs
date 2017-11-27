using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkshopManagementSystem
{
    public partial class mainWindow : Form
    {
        Form opener;
        
        public mainWindow(Form parentForm)
        {
            InitializeComponent();
            opener = parentForm;
        }
        /*
        private void button1_Click(object sender, EventArgs e)
        {
            opener.Close();
            this.Close();
        }
        */
        private void mainWindow_Load(object sender, EventArgs e)
        {

        }
        
    }
}
