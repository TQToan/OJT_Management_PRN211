using Library.Models;
using Library.Repository;
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

        // dùng tạm id để lấy studentInfor 
        //public string stuCode = "SE151262";

        private IRepositoryTblJob jobRepo = new RepositoryTblJob();
        private IRepositoryTblSemester semesterRepo = new RepositoryTblSemester();
        private IRepositoryTblRegisterJob registerJobRepo = new RepositoryTblRegisterJob();
        private IRepositoryTblStudent studentRepo = new RepositoryTblStudent();
        private IRepositoryTblCompany companyRepo = new RepositoryTblCompany(); 
        private IRepositoryTblMajor majorRepo = new RepositoryTblMajor();

        public TblAccount studentAccount { get; set; }
        public TblStudent studentInfor { get; set; }
        private TblJob jobInfor { get; set; }
        private TblSemester currentSemester { get; set; }

        public bool IsChange { get; set; } = false;
        public TblRegisterJob SelectJobFromChange { get; set; }
        
        //Method: chức năng search theo filter được chọn và text được nhập
        private void BtnSearchJobList_Click(object sender, EventArgs e)
        {
            SearchByFilter();
        }

        //Method: show ra frmStudentDetailJobCompany để thực hiện chức năng apply
        private void DgvCompaniesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            FrmStudentDetailJobCompany frmStudentDetailJobCompany = new FrmStudentDetailJobCompany()
            {
                StudentInfor = this.studentInfor,
                JobInfor = this.jobInfor
            };
            var listApplied = registerJobRepo.GetListStudentApplied(currentSemester, studentInfor.StudentCode);
            bool isCheck = false;

            if (listApplied != null)
            {
                foreach (var item in listApplied)
                {
                    if (item.JobCode == jobInfor.JobCode)
                    {
                        frmStudentDetailJobCompany.ApplyOrCancel = false;
                        frmStudentDetailJobCompany.ShowDialog();
                        isCheck = true;
                    }
                }

            }
           
            if (!isCheck)
            {
                if (IsChange)
                {
                    frmStudentDetailJobCompany.IsChange = true;
                    frmStudentDetailJobCompany.SelectJobFromChange = SelectJobFromChange;
                    if (jobInfor.JobCode == SelectJobFromChange.JobCode)
                    {
                        frmStudentDetailJobCompany.ApplyOrCancel = false;
                    }
                    else
                    {
                        frmStudentDetailJobCompany.ApplyOrCancel = true;
                    }
                    frmStudentDetailJobCompany.ShowDialog();
                    SelectJobFromChange = registerJobRepo.GetAppliedJobByIDAndStudentCode(jobInfor.JobCode, studentInfor.StudentCode);
                }
                else
                {
                    if (listApplied.Count() != 2)
                    {
                        frmStudentDetailJobCompany.ApplyOrCancel = true;
                        frmStudentDetailJobCompany.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Student have registerd 2 aspiration.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }

           
        }

        //Method: Chức năng load danh sách các job của các công ty chưa hết hạn
        //  và còn quantity tuyển dụng
        private void FrmStudentJobCompanyList_Load(object sender, EventArgs e)
        {
            TblStudent student = studentRepo.GetStudentProfileByUserName(studentAccount.Username);
            studentInfor = studentRepo.GetStudentByStudentID(student.StudentCode);
            currentSemester = semesterRepo.GetCurrentSemester();
            CbFilterJobCompanyList.Text = "Company name";
            IEnumerable<TblJob> jobList = jobRepo.GetJobActive();
            LoadJobList(jobList);
        }

        private void DgvCompaniesList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                int tmpID = int.Parse(DgvCompaniesList.Rows[e.RowIndex].Cells[0].Value.ToString());
                jobInfor = jobRepo.GetJobByID(tmpID);
            }
        }

        private void LoadJobList(IEnumerable<TblJob> list)
        {
            DgvCompaniesList.DataSource = null;
            DgvCompaniesList.Rows.Clear();

            if (list != null)
            {
                DgvCompaniesList.ColumnCount = 6;
                DgvCompaniesList.Columns[0].Name = "Job Code";
                DgvCompaniesList.Columns[1].Name = "Job Name";
                DgvCompaniesList.Columns[2].Name = "Quantity";
                DgvCompaniesList.Columns[3].Name = "Expiration Date";
                DgvCompaniesList.Columns[4].Name = "Company Name";
                DgvCompaniesList.Columns[5].Name = "Major Name";


                foreach (var item in list)
                {
                    DateTime tmpDate = (DateTime)item.ExpirationDate;
                    var tmpCompany = companyRepo.GetCompanyByTaxCode(item.TaxCode);
                    var tmpMajor = majorRepo.GetMajorByMajorCode(item.MajorCode);
                    string[] tmpJob = new string[]
                    {
                        item.JobCode.ToString(),
                        item.JobName.ToString(),
                        item.NumberInterns.ToString(),
                        tmpDate.ToString("dd/MM/yyyy"),
                        tmpCompany.CompanyName.ToString(),
                        tmpMajor.MajorName.ToString()
                    };
                    DgvCompaniesList.Rows.Add(tmpJob);
                }
            }
            DgvCompaniesList.AllowUserToAddRows = false;
        }


        private void SearchByFilter()
        {
            IEnumerable<TblJob> listInternFilter = null;
            if (string.IsNullOrEmpty(TxtSearchJobCompanyName.Text.Trim()))
            {
                listInternFilter = jobRepo.GetJobActive();
            }
            else
            {
                string tmpSearch = TxtSearchJobCompanyName.Text.Trim();
                switch (CbFilterJobCompanyList.Text)
                {
                    case "Company name":
                        listInternFilter = jobRepo.SearchJobByCompanyNameAsStudent(tmpSearch);
                        break;

                    case "Company Address":
                        listInternFilter = jobRepo.SearchJobByCompanyAddressAsStudent(tmpSearch);
                        break;
                    
                    case "Job name":
                        listInternFilter = jobRepo.SearchJobByJobNameAsStudent(tmpSearch);
                        break;
                }
            } 
            LoadJobList(listInternFilter);
        }
    }
    
}
