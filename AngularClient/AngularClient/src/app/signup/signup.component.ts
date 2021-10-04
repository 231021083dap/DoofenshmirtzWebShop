import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models';
import { UserService } from '../user.service';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  users: User[] = [];
  user: User = {
    id: 0,
    email: '',
    username: '',
    password: '',
    token: ''
  }
  constructor(private userService: UserService) { }

  ngOnInit(): void {
  }

  cancel(): void {
    this.user = {
      id: 0,
      email: '',
      username: '',
      password: '',
    }
  }
  save(): void {
    if (this.user.id == 0) {
      console.log("Log: Create =", this.user)
      this.userService.newUser(this.user)
        .subscribe(a => {
          this.users.push(a);
          this.cancel();
        })
    }
  }

}
