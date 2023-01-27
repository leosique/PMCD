import { Component } from '@angular/core';
import axios from "axios";
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
  styleUrls: ['./cadastro.component.css']
})
export class CadastroComponent {
  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  verificaCampos(){
    let cnpj = (document.getElementById("cnpj") as HTMLInputElement).value;
    let nome = (document.getElementById("nome") as HTMLInputElement).value;
    let erro = document.getElementById("erro") as HTMLElement

    if(cnpj=="" || nome==""){
      erro.style.display = "block";
      erro.textContent = "Todos os campos devem ser preenchidos";
    }else{
      this.cadastro();
    }
    
  }

  cadastro() {
    console.log("oi");

    let cnpj = document.getElementById("cnpj") as HTMLInputElement;
    let nome = document.getElementById("nome") as HTMLInputElement;

    var data = JSON.stringify({
      "cnpj": cnpj.value,
      "nome": nome.value
    });

    var config = {
      method: 'post',
      url: 'https://localhost:7274/Transportadora/Salvar',
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
