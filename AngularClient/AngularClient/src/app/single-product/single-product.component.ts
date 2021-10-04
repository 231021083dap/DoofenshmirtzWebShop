import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/category.service';
import { Category, productGallery, products } from 'src/app/models';
import { productService } from 'src/app/product.service';
import { Router, ActivatedRoute } from '@angular/router';
import { CartServiceService } from '../cart-service.service';

@Component({
  selector: 'app-single-product',
  templateUrl: './single-product.component.html',
  styleUrls: ['./single-product.component.css']
})
export class SingleProductComponent implements OnInit {
  productId: number;
  categories: Category[] = [];
  category: Category = {id:0, categoryName:''}
  gallery: productGallery[] = []
  products: products[] = []
  product: products = {
    id: 0, name: '', 
    description:'', 
    stock: 0, 
    price: 0,
    categoryId: 0,
    category: this.category, 
    imageGallery:this.gallery
  };
  constructor(
    private cartService: CartServiceService,
    private router: Router, 
    private actRoute: ActivatedRoute, 
    private categoryService: CategoryService, 
    private productService: productService
    ) { }

  ngOnInit(): void {
    this.productId = parseInt(this.actRoute.snapshot.params.id);
    this.categoryService.getCategories().subscribe(a => this.categories = a);
    console.log(this.productId);
    this.productService.getProductById(this.productId).subscribe(a => this.product = a);
  }
  addToCart(product:products){
    this.cartService.addToCart(product);
    alert("Your item has been added to your cart!")
  }

}
