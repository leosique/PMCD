import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login-seguranca',
  templateUrl: './login-seguranca.component.html',
  styleUrls: ['./login-seguranca.component.css']
})
export class LoginSegurancaComponent implements OnInit {

  constructor() { }

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
  

}
