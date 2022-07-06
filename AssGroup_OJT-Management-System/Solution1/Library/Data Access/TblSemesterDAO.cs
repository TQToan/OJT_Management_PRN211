using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblSemesterDAO
    {
        //OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
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

        public IEnumerable<string> GetAllSemesterName()
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var list = from c in db.TblSemesters
                       orderby c.StartDate descending
                       select c.SemesterName;
            return list.ToList();
        }
        public TblSemester GetSemterBySemesterID(int id)
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            return  db.TblSemesters.Find(id);
        }
        public TblSemester GetCurrentSemester()
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var list = from semester in db.TblSemesters
                         orderby semester.StartDate descending
                         select semester;
            TblSemester result =  list.First();
            return result;
        }

        public TblSemester GetSemesterByName(string name)
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var result = from semester in db.TblSemesters
                         where semester.SemesterName == name
                         select semester;
            return result.FirstOrDefault();
        }

    }
}
