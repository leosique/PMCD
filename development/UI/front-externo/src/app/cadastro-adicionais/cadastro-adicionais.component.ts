import { Component, OnInit } from '@angular/core';

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

}
