using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblCompanyDAO
    {
        //Using singleton
        private TblCompanyDAO() { }
        private static TblCompanyDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static TblCompanyDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblCompanyDAO();
                    }
                    return instance;
                }
            }
        }

        public int GetNumberOfCompany()
        {
            int numberOfCompany = 0;
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dbContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    numberOfCompany = dbContext.TblCompanies.Count();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return numberOfCompany;
        }

        public TblCompany GetCompanyInformation(string Email)
        {
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    return dBContext.TblCompanies.SingleOrDefault(company => company.Username.Equals(Email));
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void UpdateCompanyInformation (TblCompany company)
        {
            try
            {
                using(OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    dBContext.Entry<TblCompany>(company).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    dBContext.SaveChanges();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public TblCompany GetCompanyByTaxCode(string taxcode)
        {
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    return dBContext.TblCompanies.Find(taxcode);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


    }
}
