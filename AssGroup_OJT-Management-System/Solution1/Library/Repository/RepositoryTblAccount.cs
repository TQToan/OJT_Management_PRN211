﻿using Library.Data_Access;
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
        public bool CheckEmailIsExist(string email) => TblAccountDAO.Instance.CheckEmailIsExist(email);

        public TblAccount GetAccountByEmail(string email) => TblAccountDAO.Instance.GetAccountByEmail(email);

        public void InsertAccount(TblAccount account) => TblAccountDAO.Instance.InsertAccount(account);

        public void UpdateAccount(TblAccount account) => TblAccountDAO.Instance.UpdateAccount(account);
    }
}
