using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApplication
{
    public partial class FrmUniversityAddNewMajor : Form
    {
        public FrmUniversityAddNewMajor()
        {
            InitializeComponent();
        }

        //Method: Add a new major
        private void BtnAddNewMajor_Click(object sender, EventArgs e)
        {
            
        }

        //Method: close this frm
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            DialogResult isExit = MessageBox.Show("Are your sure that you want to exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (isExit == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
