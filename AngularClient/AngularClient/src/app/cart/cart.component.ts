import { Component, OnInit } from '@angular/core';
import { CartServiceService } from '../cart-service.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  
items = this.cartService.getItems();

  constructor(private cartService:CartServiceService) { }

  ngOnInit(): void {
    console.log(this.items)
  }

  clearCart(){
    this.items = this.cartService.clearCart();
  }

  deleteCartItem(productID:number){
    // this.items = this.cartService.deleteCartItem(productID);
  }

}
