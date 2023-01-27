import { Component } from '@angular/core';
import axios from "axios";
import { Router } from '@angular/router';

export interface Ajudante{
  nome: string,
  cpf:string,
  dataNascimento:string
}
@Component({
  selector: 'app-cadastro-ajudante',
  templateUrl: './cadastro-ajudante.component.html',
  styleUrls: ['./cadastro-ajudante.component.css']
})
export class CadastroAjudanteComponent {
  constructor(private router: Router) { }

  listaAjudantes: Array<Ajudante> = []
  ajudante: Ajudante = {nome:"", cpf:"", dataNascimento: ""}
  ngOnInit(): void {
      this.listaAjudantes.push({
        nome:"Allan Kley",
        cpf:"dawd",
        dataNascimento:"11;09;2000"
      },{
        nome:"Allan Kley 2",
        cpf:"dawdafwawf",
        dataNascimento:"11;09;2000"
      })
  }

  verificaCampos(){
    let cpf = (document.getElementById("cpf") as HTMLInputElement).value;
    let nome = (document.getElementById("nome") as HTMLInputElement).value;
    let nascimento = (document.getElementById("nascimento") as HTMLInputElement).value;
    let erro = document.getElementById("erro") as HTMLElement
    let erroDiv = document.getElementById("erroDiv") as HTMLElement

    if(cpf=="" || nome=="" || nascimento==""){
      erroDiv.style.display = "block";
      erro.textContent = "Todos os campos devem ser preenchidos";
    }else{

      this.ajudante.cpf = cpf
      this.ajudante.nome = nome
      this.ajudante.dataNascimento = nascimento
      this.listaAjudantes.push(this.ajudante)
      console.log(this.listaAjudantes);
      
    }
    
  }

  cadastro() {
    let cnpj = document.getElementById("cpf") as HTMLInputElement;
    let nome = document.getElementById("nome") as HTMLInputElement;
    let nascimento = document.getElementById("nascimento") as HTMLInputElement;

    var data = JSON.stringify({
      "cpf": cnpj.value,
      "nome": nome.value,
      "nascimento": nascimento.value,
    });

    var config = {
      method: 'post',
      url: 'https://localhost:7274/Entrega/Editar',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    let instance = this;

    axios(config)
      .then(function (response) {
     
        instance.router.navigate(['/sucesso']);
        localStorage.setItem("cnpj", cnpj.value);
       
      })
      .catch(function (error) {
      })

  }

  deletarAjudante(cpf:string){
    let i = 0
    this.listaAjudantes.forEach((ajudante, index) => {
      if(ajudante.cpf == cpf){
        i = index
      }
    });

    this.listaAjudantes.splice(i,1)
  }

 
}
