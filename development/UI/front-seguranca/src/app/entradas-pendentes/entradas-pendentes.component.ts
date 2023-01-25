import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import { Entrega } from 'src/interfaces/entrega';
@Component({
  selector: 'app-entradas-pendentes',
  templateUrl: './entradas-pendentes.component.html',
  styleUrls: ['./entradas-pendentes.component.css']
})
export class EntradasPendentesComponent implements OnInit {
  pendentes : Array<Entrega> = []

  // array: Array<Pendentes> = [];

  // min:number = 0;
  // max: number = 0;
  // totalItems: number = 0;
  // pages: number = 0;
  // pagAtual:number = 1;
  // itemsPerPage: number = 9;
  // PagTotalArray: Array<number> = [];

  constructor() { }

  ngOnInit(): void {
    this.GetEntrgasPendentes()
  }

  GetEntrgasPendentes(){
    var config = {
      method: 'get',
      url: 'https://localhost:7274/Entrega/Pendentes',
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        console.log(response.data);
        instance.pendentes = response.data
      });     
  }

  // ProxPag(){
  //   if(this.pagAtual != this.pages){
  //     this.pagAtual++;
  //   }

  //   this.loadPage();
  // }

  // PagAnt(){
  //   if(this.pagAtual != 1){
  //     this.pagAtual--;
  //   }

  //   this.loadPage();
  // }
  
  // loadPage(){
  //   this.min = (this.pagAtual-1)*this.itemsPerPage;
  //   this.max = (this.pagAtual)*this.itemsPerPage;

  //   this.ChangeBtnState();
  // }

  // ChangeBtnState(){
  //   let btnProx = document.querySelector("#ProxBtn");
  //   let btnAnt = document.querySelector("#AntBtn");

  //   // btnProx
  //   if(this.pagAtual == this.pages ){
  //     btnProx?.setAttribute("style", "pointer-events: none;  opacity: 0.5;");
  //   }else{
  //     btnProx?.setAttribute("style", "pointer-events: all;");
  //   }

  //   // btnAnt
  //   if(this.pagAtual == 1 || this.pagAtual == 0){
  //     btnAnt?.setAttribute("style", "pointer-events: none; opacity: 0.5;");
  //   }else{
  //     btnAnt?.setAttribute("style", "pointer-events: all;");
  //   }
  // }

  // SetItemsPerPage(){
  //   this.itemsPerPage = Number((document.getElementById('showSelector') as HTMLInputElement).value);

  //   // this.itemsPerPage = Number(showSelector.value);
  //   console.log(this.itemsPerPage);
    
  //   this.loadPage();
  //   this.CalculatePages();
  // }

  // CalculatePages(){
  //   this.pages = Math.ceil(this.totalItems/this.itemsPerPage);

  //   this.PagTotalArray = [];

  //   for(let i = 1; i <= this.pages; i++){
  //     this.PagTotalArray.push(i);
  //   }
  // }

  // selectPage(page: number){
  //   this.pagAtual = page;
  //   this.loadPage();
  // }

}
