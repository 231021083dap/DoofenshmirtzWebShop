import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import * as service from './models';

@Injectable({
  providedIn: 'root'
})

export class productService{
  private apiUrl = 'https://localhost:5001/api/Product';
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'}),
  };
  constructor(private http:HttpClient) { }
  
  getProducts(): Observable<service.products[]>{return this.http.get<service.products[]>(this.apiUrl)}

  getProductById(productId: number): Observable<service.products> {return this.http.get<service.products>(`${this.apiUrl}/${productId}`);}
  newProduct(product: service.products): Observable<service.products> {return this.http.post<service.products>(this.apiUrl, product, this.httpOptions);}
  updateProduct(productId: number, product: service.products): Observable<service.products> {return this.http.put<service.products>(`${this.apiUrl}/${productId}`, product, this.httpOptions);}
  deleteProcuct(productId: number): Observable<boolean> {return this.http.delete<boolean>(`${this.apiUrl}/${productId}`, this.httpOptions);}
}

export class categoryService{
  private apiUrl = 'https://localhost:5001/api/Category';

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'}),
  };
  constructor(private http:HttpClient) { }
  getCategories(): Observable<service.Category[]>{return this.http.get<service.Category[]>(this.apiUrl)}
  newProduct(category: service.Category): Observable<service.Category> {return this.http.post<service.Category>(this.apiUrl, category, this.httpOptions);}
  updateProduct(categoryId: number, category: service.Category): Observable<service.Category> {return this.http.put<service.Category>(`${this.apiUrl}/${categoryId}`, category, this.httpOptions);}
  deleteProcuct(categoryId: number): Observable<boolean> {return this.http.delete<boolean>(`${this.apiUrl}/${categoryId}`, this.httpOptions);}
}

export class galleryService{
  private apiUrl = 'https://localhost:5001/api/productImage';
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'}),
  };
  constructor(private http:HttpClient) { }

}