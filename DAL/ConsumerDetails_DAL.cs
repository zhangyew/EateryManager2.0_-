using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace EateryManager.DAL
{
	/// <summary>
	/// 数据访问类:ConsumerDetails
	/// </summary>
	public partial class ConsumerDetails_DAL
	{
		public ConsumerDetails_DAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("CDID", "ConsumerDetails"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int CDID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ConsumerDetails");
			strSql.Append(" where CDID="+CDID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(EateryManager.Model.ConsumerDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.CBID != null)
			{
				strSql1.Append("CBID,");
				strSql2.Append(""+model.CBID+",");
			}
			if (model.ProductID != null)
			{
				strSql1.Append("ProductID,");
				strSql2.Append(""+model.ProductID+",");
			}
			if (model.CDPrice != null)
			{
				strSql1.Append("CDPrice,");
				strSql2.Append(""+model.CDPrice+",");
			}
			if (model.CDNum != null)
			{
				strSql1.Append("CDNum,");
				strSql2.Append(""+model.CDNum+",");
			}
			if (model.CDSale != null)
			{
				strSql1.Append("CDSale,");
				strSql2.Append(""+model.CDSale+",");
			}
			if (model.CDMoney != null)
			{
				strSql1.Append("CDMoney,");
				strSql2.Append(""+model.CDMoney+",");
			}
			if (model.CDType != null)
			{
				strSql1.Append("CDType,");
				strSql2.Append(""+model.CDType+",");
			}
			if (model.CDDate != null)
			{
				strSql1.Append("CDDate,");
				strSql2.Append("'"+model.CDDate+"',");
			}
			strSql.Append("insert into ConsumerDetails(");
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
		public bool Update(EateryManager.Model.ConsumerDetails model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ConsumerDetails set ");
			if (model.CBID != null)
			{
				strSql.Append("CBID="+model.CBID+",");
			}
			else
			{
				strSql.Append("CBID= null ,");
			}
			if (model.ProductID != null)
			{
				strSql.Append("ProductID="+model.ProductID+",");
			}
			else
			{
				strSql.Append("ProductID= null ,");
			}
			if (model.CDPrice != null)
			{
				strSql.Append("CDPrice="+model.CDPrice+",");
			}
			else
			{
				strSql.Append("CDPrice= null ,");
			}
			if (model.CDNum != null)
			{
				strSql.Append("CDNum="+model.CDNum+",");
			}
			else
			{
				strSql.Append("CDNum= null ,");
			}
			if (model.CDSale != null)
			{
				strSql.Append("CDSale="+model.CDSale+",");
			}
			else
			{
				strSql.Append("CDSale= null ,");
			}
			if (model.CDMoney != null)
			{
				strSql.Append("CDMoney="+model.CDMoney+",");
			}
			else
			{
				strSql.Append("CDMoney= null ,");
			}
			if (model.CDType != null)
			{
				strSql.Append("CDType="+model.CDType+",");
			}
			else
			{
				strSql.Append("CDType= null ,");
			}
			if (model.CDDate != null)
			{
				strSql.Append("CDDate='"+model.CDDate+"',");
			}
			else
			{
				strSql.Append("CDDate= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where CDID="+ model.CDID+"");
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
		public bool Delete(int CDID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ConsumerDetails ");
			strSql.Append(" where CDID="+CDID+"" );
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
		public bool DeleteList(string CDIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ConsumerDetails ");
			strSql.Append(" where CDID in ("+CDIDlist + ")  ");
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
		public EateryManager.Model.ConsumerDetails GetModel(int CDID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" CDID,CBID,ProductID,CDPrice,CDNum,CDSale,CDMoney,CDType,CDDate ");
			strSql.Append(" from ConsumerDetails ");
			strSql.Append(" where CDID="+CDID+"" );
			EateryManager.Model.ConsumerDetails model=new EateryManager.Model.ConsumerDetails();
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
		public EateryManager.Model.ConsumerDetails DataRowToModel(DataRow row)
		{
			EateryManager.Model.ConsumerDetails model=new EateryManager.Model.ConsumerDetails();
			if (row != null)
			{
				if(row["CDID"]!=null && row["CDID"].ToString()!="")
				{
					model.CDID=int.Parse(row["CDID"].ToString());
				}
				if(row["CBID"]!=null)
				{
					model.CBID=row["CBID"].ToString();
				}
				if(row["ProductID"]!=null && row["ProductID"].ToString()!="")
				{
					model.ProductID=(row["ProductID"].ToString());
				}
				if(row["CDPrice"]!=null && row["CDPrice"].ToString()!="")
				{
					model.CDPrice=decimal.Parse(row["CDPrice"].ToString());
				}
				if(row["CDNum"]!=null && row["CDNum"].ToString()!="")
				{
					model.CDNum=int.Parse(row["CDNum"].ToString());
				}
				if(row["CDSale"]!=null && row["CDSale"].ToString()!="")
				{
					model.CDSale=decimal.Parse(row["CDSale"].ToString());
				}
				if(row["CDMoney"]!=null && row["CDMoney"].ToString()!="")
				{
					model.CDMoney=decimal.Parse(row["CDMoney"].ToString());
				}
				if(row["CDType"]!=null && row["CDType"].ToString()!="")
				{
					model.CDType=int.Parse(row["CDType"].ToString());
				}
				if(row["CDDate"]!=null && row["CDDate"].ToString()!="")
				{
					model.CDDate=DateTime.Parse(row["CDDate"].ToString());
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
			strSql.Append("select CDID,CBID,ProductID,CDPrice,CDNum,CDSale,CDMoney,CDType,CDDate ");
			strSql.Append(" FROM ConsumerDetails ");
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
			strSql.Append(" CDID,CBID,ProductID,CDPrice,CDNum,CDSale,CDMoney,CDType,CDDate ");
			strSql.Append(" FROM ConsumerDetails ");
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
			strSql.Append("select count(1) FROM ConsumerDetails ");
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
				strSql.Append("order by T.CDID desc");
			}
			strSql.Append(")AS Row, T.*  from ConsumerDetails T ");
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
		/// 增加消费-点菜
		/// </summary>
		/// <returns></returns>
		public bool ZengJiaXioaFei(string bh,string Gid,int jgg,int sl,int zjg)
        {
			string sql = $"INSERT INTO ConsumerDetails(CBID, ProductID, CDPrice, CDNum,CDMoney)VALUES('{bh}','{Gid}','{jgg}','{sl}','{zjg}')";
			return  DbHelperSQL.ExecuteNonQuery(sql);
        }
		


		#endregion  MethodEx
	}
}

