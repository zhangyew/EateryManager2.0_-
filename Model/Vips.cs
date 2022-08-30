using System;
namespace EateryManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class Vips
	{
		public Vips()
		{}
		#region Model
		private int _vipid;
		private string _vipname;
		private string _vipsex;
		private string _vgid;
		private string _viptel;
		private DateTime? _vipstartdate= DateTime.Now;
		private DateTime? _vipenddate;
		/// <summary>
		/// 会员编号
		/// </summary>
		public int VipID
		{
			set{ _vipid=value;}
			get{return _vipid;}
		}
		/// <summary>
		/// 会员姓名
		/// </summary>
		public string VipName
		{
			set{ _vipname=value;}
			get{return _vipname;}
		}
		/// <summary>
		/// 会员性别
		/// </summary>
		public string VipSex
		{
			set{ _vipsex=value;}
			get{return _vipsex;}
		}
		/// <summary>
		/// 等级ID
		/// </summary>
		public string VGID
		{
			set{ _vgid=value;}
			get{return _vgid;}
		}
		/// <summary>
		/// 联系电话
		/// </summary>
		public string VipTel
		{
			set{ _viptel=value;}
			get{return _viptel;}
		}
		/// <summary>
		/// 办理日期
		/// </summary>
		public DateTime? VipStartDate
		{
			set{ _vipstartdate=value;}
			get{return _vipstartdate;}
		}
		/// <summary>
		/// 到期日期
		/// </summary>
		public DateTime? VipEndDate
		{
			set{ _vipenddate=value;}
			get{return _vipenddate;}
		}
		/// <summary>
		/// 会员折扣率
		/// </summary>
		public double VGDiscount { set; get; }
		#endregion Model

	}
}

