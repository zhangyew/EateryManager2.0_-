using System;
namespace EateryManager.Model
{
    /// <summary>
    /// ConsumerDetails:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class ConsumerDetails
    {
        public ConsumerDetails()
        { }
        #region Model
        private int _cdid;
        private string _cbid;
        private string _productid;
        private decimal? _cdprice;
        private int? _cdnum;
        private decimal? _cdsale;
        private decimal? _cdmoney;
        private int? _cdtype;
        private DateTime? _cddate = DateTime.Now;
        /// <summary>
        /// 编号
        /// </summary>
        public int CDID
        {
            set { _cdid = value; }
            get { return _cdid; }
        }
        /// <summary>
        /// 账单编号
        /// </summary>
        public string CBID
        {
            set { _cbid = value; }
            get { return _cbid; }
        }
        /// <summary>
        /// 商品编号
        /// </summary>
        public string ProductID
        {
            set { _productid = value; }
            get { return _productid; }
        }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal? CDPrice
        {
            set { _cdprice = value; }
            get { return _cdprice; }
        }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int? CDNum
        {
            set { _cdnum = value; }
            get { return _cdnum; }
        }
        /// <summary>
        /// 优惠金额
        /// </summary>
        public decimal? CDSale
        {
            set { _cdsale = value; }
            get { return _cdsale; }
        }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal? CDMoney
        {
            set { _cdmoney = value; }
            get { return _cdmoney; }
        }
        /// <summary>
        /// 消费类型
        /// </summary>
        public int? CDType
        {
            set { _cdtype = value; }
            get { return _cdtype; }
        }
        /// <summary>
        /// 点单时间
        /// </summary>
        public DateTime? CDDate
        {
            set { _cddate = value; }
            get { return _cddate; }
        }
        /// <summary>
        /// 商品类别
        /// </summary>
        public string LeiBie { set; get; }
        /// <summary>
        /// 商品名称
        /// </summary>
        public string name { set; get; }
        #endregion Model

    }
}

