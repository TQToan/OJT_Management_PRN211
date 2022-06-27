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
    public partial class FrmUniversityAddNewCompany : Form
    {
        public FrmUniversityAddNewCompany()
        {
            InitializeComponent();
        }

        //Method: thực hiện insert new company
        private void BtnInsertANewCompany_Click(object sender, EventArgs e)
        {

        }

        //Method: Thoát màn hình hiện tại
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
