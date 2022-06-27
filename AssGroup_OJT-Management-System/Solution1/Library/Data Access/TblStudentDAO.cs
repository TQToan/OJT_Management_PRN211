using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblStudentDAO
    {
        //Using singleton
        private TblStudentDAO() { }
        private static TblStudentDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static TblStudentDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblStudentDAO();
                    }
                    return instance;
                }
            }
        }
    }
}
