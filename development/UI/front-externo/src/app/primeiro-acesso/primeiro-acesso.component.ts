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

  mudarCorAzul(idTag : String){
    var inp = document.querySelector('#'+idTag);
    inp?.setAttribute('style', 'border-bottom: .15em solid #2d7db5;');
  }
  
  mudarCorCinza(idTag : String){
    var inp = document.querySelector('#'+idTag);
    inp?.setAttribute('style', 'border-bottom: .15em solid #C1C7CC;');
  }

  EditarSenha(){
    console.log("oi");
    
    this.router.navigate(['cadastro-veiculo']);
  }
}
