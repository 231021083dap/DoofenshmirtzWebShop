import { Injectable } from '@angular/core';

const tokenKey = 'auth-token';
const userKey = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  constructor() { }
  logout(): void{
    window.sessionStorage.clear();
  }

  public saveToken(token: string): void{
    window.sessionStorage.removeItem(tokenKey);
    window.sessionStorage.setItem(tokenKey, token);
  }

  public getToken(): string | null {
    return window.sessionStorage.getItem(tokenKey);
  }

  public saveUser(user: any): void{
    window.sessionStorage.removeItem(userKey);
    window.sessionStorage.setItem(userKey, JSON.stringify(user));
  }

  public getUser(): any{
    const user = window.sessionStorage.getItem(userKey);
    if(user){
      return JSON.parse(user);
    }else{
      return{};
    }
  }
}
