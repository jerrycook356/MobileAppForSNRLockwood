using System;
namespace LockWood
{
    public class DateHolder
    {
        private static DateTime startDate;
        private static  DateTime endDate;

        public DateHolder()
        {

        }
        public DateHolder(DateTime startDateIn,DateTime endDateIn)
        {
            Console.Out.WriteLine("date holder start date = " + startDate);
            startDate = startDateIn;
            endDate = endDateIn;
        }

        public DateTime GetStartDate(){
            Console.Out.WriteLine("get start date in date holder = " + startDate);
            return startDate;
        }

        public DateTime GetEndDate(){
            return endDate;
        }
    }
}
