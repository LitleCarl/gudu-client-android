using System;

namespace Gudu
{
	public class TsaoRegular
	{
		public TsaoRegular ()
		{
			 
		}
		public static bool isMobileNO(String mobiles) {  
			return System.Text.RegularExpressions.Regex.IsMatch(mobiles, @"^[1]+[2,3,4,5,6,7,8,9]+\d{9}$");
		} 
	}
}

