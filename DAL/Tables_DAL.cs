using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;
using common;
using EateryManager.Model;

namespace EateryManager.DAL
{
    /// <summary>
    /// 数据访问类:Tables
    /// </summary>
    public partial class Tables_DAL
    {
        public Tables_DAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("TableID", "Tables");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int TableID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Tables");
            strSql.Append(" where TableID=" + TableID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EateryManager.Model.Tables model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.TableName != null)
            {
                strSql1.Append("TableName,");
                strSql2.Append("'" + model.TableName + "',");
            }
            if (model.RTID != null)
            {
                strSql1.Append("RTID,");
                strSql2.Append("" + model.RTID + ",");
            }
            if (model.TableArea != null)
            {
                strSql1.Append("TableArea,");
                strSql2.Append("'" + model.TableArea + "',");
            }
            if (model.TableState != null)
            {
                strSql1.Append("TableState,");
                strSql2.Append("" + model.TableState + ",");
            }
            strSql.Append("insert into Tables(");
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
        public bool Update(EateryManager.Model.Tables model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Tables set ");
            if (model.TableName != null)
            {
                strSql.Append("TableName='" + model.TableName + "',");
            }
            else
            {
                strSql.Append("TableName= null ,");
            }
            if (model.RTID != null)
            {
                strSql.Append("RTID=" + model.RTID + ",");
            }
            else
            {
                strSql.Append("RTID= null ,");
            }
            if (model.TableArea != null)
            {
                strSql.Append("TableArea='" + model.TableArea + "',");
            }
            else
            {
                strSql.Append("TableArea= null ,");
            }
            if (model.TableState != null)
            {
                strSql.Append("TableState=" + model.TableState + ",");
            }
            else
            {
                strSql.Append("TableState= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where TableID=" + model.TableID + "");
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
        public bool Delete(int TableID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tables ");
            strSql.Append(" where TableID=" + TableID + "");
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
        public bool DeleteList(string TableIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Tables ");
            strSql.Append(" where TableID in (" + TableIDlist + ")  ");
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
        public EateryManager.Model.Tables GetModel(int TableID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" TableID,TableName,RTID,TableArea,TableState ");
            strSql.Append(" from Tables ");
            strSql.Append(" where TableID=" + TableID + "");
            EateryManager.Model.Tables model = new EateryManager.Model.Tables();
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
        public EateryManager.Model.Tables DataRowToModel(DataRow row)
        {
            EateryManager.Model.Tables model = new EateryManager.Model.Tables();
            if (row != null)
            {
                if (row["TableID"] != null && row["TableID"].ToString() != "")
                {
                    model.TableID = int.Parse(row["TableID"].ToString());
                }
                if (row["TableName"] != null)
                {
                    model.TableName = row["TableName"].ToString();
                }
                if (row["RTID"] != null && row["RTID"].ToString() != "")
                {
                    model.RTID = (row["RTID"].ToString());
                }
                if (row["TableArea"] != null)
                {
                    model.TableArea = row["TableArea"].ToString();
                }
                if (row["TableState"] != null && row["TableState"].ToString() != "")
                {
                    model.TableState = int.Parse(row["TableState"].ToString());
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
            strSql.Append("select TableID,TableName,RTID,TableArea,TableState ");
            strSql.Append(" FROM Tables ");
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
            strSql.Append(" TableID,TableName,RTID,TableArea,TableState ");
            strSql.Append(" FROM Tables ");
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
            strSql.Append("select count(1) FROM Tables ");
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
                strSql.Append("order by T.TableID desc");
            }
            strSql.Append(")AS Row, T.*  from Tables T ");
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
        /// 绑定餐台信息
        /// </summary>
        /// <returns></returns>
        public List<Tables> Looking(int id)
        {
            string sql = $"SELECT A.TableName,B.RTName,A.TableState,A.TableArea,a.TableID FROM Tables A INNER JOIN RoomType B ON B.RTID=A.RTID WHERE 1=1 AND A.IsDask=0 AND B.IsDask=0";
            List<SqlParameter> sps = new List<SqlParameter>();
            if (id > 0)
            {
                sql += $"AND A.RTID=@id";
                sps.Add(new SqlParameter("id", id));
            }

            SqlDataReader r = DbHelperSQL.ExecuteReader(sql, sps.ToArray());
            List<Tables> list = new List<Tables>();

            while (r != null && r.HasRows && r.Read())
            {
                Tables tb = new Tables();
                tb.TableName = r["TableName"].ToString();
                tb.RTID = r["RTName"].ToString();
                tb.TableState = Convert.ToInt32(r["TableState"]);
                tb.TableArea = r["TableArea"].ToString();
                tb.TableID = Convert.ToInt32(r["TableID"]);
                list.Add(tb);
            }
            r.Close();
            return list;
        }

        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        public IList<RoomType> FanJian()
        {
            string sql = $"  SELECT RTID,RTName FROM RoomType WHERE 1=1 AND IsDask=0";
            DataTable table = DbHelperSQL.GetTable(sql);
            return DataTableHelper<RoomType>.ConvertToList(table);
        }

        /// <summary>
        /// 添加餐桌
        /// </summary>
        /// <returns></returns>
        public bool AddTables(string name, int lx, string qy)
        {
            string sql = $"INSERT INTO Tables(TableName, RTID, TableArea, TableState,IsDask)VALUES(@name,@lx,@qy,'0',0)";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
                new SqlParameter("name",name),
                new SqlParameter("lx",lx),
                new SqlParameter("qy",qy)
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }
        /// <summary>
        /// 修改餐台信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateTable(string name, int lx, string qy, string id)
        {
            string sql = $"UPDATE Tables SET TableName=@name, RTID=@lx, TableArea=@qy WHERE 1=1 AND TableID=@id AND IsDask=0";
            List<SqlParameter> sps = new List<SqlParameter>() {
            new SqlParameter("name",name),
            new SqlParameter("lx",lx),
            new SqlParameter("qy",qy),
            new SqlParameter("id",id)
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }

        /// <summary>
        /// 根据选中的房间信息加载对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Tables> LookRomm(string id)
        {
            string sql = $"SELECT TableName,RTID,TableArea FROM Tables WHERE 1=1 AND TableID=@id AND IsDask=0";
            List<SqlParameter> sps = new List<SqlParameter>() {
            new SqlParameter("id",id)
            };
            List<Tables> list = new List<Tables>();
            SqlDataReader r = DbHelperSQL.ExecuteReader(sql, sps.ToArray());
            while (r != null && r.HasRows && r.Read())
            {
                Tables ta = new Tables();
                ta.TableName = r["TableName"].ToString();
                ta.RTID = r["RTID"].ToString();
                ta.TableArea = r["TableArea"].ToString();
                list.Add(ta);
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
            string sql = $" SELECT COUNT(0) FROM Tables WHERE 1=1 AND TableName=@name AND IsDask=0";
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
            string sql = $"  UPDATE Tables SET IsDask='1' WHERE 1=1 AND RTID=@id";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
            new SqlParameter("id",id)
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }

        /// <summary>
        /// 绑定主窗体01
        /// </summary>
        /// <returns></returns>
        public List<Tables> RoomTypes(int rtid, int TableState)
        {
            string sql = $"SELECT TableID,TableName,TableState FROM Tables WHERE 1=1";
            if (rtid != 0)
            {
                sql += $" AND RTID='{rtid}'";
            }
            if (TableState != -1)
            {
                sql += $" AND TableState='{TableState}'";
            }
            SqlDataReader r = DbHelperSQL.ExecuteReader(sql);
            List<Tables> list = new List<Tables>();
            while (r != null && r.HasRows && r.Read())
            {
                Tables room = new Tables();
                room.TableName = r["TableName"].ToString();
                room.TableID = Convert.ToInt32(r["TableID"]);
                room.TableState = Convert.ToInt32(r["TableState"]);
                list.Add(room);
            }
            return list;
        }
        /// <summary>
        /// 餐台统计
        /// </summary>
        public int Looking()
        {
            string sql = $"SELECT COUNT(TableID) FROM Tables WHERE 1=1 AND IsDask='0'";
            int zs = Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));
            return zs;
        }
        public int JiSuang(int zt)
        {
            string sql = $"  SELECT COUNT(TableState) FROM Tables WHERE 1=1 AND IsDask='0' AND TableState='{zt}'";
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));
        }
        /// <summary>
        /// 获取餐台状态
        /// </summary>
        /// <param name="TalbId"></param>
        /// <returns></returns>
        public int CanTaiZT(string TalbId)
        {
            string sql = $"  SELECT TableState FROM Tables WHERE 1=1 AND TableID='{TalbId}'";
            return Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql));
        }
        /// <summary>
        /// 修改餐台状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool XiuGaiCT(string id)
        {
            string sql2 = $" UPDATE Tables SET TableState='1'WHERE 1=1 AND TableID='{id}'";
            return DbHelperSQL.ExecuteNonQuery(sql2);
        }
        /// <summary>
        /// 查询餐台名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ChaXunCanTai(string id)
        {
            string sql = $"SELECT TableName FROM Tables WHERE 1=1 AND TableID='{id}' AND IsDask=0";
            string bh = DbHelperSQL.ExecuteScalar(sql).ToString();
            return bh;
        }

        #endregion  MethodEx
    }
}

