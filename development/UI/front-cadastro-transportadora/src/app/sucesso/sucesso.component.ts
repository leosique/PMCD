import { Component } from '@angular/core';
import axios from "axios";
import { Router } from '@angular/router';

export interface Transportadora{
  nome: string,
  cnpj: string,
  senha: string
}

@Component({
  selector: 'app-sucesso',
  templateUrl: './sucesso.component.html',
  styleUrls: ['./sucesso.component.css']
})
export class SucessoComponent {
  constructor(private router: Router) { }
  transportadora: Transportadora = {nome:"", cnpj:"", senha:""}


  ngOnInit(): void {
    this.buscar();
  }

  buscar() {

    var cnpj = localStorage.getItem("cnpj")

    var config = {
      method: 'get',
      url: 'https://localhost:7274/Transportadora/BuscarCNPJ/' + cnpj,
      headers: {
        'Content-Type': 'application/json'
      }
    };

    let instance = this;

    axios(config)
      .then(function (response) {
     
        instance.transportadora = response.data;
       
      })
      .catch(function (error) {
      })

  }
}
