using System;
namespace EateryManager.Model
{
	/// <summary>
	/// ProductType:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class ProductType
	{
		public ProductType()
		{}
		#region Model
		private int _ptid;
		private string _ptname;
		/// <summary>
		/// 类型ID
		/// </summary>
		public int PTID
		{
			set{ _ptid=value;}
			get{return _ptid;}
		}
		/// <summary>
		/// 类型名称
		/// </summary>
		public string PTName
		{
			set{ _ptname=value;}
			get{return _ptname;}
		}
		#endregion Model

	}
}

