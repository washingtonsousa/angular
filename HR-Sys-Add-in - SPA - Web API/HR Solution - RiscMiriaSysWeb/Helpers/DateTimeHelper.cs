using System;
using System.Globalization;

namespace RiscServicesHRSharepointAddIn.Helpers
{


  public class DateTimeHelper
    {

        public DateTimeHelper()
        {

        }

        public DateTime convertStringdateToDateTime(String dataRef)
        {

          return DateTime.ParseExact(dataRef, "dd/MM/yyyy", CultureInfo.InvariantCulture);

        }

        public DateTime convertDateToDateTimeBR(DateTime dataRef)
        {

            return DateTime.ParseExact(this.getStringDateTimeFromDate(dataRef), "dd/MM/yyyy", CultureInfo.InvariantCulture);

        }


        private string getStringDateTimeFromDate(DateTime dataRef)
        {
        return dataRef.Day.ToString("00") + "/" + dataRef.Month.ToString("00") + "/" + dataRef.Year.ToString("0000"); 
        }




    }



}