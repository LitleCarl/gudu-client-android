using System;

namespace Gudu
{
	public static class URLConstant
	{
		public static string kBaseUrl = "http://gudu-sails.tunnel.mobi/";
		public static string kCampusUrl = "campus";
		public static string kCampusFindOneUrl = "campus/:campus_id";
		public static string kUserFindOneWithTokenUrl = "user/getWithToken";
		public static string kStoreUrl = "store";
		public static string kStoreFindOneUrl = "store/:store_id";
		public static string kProductUrl = "product";
		public static string kProductFindOneUrl = "product/:product_id";
		public static string kSearchUrl = "search/productAndStore";
		public static string kSendSmsUrl = "service/sendSMSCode";
		public static string kBasicConfig = "service/basicConfig";
		public static string kLoginUrl = "user/loginWithSMSCode";
		public static string kOrderPlaceOrderUrl = "order/placeOrder";
		public static string kPayOrderUrl = "pay/pay";
		public static string kGetOrdersUrl = "order/myOrders";
		public static string kAddAddressUrl = "address/addAddress";
		public static string kUpdateAddressUrl = "address/updateAddress";
		public static string kdeleteAddressUrl = "address/deleteAddress";

	}
}

