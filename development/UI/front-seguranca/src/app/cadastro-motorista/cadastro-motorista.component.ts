import { NONE_TYPE } from '@angular/compiler';
import { Component } from '@angular/core';
import { RouterLink,Router } from '@angular/router';
import axios from 'axios';

@Component({
  selector: 'app-cadastro-motorista',
  templateUrl: './cadastro-motorista.component.html',
  styleUrls: ['./cadastro-motorista.component.css']
})
export class CadastroMotoristaComponent {
  constructor(private router: Router) {}

  ngOnInit(): void {
   
  }

  verificaCampos(){
    console.log("entrou");
    let nome = (document.getElementById("nome") as HTMLInputElement).value;
    let cpf = (document.getElementById("cpf") as HTMLInputElement).value;
    let rg = (document.getElementById("rg") as HTMLInputElement).value;
    let cnh = (document.getElementById("cnh") as HTMLInputElement).value;
    let nascimento = (document.getElementById("nascimento") as HTMLInputElement).value;
    let erro = document.getElementById("erro") as HTMLElement
    let erroDiv = document.getElementById("erroDiv") as HTMLElement

    if(nome=="" || cpf=="" || rg=="" || cnh=="" || nascimento==""){
      erroDiv.style.display = "block";
      erro.textContent = "Todos os campos devem ser preenchidos";
    }
    else{
        localStorage.setItem("nome", nome);
        localStorage.setItem("cpf", cpf);
        localStorage.setItem("rg", rg);
        localStorage.setItem("cnh", cnh);
        localStorage.setItem("nascimento", nascimento);
        this.router.navigate(['/cadastro-ajudante']);
    }
  }
}
