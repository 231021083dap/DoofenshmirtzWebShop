import { CategoryService } from 'src/app/category.service';
import { Component, OnInit } from '@angular/core';
import { Router, Routes } from '@angular/router';
import { products, Category } from 'src/app/models';
import { productService } from 'src/app/product.service';

@Component({
  selector: 'app-databases',
  templateUrl: './databases.component.html',
  styleUrls: ['./databases.component.css']
})
export class DatabasesComponent implements OnInit {
  constructor(
    private productService: productService, private router: Router,
    private categoryService: CategoryService
    ) { }
  products:products[] = [];
  catories:Category[] = [];
  

  ngOnInit(): void {
  this.productService.getProducts().subscribe(a => this.products = a);
  this.categoryService.getCategories().subscribe(b => this.catories = b);
  }

  isOnProductsTab(): boolean{
    return this.router.url.includes("/admin/databases/products");
  }

  isOnCategoryTab(): boolean{
    return this.router.url.includes("/admin/databases/categories");
  }
}
