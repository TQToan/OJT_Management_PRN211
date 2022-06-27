using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblSemesterDAO
    {
        //Using singleton
        private TblSemesterDAO() { }
        private static TblSemesterDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static TblSemesterDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblSemesterDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
