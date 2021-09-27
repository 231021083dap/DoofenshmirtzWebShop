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
export interface OrderItems{

}
export interface User{
userID:number,
email:number,
username:number
}
export interface Orders{
    orderID:number,
    orderDate:Date,
    userID:number,
    user:User,
    orderItems:OrderItems[]
}