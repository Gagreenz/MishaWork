namespace MishaWork
{
    public static class CalendarUtil
    {
        private static List<string> months = new List<string>()
        {
            "Январь",
            "Февраль",
            "Март",
            "Апрель",
            "Май",
            "Июнь",
            "Июль",
            "Август",
            "Сентябрь",
            "Октябрь",
            "Ноябрь",
            "Декабрь"
        };
        public static string GetMonth(int index)
        {
            if (index < 1)
                index = 12;
            if (index > 11)
                index = 1;
            return months[index-1];
        }
    }
}
