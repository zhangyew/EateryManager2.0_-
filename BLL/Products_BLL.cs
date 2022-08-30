using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using EateryManager.Model;
using EateryManager.DAL;

namespace EateryManager.BLL
{
	/// <summary>
	/// Products
	/// </summary>
	public partial class Products_BLL
	{
		private readonly EateryManager.DAL.Products_DAL dal=new EateryManager.DAL.Products_DAL();
		public Products_BLL()
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
		public bool Exists(int ProductID)
		{
			return dal.Exists(ProductID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(EateryManager.Model.Products model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EateryManager.Model.Products model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int ProductID)
		{
			
			return dal.Delete(ProductID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string ProductIDlist )
		{
			return dal.DeleteList((ProductIDlist) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EateryManager.Model.Products GetModel(int ProductID)
		{
			
			return dal.GetModel(ProductID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EateryManager.Model.Products GetModelByCache(int ProductID)
		{
			
			string CacheKey = "ProductsModel-" + ProductID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(ProductID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EateryManager.Model.Products)objModel;
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
		public List<EateryManager.Model.Products> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EateryManager.Model.Products> DataTableToList(DataTable dt)
		{
			List<EateryManager.Model.Products> modelList = new List<EateryManager.Model.Products>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EateryManager.Model.Products model;
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

		private readonly Products_DAL _bll = new Products_DAL();

		/// <summary>
		/// 绑定餐台信息
		/// </summary>
		/// <returns></returns>
		public List<Products> Looking(int id, string mc)
		{
			return _bll.Looking(id,mc);
		}
		/// <summary>
		/// 添加商品
		/// </summary>
		/// <returns></returns>
		public bool ProductAdd(string mc, string py, string jg, int lb)
        {
			return _bll.ProductAdd(mc,py,jg,lb);
        }

		/// <summary>
		/// 修改信息
		/// </summary>
		/// <returns></returns>
		public bool ProductUpdate(string name, string py, string jg, int lb, string id)
        {
			return _bll.ProductUpdate(name,py,jg,lb,id);
        }
		/// <summary>
		/// 显示需要的修改信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<Products> LookProductsUpdate(string id)
        {
			return _bll.LookProductsUpdate(id);
        }
		/// <summary>
		/// 删除信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteProduct(string id)
        {
			return _bll.DeleteProduct(id);
        }

		/// <summary>
		/// 检查添加或修改时是否存在相同的名字
		/// </summary>
		/// <returns></returns>
		public int Repeat(string name)
        {
			return _bll.Repeat(name);
        }

		#endregion  ExtensionMethod
	}
}

