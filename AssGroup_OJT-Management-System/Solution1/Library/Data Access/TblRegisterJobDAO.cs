using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblRegisterJobDAO
    {
        //Using singleton
        private TblRegisterJobDAO() { }
        private static TblRegisterJobDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static TblRegisterJobDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblRegisterJobDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
