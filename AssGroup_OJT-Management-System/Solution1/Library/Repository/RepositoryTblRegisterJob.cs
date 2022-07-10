using Library.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repository
{
    public class RepositoryTblRegisterJob : IRepositoryTblRegisterJob
    {

        public bool checkCourStatusByStudentCode(string studentCode)
            => TblRegisterJobDAO.Instance.checkCourStatusByStudentCode(studentCode);

        public bool checkStudentIsPass(string studentCode)
            => TblRegisterJobDAO.Instance.checkStudentIsPass(studentCode);

        public TblRegisterJob GetAppliedJobByIDAndStudentCode(int jobID, string studentcode)
            => TblRegisterJobDAO.Instance.GetAppliedJobByIDAndStudentCode(jobID, studentcode);
        public IEnumerable<dynamic> GetListStudentAppliedJobAsCompany()
            => TblRegisterJobDAO.Instance.GetListStudentAppliedJobAsCompany();

        public void UpdateStatusApplyJobAsCompany(TblRegisterJob job) =>
            TblRegisterJobDAO.Instance.UpdateStatusApplyJobAsCompany(job);

        public IEnumerable<dynamic> SearchAppliedJobByStatusAsCompany(int status) =>
            TblRegisterJobDAO.Instance.SearchAppliedJobByStatusAsCompany(status);

        public IEnumerable<dynamic> SearchAppliedJobByJobNameAsCompany(string searchValue) =>
            TblRegisterJobDAO.Instance.SearchAppliedJobByJobNameAsCompany(searchValue);
        public int CountAppliedJobByStudentCode(string studentCode) => TblRegisterJobDAO.Instance.CountAppliedJobByStudentCode(studentCode);

        public int CountStudentActivedJobByStudentCode(string studentCode) =>
            TblRegisterJobDAO.Instance.CountStudentActivedJobByStudentCode(studentCode);
    }
}
