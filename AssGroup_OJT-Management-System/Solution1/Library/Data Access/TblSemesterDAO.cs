using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

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

        public TblSemester GetCurrentSemester()
        {
            TblSemester semester = null;
            List<TblSemester> listSemester = null;
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dBContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    listSemester = dBContext.TblSemesters.ToList();
                    if (listSemester.Count > 0)
                    {
                        semester = listSemester.OrderByDescending(semester => semester.EndDate).First();
                    }
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return semester;
        }

        public void AddNewSemester(TblSemester newSemester)
        {
            try
            {
                using (OJT_MANAGEMENT_PRN211_Vs1Context dbContext = new OJT_MANAGEMENT_PRN211_Vs1Context())
                {
                    dbContext.TblSemesters.Add(newSemester);
                    dbContext.SaveChanges();
                }
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
