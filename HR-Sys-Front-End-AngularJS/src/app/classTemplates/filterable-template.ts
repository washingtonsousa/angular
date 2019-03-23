export class Filterable {

    public  filterQueryHandler: any;
    public  currentPage: number = 1;
    public limit: number = 10;

    public constructor(filterQueryHandler: any) {
            this.filterQueryHandler = filterQueryHandler;
    }


    onFilterUpdate(event, value_type: string) {
        
        if(event.target) {
            this.filterQueryHandler[value_type] = event.target.value;
        } else {
            this.filterQueryHandler[value_type] = event;
        }

        this.filterQueryHandler =  this.filterQueryHandler;

    }

    dateTimeFilterHandler(event, value_type: string) {

        this.onFilterUpdate(event.year + "-" + ("0" + parseInt(event.month)).slice(-2) + "-" + ("0" + parseInt(event.day)).slice(-2) , value_type);
    
    }

}