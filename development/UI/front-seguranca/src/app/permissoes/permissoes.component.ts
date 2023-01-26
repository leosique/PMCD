import { Component, OnInit } from '@angular/core';
import axios from 'axios';
import {IP} from 'src/interfaces/ip'
@Component({
  selector: 'app-permissoes',
  templateUrl: './permissoes.component.html',
  styleUrls: ['./permissoes.component.css']
})
export class PermissoesComponent implements OnInit {

  constructor() { }
  arrayIP : Array<IP> = []
  array : Array<number> = [1,2,3]

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

}
