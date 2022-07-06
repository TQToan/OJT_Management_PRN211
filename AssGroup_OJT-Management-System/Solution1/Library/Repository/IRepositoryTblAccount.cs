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
        public TblAccount CheckLogin(string email, string password);
        public bool CheckAvailabelAccount(string email);
    }
}
