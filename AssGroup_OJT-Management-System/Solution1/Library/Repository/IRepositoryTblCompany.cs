using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IRepositoryTblCompany
    {
        public int GetNumberOfCompany();
        public TblCompany GetCompanyInformation(string Email);
        public void UpdateCompanyInformation(TblCompany company);
    }
}
