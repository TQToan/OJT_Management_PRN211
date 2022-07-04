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
        List<TblJob> GetTblJobs();
        void UpdateStatusJobAsAdmin(TblJob job);
        TblJob GetJobByID(int idJob);
    }
}
