using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblMajorDAO
    {
        //Using singleton
        private TblMajorDAO() { }
        private static TblMajorDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static TblMajorDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblMajorDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
