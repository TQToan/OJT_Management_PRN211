﻿using Library.Models;
using Library.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace Library.Data_Access
{
    public class TblJobDAO
    {
        //Using singleton
        private TblJobDAO() { }
        private static TblJobDAO instance = null;
        private static readonly object InstanceLock = new object();

        public static TblJobDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblJobDAO();
                    }
                    return instance;
                }
            }
        }

        public int GetNumberOfAvailableJob()
        {
            List<TblJob> listJob = new List<TblJob>();
            try
            {
                DateTime today = DateTime.Today;
                using (OJT_MANAGEMENT_PRN211_Vs1Context dbContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    foreach (var item in dbContext.TblJobs.ToList())
                    {
                        int status = DateTime.Compare(item.ExpirationDate.Value, today);
                        if (status > 0 && item.NumberInterns > 0)
                        {
                            listJob.Add(item);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listJob.Count;
        }

        public List<TblJob> GetListCompanyJobPost(TblCompany company)
        {
            List<TblJob> listJobs = null;
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    //get all jobs of a specific company
                    listJobs = dBContext.TblJobs.Where(job => job.TaxCode.Equals(company.TaxCode)).ToList();
                    if (listJobs.Count == 0)
                    {
                        listJobs = null;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listJobs;
        }
        public TblJob GetJobByID(int idJob)                      //Lay post theo ID
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                TblJob job = dBContext.TblJobs.FirstOrDefault(j => j.JobCode == idJob);
                return job;
            }
        }


        public IEnumerable<dynamic> GetJobList123()              //Lay DS bai POST
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var listFullJob = (from job in dBContext.TblJobs
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
                                   });
                return listFullJob;
            }
        }

        public void UpdateStatusJobAsAdmin(TblJob job)           //Update Status vs Admin Confirm POST
        {
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    dBContext.Entry<TblJob>(job).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dBContext.SaveChanges();      // cap nhat CSDL
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public int GetNumberOfInterns(TblCompany company, int companyConfirm, int studentIntern)
        {
            List<string> listStudent = new List<string>();
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    //get all jobs of a specific company
                    List<TblJob> listJobs = GetListCompanyJobPost(company);
                    List<TblStudent> students = dBContext.TblStudents.ToList();
                    if (listJobs != null)
                    {
                        //get list student who is the intern of this company
                        List<TblRegisterJob> listRegisterJob = dBContext.TblRegisterJobs.ToList();
                        if (listRegisterJob.Count > 0)
                        {
                            foreach (var job in listJobs)
                            {
                                foreach (var intern in listRegisterJob)
                                {
                                    if (job.JobCode == intern.JobCode && intern.IsCompanyConfirm == companyConfirm && intern.StudentConfirm == true)
                                    {
                                        foreach (var student in students)
                                        {
                                            if (student.StudentCode.Equals(intern.StudentCode) && student.IsIntern == studentIntern)
                                            {
                                                listStudent.Add(intern.StudentCode);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listStudent.Count;
        }
        public IEnumerable<dynamic> SearchJobByCompanyNameAsAdmin(string searchValue)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var listResult = dBContext.TblJobs.Where(job => job.TaxCodeNavigation.CompanyName.ToUpper().Contains(searchValue.ToUpper()))
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

                    }).OrderBy(job => job.AdminConfirm);
                return listResult;
            }
        }
        public IEnumerable<dynamic> SearchJobByJobNameAsAdmin(string searchValue)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var listResult = dBContext.TblJobs.Where(job => job.JobName.ToUpper().Contains(searchValue.ToUpper()))
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

                }).OrderBy(job => job.AdminConfirm);
                return listResult;
            }
        }
        public IEnumerable<dynamic> SearchJobByCompanyAddressAsAdmin(string searchValue)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var listResult = dBContext.TblJobs.Where(job => job.TaxCodeNavigation.Address.ToUpper().Contains(searchValue.ToUpper()))
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

                 }).OrderBy(job => job.AdminConfirm);
                return listResult;
            }
        }


        public IEnumerable<TblJob> GetJobActive()
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context()) {
                var list = from job in db.TblJobs join company in db.TblCompanies on job.TaxCode equals company.TaxCode
                           join major in db.TblMajors on job.MajorCode equals major.MajorCode
                           where job.Status == false && job.ExpirationDate >= DateTime.Now
                           select job;
                return list.ToList();
            }
        }

        public IEnumerable<TblJob> SearchJobByCompanyNameAsStudent(string searchValue)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var list = from job in db.TblJobs
                           join company in db.TblCompanies on job.TaxCode equals company.TaxCode
                           join major in db.TblMajors on job.MajorCode equals major.MajorCode
                           where job.Status == false && company.CompanyName.Contains(searchValue)
                           select job;
                return list.ToList();
            }
        }

        public IEnumerable<TblJob> SearchJobByJobNameAsStudent(string searchValue)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var list = from job in db.TblJobs
                           join company in db.TblCompanies on job.TaxCode equals company.TaxCode
                           join major in db.TblMajors on job.MajorCode equals major.MajorCode
                           where job.Status == false && job.JobName.Contains(searchValue)
                           select job;
                return list.ToList();
            }
        } 
 
        public IEnumerable<TblJob> SearchJobByCompanyAddressAsStudent(string searchValue)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                    var list = from job in db.TblJobs
                               join company in db.TblCompanies on job.TaxCode equals company.TaxCode
                               join major in db.TblMajors on job.MajorCode equals major.MajorCode
                               where job.Status == false && company.Address.Contains(searchValue)
                               select job;
                    return list.ToList();
                }
        }



    }
}

