import { Component, OnInit } from '@angular/core';
import axios from "axios";
import { Router } from '@angular/router';

@Component({
  selector: 'app-primeiro-acesso',
  templateUrl: './primeiro-acesso.component.html',
  styleUrls: ['./primeiro-acesso.component.css']
})
export class PrimeiroAcessoComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
  }

  mudarCorAzul(idTag: String) {
    var inp = document.querySelector('#' + idTag);
    inp?.setAttribute('style', 'border-bottom: .15em solid #2d7db5;');
  }

  mudarCorCinza(idTag: String) {
    var inp = document.querySelector('#' + idTag);
    inp?.setAttribute('style', 'border-bottom: .15em solid #C1C7CC;');
  }

  verificarCampos() {
    let cnpj = (document.getElementById("cnpj") as HTMLInputElement).value;
    let senhaAntiga = (document.getElementById("senhaAntiga") as HTMLInputElement).value;
    let senhaNova = (document.getElementById("senhaNova") as HTMLInputElement).value;
    let repetirSenha = (document.getElementById("repetirSenha") as HTMLInputElement).value;
    let erro = document.getElementById("erro")
    let mensagemErro = ""
    let camposVazios = new Array()

    if (cnpj == "") {
      camposVazios.push("CNPJ");
    }
    if (senhaAntiga == "") {
      camposVazios.push("Senha antiga");
    }
    if (senhaNova == "") {
      camposVazios.push("Nova Senha");
    }
    if (repetirSenha == "") {
      camposVazios.push("Repetir senha");
    }

    if (camposVazios.length > 0) {
      mensagemErro = "Campos vazios: "

      camposVazios.forEach((campo, index) => {

        if (index == 0) {
          mensagemErro += campo
        } else {
          mensagemErro += ", " + campo
        }
      });

      if (erro != null) {
        erro.style.display = "block";
        erro.textContent = mensagemErro;
      }
    }else if(senhaNova != repetirSenha){
      mensagemErro = "As senhas informadas não são iguais"
      
      if (erro != null) {
        erro.style.display = "block";
        erro.textContent = mensagemErro;
      }
    }else{
      this.EditarSenha();
    }


    
  }

  EditarSenha() {
    console.log("oi");

    let cnpj = document.getElementById("cnpj") as HTMLInputElement;
    let senha = document.getElementById("senhaAntiga") as HTMLInputElement;
    let senhaNova = document.getElementById("senhaNova") as HTMLInputElement;
    let erro = document.getElementById("erro")


    var data = JSON.stringify({
      "cnpj": cnpj.value,
      "senha": senha.value
    });


    var config = {
      method: 'put',
      url: 'https://localhost:7274/Transportadora/EditarPrimeiroAcesso/' + senhaNova.value,
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    let instance = this;
    localStorage.removeItem('authToken');
    axios(config)
      .then(function (response) {
        if(response.data["erro"] === undefined){
          instance.router.navigate(['lista-frete']);
        }else{
      
          if (erro != null) {
            erro.style.display = "block";
            erro.textContent = response.data["erro"];
          }
        }
        


      })
      .catch(function (error) {
      })

  }
}
