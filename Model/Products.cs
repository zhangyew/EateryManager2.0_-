using System;
namespace EateryManager.Model
{
	/// <summary>
	/// Products:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Products
	{
		public Products()
		{}
		#region Model
		private int _productid;
		private string _productname;
		private string _ptid;
		private string _productjp;
		private decimal? _productprice;
		/// <summary>
		/// 商品编号
		/// </summary>
		public int ProductID
		{
			set{ _productid=value;}
			get{return _productid;}
		}
		/// <summary>
		/// 商品名称
		/// </summary>
		public string ProductName
		{
			set{ _productname=value;}
			get{return _productname;}
		}
		/// <summary>
		/// 商品类别
		/// </summary>
		public string PTID
		{
			set{ _ptid=value;}
			get{return _ptid;}
		}
		/// <summary>
		/// 商品简拼
		/// </summary>
		public string ProductJP
		{
			set{ _productjp=value;}
			get{return _productjp;}
		}
		/// <summary>
		/// 商品价格
		/// </summary>
		public decimal? ProductPrice
		{
			set{ _productprice=value;}
			get{return _productprice;}
		}
		#endregion Model

	}
}

