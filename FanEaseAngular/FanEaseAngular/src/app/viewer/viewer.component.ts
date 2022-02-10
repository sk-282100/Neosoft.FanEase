import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-viewer',
  templateUrl: './viewer.component.html',
  styleUrls: ['./viewer.component.css']
})
export class ViewerComponent implements OnInit {
  
country:any;city:any;state:any;
  constructor(private router:Router, private http:HttpClient) { }
  reg(form:NgForm){
    const credentials={
      'firstName':form.value.FirstName,
      'middleName':form.value.MiddleName,
      'lastName':form.value.LastName,
      'address1':form.value.Address1,
      'address2':form.value.Address2,
      'cityId':parseInt(form.value.CityId),
      'countryId':parseInt(form.value.CountryId),
      'stateId':parseInt(form.value.StateId),
      'emailId':form.value.EmailId,
      'mobileNumber':form.value.MobileNumber,
      'password':form.value.Password,
      
      // 'date':form.value.date.toString()
    }
    console.log(credentials);
    this.http.post("https://localhost:44330/api/Viewer?api-version=1", credentials).subscribe(response => {
      console.log(response);
      this.router.navigate(["/"]);
    }, err => {
    });
  }

  ngOnInit(): void {
    this.http.get("https://localhost:44330/api/Common/GetCountryList?api-version=1").subscribe(response => {
      console.log(response);
      this.country=response;
    }, err => {
    });
  }
  loadState(id:any){
    console.log(id.target.value);
    this.http.get("https://localhost:44330/api/Common/GetStateList?countryId="+id.target.value+"&api-version=1").subscribe(response => {
      console.log(response);
      this.state=response;
    }, err => {
    });
  }
  loadCity(id:any){
    console.log(id.target.value);
    this.http.get("https://localhost:44330/api/Common/GetCityList?stateId="+id.target.value+"&api-version=1").subscribe(response => {
      console.log(response);
      this.city=response;
    }, err => {
    });
  }

}
