import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { AdminSingleProductComponent } from './admin/databases/admin-single-product/admin-single-product.component';
import { DatabasesComponent } from './admin/databases/databases.component';
import { OrdersComponent } from './admin/orders/orders.component';
import { CartComponent } from './cart/cart.component';
import { ContactComponent } from './contact/contact.component';
import { FrontPageComponent } from './front-page/front-page.component';
import { LoginComponent } from './login/login.component';
import { ProductsComponent } from './products/products.component';
import { SignupComponent } from './signup/signup.component';
import { SingleProductComponent } from './single-product/single-product.component';
import { UserPageComponent } from './user-page/user-page.component';

const routes: Routes = [
  {path: 'about', component:AboutComponent},
  {path: 'cart', component:CartComponent},
  {path: 'contact', component:ContactComponent},
  {path: '', component:FrontPageComponent},
  {path: 'login', component:LoginComponent},
  {path: 'products', component:ProductsComponent},
  {path: 'signup', component:SignupComponent},
  {path: 'singleproduct', component:SingleProductComponent},
  {path: 'userpage', component:UserPageComponent},
  {path: 'admin/dashboard', component:DashboardComponent},
  {path: 'admin/databases/products', component:DatabasesComponent},
  {path: 'admin/databases/singleProduct/:id', component:AdminSingleProductComponent},
  {path: 'admin/databases/categories', component:DatabasesComponent},
  {path: 'admin/databases/users', component:DatabasesComponent},
  {path: 'admin/databases/roles', component:DatabasesComponent},
  {path: 'admin/orders', component:OrdersComponent},
  {path: 'admin/databases/singleProduct', component: AdminSingleProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
