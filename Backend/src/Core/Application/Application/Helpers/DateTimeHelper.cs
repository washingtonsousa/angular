using System;
using System.Globalization;

namespace Core.Application.Helpers
{
    public static class DateTimeHelper
    {
        public static DateTime convertstringdateToDateTime(this string dataRef)
        {

            return DateTime.ParseExact(dataRef, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        }

        public static DateTime convertDateToDateTimeBR(this DateTime dataRef)
        {

            return DateTime.ParseExact(GetstringDateTimeFromDate(dataRef), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        }


        private static string GetstringDateTimeFromDate(this DateTime dataRef)
        {
            return dataRef.Day.ToString("00") + "/" + dataRef.Month.ToString("00") + "/" + dataRef.Year.ToString("0000");
        }

    }

}