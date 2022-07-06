using Library.Data_Access;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Repository
{
    public class RepositoryTblJob : IRepositoryTblJob
    {
        public List<TblJob> GetListCompanyJobPost(TblCompany company) 
            => TblJobDAO.Instance.GetListCompanyJobPost(company);

        public int GetNumberOfAvailableJob() 
            => TblJobDAO.Instance.GetNumberOfAvailableJob();

        public int GetNumberOfInterns(TblCompany company, int companyConfirm, int studentIntern)
            => TblJobDAO.Instance.GetNumberOfInterns(company, companyConfirm, studentIntern);
    }
}
