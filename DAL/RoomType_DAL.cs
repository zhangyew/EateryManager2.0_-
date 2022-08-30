using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using common;
using EateryManager.Model;
using System.Collections.Generic;

namespace EateryManager.DAL
{
    /// <summary>
    /// 数据访问类:RoomType
    /// </summary>
    public partial class RoomType_DAL
    {
        public RoomType_DAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("RTID", "RoomType");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int RTID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from RoomType");
            strSql.Append(" where RTID=" + RTID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EateryManager.Model.RoomType model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.RTName != null)
            {
                strSql1.Append("RTName,");
                strSql2.Append("'" + model.RTName + "',");
            }
            if (model.RTMin != null)
            {
                strSql1.Append("RTMin,");
                strSql2.Append("" + model.RTMin + ",");
            }
            if (model.RTIsDis != null)
            {
                strSql1.Append("RTIsDis,");
                strSql2.Append("" + (model.RTIsDis ? 1 : 0) + ",");
            }
            if (model.RTNum != null)
            {
                strSql1.Append("RTNum,");
                strSql2.Append("" + model.RTNum + ",");
            }
            strSql.Append("insert into RoomType(");
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
        public bool Update(EateryManager.Model.RoomType model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update RoomType set ");
            if (model.RTName != null)
            {
                strSql.Append("RTName='" + model.RTName + "',");
            }
            else
            {
                strSql.Append("RTName= null ,");
            }
            if (model.RTMin != null)
            {
                strSql.Append("RTMin=" + model.RTMin + ",");
            }
            else
            {
                strSql.Append("RTMin= null ,");
            }
            if (model.RTIsDis != null)
            {
                strSql.Append("RTIsDis=" + (model.RTIsDis ? 1 : 0) + ",");
            }
            else
            {
                strSql.Append("RTIsDis= null ,");
            }
            if (model.RTNum != null)
            {
                strSql.Append("RTNum=" + model.RTNum + ",");
            }
            else
            {
                strSql.Append("RTNum= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where RTID=" + model.RTID + "");
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
        public bool Delete(int RTID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RoomType ");
            strSql.Append(" where RTID=" + RTID + "");
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
        public bool DeleteList(string RTIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from RoomType ");
            strSql.Append(" where RTID in (" + RTIDlist + ")  ");
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
        public EateryManager.Model.RoomType GetModel(int RTID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" RTID,RTName,RTMin,RTIsDis,RTNum ");
            strSql.Append(" from RoomType ");
            strSql.Append(" where RTID=" + RTID + "");
            EateryManager.Model.RoomType model = new EateryManager.Model.RoomType();
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
        public EateryManager.Model.RoomType DataRowToModel(DataRow row)
        {
            EateryManager.Model.RoomType model = new EateryManager.Model.RoomType();
            if (row != null)
            {
                if (row["RTID"] != null && row["RTID"].ToString() != "")
                {
                    model.RTID = int.Parse(row["RTID"].ToString());
                }
                if (row["RTName"] != null)
                {
                    model.RTName = row["RTName"].ToString();
                }
                if (row["RTMin"] != null && row["RTMin"].ToString() != "")
                {
                    model.RTMin = decimal.Parse(row["RTMin"].ToString());
                }
                if (row["RTIsDis"] != null && row["RTIsDis"].ToString() != "")
                {
                    if ((row["RTIsDis"].ToString() == "1") || (row["RTIsDis"].ToString().ToLower() == "true"))
                    {
                        model.RTIsDis = true;
                    }
                    else
                    {
                        model.RTIsDis = false;
                    }
                }
                if (row["RTNum"] != null && row["RTNum"].ToString() != "")
                {
                    model.RTNum = int.Parse(row["RTNum"].ToString());
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
            strSql.Append("select RTID,RTName,RTMin,RTIsDis,RTNum ");
            strSql.Append(" FROM RoomType ");
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
            strSql.Append(" RTID,RTName,RTMin,RTIsDis,RTNum ");
            strSql.Append(" FROM RoomType ");
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
            strSql.Append("select count(1) FROM RoomType ");
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
                strSql.Append("order by T.RTID desc");
            }
            strSql.Append(")AS Row, T.*  from RoomType T ");
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
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        public IList<RoomType> Quanxian()
        {
            string sql = $"  SELECT RTID,RTName FROM RoomType WHERE 1=1  AND IsDask=0 UNION SELECT 0,'全部房间'";
            DataTable table = DbHelperSQL.GetTable(sql);
            return DataTableHelper<RoomType>.ConvertToList(table);
        }
        /// <summary>
        /// 绑定房间类型基本信息
        /// </summary>
        public List<RoomType> Looking()
        {
            string sql = $"SELECT RTID,RTName,RTMin,RTIsDis,RTNum FROM  RoomType WHERE 1=1 AND IsDask=0";
            SqlDataReader r = DbHelperSQL.ExecuteReader(sql);
            List<RoomType> list = new List<RoomType>();

            while (r != null && r.HasRows && r.Read())
            {
                RoomType room = new RoomType();
                room.RTID = Convert.ToInt32(r["RTID"]);
                room.RTName = r["RTName"].ToString();
                room.RTMin = Convert.ToInt32(r["RTMin"]);
                room.RTIsDis = Convert.ToInt32(r["RTIsDis"]) == 0 ? false : true;
                room.RTNum = Convert.ToInt32(r["RTNum"]);
                list.Add(room);
            }
            r.Close();
            return list;
        }
        /// <summary>
        /// 添加房间类型
        /// </summary>
        /// <returns></returns>
        public bool AddRoom(string name, decimal xf, int rs, bool dz)
        {
            string sql = $"INSERT INTO RoomType(RTName, RTMin, RTIsDis, RTNum,IsDask)VALUES(@name,@xf,@dz,@rs,0)";
            List<SqlParameter> sps = new List<SqlParameter>() {
            new SqlParameter("name",name),
            new SqlParameter("xf",xf),
            new SqlParameter("dz",dz),
            new SqlParameter("rs",rs)
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }
        /// <summary>
        /// 修改房间类型
        /// </summary>
        /// <returns></returns>
        public bool UpdateRoom(string name, decimal xf, int rs, bool dz, string id)
        {
            string sql = $"UPDATE RoomType SET RTName=@name,RTMin=@xf,RTNum=@rs,RTIsDis=@dz WHERE 1=1 AND RTID=@id AND IsDask=0";
            List<SqlParameter> sps = new List<SqlParameter>() {
            new SqlParameter("name",name),
            new SqlParameter("xf",xf),
            new SqlParameter("rs",rs),
            new SqlParameter("dz",dz),
            new SqlParameter("id",id),
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }

        /// <summary>
        /// 根据选中的房间信息加载对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RoomType> LookRomm(string id)
        {

            string sql = $"SELECT RTID, RTName, RTMin, RTIsDis, RTNum FROM RoomType WHERE 1=1 AND RTID=@id AND IsDask=0";
            List<SqlParameter> sps = new List<SqlParameter>() {
               new SqlParameter("id", id)
                };
            List<RoomType> list = new List<RoomType>();

            SqlDataReader r = DbHelperSQL.ExecuteReader(sql, sps.ToArray());

            while (r != null && r.HasRows && r.Read())
            {
                RoomType room = new RoomType();
                //room.RTID = Convert.ToInt32(r["RTID"]);
                room.RTName = r["RTName"].ToString();
                room.RTMin = Convert.ToInt32(r["RTMin"]);
                room.RTIsDis = Convert.ToInt32(r["RTIsDis"]) == 0 ? false : true;
                room.RTNum = Convert.ToInt32(r["RTNum"]);
                list.Add(room);
            }
            r.Close();
            return list;
        }
        /// <summary>
        /// 绑定主窗体01
        /// </summary>
        /// <returns></returns>
        public List<RoomType> RoomTypes()
        {
            string sql = $"  SELECT RTID, RTName, RTMin, RTIsDis, RTNum, IsDask FROM RoomType UNION SELECT 0,'所有餐台',0,0,0,0";
            SqlDataReader r = DbHelperSQL.ExecuteReader(sql);
            List<RoomType> list = new List<RoomType>();
            while (r != null && r.HasRows && r.Read())
            {
                RoomType room = new RoomType();
                room.RTName = r["RTName"].ToString();
                room.RTID = Convert.ToInt32(r["RTID"]);
                list.Add(room);
            }
            r.Close();
            return list;
        }



        /// <summary>
        /// 检查添加或修改时是否存在相同的名字
        /// </summary>
        /// <returns></returns>
        public int Repeat(string name)
        {
            string sql = $"SELECT COUNT(0) FROM RoomType WHERE 1=1 AND RTName=@name AND IsDask=0";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
                new SqlParameter("name",name)
            };
            int x = Convert.ToInt32(DbHelperSQL.GetSingle(sql, sps.ToArray()));
            return x;
        }
        /// <summary>
        /// 删除房间类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRoom(string id)
        {
            string sql = $"  UPDATE RoomType SET IsDask='1' WHERE 1=1 AND RTID=@id";
            List<SqlParameter> sps = new List<SqlParameter>() 
            {
            new SqlParameter("id",id)
            };
           bool res= DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }
        /// <summary>
        /// 显示开单餐台基本信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<RoomType> LookKaiDangXX(string id)
        {
            string sql = $"  SELECT A.TableName,B.RTMin,B.RTName FROM Tables A INNER JOIN RoomType B ON B.RTID=A.RTID WHERE 1=1 AND A.IsDask='0'AND B.IsDask='0' AND A.TableID='{id}'";
            SqlDataReader r = DbHelperSQL.ExecuteReader(sql);
            List<RoomType> list = new List<RoomType>();
            while (r != null && r.HasRows && r.Read())
            {
                RoomType room = new RoomType();
                room.RTName = r["RTName"].ToString();
                room.RTMin = Convert.ToInt32(r["RTMin"]);
                room.TableName = r["TableName"].ToString();
                list.Add(room);
            }
            r.Close();
            return list;

        }

        #endregion  MethodEx
    }
}

