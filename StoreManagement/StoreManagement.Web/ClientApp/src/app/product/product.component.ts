import { Component, OnInit } from '@angular/core';
import { ProductService } from './services/product.service';
import { Router, ActivatedRoute } from '@angular/router';
import { ProductModel } from './models/product.model';
import { AddProductCommand } from './commands/add-product.command';
import { UpdateProductCommand } from './commands/update-product.command';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
})
export class ProductComponent implements OnInit {
    product: ProductModel;

    constructor(private route: ActivatedRoute,
        private router: Router,
        private service: ProductService) {

    }

    ngOnInit() {
        let id = this.route.snapshot.paramMap.get('id');
        if (id) {
            this.getProduct(id);
        } else {
            this.product = new ProductModel();
        }
    }

    getProduct(id) {
        this.service.Get(id).subscribe(result => { 
            if (result.success)
                this.product = result.value;
            else
                alert(result.message);
        }, error => alert(error));
    }

    save() {
        var command = {
            name: this.product.name,
            price: this.product.price,
            stock: this.product.stock,
            id: this.product.id
        };

        var call;
        if (command.id)
            call = this.service.Update(command as UpdateProductCommand);
        else
            call = this.service.Add(command as AddProductCommand);

        call.subscribe(result => {
            if (!result.success) {
                alert(result.message);
                return;
            }

            alert('Produto salvo com sucesso');
            this.back();
        }, error => alert(error));
    }

    back() {
        this.router.navigate(['']);
    }
}
