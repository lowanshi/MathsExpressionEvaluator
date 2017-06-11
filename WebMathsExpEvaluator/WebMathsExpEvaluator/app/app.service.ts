import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from "rxjs/Observable";

@Injectable()
export class ExpressionService {    
    constructor(private http: Http) { }    
    private commentsUrl = 'api/expression';     
    private headers = new Headers({ 'Content-Type': 'text/plain' });

    create(url: string,expression: string): Observable<Response> {
        var body = {
            'expression': expression
        };
       var obs =  this.http
           .post(this.commentsUrl, expression, { headers: this.headers });
       return obs;
    }

    getHistory(url: string): Observable<any> {

        var obs = this.http.get(this.commentsUrl);      
        return obs;
    }
}