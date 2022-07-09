using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data_Access;
namespace Library.Repository
{
    public class RepositoryTblAccount : IRepositoryTblAccount
    {
        public TblAccount GetAccount(string username) => TblAccountDAO.Instance.GetAccount(username);

    }
}
