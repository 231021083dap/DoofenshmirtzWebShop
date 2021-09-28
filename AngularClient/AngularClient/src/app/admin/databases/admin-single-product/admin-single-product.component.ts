import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/category.service';
import { Category, productGallery, products } from 'src/app/models';
import { productService } from 'src/app/product.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-single-product',
  templateUrl: './admin-single-product.component.html',
  styleUrls: ['./admin-single-product.component.css']
})
export class AdminSingleProductComponent implements OnInit {
  productId: number;
  categories: Category[] = [];
  category: Category = {id:0, name:''}
  gallery: productGallery[] = []  
  product: products = {id: 0, name: '', description:'', stock: 0, price: 0, categoryId: this.category, imageGallery:this.gallery};
  constructor(private actRoute: ActivatedRoute, private categoryService: CategoryService, private productService: productService) { }

  ngOnInit(): void {
    this.productId = parseInt(this.actRoute.snapshot.params.id);
    this.getcategories();
    this.productService.getProductById(this.productId).subscribe(a => this.product = a);
  }
  getcategories(): void{
    this.categoryService.getCategories().subscribe(a => this.categories = a);
  }

}
