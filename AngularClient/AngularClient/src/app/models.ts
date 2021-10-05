export interface Category{
    id: number,
    categoryName: string
}

export interface products{
    id: number,
    name: string,
    description: String,
    stock: number,
    price: number,
    categoryId: number,
    category?: Category,
    imageGallery: productGallery[]
}
export interface productGallery{
    galleryId: number,
    galleryPath: string,
    productId?: products
}
export interface address{
id:number,
customerName:string,
streetName:string,
postalCode:number,
countryName:string

}
export interface OrderItems{
id:number,
price:number,
quantity:number,
orderID:number,
productName:string
order?:Orders
Product?:products
}
export interface User{
id:number,
email:string,
username:string,
password:string,
role?: Role,
token?: string
}
export enum Role{
    User = 'User',
    Admin = 'Admin'
}
export interface Orders{
    id:number,
    date:Date,
    userID:number,
    user?:User,
    orderItems?:OrderItems[] 
}

export interface Token {
    id: number,
    username: string,
    email: string,
    role: Role,
    token: string
}