import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Orders } from './models';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {
  private apiUrl = "https://localhost:5001/api/order";
  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'}),
  };

  constructor(private http:HttpClient) { }

  getOrders(): Observable<Orders[]>{return this.http.get<Orders[]>(this.apiUrl)};
  getOrderById(orderID:number): Observable<Orders>{return this.http.get<Orders>(`${this.apiUrl}/${orderID}`)};
  newOrders(order:Orders): Observable<Orders> {return this.http.post<Orders>(this.apiUrl, order, this.httpOptions)};
}
