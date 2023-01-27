import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { Entrega } from 'src/interfaces/entrega';

export interface DialogData {
  ajudante: string;
}

@Component({
  selector: 'app-cadastro-adicionais',
  templateUrl: './cadastro-adicionais.component.html',
  styleUrls: ['./cadastro-adicionais.component.css']
})
export class CadastroAdicionaisComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  verificarCampos() {
    var notaFiscal = (document.getElementById('nota') as HTMLInputElement).value;
    var dataEntrega = (document.getElementById('data') as HTMLInputElement).value;
    let erro = document.getElementById("erro") as HTMLElement
    let erroDiv = document.getElementById("erroDiv") as HTMLElement
    
    if (notaFiscal == "" || dataEntrega == "") {
      erroDiv.style.display = "block";
      erro.textContent = "Todos os campos devem ser preenchidos";
    }
    else {
      this.registerEntrega();
    }
  }

  registerEntrega() {
    var notaFiscal = (document.getElementById('nota') as HTMLInputElement).value;
    var dataEntrega = (document.getElementById('data') as HTMLInputElement).value;
    let id = localStorage.getItem("id")

    console.log(dataEntrega);


    var data = JSON.stringify({
      notaFiscal: notaFiscal,
      dataEntrega: dataEntrega,
      idTransportadora: id
    });

    var config = {
      method: 'post',
      url: 'https://localhost:7274/Entrega/SalvarNotaData',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    axios(config)
      .then(function (response) {
        console.log(JSON.stringify(response.data));
        alert("Entrega registrada com sucesso!");
      })
      .catch(function (error) {
        alert(error);
        console.log(error);
      });
  }
}
