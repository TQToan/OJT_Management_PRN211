using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
namespace Library.Repository
{
    public interface IRepositoryTblCompany
    {

        public IEnumerable<dynamic> ListCompany();

        public IEnumerable<dynamic> SearchCompanyFlFilter(string choose, string txtSearch);

        public TblCompany GetCompany(string taxCode);

        public bool CreateCompany(TblCompany company);
    }
}
