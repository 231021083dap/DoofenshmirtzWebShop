import {
  emitDistinctChangesOnlyDefaultValue
} from '@angular/compiler/src/core';
import {
  Component,
  OnInit
} from '@angular/core';
import {
  Role,
  User
} from 'src/app/models';
import {
  UserService
} from 'src/app/user.service';

@Component({
  selector: 'app-admin-users',
  templateUrl: './admin-users.component.html',
  styleUrls: ['./admin-users.component.css']
})
export class AdminUsersComponent implements OnInit {
  users: User[] = [];
  user: User = {
    id: 0,
    email: '',
    username: '',
    password: '',
    token: ''
  }

  constructor(private userService: UserService) {}

  ngOnInit(): void {
    this.getUsers();
  }
  getUsers(): void {
    this.userService.getUsers()
      .subscribe(a => this.users = a);
  }
  cancel(): void {
    this.user = {
      id: 0,
      email: '',
      username: '',
      password: '',
    }


  }
  edit(user: User): void {
    this.user = user;
  }
  delete(user: User): void {
    if (confirm('Do you want to delete?')) {
      this.userService.deleteUser(user.id)
        .subscribe(() => {
          this.getUsers()
        })
    }
  }
  save(): void {
    if (this.user.id == 0) {
      this.userService.newUser(this.user)
        .subscribe(a => {
          this.users.push(a);
          this.cancel();
        })
    } else {
      this.userService.updateUser(this.user.id, this.user)
        .subscribe(() => {
          this.cancel
        })
      this.cancel();
    }
  }


}
