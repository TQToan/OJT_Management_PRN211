using Library.Data_Access;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Library.Repository;

namespace Library.Repository
{
    public interface IRepositoryTblStudentSemester
    {

        IEnumerable<TblStudentSemester> GetStudentInOtherSemester(string studentCode);
        void InsertStuSemester(TblStudentSemester stuSemester);
        bool CheckStudentAndSemesterIsExist(TblStudentSemester stuSem);

    }
}
