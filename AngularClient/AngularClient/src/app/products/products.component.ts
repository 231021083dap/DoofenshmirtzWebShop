import { Component, OnInit } from '@angular/core';
import { products, productGallery, Category } from '../models';
import { productService } from '../product.service';
import { CategoryService } from '../category.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  public searchInput: string;
  products: products[] = [];
  categories:Category[] = [];
  category: Category = {id: 0, categoryName: ''};
  constructor(private productService: productService, private categoryService: CategoryService) { }

  ngOnInit(): void {
    console.log("Sup");
    this.productService.getProducts().subscribe(a => this.products = a);
    this.categoryService.getCategories().subscribe(a =>  this.categories = a);
  }

}
