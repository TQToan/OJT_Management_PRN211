using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data_Access;
using Library.Models;

namespace Library.Repository
{
    public class RepositoryTblStudent : IRepositoryTblStudent
    {
        public TblStudent GetStudentProfileByUserName(string username) =>
            TblStudentDAO.GetStudentProfileByUserName(username);
    }
}
