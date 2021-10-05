import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const httpOptions ={
  headers: new HttpHeaders({'Content-Type': 'application/json'})
}

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private apiUrl = 'https://localhost:5001/api/user';


  constructor(private http: HttpClient) {}

  login(username: string, password: string): Observable<any> {
    return this.http.post(this.apiUrl, {
      username,
      password
    },httpOptions);
  }
}
