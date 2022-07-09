using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Data_Access
{
    public class TblAccountDAO
    {
        OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();   
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

        public TblAccount GetAccount(string username) => db.TblAccounts.Where(x => x.Username == username).FirstOrDefault();

    }
}
