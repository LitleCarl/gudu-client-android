
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Reactive;
using System.Reactive.Linq;
using GuduCommon;
using Com.Github.Siyamed.Shapeimageview;
using Squareup.Picasso;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Com.Cocosw.Bottomsheet;
using MaterialUI;
namespace Gudu
{
	[Activity (Label = "ProductDetailActivity")]			
	public class ProductDetailActivity : Activity, INotifyPropertyChanged, IMenuItemOnMenuItemClickListener, MaterialUI.Widget.SnackBar.IOnActionClickListener
	{

		private LinearLayout imagesLinearLayout;
		private TextView titleTextView;
		private TextView productNameTextView;
		private TextView specificationTextView;
		private TextView specificationNameTextview;
		private TextView stockTextView;
		private TextView productBriefTextView;
		private TextView productPriceTextView;
		private TextView categoryTextView;

		private Button addCartButton;

		private SpecificationModel currentSelectSpecification;
		public SpecificationModel CurrentSelectSpecification {
			get { 
				return currentSelectSpecification;
			}
			set { SetField(ref currentSelectSpecification, value); }
		}

		private String product_id;
		public String Product_id {
			get { 
				return product_id;
			}
			set { SetField(ref product_id, value); }
		}

		private ProductModel product;
		public ProductModel Product {
			get { 
				return product;
			}
			set { SetField(ref product, value); }
		}

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.product_detail_activity);
			this.Product_id = this.Intent.GetStringExtra("product_id");
			initUI ();
			setUpTrigger();
			// Create your application here
		}
		void initUI(){
			imagesLinearLayout = FindViewById<LinearLayout> (Resource.Id.images_linear_view);
			titleTextView = FindViewById<TextView> (Resource.Id.title_textview);
			productNameTextView = FindViewById<TextView> (Resource.Id.product_name_textview); 
			specificationTextView = FindViewById<TextView> (Resource.Id.specification_textview);
			categoryTextView = FindViewById<TextView> (Resource.Id.category_textview);
			specificationNameTextview = FindViewById<TextView> (Resource.Id.specification_name_textview); 
			stockTextView =  FindViewById<TextView> (Resource.Id.stock_textview); 
			productBriefTextView = FindViewById<TextView> (Resource.Id.product_brief);
			productPriceTextView = FindViewById<TextView> (Resource.Id.product_price_textview);
			addCartButton = FindViewById<Button> (Resource.Id.addCartButton);
		}
		void setUpTrigger(){
			FindViewById<Button>(Resource.Id.select_specification_button).Click += (object sender, EventArgs e) => {
				BottomSheet builder = new BottomSheet.Builder(this).Title("选择规格").Sheet(Resource.Menu.noicon).Listener(this).Build();
				for(int i = 0; i < this.Product.Specifications.Count; i++){
					builder.Menu.Add(0, i, Menu.None, this.Product.Specifications[i].SpecificationValue);
				}


				builder.Show();
			};

			addCartButton.Click += (object sender, EventArgs e) => {
				CartItem.AddToCart(this.Product, this.CurrentSelectSpecification, 1, true);
				MaterialUI.Widget.SnackBar snack = MaterialUI.Widget.SnackBar.Make(this).ApplyStyle(Resource.Style.Material_Widget_SnackBar_Mobile_MultiLine);
				snack.Text("成功添加一个:"+this.Product.Name)
					.ActionText("购物车")
					.ActionClickListener(
						this
					).Duration(1000);
				snack.Show(this);
			};

			this.FromMyEvent<String> ("Product_id").Subscribe (
				(product_id) => {
					if (product_id != null)
						FetchData();
				}
			);
			this.FromMyEvent<ProductModel> ("Product").Subscribe (
				(product) => {
					if (product != null)
						PopulateData();
				}
			);
			this.FromMyEvent<SpecificationModel> ("CurrentSelectSpecification").Subscribe (
				(specification) =>{
					if (specification != null){
						specificationTextView.Text = specification.SpecificationValue;
						specificationNameTextview.Text = specification.Name;
						stockTextView.Text = specification.Stock.ToString();
						productPriceTextView.Text = string.Format("¥{0}", specification.Price.ToString());
						addCartButton.Enabled = specification.Stock > 0;
					}
					else{
						addCartButton.Enabled = false;
					}
				}
			);
		}

		void FetchData(){
			string url = Tool.BuildUrl (URLConstant.kBaseUrl, URLConstant.kProductFindOneUrl.Replace (":product_id", this.product_id), null);
			Tool.Get(url, null, this, (responseObject) =>{
				if (Tool.CheckStatusCode(responseObject)){
					var productPart = JObject.Parse(responseObject).SelectToken("data").ToString();
					this.Product = JsonConvert.DeserializeObject<ProductModel>(productPart, new JsonSerializerSettings
						{
							Error = (sender,errorArgs) =>
							{
								var currentError = errorArgs.ErrorContext.Error.Message;
								errorArgs.ErrorContext.Handled = true;
							}
						});
				}
				else
				{
					Console.WriteLine("状态码出错");
				}
			},
				(VolleyCSharp.VolleyError error) =>{
					
				});
			
		}
		/// <summary>
		/// 给scroll View添加横向滑动图片,各种信息显示
		/// </summary>
		void PopulateData(){
			imagesLinearLayout.RemoveAllViews ();
			foreach (var imageModel in this.Product.Product_images) {
				LayoutInflater inflater = (LayoutInflater)this.BaseContext.GetSystemService(Context.LayoutInflaterService);
				RelativeLayout relaView = (RelativeLayout) inflater.Inflate(Resource.Layout.RoundImageView, null);

				Picasso.With (this).Load (imageModel.Image_name).Into (relaView.FindViewById<ImageView>(Resource.Id.image_view));
				ViewGroup.LayoutParams layoutParams = new ViewGroup.LayoutParams((int)DeviceInfo.kScreenWidthInPixel(this),(int)DeviceInfo.kScreenWidthInPixel(this));
				imagesLinearLayout.AddView(relaView, 0, layoutParams);
			}

			productNameTextView.Text = this.Product.Name;
			titleTextView.Text = this.Product.Name;
			if (this.Product.Specifications.Count > 0) {
				this.CurrentSelectSpecification = this.Product.Specifications [0];
			}
			productBriefTextView.Text = this.Product.Brief;
			categoryTextView.Text = String.Format ("分类:{0}", this.Product.Category);
		}

		public void OnActionClick (MaterialUI.Widget.SnackBar p0, int p1){
			//TODO 去购物车
		}
		public bool OnMenuItemClick (IMenuItem item){
			
			this.CurrentSelectSpecification = this.Product.Specifications[item.ItemId];
			return true;
		}
		/// <summary>
		/// 开始Property监听
		/// </summary>
		public event PropertyChangedEventHandler PropertyChanged;
		// 添加一个触发 PropertyChanged 事件的通用方法
		protected virtual void NotifyPropertyChanged(string propertyName)
		{
			if (PropertyChanged != null)
			{
				PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		protected bool SetField<T>(ref T field, T value,
			[CallerMemberName] string propertyName = null){
			if (EqualityComparer<T>.Default.Equals(field, value)) return false;
			field = value;
			NotifyPropertyChanged(propertyName);
			return true;
		}
	}
}

