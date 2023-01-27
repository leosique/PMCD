import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import {Entrega} from 'src/interfaces/entrega';
import { Entregador } from 'src/interfaces/entregador';

@Component({
  selector: 'app-lista-fretes',
  templateUrl: './lista-fretes.component.html',
  styleUrls: ['./lista-fretes.component.css']
})
export class ListaFretesComponent implements OnInit {

 entregas: Array<Entrega> = []

  constructor() { }

  ngOnInit(): void {
    this.buscarEntregas()
  }


  buscarEntregas(){
    let cnpj = localStorage.getItem("cnpj")

    var config = {
      method: 'get',
      url: 'https://localhost:7274/Entrega/TransportadoraEntregaPendente/'+ cnpj,
      headers: {
        'Content-Type': 'application/json'
      }
    };

    let instance = this;
    localStorage.removeItem('authToken');
    axios(config)
      .then(function (response) {
        console.log(response.data);
        instance.entregas = response.data["entregasPendentes"]
        console.log(instance.entregas);
        

      })
      .catch(function (error) {
      })
  }




}
