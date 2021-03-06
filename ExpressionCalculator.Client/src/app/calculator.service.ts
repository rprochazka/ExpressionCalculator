import { Injectable } from '@angular/core';
import { Http, Response, Headers, RequestOptions } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import {ICalculateResult, ICalculateHistoryResult} from './calculator.model'

@Injectable()
export class CalculatorService {
  private serviceUrl = 'http://localhost:5000/api/v1/calculations';

  constructor(private http: Http) {}

  private extractData(res: Response): ICalculateResult {
    const body = res.json();
    return (<ICalculateResult>body) || null;
  }

  private extractHistoryData(res: Response): ICalculateHistoryResult[] {
    const body = res.json();
    return (<ICalculateHistoryResult[]>body) || [];
  }

  private handleError(error: Response | any) {
    let errMsg: string;
    if (error instanceof Response) {
      const body = error.json() || '';
      const err = body.error || JSON.stringify(body);
      errMsg = `${error.status} - ${error.statusText || ''} ${err}`;
    } else {
      errMsg = error.message ? error.message : error.toString();
    }
    console.error(errMsg);
    return Observable.throw(errMsg);
  }

  calculate(expression: string): Observable<ICalculateResult> {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const options = new RequestOptions({ headers: headers });
    const response = this.http
      .post(this.serviceUrl, '"' + expression + '"', options)
      .map(this.extractData)
      .catch(this.handleError);
    return response;
  }

  showHistory(): Observable<ICalculateHistoryResult[]> {
    const headers = new Headers({ 'Content-Type': 'application/json' });
    const options = new RequestOptions({ headers: headers });
    const response = this.http
      .get(this.serviceUrl + '/history', options)
      .map(this.extractData)
      .catch(this.handleError);
    return response;
  }
}

