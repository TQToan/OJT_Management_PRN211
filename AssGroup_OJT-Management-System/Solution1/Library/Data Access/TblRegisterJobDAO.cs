using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblRegisterJobDAO
    {
        // private OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
        //Using singleton
        private TblRegisterJobDAO() { }
        private static TblRegisterJobDAO instance = null;
        private static readonly object InstanceLock = new object();
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


        // hàm kiểm tra Cour status, lấy job mới nhất kiểm tra là pass, hay not pass(bao gồm not pass, not yet)
        public bool checkCourStatusByStudentCode(string studentCode)
        {
            using (var db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var list = from appl in db.TblRegisterJobs
                           join job in db.TblJobs on appl.JobCode equals job.JobCode
                           where appl.StudentCode == studentCode
                           orderby job.ExpirationDate descending
                           select appl;
                var result = list.FirstOrDefault();
                if (result != null && result.IsPass == false)
                {
                    return true;
                }
            }
            return false;
        }


        // hàm kiểm tra student đã pass chưa trong tất các kỳ, chỉ cần 1 pass return true 
        public bool checkStudentIsPass(string studentCode)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var list = from appl in db.TblRegisterJobs
                           where appl.StudentCode == studentCode && appl.IsPass == false
                           select appl;
                if (list.Count() != 0)
                {
                    return true;
                }
                return false;
            }
        }


        public TblRegisterJob GetAppliedJobByIDAndStudentCode(int idJob, string studentCode)                      //Lay post theo ID
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context dbContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                TblRegisterJob job = dbContext.TblRegisterJobs.FirstOrDefault(j => j.JobCode == idJob && j.StudentCode == studentCode);
                return job;
            }

        }
        public int CountAppliedJobByStudentCode(string studentCode)                      //Lay post theo ID
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context dbContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var job = dbContext.TblRegisterJobs.Where(j => j.StudentCode == studentCode);
                int count = job.Count();
                return count;
            }

        }

        public int CountStudentActivedJobByStudentCode(string studentCode)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context dbContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var job = dbContext.TblRegisterJobs.Where(j => j.StudentCode == studentCode && j.IsCompanyConfirm == 1 && j.StudentConfirm == true);
                int count = job.Count();
                return count;
            }
        }
        public IEnumerable<dynamic> GetListStudentAppliedJobAsCompany()
        {
            OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context();

            var listStudent = from apply in dBContext.TblRegisterJobs
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
        public void UpdateStatusApplyJobAsCompany(TblRegisterJob job)           //Update isCompany Confirm job
        {
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dBcontext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    var entity = dBcontext.TblRegisterJobs.FirstOrDefault(j => j.JobCode == job.JobCode && j.StudentCode == job.StudentCode);
                    entity.IsCompanyConfirm = job.IsCompanyConfirm;
                    dBcontext.SaveChanges();      // cap nhat CSDL
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public IEnumerable<dynamic> SearchAppliedJobByJobNameAsCompany(string searchValue)
        {
            var dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var listResult = dBContext.TblRegisterJobs.Where(apply => apply.JobCodeNavigation.JobName.ToUpper().Contains(searchValue.ToUpper()))
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
        public IEnumerable<dynamic> SearchAppliedJobByStatusAsCompany(int status)
        {
            var dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var listResult = dBContext.TblRegisterJobs.Where(apply => apply.IsCompanyConfirm == status)
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


        public IEnumerable<TblRegisterJob> GetIntershipInCurrentSemester(int semesterID, string taxCode)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var list = from register in db.TblRegisterJobs
                           join student in db.TblStudents on register.StudentCode equals student.StudentCode
                           join stuSem in db.TblStudentSemesters on student.StudentCode equals stuSem.StudentCode
                           join jobs in db.TblJobs on register.JobCode equals jobs.JobCode
                           where jobs.TaxCode == taxCode && stuSem.SemesterId == semesterID
                           && register.IsCompanyConfirm == 1 && register.StudentConfirm == true
                           select register;
                return list.ToList();
            }
        }
        public IEnumerable<TblRegisterJob> GetIntershipInCurrentSemesterByStudentCode(int semesterID, string taxCode, string studentCode)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var list = from register in db.TblRegisterJobs
                           join student in db.TblStudents on register.StudentCode equals student.StudentCode
                           join stuSem in db.TblStudentSemesters on student.StudentCode equals stuSem.StudentCode
                           join jobs in db.TblJobs on register.JobCode equals jobs.JobCode
                           where stuSem.StudentCode == taxCode && stuSem.SemesterId == semesterID && stuSem.StudentCode.Contains(studentCode)
                          && register.IsCompanyConfirm == 1 && register.StudentConfirm == true
                           select register;
                return list.ToList();
            }
        }
        public IEnumerable<TblRegisterJob> GetIntershipInCurrentSemesterByStudentName(int semesterID, string taxCode, string studentName)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var list = from register in db.TblRegisterJobs
                           join student in db.TblStudents on register.StudentCode equals student.StudentCode
                           join stuSem in db.TblStudentSemesters on student.StudentCode equals stuSem.StudentCode
                           join jobs in db.TblJobs on register.JobCode equals jobs.JobCode
                           where stuSem.StudentCode == taxCode && stuSem.SemesterId == semesterID && student.StudentName.Contains(studentName)
                           && register.IsCompanyConfirm == 1 && register.StudentConfirm == true
                           select register;
                return list.ToList();
            }
        }
        public IEnumerable<TblRegisterJob> GetIntershipInCurrentSemesterByStatus(int semesterID, string taxCode, int statusStudent)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var list = from register in db.TblRegisterJobs
                           join student in db.TblStudents on register.StudentCode equals student.StudentCode
                           join stuSem in db.TblStudentSemesters on student.StudentCode equals stuSem.StudentCode
                           join jobs in db.TblJobs on register.JobCode equals jobs.JobCode
                           where stuSem.StudentCode == taxCode && stuSem.SemesterId == semesterID && student.IsIntern == statusStudent
                           && register.IsCompanyConfirm == 1 && register.StudentConfirm == true
                           select register;
                return list.ToList();
            }
        }

        public void UpdateInternEvaluation(TblRegisterJob evaluation)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                db.Entry<TblRegisterJob>(evaluation).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }
        }


        // hàm lấy list các bài post sinh viên đã apply trong kỳ 
        public IEnumerable<TblRegisterJob> GetListStudentApplied(TblSemester currentSemester, string studentcode)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                var list = from register in db.TblRegisterJobs
                           join student in db.TblStudents on register.StudentCode equals student.StudentCode
                           join job in db.TblJobs on register.JobCode equals job.JobCode
                           where student.StudentCode == studentcode &&
                           job.ExpirationDate <= currentSemester.EndDate &&
                           job.ExpirationDate >= currentSemester.StartDate &&
                           register.StudentConfirm == true
                           orderby register.Aspiration
                           select register;
                return list.ToList();
            }
        }


        public void InsertRegister(TblRegisterJob registerJob)
        {
            using (OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context())
            {
                db.TblRegisterJobs.Add(registerJob);
                db.SaveChanges();
            }
        }

    }
}
