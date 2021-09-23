import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutComponent } from './about/about.component';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { AdminDatabaseComponent } from './admin/admin-database/admin-database.component';
import { AdminNewCategoryComponent } from './admin/admin-new-category/admin-new-category.component';
import { AdminNewProductComponent } from './admin/admin-new-product/admin-new-product.component';
import { AdminNewRoleComponent } from './admin/admin-new-role/admin-new-role.component';
import { AdminNewuserComponent } from './admin/admin-newuser/admin-newuser.component';
import { AdminOrdersComponent } from './admin/admin-orders/admin-orders.component';
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
  {path: 'admin/dashboard', component:AdminDashboardComponent},
  {path: 'admin/databases', component:AdminDatabaseComponent},
  {path: 'admin/categories', component:AdminNewCategoryComponent},
  {path: 'admin/products', component:AdminNewProductComponent},
  {path: 'admin/roles', component:AdminNewRoleComponent},
  {path: 'admin/users', component:AdminNewuserComponent},
  {path: 'admin/orders', component:AdminOrdersComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
