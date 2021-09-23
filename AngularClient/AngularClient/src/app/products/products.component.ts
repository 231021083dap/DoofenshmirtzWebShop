import { Component, OnInit } from '@angular/core';
import { products, productGallery, Category } from '../models';
import { productService } from '../product.service';
import { CategoryService } from '../category.service';
import { Pipe, PipeTransform } from '@angular/core';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit, PipeTransform {
  products: products[] = [];
  categories:Category[] = [];
  category: Category = {id: 0, name: ''};
  constructor(private productService: productService, private categoryService: CategoryService) { }

  ngOnInit(): void {
    console.log("Sup");
    this.productService.getProducts().subscribe(a => this.products = a);
    this.categoryService.getCategories().subscribe(a =>  this.categories = a);
  }

  transform(items: any[], searchToken: string) {
    if(searchToken == null)
      searchToken = "";

      searchToken = searchToken.toLowerCase();
      return items.filter(elem => elem.name.toLowerCase().indexOf(searchToken) > -1);
    }
}
