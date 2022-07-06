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
        public int GetNumberOfStudentOfCurrentSemester(TblSemester currentSemester)
        {
            int numberOfStudent = 0;
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dbContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    numberOfStudent = dbContext.TblStudentSemesters.Where(semester => semester.SemesterId == currentSemester.SemesterId).Count();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return numberOfStudent;
        }
    }
}
