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
	/// 数据访问类:ProductType
	/// </summary>
	public partial class ProductType_DAL
	{
		public ProductType_DAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("PTID", "ProductType"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int PTID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ProductType");
			strSql.Append(" where PTID="+PTID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(EateryManager.Model.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.PTName != null)
			{
				strSql1.Append("PTName,");
				strSql2.Append("'"+model.PTName+"',");
			}
			strSql.Append("insert into ProductType(");
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
		public bool Update(EateryManager.Model.ProductType model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ProductType set ");
			if (model.PTName != null)
			{
				strSql.Append("PTName='"+model.PTName+"',");
			}
			else
			{
				strSql.Append("PTName= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where PTID="+ model.PTID+"");
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public bool Delete(int PTID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductType ");
			strSql.Append(" where PTID="+PTID+"" );
			int rowsAffected=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rowsAffected > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string PTIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ProductType ");
			strSql.Append(" where PTID in ("+PTIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public EateryManager.Model.ProductType GetModel(int PTID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" PTID,PTName ");
			strSql.Append(" from ProductType ");
			strSql.Append(" where PTID="+PTID+"" );
			EateryManager.Model.ProductType model=new EateryManager.Model.ProductType();
			DataSet ds=DbHelperSQL.Query(strSql.ToString());
			if(ds.Tables[0].Rows.Count>0)
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
		public EateryManager.Model.ProductType DataRowToModel(DataRow row)
		{
			EateryManager.Model.ProductType model=new EateryManager.Model.ProductType();
			if (row != null)
			{
				if(row["PTID"]!=null && row["PTID"].ToString()!="")
				{
					model.PTID=int.Parse(row["PTID"].ToString());
				}
				if(row["PTName"]!=null)
				{
					model.PTName=row["PTName"].ToString();
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select PTID,PTName ");
			strSql.Append(" FROM ProductType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" PTID,PTName ");
			strSql.Append(" FROM ProductType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM ProductType ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
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
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.PTID desc");
			}
			strSql.Append(")AS Row, T.*  from ProductType T ");
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
		public IList<ProductType> LeiBie()
		{
			string sql = $" SELECT PTID,PTName FROM ProductType WHERE 1=1  AND IsDask=0 UNION SELECT 0,'全部类别'";
			DataTable table = DbHelperSQL.GetTable(sql);
			return DataTableHelper<ProductType>.ConvertToList(table);
		}


		/// <summary>
		/// 绑定商品类型基本信息
		/// </summary>
		public List<ProductType> Looking()
		{
			string sql = $" SELECT PTID,PTName FROM  ProductType WHERE 1=1 AND IsDask=0";
			SqlDataReader r = DbHelperSQL.ExecuteReader(sql);
			List<ProductType> list = new List<ProductType>();

			while (r != null && r.HasRows && r.Read())
			{
				ProductType room = new ProductType();
				room.PTID = Convert.ToInt32(r["PTID"]);
				room.PTName =r["PTName"].ToString();
				list.Add(room);
			}
			r.Close();
			return list;
		}

		/// <summary>
		/// 添加商品类型
		/// </summary>
		/// <returns></returns>
		public bool TypeAdd(string name)
        {
			string sql = $"INSERT INTO ProductType(PTName,IsDask)VALUES(@name,0)";
			List<SqlParameter> sps = new List<SqlParameter>()
			{
				new SqlParameter("name",name)
			};
			bool res= DbHelperSQL.ExecuteNonQuery(sql,sps.ToArray());
			return res;
        }
		/// <summary>
		/// 检查添加或修改时是否存在相同的名字
		/// </summary>
		/// <returns></returns>
		public int Repeat(string name)
		{
			string sql = $"SELECT COUNT(0) FROM ProductType WHERE 1=1 AND PTName=@name AND IsDask=0";
			List<SqlParameter> sps = new List<SqlParameter>()
			{
				new SqlParameter("name",name)
			};
			int x = Convert.ToInt32(DbHelperSQL.GetSingle(sql, sps.ToArray()));
			return x;
		}
		/// <summary>
		/// 根据选中的类型信息加载对应的信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<ProductType> LookType(string id)
		{
			string sql = $"SELECT PTName FROM ProductType WHERE 1=1 AND PTID=@id AND IsDask=0";
			List<SqlParameter> sps = new List<SqlParameter>() {
			new SqlParameter("id",id)
			};
			List<ProductType> list = new List<ProductType>();
			SqlDataReader r = DbHelperSQL.ExecuteReader(sql, sps.ToArray());
			while (r != null && r.HasRows && r.Read())
			{
				ProductType ta = new ProductType();
				ta.PTName = r["PTName"].ToString();
				list.Add(ta);
			}
			r.Close();
			return list;
		}

		/// <summary>
		/// 修改商品类别信息
		/// </summary>
		/// <returns></returns>
		public bool UpdateType(string name,string id)
        {
			string sql = $"UPDATE ProductType SET PTName=@name WHERE 1=1 AND PTID=@id AND IsDask=0";
			List<SqlParameter> sps = new List<SqlParameter>()
			{
				new SqlParameter("name",name),
				new SqlParameter("id",id)
			};
			bool res= DbHelperSQL.ExecuteNonQuery(sql, sps.ToArray());
			return res;
        }

		/// <summary>
		/// 删除商品类型
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteType(string id)
		{
			string sql = $"  UPDATE ProductType SET IsDask='1' WHERE 1=1 AND PTID=@id";
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

