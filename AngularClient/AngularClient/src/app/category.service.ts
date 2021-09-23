import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Category } from './models';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  private apiUrl = 'https://localhost:5001/api/Category';

  httpOptions = {
    headers: new HttpHeaders({'Content-Type': 'application/json'}),
  };
  constructor(private http:HttpClient) { }
  getCategories(): Observable<Category[]>{console.log("hi"); return this.http.get<Category[]>(this.apiUrl)}
  newProduct(category: Category): Observable<Category> {return this.http.post<Category>(this.apiUrl, category, this.httpOptions);}
  updateProduct(categoryId: number, category: Category): Observable<Category> {return this.http.put<Category>(`${this.apiUrl}/${categoryId}`, category, this.httpOptions);}
  deleteProcuct(categoryId: number): Observable<boolean> {return this.http.delete<boolean>(`${this.apiUrl}/${categoryId}`, this.httpOptions);}
}
