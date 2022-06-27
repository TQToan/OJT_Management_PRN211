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
    public partial class FrmCompanyManageInternsApplicaton : Form
    {
        public FrmCompanyManageInternsApplicaton()
        {
            InitializeComponent();
        }

        //Method: confirm application of student(intern)
        private void DgvApplicationList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to confirm for this student who applied your job?",
                "Interns Application - Confirm Application", 
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // thực hiện cập nhật companyConfirm là accepted
            } 
            else if (result == DialogResult.No)
            {
                // thực hiện cập nhật companyConfirm là dined
            }
            // cancel là thoát form này
        }

        //Method: thực hiện load dữ liệu của danh sách đăng kí list của student
        private void FrmCompanyManageInternsApplicaton_Load(object sender, EventArgs e)
        {
            List<dynamic> liststudent = new List<dynamic>();
            liststudent.Add("Thái Quốc Toàn 1");
            liststudent.Add("Thái Quốc Toàn 2");
            liststudent.Add("Thái Quốc Toàn 3");
            liststudent.Add("Thái Quốc Toàn 4");
            BindingSource source = new BindingSource();
            source.DataSource = liststudent;
            DgvApplicationList.DataSource = source;
        }

        //Method: Thực hiện search theo filter và giá trị được nhập
        private void BtnSearchApplication_Click(object sender, EventArgs e)
        {

        }
    }
}
