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
    public partial class FrmUniversityAddNewStudent : Form
    {
        public FrmUniversityAddNewStudent()
        {
            InitializeComponent();
        }


        //Method: khi nhấn vào button add new a student
        private void BtnInsertANewStudent_Click(object sender, EventArgs e)
        {

        }

        //Method: Load dữ liệu về major, về semester lên để show dữ liệu
        private void FrmUniversityAddNewStudent_Load(object sender, EventArgs e)
        {

        }


        //Method: đóng frm hiện tại
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
