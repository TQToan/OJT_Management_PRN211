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
    public partial class FrmStudentDetailJobCompany : Form
    {
        public FrmStudentDetailJobCompany()
        {
            InitializeComponent();
        }

        private IRepositoryTblJob jobRepo = new RepositoryTblJob();
        private IRepositoryTblSemester semesterRepo = new RepositoryTblSemester();
        private IRepositoryTblRegisterJob registerJobRepo = new RepositoryTblRegisterJob();
        private IRepositoryTblCompany companyRepo = new RepositoryTblCompany();
        private IRepositoryTblMajor majorRepo = new RepositoryTblMajor();

        public TblStudent StudentInfor { get; set; }

        public TblJob JobInfor { get; set; }

        public bool ApplyOrCancel { get; set; }

        public bool IsChange { get; set; } = false;

        public TblRegisterJob SelectJobFromChange { get; set; }

        private TblSemester currentSemester { get; set; }
        //Method: khi bấm nút Exit thì thoát form detail job company
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Method: Chức năng apply vào job của company
        private void BtnApply_Click(object sender, EventArgs e)
        { 
            if (BtnApply.Text.Equals("Apply"))
            {
                DialogResult result = MessageBox.Show("Are you sure that you apply this job ?", "Student Application - Apply a Job",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    var registerJob = registerJobRepo.GetAppliedJobByIDAndStudentCode(JobInfor.JobCode, StudentInfor.StudentCode);
                    var listApplied = registerJobRepo.GetListStudentApplied(currentSemester, StudentInfor.StudentCode);
                    int tmpAspiration = 1;
                    if (listApplied.Count() == 1)
                    {
                        var firstRegisterJob = listApplied.First();
                        if (firstRegisterJob.Aspiration == 1)
                        {
                            tmpAspiration = 2;
                        }
                        else
                        {
                            tmpAspiration = 1;
                        }
                    }

                    if (IsChange)
                    {
                        tmpAspiration = (int)SelectJobFromChange.Aspiration;
                        SelectJobFromChange.Aspiration = 0;
                        SelectJobFromChange.StudentConfirm = false;
                        registerJobRepo.UpdateInternEvaluation(SelectJobFromChange);
                    }

                    if (registerJob != null)
                    {
                        registerJob.StudentConfirm = true;
                        registerJob.Aspiration = tmpAspiration;
                        registerJobRepo.UpdateInternEvaluation(registerJob);
                    }
                    else
                    {
                        var tmpregister = new TblRegisterJob()
                        {
                            JobCode = JobInfor.JobCode,
                            StudentCode = StudentInfor.StudentCode,
                            StudentConfirm = true,
                            Aspiration = tmpAspiration
                        };
                        registerJobRepo.InsertRegister(tmpregister);
                    }
                    //Code chức năng apply ở đây
                    BtnApply.Text = "Cancel";
                    TxtAppliedStatus.Text = "Applied";
                }
            } else if (BtnApply.Text.Equals("Cancel"))
            {
                DialogResult result = MessageBox.Show("Are you sure that you cancel this job ?", "Student Application - Cancel a Job",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    //code chức năng cancel apply ở đây
                    var registerJob = registerJobRepo.GetAppliedJobByIDAndStudentCode(JobInfor.JobCode, StudentInfor.StudentCode);
                    if (registerJob != null)
                    {
                        registerJob.StudentConfirm = false;
                        registerJob.Aspiration = 0;
                        registerJobRepo.UpdateInternEvaluation(registerJob);


                        //cập nhật lại nguyện vọng cho job còn lại 
                        var listAppliedCancel = registerJobRepo.GetListStudentApplied(currentSemester, StudentInfor.StudentCode);
                        if (listAppliedCancel != null)
                        {
                            var tmpListAppliedCancel = listAppliedCancel.First();
                            tmpListAppliedCancel.Aspiration = 1;
                            registerJobRepo.UpdateInternEvaluation(tmpListAppliedCancel);
                        }
                    }
                    BtnApply.Text = "Apply";
                    TxtAppliedStatus.Text = "Not Yet";
                }
            }
                
        }

        //Method: Load dữ liệu của major của job lên lên và chọn 
        private void FrmStudentDetailJobCompany_Load(object sender, EventArgs e)
        {
            currentSemester = semesterRepo.GetCurrentSemester();
            TxtJobName.Enabled = false;
            TxtNumberOfInterns.Enabled = false;
            TxtAddressCompany.Enabled = false;
            CbMajorJob.Enabled = false;
            TxtJobDescriptio.Enabled = false;
            MTextExpirationDate.Enabled = false;
            TxtAppliedStatus.Enabled = false;
            loadJobInfor();
            if (ApplyOrCancel)
            {
                BtnApply.Text = "Apply";
                TxtAppliedStatus.Text = "Not Yet";
            }
            else
            {
                BtnApply.Text = "Cancel";
                TxtAppliedStatus.Text = "Applied";
            }
        }

        private void loadJobInfor()
        {
            var tmpCompany = companyRepo.GetCompanyByTaxCode(JobInfor.TaxCode);
            var tmpMajor = majorRepo.GetMajorByMajorCode(JobInfor.MajorCode);
            TxtJobName.Text = JobInfor.JobName.ToString();  
            TxtAddressCompany.Text = tmpCompany.Address.ToString();
            TxtNumberOfInterns.Text = JobInfor.NumberInterns.ToString();
            CbMajorJob.Text = tmpMajor.MajorName.ToString();
            MTextExpirationDate.Text = JobInfor.ExpirationDate.ToString();   
        }
    }
}
