using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Conris.DBA.ViewModel
{
    class AdminUser
    {
    }

 
    public class ProjectSearch
    {
        public string ProgectName { get; set; }
        public string CreateUserName { get; set; }
        public int Pageindex { get; set; }
    }
    //1
    public class ClassRoomSearch
    {
        public string Name { get; set; }

        public int Pageindex { get; set; }
    }
    //2
    public class UsersSearch
    {
        public string Name { get; set; }
        public string LoginName { get; set; }
        public string Str1 { get; set; }
        public int Pageindex { get; set; }
    }
    //3
    public class CourseSearch
    {
        public string Name { get; set; }
     
        public int Pageindex { get; set; }
    }
    //4
    public class TeacherSearch
    {
        public string Name { get; set; }

        public int Pageindex { get; set; }
    }
    //5
    public class TitleSearch
    {
        public string Name { get; set; }

        public int Pageindex { get; set; }
    }
    //6
    public class BookSearch
    {
        public string BookName { get; set; }
        public string BookCBS { get; set; }
        public string ISBN { get; set; }
        public string BookZZ { get; set; }
        public string CategoryID { get; set; }
        public int Pageindex { get; set; }
    }
    public class AchievementSearch
    {
        public string TeacherID { get; set; }
        public string UserID { get; set; }
        public string CourseID { get; set; }
        public int Pageindex { get; set; }
    }

    public class CKRecordSearch
    {
        public string BookName { get; set; }
        public string ISBN { get; set; }
        public string BookZZ { get; set; }
        public int Pageindex { get; set; }
    }
}
