using System;
namespace EateryManager.Model
{
	/// <summary>
	/// ConsumerBill:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ConsumerBill
	{
		public ConsumerBill()
		{}
		#region Model
		private string _cbid;
		private int? _tableid;
		private string _cbnum;
		private int? _vipid;
		private string _cbdiscount;
		private DateTime? _cbstartdate= DateTime.Now;
		private DateTime? _cbenddate;
		private int? _adminid;
		/// <summary>
		/// 账单编号
		/// </summary>
		public string CBID
		{
			set{ _cbid=value;}
			get{return _cbid;}
		}
		/// <summary>
		/// 餐桌编号
		/// </summary>
		public int? TableID
		{
			set{ _tableid=value;}
			get{return _tableid;}
		}
		/// <summary>
		/// 顾客人数
		/// </summary>
		public string CBNum
		{
			set{ _cbnum=value;}
			get{return _cbnum;}
		}
		/// <summary>
		/// 会员编号
		/// </summary>
		public int? VipID
		{
			set{ _vipid=value;}
			get{return _vipid;}
		}
		/// <summary>
		/// 会员折扣
		/// </summary>
		public string CBDiscount
		{
			set{ _cbdiscount=value;}
			get{return _cbdiscount;}
		}
		/// <summary>
		/// 开单时间
		/// </summary>
		public DateTime? CBStartDate
		{
			set{ _cbstartdate=value;}
			get{return _cbstartdate;}
		}
		/// <summary>
		/// 结账时间
		/// </summary>
		public DateTime? CBEndDate
		{
			set{ _cbenddate=value;}
			get{return _cbenddate;}
		}
		/// <summary>
		/// 收银员编号
		/// </summary>
		public int? AdminID
		{
			set{ _adminid=value;}
			get{return _adminid;}
		}
		#endregion Model

	}
}

