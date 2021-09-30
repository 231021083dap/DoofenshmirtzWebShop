import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  email: string = '';
  password: string = '';
  submitted = false;
  error = '';

  constructor(
    private router:Router
  ) { }

  ngOnInit(): void {
  }

  toUserPage(): void{
    this.router.navigate(['/userpage']);
  }
}
