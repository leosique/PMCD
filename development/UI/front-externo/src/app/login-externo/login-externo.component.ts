import { Component, OnInit } from '@angular/core';
import axios from "axios";
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-externo',
  templateUrl: './login-externo.component.html',
  styleUrls: ['./login-externo.component.css']
})
export class LoginExternoComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {}

  mudarCorAzul(idTag : String){
    var inp = document.querySelector('#'+idTag);
    inp?.setAttribute('style', 'border-bottom: .15em solid #2d7db5;');
  }

  mudarCorCinza(idTag : String){
    var inp = document.querySelector('#'+idTag);
    inp?.setAttribute('style', 'border-bottom: .15em solid #C1C7CC;');
  }

  verificaCampos(){
    let cnpj = (document.getElementById("cnpj") as HTMLInputElement).value;
    let senha = (document.getElementById("senha") as HTMLInputElement).value;
    let erro = document.getElementById("erro")
    let mensagemErro = ""
    
    if(cnpj!= "" && senha != ""){
      this.verificarPrimeiroAcesso();
    }

    if(cnpj== "" && senha == ""){
      mensagemErro = "Campo cnpj e senha nulos"
    }else if (cnpj == ""){ 
      mensagemErro = "Campo cnpj nulo"
    }else{
      mensagemErro = "Campo senha nulo"
    }

    if(erro!= null){
      erro.style.display = "block"
      erro.textContent = mensagemErro
    }
    
  }

  verificarPrimeiroAcesso(){
    let senha = (document.getElementById("senha") as HTMLInputElement).value;
    let cnpj = (document.getElementById("cnpj") as HTMLInputElement).value;
    let erro = document.getElementById("erro")
    

    var config = {
      method: 'get',
      url: 'https://localhost:7274/Transportadora/Verifica/' + cnpj + "/" + senha,
      headers: {
        'Content-Type': 'application/json'
      }
    };

    let instance = this;
    localStorage.removeItem('authToken');
    axios(config)
      .then(function (response) {
        
        var primeiroacesso = response.data['primeiroAcesso'];

        if(primeiroacesso){
          instance.router.navigate(['primeiro-acesso']);
        }else{
          console.log(response.data);
          let mensagemErro = response.data['erro']
          instance.login();

          if(erro!= null){
            erro.style.display = "block"
            erro.textContent = mensagemErro
          }
        }
     
      })
      .catch(function (error) {
      })
    






    
  }

  login(){
    let cnpj = document.getElementById("cnpj") as HTMLInputElement;
    let senha = document.getElementById("senha") as HTMLInputElement;
    let erro = document.getElementById("erro")
    

    var data = JSON.stringify({
      "cnpj": cnpj.value,
      "senha": senha.value
    });


    var config = {
      method: 'post',
      url: 'https://localhost:7274/Transportadora/Login',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    let instance = this;
    localStorage.removeItem('authToken');
    axios(config)
      .then(function (response) {
        console.log(response.data);
        var token = response.data["token"]

        if(token == ""){
          console.log("informações incorretas");

          if(erro!= null){
            erro.style.display = "block"
            erro.textContent = "Cnpj ou senha incorretos"
          }
          
        }else{

          localStorage.setItem('authToken', token);
          
          instance.router.navigate(['cadastro-veiculo']);
        }
        

     
      })
      .catch(function (error) {
      })
    

   
  }
  

}
