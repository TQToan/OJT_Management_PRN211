using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Models;
using Library.Repository;

namespace WinFormsApplication
{
    public partial class FrmStudentHome : Form
    {
        public IRepositoryTblStudent repositoryTblStudent { get; set; }
        public IRepositoryTblSemester RepositoryTblSemester { get; set; }
        public IRepositoryTblStudentSemester RepositoryTblStudentSemester { get; set; }
        public IRepositoryTblRegisterJob RepositoryTblRegisterJob { get; set; }
        public TblAccount studentAccount { get; set; }
        public FrmStudentHome()
        {
            InitializeComponent();
        }

        //Method: load data cho trang home
        private void FrmStudentHome_Load(object sender, EventArgs e)
        {
            //Load số lượng công ty đã được kí kết

            // load số lượng bài post của các công ty còn hạn đăng
            // và còn số lượng về đúng chuyên ngành của sinh viên

            //load dữ liệu về thông tin của sinh viên để hiện thị lênB
            BindingSource source = new BindingSource();

            repositoryTblStudent = new RepositoryTblStudent();
            TblStudent student = repositoryTblStudent.GetStudentProfileByUserName(studentAccount.Username);
            textEmail.Text = student.Username;
            TxtStudentName.Text = student.StudentName;
            TxtStudentID.Text = student.StudentCode;
            txtMajor.Text = student.Majorname;
            TxtCredit.Text = student.Credit.ToString();


            RepositoryTblSemester = new RepositoryTblSemester();
            TblSemester semester = RepositoryTblSemester.GetCurrentSemester();
            TxtSemester.Text = semester.SemesterName;

            RepositoryTblRegisterJob = new RepositoryTblRegisterJob();
            int numberOfSignedCompany = RepositoryTblRegisterJob.CountAppliedJobByStudentCode(student.StudentCode);
            TxtNumberOfSignedCompaniesHeader.Text = numberOfSignedCompany.ToString();

            int numberOfStudentActivedJob =
                RepositoryTblRegisterJob.CountStudentActivedJobByStudentCode(student.StudentCode);
            LbNumberOfActiveJobsHeader.Text = numberOfStudentActivedJob.ToString();

        }
    }
}
