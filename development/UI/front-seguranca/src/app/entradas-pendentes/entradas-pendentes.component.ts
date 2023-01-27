import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { Entrega } from 'src/interfaces/entrega';
import { Entregador } from 'src/interfaces/entregador';
import {EntregaMotorista} from 'src/interfaces/entregaMotorista';
import { Router } from '@angular/router';

@Component({
  selector: 'app-entradas-pendentes',
  templateUrl: './entradas-pendentes.component.html',
  styleUrls: ['./entradas-pendentes.component.css']
})
export class EntradasPendentesComponent implements OnInit {
  list_entregas_pendentes : Array<EntregaMotorista> = []
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
  // array: Array<Pendentes> = [];

  // min:number = 0;
  // max: number = 0;
  // totalItems: number = 0;
  // pages: number = 0;
  // pagAtual:number = 1;
  // itemsPerPage: number = 9;
  // PagTotalArray: Array<number> = [];

  constructor(private router: Router) { }

  ngOnInit(): void {
    this.GetEntrgasPendentes()
  }

  GetEntrgasPendentes(){
    var config = {
      method: 'get',
      url: 'https://localhost:7274/EntregaEntregador/Pendentes',
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        instance.list_entregas_pendentes = response.data
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
  aprovar(id:number){
    localStorage.setItem("id", id.toString())
    this.router.navigate(['/cadastro-veiculo']);
  }


 

}
