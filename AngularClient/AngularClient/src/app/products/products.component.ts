import { Component, OnInit } from '@angular/core';
import { products, productGallery, Category } from '../models';
import { productService, galleryService, categoryService } from '../service-list.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: products[] = [];
  constructor(private productService: productService) { }

  ngOnInit(): void {
    this.productService.getProducts().subscribe(a => this.products = a);
  }

}
