using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using Library.Data_Access;

namespace Library.Repository
{
    public class RepositoryTblJob: IRepositoryTblJob
    {
        
        public List<TblJob> GetTblJobs() => TblJobDAO.GetTblJobs();     //Lay cac bai post
        public void UpdateStatusJobAsAdmin(TblJob job) => TblJobDAO.UpdateStatusJobAsAdmin(job); //Admin Update Status vs Admin Confirm POST
        public TblJob GetJobByID(int jobID) => TblJobDAO.GetJobByID(jobID); //Lay bai post theo ID post
    }
}
