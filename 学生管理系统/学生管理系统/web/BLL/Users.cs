
using System;
using System.Data;
using System.Collections.Generic;

using DBA.Model;
using System.Text;
using Conris.Utility;
namespace DBA.BLL
{
    /// <summary>
    /// Users
    /// </summary>
    public partial class Users
    {
        private readonly DBA.DAL.Users dal = new DBA.DAL.Users();
        private readonly DBA.BLL.Achievement abll = new DBA.BLL.Achievement();
        public Users()
        { }
        #region  BasicMethod

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return dal.GetMaxId();
        }

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
        public int Add(DBA.Model.Users model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(DBA.Model.Users model)
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
        public bool DeleteList(string IDlist)
        {
            return dal.DeleteList(IDlist);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public DBA.Model.Users GetModel(int ID)
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DBA.Model.Users> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<DBA.Model.Users> DataTableToList(DataTable dt)
        {
            List<DBA.Model.Users> modelList = new List<DBA.Model.Users>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                DBA.Model.Users model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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
        public bool Edit(DBA.Model.Users model)
        {
            if (model.ID == 0)
            {
                model.Usertype = "学生";
                Add(model);
                return true;
            }
            else
            {
                model.Usertype = "学生";
                return Update(model);
            }
        }
        public List<DBA.Model.Users> SearchProject(Conris.DBA.ViewModel.UsersSearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder(" LoginName!='admin'");
            if (!string.IsNullOrEmpty(model.Name))
            {

                sb.Append(" And UserName like '%" + model.Name + "%'");
            }
            if (!string.IsNullOrEmpty(model.LoginName))
            {

                sb.Append(" And LoginName like '%" + model.LoginName + "%'");
            }
            sb.Append(" Order by ID Desc");
            return GetModelList(sb.ToString());
        }

        public List<DBA.Model.Users> SearchZF(Conris.DBA.ViewModel.UsersSearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder(" LoginName!='admin'");
            if (!string.IsNullOrEmpty(model.Name))
            {

                sb.Append(" And UserName like '%" + model.Name + "%'");
            }
            if (!string.IsNullOrEmpty(model.LoginName))
            {

                sb.Append(" And LoginName like '%" + model.LoginName + "%'");
            }
            sb.Append(" Order by ID Desc");
            List<DBA.Model.Users> list = GetModelList(sb.ToString());
            foreach (var item in list)
            {
                item.LoginPSD = GetSumNum(" UserID='" + item.LoginName + "'");
            }
            return list;
        }

        public List<DBA.Model.Users> SearchBB(string arr,Conris.DBA.ViewModel.UsersSearch model)
        {
            if (model == null)
                return null;
            StringBuilder sb = new StringBuilder(" LoginName!='admin'");
            if (!string.IsNullOrEmpty(model.Name))
            {

                sb.Append(" And UserName like '%" + model.Name + "%'");
            }
            if (!string.IsNullOrEmpty(model.LoginName))
            {

                sb.Append(" And LoginName like '%" + model.LoginName + "%'");
            }
            if (!string.IsNullOrEmpty(model.Str1))
            {

                sb.Append(" And Str1 like '%" + model.Str1 + "%'");
            }
            sb.Append(" Order by ID Desc");
            List<DBA.Model.Users> list = GetModelList(sb.ToString());
            string[] arrnew = arr.Split(',');
            foreach (var item in list)
            {
                item.UserNum = "";
                item.LoginPSD = GetSumNum(" UserID='" + item.LoginName + "'");
                foreach (var itemitem in arrnew)
                {
                    if (!string.IsNullOrEmpty(itemitem))
                    {
                        List<DBA.Model.Achievement> amodel = abll.GetModelList(" UserID='" + item.LoginName + "' and CourseID='" + itemitem + "'");
                        if (amodel==null||amodel.Count==0)
                        {
                            item.UserNum = item.UserNum + "0" + ",";      
                        }
                        else
                        {
                            item.UserNum = item.UserNum + amodel[0].Score + ",";     
                        }
                    }

                }
            }
           
            return list;
        }
        /// 是否存在该记录
        /// </summary>
        public string Login(string LoginName, string LoginPsd, bool IsStay)
        {
            string str = string.Format(" LoginName='{0}' and LoginPSD='{1}'  ", LoginName, LoginPsd);
            List<DBA.Model.Users> list = GetModelList(str);
            if (list.Count != 0)
            {
                AuthenHelper.Logout();
                AuthenHelper.CreateTicket(list[0].UserName, list[0].ID.ToString(), IsStay, DateTime.Now.AddHours(2), "");
                return "1";
            }
            else
                return "0";
        }

        //查询求和数量
        public string GetSumNum(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select sum(convert(int, Score)) ");
            strSql.Append(" FROM Achievement ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return Convert.ToInt32(DbHelperSQL.GetSingle(strSql.ToString())).ToString();
        }
        //登出
        public bool LogOut()
        {
            try
            {
                AuthenHelper.Logout();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static string GetNowUserName()
        {
            return AuthenHelper.GetLoginUserName();
        }

        public static string GetNowUserType()
        {
            string ID = AuthenHelper.GetLoginUserData();
            DBA.DAL.Users dale = new DAL.Users();
            return dale.GetModel(Convert.ToInt32(ID)).Usertype.Trim();


        }

        public static string GetUserXH()
        {
            string ID = AuthenHelper.GetLoginUserData();
            DBA.DAL.Users dale = new DAL.Users();
            return dale.GetModel(Convert.ToInt32(ID)).LoginName.Trim();


        }
        #endregion  ExtensionMethod
    }
}

