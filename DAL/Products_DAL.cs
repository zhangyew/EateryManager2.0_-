using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using EateryManager.Model;
using System.Collections.Generic;
using common;

namespace EateryManager.DAL
{
    /// <summary>
    /// 数据访问类:Products
    /// </summary>
    public partial class Products_DAL
    {
        public Products_DAL()
        { }
        #region  Method

        /// <summary>
        /// 得到最大ID
        /// </summary>
        public int GetMaxId()
        {
            return DbHelperSQL.GetMaxID("ProductID", "Products");
        }


        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(int ProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from Products");
            strSql.Append(" where ProductID=" + ProductID + " ");
            return DbHelperSQL.Exists(strSql.ToString());
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EateryManager.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            StringBuilder strSql1 = new StringBuilder();
            StringBuilder strSql2 = new StringBuilder();
            if (model.ProductName != null)
            {
                strSql1.Append("ProductName,");
                strSql2.Append("'" + model.ProductName + "',");
            }
            if (model.PTID != null)
            {
                strSql1.Append("PTID,");
                strSql2.Append("" + model.PTID + ",");
            }
            if (model.ProductJP != null)
            {
                strSql1.Append("ProductJP,");
                strSql2.Append("'" + model.ProductJP + "',");
            }
            if (model.ProductPrice != null)
            {
                strSql1.Append("ProductPrice,");
                strSql2.Append("" + model.ProductPrice + ",");
            }
            strSql.Append("insert into Products(");
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
        public bool Update(EateryManager.Model.Products model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update Products set ");
            if (model.ProductName != null)
            {
                strSql.Append("ProductName='" + model.ProductName + "',");
            }
            else
            {
                strSql.Append("ProductName= null ,");
            }
            if (model.PTID != null)
            {
                strSql.Append("PTID=" + model.PTID + ",");
            }
            else
            {
                strSql.Append("PTID= null ,");
            }
            if (model.ProductJP != null)
            {
                strSql.Append("ProductJP='" + model.ProductJP + "',");
            }
            else
            {
                strSql.Append("ProductJP= null ,");
            }
            if (model.ProductPrice != null)
            {
                strSql.Append("ProductPrice=" + model.ProductPrice + ",");
            }
            else
            {
                strSql.Append("ProductPrice= null ,");
            }
            int n = strSql.ToString().LastIndexOf(",");
            strSql.Remove(n, 1);
            strSql.Append(" where ProductID=" + model.ProductID + "");
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
        public bool Delete(int ProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Products ");
            strSql.Append(" where ProductID=" + ProductID + "");
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
        public bool DeleteList(string ProductIDlist)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from Products ");
            strSql.Append(" where ProductID in (" + ProductIDlist + ")  ");
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
        public EateryManager.Model.Products GetModel(int ProductID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1  ");
            strSql.Append(" ProductID,ProductName,PTID,ProductJP,ProductPrice ");
            strSql.Append(" from Products ");
            strSql.Append(" where ProductID=" + ProductID + "");
            EateryManager.Model.Products model = new EateryManager.Model.Products();
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
        public EateryManager.Model.Products DataRowToModel(DataRow row)
        {
            EateryManager.Model.Products model = new EateryManager.Model.Products();
            if (row != null)
            {
                if (row["ProductID"] != null && row["ProductID"].ToString() != "")
                {
                    model.ProductID = int.Parse(row["ProductID"].ToString());
                }
                if (row["ProductName"] != null)
                {
                    model.ProductName = row["ProductName"].ToString();
                }
                if (row["PTID"] != null && row["PTID"].ToString() != "")
                {
                    model.PTID = (row["PTID"].ToString());
                }
                if (row["ProductJP"] != null)
                {
                    model.ProductJP = row["ProductJP"].ToString();
                }
                if (row["ProductPrice"] != null && row["ProductPrice"].ToString() != "")
                {
                    model.ProductPrice = decimal.Parse(row["ProductPrice"].ToString());
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
            strSql.Append("select ProductID,ProductName,PTID,ProductJP,ProductPrice ");
            strSql.Append(" FROM Products ");
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
            strSql.Append(" ProductID,ProductName,PTID,ProductJP,ProductPrice ");
            strSql.Append(" FROM Products ");
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
            strSql.Append("select count(1) FROM Products ");
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
                strSql.Append("order by T.ProductID desc");
            }
            strSql.Append(")AS Row, T.*  from Products T ");
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
        public List<Products> Looking(int id, string mc)
        {
            string sql = $"SELECT A.ProductID,A.ProductName,A.ProductPrice,B.PTName FROM Products A INNER JOIN ProductType B ON B.PTID=A.PTID WHERE 1=1 AND A.IsDask=0 AND B.IsDask=0";
            List<SqlParameter> sps = new List<SqlParameter>();
            if (id > 0)
            {
                sql += $"AND A.PTID=@id";
                sps.Add(new SqlParameter("id", id));
            }
            if (mc != null)
            {
                sql += $" AND A.ProductName LIKE '%{mc}%' OR A.ProductJP LIKE '%{mc}%'";
            }

            SqlDataReader r = DbHelperSQL.ExecuteReader(sql, sps.ToArray());
            List<Products> list = new List<Products>();

            while (r != null && r.HasRows && r.Read())
            {
                Products tb = new Products();
                tb.ProductID = Convert.ToInt32(r["ProductID"]);
                tb.ProductName = r["ProductName"].ToString();
                tb.ProductPrice = Convert.ToInt32(r["ProductPrice"]);
                tb.PTID = r["PTName"].ToString();
                list.Add(tb);
            }
            r.Close();
            return list;
        }

        /// <summary>
        /// 添加商品
        /// </summary>
        /// <returns></returns>
        public bool ProductAdd(string mc, string py, string jg, int lb)
        {
            string sql = $"INSERT INTO Products( ProductName, PTID, ProductJP, ProductPrice, IsDask)VALUES(@name,@lb,@py,@jg,0)";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
                new SqlParameter("name",mc),
                new SqlParameter("py",py),
                new SqlParameter("jg",jg),
                new SqlParameter("lb",lb)
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }

        /// <summary>
        /// 修改信息
        /// </summary>
        /// <returns></returns>
        public bool ProductUpdate(string name, string py, string jg, int lb, string id)
        {
            string sql = $"UPDATE Products SET ProductName=@name,PTID=@lb,ProductJP=@py,ProductPrice=@jg WHERE 1=1 AND ProductID=@id AND IsDask='0'";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
                new SqlParameter("name",name),
                new SqlParameter("py",py),
                new SqlParameter("jg",jg),
                new SqlParameter("lb",lb),
                new SqlParameter("id",id)
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }

        /// <summary>
        /// 显示需要的修改信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Products> LookProductsUpdate(string id)
        {
            string sql = $"SELECT ProductName,ProductPrice,PTID FROM Products WHERE 1=1 AND ProductID=@id AND IsDask='0'";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
                new SqlParameter("id",id)
            };
            SqlDataReader r = DbHelperSQL.ExecuteReader(sql, sps.ToArray());
            List<Products> list = new List<Products>();
            while (r != null && r.HasRows && r.Read())
            {
                Products p = new Products();
                p.ProductName = r["ProductName"].ToString();
                p.ProductPrice = Convert.ToInt32(r["ProductPrice"]);
                p.PTID = r["PTID"].ToString();
                list.Add(p);
            }
            return list;
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteProduct(string id)
        {
            string sql = $"UPDATE Products SET IsDask='1' WHERE 1=1 AND ProductID=@id";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
                new SqlParameter("id",id)
            };
            bool res = DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
            return res;
        }

        /// <summary>
        /// 检查添加或修改时是否存在相同的名字
        /// </summary>
        /// <returns></returns>
        public int Repeat(string name)
        {
            string sql = $" SELECT COUNT(0) FROM Products WHERE 1=1 AND ProductName=@name AND IsDask=0";
            List<SqlParameter> sps = new List<SqlParameter>()
            {
                new SqlParameter("name",name)
            };
            int x = Convert.ToInt32(DbHelperSQL.GetSingle(sql, sps.ToArray()));
            return x;
        }

        #endregion  MethodEx
    }
}

