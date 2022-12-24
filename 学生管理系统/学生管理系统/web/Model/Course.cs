
using System;
namespace DBA.Model
{
	/// <summary>
	/// Course:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Course
	{
		public Course()
		{}
		#region Model
		private int _id;
		private string _coursename;
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
		public string CourseName
		{
			set{ _coursename=value;}
			get{return _coursename;}
		}
		#endregion Model

	}
}

