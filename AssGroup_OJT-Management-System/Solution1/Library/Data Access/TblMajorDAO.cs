using Library.Models;
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

        public IEnumerable<string> GetAllMajorName()
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var list = from major in db.TblMajors
                       select major.MajorName;
            return list.ToList();
        }
    }
}
