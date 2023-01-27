import { NONE_TYPE } from '@angular/compiler';
import { Component } from '@angular/core';
import { RouterLink,Router } from '@angular/router';
import axios from 'axios';

export interface Motorista{
  "nome": string,
  "cpf": string,
  "cnh": string,
  "rg": string,
  "dataNascimento": string
}

@Component({
  selector: 'app-cadastro-motorista',
  templateUrl: './cadastro-motorista.component.html',
  styleUrls: ['./cadastro-motorista.component.css']
})
export class CadastroMotoristaComponent {
  constructor(private router: Router) {}

  motorista: Motorista = {nome:"", cpf:"", cnh:"", rg:"", dataNascimento:""}

  ngOnInit(): void {
   
  }

  verificaCampos(){
    console.log("entrou");
    let nome = (document.getElementById("nome") as HTMLInputElement).value;
    let cpf = (document.getElementById("cpf") as HTMLInputElement).value;
    let rg = (document.getElementById("rg") as HTMLInputElement).value;
    let cnh = (document.getElementById("cnh") as HTMLInputElement).value;
    let nascimento = (document.getElementById("nascimento") as HTMLInputElement).value;
    let erro = document.getElementById("erro") as HTMLElement
    let erroDiv = document.getElementById("erroDiv") as HTMLElement

    if(nome=="" || cpf=="" || rg=="" || cnh=="" || nascimento==""){
      erroDiv.style.display = "block";
      erro.textContent = "Todos os campos devem ser preenchidos";
    }
    else{
      this.motorista.nome = nome;
      this.motorista.cpf = cpf;
      this.motorista.rg = rg;
      this.motorista.cnh = cnh;
      this.motorista.dataNascimento = nascimento;

      this.cadastro();
        
    }
  }

  cadastro() {

    var data = JSON.stringify({
      "nome": this.motorista.nome,
      "cpf": this.motorista.cpf,
      "cnh": this.motorista.cnh,
      "rg": this.motorista.rg,
      "dataNascimento": this.motorista.dataNascimento,
      
    });

    var config = {
      method: 'post',
      url: 'https://localhost:7274/Entregador/Salvar',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    let instance = this;

    axios(config)
      .then(function (response) {
     


        instance.cadastroEntregaEntregador(response.data["id"])
       
      })
      .catch(function (error) {
      })

  }

  cadastroEntregaEntregador(idEntregador:number){
    let idEntrega = localStorage.getItem("id")

    var data = JSON.stringify({
      "idEntrega": idEntrega,
      "idEntregador": idEntregador,
      "motorista": true
          
    });

    var config = {
      method: 'post',
      url: 'https://localhost:7274/EntregaEntregador/Salvar',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    let instance = this;

    axios(config)
      .then(function (response) {

        instance.router.navigate(['/cadastro-ajudante']);
       
      })
      .catch(function (error) {
      })
  }
}
