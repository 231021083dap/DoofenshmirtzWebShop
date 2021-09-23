import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { FrontPageComponent } from './front-page/front-page.component';
import { ProductsComponent } from './products/products.component';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { CartComponent } from './cart/cart.component';
import { SingleProductComponent } from './single-product/single-product.component';
import { ContactComponent } from './contact/contact.component';
import { AboutComponent } from './about/about.component';
import { UserPageComponent } from './user-page/user-page.component';
import { AdminDashboardComponent } from './admin/admin-dashboard/admin-dashboard.component';
import { AdminDatabaseComponent } from './admin/admin-database/admin-database.component';
import { AdminNewCategoryComponent } from './admin/admin-new-category/admin-new-category.component';
import { AdminNewProductComponent } from './admin/admin-new-product/admin-new-product.component';
import { AdminNewuserComponent } from './admin/admin-newuser/admin-newuser.component';
import { AdminNewRoleComponent } from './admin/admin-new-role/admin-new-role.component';
import { AdminOrdersComponent } from './admin/admin-orders/admin-orders.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    AppComponent,
    FrontPageComponent,
    ProductsComponent,
    LoginComponent,
    SignupComponent,
    CartComponent,
    SingleProductComponent,
    ContactComponent,
    AboutComponent,
    UserPageComponent,
    AdminDashboardComponent,
    AdminDatabaseComponent,
    AdminNewCategoryComponent,
    AdminNewProductComponent,
    AdminNewuserComponent,
    AdminNewRoleComponent,
    AdminOrdersComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
