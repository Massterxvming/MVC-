
using System;
namespace DBA.Model
{
	/// <summary>
	/// Teacher:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Teacher
	{
		public Teacher()
		{}
		#region Model
		private int _id;
		private string _teachername;
		private string _course;
		private string _title;
		private string _time;
		private string _str1;
		/// <summary>
		/// 
		/// </summary>
		public int ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TeacherName
		{
			set{ _teachername=value;}
			get{return _teachername;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Course
		{
			set{ _course=value;}
			get{return _course;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Time
		{
			set{ _time=value;}
			get{return _time;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Str1
		{
			set{ _str1=value;}
			get{return _str1;}
		}
		#endregion Model

	}
}

