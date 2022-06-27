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
    public partial class FrmCompanyManageInternshipList : Form
    {
        public FrmCompanyManageInternshipList()
        {
            InitializeComponent();
        }


        //Method: Load dữ liệu danh sách sinh viên đã và đang thực tập tại công ty này
        private void FrmCompanyManageInternshipList_Load(object sender, EventArgs e)
        {
            List<dynamic> liststudent = new List<dynamic>();
            liststudent.Add("Thái Quốc Toàn 1");
            liststudent.Add("Thái Quốc Toàn 2");
            liststudent.Add("Thái Quốc Toàn 3");
            liststudent.Add("Thái Quốc Toàn 4");
            BindingSource source = new BindingSource();
            source.DataSource = liststudent;
            DgvStudentList.DataSource = source;
        }

        //Method: mở trang đánh giá đối với sinh viên với trạng thái isInterns là working
        private void DgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmCompanyEvaluateInterns frmCompanyEvaluateInterns = new FrmCompanyEvaluateInterns();
            frmCompanyEvaluateInterns.ShowDialog();
        }
    }
}
