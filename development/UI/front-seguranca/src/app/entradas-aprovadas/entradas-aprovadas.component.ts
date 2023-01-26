import { Component, OnInit } from '@angular/core';
import { Entrega } from 'src/interfaces/entrega';
import { Entregador } from 'src/interfaces/entregador';
import {EntregaMotorista} from 'src/interfaces/entregaMotorista';
import axios from 'axios';
@Component({
  selector: 'app-entradas-aprovadas',
  templateUrl: './entradas-aprovadas.component.html',
  styleUrls: ['./entradas-aprovadas.component.css']
})
export class EntradasAprovadasComponent implements OnInit {

  constructor() { }
  list_entrgas_aprovadas : Array<EntregaMotorista> = []
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
  detalhes_entregador: Entregador = {
    id: 0,
    nome:"",
    cpf: "",
    cnh: "",
    rg: "",
    dataNascimento: new Date(),
  }
  ngOnInit(): void {
    this.GetEntrgasAprovadas()
  }

  GetEntrgasAprovadas(){
    var config = {
      method: 'get',
      url: 'https://localhost:7274/EntregaEntregador/Aprovadas',
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        instance.list_entrgas_aprovadas = response.data
      });     
  }

  detalhesEntrada(idEntrega: number,idEntregador : number){
    var config = {
      method: 'get',
      url: 'https://localhost:7274/Entrega/Buscar/'+idEntrega,
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        instance.detalhes_entrega = response.data
        instance.detalhesEntregador(idEntregador)
      }); 
  }
  detalhesEntregador(idEntregador : number){
    var config = {
      method: 'get',
      url: 'https://localhost:7274/Entregador/Buscar/'+idEntregador,
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        instance.detalhes_entregador = response.data      
      }); 
  }

}
