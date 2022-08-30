using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using EateryManager.Model;
using EateryManager.DAL;

namespace EateryManager.BLL
{
	/// <summary>
	/// ProductType
	/// </summary>
	public partial class ProductType_BLL
	{
		private readonly EateryManager.DAL.ProductType_DAL dal=new EateryManager.DAL.ProductType_DAL();
		public ProductType_BLL()
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
		public bool Exists(int PTID)
		{
			return dal.Exists(PTID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(EateryManager.Model.ProductType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EateryManager.Model.ProductType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int PTID)
		{
			
			return dal.Delete(PTID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string PTIDlist )
		{
			return dal.DeleteList((PTIDlist) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EateryManager.Model.ProductType GetModel(int PTID)
		{
			
			return dal.GetModel(PTID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EateryManager.Model.ProductType GetModelByCache(int PTID)
		{
			
			string CacheKey = "ProductTypeModel-" + PTID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(PTID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EateryManager.Model.ProductType)objModel;
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
		public List<EateryManager.Model.ProductType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EateryManager.Model.ProductType> DataTableToList(DataTable dt)
		{
			List<EateryManager.Model.ProductType> modelList = new List<EateryManager.Model.ProductType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EateryManager.Model.ProductType model;
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

		private readonly ProductType_DAL _dal = new ProductType_DAL();
		/// <summary>
		///绑定下拉框
		/// </summary>
		public IList<ProductType> Quanxian()
		{
			return _dal.LeiBie();
		}
		/// <summary>
		/// 绑定类型基本信息
		/// </summary>
		/// <returns></returns>
		public List<ProductType> Looking()
		{
			return _dal.Looking();
		}
		/// <summary>
		/// 添加商品类型
		/// </summary>
		/// <returns></returns>
		public bool TypeAdd(string name)
        {
			return _dal.TypeAdd(name);
        }
		/// <summary>
		/// 检查添加或修改时是否存在相同的名字
		/// </summary>
		/// <returns></returns>
		public int Repeat(string name)
        {
			return _dal.Repeat(name);
        }

		/// <summary>
		/// 根据选中的类型信息加载对应的信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<ProductType> LookType(string id)
        {
			return _dal.LookType(id);
        }
		/// <summary>
		/// 修改商品类别信息
		/// </summary>
		/// <returns></returns>
		public bool UpdateType(string name, string id)
        {
			return _dal.UpdateType(name, id);
        }

		/// <summary>
		/// 删除商品类型
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteType(string id)
        {
			return _dal.DeleteType(id);
        }

		#endregion  ExtensionMethod
	}
}

