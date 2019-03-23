export class NgSelectizeHelper {


private labelField: string;
private valueField: string;
private maxItems: number;

 constructor(labelField: string, valueField: string, maxItems = 1) {

   this.labelField = labelField;
   this.valueField = valueField;
   this.maxItems = maxItems;

 }

 setValueField(valueField: string) {
    this.valueField = valueField;
 }

 setLabelField(labelField: string) {
    this.labelField = labelField;
 }


 build() {

    return {

        labelField: this.labelField,
        valueField:  this.valueField,
        highlight: true,
        create:false,
        persist:true,
        plugins: ['dropdown_direction'],
        dropdownDirection: 'down',
        maxItems: this.maxItems

    }

 }



}