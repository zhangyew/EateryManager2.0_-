using System;
namespace EateryManager.Model
{
	/// <summary>
	/// RoomType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class RoomType
	{
		public RoomType()
		{}
		#region Model
		private int _rtid;
		private string _rtname;
		private decimal _rtmin=0M;
		private bool _rtisdis;
		private int _rtnum;
		/// <summary>
		/// 类型ID
		/// </summary>
		public int RTID
		{
			set{ _rtid=value;}
			get{return _rtid;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string RTName
		{
			set{ _rtname=value;}
			get{return _rtname;}
		}
		/// <summary>
		/// 最低消费
		/// </summary>
		public decimal RTMin
		{
			set{ _rtmin=value;}
			get{return _rtmin;}
		}
		/// <summary>
		/// 是否打折
		/// </summary>
		public bool RTIsDis
		{
			set{ _rtisdis=value;}
			get{return _rtisdis;}
		}
		/// <summary>
		/// 容纳人数
		/// </summary>
		public int RTNum
		{
			set{ _rtnum=value;}
			get{return _rtnum;}
		}
		/// <summary>
		/// 餐台编号
		/// </summary>
		public string TableName { set; get; }

		#endregion Model

	}
}

