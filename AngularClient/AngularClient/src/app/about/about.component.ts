import { Component, OnInit } from '@angular/core';
declare var getPages: any;

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  page: string = "about1";
  constructor() { }

  ngOnInit(): void {
  }
  getAboutPage1(){
    this.page = "about1";
  }
  getAboutPage2(){
    this.page = "about2";
  }
  getAboutPage3(){
    this.page = "about3";
  }

}
