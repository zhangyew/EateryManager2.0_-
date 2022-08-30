using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;
using EateryManager.Model;
using common;

namespace EateryManager.DAL
{
    /// <summary>
    /// 数据访问类:Admins
    /// </summary>
    public partial class Admins_DAL
    {
        public Admins_DAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("UserID", "Admins");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Admins");
            strSql.Append(" where UserID=" + UserID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EateryManager.Model.Admins model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.UserName != null)
            {
                strSql1.Append("UserName,");
                strSql2.Append("'" + model.UserName + "',");
            }
            if (model.UserPwd != null)
            {
                strSql1.Append("UserPwd,");
                strSql2.Append("'" + model.UserPwd + "',");
            }
            //if (model.TrueName != null)
            //{
            //    strSql1.Append("IsDask,");
            //    strSql2.Append("0");
            //}
            if (model.TrueName != null)
            {
                strSql1.Append("TrueName,");
                strSql2.Append("'" + model.TrueName + "',");
            }
            strSql.Append("insert into Admins(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
            strSql.Append(";select @@IDENTITY");
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EateryManager.Model.Admins model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Admins set ");
            if (model.UserName != null)
            {
                strSql.Append("UserName='" + model.UserName + "',");
            }
            else
            {
                strSql.Append("UserName= null ,");
            }
            if (model.UserPwd != null)
            {
                strSql.Append("UserPwd='" + model.UserPwd + "',");
            }
            else
            {
                strSql.Append("UserPwd= null ,");
            }
            if (model.TrueName != null)
            {
                strSql.Append("TrueName='" + model.TrueName + "',");
            }
            else
            {
                strSql.Append("TrueName= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where UserID=" + model.UserID + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Admins ");
            strSql.Append(" where UserID=" + UserID + "");
            int rowsAffected = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rowsAffected > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }       /// <summary>
                /// 批量删除数据
                /// </summary>
        public bool DeleteList(string UserIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Admins ");
            strSql.Append(" where UserID in (" + UserIDlist + ")  ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EateryManager.Model.Admins GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" UserID,UserName,UserPwd,TrueName ");
            strSql.Append(" from Admins ");
            strSql.Append(" where UserID=" + UserID + "");
            EateryManager.Model.Admins model = new EateryManager.Model.Admins();
            DataSet ds = DbHelperSQL.Query(strSql.ToString());
            if (ds.Tables[0].Rows.Count > 0)
            {
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EateryManager.Model.Admins DataRowToModel(DataRow row)
        {
            EateryManager.Model.Admins model = new EateryManager.Model.Admins();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserPwd"] != null)
                {
                    model.UserPwd = row["UserPwd"].ToString();
                }
                if (row["TrueName"] != null)
                {
                    model.TrueName = row["TrueName"].ToString();
                }
            }
            return model;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserID,UserName,UserPwd,TrueName ");
            strSql.Append(" FROM Admins ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获得前几行数据
        /// </summary>
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append(" top " + Top.ToString());
            }
            strSql.Append(" UserID,UserName,UserPwd,TrueName ");
            strSql.Append(" FROM Admins ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /// <summary>
        /// 获取记录总数
        /// </summary>
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) FROM Admins ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("SELECT * FROM ( ");
            strSql.Append(" SELECT ROW_NUMBER() OVER (");
            if (!string.IsNullOrEmpty(orderby.Trim()))
            {
                strSql.Append("order by T." + orderby);
            }
            else
            {
                strSql.Append("order by T.UserID desc");
            }
            strSql.Append(")AS Row, T.*  from Admins T ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" WHERE " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
            return DbHelperSQL.Query(strSql.ToString());
        }

        /*
		*/

        #endregion  Method
        #region  MethodEx
        /// <summary>
        /// 查询信息是否存在
        /// </summary>
        /// <param name="stu"></param>
        /// <returns></returns>
        public bool CheckUserInfo(Model.Admins stu)
        {
            //定义SQL语句
            string sql = $"SELECT COUNT(*) FROM Admins WHERE 1=1 AND UserName=@yhm AND UserPwd=@pwd";
            //定义参数
            List<SqlParameter> sps = new List<SqlParameter>();
            sps.Add(new SqlParameter("yhm", stu.UserName));
            sps.Add(new SqlParameter("pwd", stu.UserPwd));
            int res = Convert.ToInt32(DbHelperSQL.GetSingle(sql, sps.ToArray()));
            return res == 1;
        }


        /// <summary>
        ///绑定登录界面下拉框
        /// </summary>
        public IList<Admins> Quanxian()
        {
            string sql = $"SELECT UserID,UserName FROM Admins WHERE 1=1 ";
            DataTable table = DbHelperSQL.GetTable(sql);
            return DataTableHelper<Admins>.ConvertToList(table);
        }

        /// <summary>
        /// 显示信息
        /// </summary>
        /// <returns></returns>
        public List<Admins> Looking()
        {
            string sql = $"SELECT UserID,TrueName FROM Admins WHERE 1=1 AND IsDask='0'";
            SqlDataReader r = DbHelperSQL.ExecuteReader(sql);
            List<Admins> admins = new List<Admins>();
            while (r != null && r.HasRows && r.Read())
            {
                Admins a = new Admins();
                a.UserID = Convert.ToInt32(r["UserID"]);
                a.TrueName = r["TrueName"].ToString();
                admins.Add(a);
            }
            return admins;
        }
        /// <summary>
		/// 删除商品类型
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteType(string id)
        {
            string sql = $"UPDATE Admins SET IsDask='1' WHERE 1=1 AND UserID=@id";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
            new SqlParameter("id",id)
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }
        #endregion  MethodEx

    }
}

