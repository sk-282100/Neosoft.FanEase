import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { ConnectableObservable } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  invalidLogin:boolean;
  constructor(private router:Router, private http:HttpClient) { }
  login(form:NgForm){
    const credentials={
      'username':form.value.username,
      'password':form.value.password
    }
    console.log(form.value.username);
    console.log(form.value.password);

    this.http.post("https://localhost:44332/api/Login/CheckUsernameAndPassword?api-version=1", credentials).subscribe(response => {
      console.log(response);
      const token = (<any>response).token;
      localStorage.setItem("jwt", token);
      this.invalidLogin = false;
      this.router.navigate(["/"]);
    }, err => {
      this.invalidLogin = true;
    });
  }

  ngOnInit(): void {
  }

}
