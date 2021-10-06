import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { CategoryService } from 'src/app/category.service';
import { Category, products } from 'src/app/models';
import { productService } from 'src/app/product.service';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})
export class AdminProductsComponent implements OnInit {
  public searchInput:string;
  public dropdownInput: string;
  categories:Category[] = [];
  products:products[] = [];
  constructor(
    private categoryService:CategoryService,
    private productService: productService, 
    private router: Router) { }

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe(a => this.categories = a);
  this.productService.getProducts().subscribe(a => this.products = a);
  }
  newItem(): void{
    this.router.navigate(['/admin/databases/singleProduct/new']);
  }
}
