import { Component, OnInit } from '@angular/core';
import axios from 'axios';

export interface DialogData{
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

  registerEntrega(){
    var notaFiscal = (document.getElementById('nota') as HTMLInputElement).value;
    var dataEntrega = (document.getElementById('data') as HTMLInputElement).value;

    var data = JSON.stringify({
      "notaFiscal": notaFiscal,
      "dataEntrega": dataEntrega,
      "placaCarro": " ",
      "codigoInterno": 0,
      "pesoEntrada": 0,
      "pesoSaida": 0,
      "liberado": false,
      "idTransponder": 0,
      "idTransportadora": 0,
      "idResponsavelBosch": 0
    });
    
    var config = {
      method: 'post',
      url: 'http://localhost:5265/entrega/salvar',
      headers: { 
        'Content-Type': 'application/json'
      },
      data : data
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
