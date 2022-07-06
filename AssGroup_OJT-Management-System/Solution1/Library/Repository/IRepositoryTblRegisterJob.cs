using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repository
{
    public interface IRepositoryTblRegisterJob
    {
        TblRegisterJob GetAppliedJobByIDAndStudentCode(int jobID, string studentCode);
        IEnumerable<dynamic> GetListStudentAppliedJobAsCompany();
        void UpdateStatusApplyJobAsCompany(TblRegisterJob job);
        IEnumerable<dynamic> SearchAppliedJobByStatusAsCompany(int status);
        IEnumerable<dynamic> SearchAppliedJobByJobNameAsCompany(string searchValue);
    }
}
