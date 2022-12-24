
using System;
using System.Data;
using System.Collections.Generic;

using DBA.Model;
using System.Text;
namespace DBA.BLL
{
	/// <summary>
	/// Achievement
	/// </summary>
	public partial class Achievement
	{
		private readonly DBA.DAL.Achievement dal=new DBA.DAL.Achievement();
		public Achievement()
		{}
		#region  BasicMethod

		

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int ID)
		{
			return dal.Exists(ID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(DBA.Model.Achievement model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(DBA.Model.Achievement model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ID)
		{
			
			return dal.Delete(ID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string IDlist )
		{
			return dal.DeleteList(IDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DBA.Model.Achievement GetModel(int ID)
		{
			
			return dal.GetModel(ID);
		}

		

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DBA.Model.Achievement> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DBA.Model.Achievement> DataTableToList(DataTable dt)
		{
			List<DBA.Model.Achievement> modelList = new List<DBA.Model.Achievement>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DBA.Model.Achievement model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
        #region  ExtensionMethod
        public bool Edit(DBA.Model.Achievement model)
        {
            if (model.ID == 0)
            {
                Add(model);
                return true;
            }
            else
            {
                return Update(model);
            }
        }
        public List<DBA.Model.Achievement> SearchProject(Conris.DBA.ViewModel.AchievementSearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder(" 1=1");
            if (DBA.BLL.Users.GetNowUserType() == "学生")
            {
                sb.Append(" And UserID ='" + DBA.BLL.Users.GetUserXH() + "'");
            }
            if (!string.IsNullOrEmpty(model.UserID))
            {

                sb.Append(" And UserID ='" + model.UserID + "'");
            }
            if (!string.IsNullOrEmpty(model.CourseID))
            {

                sb.Append(" And CourseID ='" + model.CourseID + "'");
            }
            if (!string.IsNullOrEmpty(model.TeacherID))
            {

                sb.Append(" And TeacherID ='" + model.TeacherID + "'");
            }
            sb.Append(" Order by ID Desc");
            return GetModelList(sb.ToString());
        }

        public List<DBA.Model.Achievement> DSearch(Conris.DBA.ViewModel.AchievementSearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder(" 1=1");
            if (DBA.BLL.Users.GetNowUserType() == "学生")
            {
                sb.Append(" And UserID ='" + DBA.BLL.Users.GetUserXH() + "'");
            }
            if (!string.IsNullOrEmpty(model.UserID))
            {

                sb.Append(" And UserID ='" + model.UserID + "'");
            }
            if (!string.IsNullOrEmpty(model.CourseID))
            {

                sb.Append(" And CourseID ='" + model.CourseID + "'");
            }
            if (!string.IsNullOrEmpty(model.TeacherID))
            {

                sb.Append(" And TeacherID ='" + model.TeacherID + "'");
            }
            sb.Append(" Order by  cast(Score as int) Desc");
            return GetModelList(sb.ToString());
        }
        #endregion  ExtensionMethod
	}
}

