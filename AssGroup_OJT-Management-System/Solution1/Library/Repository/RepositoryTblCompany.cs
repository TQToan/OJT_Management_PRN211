using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Data_Access;
namespace Library.Repository
{
    public class RepositoryTblCompany : IRepositoryTblCompany
    {
        public bool CreateCompany(TblCompany company) => TblCompanyDAO.Instance.CreateCompany(company);

        public TblCompany GetCompany(string taxCode) => TblCompanyDAO.Instance.GetCompany(taxCode);

        public IEnumerable<dynamic> ListCompany() => TblCompanyDAO.Instance.ListCompany();

        public IEnumerable<dynamic> SearchCompanyFlFilter(string choose, string txtSearch) => TblCompanyDAO.Instance.SearchCompanyFlFilter(choose, txtSearch);



    }
}
