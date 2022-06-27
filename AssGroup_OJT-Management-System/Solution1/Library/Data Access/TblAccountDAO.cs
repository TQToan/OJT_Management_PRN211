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
    }
}
