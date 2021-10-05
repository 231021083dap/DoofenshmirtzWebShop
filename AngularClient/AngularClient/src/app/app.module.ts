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
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { DashboardComponent } from './admin/dashboard/dashboard.component';
import { DatabasesComponent } from './admin/databases/databases.component';
import { OrdersComponent } from './admin/orders/orders.component';
import { AdminSingleProductComponent } from './admin/databases/admin-single-product/admin-single-product.component';
import { AdminCategoriesComponent } from './admin/databases/admin-categories/admin-categories.component';
import { AdminUsersComponent } from './admin/databases/admin-users/admin-users.component';
import { AdminProductsComponent } from './admin/databases/admin-products/admin-products.component';
import { AdminRolesComponent } from './admin/databases/admin-roles/admin-roles.component';
import { Ng2SearchPipe, Ng2SearchPipeModule } from 'ng2-search-filter';
import { JwtModule } from '@auth0/angular-jwt';

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
    DashboardComponent,
    DatabasesComponent,
    OrdersComponent,
    AdminSingleProductComponent,
    AdminCategoriesComponent,
    AdminUsersComponent,
    AdminProductsComponent,
    AdminRolesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    Ng2SearchPipeModule,
    JwtModule.forRoot({
      config: {
      tokenGetter: () => localStorage.getItem("token"),
      allowedDomains: [window.location.host]
    },
  })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
