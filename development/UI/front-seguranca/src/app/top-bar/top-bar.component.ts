import { Component, OnInit } from '@angular/core';
import axios from "axios";
import { Router } from '@angular/router';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})
export class TopBarComponent implements OnInit {

  constructor(private router: Router) { }
  
  adm:boolean = false

  ngOnInit(): void {

    this.verificarAdm()
  }

  verificarAdm() {

    var config = {
      method: 'get',
      url: 'https://localhost:7274/Ip/VerificaIp',
      headers: {
        'Content-Type': 'application/json'
      }
    };

    let instance = this;

    axios(config)
      .then(function (response) {

        instance.adm = response.data["adm"]
        if(response.data["erro"] != undefined){

          instance.router.navigate(['/erro404']);
        }
        
        
      })
      .catch(function (error) {
      })
  }
}
