using System;
using SQLite;
using GuduCommon;
using System.IO;
using DSoft.Messaging;

namespace Gudu
{	[Table("CartItem")]
	public class CartItem
	{
		[PrimaryKey]
		public string ProductAndSpecification { get; set; }
		public string Product_id { get; set; }
		public string Specification_id { get; set; }
		public string Logo_filename { get; set; }
		public int Quantity { get; set; }
		public string Name { get; set; }
		public string SpecificationBrief { get; set; }
		public string Price { get; set; }


		public static SQLiteConnection dbInstance;
		static CartItem(){
			string dbPath = Path.Combine (
				                Environment.GetFolderPath (Environment.SpecialFolder.Personal), "Normal.db3");
			dbInstance = new SQLiteConnection (dbPath);
			dbInstance.CreateTable<CartItem> ();
		}

		public static void AddToCart(ProductModel product, SpecificationModel specification, int mount, bool increase){
			string priKey = product.Id+"-"+specification.Id;
			var cart = dbInstance.Table<CartItem> ().Where (item => 
				item.ProductAndSpecification == priKey);
			
			Console.WriteLine ("cart :{0}", cart);
			if (cart.Count() > 0) {
				Console.WriteLine (">0");

				var cartItem = cart.First();
				if (increase) {
					cartItem.Quantity = Math.Max(0, cartItem.Quantity + mount);
				} else {
					cartItem.Quantity = Math.Max(0, mount);
				}
				if (cartItem.Quantity < 1) {
					dbInstance.Delete (cartItem);
				} else {
					dbInstance.Update (cartItem);	
				}
			} else {
				Console.WriteLine ("<1");

				var cartItem = new CartItem ();
				cartItem.ProductAndSpecification = string.Format ("{0}-{1}", product.Id, specification.Id);
				cartItem.Product_id = product.Id;
				cartItem.Specification_id = specification.Id;
				cartItem.Logo_filename = product.Logo_filename;
				cartItem.Quantity = Math.Max(0, mount);
				cartItem.Name = product.Name;
				cartItem.SpecificationBrief = string.Format ("{0}:{1}",specification.Name, specification.SpecificationValue);
				cartItem.Price = specification.Price.ToString();
				if (cartItem.Quantity > 0)
					dbInstance.Insert (cartItem);	

			}
			MessageBus.Default.Post (new CartItemChangedEvent (){
				Sender = null,
				Data = new object[]{"购物车商品变化"},
			});

		}

		public CartItem ()
		{
		}
	}
}

