using System;
namespace EateryManager.Model
{
	/// <summary>
	/// Tables:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Tables
	{
		public Tables()
		{}
		#region Model
		private int _tableid;
		private string _tablename;
		private string _rtid;
		private string _tablearea;
		private int? _tablestate=0;
		/// <summary>
		/// 餐桌编号
		/// </summary>
		public int TableID
		{
			set{ _tableid=value;}
			get{return _tableid;}
		}
		/// <summary>
		/// 餐桌名称
		/// </summary>
		public string TableName
		{
			set{ _tablename=value;}
			get{return _tablename;}
		}
		/// <summary>
		/// 房间类型
		/// </summary>
		public string RTID
		{
			set{ _rtid=value;}
			get{return _rtid;}
		}
		/// <summary>
		/// 所在区域
		/// </summary>
		public string TableArea
		{
			set{ _tablearea=value;}
			get{return _tablearea;}
		}
		/// <summary>
		/// 餐桌状态
		/// </summary>
		public int? TableState
		{
			set{ _tablestate=value;}
			get{return _tablestate;}
		}
		
		#endregion Model

	}
}

