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
    public partial class FrmStudentApplication : Form
    {
        public FrmStudentApplication()
        {
            InitializeComponent();
        }

        //Method: Load dữ liệu của 2 bài được applied bởi sinh viên này
        private void FrmStudentApplication_Load(object sender, EventArgs e)
        {
            //code load data ở đây
        }


        //Method: Hủy (xóa) applied vào job nguyện vọng 1 này của sinh viên
        private void BtnCancelAspiration1_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("Are you sure that you want to cancel this job?", "Student Application - Cancel a Job", 
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //code xóa applied ở đây
            }
            
        }


        //Method: Change job cho sinh viên khi muốn job khác làm Nguyện vọng 1
        private void BtnChangeAspiration1_Click(object sender, EventArgs e)
        {
            DialogResult result =  MessageBox.Show("Are you sure that you want to change this job by another job?", "Student Application - Change a Job",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                FrmStudentJobCompanyList frmStudentJobCompanyList = new FrmStudentJobCompanyList();
                frmStudentJobCompanyList.ShowDialog();
                //code change applied ở đây
            }

        }

        //Method: Hủy (xóa) applied vào job nguyện vọng 2 này của sinh viên
        private void BtnCancelAspiration2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to cancel this job?", "Student Application - Cancel a Job",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                //code xóa applied ở đây
            }
        }

        //Method: Change job cho sinh viên khi muốn job khác làm Nguyện vọng 2
        private void BtnChangeAspiration2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure that you want to change this job by another job?", "Student Application - Change a Job",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                FrmStudentJobCompanyList frmStudentJobCompanyList = new FrmStudentJobCompanyList();
                frmStudentJobCompanyList.ShowDialog();
                //code change applied ở đây
            }
        }
    }
}
