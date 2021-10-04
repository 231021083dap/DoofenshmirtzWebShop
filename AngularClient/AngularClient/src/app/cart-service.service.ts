import { productGallery } from './models';
import { Injectable } from '@angular/core';
import { products } from './models'

@Injectable({
  providedIn: 'root'
})
export class CartServiceService {
  items:products[] = [];

  constructor() { }

  addToCart(product:products){
    this.items.push(product);
  }

  getItems(){
    return this.items;
  }

  clearCart(){
    this.items = [];
    return this.items;
  }
}
