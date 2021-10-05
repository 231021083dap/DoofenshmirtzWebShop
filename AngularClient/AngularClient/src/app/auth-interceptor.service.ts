import { HTTP_INTERCEPTORS, HttpEvent } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpHandler, HttpRequest } from '@angular/common/http';
import { TokenStorageService } from './token-storage.service';
import { Observable, observable } from 'rxjs';

const tokenHeaderKey = 'Authorization';

@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private token: TokenStorageService) { }
  intercept(req: HttpRequest<any>, next:HttpHandler): Observable<HttpEvent<any>>{
    let authreq = req;
    const token = this.token.getToken();
    if(token != null){
      authreq = req.clone({headers: req.headers.set(tokenHeaderKey, 'Bearer' + token)});
    }
    return next.handle(authreq);
  }
}

export const authInterceptorProviders = [{
  provide: HTTP_INTERCEPTORS, useClass: AuthInterceptorService, multi:true
}];