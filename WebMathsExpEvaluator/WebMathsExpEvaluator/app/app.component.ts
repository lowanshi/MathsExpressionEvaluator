import { Component } from '@angular/core';
import { ExpressionService } from './app.service';


@Component({
    selector: 'my-app',
    templateUrl: 'app.component.html',
    styleUrls: [ 'app.component.css'],
    moduleId: module.id,
    providers: [ExpressionService]
})
export class AppComponent {
    history: any;
    inputExpression: string;
    ComputedValue: string;
    indLoading: boolean = false;
    isComputed: boolean = false;
    isHistory: boolean = false;
    expressionUrl = 'api/expression';    
    constructor(private expressionService: ExpressionService) { }

    getHistory(): void {
        this.isHistory = true;
        var obs = this.expressionService.getHistory(this.expressionUrl);
        obs.subscribe(res => {
            this.history = res.json();
        },
            err => {
                this.history = err;
            });
    };
    sendValues(): void {
        this.indLoading = true;
        var obs = this.expressionService.create(this.expressionUrl,this.inputExpression);
        
        obs.subscribe(res => {
        this.isComputed = true;
        this.indLoading = false;
            this.ComputedValue = res.json();
        },
            err => {
                this.indLoading = false;
                this.isComputed = true;
                console.log(err);
                this.ComputedValue = err;
            });
    };   
    
}
