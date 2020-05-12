import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProductService } from './services/product.service';
import { ProductModel } from './models/product.model';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
})
export class ProductListComponent implements OnInit {
    products: ProductModel[];
    
    constructor(private router: Router,
        private service: ProductService) {
    }

    ngOnInit() {
        this.getProducts();
    }

    getProducts() {
        this.service.GetAll().subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }

            this.products = result.value;
        }, error => alert(error));
    }

    new() {
        this.router.navigate(['product'])
    }

    edit(id) {
        this.router.navigate([`product/${id}`])
    }

    remove(id) {
        if (confirm('Deseja realmente excluir?'))
            this.service.Delete(id).subscribe(result => {
                if (!result.success) {
                    alert(result.message);
                    return;
                }
                    
                alert('Produto excluído');
                this.getProducts();
            }, error => alert(error));
    }
}
