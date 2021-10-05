import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { TokenStorageService } from '../token-storage.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  form: any = {
    username: '',
    password: ''
  };
  isLoggedIn = false;
  failedLogin = false;
  errorMessage = '';
  roles: string[] = []

  constructor(private authService: AuthenticationService, private tokenStorage: TokenStorageService, private router:Router){}

  ngOnInit(): void {
    if(this.tokenStorage.getToken()){
      this.isLoggedIn = true;
      this.roles = this.tokenStorage.getUser().roles;
    }
  }

  login(): void {
    console.log(this.form.username, this.form.password);
    const{username, password} = this.form;
    this.authService.login(username, password).subscribe(
      data => {
        this.tokenStorage.saveToken(data.accessToken);
        this.tokenStorage.saveUser(data);

        this.failedLogin = false;
        this.isLoggedIn = true;
        this.roles = this.tokenStorage.getUser().roles;
        console.log(username, password)
        this.router.navigate(['/userPage']);
      },
      err => {
        this.errorMessage = err.error.message;
        this.failedLogin = true;
      }   
    );
  }

  toUserPage(): void{
  }
}
