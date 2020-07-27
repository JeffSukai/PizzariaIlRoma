import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PizzaService } from '../Shared/pizza.service';
import { pizza } from '../admin/model/pizza';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent  implements OnInit{

  pizzaDetails;
  orderList: any = [];

  constructor(private router: Router, private service: PizzaService)
  {
  }

  ngOnInit(): void {
    this.GetAllPizzas();
  }

  GetAllPizzas(): void {
    this.service.GetAllPizza().subscribe(
      res => {
        this.pizzaDetails = res;
      },
      err => {
        console.log(err)
      }
    )
  }

  AddPizzaToOrder(name:string)
  {
    this.orderList.push(new pizza(name, "5,00"));
    console.log(this.orderList);
  }

  RemovePizzaFromOrder(name: string) {
    let index = this.orderList.findIndex(a => a.Name === name);
    if (index != -1) {
      this.orderList.splice(index, 1);
    }
  }


}
