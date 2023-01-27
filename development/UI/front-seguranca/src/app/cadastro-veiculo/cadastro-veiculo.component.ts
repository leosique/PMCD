import { NONE_TYPE } from '@angular/compiler';
import { Component } from '@angular/core';
import { RouterLink,Router } from '@angular/router';
import axios from 'axios';

export interface Veiculo{
  placaCarro: string,
  modeloCarro: string,
  anoCarro:string
}

@Component({
  selector: 'app-cadastro-veiculo',
  templateUrl: './cadastro-veiculo.component.html',
  styleUrls: ['./cadastro-veiculo.component.css']
})
export class CadastroVeiculoComponent {
  constructor(private router: Router) {}
  veiculo: Veiculo ={placaCarro:"", modeloCarro:"", anoCarro:""}
  ngOnInit(): void {
        
  }

  verificaCampos(){
    let placaCarro = (document.getElementById("veiculo") as HTMLInputElement).value;
    let modeloCarro = (document.getElementById("modelo") as HTMLInputElement).value;
    let anoCarro = (document.getElementById("ano") as HTMLInputElement).value;
    let erro = document.getElementById("erro") as HTMLElement
    let erroDiv = document.getElementById("erroDiv") as HTMLElement

    if(placaCarro=="" || modeloCarro=="" || anoCarro==""){
      erroDiv.style.display = "block";
      erro.textContent = "Todos os campos devem ser preenchidos";
    }
    else{
        this.veiculo.placaCarro = placaCarro
        this.veiculo.modeloCarro = modeloCarro
        this.veiculo.anoCarro = anoCarro
        
        this.cadastro();
    }
  }


  cadastro() {
    let id = localStorage.getItem("id")

    var data = JSON.stringify({
      "id": id,
      "placaCarro": this.veiculo.placaCarro,
      "modeloCarro": this.veiculo.modeloCarro,
      "anoCarro": this.veiculo.anoCarro
    });
    console.log(data);
    
    var config = {
      method: 'put',
      url: 'https://localhost:7274/Entrega/Editar',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    let instance = this;

    axios(config)
      .then(function (response) {

        instance.router.navigate(['/cadastro-motorista']);
       
      })
      .catch(function (error) {
      })

  }
}

