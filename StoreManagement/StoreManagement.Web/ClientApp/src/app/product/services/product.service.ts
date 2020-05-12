import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Result } from 'src/app/result';
import { ProductModel } from '../models/product.model';
import { AddProductCommand } from '../commands/add-product.command';
import { UpdateProductCommand } from '../commands/update-product.command';

@Injectable({
  providedIn: 'root'
})

export class ProductService {

  baseurl: string;

  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseurl = baseUrl + 'api/product';
  }

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  Add(command: AddProductCommand): Observable<Result<ProductModel>> {
    return this.http.post<Result<ProductModel>>(this.baseurl, JSON.stringify(command), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandl)
    )
  }  

  GetAll(): Observable<Result<ProductModel[]>> {
    return this.http.get<Result<ProductModel[]>>(this.baseurl, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandl)
    )
  }

  Get(id): Observable<Result<ProductModel>> {
    return this.http.get<Result<ProductModel>>(this.baseurl + '/' + id, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandl)
    )
  }

  Update(command: UpdateProductCommand): Observable<Result<ProductModel>> {
    return this.http.put<Result<ProductModel>>(this.baseurl, JSON.stringify(command), this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandl)
    )
  }

  Delete(id){
    return this.http.delete<Result<ProductModel>>(this.baseurl +'/' + id, this.httpOptions)
    .pipe(
      retry(1),
      catchError(this.errorHandl)
    )
  }

  errorHandl(error) {
     let errorMessage = '';
     if(error.error instanceof ErrorEvent) {
       errorMessage = error.error.message;
     } else {
       errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
     }
     console.log(errorMessage);
     return throwError(errorMessage);
  }

}