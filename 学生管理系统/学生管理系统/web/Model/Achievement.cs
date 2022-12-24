using System;
namespace DBA.Model
{
    /// <summary>
    /// Achievement:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Achievement
    {
        public Achievement()
        { }
        #region Model
        private int _id;
        private string _userid;
        private string _courseid;
        private string _teacherid;
        private string _score;
        private string _time;
        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string UserID
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string CourseID
        {
            set { _courseid = value; }
            get { return _courseid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string TeacherID
        {
            set { _teacherid = value; }
            get { return _teacherid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Score
        {
            set { _score = value; }
            get { return _score; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Time
        {
            set { _time = value; }
            get { return _time; }
        }
        #endregion Model

    }
}

