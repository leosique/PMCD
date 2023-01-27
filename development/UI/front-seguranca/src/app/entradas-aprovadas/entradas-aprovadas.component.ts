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
  list_entregas_aprovadas : Array<EntregaMotorista> = []
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
  lista_detalhes_entregador : Array<Entregador> = []
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
        instance.list_entregas_aprovadas = response.data
        console.log(instance.list_entregas_aprovadas);
        
      });     
  }

  MostraDetalhes(entregaId : number){
    this.lista_detalhes_entregador = []
    this.list_entregas_aprovadas.forEach(element => {
      if(element.entrega.id == entregaId){
        this.detalhes_entrega = element.entrega
        element.entregadores.forEach(entregador => {
          if(entregador.motorista) this.detalhes_entregador = entregador.entregador
          else this.lista_detalhes_entregador.push(entregador.entregador)
        });
       
      }
    });  
  }

}
