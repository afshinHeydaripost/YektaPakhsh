using System.Globalization;

namespace Helper
{
	public static class DateTools
	{
		public static string ToPersianDate(this DateTime? date)
		{
			if (date is null)
				return "";
			PersianCalendar pc = new PersianCalendar();
			return string.Format("{0}/{1}/{2}", pc.GetYear(date.Value), pc.GetMonth(date.Value), pc.GetDayOfMonth(date.Value));
		}
		public static DateTime? ToDateTime(this string? date)
		{
			if (string.IsNullOrEmpty(date))
				return null;
			var dt = date.Replace("/", "").Replace(":", "").Replace("-", "").Replace(" ", "");
			PersianCalendar persianCalendar = new PersianCalendar();
			DateTime dateTime = persianCalendar.ToDateTime(Convert.ToInt32(dt.Substring(0, 4)), Convert.ToInt32(dt.Substring(4, 2)), Convert.ToInt32(dt.Substring(6, 2)), 0, 0, 0, 0);
			return dateTime;
		}
	}
}