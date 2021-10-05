import { productGallery } from './models';
import { Injectable } from '@angular/core';
import { products } from './models'

@Injectable({
  providedIn: 'root'
})
export class CartServiceService {
  items:products[] = [];

  constructor() { }

  createCart():void{
    let cart = localStorage.getItem('cart')
    if(cart == null || cart == 'null')
    {
      this.items = []
      localStorage.setItem('cart', JSON.stringify(this.items));
    }
    else {
      this.items = JSON.parse(localStorage.getItem('cart'))
    }
  }

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

  deleteCartItem(productID:number){
    this.items.splice(productID);
  }
}
