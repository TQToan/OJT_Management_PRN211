﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using Library.Data_Access;
using Library.Models;
using Library.Repository;

namespace WinFormsApplication
{
    public partial class FrmCompanyManageInternsApplicaton : Form
    {
        private readonly IRepositoryTblRegisterJob repositoryTblRegisterJob = new RepositoryTblRegisterJob();
        //private readonly BindingSource source = new BindingSource();
        public FrmCompanyManageInternsApplicaton()
        {
            InitializeComponent();
        }

        //Method: confirm application of student(intern)
        private void DgvApplicationList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var appliedJob =
                repositoryTblRegisterJob.GetAppliedJobByIDAndStudentCode(Int32.Parse(txtJobCodeInvisible.Text),
                    txtStudentCodeInvisible.Text);
            DialogResult result = MessageBox.Show("Do you want to confirm for this student who applied your job?",
                "Interns Application - Confirm Application",
                MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // thực hiện cập nhật companyConfirm là accepted
                TblRegisterJob studentApplied = new TblRegisterJob
                {
                    StudentCode = appliedJob.StudentCode,
                    JobCode = appliedJob.JobCode,
                    Grade = appliedJob.Grade,
                    Comment = appliedJob.Comment,
                    StudentConfirm = appliedJob.StudentConfirm,
                    IsCompanyConfirm = 1,
                    IsPass = appliedJob.IsPass,
                    Aspiration = appliedJob.Aspiration,
                };
                repositoryTblRegisterJob.UpdateStatusApplyJobAsCompany(studentApplied);
            }
            else if (result == DialogResult.No)
            {
                // thực hiện cập nhật companyConfirm là dined
                TblRegisterJob studentApplied = new TblRegisterJob
                {
                    StudentCode = appliedJob.StudentCode,
                    JobCode = appliedJob.JobCode,
                    Grade = appliedJob.Grade,
                    Comment = appliedJob.Comment,
                    StudentConfirm = appliedJob.StudentConfirm,
                    IsCompanyConfirm = 2,
                    IsPass = appliedJob.IsPass,
                    Aspiration = appliedJob.Aspiration,
                };
                repositoryTblRegisterJob.UpdateStatusApplyJobAsCompany(studentApplied);

            }
            // cancel là thoát form này
            LoadAppiedJob();
        }
        public void LoadAppiedJob()
        {
            BindingSource source = new BindingSource();
            //string[] status = new string[3] { "Not yet", "Accept", "Denied" };
            //cbStatus.Items.Add(new KeyValuePair<string, int>("Not yet", 0));
            //cbStatus.Items.Add(new KeyValuePair<string, int>("Accept", 1));
            //cbStatus.Items.Add(new KeyValuePair<string, int>("Denied", 2));
            //cbStatus.

            try
            {

                source.DataSource = repositoryTblRegisterJob.GetListStudentAppliedJobAsCompany().ToList();
                txtJobCodeInvisible.DataBindings.Clear();
                txtStudentCodeInvisible.DataBindings.Clear();
                txtJobCodeInvisible.DataBindings.Add("Text", source, "JobCode");
                txtStudentCodeInvisible.DataBindings.Add("Text", source, "StudentCode");
                DgvApplicationList.DataSource = source;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Load data error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //Method: thực hiện load dữ liệu của danh sách đăng kí list của student
        private void FrmCompanyManageInternsApplicaton_Load(object sender, EventArgs e)
        {
            CbFilterApplicationList.Text = "Job name";
            LoadAppiedJob();

        }

        //Method: Thực hiện search theo filter và giá trị được nhập
        private void BtnSearchApplication_Click(object sender, EventArgs e)
        {
            BindingSource source = new BindingSource();

            string filterSearch = CbFilterApplicationList.Text;
            try
            {
                switch (filterSearch)
                {
                    case "Status":
                        if ("accept".Contains(TxtSearchApplication.Text))
                        {
                            source.DataSource = repositoryTblRegisterJob.SearchAppliedJobByStatusAsCompany(1).ToList();
                        }
                        else if ("denied".Contains(TxtSearchApplication.Text))
                        {
                            source.DataSource = repositoryTblRegisterJob.SearchAppliedJobByStatusAsCompany(2).ToList();
                        }
                        else if ("not yet".Contains(TxtSearchApplication.Text))
                        {
                            source.DataSource = repositoryTblRegisterJob.SearchAppliedJobByStatusAsCompany(0).ToList();
                        }
                        break;
                    default:
                        source.DataSource =
                            repositoryTblRegisterJob.SearchAppliedJobByJobNameAsCompany(TxtSearchApplication.Text).ToList();
                        break;
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Search error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (source.Count > 0)
            {
                txtJobCodeInvisible.DataBindings.Clear();
                txtStudentCodeInvisible.DataBindings.Clear();
                txtJobCodeInvisible.DataBindings.Add("Text", source, "JobCode");
                txtStudentCodeInvisible.DataBindings.Add("Text", source, "StudentCode");
                DgvApplicationList.DataSource = source;
            }
            else
            {
                MessageBox.Show("No record match!", "Search error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvApplicationList_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (DgvApplicationList.Columns[e.ColumnIndex].Name == "StudentConfirm")
            {
                if (e.Value != null && e.Value.ToString().Equals("True"))

                {
                    e.Value = new string("Accept");
                    e.CellStyle.ForeColor = Color.Green;
                }
                else
                {
                    e.Value = new string("Cancel");
                    e.CellStyle.ForeColor = Color.Red;
                }
            }

            if (DgvApplicationList.Columns[e.ColumnIndex].Name == "CompanyConfirm")
            {
                if (e.Value != null && e.Value.Equals(1))

                {
                    e.Value = new string("Accepted");
                    e.CellStyle.ForeColor = Color.Green;
                }
                else if (e.Value != null && e.Value.Equals(2))
                {
                    e.Value = new string("Denied");
                    e.CellStyle.ForeColor = Color.Red;
                }
                else
                {
                    e.Value = new string("Not Yet");
                }
            }
        }


        private void CbFilterApplicationList_TextChanged(object sender, EventArgs e)
        {
            TxtSearchApplication.Text = "";
        }
    }
}
