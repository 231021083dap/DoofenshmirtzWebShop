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

  async login(): Promise<void> {
    await this.authService.login(this.form.username, this.form.password);
    
    if (this.authService.authenticated()) {
      let user = await this.authService.user();
      this.router.navigate(['/userpage/' + user.id]);
    }
  }

  toUserPage(): void{
  }
}
