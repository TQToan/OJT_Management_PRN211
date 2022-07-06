using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public interface IRepositoryTblJob
    {
        public int GetNumberOfAvailableJob();
        public int GetNumberOfInterns(TblCompany company, int companyConfirm, int studentIntern);
        public List<TblJob> GetListCompanyJobPost(TblCompany company);
    }
}
