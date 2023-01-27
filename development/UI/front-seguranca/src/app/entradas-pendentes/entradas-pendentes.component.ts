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

 
  aprovar(id:number){
    localStorage.setItem("id", id.toString())
    this.router.navigate(['/cadastro-veiculo']);
  }


 

}
