using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using System.Collections.Generic;
using EateryManager.Model;

namespace EateryManager.DAL
{
    /// <summary>
    /// 数据访问类:ConsumerBill
    /// </summary>
    public partial class ConsumerBill_DAL
    {
        public ConsumerBill_DAL()
        { }
        #region  Method


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string CBID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from ConsumerBill");
            strSql.Append(" where CBID=" + CBID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(EateryManager.Model.ConsumerBill model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.CBID != null)
            {
                strSql1.Append("CBID,");
                strSql2.Append("" + model.CBID + ",");
            }
            if (model.TableID != null)
            {
                strSql1.Append("TableID,");
                strSql2.Append("" + model.TableID + ",");
            }
            if (model.CBNum != null)
            {
                strSql1.Append("CBNum,");
                strSql2.Append("'" + model.CBNum + "',");
            }
            if (model.VipID != null)
            {
                strSql1.Append("VipID,");
                strSql2.Append("" + model.VipID + ",");
            }
            if (model.CBDiscount != null)
            {
                strSql1.Append("CBDiscount,");
                strSql2.Append("'" + model.CBDiscount + "',");
            }
            if (model.CBStartDate != null)
            {
                strSql1.Append("CBStartDate,");
                strSql2.Append("'" + model.CBStartDate + "',");
            }
            if (model.CBEndDate != null)
            {
                strSql1.Append("CBEndDate,");
                strSql2.Append("'" + model.CBEndDate + "',");
            }
            if (model.AdminID != null)
            {
                strSql1.Append("AdminID,");
                strSql2.Append("" + model.AdminID + ",");
            }
            strSql.Append("insert into ConsumerBill(");
            strSql.Append(strSql1.ToString().Remove(strSql1.Length - 1));
            strSql.Append(")");
            strSql.Append(" values (");
            strSql.Append(strSql2.ToString().Remove(strSql2.Length - 1));
            strSql.Append(")");
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
        /// 更新一条数据
        /// </summary>
        public bool Update(EateryManager.Model.ConsumerBill model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update ConsumerBill set ");
            if (model.TableID != null)
            {
                strSql.Append("TableID=" + model.TableID + ",");
            }
            else
            {
                strSql.Append("TableID= null ,");
            }
            if (model.CBNum != null)
            {
                strSql.Append("CBNum='" + model.CBNum + "',");
            }
            else
            {
                strSql.Append("CBNum= null ,");
            }
            if (model.VipID != null)
            {
                strSql.Append("VipID=" + model.VipID + ",");
            }
            else
            {
                strSql.Append("VipID= null ,");
            }
            if (model.CBDiscount != null)
            {
                strSql.Append("CBDiscount='" + model.CBDiscount + "',");
            }
            else
            {
                strSql.Append("CBDiscount= null ,");
            }
            if (model.CBStartDate != null)
            {
                strSql.Append("CBStartDate='" + model.CBStartDate + "',");
            }
            else
            {
                strSql.Append("CBStartDate= null ,");
            }
            if (model.CBEndDate != null)
            {
                strSql.Append("CBEndDate='" + model.CBEndDate + "',");
            }
            else
            {
                strSql.Append("CBEndDate= null ,");
            }
            if (model.AdminID != null)
            {
                strSql.Append("AdminID=" + model.AdminID + ",");
            }
            else
            {
                strSql.Append("AdminID= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where CBID=" + model.CBID + " ");
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
        public bool Delete(string CBID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ConsumerBill ");
            strSql.Append(" where CBID=" + CBID + " ");
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
        public bool DeleteList(string CBIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from ConsumerBill ");
            strSql.Append(" where CBID in (" + CBIDlist + ")  ");
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
        public EateryManager.Model.ConsumerBill GetModel(string CBID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" CBID,TableID,CBNum,VipID,CBDiscount,CBStartDate,CBEndDate,AdminID ");
            strSql.Append(" from ConsumerBill ");
            strSql.Append(" where CBID=" + CBID + " ");
            EateryManager.Model.ConsumerBill model = new EateryManager.Model.ConsumerBill();
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
        public EateryManager.Model.ConsumerBill DataRowToModel(DataRow row)
        {
            EateryManager.Model.ConsumerBill model = new EateryManager.Model.ConsumerBill();
            if (row != null)
            {
                if (row["CBID"] != null)
                {
                    model.CBID = row["CBID"].ToString();
                }
                if (row["TableID"] != null && row["TableID"].ToString() != "")
                {
                    model.TableID = int.Parse(row["TableID"].ToString());
                }
                if (row["CBNum"] != null)
                {
                    model.CBNum = row["CBNum"].ToString();
                }
                if (row["VipID"] != null && row["VipID"].ToString() != "")
                {
                    model.VipID = int.Parse(row["VipID"].ToString());
                }
                if (row["CBDiscount"] != null)
                {
                    model.CBDiscount = row["CBDiscount"].ToString();
                }
                if (row["CBStartDate"] != null && row["CBStartDate"].ToString() != "")
                {
                    model.CBStartDate = DateTime.Parse(row["CBStartDate"].ToString());
                }
                if (row["CBEndDate"] != null && row["CBEndDate"].ToString() != "")
                {
                    model.CBEndDate = DateTime.Parse(row["CBEndDate"].ToString());
                }
                if (row["AdminID"] != null && row["AdminID"].ToString() != "")
                {
                    model.AdminID = int.Parse(row["AdminID"].ToString());
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
            strSql.Append("select CBID,TableID,CBNum,VipID,CBDiscount,CBStartDate,CBEndDate,AdminID ");
            strSql.Append(" FROM ConsumerBill ");
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
            strSql.Append(" CBID,TableID,CBNum,VipID,CBDiscount,CBStartDate,CBEndDate,AdminID ");
            strSql.Append(" FROM ConsumerBill ");
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
            strSql.Append("select count(1) FROM ConsumerBill ");
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
                strSql.Append("order by T.CBID desc");
            }
            strSql.Append(")AS Row, T.*  from ConsumerBill T ");
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
        /// 顾客开单
        /// </summary>
        /// <returns></returns>
        public bool KaiDan(string bh, int id, string rs, string rq)
        {
            string sql = $"INSERT INTO ConsumerBill(CBID, TableID, CBNum,CBStartDate)VALUES('{bh}','{id}','{rs}','{rq}')";
            return DbHelperSQL.ExecuteNonQuery(sql);
        }
        /// <summary>
        /// 查询餐台的最新订单号
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string lookDingDanHao(string id)
        {
            string sql = $"SELECT TOP 1 CBID FROM ConsumerBill WHERE 1=1 AND TableID='{id}' ORDER BY CBStartDate DESC";
            return DbHelperSQL.ExecuteScalar(sql).ToString();
        }

        /// <summary>
        /// 显示单号对应的点单信息
        /// </summary>
        /// <returns></returns>
        public List<ConsumerDetails> LookDianDanCP(string id)
        {
            string sql = $"SELECT B.ProductName,A.CDID,B.ProductPrice,A.CDNum,CDMoney,CDDate,C.PTName FROM ConsumerDetails A INNER JOIN Products B ON A.ProductID=B.ProductID INNER JOIN ProductType C ON C.PTID=B.PTID  WHERE 1=1 AND CBID='{id}' AND A.IsDask=0 AND B.IsDask=0";
            SqlDataReader r = DbHelperSQL.ExecuteReader(sql);
            List<ConsumerDetails> list = new List<ConsumerDetails>();

            while (r != null && r.HasRows && r.Read())
            {
                ConsumerDetails tb = new ConsumerDetails();
                tb.ProductID = r["CDID"].ToString();
                tb.name = r["ProductName"].ToString();
                tb.CDPrice = Convert.ToInt32(r["ProductPrice"]);
                tb.CDNum = Convert.ToInt32(r["CDNum"]);
                tb.CDMoney = Convert.ToInt32(r["CDMoney"]);
                tb.CDDate = (DateTime?)r["CDDate"];
                tb.LeiBie = r["PTName"].ToString();
                list.Add(tb);
            }
            return list;
        }
        /// <summary>
        /// 退菜
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRoom(string id,string name)
        {
            string sql = $"  UPDATE ConsumerDetails SET IsDask='1' WHERE 1=1 AND CBID=@id AND CDID=@name";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
            new SqlParameter("id",id),
            new SqlParameter("name",name)
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }
        /// <summary>
        /// 查询总金额
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public double LookJE(string id)
        {

            string sql = $"SELECT TOP 1 CBID FROM ConsumerBill WHERE 1=1 AND TableID='{id}' ORDER BY CBStartDate DESC";
            string Cid= DbHelperSQL.ExecuteScalar(sql).ToString();
            string sql2 = $"SELECT SUM(CDMoney) FROM ConsumerDetails WHERE 1=1 AND CBID='{Cid}' AND IsDask=0";
            double je= (double)DbHelperSQL.ExecuteScalar(sql2);
            return je;
        }
        /// <summary>
        /// 查询总数量
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int LookDD(string id)
        {
            string sql = $"SELECT TOP 1 CBID FROM ConsumerBill WHERE 1=1 AND TableID='{id}' ORDER BY CBStartDate DESC";
            string Cid = DbHelperSQL.ExecuteScalar(sql).ToString();
            string sql2 = $"SELECT SUM(CDNum) FROM ConsumerDetails WHERE 1=1 AND CBID='{Cid}'AND IsDask=0";
            int je =Convert.ToInt32(DbHelperSQL.ExecuteScalar(sql2));
            return je;
        }
        /// <summary>
        /// 结账
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool JieZang(string id,string vid,string dz,string ct)
        {
            string sql = $"UPDATE ConsumerBill SET VipID='{vid}',CBDiscount='{dz}',CBEndDate=GETDATE(),AdminID=1,IsDask=1 WHERE 1=1 AND CBID='{id}'";
            
            string sql2 = $" UPDATE Tables SET TableState=0 WHERE 1=1 AND TableID='{ct}'";
            DbHelperSQL.ExecuteNonQuery(sql2);

            return DbHelperSQL.ExecuteNonQuery(sql);

        }

        #endregion  MethodEx
    }
}

