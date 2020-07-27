import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})

export class PizzaService {

  readonly BaseURL = 'http://localhost:61172/api';

  constructor(private http: HttpClient) {

  }

  CreatePizza(name: string, price: string) {

    const model = {
      name: name,
      price: price,
      imgPath:"./assets/pizza_placeholder.webp"
    }
    console.log(model);
    return this.http.post(this.BaseURL + '/pizza/create', model);
  }

  UpdatePizza(id:number, name: string, price: string) {

    const model = {
      name: name,
      price: price
    }
    console.log(model);
    return this.http.put(this.BaseURL + '/pizza/Update/'+id, model);
  }


  GetAllPizza() {
    return this.http.get(this.BaseURL + '/pizza')
  }

  DeletePizza(Id: number) {
    return this.http.delete(this.BaseURL + '/pizza/delete/' + Id);
  }
}
