import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Doofenshmirtz Evil Webshop';

  constructor(private router:Router){}

  isOnAdminPage(): boolean{
    //return true if URL has admin in it
    return this.router.url.includes("/admin/");
  }
}
