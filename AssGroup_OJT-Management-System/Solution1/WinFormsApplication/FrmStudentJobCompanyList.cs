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
    public partial class FrmStudentJobCompanyList : Form
    {
        public FrmStudentJobCompanyList()
        {
            InitializeComponent();
        }

        //Method: chức năng search theo filter được chọn và text được nhập
        private void BtnSearchJobList_Click(object sender, EventArgs e)
        {

        }

        //Method: show ra frmStudentDetailJobCompany để thực hiện chức năng apply
        private void DgvCompaniesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmStudentDetailJobCompany frmStudentDetailJobCompany = new FrmStudentDetailJobCompany();
            DialogResult result = frmStudentDetailJobCompany.ShowDialog();
        }

        //Method: Chức năng load danh sách các job của các công ty chưa hết hạn
        //  và còn quantity tuyển dụng
        private void FrmStudentJobCompanyList_Load(object sender, EventArgs e)
        {
            
            List<dynamic> liststudent = new List<dynamic>();
            liststudent.Add("Thái Quốc Toàn 1");
            liststudent.Add("Thái Quốc Toàn 2");
            liststudent.Add("Thái Quốc Toàn 3");
            liststudent.Add("Thái Quốc Toàn 4");
            BindingSource source = new BindingSource();
            source.DataSource = liststudent;
            DgvCompaniesList.DataSource = source;
        }
    }
    public record Student
    {
        string name { get; set; }
    }
}
