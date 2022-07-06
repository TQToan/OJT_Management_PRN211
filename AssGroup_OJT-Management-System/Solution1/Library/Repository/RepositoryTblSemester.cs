using Library.Data_Access;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class RepositoryTblSemester : IRepositoryTblSemester
    {
        public TblSemester GetCurrentSemester() 
            => TblSemesterDAO.Instance.GetCurrentSemester();
        public void AddNewSemester(TblSemester newSemester) 
            => TblSemesterDAO.Instance.AddNewSemester(newSemester);
    }
}
