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

        public bool checkCourStatusByStudentCode(string studentCode);

        public bool checkStudentIsPass(string studentCode);

        public TblRegisterJob GetAppliedJobByIDAndStudentCode(int jobID, string studentCode);
        public IEnumerable<dynamic> GetListStudentAppliedJobAsCompany();
        public void UpdateStatusApplyJobAsCompany(TblRegisterJob job);
        public IEnumerable<dynamic> SearchAppliedJobByStatusAsCompany(int status);
        public IEnumerable<dynamic> SearchAppliedJobByJobNameAsCompany(string searchValue);
        public int CountAppliedJobByStudentCode(string studentCode);
        public int CountStudentActivedJobByStudentCode(string studentCode);

    }
}
