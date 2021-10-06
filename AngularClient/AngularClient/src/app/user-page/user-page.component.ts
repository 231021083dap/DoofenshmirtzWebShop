import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../authentication.service';
import { User } from '../models';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {
  username: string;
  email: string;

  constructor(private authService: AuthenticationService) { }

  async ngOnInit(): Promise<void> {
    let user = await this.authService.user();

    this.username = user.username;
    this.email = user.email;
  }

}
