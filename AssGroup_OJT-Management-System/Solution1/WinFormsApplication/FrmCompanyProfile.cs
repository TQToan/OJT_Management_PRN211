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
    public partial class FrmCompanyProfile : Form
    {
        public FrmCompanyProfile()
        {
            InitializeComponent();
        }

        //Method: Load dữ liệu của công ty đang đăng nhập vào hệ thống
        private void FrmCompanyProfile_Load(object sender, EventArgs e)
        {

        }

        //Method: open frm edit profile để thực hiện edit
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FrmCompanyEditProfile frmCompanyEditProfile = new FrmCompanyEditProfile();
            frmCompanyEditProfile.ShowDialog();
        }
    }
}
