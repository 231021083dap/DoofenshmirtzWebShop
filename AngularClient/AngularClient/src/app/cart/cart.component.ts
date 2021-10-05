import { Component, OnInit } from '@angular/core';
import { CartServiceService } from '../cart-service.service';
import { Orders } from '../models';
import { OrdersService } from '../orders.service';

@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {
  orders:Orders[] = [];
order:Orders = {id:0, date: null, userID: 0};
items = this.cartService.getItems();
totalprice:number = 0;

  constructor(private cartService:CartServiceService, private orderService: OrdersService) { }

  ngOnInit(): void {
    console.log(this.items)
  }

  clearCart(){
    this.items = this.cartService.clearCart();
  }

  deleteCartItem(productID:number){
     for(let i = 0; i < this.items.length; i += 1)
     {

     }
  }

  save(): void{
    if(this.order.id == 0)
    {
      this.orderService.newOrders(this.order)
      .subscribe(a => {
        this.orders.push(a)
        this.clearCart();
        alert("Order Completed");
      })
    }
  }

}
