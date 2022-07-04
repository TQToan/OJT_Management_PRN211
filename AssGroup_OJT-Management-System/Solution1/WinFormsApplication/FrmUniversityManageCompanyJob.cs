using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library.Repository;
using Library.Models;
using Library.Data_Access;


namespace WinFormsApplication
{
    public partial class FrmUniversityManageCompanyJob : Form
    {
        IRepositoryTblJob repositoryTblJob = new RepositoryTblJob();
        public FrmUniversityManageCompanyJob()
        {
            InitializeComponent();
        }

        //Method: open frm confirm job để thực hiện confirm denied or accepted job này của company
        private void DgvCompaniesList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Lay Job by ID Job
            TblJob tblJob = repositoryTblJob.GetJobByID(int.Parse(txtIDJob.Text));
            if (tblJob.NumberInterns <= 0 || tblJob.ExpirationDate < DateTime.Now)
            {
                MessageBox.Show("Can't not confirm this job", "Company Job - Confirm Company's Job");
            }
            else
            {
                DialogResult result = MessageBox.Show("Do you want to accept this company's job?", "Company Job - Confirm Company's Job",
                                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    //thực hiện thay đổi trạng thái của job này sang trạng thái accept
                    tblJob = new TblJob
                    {
                        JobCode = int.Parse(txtIDJob.Text),
                        JobName = tblJob.JobName,
                        NumberInterns = tblJob.NumberInterns,
                        ExpirationDate = tblJob.ExpirationDate,
                        Status = true,
                        TaxCode = tblJob.TaxCode,
                        MajorCode = tblJob.MajorCode,
                        AdminConfirm = 1,
                    };
                    repositoryTblJob.UpdateStatusJobAsAdmin(tblJob);
                }

                else if (result == DialogResult.No)
                {
                    //thực hiện thay đổi trạng thái của job này sang trạng thái dined
                    tblJob = new TblJob
                    {
                        JobCode = int.Parse(txtIDJob.Text),
                        JobName = tblJob.JobName,
                        NumberInterns = tblJob.NumberInterns,
                        ExpirationDate = tblJob.ExpirationDate,
                        Status = false,
                        TaxCode = tblJob.TaxCode,
                        MajorCode = tblJob.MajorCode,
                        AdminConfirm = 2,
                    };
                    repositoryTblJob.UpdateStatusJobAsAdmin(tblJob);
                }
                LoadCompanyJob();
                // nếu là cancel thì không thay đổi gì cả
            }

        }

        //Method: thực hiện load các job lên



        //Lay danh sach cac bai post
        public void LoadCompanyJob()
        {
            try
            {

                using (var db = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    BindingSource source = new BindingSource();
                    source.DataSource = (from job in db.TblJobs
                                         orderby job.AdminConfirm ascending
                                         select new
                                         {
                                             JobCode = job.JobCode,
                                             JobName = job.JobName,
                                             CompanyName = job.TaxCodeNavigation.CompanyName,
                                             MajorName = job.MajorCodeNavigation.MajorName,
                                             NumberOfInTerns = job.NumberInterns,
                                             ExpirationDate = job.ExpirationDate,
                                             Address = job.TaxCodeNavigation.Address,
                                             ActionStatus = job.Status,
                                             AdminConfirm = job.AdminConfirm
                                         }).ToList();
                    txtIDJob.DataBindings.Clear();
                    txtIDJob.DataBindings.Add("Text", source, "JobCode");
                    //DgvCompaniesList.Columns[0].Visible = false;
                    DgvCompaniesList.DataSource = source;
                }
            }
            catch (Exception ex)
            {

            }
        }

        //Load cac bai Post
        private void FrmUniversityManageCompanyJob_Load(object sender, EventArgs e)
        {
            LoadCompanyJob();

        }

        private void BtnSearchJobList_Click(object sender, EventArgs e)
        {

            try
            {
                BindingSource source = new BindingSource();
                source.DataSource = null;
                using (var db = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    string searchValue = CbFilterJobCompanyList.Text;
                    switch (searchValue)
                    {
                        case "Company name":
                            source.DataSource = db.TblJobs.Where(job => job.TaxCodeNavigation.CompanyName.ToUpper().Contains(TxtSearchJobCompanyName.Text.ToUpper()))
                            .Select(job => new
                            {
                                JobCode = job.JobCode,
                                JobName = job.JobName,
                                CompanyName = job.TaxCodeNavigation.CompanyName,
                                MajorName = job.MajorCodeNavigation.MajorName,
                                NumberOfInTerns = job.NumberInterns,
                                ExpirationDate = job.ExpirationDate,
                                Address = job.TaxCodeNavigation.Address,
                                ActionStatus = job.Status,
                                AdminConfirm = job.AdminConfirm

                            }).OrderBy(job => job.AdminConfirm).ToList();
                            break;

                        case "Company Address":
                            source.DataSource = db.TblJobs.Where(job => job.TaxCodeNavigation.Address.ToUpper().Contains(TxtSearchJobCompanyName.Text.ToUpper()))
                            .Select(job => new
                            {
                                JobCode = job.JobCode,
                                JobName = job.JobName,
                                CompanyName = job.TaxCodeNavigation.CompanyName,
                                MajorName = job.MajorCodeNavigation.MajorName,
                                NumberOfInTerns = job.NumberInterns,
                                ExpirationDate = job.ExpirationDate,
                                Address = job.TaxCodeNavigation.Address,
                                ActionStatus = job.Status,
                                AdminConfirm = job.AdminConfirm

                            }).OrderBy(job => job.AdminConfirm).ToList();
                            break;

                        case "Job name":
                            source.DataSource = db.TblJobs.Where(job => job.JobName.ToUpper().Contains(TxtSearchJobCompanyName.Text.ToUpper())).
                            Select(job => new
                            {
                                JobCode = job.JobCode,
                                JobName = job.JobName,
                                CompanyName = job.TaxCodeNavigation.CompanyName,
                                MajorName = job.MajorCodeNavigation.MajorName,
                                NumberOfInTerns = job.NumberInterns,
                                ExpirationDate = job.ExpirationDate,
                                Address = job.TaxCodeNavigation.Address,
                                ActionStatus = job.Status,
                                AdminConfirm = job.AdminConfirm

                            }).OrderBy(job => job.AdminConfirm).ToList();
                            break;
                    }

                    txtIDJob.DataBindings.Clear();
                    txtIDJob.DataBindings.Add("Text", source, "JobCode");
                    DgvCompaniesList.DataSource = source;

                }
            }
            catch (Exception ex)
            {

            }

        }

        private void CbFilterJobCompanyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtSearchJobCompanyName.Text = "";
        }

        private void DgvCompaniesList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.DgvCompaniesList.Columns[e.ColumnIndex].Name == "ActionStatus")
            {
                if (e.Value != null && e.Value.ToString().Equals("True"))

                {
                    e.Value = new String("Active");
                    e.CellStyle.ForeColor = Color.Green;
                }
                else
                {
                    e.Value = new String("Unactive");
                    e.CellStyle.ForeColor = Color.Red;
                }
            }
            if (this.DgvCompaniesList.Columns[e.ColumnIndex].Name == "AdminConfirm")
            {
                if (e.Value != null && e.Value.Equals(1))

                {
                    e.Value = new String("Accepted");
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (e.Value != null && e.Value.Equals(2))
                {
                    e.Value = new String("Denied");
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                    e.Value = new String("Not Yet");
            }
            if (this.DgvCompaniesList.Columns[e.ColumnIndex].Name == "ExpirationDate")
            {
                ShortFormDateFormat(e);
            }
        }

        //FormatDate
        private static void ShortFormDateFormat(DataGridViewCellFormattingEventArgs formatting)
        {
            if (formatting.Value != null)
            {
                try
                {
                    System.Text.StringBuilder dateString = new System.Text.StringBuilder();
                    DateTime theDate = DateTime.Parse(formatting.Value.ToString());

                    dateString.Append(theDate.Day);
                    dateString.Append("/");
                    dateString.Append(theDate.Month);
                    dateString.Append("/");
                    dateString.Append(theDate.Year);
                    formatting.Value = dateString.ToString();
                    formatting.FormattingApplied = true;
                }
                catch (FormatException)
                {
                    // Set to false in case there are other handlers interested trying to
                    // format this DataGridViewCellFormattingEventArgs instance.
                    formatting.FormattingApplied = false;
                }
            }
        }


    }
}
