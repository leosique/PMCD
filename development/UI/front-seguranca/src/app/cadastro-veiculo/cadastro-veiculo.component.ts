import { NONE_TYPE } from '@angular/compiler';
import { Component } from '@angular/core';
import { RouterLink,Router } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-cadastro-veiculo',
  templateUrl: './cadastro-veiculo.component.html',
  styleUrls: ['./cadastro-veiculo.component.css']
})
export class CadastroVeiculoComponent {
  constructor(private router: Router) {}

  ngOnInit(): void {
        
  }

  verificaCampos(){
    let veiculo = (document.getElementById("veiculo") as HTMLInputElement).value;
    let modelo = (document.getElementById("modelo") as HTMLInputElement).value;
    let ano = (document.getElementById("ano") as HTMLInputElement).value;
    let erro = document.getElementById("erro") as HTMLElement
    let erroDiv = document.getElementById("erroDiv") as HTMLElement

    if(veiculo=="" || modelo=="" || ano==""){
      erroDiv.style.display = "block";
      erro.textContent = "Todos os campos devem ser preenchidos";
    }
    else{
        localStorage.setItem("veiculo", veiculo);
        localStorage.setItem("modelo", modelo);
        localStorage.setItem("ano", ano);
        this.router.navigate(['/cadastro-motorista']);
    }
  }
}

