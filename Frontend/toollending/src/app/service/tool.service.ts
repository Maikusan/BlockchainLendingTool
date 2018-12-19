import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Tool } from '../classes/tool';

@Injectable()
export class ToolService {

  constructor(private httpClient: HttpClient) { }

  getData(): Observable<any[]> {
    return this.httpClient.get<any[]>('http://localhost:61702/tools')
  }

  postData(tool : Tool): any {
    alert(tool.name);
    let a = this.httpClient.post<any>('http://localhost:61702/tools', tool).subscribe(
        res => {
          console.log(res);
        },
        err => {
          console.log(err);
        }
        );
    return a;
  }


  private handleError(error: Response) {
    console.error(error);
    return Observable.throw(error.json());
  }

}
