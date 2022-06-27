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
    public partial class FrmUniversityEditStudentInformation : Form
    {
        public FrmUniversityEditStudentInformation()
        {
            InitializeComponent();
        }

        //Method: Load dữ liệu lên cho frm edit Student information
        private void FrmUniversityEditStudentInformation_Load(object sender, EventArgs e)
        {

        }


        //Method: Thực hiện update thông tin cho student
        private void BtnUpdate_Click(object sender, EventArgs e)
        {

        }

        //Method: close frm hiện tại
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
