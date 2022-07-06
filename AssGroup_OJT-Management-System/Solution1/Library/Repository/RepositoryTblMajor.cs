﻿using Library.Data_Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class RepositoryTblMajor : IRepositoryTblMajor
    {
        public IEnumerable<string> GetAllMajorName() => TblMajorDAO.Instance.GetAllMajorName();
    }
}
