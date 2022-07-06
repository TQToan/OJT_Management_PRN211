using Library.Data_Access;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class RepositoryTblStudentSemester : IRepositoryTblStudentSemester
    {
        public int GetNumberOfStudentOfCurrentSemester(TblSemester currentSemester) 
            => TblSttudentSemesterDAO.Instance.GetNumberOfStudentOfCurrentSemester(currentSemester);
    }
}
