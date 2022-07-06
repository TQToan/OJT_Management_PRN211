using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IRepositoryTblAccount
    {
        bool CheckEmailIsExist(String email);
        TblAccount GetAccountByEmail(string email);

        void InsertAccount(TblAccount account);
        void UpdateAccount(TblAccount account);
    }
}
