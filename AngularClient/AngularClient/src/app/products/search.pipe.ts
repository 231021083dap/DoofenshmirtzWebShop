import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name:'searchbar'
})

export class searchPipe implements PipeTransform{
    transform(products: string[], searchInput: string): any[] {
        if(!searchInput){
            return [];
        }
        searchInput = searchInput.toLowerCase();
        return products.filter(x => x.toLowerCase().includes(searchInput));
    }

}