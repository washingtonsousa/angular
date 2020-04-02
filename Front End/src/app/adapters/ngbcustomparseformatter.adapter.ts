import { NgbDateParserFormatter, NgbDateStruct } from '@ng-bootstrap/ng-bootstrap';
import { Injectable } from '@angular/core';

@Injectable()
export class NgbDateCustomParserFormatter extends NgbDateParserFormatter {

  parse(value: string): NgbDateStruct {
  
    
    if (value) {

      const dateParts = value.trim().split('-');

  
        return {day: parseInt(dateParts[0]), month: parseInt(dateParts[1]), year: parseInt(dateParts[2])};
   

    }

    return null;
}

  format(date: NgbDateStruct): string {
    return date ? `${date.day}-${date.month}-${date.year}` : '';
  }
}