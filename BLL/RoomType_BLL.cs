using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using EateryManager.Model;
using EateryManager.DAL;

namespace EateryManager.BLL
{
	/// <summary>
	/// RoomType
	/// </summary>
	public partial class RoomType_BLL
	{
		private readonly EateryManager.DAL.RoomType_DAL dal=new EateryManager.DAL.RoomType_DAL();
		public RoomType_BLL()
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
		public bool Exists(int RTID)
		{
			return dal.Exists(RTID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(EateryManager.Model.RoomType model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EateryManager.Model.RoomType model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int RTID)
		{
			
			return dal.Delete(RTID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string RTIDlist )
		{
			return dal.DeleteList((RTIDlist) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EateryManager.Model.RoomType GetModel(int RTID)
		{
			
			return dal.GetModel(RTID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EateryManager.Model.RoomType GetModelByCache(int RTID)
		{
			
			string CacheKey = "RoomTypeModel-" + RTID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(RTID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EateryManager.Model.RoomType)objModel;
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
		public List<EateryManager.Model.RoomType> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EateryManager.Model.RoomType> DataTableToList(DataTable dt)
		{
			List<EateryManager.Model.RoomType> modelList = new List<EateryManager.Model.RoomType>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EateryManager.Model.RoomType model;
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
		private readonly RoomType_DAL _dal = new RoomType_DAL();
		/// <summary>
		///绑定下拉框
		/// </summary>
		public IList<RoomType> Quanxian()
		{
			return _dal.Quanxian();
		}
		/// <summary>
		/// 绑定房间类型基本信息
		/// </summary>
		/// <returns></returns>
		public List<RoomType> Looking()
        {
			return _dal.Looking();
        }

		/// <summary>
		/// 添加房间类型
		/// </summary>
		/// <returns></returns>
		public bool AddRoom(string name, decimal xf, int rs, bool dz)
        {
			return _dal.AddRoom(name,xf,rs,dz);
        }
		/// <summary>
		/// 修改房间类型
		/// </summary>
		/// <returns></returns>
		public bool UpdateRoom(string name, decimal xf, int rs, bool dz, string id)
        {
			return _dal.UpdateRoom(name, xf, rs, dz,id);
        }

		/// <summary>
		/// 根据选中的房间信息加载对应的信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<RoomType> LookRomm(string id)
        {
			return _dal.LookRomm(id);
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
		/// 删除房间类型
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteRoom(string id)
        {
			return _dal.DeleteRoom(id);
        }

		/// <summary>
		/// 绑定主窗体
		/// </summary>
		/// <returns></returns>
		public List<RoomType> RoomTypes()
        {
			return _dal.RoomTypes();
        }
		/// <summary>
		/// 显示开单餐台基本信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public List<RoomType> LookKaiDangXX(string id)
        {
			return _dal.LookKaiDangXX(id);
        }
		#endregion  ExtensionMethod
	}
}

