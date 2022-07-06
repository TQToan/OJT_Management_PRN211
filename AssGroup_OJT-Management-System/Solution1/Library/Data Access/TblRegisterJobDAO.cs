using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Data_Access
{
    public class TblRegisterJobDAO
    {
       // private OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
        //Using singleton
        private TblRegisterJobDAO() { }
        private static TblRegisterJobDAO instance = null;
        private static readonly object InstanceLock = new object();
        public static TblRegisterJobDAO Instance
        {
            get
            {
                lock (InstanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TblRegisterJobDAO();
                    }
                    return instance;
                }
            }
        }

        // hàm kiểm tra Cour status, lấy job mới nhất kiểm tra là pass, hay not pass(bao gồm not pass, not yet)
        public bool checkCourStatusByStudentCode(string studentCode)
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var list = from appl in db.TblRegisterJobs join job in db.TblJobs on appl.JobCode equals job.JobCode
                       where appl.StudentCode == studentCode 
                         orderby job.ExpirationDate descending 
                         select appl;
            var result = list.FirstOrDefault();
            if (result != null && result.IsPass == false)
            {
                return true;
            }
            return false;
        }


        // hàm kiểm tra student đã pass chưa trong tất các kỳ, chỉ cần 1 pass return true 
        public bool checkStudentIsPass(string studentCode)
        {
            using OJT_MANAGEMENT_PRN211_Vs1Context db = new OJT_MANAGEMENT_PRN211_Vs1Context();
            var list = from appl in db.TblRegisterJobs
                       where appl.StudentCode == studentCode && appl.IsPass == false
                       select appl;
            if (list.Count() != 0)
            {
                return true;
            }
            return false;
        }

    }
}
