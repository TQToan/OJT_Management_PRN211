using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repository
{
    public interface IRepositoryTblJob
    {
        void UpdateStatusJobAsAdmin(TblJob job);    //Admin Update Status vs Admin Confirm POST
        TblJob GetJobByID(int idJob);           //lay post theo ID job
        IEnumerable<dynamic> GetJobList123(); //lay cac bai post khi Load from
        
        //Admin search cac bai post cua company -------------------------------------------
        IEnumerable<dynamic> SearchJobByCompanyNameAsAdmin(string searchValue);
        IEnumerable<dynamic> SearchJobByJobNameAsAdmin(string searchValue);
        IEnumerable<dynamic> SearchJobByCompanyAddressAsAdmin(string searchValue);
        //----------------------------------------------------------------------
    }
}
