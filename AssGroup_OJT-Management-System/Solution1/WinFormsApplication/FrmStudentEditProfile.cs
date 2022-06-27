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
    public partial class FrmStudentEditProfile : Form
    {
        public FrmStudentEditProfile()
        {
            InitializeComponent();
        }

        //Method: Khi nhấn nút cancel thì tắt form edit profile
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Method: khi nhấn nút Update thì thực hiện chức năng Update
        private void BtnUpdate_Click(object sender, EventArgs e)
        {
            //Chức năng update code ở đây
        }
    }
}
