using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using EateryManager.Model;
using EateryManager.DAL;

namespace EateryManager.BLL
{
	/// <summary>
	/// ConsumerBill
	/// </summary>
	public partial class ConsumerBill_BLL
	{
		private readonly EateryManager.DAL.ConsumerBill_DAL dal=new EateryManager.DAL.ConsumerBill_DAL();
		public ConsumerBill_BLL()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string CBID)
		{
			return dal.Exists(CBID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(EateryManager.Model.ConsumerBill model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(EateryManager.Model.ConsumerBill model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string CBID)
		{
			
			return dal.Delete(CBID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string CBIDlist )
		{
			return dal.DeleteList((CBIDlist) );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public EateryManager.Model.ConsumerBill GetModel(string CBID)
		{
			
			return dal.GetModel(CBID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public EateryManager.Model.ConsumerBill GetModelByCache(string CBID)
		{
			
			string CacheKey = "ConsumerBillModel-" + CBID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(CBID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (EateryManager.Model.ConsumerBill)objModel;
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
		public List<EateryManager.Model.ConsumerBill> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<EateryManager.Model.ConsumerBill> DataTableToList(DataTable dt)
		{
			List<EateryManager.Model.ConsumerBill> modelList = new List<EateryManager.Model.ConsumerBill>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				EateryManager.Model.ConsumerBill model;
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
		ConsumerBill_DAL _dal = new ConsumerBill_DAL();

		/// <summary>
		/// 顾客开单
		/// </summary>
		/// <returns></returns>
		public bool KaiDan(string bh, int id, string rs, string rq)
        {
			return _dal.KaiDan(bh, id, rs, rq);
        }
		/// <summary>
		/// 查询餐台的最新订单号
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public string lookDingDanHao(string id)
        {
			return _dal.lookDingDanHao(id);
        }
		/// <summary>
		/// 显示单号对应的点单信息
		/// </summary>
		/// <returns></returns>
		public List<ConsumerDetails> LookDianDanCP(string id)
        {
			return _dal.LookDianDanCP(id);
        }
		/// <summary>
		/// 退菜
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool DeleteRoom(string id,string name)
		{
			return _dal.DeleteRoom(id,name);
		}
		/// <summary>
		/// 查询总金额
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public double LookJE(string id)
        {
			return _dal.LookJE(id);
        }
		/// <summary>
		/// 查询总数量
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public int LookDD(string id)
        {
			return _dal.LookDD(id);
        }
		/// <summary>
		/// 结账
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public bool JieZang(string id, string vid, string dz,string ct)
        {
			return _dal.JieZang(id,vid,dz,ct);
        }
		#endregion  ExtensionMethod
	}
}

