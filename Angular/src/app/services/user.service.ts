import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  private apiurl = 'https://localhost:7248/api/Working';

  constructor(private http: HttpClient) { }

  registeruser(user: any): Observable<any> {
    return this.http.post(`${this.apiurl}/register`, user, {
      headers: { 'Content-Type': 'application/json' }
    });
  }

  loginuser(user: any): Observable<any>{
    return this.http.post(`${this.apiurl}/login`, user,{
      headers: {'Content-Type': 'application/json'}
    })

  
  }



}
