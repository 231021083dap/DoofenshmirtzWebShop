import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { LoginResponseModel } from './models/LoginResponse.model';
import { JwtHelperService } from '@auth0/angular-jwt';

@Injectable({ providedIn: 'root' })
export class AuthenticationService {
  private apiUrl = 'https://localhost:5001/api/User';
  private currentUser;

  constructor(private http: HttpClient, private jwt: JwtHelperService) {
  }

  async user(): Promise<any> {
    if (this.authenticated()) {
      let token = localStorage.getItem('token');
      let dt = this.jwt.decodeToken(token);
      let id = dt.ID;
      let headers = new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      });
      let user = await this.http.get(`${this.apiUrl}/${id}`, {headers}).toPromise();

      return user;
    }
  }

  authenticated(): boolean {
    let token = localStorage.getItem('token');
    if (token) return true;
    return false;
  }

  async login(username: string, password: string): Promise<any> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });

    let body = {
      Email: username,
      Password: password
    };

    let user = await this.http.post<LoginResponseModel>(`${this.apiUrl}/Authorization`, body, {headers}).toPromise();

    localStorage.setItem('token', user.token);
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUser = undefined;
  }
}
