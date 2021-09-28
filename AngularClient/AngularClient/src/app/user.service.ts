import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, observable } from 'rxjs';
import { User } from './models';

@Injectable({
  providedIn: 'root'
})
export class UserService {
private apiUrl = 'https://localhost:5001/api/user'
httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'}),
};
  constructor(private http:HttpClient) { }
  getUsers(): Observable<User[]>{return this.http.get<User[]>(this.apiUrl)}
  getUserById(userID:number): Observable<User>{return this.http.get<User>(`${this.apiUrl}/${userID}`)};
  newUser(user:User): Observable<User> {return this.http.post<User>(this.apiUrl, user, this.httpOptions)};
  updateUser(userID:number, user:User): Observable<User> {return this.http.put<User>(`${this.apiUrl}/${userID}`, user ,this.httpOptions)};
  deleteUser(userID:number): Observable<Boolean>{return this.http.delete<Boolean>(`${this.apiUrl}/${userID}`, this.httpOptions)};
}

