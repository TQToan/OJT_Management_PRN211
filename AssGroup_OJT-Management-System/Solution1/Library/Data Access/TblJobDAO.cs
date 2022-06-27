using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
