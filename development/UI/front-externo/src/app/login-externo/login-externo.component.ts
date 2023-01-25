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

  verificarPrimeiroAcesso(){
    var primeiroacesso = false

    if(primeiroacesso){
      this.router.navigate(['primeiro-acesso']);
    }else{
      this.login();
    }
  }

  login(){
    let cnpj = document.getElementById("cnpj") as HTMLInputElement;
    let senha = document.getElementById("senha") as HTMLInputElement;

    var data = JSON.stringify({
      "cnpj": cnpj.value,
      "senha": senha.value
    });
    console.log(data);


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
        
        //localStorage.setItem('authToken', response.data);
        
        instance.router.navigate(['cadastro-veiculo']);
     
      })
      .catch(function (error) {
      })
    

   
  }
  

}
