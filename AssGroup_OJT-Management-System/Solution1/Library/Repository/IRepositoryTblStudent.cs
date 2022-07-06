using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Models;

namespace Library.Repository
{
    public interface IRepositoryTblStudent
    {
        void InsertStudent(TblStudent student);
        void UpdateStudent(TblStudent student);
        bool ChecStudentIDIsExist(string studentID);
        IEnumerable<TblStudent> GetStudentListBySemesterID(int semesterID);
        IEnumerable<TblStudent> GetStudentListByStudentName(int semesterID, string studentName);
        IEnumerable<TblStudent> GetStudentListByStudentCode(int semesterID, string studentCode);
        IEnumerable<TblStudent> GetStudentListByAddress(int semesterID, string address);
        IEnumerable<TblStudent> GetStudentListByCredits(int semesterID, int credit);
        IEnumerable<TblStudent> GetStudentListByMajorName(int semesterID, string major);
        TblStudent GetStudentByStudentID(string id);

        TblStudent GetStudentProfileByUserName(string username);
    }
}
