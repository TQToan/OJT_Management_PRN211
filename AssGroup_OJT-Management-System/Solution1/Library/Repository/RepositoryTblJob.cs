using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Library.Data_Access;

namespace Library.Repository
{
    public class RepositoryTblJob : IRepositoryTblJob
    {


        public void UpdateStatusJobAsAdmin(TblJob job) => TblJobDAO.UpdateStatusJobAsAdmin(job); //Admin Update Status vs Admin Confirm POST
        public TblJob GetJobByID(int jobID) => TblJobDAO.GetJobByID(jobID); //Lay bai post theo ID post
        public IEnumerable<dynamic> GetJobList123() => TblJobDAO.GetJobList123(); ////Lay cac bai post

        //Admin search cac bai post cua company -------------------------------------------
        public IEnumerable<dynamic> SearchJobByCompanyNameAsAdmin(string searchValue) => TblJobDAO.SearchJobByCompanyNameAsAdmin(searchValue);
        public IEnumerable<dynamic> SearchJobByJobNameAsAdmin(string searchValue) => TblJobDAO.SearchJobByJobNameAsAdmin(searchValue);
        public IEnumerable<dynamic> SearchJobByCompanyAddressAsAdmin(string searchValue) => TblJobDAO.SearchJobByCompanyAddressAsAdmin(searchValue);
        //----------------------------------------------------------------------
    }
}
