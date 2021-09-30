import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { Observable } from 'rxjs';
import { products } from './models';
@Injectable({
  providedIn: 'root'
})

export class productService{
  private apiUrl = 'https://localhost:5001/api/Product';
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'}),
  };
  constructor(private http:HttpClient) { }
  
  getProducts(): Observable<products[]>{return this.http.get<products[]>(this.apiUrl)}

  getProductById(productId: number): Observable<products> {return this.http.get<products>(`${this.apiUrl}/${productId}`);}
  newProduct(product: products): Observable<products> {return this.http.post<products>(this.apiUrl, product, this.httpOptions);}
  updateProduct(productId: number, product: products): Observable<products> {return this.http.put<products>(`${this.apiUrl}/${productId}`, product, this.httpOptions);}
  deleteProduct(productId: number): Observable<boolean> {return this.http.delete<boolean>(`${this.apiUrl}/${productId}`, this.httpOptions);}
}
