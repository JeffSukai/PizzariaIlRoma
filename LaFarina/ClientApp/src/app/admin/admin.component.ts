import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PizzaService } from '../Shared/pizza.service';



@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css']
})



export class AdminComponent implements OnInit {

  pizzaDetails;
  pizzaList: any = [];


  constructor(private route: ActivatedRoute, private router: Router,
              private service: PizzaService)
  { }

  ngOnInit(): void {
    this.GetAllPizzas();
  }


  CreatePizza(name: string, price: string):void
  {
    this.service.CreatePizza(name, price).subscribe(
      (res: any) => {
        this.pizzaList.push(res);
      },
      err => {
        console.log(err)
      }
    );
  }

  UpdatePizza(id:number,name: string, price: string): void {
    this.service.UpdatePizza(id,name,price).subscribe(
      (res: any) => {
        //TODO: Replace element in array
        //this.pizzaList.push(res);
      },
      err => {
        console.log(err)
      }
    );
  }
  
  GetAllPizzas(): void {
    this.service.GetAllPizza().subscribe(
      res => {
        this.pizzaDetails = res;
        this.pizzaDetails.forEach(element => {
        this.pizzaList.push(element);
        });
      },
      err => {
        console.log(err)
      }
    )
  }

  RemovePizza(id: number): void {

    let index = this.pizzaList.findIndex(a => a.id === id);
    if (index != -1) {
      this.pizzaList.splice(index, 1);
    }

    this.service.DeletePizza(id).subscribe(
      (res: any) => {
        this.router.navigateByUrl('/admin');
      },
      err => {
        console.log(err)
      }
    )
  }
}
