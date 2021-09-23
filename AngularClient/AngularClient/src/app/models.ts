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