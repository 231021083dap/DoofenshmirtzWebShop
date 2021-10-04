import { Component, OnInit } from '@angular/core';
import { CategoryService } from 'src/app/category.service';
import { Category, productGallery, products } from 'src/app/models';
import { productService } from 'src/app/product.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-admin-single-product',
  templateUrl: './admin-single-product.component.html',
  styleUrls: ['./admin-single-product.component.css']
})
export class AdminSingleProductComponent implements OnInit {
  productId: number;
  categories: Category[] = [];
  category: Category = {id:0, categoryName:''}
  gallery: productGallery[] = []
  products: products[] = []
  product: products = {
    id: 0, 
    name: '', 
    description:'', 
    stock: 0, 
    price: 0,
    categoryId: 0, 
    category: this.category, 
    imageGallery:this.gallery};
  constructor(
    private router: Router, 
    private actRoute: ActivatedRoute, 
    private categoryService: CategoryService, 
    private productService: productService
    ) { }

  ngOnInit(): void {
    this.productId = parseInt(this.actRoute.snapshot.params.id);
    this.getcategories();
    console.log(this.productId);
    if(!isNaN(this.productId)){
      this.productService.getProductById(this.productId).subscribe(a => this.product = a);
    }
  }
  getcategories(): void{
    this.categoryService.getCategories().subscribe(a => this.categories = a);
  }

  isNew(): boolean{
    return this.router.url.includes("/admin/databases/singleProduct/new");
  }
  onCancel(): void{
    this.router.navigate(["/admin/databases/products"]);
  }

  saveChanges(): void{
    if(this.product.id == 0){
      console.log( "Log: Create = ", this.product);
      this.productService.newProduct(this.product)
      .subscribe(a => {
        this.products.push(a);
        this.product = {id:0, name:'', description:'', 
        stock: 0, price: 0, categoryId: 0,
      category: this.category, imageGallery:this.gallery}});
      this.router.navigate(['/admin/databases/products']);
    }
    else{
      console.log("Log: Update", this.product);
      this.productService.updateProduct(
        this.product.id, this.product)
        .subscribe(() => this.product = {
        id:0, name:'', description:'', stock: 0, price: 0, 
        categoryId: 0,
      category: this.category, imageGallery:this.gallery});
      this.router.navigate(['/admin/databases/products']);
    }
  }
  onDelete(): void{
    if(confirm('are you sure you want to delete this product?')){
      this.productService.deleteProduct(this.product.id).subscribe(() => {this.products = this.products.filter(a => a.id != this.product.id)});
      this.router.navigate(['/admin/databases/products']);
    }
  }
}
