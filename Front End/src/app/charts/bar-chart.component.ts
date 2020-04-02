import { Component, OnInit, Input, OnChanges } from "@angular/core";

@Component({
  selector: 'simple-bar-chart',
  template: `
  <div *ngIf="barChartData.length" style="display: block" class="chart-card-white">
                            <canvas baseChart
                                    [datasets]="barChartData"
                                    [labels]="barChartLabels"
                                    [options]="barChartOptions"
                                    [legend]="barChartLegend"
                                    chartType="bar"
                                    [colors]="chartColors">
                            </canvas>
                          </div>
  `
})
export class BarChartComponent implements OnInit {
      private barChartOptions = {
        scaleShowVerticalLines: false,
        responsive: true
      };

      @Input() public defaultLabelColors: any[] = [];

      @Input() private chartColors: any[] = [];  
    
      @Input() public barChartLabels = [];
      @Input() public barChartLegend = true;

      /* Format :   {data: [120, 130, 180, 70], label: '2017'}, */
      @Input() public barChartData = [
      ];


       getRandomColor() {
        var letters = '0123456789ABCDEF';
        var color = '#';
        for (var i = 0; i < 6; i++) {
          color += letters[Math.floor(Math.random() * 16)];
        }
        return color;
        }

      ngOnInit() {
      

          for(let i=0; i < this.barChartData.length; i++) {
           if(this.defaultLabelColors.length > 0) {
            this.chartColors.push({ backgroundColor: this.defaultLabelColors[i] });
           } else {
         
            this.chartColors.push({ backgroundColor: this.getRandomColor() });
           }
              
          }
        
      }
}