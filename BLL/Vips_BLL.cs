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
	public partial class Vips_BLL
	{
		private readonly EateryManager.DAL.Vips_DAL dal=new EateryManager.DAL.Vips_DAL();
		public Vips_BLL()
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
		public bool Exists(int VipID)
		{
			return dal.Exists(VipID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(EateryManager.Model.Vips model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EateryManager.Model.Vips model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int VipID)
		{
			
			return dal.Delete(VipID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string VipIDlist )
		{
			return dal.DeleteList((VipIDlist) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EateryManager.Model.Vips GetModel(int VipID)
		{
			
			return dal.GetModel(VipID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EateryManager.Model.Vips GetModelByCache(int VipID)
		{
			
			string CacheKey = "VipsModel-" + VipID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(VipID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EateryManager.Model.Vips)objModel;
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
		public List<EateryManager.Model.Vips> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EateryManager.Model.Vips> DataTableToList(DataTable dt)
		{
			List<EateryManager.Model.Vips> modelList = new List<EateryManager.Model.Vips>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EateryManager.Model.Vips model;
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

		Vips_DAL _dal = new Vips_DAL();

		/// <summary>
		/// 显示信息
		/// </summary>
		/// <returns></returns>
		public List<Vips> Looking(string cx)
        {
			return _dal.Looking(cx);
        }
		/// <summary>
		///绑定界面下拉框
		/// </summary>
		public IList<VipGrade> Quanxian()
        {
			return _dal.Quanxian();
        }
		/// <summary>
		/// 查询最大编号
		/// </summary>
		/// <returns></returns>
		public int LookMIX()
        {
			return _dal.LookMIX();
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

