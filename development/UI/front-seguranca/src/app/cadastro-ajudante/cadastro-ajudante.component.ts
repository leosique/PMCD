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

      let ajudante = {
        cpf: cpf,
        nome: nome,
        dataNascimento: nascimento
      }

      this.listaAjudantes.push(ajudante)
      console.log(this.listaAjudantes);
      
    }
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
  
  cadastroAjudantes(){

    this.listaAjudantes.forEach((ajudante, index) => {
      
      this.cadastroAjudante(index)
    });
  }

  cadastroAjudante(index:number) {
    let ajudante = this.listaAjudantes[index]

    var data = JSON.stringify({
      "nome": ajudante.nome,
      "cpf": ajudante.cpf,
      "dataNascimento": ajudante.dataNascimento,
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
      "motorista": false
          
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

        instance.aprova();
       
      })
      .catch(function (error) {
      })
  }

  aprova(){
    let idEntrega = localStorage.getItem("id")

    var config = {
      method: 'put',
      url: 'https://localhost:7274/Entrega/AprovaEntrega/' + idEntrega,
      headers: {
        'Content-Type': 'application/json'
      }
    };

    let instance = this;

    axios(config)
      .then(function (response) {

        instance.router.navigate(['/entradas-pendentes']);
       
      })
      .catch(function (error) {
      })
  }
 
}
