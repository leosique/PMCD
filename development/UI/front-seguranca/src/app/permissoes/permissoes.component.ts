import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import {IP} from 'src/interfaces/ip';



@Component({
  selector: 'app-permissoes',
  templateUrl: './permissoes.component.html',
  styleUrls: ['./permissoes.component.css']
})
export class PermissoesComponent implements OnInit {

  constructor() { }
  arrayIP : Array<IP> = []
  array : Array<number> = [1,2,3]
  ip : string = ""

  ngOnInit(): void {
    var config = {
      method: 'get',
      url: 'https://localhost:7274/Ip/BuscarTodos',
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        console.log(response.data);
        instance.arrayIP = response.data
        console.log(instance.arrayIP)
      }); 
  }

  guardaIP(ip:string){
    this.ip=ip
  }
  deleteIP(){
 
    var config = {
      method: 'delete',
      url: 'https://localhost:7274/Ip/DeletarEndereco/'+ this.ip,
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        console.log(response.data);
        instance.arrayIP = response.data
        window.location.reload()
        console.log(instance.arrayIP)
      }); 
  }
  mudaIP(ip:string){
    var config = {
      method: 'put',
      url: 'https://localhost:7274/Ip/Editar/' + ip ,
      headers: {},
    };
    var instance = this;
    axios(config)
      .then(function(response:any) {
        console.log(response.data);
        instance.arrayIP = response.data
        window.location.reload()
        console.log(instance.arrayIP)
      });
  }
  AddIP(){
    let ip = (document.getElementById("addIP") as HTMLInputElement).value;
    let permission = Number((document.getElementById("addPerm") as HTMLInputElement).value)
    

    var data = JSON.stringify({
      enderecoIp :ip ,
      adm : permission == 1 ? true : false
    });

    var config = {
      method: 'post',
      url: 'https://localhost:7274/Ip/Salvar',
      headers: {
        'Content-Type': 'application/json'
      },
      data: data
    };

    let instance = this;
    axios(config)
      .then(function(response:any) {
        console.log(response.data)
        window.location.reload()
      });}



  
}

