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
    /// 数据访问类:Vips
    /// </summary>
    public partial class Vips_DAL
    {
        public Vips_DAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("VipID", "Vips");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int VipID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Vips");
            strSql.Append(" where VipID=" + VipID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EateryManager.Model.Vips model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.VipName != null)
            {
                strSql1.Append("VipName,");
                strSql2.Append("'" + model.VipName + "',");
            }
            if (model.VipSex != null)
            {
                strSql1.Append("VipSex,");
                strSql2.Append("'" + model.VipSex + "',");
            }
            if (model.VGID != null)
            {
                strSql1.Append("VGID,");
                strSql2.Append("" + model.VGID + ",");
            }
            if (model.VipTel != null)
            {
                strSql1.Append("VipTel,");
                strSql2.Append("'" + model.VipTel + "',");
            }
            if (model.VipStartDate != null)
            {
                strSql1.Append("VipStartDate,");
                strSql2.Append("'" + model.VipStartDate + "',");
            }
            if (model.VipEndDate != null)
            {
                strSql1.Append("VipEndDate,");
                strSql2.Append("'" + model.VipEndDate + "',");
            }
            strSql.Append("insert into Vips(");
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
        public bool Update(EateryManager.Model.Vips model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Vips set ");
            if (model.VipName != null)
            {
                strSql.Append("VipName='" + model.VipName + "',");
            }
            else
            {
                strSql.Append("VipName= null ,");
            }
            if (model.VipSex != null)
            {
                strSql.Append("VipSex='" + model.VipSex + "',");
            }
            else
            {
                strSql.Append("VipSex= null ,");
            }
            if (model.VGID != null)
            {
                strSql.Append("VGID=" + model.VGID + ",");
            }
            else
            {
                strSql.Append("VGID= null ,");
            }
            if (model.VipTel != null)
            {
                strSql.Append("VipTel='" + model.VipTel + "',");
            }
            else
            {
                strSql.Append("VipTel= null ,");
            }
            if (model.VipStartDate != null)
            {
                strSql.Append("VipStartDate='" + model.VipStartDate + "',");
            }
            else
            {
                strSql.Append("VipStartDate= null ,");
            }
            if (model.VipEndDate != null)
            {
                strSql.Append("VipEndDate='" + model.VipEndDate + "',");
            }
            else
            {
                strSql.Append("VipEndDate= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where VipID=" + model.VipID + "");
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
        public bool Delete(int VipID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Vips ");
            strSql.Append(" where VipID=" + VipID + "");
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
        public bool DeleteList(string VipIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Vips ");
            strSql.Append(" where VipID in (" + VipIDlist + ")  ");
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
        public EateryManager.Model.Vips GetModel(int VipID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" VipID,VipName,VipSex,VGID,VipTel,VipStartDate,VipEndDate ");
            strSql.Append(" from Vips ");
            strSql.Append(" where VipID=" + VipID + "");
            EateryManager.Model.Vips model = new EateryManager.Model.Vips();
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
        public EateryManager.Model.Vips DataRowToModel(DataRow row)
        {
            EateryManager.Model.Vips model = new EateryManager.Model.Vips();
            if (row != null)
            {
                if (row["VipID"] != null && row["VipID"].ToString() != "")
                {
                    model.VipID = int.Parse(row["VipID"].ToString());
                }
                if (row["VipName"] != null)
                {
                    model.VipName = row["VipName"].ToString();
                }
                if (row["VipSex"] != null)
                {
                    model.VipSex = row["VipSex"].ToString();
                }
                if (row["VGID"] != null && row["VGID"].ToString() != "")
                {
                    model.VGID = (row["VGID"].ToString());
                }
                if (row["VipTel"] != null)
                {
                    model.VipTel = row["VipTel"].ToString();
                }
                if (row["VipStartDate"] != null && row["VipStartDate"].ToString() != "")
                {
                    model.VipStartDate = DateTime.Parse(row["VipStartDate"].ToString());
                }
                if (row["VipEndDate"] != null && row["VipEndDate"].ToString() != "")
                {
                    model.VipEndDate = DateTime.Parse(row["VipEndDate"].ToString());
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
            strSql.Append("select VipID,VipName,VipSex,VGID,VipTel,VipStartDate,VipEndDate ");
            strSql.Append(" FROM Vips ");
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
            strSql.Append(" VipID,VipName,VipSex,VGID,VipTel,VipStartDate,VipEndDate ");
            strSql.Append(" FROM Vips ");
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
            strSql.Append("select count(1) FROM Vips ");
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
                strSql.Append("order by T.VipID desc");
            }
            strSql.Append(")AS Row, T.*  from Vips T ");
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
        /// 显示信息
        /// </summary>
        /// <returns></returns>
        public List<Vips> Looking(string cx)
        {
            string sql = $"SELECT VipID, VipName, VipSex, B.VGName,B.VGDiscount, VipTel, VipStartDate, VipEndDate FROM Vips A INNER JOIN VipGrade B ON B.VGID=A.VGID WHERE 1=1 AND A.IsDask='0' AND B.IsDask='0'";

            List<SqlParameter> sps = new List<SqlParameter>();
            if (cx != null)
            {
                sql += $" AND VipName LIKE '%{cx}%'";
                // new SqlParameter("name", $"%{cx}%");
                //new SqlParameter("id", $"%{cx}%");
            }
            List<Vips> v = new List<Vips>();
            SqlDataReader r = DbHelperSQL.ExecuteReader(sql, sps.ToArray());
            while (r != null && r.HasRows && r.Read())
            {
                Vips s = new Vips();
                s.VipID = Convert.ToInt32(r["VipID"]);
                s.VipName = r["VipName"].ToString();
                s.VipSex = r["VipSex"].ToString();
                s.VGID = r["VGName"].ToString();
                s.VGDiscount = double.Parse(r["VGDiscount"].ToString());
                s.VipTel = r["VipTel"].ToString();
                s.VipStartDate = (DateTime?)r["VipStartDate"];
                s.VipEndDate = (DateTime?)r["VipEndDate"];
                v.Add(s);
            }
            return v;
        }
        /// <summary>
        ///绑定界面下拉框
        /// </summary>
        public IList<VipGrade> Quanxian()
        {
            string sql = $"SELECT VGID,VGName FROM VipGrade WHERE 1=1 AND IsDask='0'";
            DataTable table = DbHelperSQL.GetTable(sql);
            return DataTableHelper<VipGrade>.ConvertToList(table);
        }
        /// <summary>
        /// 查询最大编号
        /// </summary>
        /// <returns></returns>
        public int LookMIX()
        {
            string sql = $"SELECT TOP 1 MAX(VipID) FROM Vips WHERE 1=1";
            int r =Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));
            return r;
        }
        /// <summary>
		/// 删除商品类型
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteType(string id)
        {
            string sql = $"UPDATE Vips SET IsDask='1' WHERE 1=1 AND VipID=@id";
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

