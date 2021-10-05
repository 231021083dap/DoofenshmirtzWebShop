import { Injectable, EventEmitter } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';


@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  public onAuthenticationChange: EventEmitter<any> = new EventEmitter<any>();

  constructor(private jwt: JwtHelperService) { 
    const token = localStorage.getItem('token');

    if (token) {
      this.authorization = { token: token }
      this.onAuthenticationChange.emit(this.authorization);
    }
  }

  public async login(email: string, password: string): Promise<boolean> {
    try {
      let auth = // call to api

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
}