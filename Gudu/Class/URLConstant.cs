using System;

namespace Gudu
{
	public static class URLConstant
	{
		public static string kBaseUrl = "http://api.zaocan84.com/";
		public static string kCampusUrl = "campuses";
		public static string kCampusFindOneUrl = "campuses/:campus_id";
		public static string kStoresInCampusUrl = "campuses/:campus_id/stores";

		public static string kUserFindOneWithTokenUrl = "users";
		public static string kStoreUrl = "stores";
		public static string kStoreFindOneUrl = "stores/:store_id";
		public static string kProductUrl = "products";
		public static string kProductFindOneUrl = "products/:product_id";
		public static string kSearchUrl = "services/search_product_and_store_for_campus";
		public static string kSendSmsUrl = "services/send_login_sms_code";
		public static string kRandomRecommendUrl = "services/random_recommend_store_in_campus";

		public static string kBasicConfig = "services/basic_config";

		public static string kLoginUrl = "users/login_with_sms_code";

		public static string kWeixinLoginUrl = "/authorizations/authorization";
		public static string kBindRoleUrl = "/users/bind_weixin";

		public static string kOrderPlaceOrderUrl = "orders";
		public static string kPayOrderUrl = "orders/:order_id/get_charge_for_unpaid_order";
		public static string kGetOrdersUrl = "orders";
		public static string kOrderShowUrl = "orders/:order_id";

		public static string kAddAddressUrl = "addresses";
		public static string kUpdateAddressUrl = "addresses/:address_id";
		public static string kDeleteAddressUrl = "addresses/:address_id";

		public static string kGetCouponsUrl = "users/:user_id/coupons";

	}
}

