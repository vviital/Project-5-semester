using System;
using System.IO;

namespace SmartHomeForms
{
    public class HandlerEventArgs : EventArgs
    {
        public DateTime DateTime { private set; get; }

        public Seasons Season { private set; get; }

        public DayParts DayPart { private set; get; }
        
        public HandlerEventArgs()
        {
            DateTime = DateTime.Now;
            SetVariables();
        }

        private void SetVariables()
        {
            int season = DateTime.Month%12/3;
            switch (season)
            {
                case 0:
                    Season = Seasons.Winter;
                    break;
                case 1:
                    Season = Seasons.Spring;
                    break;
                case 2:
                    Season = Seasons.Summer;
                    break;
                case 3:
                    Season = Seasons.Autumn;
                    break;
            }
            int dayPart = DateTime.Hour%21;
            DayPart = dayPart <= 9
                ? (dayPart <= 6 ? DayParts.Night : DayParts.Morning)
                : (dayPart <= 16 ? DayParts.Day : DayParts.Evening);
        }
    }
}
