import { Component, OnInit } from '@angular/core';
import { Entrega } from 'src/interfaces/entrega';
import axios from 'axios';
@Component({
  selector: 'app-entradas-aprovadas',
  templateUrl: './entradas-aprovadas.component.html',
  styleUrls: ['./entradas-aprovadas.component.css']
})
export class EntradasAprovadasComponent implements OnInit {

  constructor() { }
  list_entrgas_aprovadas : Array<Entrega> = []
  ngOnInit(): void {
    this.GetEntrgasAprovadas()
  }

  GetEntrgasAprovadas(){
    var config = {
      method: 'get',
      url: 'https://localhost:7274/Entrega/Aprovadas',
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        console.log(response.data);
        instance.list_entrgas_aprovadas = response.data
      });     
  }


}
