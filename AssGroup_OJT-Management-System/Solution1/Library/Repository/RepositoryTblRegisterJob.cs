using Library.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class RepositoryTblRegisterJob : IRepositoryTblRegisterJob
    {
        public bool checkCourStatusByStudentCode(string studentCode) => TblRegisterJobDAO.Instance.checkCourStatusByStudentCode(studentCode);

        public bool checkStudentIsPass(string studentCode) =>TblRegisterJobDAO.Instance.checkStudentIsPass(studentCode);
    }
}
