import { Component } from '@angular/core';
import axios from "axios";
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro-ajudante',
  templateUrl: './cadastro-ajudante.component.html',
  styleUrls: ['./cadastro-ajudante.component.css']
})
export class CadastroAjudanteComponent {
  constructor(private router: Router) { }
  ngOnInit(): void {

  }

  verificaCampos(){
    let cpf = (document.getElementById("cpf") as HTMLInputElement).value;
    let nome = (document.getElementById("nome") as HTMLInputElement).value;
    let nascimento = (document.getElementById("nascimento") as HTMLInputElement).value;
    let erro = document.getElementById("erro") as HTMLElement

    if(cpf=="" || nome=="" || nascimento==""){
      erro.style.display = "block";
      erro.textContent = "Todos os campos devem ser preenchidos";
    }else{
      this.cadastro();
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
}
