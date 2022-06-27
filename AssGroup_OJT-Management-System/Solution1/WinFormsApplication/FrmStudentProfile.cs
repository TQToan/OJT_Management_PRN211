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
    public partial class FrmStudentProfile : Form
    {
        public FrmStudentProfile()
        {
            InitializeComponent();
        }

        //Method: load form student profile, và load dữ liệu về major và semester
        private void FrmStudentProfile_Load(object sender, EventArgs e)
        {
            //code load dữ liệu lên 
        }


        //Method: Khi nhấn nút Edit profile thì sẽ mở form edit profile để edit
        private void BtnEdit_Click(object sender, EventArgs e)
        {
            FrmStudentEditProfile frmStudentEditProfile = new FrmStudentEditProfile();
            frmStudentEditProfile.ShowDialog();
        }
    }
}
