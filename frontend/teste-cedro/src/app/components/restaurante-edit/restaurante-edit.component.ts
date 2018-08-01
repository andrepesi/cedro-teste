import { RestauranteService } from '../restaurante/restaurante.service';
import { Component, OnInit } from '@angular/core';
import { Restaurante } from '../../types/restaurante';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-restaurante-edit',
  templateUrl: './restaurante-edit.component.html',
  styleUrls: ['./restaurante-edit.component.css']
})
export class RestauranteEditComponent implements OnInit {

  restaurante: Restaurante;
  constructor(private client: RestauranteService, private route: ActivatedRoute) { }

  ngOnInit() {

    this.restaurante = {} as Restaurante;
    this.route.params.subscribe(params => {
      const id = params['id'];
      this.client.getById(id).subscribe(result => {
        this.restaurante = result;
      })

    }
    )
  }
  save(): void {
    let promisse: any;
    if (this.restaurante.id > 0) {
      promisse = this.client.update(this.restaurante)
    }
    else {
      promisse = this.client.create(this.restaurante);
    }
    promisse.subscribe(result=> {
      if(result){
        alert("OK")
      }
    })
  }

}
