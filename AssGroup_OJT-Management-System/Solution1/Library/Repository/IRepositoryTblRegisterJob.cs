using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IRepositoryTblRegisterJob
    {
        bool checkCourStatusByStudentCode(string studentCode);

        bool checkStudentIsPass(string studentCode);
    }
}
