using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblAccountDAO
    {
        //Using singleton
        private TblAccountDAO() { }
        private static TblAccountDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static TblAccountDAO Instance
        {
            get
            {
                lock(InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblAccountDAO();
                    }
                    return instance;
                }
            }
        }

        public TblAccount CheckLogin(string email, string password)
        {
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    return dBContext.TblAccounts.SingleOrDefault(account => account.Username.Equals(email) && account.Password.Equals(password));
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public bool CheckAvailabelAccount(string email)
        {
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    TblAccount account = dBContext.TblAccounts.SingleOrDefault(account => account.Username.Equals(email));
                    if (account != null)
                    {
                        return true;
                    }
                }
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return false;
        }
    }
}
