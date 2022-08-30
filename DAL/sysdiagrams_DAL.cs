using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace EateryManager.DAL
{
	/// <summary>
	/// 数据访问类:sysdiagrams
	/// </summary>
	public partial class sysdiagrams_DAL
	{
		public sysdiagrams_DAL()
		{}
		#region  Method

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("principal_id", "sysdiagrams"); 
		}


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string name,int principal_id,int diagram_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sysdiagrams");
			strSql.Append(" where name='"+name+"' and principal_id="+principal_id+" and diagram_id="+diagram_id+" ");
			return DbHelperSQL.Exists(strSql.ToString());
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(EateryManager.Model.sysdiagrams model)
		{
			StringBuilder strSql=new StringBuilder();
			StringBuilder strSql1=new StringBuilder();
			StringBuilder strSql2=new StringBuilder();
			if (model.name != null)
			{
				strSql1.Append("name,");
				strSql2.Append("'"+model.name+"',");
			}
			if (model.principal_id != null)
			{
				strSql1.Append("principal_id,");
				strSql2.Append(""+model.principal_id+",");
			}
			if (model.version != null)
			{
				strSql1.Append("version,");
				strSql2.Append(""+model.version+",");
			}
			if (model.definition != null)
			{
				strSql1.Append("definition,");
				strSql2.Append(""+model.definition+",");
			}
			strSql.Append("insert into sysdiagrams(");
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
		public bool Update(EateryManager.Model.sysdiagrams model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sysdiagrams set ");
			if (model.version != null)
			{
				strSql.Append("version="+model.version+",");
			}
			else
			{
				strSql.Append("version= null ,");
			}
			if (model.definition != null)
			{
				strSql.Append("definition="+model.definition+",");
			}
			else
			{
				strSql.Append("definition= null ,");
			}
			int n = strSql.ToString().LastIndexOf(",");
			strSql.Remove(n, 1);
			strSql.Append(" where diagram_id="+ model.diagram_id+"");
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
		public bool Delete(int diagram_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sysdiagrams ");
			strSql.Append(" where diagram_id="+diagram_id+"" );
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
		/// 删除一条数据
		/// </summary>
		public bool Delete(string name,int principal_id,int diagram_id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sysdiagrams ");
			strSql.Append(" where name=@name and principal_id=@principal_id and diagram_id=@diagram_id ");
			SqlParameter[] parameters = {
					new SqlParameter("@name", SqlDbType.NVarChar,-1),
					new SqlParameter("@principal_id", SqlDbType.Int,4),
					new SqlParameter("@diagram_id", SqlDbType.Int,4)};
			parameters[0].Value = name;
			parameters[1].Value = principal_id;
			parameters[2].Value = diagram_id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string diagram_idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sysdiagrams ");
			strSql.Append(" where diagram_id in ("+diagram_idlist + ")  ");
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
		public EateryManager.Model.sysdiagrams GetModel(int diagram_id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1  ");
			strSql.Append(" name,principal_id,diagram_id,version,definition ");
			strSql.Append(" from sysdiagrams ");
			strSql.Append(" where diagram_id="+diagram_id+"" );
			EateryManager.Model.sysdiagrams model=new EateryManager.Model.sysdiagrams();
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
		public EateryManager.Model.sysdiagrams DataRowToModel(DataRow row)
		{
			EateryManager.Model.sysdiagrams model=new EateryManager.Model.sysdiagrams();
			if (row != null)
			{
				if(row["name"]!=null)
				{
					model.name=row["name"].ToString();
				}
				if(row["principal_id"]!=null && row["principal_id"].ToString()!="")
				{
					model.principal_id=int.Parse(row["principal_id"].ToString());
				}
				if(row["diagram_id"]!=null && row["diagram_id"].ToString()!="")
				{
					model.diagram_id=int.Parse(row["diagram_id"].ToString());
				}
				if(row["version"]!=null && row["version"].ToString()!="")
				{
					model.version=int.Parse(row["version"].ToString());
				}
				if(row["definition"]!=null && row["definition"].ToString()!="")
				{
					model.definition=(byte[])row["definition"];
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
			strSql.Append("select name,principal_id,diagram_id,version,definition ");
			strSql.Append(" FROM sysdiagrams ");
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
			strSql.Append(" name,principal_id,diagram_id,version,definition ");
			strSql.Append(" FROM sysdiagrams ");
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
			strSql.Append("select count(1) FROM sysdiagrams ");
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
				strSql.Append("order by T.diagram_id desc");
			}
			strSql.Append(")AS Row, T.*  from sysdiagrams T ");
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

		#endregion  MethodEx
	}
}

