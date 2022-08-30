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
    public partial class Tables_BLL
    {
        private readonly EateryManager.DAL.Tables_DAL dal = new EateryManager.DAL.Tables_DAL();
        public Tables_BLL()
        { }
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
        public bool Exists(int TableID)
        {
            return dal.Exists(TableID);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(EateryManager.Model.Tables model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(EateryManager.Model.Tables model)
        {
            return dal.Update(model);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(int TableID)
        {

            return dal.Delete(TableID);
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool DeleteList(string TableIDlist)
        {
            return dal.DeleteList((TableIDlist));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public EateryManager.Model.Tables GetModel(int TableID)
        {

            return dal.GetModel(TableID);
        }

        /// <summary>
        /// 得到一个对象实体，从缓存中
        /// </summary>
        public EateryManager.Model.Tables GetModelByCache(int TableID)
        {

            string CacheKey = "TablesModel-" + TableID;
            object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = dal.GetModel(TableID);
                    if (objModel != null)
                    {
                        int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
                        Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
                    }
                }
                catch { }
            }
            return (EateryManager.Model.Tables)objModel;
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
        public DataSet GetList(int Top, string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EateryManager.Model.Tables> GetModelList(string strWhere)
        {
            DataSet ds = dal.GetList(strWhere);
            return DataTableToList(ds.Tables[0]);
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<EateryManager.Model.Tables> DataTableToList(DataTable dt)
        {
            List<EateryManager.Model.Tables> modelList = new List<EateryManager.Model.Tables>();
            int rowsCount = dt.Rows.Count;
            if (rowsCount > 0)
            {
                EateryManager.Model.Tables model;
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
            return dal.GetListByPage(strWhere, orderby, startIndex, endIndex);
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

        private readonly Tables_DAL _bll = new Tables_DAL();
        /// <summary>
        /// 绑定餐台信息
        /// </summary>
        /// <returns></returns>
        public List<Tables> Looking(int id)
        {
            return _bll.Looking(id);
        }

        /// <summary>
        /// 绑定下拉框
        /// </summary>
        /// <returns></returns>
        public IList<RoomType> FanJian()
        {
            return _bll.FanJian();
        }
        /// <summary>
        /// 添加餐桌
        /// </summary>
        /// <returns></returns>
        public bool AddTables(string name, int lx, string qy)
        {
            return _bll.AddTables(name, lx, qy);
        }
        /// <summary>
        /// 修改餐台信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool UpdateTable(string name, int lx, string qy, string id)
        {
            return _bll.UpdateTable(name, lx, qy, id);
        }

        /// <summary>
        /// 根据选中的房间信息加载对应的信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Tables> LookRomm(string id)
        {
            return _bll.LookRomm(id);
        }

        /// <summary>
        /// 检查添加或修改时是否存在相同的名字
        /// </summary>
        /// <returns></returns>
        public int Repeat(string name)
        {
            return _bll.Repeat(name);
        }

        /// <summary>
        /// 删除房间类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool DeleteRoom(string id)
        {
            return _bll.DeleteRoom(id);
        }
        /// <summary>
        /// 绑定主窗体01
        /// </summary>
        /// <returns></returns>
        public List<Tables> RoomTypes(int rtid, int TableState)
        {
            return _bll.RoomTypes(rtid, TableState);
        }
        /// <summary>
        /// 餐台统计
        /// </summary>
        public int Looking()
        {
            return _bll.Looking();
        }
        public int JiSuang(int zt)
        {
            return _bll.JiSuang(zt);
        }
        /// <summary>
        /// 获取餐台状态
        /// </summary>
        /// <param name="TalbId"></param>
        /// <returns></returns>
        public int CanTaiZT(string TalbId)
        {
            return _bll.CanTaiZT(TalbId);
        }
        /// <summary>
        /// 修改餐台状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool XiuGaiCT(string id)
        {
            return _bll.XiuGaiCT(id);
        }

        /// <summary>
        /// 查询餐台名称
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string ChaXunCanTai(string id)
        {
            return _bll.ChaXunCanTai(id);
        }

        #endregion  ExtensionMethod
    }
}

