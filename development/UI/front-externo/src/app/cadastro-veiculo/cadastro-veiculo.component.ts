import { Component, OnInit } from '@angular/core';
import axios from "axios";


@Component({
  selector: 'app-cadastro-veiculo',
  templateUrl: './cadastro-veiculo.component.html',
  styleUrls: ['./cadastro-veiculo.component.css']
})
export class CadastroVeiculoComponent implements OnInit {
 
  constructor() { }

  ngOnInit(): void {
  }

  veiculoRegister(){
    var placaCarro = (document.getElementById('placa') as HTMLInputElement).value;
    localStorage.setItem("placaCarro", placaCarro)
  }

}
