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
    public partial class FrmUniversityManageStudentList : Form
    {
        public FrmUniversityManageStudentList()
        {
            InitializeComponent();
        }

        //Method: Load dữ liệu sinh viên hiển thị sinh viên kì hiện tại
        private void FrmUniversityManageStudentList_Load(object sender, EventArgs e)
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

        
        //Method: chức năng add 1 sinh viên mới
        private void BtnAddNewStudent_Click(object sender, EventArgs e)
        {
            FrmUniversityAddNewStudent frmUniversityAddNewStudent = new FrmUniversityAddNewStudent();
            frmUniversityAddNewStudent.ShowDialog();
        }

        //Method: chức năng luôn luôn search student list theo kì được chọn
        private void CbSesmester_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        //Method: chức năng search student theo filter mà user chọn và nhập
        private void BtnSearchStudentList_Click(object sender, EventArgs e)
        {
            
        }

        //Method: open frm edit information cho student
        private void DgvStudentList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmUniversityEditStudentInformation frmUniversityEditStudentInformation = new FrmUniversityEditStudentInformation();
            frmUniversityEditStudentInformation.ShowDialog();
        }
    }
    public record StudentCheck
    {
        string name { get; set; }
    }
}
