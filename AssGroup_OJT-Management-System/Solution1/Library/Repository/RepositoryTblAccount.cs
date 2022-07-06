using Library.Data_Access;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class RepositoryTblAccount : IRepositoryTblAccount
    {
        public bool CheckAvailabelAccount(string email) 
            => TblAccountDAO.Instance.CheckAvailabelAccount(email);

        public TblAccount CheckLogin(string email, string password)
            => TblAccountDAO.Instance.CheckLogin(email, password);
    }
}
