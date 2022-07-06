using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Data_Access
{
    public class TblStudentDAO
    {
        //Using singleton
        private TblStudentDAO() { }
        private static TblStudentDAO instance = null;
        private static readonly object InstanceLock = new object();
        private static OJT_MANAGEMENT_PRN211_Vs1Context context = new OJT_MANAGEMENT_PRN211_Vs1Context();

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

        public static TblStudent GetStudentProfileByUserName(string username)              //Lay DS bai POST
        {
            var infoStudent = context.TblStudents.FirstOrDefault(stu => stu.Username == username);
            //var infoStudent = (from stu in context.TblStudents
            //                   join sem in context.TblStudentSemesters on stu.StudentCode equals sem.StudentCode
            //                   where stu.StudentName == username
            //                   select new
            //                   {
            //                       Email = stu.Username,
            //                       StudentName = stu.StudentName,
            //                       StudentCode = stu.StudentCode,
            //                       Semester = sem.Semester.SemesterName,
            //                       MajorName = stu.Majorname,
            //                       Credit = stu.Credit,
            //                   });
            return infoStudent;
        }
    }
}
