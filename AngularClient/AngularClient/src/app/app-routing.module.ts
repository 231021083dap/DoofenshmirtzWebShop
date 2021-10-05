import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { AdminCategoriesComponent } from './admin/databases/admin-categories/admin-categories.component';
import { AdminProductsComponent } from './admin/databases/admin-products/admin-products.component';
import { AdminRolesComponent } from './admin/databases/admin-roles/admin-roles.component';
import { AdminSingleProductComponent } from './admin/databases/admin-single-product/admin-single-product.component';
import { AdminUsersComponent } from './admin/databases/admin-users/admin-users.component';
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
  {path: 'singleproduct/:id', component:SingleProductComponent},
  {path: 'userpage/:id', component:UserPageComponent},
  {path: 'admin/dashboard', component:DashboardComponent},
  {path: 'admin/databases/products', component:AdminProductsComponent},
  {path: 'admin/databases/singleProduct/:id', component:AdminSingleProductComponent},
  {path: 'admin/databases/categories', component:AdminCategoriesComponent},
  {path: 'admin/databases/users', component:AdminUsersComponent},
  {path: 'admin/databases/roles', component:AdminRolesComponent},
  {path: 'admin/orders', component:OrdersComponent},
  {path: 'admin/databases/singleProduct', component: AdminSingleProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
