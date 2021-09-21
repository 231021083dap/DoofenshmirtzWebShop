export interface Category{
    categoryid: number,
    categoryName: string
}

export interface products{
    productID: number,
    productName: string,
    productDescription: String,
    productStock: number,
    productPrice: number,
    productCategoryId?: Category,
    productGallery: productGallery[]
}
export interface productGallery{
    galleryId: number,
    galleryPath: string,
    productId?: products
}