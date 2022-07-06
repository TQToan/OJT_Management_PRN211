using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data_Access;
using Library.Models;

namespace Library.Repository
{
    public class RepositoryTblRegisterJob : IRepositoryTblRegisterJob
    {
        public TblRegisterJob GetAppliedJobByIDAndStudentCode(int jobID, string studentcode) => TblRegisterJobDAO.GetAppliedJobByIDAndStudentCode(jobID, studentcode);
        public IEnumerable<dynamic> GetListStudentAppliedJobAsCompany() => TblRegisterJobDAO.GetListStudentAppliedJobAsCompany();

        public void UpdateStatusApplyJobAsCompany(TblRegisterJob job) =>
            TblRegisterJobDAO.UpdateStatusApplyJobAsCompany(job);

        public IEnumerable<dynamic> SearchAppliedJobByStatusAsCompany(int status) =>
            TblRegisterJobDAO.SearchAppliedJobByStatusAsCompany(status);

        public IEnumerable<dynamic> SearchAppliedJobByJobNameAsCompany(string searchValue) =>
            TblRegisterJobDAO.SearchAppliedJobByJobNameAsCompany(searchValue);
    }
}
