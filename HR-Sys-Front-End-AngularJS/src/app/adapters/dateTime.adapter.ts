import {NgbDateStruct, NgbCalendar} from '@ng-bootstrap/ng-bootstrap';
import {Injectable} from '@angular/core';

@Injectable()
export class DateTimeAdapterService {


constructor(private calendar: NgbCalendar) {}

 public  stringToDate(_date,_format,_delimiter) 
    {

        if(!_date) {
            return null;
        }
        
    var formatLowerCase=_format.toLowerCase();

    var formatItems=formatLowerCase.split(_delimiter);

    var dateItems=_date.split(_delimiter);

    var monthIndex=formatItems.indexOf("mm");

    var dayIndex=formatItems.indexOf("dd");

    var yearIndex=formatItems.indexOf("yyyy");

    var month=parseInt(dateItems[monthIndex]);

    var formatedDate = new Date(dateItems[yearIndex],month,dateItems[dayIndex]);

    return formatedDate;
    }

   public dateTimeStringToDate(_date,_format,_delimiter) {

    if(!_date || _date == "0001-01-01T00:00:00") {
        return null;
    }

    var formatLowerCase=_format.toLowerCase();

    var formatItems=formatLowerCase.split(_delimiter);

    var dateItems= _date.split("T")[0].split(_delimiter);

    var monthIndex=formatItems.indexOf("mm");

    var dayIndex=formatItems.indexOf("dd");

    var yearIndex=formatItems.indexOf("yyyy");

    var month=parseInt(dateItems[monthIndex]);

    var formatedDate = new Date(dateItems[yearIndex],month,dateItems[dayIndex]);

    return formatedDate;

   }
   
   public dateTimeStringToStringDate(_date,_format,_delimiter, _separator) {


    if(!_date || _date == "0001-01-01T00:00:00") {
        return null;
    }

    var formatLowerCase=_format.toLowerCase();

    var formatItems=formatLowerCase.split(_delimiter);

    var dateItems= _date.split("T")[0].split(_delimiter);

    var monthIndex=formatItems.indexOf("mm");

    var dayIndex=formatItems.indexOf("dd");

    var yearIndex=formatItems.indexOf("yyyy");

    var month=parseInt(dateItems[monthIndex]);

    return dateItems[dayIndex] +  _separator + month + _separator + dateItems[yearIndex];

   }


   public dateTimeStringtoCalendar(_date,_format,_delimiter) {

    if(!_date) {
       return null;
    }
   
   let date = this.dateTimeStringToDate(_date,_format,_delimiter);
   
   return this.dateToCalendar(date);

   }

   public calendarToDate(datePickerModel: NgbDateStruct) : Date {

    let date = new Date();
    date.setMonth(datePickerModel.month - 1);
    date.setFullYear(datePickerModel.year);
    date.setDate(datePickerModel.day); 
    
    return date;

    }
  
    public dateToCalendar(date: Date) {
    
    let calendarDate: NgbDateStruct = this.calendar.getToday();
    calendarDate.day = date.getDay();
    calendarDate.month = date.getMonth();
    calendarDate.year = date.getFullYear();
    
    return calendarDate;

    }

    public calendarToString(_separator , datePickerModel: NgbDateStruct) {
       
        return datePickerModel.day + _separator + datePickerModel.month + _separator + datePickerModel.year;

    }
  


}