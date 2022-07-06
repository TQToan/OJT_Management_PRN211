using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblSttudentSemesterDAO
    {
        //private OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
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

        public void InsertStuSemester(TblStudentSemester stuSemester)
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            db.TblStudentSemesters.Add(stuSemester);
            db.SaveChanges();
        }
        public IEnumerable<TblStudentSemester> GetStudentInOtherSemester(string studentCode)
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            return (IEnumerable<TblStudentSemester>)db.TblStudentSemesters.Where(p => p.StudentCode == studentCode).ToList();
        }

        public bool CheckStudentAndSemesterIsExist(TblStudentSemester stuSem)
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var result = db.TblStudentSemesters.Where(p => p.StudentCode == stuSem.StudentCode && 
            p.SemesterId == stuSem.SemesterId).ToList();
            if (result.Count == 0)
            {
                return false;
            }
            return true;
        }
    }
}
