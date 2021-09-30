import {
  Component,
  OnInit
} from '@angular/core';
import {
  CategoryService
} from 'src/app/category.service';
import {
  Category
} from 'src/app/models';

@Component({
  selector: 'app-admin-categories',
  templateUrl: './admin-categories.component.html',
  styleUrls: ['./admin-categories.component.css']
})
export class AdminCategoriesComponent implements OnInit {
  categories: Category[] = [];
  category: Category = {
    id: 0,
    categoryName: ''
  }
  constructor(private categoryService: CategoryService) {}

  ngOnInit(): void {
    this.getCategories();
  }
  getCategories(): void {
    this.categoryService.getCategories()
      .subscribe(a => this.categories = a)
  }

  cancel(): void {
    this.category = {
      id: 0,
      categoryName: ''
    }
  }
  edit(category: Category): void {
    this.category = category;
  }
  delete(category:Category):void{
    if(confirm('Er du sikker på at slette?')){
      this.categoryService.deleteCategory(category.id)
      .subscribe(() => {this.getCategories()})
    }
  }
  save(): void {
    if (this.category.id == 0) {
      this.categoryService.newCategory(this.category)
        .subscribe(a => {
          this.categories.push(a);
          this.cancel();
        })
    } else {
      this.categoryService.updateCategory(this.category.id, this.category)
      .subscribe(() => {this.cancel})};

    
  }

}
