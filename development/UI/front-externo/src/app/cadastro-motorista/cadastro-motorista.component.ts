import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-cadastro-motorista',
  templateUrl: './cadastro-motorista.component.html',
  styleUrls: ['./cadastro-motorista.component.css']
})
export class CadastroMotoristaComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }
  
  EntregadorRegister(){
    var nomeEntregador = (document.getElementById('nome') as HTMLInputElement).value;
    var cpfEntregador = (document.getElementById('cpf') as HTMLInputElement).value;
    var rgEntregador = (document.getElementById('rg') as HTMLInputElement).value;
    var cnhEntregador = (document.getElementById('cnh') as HTMLInputElement).value;
    var dataNascimento = (document.getElementById('nascimento') as HTMLInputElement).value;
    localStorage.setItem("nomeEntregador", nomeEntregador);
    localStorage.setItem("cpfEntregador", cpfEntregador);
    localStorage.setItem("rgEntregador", rgEntregador);
    localStorage.setItem("cnhEntregador", cnhEntregador);
    localStorage.setItem("dataNascimento", dataNascimento);
  }

}
