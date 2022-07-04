using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Data_Access
{
    public class TblJobDAO
    {
        //Using singleton
        private TblJobDAO() { }
        private static TblJobDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static TblJobDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblJobDAO();
                    }
                    return instance;
                }
            }
        }
        public static TblJob GetJobByID(int idJob)                      //Lay post theo ID
        {
            var db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            TblJob job = db.TblJobs.Where(j => j.JobCode == idJob).FirstOrDefault();
            return job;
        }
        public static List<TblJob> GetTblJobs()                         //Lay DS bai POST
        {
            var listJobAsAdmin = new List<TblJob>();
            try
            {
                using (var db = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    listJobAsAdmin = db.TblJobs.ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listJobAsAdmin;
        }
        public static void UpdateStatusJobAsAdmin(TblJob job)           //Update Status vs Admin Confirm POST
        {
            try
            {
                using (var db = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    
                    db.Entry<TblJob>(job).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    db.SaveChanges();      // cap nhat CSDL
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
