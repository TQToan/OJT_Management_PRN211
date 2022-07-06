using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;
using System.Data;

namespace Library.Data_Access
{
    public class TblJobDAO
    {
        //Using singleton
        private TblJobDAO() { }
        private static TblJobDAO instance = null;
        private static readonly object InstanceLock = new object();
        private static OJT_MANAGEMENT_PRN211_Vs1Context context = new OJT_MANAGEMENT_PRN211_Vs1Context();

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
            TblJob job = context.TblJobs.Where(j => j.JobCode == idJob).FirstOrDefault();
            return job;
        }


        public static IEnumerable<dynamic> GetJobList123()              //Lay DS bai POST
        {
            var listFullJob = (from job in context.TblJobs
                               orderby job.AdminConfirm ascending
                               select new
                               {
                                   JobCode = job.JobCode,
                                   JobName = job.JobName,
                                   CompanyName = job.TaxCodeNavigation.CompanyName,
                                   MajorName = job.MajorCodeNavigation.MajorName,
                                   NumberOfInTerns = job.NumberInterns,
                                   ExpirationDate = job.ExpirationDate,
                                   Address = job.TaxCodeNavigation.Address,
                                   ActionStatus = job.Status,
                                   AdminConfirm = job.AdminConfirm
                               });
            return listFullJob;
        }
        
        public static void UpdateStatusJobAsAdmin(TblJob job)           //Update Status vs Admin Confirm POST
        {
            try
            {

                context.Entry<TblJob>(job).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                context.SaveChanges();      // cap nhat CSDL

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public static IEnumerable<dynamic> SearchJobByCompanyNameAsAdmin(string searchValue)
        {
            var db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var listResult = context.TblJobs.Where(job => job.TaxCodeNavigation.CompanyName.ToUpper().Contains(searchValue.ToUpper()))
                .Select(job => new
                {
                    JobCode = job.JobCode,
                    JobName = job.JobName,
                    CompanyName = job.TaxCodeNavigation.CompanyName,
                    MajorName = job.MajorCodeNavigation.MajorName,
                    NumberOfInTerns = job.NumberInterns,
                    ExpirationDate = job.ExpirationDate,
                    Address = job.TaxCodeNavigation.Address,
                    ActionStatus = job.Status,
                    AdminConfirm = job.AdminConfirm

                }).OrderBy(job => job.AdminConfirm);
            return listResult;
        }
        public static IEnumerable<dynamic> SearchJobByJobNameAsAdmin(string searchValue)
        {
            var listResult = context.TblJobs.Where(job => job.JobName.ToUpper().Contains(searchValue.ToUpper()))
                .Select(job => new
                {
                    JobCode = job.JobCode,
                    JobName = job.JobName,
                    CompanyName = job.TaxCodeNavigation.CompanyName,
                    MajorName = job.MajorCodeNavigation.MajorName,
                    NumberOfInTerns = job.NumberInterns,
                    ExpirationDate = job.ExpirationDate,
                    Address = job.TaxCodeNavigation.Address,
                    ActionStatus = job.Status,
                    AdminConfirm = job.AdminConfirm

                }).OrderBy(job => job.AdminConfirm);
            return listResult;
        }
        public static IEnumerable<dynamic> SearchJobByCompanyAddressAsAdmin(string searchValue)
        {
            var listResult = context.TblJobs.Where(job => job.TaxCodeNavigation.Address.ToUpper().Contains(searchValue.ToUpper()))
                 .Select(job => new
                 {
                     JobCode = job.JobCode,
                     JobName = job.JobName,
                     CompanyName = job.TaxCodeNavigation.CompanyName,
                     MajorName = job.MajorCodeNavigation.MajorName,
                     NumberOfInTerns = job.NumberInterns,
                     ExpirationDate = job.ExpirationDate,
                     Address = job.TaxCodeNavigation.Address,
                     ActionStatus = job.Status,
                     AdminConfirm = job.AdminConfirm

                 }).OrderBy(job => job.AdminConfirm);
            return listResult;
        }
    }
}

