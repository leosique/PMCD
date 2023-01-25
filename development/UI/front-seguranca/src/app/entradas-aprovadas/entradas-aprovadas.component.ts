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
  detalhes_entrega : Entrega = { 
    id : 0,
    codigoInterno: "",
    dataEntrega: new Date(),
    idResponsavelBosch: 0,
    idTransponder: 0,
    idTransportadora: 0,
    liberado: false,
    notaFiscal : "",
    pesoEntrada: 0,
    pesoSaida: 0,
    placaCarro: ""
  }
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

  detalhesEntrada(id: number){
    var config = {
      method: 'get',
      url: 'https://localhost:7274/Entrega/Buscar/'+id,
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        instance.detalhes_entrega = response.data
        
      }); 
  }

}
