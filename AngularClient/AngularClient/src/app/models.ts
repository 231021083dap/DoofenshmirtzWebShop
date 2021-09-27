export interface Category{
    id: number,
    name: string
}

export interface products{
    id: number,
    name: string,
    description: String,
    stock: number,
    price: number,
    categoryId?: Category,
    imageGallery: productGallery[]
}
export interface productGallery{
    galleryId: number,
    galleryPath: string,
    productId?: products
}
export interface address{
ID:number,
customerName:string,
streetName:string,
postalCode:number,
countryName:string

}
export interface OrderItems{
ID:number,
price:number,
quantity:number,
orderID:number,
order?:Orders
Product:products
}
export interface User{
userID:number,
email:number,
username:number
password:string,
address:address[]
}
export interface Orders{
    orderID:number,
    orderDate:Date,
    userID:number,
    user:User,
    orderItems:OrderItems[]
}