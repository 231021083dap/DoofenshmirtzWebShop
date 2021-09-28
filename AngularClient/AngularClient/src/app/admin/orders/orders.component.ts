import { Component, OnInit } from '@angular/core';
import { OrderItems, Orders, User } from 'src/app/models';
import { OrdersService } from 'src/app/orders.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {


  Orders: Orders[] = [];
  user: User = {id: 0, email:'', username:'', token:'' };
  orderItems: OrderItems = {id:0,price:0,quantity:0,orderID:0,}
  constructor(private orderService: OrdersService) { }

  ngOnInit(): void {
  this.getOrders();

  }
  getOrders():void{
    this.orderService.getOrders()
    .subscribe(a => this.Orders = a)
  }

  delete(order:Orders):void{
    if(confirm('Er du sikker på at slette?')){
     
  this.orderService.deleteOrder(order.id)
  .subscribe(() =>  {this.getOrders()})}
  }

  

  

}
