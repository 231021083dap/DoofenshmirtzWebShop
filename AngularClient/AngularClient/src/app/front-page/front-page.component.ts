import { Component, OnInit } from '@angular/core';
import { products } from '../models';
import { productService } from '../product.service';

@Component({
  selector: 'app-front-page',
  templateUrl: './front-page.component.html',
  styleUrls: ['./front-page.component.css']
})
export class FrontPageComponent implements OnInit {
  products: products[] = [];
  constructor(private productService: productService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(a => this.products = a);
  }

}
