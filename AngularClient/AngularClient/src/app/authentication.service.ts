import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Injectable, EventEmitter } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Token, User } from './models';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public onAuthenticationChange: EventEmitter<any> = new EventEmitter<any>();
  private authorization : {token: string};

  constructor(private jwt: JwtHelperService, private http: HttpClient) {

    const token = localStorage.getItem('token');

    if (token) {
      this.authorization = { token: token }
      this.onAuthenticationChange.emit(this.authorization);
    }
  }

  public async login(username: string, password: string): Promise<boolean> {
    try {
      let apiUrl = 'https://localhost:5001/api/User/Authorization'
      let httpOptions = {
        headers: new HttpHeaders({
         'Content-Type': 'application/json'
        }),
    };
    let body = {Username: username, Password: password}

      let auth = await this.http.post < Token > (apiUrl, body, httpOptions).toPromise(); // call to api
      console.log(auth);
      
      this.authorization = { token: auth.token }
      localStorage.setItem('token', auth.token);
      this.onAuthenticationChange.emit(this.authorization);

      return true;
    } catch(e) {
      return false;
    }
  }

  public logout() {
    this.authorization = undefined;
    localStorage.removeItem('token');
    this.onAuthenticationChange.emit(this.authorization);
  }

  get authenticated(): boolean {
    if (this.authorization) return !this.jwt.isTokenExpired(this.authorization.token);
    else return false;
  }

  get id(): number {
    let data = this.jwt.decodeToken(this.authorization.token);
    return data.ID;
  }

  async user(): Promise<User> {
    let apiUrl = 'https://localhost:5001/api/User/' + this.id;
    let httpHeaders = {
      headers: new HttpHeaders({
       'Content-Type': 'application/json', 
       'Authorization' : 'Bearer ' + this.authorization.token
      })}
    let user = await this.http.get<User> (apiUrl, httpHeaders).toPromise();
    return user;
  }
}