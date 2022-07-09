using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;


namespace Library.Data_Access
{
    public class TblCompanyDAO
    {
        OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
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

        public IEnumerable<dynamic> ListCompany()
        {
            var result = from c in db.TblCompanies
                         select new
                         {
                             CompanyName = c.CompanyName,
                             CompanyTax = c.TaxCode,
                             Email = c.Username,
                             Address = c.Address,
                             NumberOfJob = c.TblJobs.Count,
                         };
            return result;
        }

        public TblCompany GetCompany(string taxCode) => db.TblCompanies.Where(c => c.TaxCode == taxCode).FirstOrDefault();

        public bool CreateCompany(TblCompany company)
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.TblAccounts.Add(company.UsernameNavigation);
                    db.SaveChanges();

                    db.TblCompanies.Add(company);
                    db.SaveChanges();

                    transaction.Commit();
                    return true;
                }catch (Exception ex)
                {
                    transaction.Rollback();
                    //System.Diagnostics.Debug.WriteLine(ex.Message);
                }

            }
            return false;
        }
        

        public IEnumerable<dynamic> SearchCompanyFlFilter(string choose, string txtSearch)
        {
            IEnumerable<dynamic> listCompany = ListCompany();
            List<dynamic> result = new List<dynamic>();
            //System.Diagnostics.Debug.WriteLine(choose);
            foreach (var item in listCompany)
            {
                bool check = true;
                if (choose.Equals("Company name"))
                {
                    if (txtSearch != string.Empty && !(item.CompanyName.Trim().ToLower().Contains(txtSearch.Trim().ToLower())))
                    {
                        check = false;
                    }
                } else if (choose.Equals("Company tax"))
                {
                    if (txtSearch != string.Empty && !(item.CompanyTax.Trim().ToLower().Contains(txtSearch.Trim().ToLower())))
                    {
                        check = false;
                    }
                    
                }else if (choose.Equals("Company address"))
                {
                    if (txtSearch != string.Empty && !(item.Address.Trim().ToLower().Contains(txtSearch.Trim().ToLower())))
                    {
                        check = false;
                    }
                }
                if (check)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
