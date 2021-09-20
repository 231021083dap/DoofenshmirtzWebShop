import { Component, OnInit } from '@angular/core';
declare var getPages: any;

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  getAboutPage1(){
    getPages.page1();
  }
  getAboutPage2(){
    getPages.page2();
  }
  getAboutPage3(){
    getPages.page3();
  }

}
