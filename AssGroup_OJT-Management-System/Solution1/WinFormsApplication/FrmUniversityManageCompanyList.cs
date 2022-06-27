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
    public partial class FrmUniversityManageCompanyList : Form
    {
        public FrmUniversityManageCompanyList()
        {
            InitializeComponent();
        }

        //Method: search company theo filter và giá trị của filter
        private void BtnSearchStudentList_Click(object sender, EventArgs e)
        {

        }

        //Method: insert a new company
        private void BtnAddNewCompany_Click(object sender, EventArgs e)
        {
            FrmUniversityAddNewCompany frmUniversityAddNewCompany = new FrmUniversityAddNewCompany();
            frmUniversityAddNewCompany.ShowDialog();
        }

        //Method: load dữ liệu của company vào datagridview
        private void FrmUniversityManageCompanyList_Load(object sender, EventArgs e)
        {
            List<dynamic> liststudent = new List<dynamic>();
            liststudent.Add("Thái Quốc Toàn 1");
            liststudent.Add("Thái Quốc Toàn 2");
            liststudent.Add("Thái Quốc Toàn 3");
            liststudent.Add("Thái Quốc Toàn 4");
            BindingSource source = new BindingSource();
            source.DataSource = liststudent;
            DgvCompanyList.DataSource = source;
        }
    }
}
