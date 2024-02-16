using LR3.interfaces;

namespace LR3.controllers
{
	public class DayTimeServise : IDayTimeService
	{
		public string GetDayTime(DateTime dateTime)
		{ 
			int hours = dateTime.Hour;

			if (hours >= 6 && hours < 12)
			{
				return $"It's morning ({dateTime})";
			}
			else if (hours >= 12 && hours < 18)
			{
				return $"It's daytime ({dateTime})";
			}
			else if (hours >= 18 && hours < 24)
			{
				return $"It's evening ({dateTime})";
			}
			else
			{
				return $"It's night now ({dateTime})";
			}
		}
	}
}
