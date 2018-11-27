import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";

@Injectable()
export class UserService {

  constructor(private httpClient: HttpClient) { }

  getData(): Observable<any> {
    return this.httpClient.get<any>('http://localhost:61702/api/users')
  }

  private handleError(error: Response) {
    console.error(error);
    return Observable.throw(error.json());
  }

}
