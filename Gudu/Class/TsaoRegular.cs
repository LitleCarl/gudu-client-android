using System;

namespace Gudu
{
	public class TsaoRegular
	{
		public TsaoRegular ()
		{
			 
		}
		public static bool isMobileNO(String mobiles) {  
			return System.Text.RegularExpressions.Regex.IsMatch(mobiles, @"^[1]+[3,5,7,8]+\d{9}$");
		} 
	}
}

