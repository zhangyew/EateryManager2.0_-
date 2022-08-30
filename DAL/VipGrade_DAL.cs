using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
using EateryManager.Model;
using System.Collections.Generic;

namespace EateryManager.DAL
{
	/// <summary>
	/// 数据访问类:VipGrade
	/// </summary>
	public partial class VipGrade_DAL
	{
		public VipGrade_DAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("VGID", "VipGrade"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int VGID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from VipGrade");
			strSql.Append(" where VGID="+VGID+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(EateryManager.Model.VipGrade model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.VGName != null)
			{
				strSql1.Append("VGName,");
				strSql2.Append("'"+model.VGName+"',");
			}
			if (model.VGDiscount != null)
			{
				strSql1.Append("VGDiscount,");
				strSql2.Append(""+model.VGDiscount+",");
			}
			strSql.Append("insert into VipGrade(");
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
		public bool Update(EateryManager.Model.VipGrade model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update VipGrade set ");
			if (model.VGName != null)
			{
				strSql.Append("VGName='"+model.VGName+"',");
			}
			else
			{
				strSql.Append("VGName= null ,");
			}
			if (model.VGDiscount != null)
			{
				strSql.Append("VGDiscount="+model.VGDiscount+",");
			}
			else
			{
				strSql.Append("VGDiscount= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where VGID="+ model.VGID+"");
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
		public bool Delete(int VGID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VipGrade ");
			strSql.Append(" where VGID="+VGID+"" );
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
		public bool DeleteList(string VGIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from VipGrade ");
			strSql.Append(" where VGID in ("+VGIDlist + ")  ");
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
		public EateryManager.Model.VipGrade GetModel(int VGID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" VGID,VGName,VGDiscount ");
			strSql.Append(" from VipGrade ");
			strSql.Append(" where VGID="+VGID+"" );
			EateryManager.Model.VipGrade model=new EateryManager.Model.VipGrade();
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
		public EateryManager.Model.VipGrade DataRowToModel(DataRow row)
		{
			EateryManager.Model.VipGrade model=new EateryManager.Model.VipGrade();
			if (row != null)
			{
				if(row["VGID"]!=null && row["VGID"].ToString()!="")
				{
					model.VGID=int.Parse(row["VGID"].ToString());
				}
				if(row["VGName"]!=null)
				{
					model.VGName=row["VGName"].ToString();
				}
				if(row["VGDiscount"]!=null && row["VGDiscount"].ToString()!="")
				{
					model.VGDiscount=double.Parse(row["VGDiscount"].ToString());
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
			strSql.Append("select VGID,VGName,VGDiscount ");
			strSql.Append(" FROM VipGrade ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where " + strWhere);
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
			strSql.Append(" VGID,VGName,VGDiscount ");
			strSql.Append(" FROM VipGrade ");
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
			strSql.Append("select count(1) FROM VipGrade ");
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
				strSql.Append("order by T.VGID desc");
			}
			strSql.Append(")AS Row, T.*  from VipGrade T ");
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
		public List<VipGrade> Looking()
		{
			string sql = $"SELECT VGID,VGName,VGDiscount FROM VipGrade WHERE 1=1 AND IsDask='0'";
			SqlDataReader r = DbHelperSQL.ExecuteReader(sql);
			List<VipGrade> admins = new List<VipGrade>();
			while (r != null && r.HasRows && r.Read())
			{
				VipGrade a = new VipGrade();
				a.VGID = Convert.ToInt32(r["VGID"]);
				a.VGName = r["VGName"].ToString();
				a.VGDiscount =double.Parse(r["VGDiscount"].ToString());
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
			string sql = $"UPDATE VipGrade SET IsDask='1' WHERE 1=1 AND VGID=@id";
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

