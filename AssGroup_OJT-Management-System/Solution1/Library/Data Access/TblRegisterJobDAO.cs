using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Data_Access
{
    public class TblRegisterJobDAO
    {
        //Using singleton
        private TblRegisterJobDAO() { }
        private static TblRegisterJobDAO instance = null;
        private static readonly object InstanceLock = new object();
        private static OJT_MANAGEMENT_PRN211_Vs1Context contex = new OJT_MANAGEMENT_PRN211_Vs1Context();
        public static TblRegisterJobDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblRegisterJobDAO();
                    }
                    return instance;
                }
            }
        }
        public static TblRegisterJob GetAppliedJobByIDAndStudentCode(int idJob, string studentCode)                      //Lay post theo ID
        {
            TblRegisterJob job = contex.TblRegisterJobs.FirstOrDefault(j => j.JobCode == idJob && j.StudentCode == studentCode);
            return job;
        }
        public static IEnumerable<dynamic> GetListStudentAppliedJobAsCompany()
        {
            var listStudent = from apply in contex.TblRegisterJobs
                              orderby apply.IsCompanyConfirm
                              select new
                              {
                                  StudentCode = apply.StudentCode,
                                  StudentName = apply.StudentCodeNavigation.StudentName,
                                  JobName = apply.JobCodeNavigation.JobName,
                                  StudentConfirm = apply.StudentConfirm,
                                  CompanyConfirm = apply.IsCompanyConfirm,
                                  Aspiration = apply.Aspiration,
                                  JobCode = apply.JobCode,
                              };
            return listStudent;
        }
        public static void UpdateStatusApplyJobAsCompany(TblRegisterJob job)           //Update isCompany Confirm job
        {
            try
            {

                var entity = contex.TblRegisterJobs.FirstOrDefault(j => j.JobCode == job.JobCode && j.StudentCode == job.StudentCode);
                entity.IsCompanyConfirm = job.IsCompanyConfirm;
                contex.SaveChanges();      // cap nhat CSDL

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static IEnumerable<dynamic> SearchAppliedJobByJobNameAsCompany(string searchValue)
        {
            var listResult = contex.TblRegisterJobs.Where(apply => apply.JobCodeNavigation.JobName.ToUpper().Contains(searchValue.ToUpper()))
                .Select(apply => new
                {
                    StudentCode = apply.StudentCode,
                    StudentName = apply.StudentCodeNavigation.StudentName,
                    JobName = apply.JobCodeNavigation.JobName,
                    StudentConfirm = apply.StudentConfirm,
                    CompanyConfirm = apply.IsCompanyConfirm,
                    Aspiration = apply.Aspiration,
                    JobCode = apply.JobCode,

                }).OrderBy(apply => apply.CompanyConfirm);
            return listResult;
        }
        public static IEnumerable<dynamic> SearchAppliedJobByStatusAsCompany(int status)
        {
            var listResult = contex.TblRegisterJobs.Where(apply => apply.IsCompanyConfirm == status)
                .Select(apply => new
                {
                    StudentCode = apply.StudentCode,
                    StudentName = apply.StudentCodeNavigation.StudentName,
                    JobName = apply.JobCodeNavigation.JobName,
                    StudentConfirm = apply.StudentConfirm,
                    CompanyConfirm = apply.IsCompanyConfirm,
                    Aspiration = apply.Aspiration,
                    JobCode = apply.JobCode,

                }).OrderBy(apply => apply.CompanyConfirm);
            return listResult;
        }
    }
}
