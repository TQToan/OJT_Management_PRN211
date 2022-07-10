using Library.Data_Access;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class RepositoryTblCompany : IRepositoryTblCompany
    {
        public TblCompany GetCompanyByTaxCode(string taxcode)
            => TblCompanyDAO.Instance.GetCompanyByTaxCode(taxcode);

        public TblCompany GetCompanyInformation(string Email) 
            => TblCompanyDAO.Instance.GetCompanyInformation(Email);

        public int GetNumberOfCompany() 
            => TblCompanyDAO.Instance.GetNumberOfCompany();

        public void UpdateCompanyInformation(TblCompany company) 
            => TblCompanyDAO.Instance.UpdateCompanyInformation(company);
    }
}
