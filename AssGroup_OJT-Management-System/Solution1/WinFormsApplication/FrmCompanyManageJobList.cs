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
    public partial class FrmCompanyManageJobList : Form
    {
        public FrmCompanyManageJobList()
        {
            InitializeComponent();
        }

        //Method: Load dữ liệu của các bài job của công ty này
        private void FrmCompanyManageJobList_Load(object sender, EventArgs e)
        {
            List<dynamic> liststudent = new List<dynamic>();
            liststudent.Add("Thái Quốc Toàn 1");
            liststudent.Add("Thái Quốc Toàn 2");
            liststudent.Add("Thái Quốc Toàn 3");
            liststudent.Add("Thái Quốc Toàn 4");
            BindingSource source = new BindingSource();
            source.DataSource = liststudent;
            DgvCompanyJobList.DataSource = source;
        }

        //Method: Search job company theo fiter và giá trị tên được nhập vào
        private void BtnSearchJobList_Click(object sender, EventArgs e)
        {

        }

        //Method: Open form add new company 
        private void BtnAddNewCompany_Click(object sender, EventArgs e)
        {
            FrmCompanyAddNewJob frmCompanyAddNewJob = new FrmCompanyAddNewJob();
            frmCompanyAddNewJob.ShowDialog();
        }

        //Method: open form update job information
        private void DgvCompanyJobList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmCompanyUpdateJobInformation frmCompanyUpdateJobInformation = new FrmCompanyUpdateJobInformation();
            frmCompanyUpdateJobInformation.ShowDialog();
        }
    }
}
