import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { products } from 'src/app/models';
import { productService } from 'src/app/product.service';

@Component({
  selector: 'app-admin-products',
  templateUrl: './admin-products.component.html',
  styleUrls: ['./admin-products.component.css']
})
export class AdminProductsComponent implements OnInit {
  products:products[] = [];
  getNav: any;
  constructor(
    private productService: productService, 
    private router: Router) { }

  ngOnInit(): void {
  this.productService.getProducts().subscribe(a => this.products = a);
  }

  isOnProductsTab(): boolean{
    return this.router.url.includes("/admin/databases/products/");
  }
  newItem(): void{
    this.router.navigateByUrl('admin/products/singleProduct');
  }
}
