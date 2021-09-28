import { Component, OnInit } from '@angular/core';
import { Router, Routes } from '@angular/router';
import { products } from 'src/app/models';
import { productService } from 'src/app/product.service';

@Component({
  selector: 'app-databases',
  templateUrl: './databases.component.html',
  styleUrls: ['./databases.component.css']
})
export class DatabasesComponent implements OnInit {
  products:products[] = [];
  constructor(private productService: productService, private router: Router) { }

  ngOnInit(): void {
  this.productService.getProducts().subscribe(a => this.products = a);
  }

  isOnProductsTab(): boolean{
    return this.router.url.includes("/admin/databases/products");
  }
}
