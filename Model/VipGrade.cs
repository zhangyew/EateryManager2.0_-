using System;
namespace EateryManager.Model
{
	/// <summary>
	/// 1
	/// </summary>
	[Serializable]
	public partial class VipGrade
	{
		public VipGrade()
		{}
		#region Model
		private int _vgid;
		private string _vgname;
		private double ? _vgdiscount;
		/// <summary>
		/// 等级编号
		/// </summary>
		public int VGID
		{
			set{ _vgid=value;}
			get{return _vgid;}
		}
		/// <summary>
		/// 等级名称
		/// </summary>
		public string VGName
		{
			set{ _vgname=value;}
			get{return _vgname;}
		}
		/// <summary>
		/// 等级折扣
		/// </summary>
		public double? VGDiscount
		{
			set{ _vgdiscount=value;}
			get{return _vgdiscount;}
		}
		#endregion Model

	}
}

