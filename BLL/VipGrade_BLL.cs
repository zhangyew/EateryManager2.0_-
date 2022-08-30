using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using EateryManager.Model;
using EateryManager.DAL;

namespace EateryManager.BLL
{
	/// <summary>
	/// 1
	/// </summary>
	public partial class VipGrade_BLL
	{
		private readonly EateryManager.DAL.VipGrade_DAL dal=new EateryManager.DAL.VipGrade_DAL();
		public VipGrade_BLL()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int VGID)
		{
			return dal.Exists(VGID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(EateryManager.Model.VipGrade model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EateryManager.Model.VipGrade model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int VGID)
		{
			
			return dal.Delete(VGID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string VGIDlist )
		{
			return dal.DeleteList((VGIDlist) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EateryManager.Model.VipGrade GetModel(int VGID)
		{
			
			return dal.GetModel(VGID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EateryManager.Model.VipGrade GetModelByCache(int VGID)
		{
			
			string CacheKey = "VipGradeModel-" + VGID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(VGID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EateryManager.Model.VipGrade)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EateryManager.Model.VipGrade> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EateryManager.Model.VipGrade> DataTableToList(DataTable dt)
		{
			List<EateryManager.Model.VipGrade> modelList = new List<EateryManager.Model.VipGrade>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EateryManager.Model.VipGrade model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
		//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		/// <summary>
		/// 显示信息
		/// </summary>
		/// <returns></returns>
		public List<VipGrade> Looking()
        {
			return dal.Looking();
        }
		/// <summary>
		/// 删除商品类型
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteType(string id)
        {
			return dal.DeleteType(id);
        }

		#endregion  ExtensionMethod
	}
}

