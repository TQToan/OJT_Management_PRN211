using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblSttudentSemesterDAO
    {
        //Using singleton
        private TblSttudentSemesterDAO() { }
        private static TblSttudentSemesterDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static TblSttudentSemesterDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblSttudentSemesterDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
