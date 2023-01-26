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

  ngOnInit(): void {
  }

  verificarAdm() {

    var config = {
      method: 'get',
      url: 'https://localhost:7274/Ip/VerificarAdm/',
      headers: {
        'Content-Type': 'application/json'
      }
    };

    let instance = this;

    axios(config)
      .then(function (response) {
     
        instance.router.navigate(['/sucesso']);

      })
      .catch(function (error) {
      })
  }
}
